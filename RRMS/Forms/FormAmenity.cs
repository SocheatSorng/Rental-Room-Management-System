using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;
using System.Data;

namespace RRMS.Forms
{
    public partial class FormAmenity : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;
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
                string searchValue = txtSearch.Text.Trim();
                dgvAme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvAme.Rows.Count;
                    
                    for(int i = startIndex; i < dgvAme.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvAme.Rows.Count;
                        DataGridViewRow row = dgvAme.Rows[currentIndex];

                        string? id = row.Cells["colAmeID"].Value?.ToString();
                        string? amenityName = row.Cells["colAmeName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                                    (amenityName != null && amenityName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvAme.ClearSelection();
                            row.Selected = true;
                            dgvAme.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching amenities found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lastHighlightedIndex = -1; // Reset to allow starting over
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

                object cellValue = row.Cells["colAmeID"].Value;
                int? amenityID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (amenityID.HasValue)
                {
                    var amenity = Helper.GetEntityById<Amenity>(Program.Connection, amenityID.Value, "SP_GetAmenityByID");
                    if (amenity != null)
                    {
                        PopulateFields(amenity);
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
            PopulateFields(null);

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
                Invoke((MethodInvoker)delegate
                {
                    UpdateAmenityView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvAme.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvAme.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvAme.Rows[rowIndex].Cells["colAmeID"].Value);

                using var cmd = Program.Connection.CreateCommand();
                cmd.CommandText = "SP_DeleteAmenity";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AmeID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Amenity ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                object cellValue = dgvAme.Rows[rowIndex].Cells["colAmeID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var amenity = GatherAmenityInput();
                    amenity.ID = id;

                    if (TryParseInputs(amenity.FirstName, amenity.Province, amenity.CostPrice, amenity.RentPrice))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(amenity, "SP_UpdateAmenity", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid amenity to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a amenity to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnAmenityAdded(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetAmenityByID";
            if (e.ByteId == 0) return;

            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Amenity>(Program.Connection, e.ByteId, SP_Name);

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
            var amenity = GatherAmenityInput();
            if (TryParseInputs(amenity.FirstName, amenity.Province ,amenity.CostPrice, amenity.RentPrice))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(amenity, "SP_InsertAmenity", "Insert");
            }

            else {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }

        private bool TryParseInputs(string ameName, string ameLoc, double ameBP, double ameCPR)
        {

            if (string.IsNullOrEmpty(ameName))
            {
                MessageBox.Show("Amenity name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(ameLoc))
            {
                MessageBox.Show("Amenity location must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ameBP <= 0)
            {
                MessageBox.Show("Amenity bought price must be a valid number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ameCPR <= 0)
            {
                MessageBox.Show("Amenity cost per rent must be a valid number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateAmenityView()
        {
            try
            {
                dgvAme.Rows.Clear();
                string SP_Name = "SP_GetAllAmenitys";

                var result = Helper.GetAllEntities<Amenity>(Program.Connection, SP_Name);

                foreach (var amenity in result)
                {
                    AddToView(amenity);
                }
                dgvAme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAme.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Amenitys", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Amenity GatherAmenityInput()
        {
            double cp;
            double.TryParse(txtAmeBP.Text.Trim(), out cp);
            double rp;
            double.TryParse(txtAmeCPR.Text.Trim(), out rp);
            return new Amenity()
            {
                
                FirstName = txtAmeName.Text.Trim(),
                Status = chkAmeAvail.Checked,
                Province = txtAmeLoc.Text.Trim(),
                CostPrice = cp,
                RentPrice = rp,
                Start = dtpAmeMD.Value,
                Description = txtAmeDesc.Text.Trim(),
            };
        }

        private void PopulateFields(Amenity? amenity)
        {
            if(amenity != null)
            {
                txtAmeID.Text = amenity.ID.ToString();
                txtAmeName.Text = amenity.FirstName.ToString();
                chkAmeAvail.Checked = amenity.Status;
                txtAmeLoc.Text = amenity.Province;
                txtAmeBP.Text = amenity.CostPrice.ToString("F2");
                txtAmeCPR.Text = amenity.RentPrice.ToString("F2");
                dtpAmeMD.Value = amenity.Start ?? DateTime.Now;
                txtAmeDesc.Text = amenity.Description;
            }
            else
            {
                txtAmeID.Text = string.Empty;
                txtAmeName.Text = string.Empty;
                chkAmeAvail.Checked = false;
                txtAmeLoc.Text = string.Empty;
                txtAmeBP.Text = string.Empty;
                txtAmeCPR.Text = string.Empty;
                dtpAmeMD.Value = DateTime.Now;
                txtAmeDesc.Text = string.Empty;
            }
        }

        private void ConfigView()
        {
            dgvAme.Columns.Clear();
            dgvAme.Columns.Add("colAmeID", "Amenity ID");
            dgvAme.Columns.Add("colAmeName", "Amenity Name");
            dgvAme.Columns[0].Width = 100;
            dgvAme.Columns[1].Width = 200;
            dgvAme.DefaultCellStyle.BackColor = Color.White;
            dgvAme.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllAmenitys";
                var result = Helper.GetAllEntities<Amenity>(Program.Connection, SP_Name);
                dgvAme.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Amenity>(dgvAme, amenity => new object[] { amenity.ID, amenity.FirstName });

                foreach (var amenity in result)
                {
                    entityViewAdder.AddToView(amenity);
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
            row.CreateCells(dgvAme, amenity.ID, amenity.FirstName);
            row.Tag = amenity.ID;
            dgvAme.Rows.Add(row);
        }
    }
}