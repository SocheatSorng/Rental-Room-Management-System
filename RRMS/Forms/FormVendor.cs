using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;
using Microsoft.Data.SqlClient;
using System.Numerics;
using System.Data;

namespace RRMS.Forms
{
    public partial class FormVendor : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormVendor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvVen;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnVendorInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnVendorInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnVendorUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnVendorUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnVendorDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnVendorDeleted;
            };

            btnNew.Click += DoClickNew;
            //btnClose.Click += (sender, e) => { this.Close(); };
            dgvVen.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch; // Attach the search event
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvVen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Reset last highlighted index if the search term has changed
                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvVen.Rows.Count; // Start from the next row

                    for (int i = startIndex; i < dgvVen.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvVen.Rows.Count; // Wrap around if necessary
                        DataGridViewRow row = dgvVen.Rows[currentIndex];

                        string? id = row.Cells["colVenID"].Value?.ToString();
                        string? vendorName = row.Cells["colVendorName"].Value?.ToString();

                        // Check if the current row matches the search value
                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (vendorName != null && vendorName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvVen.ClearSelection(); // Clear previous selections
                            row.Selected = true; // Highlight the found row
                            dgvVen.FirstDisplayedScrollingRowIndex = row.Index; // Scroll to the found row
                            lastHighlightedIndex = currentIndex; // Update the last highlighted index
                            found = true; // Set the flag to true
                            break; // Exit the loop after finding the next match
                        }
                    }

                    // Optional: If no match is found, you can show a message
                    if (!found)
                    {
                        MessageBox.Show("No more matching vendors found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvVen.SelectedCells.Count > 0)
            {
                int rowIndex = dgvVen.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvVen.Rows[rowIndex];

                object cellValue = row.Cells["colVenID"].Value;
                int? vendorID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (vendorID.HasValue)
                {
                    var vendor = Helper.GetEntityById<Vendor>(Program.Connection, vendorID.Value, "SP_GetVendorById");
                    if (vendor != null)
                    {
                        PopulateFields(vendor);
                    }
                    else
                    {
                        MessageBox.Show("Vendor not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Vendor ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtVenID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtVenID, false);
        }

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var vendor = GatherVendorInput();

            if (TryParseInputs(vendor.VenName, vendor.VenContact, vendor.VenHNo, vendor.VenSNo, vendor.VenCommune, vendor.VenDistrict, vendor.VenProvince, vendor.VenDesc))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(vendor, "SP_InsertVendor", "Insert");
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnVendorDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;

            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateVendorView(); // Refresh the vendor view after deletion
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvVen.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvVen.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvVen.Rows[rowIndex].Cells["colVenID"].Value);

                using var cmd = Program.Connection.CreateCommand(); 
                cmd.CommandText = "SP_DeleteVendor"; 
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@VenID", id); 

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Vendor ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnVendorUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvVen.CurrentCell?.RowIndex ?? 0;

            ConfigView(); // Refresh the vendor view after update

            if (rowIndex < dgvVen.Rows.Count)
            {
                dgvVen.Rows[rowIndex].Selected = true;
                dgvVen.CurrentCell = dgvVen[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvVen.SelectedCells.Count > 0)
            {
                int rowIndex = dgvVen.SelectedCells[0].RowIndex;
                object cellValue = dgvVen.Rows[rowIndex].Cells["colVenID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var vendor = GatherVendorInput();
                    vendor.VenID = id;

                    if (TryParseInputs(vendor.VenName, vendor.VenContact, vendor.VenHNo, vendor.VenSNo, vendor.VenCommune, vendor.VenDistrict, vendor.VenProvince, vendor.VenDesc))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(vendor, "SP_UpdateVendor", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid vendor to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a vendor to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnVendorInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetVendorById"; 
            if (e.ByteId == 0) return;

            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Vendor>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvVen.Invoke((MethodInvoker)delegate
                        {
                            AddToView(result);
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error); // Handle exceptions
                }
            });

            DoClickNew(sender, e); // Call the method to handle new entry
        }

        private Vendor GatherVendorInput()
        {
            return new Vendor()
            {
                VenName = txtVenName.Text.Trim(),
                VenContact = txtVenCN.Text.Trim(),
                VenHNo = txtVenHNo.Text.Trim(),
                VenSNo = txtVenSNo.Text.Trim(),
                VenCommune = txtVenCom.Text.Trim(),
                VenDistrict = txtVenDis.Text.Trim(),
                VenProvince = txtVenPro.Text.Trim(),
                VenConStart = dtpVenCS.Value,
                VenConEnd = dtpVenCE.Value,
                VenStatus = chkVenStat.Checked,
                VenDesc = txtVenDesc.Text.Trim()
            };
        }

        private void PopulateFields(Vendor? vendor)
        {
            if (vendor != null)
            {
                txtVenID.Text = vendor.VenID.ToString();
                txtVenName.Text = vendor.VenName;
                txtVenCN.Text = vendor.VenContact;
                txtVenHNo.Text = vendor.VenHNo;
                txtVenSNo.Text = vendor.VenSNo;
                txtVenCom.Text = vendor.VenCommune;
                txtVenDis.Text = vendor.VenDistrict;
                txtVenPro.Text = vendor.VenProvince;
                dtpVenCS.Value = vendor.VenConStart;
                dtpVenCE.Value = vendor.VenConEnd;
                chkVenStat.Checked = vendor.VenStatus;
                txtVenDesc.Text = vendor.VenDesc;
            }
            else
            {
                // Clear the fields for a new vendor
                txtVenID.Text = string.Empty;
                txtVenName.Text = string.Empty;
                txtVenCN.Text = string.Empty;
                txtVenHNo.Text = string.Empty;
                txtVenSNo.Text = string.Empty;
                txtVenCom.Text = string.Empty;
                txtVenDis.Text = string.Empty;
                txtVenPro.Text = string.Empty;
                dtpVenCS.Value = DateTime.Now;
                dtpVenCE.Value = DateTime.Now;
                chkVenStat.Checked = false;
                txtVenDesc.Text = string.Empty;
            }
        }

        private bool TryParseInputs(string venName, string venCN, string venHNo, string venSNo, string venCom, string venDis, string venPro, string venDesc)
        {
            if (string.IsNullOrEmpty(venName))
            {
                MessageBox.Show("Vendor name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venCN))
            {
                MessageBox.Show("Vendor contact must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venHNo))
            {
                MessageBox.Show("Vendor house number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venSNo))
            {
                MessageBox.Show("Vendor street number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venCom))
            {
                MessageBox.Show("Vendor commune must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venDis))
            {
                MessageBox.Show("Vendor district must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venPro))
            {
                MessageBox.Show("Vendor province must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(venDesc))
            {
                MessageBox.Show("Vendor description must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateVendorView()
        {
            try
            {
                dgvVen.Rows.Clear();
                string SP_Name = "SP_GetAllVendors";

                var result = Helper.GetAllEntities<Vendor>(Program.Connection, SP_Name);

                foreach (var vendor in result)
                {
                    AddToView(vendor);
                }
                dgvVen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVen.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Vendors", MessageBoxButtons.OK, MessageBoxIcon.Error); // Handle exceptions
            }
        }

        private void ConfigView()
        {
            dgvVen.Columns.Clear();
            dgvVen.Columns.Add("colVenID", "Vendor ID");
            dgvVen.Columns.Add("colVenName", "Vendor Name");
            dgvVen.Columns[0].Width = 100;
            dgvVen.Columns[1].Width = 200;
            dgvVen.DefaultCellStyle.BackColor = Color.White;
            dgvVen.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllVendors"; 
                var result = Helper.GetAllEntities<Vendor>(Program.Connection, SP_Name); 
                dgvVen.Rows.Clear();

                
                var entityViewAdder = new EntityViewAdder<Vendor>(dgvVen,
                    vendor => new object[] { vendor.VenID, vendor.VenName }
                );
              
                foreach (var vendor in result)
                {
                    entityViewAdder.AddToView(vendor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving vendors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Vendor vendor)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvVen, vendor.VenID, vendor.VenName);
            row.Tag = vendor.VenID;
            dgvVen.Rows.Add(row);
        }
    }
}