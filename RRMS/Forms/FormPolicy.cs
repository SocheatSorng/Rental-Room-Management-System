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
    public partial class FormPolicy : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormPolicy()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvPol;
            LoadResidentIDs();
            LoadStaffIDs();

            // Event handlers
            cbbResID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;
            txtStaffID.SelectedIndexChanged += CbbStaffID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnPolicyInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnPolicyInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnPolicyUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnPolicyUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnPolicyDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnPolicyDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvPol.SelectionChanged += DoClickRecord;
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
                        cbbResID.DisplayMember = resID;
                        cbbResID.ValueMember = resID;
                    }
                }
            }
        }

        private void LoadStaffIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadStaffIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object staffIDObj = dr["StaffID"];
                    if (staffIDObj != DBNull.Value)
                    {
                        string? staffID = staffIDObj.ToString();
                        txtStaffID.Items.Add(staffID);
                        txtStaffID.DisplayMember = staffID;
                        txtStaffID.ValueMember = staffID;
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

        private void CbbStaffID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (txtStaffID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetStaffByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffID", txtStaffID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string firstName = dr["FirstName"].ToString() ?? string.Empty;
                            string lastName = dr["LastName"].ToString() ?? string.Empty;
                            txtStaffName.Text = $"{firstName} {lastName}".Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving staff name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStaffName.Text = string.Empty;
                }
            }
            else
            {
                txtStaffName.Text = string.Empty;
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvPol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvPol.Rows.Count;

                    for (int i = startIndex; i < dgvPol.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvPol.Rows.Count;
                        DataGridViewRow row = dgvPol.Rows[currentIndex];

                        string? id = row.Cells["colPolID"].Value?.ToString();
                        string? policyName = row.Cells["colPolName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (policyName != null && policyName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvPol.ClearSelection();
                            row.Selected = true;
                            dgvPol.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching policies found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvPol.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPol.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvPol.Rows[rowIndex];

                object cellValue = row.Cells["colPolID"].Value;
                int? policyID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (policyID.HasValue)
                {
                    var policy = Helper.GetEntityById<Policy>(Program.Connection, policyID.Value, "SP_GetPolicyByID");
                    if (policy != null)
                    {
                        PopulateFields(policy);
                    }
                    else
                    {
                        MessageBox.Show("Policy not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Policy ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtPolID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtPolID, false);
        }

        private void DoOnPolicyDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdatePolicyView();
                    MessageBox.Show("Policy deleted successfully!", "Delete Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvPol.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvPol.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvPol.Rows[rowIndex].Cells["colPolID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this policy?\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeletePolicy";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PolicyID", id);

                    cmd.ExecuteNonQuery();
                    UpdatePolicyView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnPolicyUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvPol.CurrentCell == null) return;
            int rowIndex = dgvPol.CurrentCell.RowIndex;

            UpdatePolicyView();

            if (rowIndex < dgvPol.Rows.Count)
            {
                dgvPol.Rows[rowIndex].Selected = true;
                dgvPol.CurrentCell = dgvPol[0, rowIndex];
            }

            MessageBox.Show("Policy updated successfully!", "Update Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvPol.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPol.SelectedCells[0].RowIndex;
                object cellValue = dgvPol.Rows[rowIndex].Cells["colPolID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var policy = GatherPolicyInput();
                    policy.ID = id;

                    if (ValidateInputs())
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(policy, "SP_UpdatePolicy", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid policy to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DoOnPolicyInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetPolicyByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Policy>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvPol.Invoke((MethodInvoker)delegate
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
            var policy = GatherPolicyInput();

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(policy, "SP_InsertPolicy", "Insert");
                UpdatePolicyView();
            }
        }

        private Policy GatherPolicyInput()
        {
            int resID = 0, staffID = 0;
            int.TryParse(cbbResID.SelectedItem?.ToString(), out resID);
            int.TryParse(txtStaffID.SelectedItem?.ToString(), out staffID);

            return new Policy()
            {
                Name = txtPolName.Text.Trim(),
                PolicyDescription = txtPolDesc.Text.Trim(),
                CreatedDate = dtpPolCD.Value,
                UpdatedDate = dtpPolUD.Value,
                ResidentID = resID,
                StaffID = staffID
            };
        }

        private void PopulateFields(Policy? policy)
        {
            if (policy != null)
            {
                txtPolID.Text = policy.ID.ToString();
                txtPolName.Text = policy.Name;
                txtPolDesc.Text = policy.PolicyDescription;
                dtpPolCD.Value = policy.CreatedDate ?? DateTime.Now;
                dtpPolUD.Value = policy.UpdatedDate ?? DateTime.Now;
                cbbResID.Text = policy.ResidentID.ToString();
                txtStaffID.Text = policy.StaffID.ToString();
            }
            else
            {
                txtPolID.Text = string.Empty;
                txtPolName.Text = string.Empty;
                txtPolDesc.Text = string.Empty;
                dtpPolCD.Value = DateTime.Now;
                dtpPolUD.Value = DateTime.Now;
                cbbResID.SelectedIndex = -1;
                txtStaffID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
                txtStaffName.Text = string.Empty;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPolName.Text))
            {
                MessageBox.Show("Policy name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbbResID.SelectedItem == null)
            {
                MessageBox.Show("Please select a resident.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtStaffID.SelectedItem == null)
            {
                MessageBox.Show("Please select a staff member.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void UpdatePolicyView()
        {
            try
            {
                dgvPol.Rows.Clear();
                string SP_Name = "SP_GetAllPolicies";

                var result = Helper.GetAllEntities<Policy>(Program.Connection, SP_Name);

                foreach (var policy in result)
                {
                    AddToView(policy);
                }
                dgvPol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPol.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigView()
        {
            dgvPol.Columns.Clear();
            dgvPol.Columns.Add("colPolID", "Policy ID");
            dgvPol.Columns.Add("colPolName", "Policy Name");
            dgvPol.Columns.Add("colPolDesc", "Description");
            dgvPol.Columns.Add("colPolCD", "Created Date");
            dgvPol.Columns.Add("colPolUD", "Updated Date");
            dgvPol.Columns.Add("colResID", "Resident ID");
            dgvPol.Columns.Add("colStaffID", "Staff ID");

            dgvPol.Columns[0].Width = 80;  // Policy ID
            dgvPol.Columns[1].Width = 150; // Policy Name
            dgvPol.Columns[2].Width = 200; // Description
            dgvPol.Columns[3].Width = 100; // Created Date
            dgvPol.Columns[4].Width = 100; // Updated Date
            dgvPol.Columns[5].Width = 80;  // Resident ID
            dgvPol.Columns[6].Width = 80;  // Staff ID

            dgvPol.DefaultCellStyle.BackColor = Color.White;
            dgvPol.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllPolicies";
                var result = Helper.GetAllEntities<Policy>(Program.Connection, SP_Name);
                dgvPol.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Policy>(
                    dgvPol,
                    policy => new object[]
                    {
                        policy.ID,
                        policy.Name,
                        policy.PolicyDescription,
                        policy.CreatedDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                        policy.UpdatedDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                        policy.ResidentID,
                        policy.StaffID
                    }
                );

                foreach (var policy in result)
                {
                    entityViewAdder.AddToView(policy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Policy policy)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvPol,
                policy.ID,
                policy.Name,
                policy.PolicyDescription,
                policy.CreatedDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                policy.UpdatedDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                policy.ResidentID,
                policy.StaffID
            );
            row.Tag = policy.ID;
            dgvPol.Rows.Add(row);
        }
    }
}