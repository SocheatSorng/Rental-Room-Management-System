using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;

namespace RRMS.Forms
{
    public partial class FormAmenity : Form
    {
        BindingSource _bs = new();
        public FormAmenity()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvAme;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnAmenityAdded;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnAmenityAdded;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnAmenityUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnAmenityUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnAmenityDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnAmenityDeleted;
            };

            btnNew.Click += DoClickNew;
            //btnClose.Click += (sender, e) => { this.Close(); };
            dgvAme.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text;
                dgvAme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                try
                {
                    foreach (DataGridViewRow row in dgvAme.Rows)
                    {
                        string? id = row.Cells["colAmenityID"].Value.ToString();
                        string? amenityName = row.Cells["colAmenityName"].Value.ToString();

                        if (id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            amenityName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.Selected = true;
                            dgvAme.FirstDisplayedScrollingRowIndex = row.Index;
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
            if (dgvAme.SelectedCells.Count > 0)
            {
                int rowIndex = dgvAme.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvAme.Rows[rowIndex];

                object cellValue = row.Cells["colAmenityID"].Value;
                int? amenityID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (amenityID.HasValue)
                {
                    var amenity = Helper.GetAmenityById(Program.Connection, amenityID.Value);
                    if (amenity != null)
                    {
                        txtAmeID.Text = amenity.AmenityId.ToString();
                        txtAmeName.Text = amenity.AmenityName;
                        txtAmeAvail.Text = amenity.AmenityAvail.ToString();
                        txtAmeLoc.Text = amenity.AmenityLocation;
                        txtAmeBP.Text = amenity.AmenityBouPri.ToString();
                        txtAmeCPR.Text = amenity.AmenityCPR.ToString();
                        dtpAmeMD.Value = amenity.AmenityMainDate;
                        txtAmeDesc.Text = amenity.AmenityDesc;
                    }
                    else
                    {
                        MessageBox.Show("Amenity not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Amenity ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtAmeID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            txtAmeID.Clear();
            txtAmeName.Clear();
            txtAmeAvail.Clear();
            txtAmeLoc.Clear();
            txtAmeBP.Clear();
            txtAmeCPR.Clear();
            dtpAmeMD.Value = DateTime.Now;
            txtAmeDesc.Clear();

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtAmeID, false);
        }

        private void DoOnAmenityDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dgvAme.Rows.Clear();
                        var result = Helper.GetAllAmenities(Program.Connection);
                        foreach (var amenity in result)
                        {
                            AddToView(amenity);
                        }
                        dgvAme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvAme.ClearSelection();
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
            int rowIndex = dgvAme.CurrentCell.RowIndex;
            object? tag = dgvAme.Rows[rowIndex].Tag;
            if (tag != null)
            {
                int id = (int)tag;

                try
                {
                    Helper.DeleteAmenity(Program.Connection, id);
                    MessageBox.Show($"Successfully Deleted Amenity ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DoOnAmenityUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvAme.CurrentCell?.RowIndex ?? 0;

            ConfigView();

            if (rowIndex < dgvAme.Rows.Count)
            {
                dgvAme.Rows[rowIndex].Selected = true;
                dgvAme.CurrentCell = dgvAme[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvAme.SelectedCells.Count > 0)
            {
                int rowIndex = dgvAme.SelectedCells[0].RowIndex;
                object cellValue = dgvAme.Rows[rowIndex].Cells["colAmenityID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    if (TryParseInputs(txtAmeName.Text, txtAmeAvail.Text, txtAmeLoc.Text, txtAmeBP.Text, txtAmeCPR.Text, out string ameName, out string ameAvail, out string ameLoc, out string ameBP, out string ameCPR))
                    {
                        Amenity updatedAmenity = new Amenity()
                        {
                            AmenityId = id,
                            AmenityName = ameName,
                            AmenityAvail = bool.Parse(ameAvail),
                            AmenityLocation = ameLoc,
                            AmenityBouPri = double.Parse(ameBP),
                            AmenityCPR = double.Parse(ameCPR),
                            AmenityMainDate = dtpAmeMD.Value,
                            AmenityDesc = txtAmeDesc.Text.Trim()
                        };

                        try
                        {
                            Helper.UpdateAmenity(Program.Connection, updatedAmenity);
                            MessageBox.Show($"Successfully Updated Amenity ID > {id}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void DoOnAmenityAdded(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetAmenityById(Program.Connection, e.ByteId);

                    if (result != null)
                    {
                        dgvAme.Invoke((MethodInvoker)delegate
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
            if (TryParseInputs(txtAmeName.Text, txtAmeAvail.Text, txtAmeLoc.Text, txtAmeBP.Text, txtAmeCPR.Text, out string ameName, out string ameAvail, out string ameLoc, out string ameBP, out string ameCPR))
            {
                Amenity newAmenity = new Amenity()
                {
                    AmenityName = ameName,
                    AmenityAvail = bool.Parse(ameAvail),
                    AmenityLocation = ameLoc,
                    AmenityBouPri = double.Parse(ameBP),
                    AmenityCPR = double.Parse(ameCPR),
                    AmenityMainDate = dtpAmeMD.Value,
                    AmenityDesc = txtAmeDesc.Text.Trim()
                };

                try
                {
                    Helper.AddAmenity(Program.Connection, newAmenity);
                    MessageBox.Show("Successfully Inserted Amenity", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool TryParseInputs(string ameName, string ameAvail, string ameLoc, string ameBP, string ameCPR, out string outName, out string outAvail, out string outLoc, out string outBP, out string outCPR)
        {
            outName = ameName;
            outAvail = ameAvail;
            outLoc = ameLoc;
            outBP = ameBP;
            outCPR = ameCPR;

            if (string.IsNullOrEmpty(outName))
            {
                MessageBox.Show("Amenity name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(outAvail) || !bool.TryParse(outAvail, out _))
            {
                MessageBox.Show("Amenity availability must be a valid boolean value.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(outLoc))
            {
                MessageBox.Show("Amenity location must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(outBP) || !double.TryParse(outBP, out _))
            {
                MessageBox.Show("Amenity bought price must be a valid number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(outCPR) || !double.TryParse(outCPR, out _))
            {
                MessageBox.Show("Amenity cost per rent must be a valid number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ConfigView()
        {
            dgvAme.Columns.Clear();
            dgvAme.Columns.Add("colAmen ityID", "Amenity ID");
            dgvAme.Columns.Add("colAmenityName", "Amenity Name");
            dgvAme.Columns[0].Width = 100;
            dgvAme.Columns[1].Width = 200;
            dgvAme.DefaultCellStyle.BackColor = Color.White;
            dgvAme.ScrollBars = ScrollBars.Both;

            try
            {
                var result = Helper.GetAllAmenities(Program.Connection);
                dgvAme.Rows.Clear();
                foreach (var amenity in result)
                {
                    AddToView(amenity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving amenities", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Amenity amenity)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvAme, amenity.AmenityId, amenity.AmenityName);
            row.Tag = amenity.AmenityId;
            dgvAme.Rows.Add(row);
        }

        private void FormAmenity_Load(object sender, EventArgs e)
        {

        }
    }
}