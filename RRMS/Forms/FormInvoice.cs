//using Microsoft.Data.SqlClient;
//using RRMS.Model;
//using System;
//using System.Data;
//using System.Drawing;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RRMS.Forms
{
    public partial class FormInvoice : Form
    {
        public FormInvoice()
        {
            InitializeComponent();
        }
    }
}

//namespace RRMS.Forms
//{
//    public partial class FormInvoice : Form
//    {
//        BindingSource _bs = new();
//        private int lastHighlightedIndex = -1;

//        public FormInvoice()
//        {
//            InitializeComponent();
//            this.FormBorderStyle = FormBorderStyle.FixedSingle;
//            DataGridView.CheckForIllegalCrossThreadCalls = false;

//            ConfigView();
//            _bs.DataSource = dgvInvoice;
//            LoadPaymentIDs();

//            // Event handlers
//            cbbPaymentID.SelectedIndexChanged += CbbPaymentID_SelectedIndexChanged;

//            btnInsert.Click += (sender, e) =>
//            {
//                Helper.Added += DoOnInvoiceInserted;
//                DoClickInsert(sender, e);
//                Helper.Added -= DoOnInvoiceInserted;
//            };

//            btnUpdate.Click += (sender, e) =>
//            {
//                Helper.Updated += DoOnInvoiceUpdated;
//                DoClickUpdate(sender, e);
//                Helper.Updated -= DoOnInvoiceUpdated;
//            };

//            btnDelete.Click += (sender, e) =>
//            {
//                Helper.Deleted += DoOnInvoiceDeleted;
//                DoClickDelete(sender, e);
//                Helper.Deleted -= DoOnInvoiceDeleted;
//            };

//            btnNew.Click += DoClickNew;
//            dgvInvoice.SelectionChanged += DoClickRecord;
//            txtSearch.KeyDown += DoSearch;
//        }

//        private void LoadPaymentIDs()
//        {
//            using SqlCommand cmd = new("SP_LoadPaymentIDs", Program.Connection);
//            cmd.CommandType = CommandType.StoredProcedure;
//            using SqlDataReader dr = cmd.ExecuteReader();
//            while (dr.Read())
//            {
//                if (dr["PaymentID"] != DBNull.Value)
//                {
//                    string? paymentId = dr["PaymentID"].ToString();
//                    cbbPaymentID.Items.Add(paymentId);
//                }
//            }
//        }

//        private void CbbPaymentID_SelectedIndexChanged(object? sender, EventArgs e)
//        {
//            if (cbbPaymentID.SelectedItem != null)
//            {
//                try
//                {
//                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@ResidentID", cbbPaymentID.SelectedItem);
//                    using (SqlDataReader dr = cmd.ExecuteReader())
//                    {
//                        if (dr.Read())
//                        {
//                            txtPaymentType.Text = dr[""]
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    txtResName.Text = string.Empty;
//                }
//            }
//            else
//            {
//                txtResName.Text = "";
//            }
//        }

//        private void DoSearch(object? sender, KeyEventArgs e)
//        {
//            if (e.KeyCode != Keys.Enter) return;

//            string searchValue = txtSearch.Text.Trim();
//            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

//            if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
//            {
//                lastHighlightedIndex = -1;
//            }

//            try
//            {
//                bool found = false;
//                int startIndex = (lastHighlightedIndex + 1) % dgvInvoice.Rows.Count;

//                for (int i = startIndex; i < dgvInvoice.Rows.Count + startIndex; i++)
//                {
//                    int currentIndex = i % dgvInvoice.Rows.Count;
//                    DataGridViewRow row = dgvInvoice.Rows[currentIndex];

//                    string? id = row.Cells["colInvoiceID"].Value?.ToString();
//                    string? invoiceNo = row.Cells["colInvoiceNo"].Value?.ToString();

