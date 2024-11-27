using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;

namespace RRMS.Forms
{
    public partial class FormVendor : Form
    {
        BindingSource _bs = new();
        public FormVendor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvVen;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnVendorAdded;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnVendorAdded;
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
            btnClose.Click += (sender, e) => { this.Close(); };
            dgvVen.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text;
                dgvVen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                try
                {
                    foreach (DataGridViewRow row in dgvVen.Rows)
                    {
                        string? id = row.Cells["colVendorID"].Value.ToString();
                        string? vendorName = row.Cells["colVendorName"].Value.ToString();

                        if (id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                            vendorName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            row.Selected = true;
                            dgvVen.FirstDisplayedScrollingRowIndex = row.Index;
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
            if (dgvVen.SelectedCells.Count > 0)
            {
                int rowIndex = dgvVen.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvVen.Rows[rowIndex];

                object cellValue = row.Cells["colVendorID"].Value;
                int? vendorID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (vendorID.HasValue)
                {
                    var vendor = Helper.GetVendorById(Program.Connection, vendorID.Value);
                    if (vendor != null)
                    {
                        txtVenID.Text = vendor.VendorID.ToString();
                        txtVenName.Text = vendor.VendorName;
                        txtVenCN.Text = vendor.VendorContact;
                        txtVenHNo.Text = vendor.VendorHNo;
                        txtVenSNo.Text = vendor.VendorSNo;
                        txtVenCom.Text = vendor.VendorCommune;
                        txtVenDis.Text = vendor.VendorDistrict;
                        txtVenPro.Text = vendor.VendorProvince;
                        dtpVenCS.Value = vendor.VendorConStart;
                        dtpVenCE.Value = vendor.VendorConEnd;
                        chkVenStat.Checked = vendor.VendorStatus;
                        txtVenDesc.Text = vendor.VendorDesc;
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

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtVenID, false);
        }

        private void DoOnVendorDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        dgvVen.Rows.Clear();
                        var result = Helper.GetAllVendors(Program.Connection);
                        foreach (var vendor in result)
                        {
                            AddToView(vendor);
                        }
                        dgvVen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvVen.ClearSelection();
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
            int rowIndex = dgvVen.CurrentCell.RowIndex;
            object? tag = dgvVen.Rows[rowIndex].Tag;
            if (tag != null)
            {
                int id = (int)tag;

                try
                {
                    Helper.DeleteVendor(Program.Connection, id);
                    MessageBox.Show($"Successfully Deleted Vendor ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DoOnVendorUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvVen.CurrentCell?.RowIndex ?? 0;

            ConfigView();

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
                object cellValue = dgvVen.Rows[rowIndex].Cells["colVendorID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var vendorName = txtVenName.Text.Trim();
                    var vendorContact = txtVenCN.Text.Trim();
                    var vendorHNo = txtVenHNo.Text.Trim();
                    var vendorSNo = txtVenSNo.Text.Trim();
                    var vendorCommune = txtVenCom.Text.Trim();
                    var vendorDistrict = txtVenDis.Text.Trim();
                    var vendorProvince = txtVenPro.Text.Trim();
                    var vendorConStart = dtpVenCS.Value;
                    var vendorConEnd = dtpVenCE.Value;
                    var vendorStatus = chkVenStat.Checked;
                    var vendorDesc = txtVenDesc.Text.Trim();

                    Vendor updatedVendor = new Vendor()
                    {
                        VendorID = id,
                        VendorName = vendorName,
                        VendorContact = vendorContact,
                        VendorHNo = vendorHNo,
                        VendorSNo = vendorSNo,
                        VendorCommune = vendorCommune,
                        VendorDistrict = vendorDistrict,
                        VendorProvince = vendorProvince,
                        VendorConStart = vendorConStart,
                        VendorConEnd = vendorConEnd,
                        VendorStatus = vendorStatus,
                        VendorDesc = vendorDesc
                    };

                    try
                    {
                        Helper.UpdateVendor(Program.Connection, updatedVendor);
                        MessageBox.Show($"Successfully Updated Vendor ID > {id}", "Updating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DoOnVendorAdded(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        // Refresh the entire view instead of adding a single row
                        ConfigView();
                    });
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
            var vendorName = txtVenName.Text.Trim();
            var vendorContact = txtVenCN.Text.Trim();
            var vendorHNo = txtVenHNo.Text.Trim();
            var vendorSNo = txtVenSNo.Text.Trim();
            var vendorCommune = txtVenCom.Text.Trim();
            var vendorDistrict = txtVenDis.Text.Trim();
            var vendorProvince = txtVenPro.Text.Trim();
            var vendorConStart = dtpVenCS.Value;
            var vendorConEnd = dtpVenCE.Value;
            var vendorStatus = chkVenStat.Checked;
            var vendorDesc = txtVenDesc.Text.Trim();

            if (TryParseInputs(vendorName, vendorContact, vendorHNo, vendorSNo, vendorCommune, vendorDistrict, vendorProvince, vendorDesc, out string venName, out string venCN, out string venHNo, out string venSNo, out string venCom, out string venDis, out string venPro, out string venDesc))
            {
                Vendor newVendor = new Vendor()
                {
                    VendorName = vendorName,
                    VendorContact = vendorContact,
                    VendorHNo = vendorHNo,
                    VendorSNo = vendorSNo,
                    VendorCommune = vendorCommune,
                    VendorDistrict = vendorDistrict,
                    VendorProvince = vendorProvince,
                    VendorConStart = vendorConStart,
                    VendorConEnd = vendorConEnd,
                    VendorStatus = vendorStatus,
                    VendorDesc = vendorDesc
                };

                try
                {
                    Helper.AddVendor(Program.Connection, newVendor);
                    MessageBox.Show($"Successfully Inserted Vendor", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool TryParseInputs(string venName, string venCN, string venHNo, string venSNo, string venCom, string venDis, string venPro, string venDesc, out string vendorName, out string vendorContact, out string vendorHNo, out string vendorSNo, out string vendorCommune, out string vendorDistrict, out string vendorProvince, out string vendorDesc)
        {
            vendorName = venName;
            vendorContact = venCN;
            vendorHNo = venHNo;
            vendorSNo = venSNo;
            vendorCommune = venCom;
            vendorDistrict = venDis;
            vendorProvince = venPro;
            vendorDesc = venDesc;

            if (string.IsNullOrEmpty(vendorName))
            {
                MessageBox.Show("Vendor name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorContact))
            {
                MessageBox.Show("Vendor contact must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorHNo))
            {
                MessageBox.Show("Vendor house number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorSNo))
            {
                MessageBox.Show("Vendor street number must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorCommune))
            {
                MessageBox.Show("Vendor commune must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorDistrict))
            {
                MessageBox.Show("Vendor district must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorProvince))
            {
                MessageBox.Show("Vendor province must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(vendorDesc))
            {
                MessageBox.Show("Vendor description must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ConfigView()
        {
            dgvVen.Columns.Clear();
            dgvVen.Columns.Add("colVendorID", "Vendor ID");
            dgvVen.Columns.Add("colVendorName", "Vendor Name");
            dgvVen.Columns[0].Width = 100;
            dgvVen.Columns[1].Width = 200;
            dgvVen.DefaultCellStyle.BackColor = Color.White;
            dgvVen.ScrollBars = ScrollBars.Both;

            try
            {
                var result = Helper.GetAllVendors(Program.Connection);
                dgvVen.Rows.Clear();
                foreach (var vendor in result)
                {
                    AddToView(vendor);
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
            row.CreateCells(dgvVen, vendor.VendorID, vendor.VendorName);
            row.Tag = vendor.VendorID;
            dgvVen.Rows.Add(row);
        }
    }
}