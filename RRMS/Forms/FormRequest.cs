using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRMS.Forms
{
    public partial class FormRequest : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormRequest()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvReq;
            LoadResidentIDs();
            LoadServiceIDs();

            // Initialize Status ComboBox
            cbbSerStatus.Items.AddRange(new string[] { "Pending", "Completed", "Cancelled" });
            cbbSerStatus.SelectedIndex = 0;

            // Event handlers
            cbbResID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;
            cbbSerID.SelectedIndexChanged += CbbServiceID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnRequestInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnRequestInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnRequestUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnRequestUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnRequestDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnRequestDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvReq.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void LoadResidentIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object resIDObj = dr["ResidentID"];
                    if (resIDObj != DBNull.Value)
                    {
                        string? resID = resIDObj.ToString();
                        cbbResID.Items.Add(resID);
                    }
                }
            }
        }

        private void LoadServiceIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadServiceIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object serIDObj = dr["ServiceID"];
                    if (serIDObj != DBNull.Value)
                    {
                        string? serID = serIDObj.ToString();
                        cbbSerID.Items.Add(serID);
                    }
                }
            }
        }

        private void CbbResidentID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbResID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentID", cbbResID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string firstName = dr["FirstName"].ToString() ?? string.Empty;
                            string lastName = dr["LastName"].ToString() ?? string.Empty;
                            txtResName.Text = $"{firstName} {lastName}".Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResName.Text = string.Empty;
                }
            }
            else
            {
                txtResName.Text = string.Empty;
            }
        }

        private void CbbServiceID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbSerID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetServiceById", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", cbbSerID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtSerName.Text = dr["ServiceName"].ToString() ?? string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving service name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSerName.Text = string.Empty;
                }
            }
            else
            {
                txtSerName.Text = string.Empty;
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvReq.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvReq.Rows.Count;

                    for (int i = startIndex; i < dgvReq.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvReq.Rows.Count;
                        DataGridViewRow row = dgvReq.Rows[currentIndex];

                        string? id = row.Cells["colReqID"].Value?.ToString();
                        string? desc = row.Cells["colReqDesc"].Value?.ToString();
                        string? status = row.Cells["colStatus"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (desc != null && desc.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (status != null && status.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvReq.ClearSelection();
                            row.Selected = true;
                            dgvReq.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching requests found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvReq.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReq.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvReq.Rows[rowIndex];

                object cellValue = row.Cells["colReqID"].Value;
                int? requestID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (requestID.HasValue)
                {
                    var request = Helper.GetEntityById<Request>(Program.Connection, requestID.Value, "SP_GetRequestById");
                    if (request != null)
                    {
                        PopulateFields(request);
                    }
                    else
                    {
                        MessageBox.Show("Request not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Request ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtReqID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtReqID, false);
        }

        private void DoOnRequestDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateRequestView();
                    MessageBox.Show("Request deleted successfully!", "Delete Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvReq.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvReq.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvReq.Rows[rowIndex].Cells["colReqID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this request?\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRequest";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RequestID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Request ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnRequestUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvReq.CurrentCell == null) return;
            int rowIndex = dgvReq.CurrentCell.RowIndex;

            UpdateRequestView();

            if (rowIndex < dgvReq.Rows.Count)
            {
                dgvReq.Rows[rowIndex].Selected = true;
                dgvReq.CurrentCell = dgvReq[0, rowIndex];
            }

            MessageBox.Show("Request updated successfully!", "Update Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvReq.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReq.SelectedCells[0].RowIndex;
                object cellValue = dgvReq.Rows[rowIndex].Cells["colReqID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var request = GatherRequestInput();
                    request.ID = id;

                    if (TryParseInputs(request))
                    {
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to update this request?",
                            "Confirm Update",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(request, "SP_UpdateRequest", "Update");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid request to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnRequestInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetRequestById";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Request>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvReq.Invoke((MethodInvoker)delegate
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
            var request = GatherRequestInput();

            if (TryParseInputs(request))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(request, "SP_InsertRequest", "Insert");
                UpdateRequestView();
            }
        }

        private Request GatherRequestInput()
        {
            int resID = 0, serID = 0;
            if (cbbResID.SelectedItem != null)
                int.TryParse(cbbResID.SelectedItem.ToString(), out resID);
            if (cbbSerID.SelectedItem != null)
                int.TryParse(cbbSerID.SelectedItem.ToString(), out serID);

            return new Request()
            {
                Start = dtpReqDate.Value,
                Description = txtReqDesc.Text.Trim(),
                Type = cbbSerStatus.SelectedItem?.ToString() ?? "Pending" ?? "Completed" ?? "Canceled",
                ResidentID = resID,
                ServiceID = serID
            };
        }

        private void PopulateFields(Request? request)
        {
            if (request != null)
            {
                txtReqID.Text = request.ID.ToString();
                dtpReqDate.Value = request.Start ?? DateTime.Now;
                txtReqDesc.Text = request.Description;
                cbbSerStatus.Text = request.Type;
                cbbResID.Text = request.ResidentID.ToString();
                cbbSerID.Text = request.ServiceID.ToString();
            }
            else
            {
                txtReqID.Text = string.Empty;
                dtpReqDate.Value = DateTime.Now;
                txtReqDesc.Text = string.Empty;
                cbbSerStatus.SelectedIndex = 0;
                cbbResID.SelectedIndex = -1;
                cbbSerID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
                txtSerName.Text = string.Empty;
            }
        }

        private bool TryParseInputs(Request request)
        {
            if (request.ResidentID <= 0)
            {
                MessageBox.Show("Please select a valid Resident ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (request.ServiceID <= 0)
            {
                MessageBox.Show("Please select a valid Service ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                MessageBox.Show("Please enter a request description.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateRequestView()
        {
            try
            {
                dgvReq.Rows.Clear();
                string SP_Name = "SP_GetAllRequests";

                var result = Helper.GetAllEntities<Request>(Program.Connection, SP_Name);

                foreach (var request in result)
                {
                    AddToView(request);
                }
                dgvReq.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReq.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Requests",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigView()
        {
            dgvReq.Columns.Clear();
            dgvReq.Columns.Add("colReqID", "Request ID");
            dgvReq.Columns.Add("colReqDate", "Date");
            dgvReq.Columns.Add("colReqDesc", "Description");
            dgvReq.Columns.Add("colStatus", "Status");
            dgvReq.Columns.Add("colResID", "Resident ID");
            dgvReq.Columns.Add("colSerID", "Service ID");

            dgvReq.Columns[0].Width = 100;
            dgvReq.Columns[1].Width = 120;
            dgvReq.Columns[2].Width = 200;
            dgvReq.Columns[3].Width = 100;
            dgvReq.Columns[4].Width = 100;
            dgvReq.Columns[5].Width = 100;

            dgvReq.DefaultCellStyle.BackColor = Color.White;
            dgvReq.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRequests";
                var result = Helper.GetAllEntities<Request>(Program.Connection, SP_Name);
                dgvReq.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Request>(
                    dgvReq,
                    request => new object[]
                    {
                        request.ID,
                        request.Start?.ToString("yyyy-MM-dd") ?? string.Empty,
                        request.Description,
                        request.Status,
                        request.ResidentID,
                        request.ServiceID
                    }
                );

                foreach (var request in result)
                {
                    entityViewAdder.AddToView(request);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving Requests",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Request request)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvReq,
                request.ID,
                request.Start?.ToString("yyyy-MM-dd") ?? string.Empty,
                request.Description,
                request.Status,
                request.ResidentID,
                request.ServiceID
            );
            row.Tag = request.ID;
            dgvReq.Rows.Add(row);
        }
    }
}