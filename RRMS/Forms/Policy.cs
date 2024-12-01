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
    public partial class Policy : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public Policy()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvPolicy;
            LoadResidentIDs();

            // Make ID textbox and dates read-only
            txtID.ReadOnly = true;
            txtResidentName.ReadOnly = true;
            dateCreate.Enabled = false;
            dateUpdate.Enabled = false;

            // Event handlers
            cbbResidentID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;

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
            dgvPolicy.SelectionChanged += DoClickRecord;
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
                    object resIDObj = dr["ID"];
                    if (resIDObj != DBNull.Value)
                    {
                        string? resID = resIDObj.ToString();
                        cbbResidentID.Items.Add(resID);
                        cbbResidentID.DisplayMember = resID;
                        cbbResidentID.ValueMember = resID;
                    }
                }
            }
        }

        private void CbbResidentID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbResidentID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResID", cbbResidentID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtResidentName.Text = dr[2].ToString();
                    }
                }
            }
            else
            {
                txtResidentName.Text = "";
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvPolicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvPolicy.Rows.Count;

                    for (int i = startIndex; i < dgvPolicy.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvPolicy.Rows.Count;
                        DataGridViewRow row = dgvPolicy.Rows[currentIndex];

                        string? id = row.Cells["colPolicyID"].Value?.ToString();
                        string? name = row.Cells["colName"].Value?.ToString();
                        string? desc = row.Cells["colDesc"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (name != null && name.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (desc != null && desc.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvPolicy.ClearSelection();
                            row.Selected = true;
                            dgvPolicy.FirstDisplayedScrollingRowIndex = row.Index;
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
            if (dgvPolicy.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPolicy.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvPolicy.Rows[rowIndex];

                object cellValue = row.Cells["colPolicyID"].Value;
                int? policyID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (policyID.HasValue)
                {
                    var policy = Helper.GetEntityById<Model.Policy>(Program.Connection, policyID.Value, "SP_GetPolicyByID");
                    if (policy != null)
                    {
                        PopulateFields(policy);
                    }
                    else
                    {
                        MessageBox.Show("Policy not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ManageControl.EnableControl(txtID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtID, false);
        }

        private void DoOnPolicyDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdatePolicyView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvPolicy.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvPolicy.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvPolicy.Rows[rowIndex].Cells["colPolicyID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this policy?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeletePolicy";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PolicyID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Policy ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnPolicyUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvPolicy.CurrentCell == null) return;
            int rowIndex = dgvPolicy.CurrentCell.RowIndex;

            UpdatePolicyView();

            // Restore selection to the updated row
            if (rowIndex < dgvPolicy.Rows.Count)
            {
                dgvPolicy.Rows[rowIndex].Selected = true;
                dgvPolicy.CurrentCell = dgvPolicy[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvPolicy.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPolicy.SelectedCells[0].RowIndex;
                object cellValue = dgvPolicy.Rows[rowIndex].Cells["colPolicyID"].Value;

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
                    MessageBox.Show("Please select a valid policy to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a policy to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    var result = Helper.GetEntityById<Model.Policy>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvPolicy.Invoke((MethodInvoker)delegate
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
            }
        }

        private Model.Policy GatherPolicyInput()
        {
            int residentId;
            if (cbbResidentID.SelectedItem != null && int.TryParse(cbbResidentID.SelectedItem.ToString(), out residentId))
            {
                return new Model.Policy
                {
                    PolName = txtName.Text.Trim(),
                    Des = txtDesc.Text.Trim(),
                    ResID = residentId
                };
            }
            else
            {
                MessageBox.Show("Please select a valid Resident ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void UpdatePolicyView()
        {
            try
            {
                dgvPolicy.Rows.Clear();
                string SP_Name = "SP_GetAllPolicies";

                var result = Helper.GetAllEntities<Model.Policy>(Program.Connection, SP_Name);

                foreach (var policy in result)
                {
                    AddToView(policy);
                }
                dgvPolicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPolicy.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFields(Model.Policy? policy)
        {
            if (policy != null)
            {
                txtID.Text = policy.PolID.ToString();
                txtName.Text = policy.PolName;
                txtDesc.Text = policy.Des;
                dateCreate.Value = policy.CreDate;
                dateUpdate.Value = policy.UpdDate ?? DateTime.Now;
                cbbResidentID.Text = policy.ResID.ToString();
                txtResidentName.Text = policy.ResName;
            }
            else
            {
                txtID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtDesc.Text = string.Empty;
                dateCreate.Value = DateTime.Now;
                dateUpdate.Value = DateTime.Now;
                cbbResidentID.SelectedIndex = -1;
                txtResidentName.Text = string.Empty;
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter policy name.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Please enter description.", "Validation Error");
                return false;
            }

            if (cbbResidentID.SelectedItem == null)
            {
                MessageBox.Show("Please select a Resident ID.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResidentName.Text))
            {
                MessageBox.Show("Invalid Resident ID. Please select a valid Resident ID.", "Validation Error");
                return false;
            }

            return true;
        }
        private void ConfigView()
        {
            dgvPolicy.Columns.Clear();
            dgvPolicy.Columns.Add("colPolicyID", "Policy ID");
            dgvPolicy.Columns.Add("colName", "Name");
            dgvPolicy.Columns.Add("colDesc", "Description");
            dgvPolicy.Columns.Add("colCreatedDate", "Created Date");
            dgvPolicy.Columns.Add("colUpdatedDate", "Updated Date");
            dgvPolicy.Columns.Add("colResidentID", "Resident ID");
            dgvPolicy.Columns.Add("colResidentName", "Resident Name");

            dgvPolicy.Columns[0].Width = 80;
            dgvPolicy.Columns[1].Width = 100;
            dgvPolicy.Columns[2].Width = 150;
            dgvPolicy.Columns[3].Width = 100;
            dgvPolicy.Columns[4].Width = 100;
            dgvPolicy.Columns[5].Width = 80;
            dgvPolicy.Columns[6].Width = 120;

            dgvPolicy.DefaultCellStyle.BackColor = Color.White;
            dgvPolicy.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllPolicies";
                var result = Helper.GetAllEntities<Model.Policy>(Program.Connection, SP_Name);
                dgvPolicy.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Model.Policy>(dgvPolicy, policy => new object[]
                {
                    policy.PolID,
                    policy.PolName,
                    policy.Des,
                    policy.CreDate.ToString("yyyy-MM-dd"),
                    policy.UpdDate?.ToString("yyyy-MM-dd") ?? "",
                    policy.ResID,
                    policy.ResName
                });

                foreach (var policy in result)
                {
                    entityViewAdder.AddToView(policy);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Model.Policy policy)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvPolicy,
                policy.PolID,
                policy.PolName,
                policy.Des,
                policy.CreDate.ToString("yyyy-MM-dd"),
                policy.UpdDate?.ToString("yyyy-MM-dd") ?? "",
                policy.ResID,
                policy.ResName
            );
            row.Tag = policy.PolID;
            dgvPolicy.Rows.Add(row);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
