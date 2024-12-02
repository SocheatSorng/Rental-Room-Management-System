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
    public partial class FormLeaseAgreement : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormLeaseAgreement()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvLease;
            LoadResidentIDs();

            // Event handlers
            cbbResID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnLeaseInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnLeaseInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnLeaseUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnLeaseUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnLeaseDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnLeaseDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvLease.SelectionChanged += DoClickRecord;
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
                cmd.Parameters.AddWithValue("@ResidentID", cbbResID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtResidentName.Text = dr[3].ToString();
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
                dgvLease.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvLease.Rows.Count;

                    for (int i = startIndex; i < dgvLease.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvLease.Rows.Count;
                        DataGridViewRow row = dgvLease.Rows[currentIndex];

                        string? id = row.Cells["colLeaseID"].Value?.ToString();
                        string? monthlyRent = row.Cells["colMonthlyRent"].Value?.ToString();
                        string? residentId = row.Cells["colResidentID"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (monthlyRent != null && monthlyRent.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (residentId != null && residentId.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvLease.ClearSelection();
                            row.Selected = true;
                            dgvLease.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching leases found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvLease.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLease.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvLease.Rows[rowIndex];

                object cellValue = row.Cells["colLeaseID"].Value;
                int? leaseID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (leaseID.HasValue)
                {
                    var lease = Helper.GetEntityById<Model.LeaseAgreement>(Program.Connection, leaseID.Value, "SP_GetLeaseAgreementByID");
                    if (lease != null)
                    {
                        PopulateFields(lease);
                    }
                    else
                    {
                        MessageBox.Show("Lease not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Lease ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtLeaseID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtLeaseID, false);
        }

        private void DoOnLeaseDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateLeaseView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvLease.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvLease.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvLease.Rows[rowIndex].Cells["colLeaseID"].Value);

                using var cmd = Program.Connection.CreateCommand();
                cmd.CommandText = "SP_DeleteLeaseAgreement";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeaseID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Lease ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnLeaseUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvLease.CurrentCell == null) return;
            int rowIndex = dgvLease.CurrentCell.RowIndex;

            UpdateLeaseView();

            // Restore selection to the updated row
            if (rowIndex < dgvLease.Rows.Count)
            {
                dgvLease.Rows[rowIndex].Selected = true;
                dgvLease.CurrentCell = dgvLease[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvLease.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLease.SelectedCells[0].RowIndex;
                object cellValue = dgvLease.Rows[rowIndex].Cells["colLeaseID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var lease = GatherLeaseInput();
                    lease.ID = id;

                    if (ValidateInputs())
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(lease, "SP_UpdateLeaseAgreement", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid lease to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a lease to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnLeaseInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetLeaseAgreementByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Model.LeaseAgreement>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvLease.Invoke((MethodInvoker)delegate
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
            var lease = GatherLeaseInput();

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(lease, "SP_InsertLeaseAgreement", "Insert");
            }
        }

        private Model.LeaseAgreement GatherLeaseInput()
        {
            int residentId;
            if (cbbResID.SelectedItem != null && int.TryParse(cbbResID.SelectedItem.ToString(), out residentId))
            {
                return new Model.LeaseAgreement
                {
                    StartDate = dtpLeaseSD.Value,
                    EndDate = dtpLeaseED.Value,
                    CostPrice = Double.Parse(txtMonthlyRent.Text),
                    Description = txtTerms.Text.Trim(),
                    ResID = residentId
                };
            }
            else
            {
                MessageBox.Show("Please select a valid Resident ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void UpdateLeaseView()
        {
            try
            {
                dgvLease.Rows.Clear();
                string SP_Name = "SP_GetAllLeaseAgreements";

                var result = Helper.GetAllEntities<Model.LeaseAgreement>(Program.Connection, SP_Name);

                foreach (var lease in result)
                {
                    AddToView(lease);
                }
                dgvLease.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLease.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Leases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFields(Model.LeaseAgreement? lease)
        {
            if (lease != null)
            {
                txtLeaseID.Text = lease.ID.ToString();
                dtpLeaseSD.Value = lease.StartDate;
                dtpLeaseED.Value = lease.EndDate;
                txtMonthlyRent.Text = lease.CostPrice.ToString();
                txtTerms.Text = lease.Description;
                cbbResID.Text = lease.ResID.ToString();
                txtResidentName.Text = lease.ResName;
            }
            else
            {
                txtLeaseID.Text = string.Empty;
                dtpLeaseSD.Value = DateTime.Now;
                dtpLeaseED.Value = DateTime.Now;
                txtMonthlyRent.Text = string.Empty;
                txtTerms.Text = string.Empty;
                cbbResID.SelectedIndex = -1;
                txtResidentName.Text = string.Empty;
            }
        }

        private bool ValidateInputs()
        {
            if (dtpLeaseED.Value < dtpLeaseSD.Value)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(txtMonthlyRent.Text, out _))
            {
                MessageBox.Show("Please enter a valid monthly rent amount.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTerms.Text))
            {
                MessageBox.Show("Please enter terms and conditions.", "Validation Error");
                return false;
            }

            if (cbbResID.SelectedItem == null)
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
            dgvLease.Columns.Clear();
            dgvLease.Columns.Add("colLeaseID", "Lease ID");
            dgvLease.Columns.Add("colStartDate", "Start Date");
            dgvLease.Columns.Add("colEndDate", "End Date");
            dgvLease.Columns.Add("colMonthlyRent", "Monthly Rent");
            dgvLease.Columns.Add("colTerms", "Terms");
            dgvLease.Columns.Add("colResidentID", "Resident ID");
            dgvLease.Columns.Add("colResidentName", "Resident Name");

            dgvLease.Columns[0].Width = 80;
            dgvLease.Columns[1].Width = 100;
            dgvLease.Columns[2].Width = 100;
            dgvLease.Columns[3].Width = 100;
            dgvLease.Columns[4].Width = 150;
            dgvLease.Columns[5].Width = 80;
            dgvLease.Columns[6].Width = 120;

            dgvLease.DefaultCellStyle.BackColor = Color.White;
            dgvLease.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllLeaseAgreements";
                var result = Helper.GetAllEntities<Model.LeaseAgreement>(Program.Connection, SP_Name);
                dgvLease.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Model.LeaseAgreement>(dgvLease, lease => new object[]
                {
                    lease.ID,
                    lease.StartDate.ToString("yyyy-MM-dd"),
                    lease.EndDate.ToString("yyyy-MM-dd"),
                    lease.CostPrice,
                    lease.Description,
                    lease.ResID,
                    lease.ResName
                });

                foreach (var lease in result)
                {
                    entityViewAdder.AddToView(lease);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving leases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Model.LeaseAgreement lease)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvLease,
                lease.ID,
                lease.StartDate.ToString("yyyy-MM-dd"),
                lease.EndDate.ToString("yyyy-MM-dd"),
                lease.CostPrice,
                lease.Description,
                lease.ResID,
                lease.ResName
            );
            row.Tag = lease.ID;
            dgvLease.Rows.Add(row);
        }
    }
}