//                    if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                        (invoiceNo != null && invoiceNo.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
//                    {
//                        dgvInvoice.ClearSelection();
//                        row.Selected = true;
//                        dgvInvoice.FirstDisplayedScrollingRowIndex = row.Index;
//                        lastHighlightedIndex = currentIndex;
//                        found = true;
//                        break;
//                    }
//                }

//                if (!found)
//                {
//                    MessageBox.Show("No more matching invoices found. Starting over.", "Search Result",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    lastHighlightedIndex = -1;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private void ConfigView()
//        {
//            dgvInvoice.Columns.Clear();
//            dgvInvoice.Columns.Add("colInvoiceID", "Invoice ID");
//            dgvInvoice.Columns.Add("colInvoiceNo", "Invoice No");
//            dgvInvoice.Columns.Add("colDate", "Date");
//            dgvInvoice.Columns.Add("colPaymentType", "Payment Type");
//            dgvInvoice.Columns.Add("colAmount", "Amount");

//            dgvInvoice.Columns["colInvoiceID"].Width = 80;
//            dgvInvoice.Columns["colInvoiceNo"].Width = 150;
//            dgvInvoice.Columns["colDate"].Width = 100;
//            dgvInvoice.Columns["colPaymentType"].Width = 100;
//            dgvInvoice.Columns["colAmount"].Width = 100;

//            dgvInvoice.DefaultCellStyle.BackColor = Color.White;
//            dgvInvoice.ScrollBars = ScrollBars.Both;

//            UpdateInvoiceView();
//        }
//        private void AddToView(Invoice invoice)
//        {
//            DataGridViewRow row = new();
//            row.CreateCells(dgvInvoice,
//                invoice.ID,
//                invoice.InvoiceNo,
//                invoice.InvoiceDate?.ToString("yyyy-MM-dd"),
//                invoice.Type
//            );
//            row.Tag = invoice.ID;
//            dgvInvoice.Rows.Add(row);
//        }

//        private void DoClickRecord(object? sender, EventArgs e)
//        {
//            if (dgvInvoice.SelectedCells.Count > 0)
//            {
//                int rowIndex = dgvInvoice.SelectedCells[0].RowIndex;
//                DataGridViewRow row = dgvInvoice.Rows[rowIndex];

//                object cellValue = row.Cells["colInvoiceID"].Value;
//                int? invoiceID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

//                if (invoiceID.HasValue)
//                {
//                    var invoice = Helper.GetEntityById<Invoice>(Program.Connection, invoiceID.Value, "SP_GetInvoiceByID");
//                    if (invoice != null)
//                    {
//                        PopulateFields(invoice);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Invoice not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Invalid Invoice ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }

//            ManageControl.EnableControl(btnInsert, false);
//            ManageControl.EnableControl(btnUpdate, true);
//            ManageControl.EnableControl(btnDelete, true);
//        }

//        private void DoClickNew(object? sender, EventArgs e)
//        {
//            PopulateFields(null);
//            ManageControl.EnableControl(btnInsert, true);
//            ManageControl.EnableControl(btnUpdate, false);
//            ManageControl.EnableControl(btnDelete, false);
//        }

