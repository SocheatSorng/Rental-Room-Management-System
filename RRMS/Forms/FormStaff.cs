using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;

namespace RRMS.Forms
{
    public partial class FormStaff : Form
    {
        BindingSource _bs = new();
        public FormStaff()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvSta;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnStaffAdded;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnStaffAdded;
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
                string searchValue = txtSearch.Text;
                dgvSta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                try
                {
                    foreach (DataGridViewRow row in dgvSta.Rows)
                    {
                        string? id = row.Cells["colStaffID"].Value.ToString();
                        string? staffName = row.Cells["colStaffName"].Value.ToString();

                        if (id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            staffName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.Selected = true;
                            dgvSta.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
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

                object cellValue = row.Cells["colStaffID"].Value;
                int? staffID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (staffID.HasValue)
                {
                    var staff = Helper.GetStaffById(Program.Connection, staffID.Value);
                    if (staff != null)
                    {
                        txtStaID.Text = staff.StaffId.ToString();
                        txtStaFN.Text = staff.StaffFName;
                        txtStaLN.Text = staff.StaffLName;
                        txtStaSex.Text = staff.StaffSex;
                        dtpStaBOD.Value = staff.StaffBOD;
                        txtStaPos.Text = staff.StaffPosition;
                        txtStaHNo.Text = staff.StaffHNo;
                        txtStaSNo.Text = staff.StaffSNo;
                        txtStaCom.Text = staff.StaffCommune;
                        txtStaDis.Text = staff.StaffDistrict;
                        txtStaPro.Text = staff.StaffProvince;
                        txtStaPN.Text = staff.StaffPerNum;
                        txtStaSal.Text = staff.StaffSalary.HasValue ? staff.StaffSalary.Value.ToString("F2") : string.Empty;
                        dtpStaHD.Value = staff.StaffHiredDate;
                        chkStaSW.Checked = staff.StaffStopped;
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
            txtStaID.Clear();
            txtStaFN.Clear();
            txtStaLN.Clear();
            txtStaSex.Clear();
            dtpStaBOD.Value = DateTime.Now;
            txtStaPos.Clear();
            txtStaHNo.Clear();
            txtStaSNo.Clear();
            txtStaCom.Clear();
            txtStaDis.Clear();
            txtStaPro.Clear();
            txtStaPN.Clear();
            txtStaSal.Clear();
            dtpStaHD.Value = DateTime.Now;
            chkStaSW.Checked = false;

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
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dgvSta.Rows.Clear();
                        var result = Helper.GetAllStaff(Program.Connection);
                        foreach (var staff in result)
                        {
                            AddToView(staff);
                        }
                        dgvSta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvSta.ClearSelection();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            int rowIndex = dgvSta.CurrentCell.RowIndex;
            object? tag = dgvSta.Rows[rowIndex].Tag;
            if (tag != null)
            {
                int id = (int)tag;

                try
                {
                    Helper.DeleteStaff(Program.Connection, id);
                    MessageBox.Show($"Successfully Deleted Staff ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No row selected", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnStaffUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvSta.CurrentCell?.RowIndex ?? 0;

            ConfigView();

            if (rowIndex < dgvSta.Rows.Count)
            {
                dgvSta.Rows[rowIndex].Selected = true;
                dgvSta.CurrentCell = dgvSta[0, rowIndex];
            }
        }

        private bool TryParseInputs(string firstName, string lastName, string sex, string position,
            string personalNum, string salary, out string outFirstName, out string outLastName,
            out string outSex, out string outPosition, out string outPersonalNum, out double outSalary)
        {
            outFirstName = firstName;
            outLastName = lastName;
            outSex = sex;
            outPosition = position;
            outPersonalNum = personalNum;
            outSalary = 0;

            // First Name validation
            if (string.IsNullOrEmpty(outFirstName))
            {
                MessageBox.Show("First name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (outFirstName.Length > 50)
            {
                MessageBox.Show("First name must be 50 characters or less.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Last Name validation
            if (string.IsNullOrEmpty(outLastName))
            {
                MessageBox.Show("Last name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (outLastName.Length > 50)
            {
                MessageBox.Show("Last name must be 50 characters or less.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Sex validation
            if (string.IsNullOrEmpty(outSex))
            {
                MessageBox.Show("Sex must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string[] validSexes = { "Male", "Female", "Other" };
            if (!validSexes.Contains(outSex, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Invalid sex. Must be Male, Female, or Other.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Position validation
            if (string.IsNullOrEmpty(outPosition))
            {
                MessageBox.Show("Position must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (outPosition.Length > 50)
            {
                MessageBox.Show("Position must be 50 characters or less.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Personal Number validation
            if (string.IsNullOrEmpty(outPersonalNum))
            {
                MessageBox.Show("Personal number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(outPersonalNum, @"^\d{9,12}$"))
            {
                MessageBox.Show("Personal number must be 9-12 digits.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Salary validation
            if (string.IsNullOrEmpty(salary))
            {
                MessageBox.Show("Salary must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!double.TryParse(salary, out outSalary) || outSalary < 0)
            {
                MessageBox.Show("Salary must be a valid positive number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Age validation
            DateTime minBirthDate = DateTime.Now.AddYears(-65);
            DateTime maxBirthDate = DateTime.Now.AddYears(-18);
            if (dtpStaBOD.Value < minBirthDate || dtpStaBOD.Value > maxBirthDate)
            {
                MessageBox.Show($"Birth date must be between {minBirthDate.ToShortDateString()} and {maxBirthDate.ToShortDateString()}.",
                    "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Hired Date validation
            if (dtpStaHD.Value > DateTime.Now)
            {
                MessageBox.Show("Hired date cannot be in the future.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvSta.SelectedCells.Count > 0)
            {
                int rowIndex = dgvSta.SelectedCells[0].RowIndex;
                object cellValue = dgvSta.Rows[rowIndex].Cells["colStaffID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    if (TryParseInputs(
                        txtStaFN.Text,
                        txtStaLN.Text,
                        txtStaSex.Text,
                        txtStaPos.Text,
                        txtStaPN.Text,
                        txtStaSal.Text,
                        out string firstName,
                        out string lastName,
                        out string sex,
                        out string position,
                        out string personalNum,
                        out double salary))
                    {
                        var staff = new Staff
                        {
                            StaffId = id,
                            StaffFName = firstName,
                            StaffLName = lastName,
                            StaffSex = sex,
                            StaffBOD = dtpStaBOD.Value,
                            StaffPosition = position,
                            StaffHNo = txtStaHNo.Text.Trim(),
                            StaffSNo = txtStaSNo.Text.Trim(),
                            StaffCommune = txtStaCom.Text.Trim(),
                            StaffDistrict = txtStaDis.Text.Trim(),
                            StaffProvince = txtStaPro.Text.Trim(),
                            StaffPerNum = personalNum,
                            StaffSalary = salary,
                            StaffHiredDate = dtpStaHD.Value,
                            StaffStopped = chkStaSW.Checked
                        };

                        try
                        {
                            Helper.UpdateStaff(Program.Connection, staff);
                            MessageBox.Show($"Successfully Updated Staff ID > {id}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void DoOnStaffAdded(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetStaffById(Program.Connection, e.ByteId);
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
            if (TryParseInputs(
                txtStaFN.Text,
                txtStaLN.Text,
                txtStaSex.Text,
                txtStaPos.Text,
                txtStaPN.Text,
                txtStaSal.Text,
                out string firstName,
                out string lastName,
                out string sex,
                out string position,
                out string personalNum,
                out double salary))
            {
                var staff = new Staff
                {
                    StaffFName = firstName,
                    StaffLName = lastName,
                    StaffSex = sex,
                    StaffBOD = dtpStaBOD.Value,
                    StaffPosition = position,
                    StaffHNo = txtStaHNo.Text.Trim(),
                    StaffSNo = txtStaSNo.Text.Trim(),
                    StaffCommune = txtStaCom.Text.Trim(),
                    StaffDistrict = txtStaDis.Text.Trim(),
                    StaffProvince = txtStaPro.Text.Trim(),
                    StaffPerNum = personalNum,
                    StaffSalary = salary,
                    StaffHiredDate = dtpStaHD.Value,
                    StaffStopped = chkStaSW.Checked
                };

                try
                {
                    Helper.AddStaff(Program.Connection, staff);
                    MessageBox.Show("Successfully Inserted Staff", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ConfigView()
        {
            dgvSta.Columns.Clear();
            dgvSta.Columns.Add("colStaffID", "Staff ID");
            dgvSta.Columns.Add("colStaffName", "Staff Name");
            dgvSta.Columns[0].Width = 100;
            dgvSta.Columns[1].Width = 200;
            dgvSta.DefaultCellStyle.BackColor = Color.White;
            dgvSta.ScrollBars = ScrollBars.Both;

            try
            {
                var result = Helper.GetAllStaff(Program.Connection);
                dgvSta.Rows.Clear();
                foreach (var staff in result)
                {
                    AddToView(staff);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Staff staff)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvSta, staff.StaffId, staff.StaffFName + " " + staff.StaffLName);
            row.Tag = staff.StaffId;
            dgvSta.Rows.Add(row);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}