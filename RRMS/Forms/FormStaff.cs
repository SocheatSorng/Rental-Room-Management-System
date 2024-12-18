﻿using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RRMS.Forms
{
    public partial class FormStaff : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;
        public FormStaff()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvSta;

            cbbStaPos.Items.Add("Manager");
            cbbStaPos.Items.Add("Staff");
            cbbStaPos.Items.Add("Security");
            cbbStaPos.Items.Add("Cleaner");
            cbbStaPos.SelectedIndex = 1;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnStaffInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnStaffInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnStaffUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnStaffUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnStaffDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnStaffDeleted;
            };

            btnNew.Click += DoClickNew;
            //btnClose.Click += (sender, e) => { this.Close(); };
            dgvSta.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvSta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvSta.Rows.Count;

                    for (int i = startIndex; i < dgvSta.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvSta.Rows.Count;
                        DataGridViewRow row = dgvSta.Rows[currentIndex];

                        string? id = row.Cells["colStaID"].Value?.ToString();
                        string? staffName = row.Cells["colStaName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (staffName != null && staffName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {

                            dgvSta.ClearSelection();

                            row.Selected = true;
                            dgvSta.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching staffs found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvSta.SelectedCells.Count > 0)
            {
                int rowIndex = dgvSta.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvSta.Rows[rowIndex];

                object cellValue = row.Cells["colStaID"].Value;
                int? staffID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (staffID.HasValue)
                {
                    var staff = Helper.GetEntityById<Staff>(Program.Connection, staffID.Value, "SP_GetStaffbyID");
                    if (staff != null)
                    {
                        PopulateFields(staff);
                    }
                    else
                    {
                        MessageBox.Show("Staff not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Staff ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtStaID, false);
        }
        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtStaID, false);
        }

        private void DoOnStaffDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateStaffView();
                    MessageBox.Show("Staff deleted successfully!", "Delete Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvSta.SelectedCells.Count <= 0) return;
            DialogResult result = MessageBox.Show(
            "Are you sure you want to delete this staff?\nThis action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                try
                {
                    int rowIndex = dgvSta.SelectedCells[0].RowIndex;
                    int id = Convert.ToInt32(dgvSta.Rows[rowIndex].Cells["colStaID"].Value);

                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteStaff";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Staff ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DoOnStaffUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvSta.CurrentCell == null) return;
            int rowIndex = dgvSta.CurrentCell.RowIndex;

            UpdateStaffView();

            // Restore selection to the updated row
            if (rowIndex < dgvSta.Rows.Count)
            {
                dgvSta.Rows[rowIndex].Selected = true;
                dgvSta.CurrentCell = dgvSta[0, rowIndex];
            }
            MessageBox.Show("Staff updated successfully!", "Update Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to update this staff?",
            "Confirm Update",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                if (dgvSta.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvSta.SelectedCells[0].RowIndex;
                    object cellValue = dgvSta.Rows[rowIndex].Cells["colStaID"].Value;

                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                    {
                        var staff = GatherStaffInput();
                        staff.ID = id;

                        if (TryParseInputs(staff.StaFName, staff.StaLName, staff.StaSex, staff.StaPosition, staff.StaPerNum, staff.StaSalary))
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(staff, "SP_UpdateStaff", "Update");
                        }
                        else
                        {
                            MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid staff to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a staff to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void DoOnStaffInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetStaffByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Staff>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvSta.Invoke((MethodInvoker)delegate
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
            var staff = GatherStaffInput();

            if (TryParseInputs(staff.FirstName, staff.LastName, staff.Sex, staff.Type, staff.PersonalNumber, staff.Salary))
            {
                // Create an instance of EntityService
                var entityService = new EntityService();

                // Call InsertOrUpdateEntity method
                entityService.InsertOrUpdateEntity(staff, "SP_InsertStaff", "Insert");
                UpdateStaffView();
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool TryParseInputs(string firstName, string lastName, string sex, string position,string personalNum, double salary)
        {

            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Last name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(sex))
            {
                MessageBox.Show("Sex must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(position))
            {
                MessageBox.Show("Position must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (salary < 0)
            {
                MessageBox.Show("Salary must be a valid positive number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateStaffView()
        {
            try
            {
                dgvSta.Rows.Clear();
                string SP_Name = "SP_GetAllStaffs";

                var result = Helper.GetAllEntities<Staff>(Program.Connection, SP_Name);

                foreach (var staff in result)
                {
                    AddToView(staff);
                }
                dgvSta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSta.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Staffs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Staff GatherStaffInput()
        {
            double salary;
            double.TryParse(txtStaSal.Text.Trim(), out salary);
            return new Staff()
            {
                FirstName = txtStaFN.Text.Trim(),
                LastName = txtStaLN.Text.Trim(),
                Sex = txtStaSex.Text.Trim(),
                BirthDate = dtpStaBD.Value,
                Type = cbbStaPos.SelectedItem.ToString(),
                HouseNo = txtStaHNo.Text.Trim(),
                StreetNo = txtStaSNo.Text.Trim(),
                Commune = txtStaCom.Text.Trim(),
                District = txtStaDis.Text.Trim(),
                Province = txtStaPro.Text.Trim(),
                PersonalNumber = txtStaPN.Text.Trim(),
                Salary = salary,
                Start = dtpStaHD.Value,
                End = dtpStaStop.Value,
            };
        }
        private void PopulateFields(Staff? staff)
        {
            if (staff != null)
            {
                // Populate the form fields with the staff's data
                txtStaID.Text = staff.ID.ToString();
                txtStaFN.Text = staff.FirstName;
                txtStaLN.Text = staff.LastName;
                txtStaSex.Text = staff.Sex;
                dtpStaBD.Value = staff.BirthDate ?? DateTime.Now;
                cbbStaPos.SelectedItem = staff.Type;
                txtStaHNo.Text = staff.HouseNo;
                txtStaSNo.Text = staff.StreetNo;
                txtStaCom.Text = staff.Commune;
                txtStaDis.Text = staff.District;
                txtStaPro.Text = staff.Province;
                txtStaPN.Text = staff.PersonalNumber;
                txtStaSal.Text = staff.Salary.ToString("F2");
                dtpStaHD.Value = staff.Start ?? DateTime.Now;
                dtpStaStop.Value = staff.End ?? DateTime.Now;
            }
            else
            {
                // Clear the fields for a new staff
                txtStaID.Text = string.Empty;
                txtStaFN.Text = string.Empty;
                txtStaLN.Text = string.Empty;
                txtStaSex.Text = string.Empty;
                dtpStaBD.Value = DateTime.Now;
                cbbStaPos.SelectedIndex = 0;
                txtStaHNo.Text = string.Empty;
                txtStaSNo.Text = string.Empty;
                txtStaCom.Text = string.Empty;
                txtStaDis.Text = string.Empty;
                txtStaPro.Text = string.Empty;
                txtStaPN.Text = string.Empty;
                txtStaSal.Text = string.Empty;
                dtpStaHD.Value = DateTime.Now;
                dtpStaStop.Value = DateTime.Now;
            }
        }
        private void ConfigView()
        {
            dgvSta.Columns.Clear();
            dgvSta.Columns.Add("colStaID", "Staff ID");
            dgvSta.Columns.Add("colStaName", "Staff Name");
            dgvSta.Columns[0].Width = 100;
            dgvSta.Columns[1].Width = 200;
            dgvSta.DefaultCellStyle.BackColor = Color.White;
            dgvSta.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllStaffs";
                var result = Helper.GetAllEntities<Staff>(Program.Connection, SP_Name);
                dgvSta.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Staff>(dgvSta, staff => new object[] { staff.ID, staff.FirstName + " " + staff.LastName });
                foreach (var staff in result)
                {
                    entityViewAdder.AddToView(staff);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving staffs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Staff staff)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvSta, staff.ID, staff.FirstName + " " + staff.LastName);
            row.Tag = staff.ID;
            dgvSta.Rows.Add(row);
        }
    }
}