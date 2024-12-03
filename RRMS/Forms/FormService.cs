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
            cbbVenID.SelectedIndexChanged += cbbVenID_SelectedIndexChanged;
            LoadRoomIDs();
            cbbRoomID.SelectedIndexChanged += cbbRoomID_SelectedIndexChanged;

            ConfigView();
            _bs.DataSource = dgvSer;

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
                        cbbRoomID.DisplayMember = roomID;
                        cbbRoomID.ValueMember = roomID;
                    }
                }
            }
        }
        private void cbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cbbRoomID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomID", cbbRoomID.SelectedItem);
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtRoomID.Text = dr[1].ToString();
                    }
                }
            }
            else
            {
                txtRoomID.Text = "";
            }
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
                        cbbVenID.DisplayMember = venID;
                        cbbVenID.ValueMember = venID;
                    }
                }
            }
        }
        private void cbbVenID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cbbVenID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetVendorByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorID", cbbVenID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtVenName.Text = dr[1].ToString();
                    }
                }
            }
            else
            {
                txtVenName.Text = "";
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

                        string? id = row.Cells["colSerID"].Value?.ToString();
                        string? serviceName = row.Cells["colSerName"].Value?.ToString();
                        string? description = row.Cells["colSerDesc"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (serviceName != null && serviceName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (description != null && description.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
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

                object cellValue = row.Cells["colSerID"].Value;
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
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvSer.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvSer.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvSer.Rows[rowIndex].Cells["colSerID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this service?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteService";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Service ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateServiceView();
                    PopulateFields(null);
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

                    if (TryParseInputs(service.FirstName, service.CostPrice))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(service, "SP_UpdateService", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entities.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid service to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (TryParseInputs(service.FirstName, service.CostPrice))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(service, "SP_InsertService", "Insert");
            }
        }

        private bool TryParseInputs(string name,double cost)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Service name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cost < 0)
            {
                MessageBox.Show("Please enter a valid cost.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Service GatherServiceInput()
        {
            int venID;
            int roomID;
            double cost;
            double.TryParse(txtSerCost.Text.Trim(), out cost);
            if (cbbVenID.SelectedItem != null && int.TryParse(cbbVenID.SelectedItem.ToString(), out venID));
            if (cbbRoomID.SelectedItem != null && int.TryParse(cbbRoomID.SelectedItem.ToString(), out roomID));
            return new Service()
            {
                FirstName = txtSerName.Text.Trim(),
                Description = txtSerDesc.Text.Trim(),
                CostPrice = cost,
                //VenID = venID,
                //RoomID = roomID
            };
        }

        private void PopulateFields(Service? service)
        {
            if (service != null)
            {
                txtSerID.Text = service.ID.ToString();
                txtSerName.Text = service.FirstName;
                txtSerDesc.Text = service.Description;
                txtSerCost.Text = service.Cost.ToString();
            }
            else
            {
                txtSerID.Text = string.Empty;
                txtSerName.Text = string.Empty;
                txtSerDesc.Text = string.Empty;
                txtSerCost.Text = string.Empty;
            }
        }

        private void ConfigView()
        {
            dgvSer.Columns.Clear();
            dgvSer.Columns.Add("colServiceID", "Service ID");
            dgvSer.Columns.Add("colServiceName", "Service Name");
            dgvSer.Columns.Add("colServiceDesc", "Description");
            dgvSer.Columns.Add("colServiceCost", "Cost");

            dgvSer.Columns[0].Width = 100;
            dgvSer.Columns[1].Width = 200;
            dgvSer.Columns[2].Width = 300;
            dgvSer.Columns[3].Width = 100;

            dgvSer.DefaultCellStyle.BackColor = Color.White;
            dgvSer.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllServices";
                var result = Helper.GetAllEntities<Service>(Program.Connection, SP_Name);
                dgvSer.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Service>(dgvSer,
                    service => new object[] { service.ID, service.FirstName, service.Description, service.Cost });
                foreach (var service in result)
                {
                    entityViewAdder.AddToView(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Service service)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvSer, service.ID, service.FirstName, service.Description, service.Cost);
            row.Tag = service.ID;
            dgvSer.Rows.Add(row);
        }
    }
}