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
    public partial class FormRequest : Form
    {
        private int lastHighlightedIndex = -1;

        public FormRequest()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;

            ConfigView();

            // Initialize status ComboBox
            if (status.Items.Count == 0)
            {
                status.Items.AddRange(new string[] { "Pending", "Confirmed", "Completed", "Cancelled" });
                status.SelectedIndex = 0;
            }

            // Set up event handlers for ID validation
            residentid.KeyDown += ResidentID_KeyDown;
            serviceid.KeyDown += ServiceID_KeyDown;

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

            btnClear.Click += DoClickNew;
            dgvReq.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;

            // Make certain textboxes read-only
            requestid.ReadOnly = true;
            residentname.ReadOnly = true;
            servicename.ReadOnly = true;
        }


        private void ResidentID_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(residentid.Text))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResID", residentid.Text);
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                residentname.Text = dr[2].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Resident not found!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                residentname.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error finding resident: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        residentname.Text = "";
                    }
                }
                else
                {
                    residentname.Text = "";
                }
            }
        }

        private void ServiceID_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(serviceid.Text))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetServiceByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", serviceid.Text);
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                servicename.Text = dr["ServiceName"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Service not found!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                servicename.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error finding service: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        servicename.Text = "";
                    }
                }
                else
                {
                    servicename.Text = "";
                }
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

                        string? id = row.Cells["colRequestID"].Value?.ToString();
                        string? description = row.Cells["colDescription"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (description != null && description.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
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
                        MessageBox.Show("No more matching requests found. Starting over.", "Search Result",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                object cellValue = row.Cells["colRequestID"].Value;
                int? requestID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (requestID.HasValue)
                {
                    var request = Helper.GetEntityById<Request>(Program.Connection, requestID.Value, "SP_GetRequestByID");
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
            ManageControl.EnableControl(requestid, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(requestid, false);
        }

        private void DoOnRequestDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateRequestView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvReq.SelectedCells.Count <= 0) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this request?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int rowIndex = dgvReq.SelectedCells[0].RowIndex;
                    int id = Convert.ToInt32(dgvReq.Rows[rowIndex].Cells["colRequestID"].Value);

                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRequest";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RequestID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Request ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvReq.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReq.SelectedCells[0].RowIndex;
                object cellValue = dgvReq.Rows[rowIndex].Cells["colRequestID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var request = GatherRequestInput();
                    request.ID = id;

                    if (ValidateInputs())
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(request, "SP_UpdateRequest", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid request to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DoOnRequestInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Request>(Program.Connection, e.ByteId, "SP_GetRequestByID");

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

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(request, "SP_InsertRequest", "Insert");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(description.Text))
            {
                MessageBox.Show("Description must not be empty.", "Validation Error");
                return false;
            }

            if (string.IsNullOrEmpty(residentid.Text))
            {
                MessageBox.Show("Please enter a Resident ID.", "Validation Error");
                return false;
            }

            if (string.IsNullOrEmpty(serviceid.Text))
            {
                MessageBox.Show("Please enter a Service ID.", "Validation Error");
                return false;
            }

            if (status.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status.", "Validation Error");
                return false;
            }

            // Additional validation to check if the IDs are valid numbers
            if (!int.TryParse(residentid.Text, out _))
            {
                MessageBox.Show("Please enter a valid Resident ID number.", "Validation Error");
                return false;
            }

            if (!int.TryParse(serviceid.Text, out _))
            {
                MessageBox.Show("Please enter a valid Service ID number.", "Validation Error");
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
                MessageBox.Show(ex.Message, "Updating Requests", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Request GatherRequestInput()
        {
            if (!string.IsNullOrEmpty(residentid.Text) && !string.IsNullOrEmpty(serviceid.Text))
            {
                if (int.TryParse(residentid.Text, out int resID) && int.TryParse(serviceid.Text, out int servID))
                {
                    return new Request()
                    {
                        Start = requestdate.Value,
                        Description = description.Text.Trim(),
                        Stat = status.Text,
                        ResID = resID,
                        SerID = servID,
                        FirstName = residentname.Text,
                        LastName = servicename.Text
                    };
                }
            }

            MessageBox.Show("Please enter valid Resident and Service IDs.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void PopulateFields(Request? request)
        {
            if (request != null)
            {
                requestid.Text = request.ID.ToString();
                requestdate.Value = request.Start;
                description.Text = request.Description;
                status.Text = request.Stat;
                residentid.Text = request.ResID.ToString();
                serviceid.Text = request.SerID.ToString();
                residentname.Text = request.FirstName;
                servicename.Text = request.LastName;
            }
            else
            {
                requestid.Text = string.Empty;
                requestdate.Value = DateTime.Now;
                description.Text = string.Empty;
                status.SelectedIndex = 0;
                residentid.Text = string.Empty;
                serviceid.Text = string.Empty;
                residentname.Text = string.Empty;
                servicename.Text = string.Empty;
            }
        }

        private void ConfigView()
        {
            dgvReq.Columns.Clear();
            dgvReq.Columns.Add("colRequestID", "Request ID");
            dgvReq.Columns.Add("colRequestDate", "Request Date");
            dgvReq.Columns.Add("colDescription", "Description");
            dgvReq.Columns.Add("colStatus", "Status");
            dgvReq.Columns.Add("colResidentID", "Resident ID");
            dgvReq.Columns.Add("colServiceID", "Service ID");
            dgvReq.Columns.Add("colResidentName", "Resident Name");
            dgvReq.Columns.Add("colServiceName", "Service Name");

            // Set column widths
            dgvReq.Columns[0].Width = 100; // Request ID
            dgvReq.Columns[1].Width = 120; // Request Date
            dgvReq.Columns[2].Width = 200; // Description
            dgvReq.Columns[3].Width = 100; // Status
            dgvReq.Columns[4].Width = 100; // Resident ID
            dgvReq.Columns[5].Width = 100; // Service ID
            dgvReq.Columns[6].Width = 150; // Resident Name
            dgvReq.Columns[7].Width = 150; // Service Name

            dgvReq.DefaultCellStyle.BackColor = Color.White;
            dgvReq.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRequests";
                var result = Helper.GetAllEntities<Request>(Program.Connection, SP_Name);
                dgvReq.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Request>(dgvReq, request => new object[]
                {
                    request.ID,
                    request.Start.ToString("yyyy-MM-dd"),
                    request.Description,
                    request.Status,
                    request.ResID,
                    request.SerID,
                    request.FirstName,
                    request.LastName
                });

                foreach (var request in result)
                {
                    entityViewAdder.AddToView(request);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving requests", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Request request)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvReq,
                request.ID,
                request.Start.ToString("yyyy-MM-dd"),
                request.Description,
                request.Status,
                request.ResID,
                request.SerID,
                request.FirstName,
                request.LastName
            );
            row.Tag = request.ID;
            dgvReq.Rows.Add(row);
        }
    }
}