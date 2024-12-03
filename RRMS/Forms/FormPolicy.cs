using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
            cbbResID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;

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
                    object resIDObj = dr["ID"];
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
        private void CbbResidentID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbResID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResID", cbbResID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtResName.Text = dr[2].ToString();
                    }
                }
            }
            else
            {
                txtResName.Text = "";
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
                        string? name = row.Cells["colPolName"].Value?.ToString();
                        string? desc = row.Cells["colDesc"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (name != null && name.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (desc != null && desc.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
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
                        MessageBox.Show("No more matching policies found. Starting over.", "Search Result",
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
            if (dgvPol.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPol.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvPol.Rows[rowIndex];

                object cellValue = row.Cells["colPolID"].Value;
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

                using var cmd = Program.Connection.CreateCommand();
                cmd.CommandText = "SP_DeletePolicy";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PolID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Policy ID > {id}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
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

                    if (TryParseInputs(policy.FirstName, policy.Description, policy.ID))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(policy, "SP_UpdatePolicy", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid policy to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a policy to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (TryParseInputs(policy.FirstName, policy.Description, policy.ID))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(policy, "SP_InsertPolicy", "Insert");
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool TryParseInputs(string polName, string desc, int resID)
        {
            if (string.IsNullOrEmpty(polName))
            {
                MessageBox.Show("Policy name must not be empty.", "Inserting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Description must not be empty.", "Inserting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (resID < 0)
            {
                MessageBox.Show("Resident ID is not selected", "Inserting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void UpdatePolicyView()
        {
            try
            {
                dgvPol.Rows.Clear();
                string SP_Name = "SP_GetAllPolicys";

                var result = Helper.GetAllEntities<Model.Policy>(Program.Connection, SP_Name);

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

        private Model.Policy GatherPolicyInput()
        {
            int resID;
            if (cbbResID.SelectedItem != null && int.TryParse(cbbResID.SelectedItem.ToString(), out resID))
            {
                return new Model.Policy()
                {
                    FirstName = txtPolName.Text.Trim(),
                    Description = txtPolDesc.Text.Trim(),
                    Start = dtpPolCD.Value,
                    End = dtpPolUD.Value,
                    ResidentID = resID,
                    //Re = txtResName.Text.Trim(),
                };
            }
            else
            {
                MessageBox.Show("Please select a valid Resident ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void PopulateFields(Model.Policy? policy)
        {
            if (policy != null)
            {
                txtPolID.Text = policy.PolID.ToString();
                txtPolName.Text = policy.FirstName;
                txtPolDesc.Text = policy.Description;
                dtpPolCD.Value = policy.Start ?? DateTime.Now;
                dtpPolUD.Value = policy.End ?? DateTime.Now;

                // Set Resident ID in ComboBox
                cbbResID.SelectedItem = policy.ID.ToString();

                // Fetch and set Resident Name
                if (cbbResID.SelectedItem != null)
                {
                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentID", policy.ID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtResName.Text = dr["Name"].ToString(); // Assuming the resident name is in the 3rd column
                        }
                    }
                }
            }
            else
            {
                txtPolID.Text = string.Empty;
                txtPolName.Text = string.Empty;
                txtPolDesc.Text = string.Empty;
                dtpPolCD.Value = DateTime.Now;
                dtpPolUD.Value = DateTime.Now;
                cbbResID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
            }
        }
        private void ConfigView()
        {
            dgvPol.Columns.Clear();
            dgvPol.Columns.Add("colPolID", "Policy ID");
            dgvPol.Columns.Add("colPolName", "Policy Name");
            dgvPol.Columns.Add("colDesc", "Description");
            dgvPol.Columns[0].Width = 80;
            dgvPol.Columns[1].Width = 150;
            dgvPol.Columns[2].Width = 200;
            dgvPol.DefaultCellStyle.BackColor = Color.White;
            dgvPol.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllPolicys";
                var result = Helper.GetAllEntities<Model.Policy>(Program.Connection, SP_Name);
                dgvPol.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Model.Policy>(dgvPol, policy => new object[]
                {
                    policy.PolID,
                    policy.FirstName,
                    policy.Description
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
            row.CreateCells(dgvPol,
                policy.PolID,
                policy.FirstName,
                policy.Description
            );
            row.Tag = policy.PolID;
            dgvPol.Rows.Add(row);
        }

    }
}
