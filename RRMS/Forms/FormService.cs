using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RRMS.Forms
{
    public partial class FormService : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormService()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvSer;
            LoadVendorIDs();
            LoadRoomIDs();

            // Event handlers
            cbbVenID.SelectedIndexChanged += CbbVendorID_SelectedIndexChanged;
            cbbRoomID.SelectedIndexChanged += CbbRoomID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnServiceInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnServiceInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnServiceUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnServiceUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnServiceDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnServiceDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvSer.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void LoadVendorIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadVendorIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object venIDObj = dr["VendorID"];
                    if (venIDObj != DBNull.Value)
                    {
                        string? venID = venIDObj.ToString();
                        cbbVenID.Items.Add(venID);
                    }
                }
            }
        }

        private void LoadRoomIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadRoomIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object roomIDObj = dr["RoomID"];
                    if (roomIDObj != DBNull.Value)
                    {
                        string? roomID = roomIDObj.ToString();
                        cbbRoomID.Items.Add(roomID);
                    }
                }
            }
        }

        private void CbbVendorID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbVenID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetVendorByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorID", cbbVenID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtVenName.Text = dr["Name"].ToString() ?? string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving vendor name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVenName.Text = string.Empty;
                }
            }
            else
            {
                txtVenName.Text = string.Empty;
            }
        }

        private void CbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbRoomID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", cbbRoomID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtRoomID.Text = dr["RoomNumber"].ToString() ?? string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving room number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRoomID.Text = string.Empty;
                }
            }
            else
            {
                txtRoomID.Text = string.Empty;
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvSer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvSer.Rows.Count;

                    for (int i = startIndex; i < dgvSer.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvSer.Rows.Count;
                        DataGridViewRow row = dgvSer.Rows[currentIndex];

                        string? id = row.Cells["colServiceID"].Value?.ToString();
                        string? serviceName = row.Cells["colServiceName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (serviceName != null && serviceName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvSer.ClearSelection();
                            row.Selected = true;
                            dgvSer.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching services found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lastHighlightedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DoClickRecord(object? sender, EventArgs e)
        {
            if (dgvSer.SelectedCells.Count > 0)
            {
                int rowIndex = dgvSer.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvSer.Rows[rowIndex];

                object cellValue = row.Cells["colServiceID"].Value;
                int? serviceID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (serviceID.HasValue)
                {
                    var service = Helper.GetEntityById<Service>(Program.Connection, serviceID.Value, "SP_GetServiceByID");
                    if (service != null)
                    {
                        PopulateFields(service);
                    }
                    else
                    {
                        MessageBox.Show("Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Service ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtSerID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtSerID, false);
        }

        private void DoOnServiceDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateServiceView();
                    MessageBox.Show("Service deleted successfully!", "Delete Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvSer.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvSer.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvSer.Rows[rowIndex].Cells["colServiceID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this service?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteService";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", id);

                    cmd.ExecuteNonQuery();
                    UpdateServiceView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnServiceUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvSer.CurrentCell == null) return;
            int rowIndex = dgvSer.CurrentCell.RowIndex;

            UpdateServiceView();

            if (rowIndex < dgvSer.Rows.Count)
            {
                dgvSer.Rows[rowIndex].Selected = true;
                dgvSer.CurrentCell = dgvSer[0, rowIndex];
            }

            MessageBox.Show("Service updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvSer.SelectedCells.Count > 0)
            {
                int rowIndex = dgvSer.SelectedCells[0].RowIndex;
                object cellValue = dgvSer.Rows[rowIndex].Cells["colServiceID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var service = GatherServiceInput();
                    service.ID = id;

                    if (service != null && TryParseInputs(service))
                    {
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to update this service?",
                            "Confirm Update",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(service, "SP_UpdateService", "Update");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid service to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DoOnServiceInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetServiceByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Service>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvSer.Invoke((MethodInvoker)delegate
                        {
                            AddToView(result);
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            DoClickNew(sender, e);
        }

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var service = GatherServiceInput();

            if (service != null && TryParseInputs(service))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(service, "SP_InsertService", "Insert");
                UpdateServiceView();
            }
        }

        private Service GatherServiceInput()
        {
            if (!int.TryParse(cbbVenID.SelectedItem?.ToString(), out int vendorId) ||
                !int.TryParse(cbbRoomID.SelectedItem?.ToString(), out int roomId))
            {
                MessageBox.Show("Please select valid Vendor and Room IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!double.TryParse(txtSerCost.Text, out double cost))
            {
                MessageBox.Show("Please enter a valid cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Service
            {
                ServiceName = txtSerName.Text.Trim(),
                ServiceDescription = txtSerDesc.Text.Trim(),
                ServiceCost = cost,
                VendorID = vendorId,
                RoomID = roomId
            };
        }

        private void PopulateFields(Service? service)
        {
            if (service != null)
            {
                txtSerID.Text = service.ServiceID.ToString();
                txtSerName.Text = service.ServiceName;
                txtSerDesc.Text = service.ServiceDescription;
                txtSerCost.Text = service.ServiceCost.ToString();
                cbbVenID.Text = service.VendorID.ToString();
                cbbRoomID.Text = service.RoomID.ToString();
            }
            else
            {
                txtSerID.Text = string.Empty;
                txtSerName.Text = string.Empty;
                txtSerDesc.Text = string.Empty;
                txtSerCost.Text = string.Empty;
                cbbVenID.SelectedIndex = -1;
                cbbRoomID.SelectedIndex = -1;
                txtVenName.Text = string.Empty;
                txtRoomID.Text = string.Empty;
            }
        }

        private bool TryParseInputs(Service service)
        {
            if (string.IsNullOrEmpty(service.ServiceName))
            {
                MessageBox.Show("Service name must not be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (service.ServiceCost <= 0)
            {
                MessageBox.Show("Service cost must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (service.VendorID <= 0)
            {
                MessageBox.Show("Please select a valid vendor.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (service.RoomID <= 0)
            {
                MessageBox.Show("Please select a valid room.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateServiceView()
        {
            try
            {
                dgvSer.Rows.Clear();
                string SP_Name = "SP_GetAllServices";

                var result = Helper.GetAllEntities<Service>(Program.Connection, SP_Name);

                foreach (var service in result)
                {
                    AddToView(service);
                }
                dgvSer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSer.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigView()
        {
            dgvSer.Columns.Clear();
            dgvSer.Columns.Add("colServiceID", "Service ID");
            dgvSer.Columns.Add("colServiceName", "Service Name");
            dgvSer.Columns.Add("colServiceCost", "Cost");
            dgvSer.Columns.Add("colVendorName", "Vendor");
            dgvSer.Columns.Add("colRoomNumber", "Room");

            dgvSer.Columns[0].Width = 80;
            dgvSer.Columns[1].Width = 200;
            dgvSer.Columns[2].Width = 100;
            dgvSer.Columns[3].Width = 150;
            dgvSer.Columns[4].Width = 100;

            dgvSer.DefaultCellStyle.BackColor = Color.White;
            dgvSer.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllServices";
                var result = Helper.GetAllEntities<Service>(Program.Connection, SP_Name);
                dgvSer.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Service>(
                    dgvSer,
                    service => new object[]
                    {
                        service.ServiceID,
                        service.ServiceName,
                        service.ServiceCost.ToString("C"),
                        txtVenName.Text,
                        txtRoomID.Text
                    }
                );

                foreach (var service in result)
                {
                    entityViewAdder.AddToView(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Service service)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvSer,
                service.ServiceID,
                service.ServiceName,
                service.ServiceCost.ToString("C"),
                txtVenName.Text,
                txtRoomID.Text
            );
            row.Tag = service.ServiceID;
            dgvSer.Rows.Add(row);
        }
    }
}