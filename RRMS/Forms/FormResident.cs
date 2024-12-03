using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RRMS.Forms
{
    public partial class FormResident : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;
        public FormResident()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvRes;

            // Populate the ComboBox with options
            cbbResType.Items.Add("Guest");
            cbbResType.Items.Add("Resident");
            cbbResType.SelectedIndex = 1; // Set default selection

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnResidentInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnResidentInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnResidentUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnResidentUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnResidentDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnResidentDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvRes.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvRes.Rows.Count;

                    for (int i = startIndex; i < dgvRes.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvRes.Rows.Count;
                        DataGridViewRow row = dgvRes.Rows[currentIndex];

                        string? id = row.Cells["colResID"].Value?.ToString();
                        string? residentName = row.Cells["colResName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (residentName != null && residentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {

                            dgvRes.ClearSelection();

                            row.Selected = true;
                            dgvRes.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching residents found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvRes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRes.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvRes.Rows[rowIndex];

                object cellValue = row.Cells["colResID"].Value;
                int? residentID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (residentID.HasValue)
                {
                    // Use the generic GetEntityById method to retrieve the Resident
                    var resident = Helper.GetEntityById<Resident>(Program.Connection, residentID.Value, "SP_GetResidentByID");
                    if (resident != null)
                    {
                        PopulateFields(resident);
                    }
                    else
                    {
                        MessageBox.Show("Resident not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Resident ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtResID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtResID, false); // Disable the ID input
        }
        private void DoOnResidentDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateResidentView();
                    // Show success message after deletion
                    MessageBox.Show("Resident deleted successfully!", "Delete Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvRes.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvRes.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvRes.Rows[rowIndex].Cells["colResID"].Value);

                // Show confirmation dialog before deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this resident?\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteResident";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Resident ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
                // If No, do nothing and return to form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnResidentUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvRes.CurrentCell == null) return;
            int rowIndex = dgvRes.CurrentCell.RowIndex;

            UpdateResidentView();

            // Restore selection to the updated row
            if (rowIndex < dgvRes.Rows.Count)
            {
                dgvRes.Rows[rowIndex].Selected = true;
                dgvRes.CurrentCell = dgvRes[0, rowIndex];
            }

            // Show success message
            MessageBox.Show("Resident updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRes.SelectedCells[0].RowIndex;
                object cellValue = dgvRes.Rows[rowIndex].Cells["colResID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var resident = GatherResidentInput();
                    resident.ID = id;

                    if (TryParseInputs(resident.Type, resident.FirstName, resident.Sex, resident.PersonalNumber, resident.ContactNumber))
                    {
                        // Show confirmation dialog
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to update this resident?",
                            "Confirm Update",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(resident, "SP_UpdateResident", "Update");
                        }
                        // If No, do nothing and return to form
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid resident to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a resident to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnResidentInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetResidentByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Resident>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvRes.Invoke((MethodInvoker)delegate
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
            var resident = GatherResidentInput();

            if (TryParseInputs(resident.Type, resident.FirstName, resident.Sex, resident.PersonalNumber, resident.ContactNumber))
            {
                // Create an instance of EntityService
                var entityService = new EntityService();

                // Call InsertOrUpdateEntity method
                entityService.InsertOrUpdateEntity(resident, "SP_InsertResident", "Insert");
                UpdateResidentView();
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool TryParseInputs(string residentType, string residentName, string sex, string resPN, string resCN)
        {
            if (string.IsNullOrEmpty(residentType))
            {
                MessageBox.Show("Resident type must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(residentName))
            {
                MessageBox.Show("Resident name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(sex))
            {
                MessageBox.Show("Resident sex must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(resPN))
            {
                MessageBox.Show("Resident personal number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(resCN))
            {
                MessageBox.Show("Resident contact number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateResidentView()
        {
            try
            {
                dgvRes.Rows.Clear();
                string SP_Name = "SP_GetAllResidents";

                var result = Helper.GetAllEntities<Resident>(Program.Connection, SP_Name);

                foreach (var resident in result)
                {
                    AddToView(resident);
                }
                dgvRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Residents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Resident GatherResidentInput()
        {
            return new Resident()
            {
                ResType = cbbResType?.SelectedItem?.ToString(),
                ResFirstName = txtResFirst.Text.Trim(),
                ResLastName = txtResLast.Text.Trim(),
                ResSex = txtResSex.Text.Trim(),
                ResBD = dtpResBOD.Value,
                ResPrevHouseNo = txtResHNo.Text.Trim(),
                ResPrevStNo = txtResStNo.Text.Trim(),
                ResPrevCommune = txtResCom.Text.Trim(),
                ResPrevDistrict = txtResDis.Text.Trim(),
                ResPrevProvince = txtResPro.Text.Trim(),
                ResPerNum = txtResPN.Text.Trim(),
                ResConNum = txtResCN.Text.Trim(),
                ResCheckIn = dtpResCID.Value,
                ResCheckOut = dtpResCOD.Value
            };
        }
        private void PopulateFields(Resident? resident)
        {
            if (resident != null)
            {
                // Populate the form fields with the resident's data
                txtResID.Text = resident.ID.ToString();
                cbbResType.SelectedItem = resident.ResType; // Set the selected value of the ComboBox
                txtResFirst.Text = resident.ResFirstName;
                txtResLast.Text = resident.ResLastName;
                txtResSex.Text = resident.ResSex;
                dtpResBOD.Value = resident.ResBD ?? DateTime.Now;
                txtResHNo.Text = resident.ResPrevHouseNo;
                txtResStNo.Text = resident.ResPrevStNo;
                txtResCom.Text = resident.ResPrevCommune;
                txtResDis.Text = resident.ResPrevDistrict;
                txtResPro.Text = resident.ResPrevProvince;
                txtResPN.Text = resident.ResPerNum;
                txtResCN.Text = resident.ResConNum;
                dtpResCID.Value = resident.ResCheckIn ?? DateTime.Now;
                dtpResCOD.Value = resident.ResCheckOut ?? DateTime.Now;
            }
            else
            {
                // Clear the fields for a new resident
                txtResID.Text = string.Empty;
                cbbResType.SelectedIndex = 0; // Reset to default selection
                txtResFirst.Text = string.Empty;
                txtResLast.Text = string.Empty;
                txtResSex.Text = string.Empty;
                dtpResBOD.Value = DateTime.Now;
                txtResHNo.Text = string.Empty;
                txtResStNo.Text = string.Empty;
                txtResCom.Text = string.Empty;
                txtResDis.Text = string.Empty;
                txtResPro.Text = string.Empty;
                txtResPN.Text = string.Empty;
                txtResCN.Text = string.Empty;
                dtpResCID.Value = DateTime.Now;
                dtpResCOD.Value = DateTime.Now;
            }
        }
        private void ConfigView()
        {
            dgvRes.Columns.Clear();
            dgvRes.Columns.Add("colResID", "Resident ID");
            dgvRes.Columns.Add("colResName", "Resident Name");
            dgvRes.Columns[0].Width = 100;
            dgvRes.Columns[1].Width = 400;
            dgvRes.DefaultCellStyle.BackColor = Color.White;
            dgvRes.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllResidents";
                var result = Helper.GetAllEntities<Resident>(Program.Connection, SP_Name);
                dgvRes.Rows.Clear();

                // Create an instance of EntityViewAdder
                var entityViewAdder = new EntityViewAdder<Resident>(
                    dgvRes,
                    resident => new object[] { resident.ID, $"{resident.FirstName} {resident.LastName}".Trim() }
                );

                // Use the AddToView method to add each resident to the DataGridView
                foreach (var resident in result)
                {
                    entityViewAdder.AddToView(resident);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving residents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Resident resident)
        {
            DataGridViewRow row = new DataGridViewRow();
            string fullName = $"{resident.FirstName} {resident.LastName}".Trim();
            row.CreateCells(dgvRes, resident.ID, fullName);
            row.Tag = resident.ID;
            dgvRes.Rows.Add(row);
        }
    }
}