//        private void DoOnInvoiceDeleted(object? sender, EntityEventArgs e)
//        {
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                Invoke((MethodInvoker)delegate
//                {
//                    ConfigView();
//                });
//            });
//        }

//        private void DoClickDelete(object? sender, EventArgs e)
//        {
//            if (dgvInvoice.SelectedCells.Count <= 0) return;

//            try
//            {
//                int rowIndex = dgvInvoice.SelectedCells[0].RowIndex;
//                int id = Convert.ToInt32(dgvInvoice.Rows[rowIndex].Cells["colInvoiceID"].Value);

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this invoice?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    using var cmd = Program.Connection.CreateCommand();
//                    cmd.CommandText = "SP_DeleteInvoice";
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@InvoiceID", id);

//                    cmd.ExecuteNonQuery();
//                    MessageBox.Show($"Successfully Deleted Invoice ID > {id}", "Deleting",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    ConfigView();
//                    DoClickNew(sender, e);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DoOnInvoiceUpdated(object? sender, EntityEventArgs e)
//        {
//            ConfigView();
//            if (dgvInvoice.CurrentCell != null)
//            {
//                int rowIndex = dgvInvoice.CurrentCell.RowIndex;
//                if (rowIndex < dgvInvoice.Rows.Count)
//                {
//                    dgvInvoice.Rows[rowIndex].Selected = true;
//                    dgvInvoice.CurrentCell = dgvInvoice[0, rowIndex];
//                }
//            }
//        }

//        private void DoClickUpdate(object? sender, EventArgs e)
//        {
//            if (dgvInvoice.SelectedCells.Count > 0)
//            {
//                int rowIndex = dgvInvoice.SelectedCells[0].RowIndex;
//                object cellValue = dgvInvoice.Rows[rowIndex].Cells["colInvoiceID"].Value;

//                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
//                {
//                    var invoice = GatherInvoiceInput();
//                    invoice.ID = id;

//                    if (ValidateInputs())
//                    {
//                        var entityService = new EntityService();
//                        entityService.InsertOrUpdateEntity(invoice, "SP_UpdateInvoice", "Update");
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Please select a valid invoice to update.", "Selection Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//        }

//        private void DoOnInvoiceInserted(object? sender, EntityEventArgs e)
//        {
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                try
//                {
//                    var result = Helper.GetEntityById<Invoice>(Program.Connection, e.ByteId, "SP_GetInvoiceByID");

//                    if (result != null)
//                    {
//                        Invoke((MethodInvoker)delegate
//                        {
//                            AddToView(result);
//                        });
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            });

//            DoClickNew(sender, e);
//        }

//        private void DoClickInsert(object? sender, EventArgs e)
//        {
//            var invoice = GatherInvoiceInput();

//            if (ValidateInputs())
//            {
//                var entityService = new EntityService();
//                entityService.InsertOrUpdateEntity(invoice, "SP_InsertInvoice", "Insert");
//            }
//        }

//        private Invoice? GatherInvoiceInput()
//        {
//            if (!int.TryParse(cbbPaymentID.SelectedItem?.ToString(), out int paymentId))
//            {
//                MessageBox.Show("Please select a valid payment.", "Validation Error");
//                return null;
//            }

//            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
//            {
//                MessageBox.Show("Please enter an invoice number.", "Validation Error");
//                return null;
//            }

//            return new Invoice
//            {
//                InvoiceNo = txtInvoiceNo.Text.Trim(),
//                InvoiceDate = dtInvoiceDate.Value,
//                PaymentID = paymentId
//            };
//        }
//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
//            {
//                MessageBox.Show("Please enter an invoice number.", "Validation Error");
//                return false;
//            }

//            if (cbbPaymentID.SelectedItem == null)
//            {
//                MessageBox.Show("Please select a Payment ID.", "Validation Error");
//                return false;
//            }

//            return true;
//        }

//        private void PopulateFields(Invoice? invoice)
//        {
//            if (invoice != null)
//            {
//                txtInvoiceNo.Text = invoice.InvoiceNo;
//                dtInvoiceDate.Value = invoice.InvoiceDate ?? DateTime.Now;
//                cbbPaymentID.Text = invoice.PaymentID.ToString();
//            }
//            else
//            {
//                txtInvoiceNo.Text = string.Empty;
//                dtInvoiceDate.Value = DateTime.Now;
//                cbbPaymentID.SelectedIndex = -1;
//            }
//        }

//        private void UpdateInvoiceView()
//        {
//            try
//            {
//                dgvInvoice.Rows.Clear();
//                string SP_Name = "SP_GetAllInvoices";
//                var result = Helper.GetAllEntities<Invoice>(Program.Connection, SP_Name);

//                foreach (var invoice in result)
//                {
//                    AddToView(invoice);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Loading Invoices", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        protected override void OnFormClosing(FormClosingEventArgs e)
//        {
//            base.OnFormClosing(e);
//            _bs.Dispose();
//        }
//    }
//}