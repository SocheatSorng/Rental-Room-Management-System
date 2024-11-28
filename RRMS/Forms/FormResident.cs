using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;

namespace RRMS.Forms
{
    public partial class FormResident : Form
    {
        BindingSource _bs = new();
        public FormResident()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvRes;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnResidentAdded;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnResidentAdded;
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
            btnClose.Click += (sender, e) => { this.Close(); };
            dgvRes.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text;
                dgvRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                try
                {
                    foreach (DataGridViewRow row in dgvRes.Rows)
                    {
                        string? id = row.Cells["colResidentID"].Value.ToString();
                        string? residentName = row.Cells["colResidentName"].Value.ToString();

                        if (id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            residentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.Selected = true;
                            dgvRes.FirstDisplayedScrollingRowIndex = row.Index;
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
            if (dgvRes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRes.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvRes.Rows[rowIndex];

                // Retrieve the value from the cell and convert it to int?
                object cellValue = row.Cells["colResidentID"].Value;
                int? residentID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (residentID.HasValue) // Check if residentID is not null
                {
                    // Use the generic GetEntityById method to retrieve the Resident
                    var resident = Helper.GetEntityById<Resident>(Program.Connection, residentID.Value, "SP_GetResidentById");
                    if (resident != null)
                    {
                        // Populate the form fields with the resident's data
                        txtResID.Text = resident.ResID.ToString();
                        txtResType.Text = resident.ResType;
                        txtResName.Text = resident.ResFirstName;
                        txtResSex.Text = resident.ResSex; // Corrected from Sex to ResSex
                        dtpResBOD.Value = resident.ResBD;
                        txtResHNo.Text = resident.ResPrevHouseNo;
                        txtResStNo.Text = resident.ResPrevStNo;
                        txtResCom.Text = resident.ResPrevCommune;
                        txtResDis.Text = resident.ResPrevDistrict;
                        txtResPN.Text = resident.ResPerNum;
                        txtResCN.Text = resident.ResConNum;
                        dtpResCID.Value = resident.ResCheckIn;
                        dtpResCOD.Value = resident.ResCheckOut;
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
            txtResID.Text = string.Empty; // Keep this line to clear the ID field
            txtResType.Text = string.Empty;
            txtResName.Text = string.Empty;
            txtResSex.Text = string.Empty;
            dtpResBOD.Value = DateTime.Now;
            txtResHNo.Text = string.Empty;
            txtResStNo.Text = string.Empty;
            txtResCom.Text = string.Empty;
            txtResDis.Text = string.Empty;
            txtResPN.Text = string.Empty;
            txtResCN.Text = string.Empty;
            dtpResCID.Value = DateTime.Now;
            dtpResCOD.Value = DateTime.Now;

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
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dgvRes.Rows.Clear();
                        var result = Helper.GetAllResidents(Program.Connection);
                        foreach (var resident in result)
                        {
                            AddToView(resident);
                        }
                        dgvRes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvRes.ClearSelection();
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
            int rowIndex = dgvRes.CurrentCell.RowIndex;
            object? tag = dgvRes.Rows[rowIndex].Tag;
            if (tag != null)
            {
                int id = (int)tag;

                try
                {
                    Helper.DeleteResident(Program.Connection, id);
                    MessageBox.Show($"Successfully Deleted Resident ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DoOnResidentUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvRes.CurrentCell?.RowIndex ?? 0;

            ConfigView();

            if (rowIndex < dgvRes.Rows.Count)
            {
                dgvRes.Rows[rowIndex].Selected = true;
                dgvRes.CurrentCell = dgvRes[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRes.SelectedCells[0].RowIndex;
                object cellValue = dgvRes.Rows[rowIndex].Cells["colResID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var residentType = txtResType.Text.Trim();
                    var residentName = txtResName.Text.Trim();
                    var sex = txtResSex.Text.Trim();
                    var resBOD = dtpResBOD.Value;
                    var prevHouseNo = txtResHNo.Text.Trim();
                    var prevStNo = txtResStNo.Text.Trim();
                    var prevCommune = txtResCom.Text.Trim();
                    var prevDistrict = txtResDis.Text.Trim();
                    var resPerNum = txtResPN.Text.Trim();
                    var resConNum = txtResCN.Text.Trim();
                    var checkIn = dtpResCID.Value;
                    var checkOut = dtpResCOD.Value;

                    Resident updatedResident = new Resident()
                    {
                        ResID = id, // Use the ID from the selected resident
                        ResType = residentType,
                        ResFirstName = residentName,
                        ResSex = sex,
                        ResBD = resBOD,
                        ResPrevHouseNo = prevHouseNo,
                        ResPrevStNo = prevStNo,
                        ResPrevCommune = prevCommune,
                        ResPrevDistrict = prevDistrict,
                        ResPerNum = resPerNum,
                        ResConNum = resConNum,
                        ResCheckIn = checkIn,
                        ResCheckOut = checkOut
                    };

                    try
                    {
                        Helper.UpdateResident(Program.Connection, updatedResident);
                        MessageBox.Show($"Successfully Updated Resident ID > {id}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void DoOnResidentAdded(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetResidentById";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    //var result = Helper.GetEntityById<Resident>(Program.Connection, e.ByteId);
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
            var residentType = txtResType.Text.Trim();
            var residentName = txtResName.Text.Trim();
            var sex = txtResSex.Text.Trim();
            var resBOD = dtpResBOD.Value;
            var prevHouseNo = txtResHNo.Text.Trim();
            var prevStNo = txtResStNo.Text.Trim();
            var prevCommune = txtResCom.Text.Trim();
            var prevDistrict = txtResDis.Text.Trim();
            var resPerNum = txtResPN.Text.Trim();
            var resConNum = txtResCN.Text.Trim();
            var checkIn = dtpResCID.Value;
            var checkOut = dtpResCOD.Value;

            // Removed residentID input
            if (TryParseInputs(residentType, residentName, sex, resPerNum, resConNum, out string resType, out string resName, out string resSex, out string resPN, out string resCN))
            {
                Resident newResident = new Resident()
                {
                    ResType = residentType,
                    ResFirstName = residentName,
                    ResSex= sex,
                    ResBD = resBOD,
                    ResPrevHouseNo = prevHouseNo,
                    ResPrevStNo = prevStNo,
                    ResPrevCommune = prevCommune,
                    ResPrevDistrict = prevDistrict,
                    ResPerNum = resPerNum,
                    ResConNum = resConNum,
                    ResCheckIn = checkIn,
                    ResCheckOut = checkOut
                };

                try
                {
                    Helper.AddResident(Program.Connection, newResident);
                    MessageBox.Show($"Successfully Inserted Resident", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool TryParseInputs(string restype, string resname, string ressex, string respn, string rescn, out string resType, out string resName, out string resSex, out string resPN, out string resCN)
        {
            resType = restype;
            resName = resname;
            resSex = ressex;
            resPN = respn;
            resCN = rescn;

            if (string.IsNullOrEmpty(resType))
            {
                MessageBox.Show("Resident type must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(resName))
            {
                MessageBox.Show("Resident name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(resSex))
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
        private void ConfigView()
        {
            dgvRes.Columns.Clear();
            dgvRes.Columns.Add("colResidentID", "Resident ID");
            dgvRes.Columns.Add("colResidentName", "Resident Name");
            dgvRes.Columns[0].Width = 100;
            dgvRes.Columns[1].Width = 200;
            dgvRes.DefaultCellStyle.BackColor = Color.White;
            dgvRes.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllResidents";
                var result = Helper.GetAllEntities<Resident>(Program.Connection, SP_Name);
                dgvRes.Rows.Clear();
                foreach (var resident in result)
                {
                    AddToView(resident);
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
            row.CreateCells(dgvRes, resident.ResID, resident.ResFirstName);
            row.Tag = resident.ResID;
            dgvRes.Rows.Add(row);
        }
    }
}