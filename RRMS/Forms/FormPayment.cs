using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRMS.Forms
{
    public partial class FormPayment : Form
    {
        private int lastHighlightedIndex = -1;
        BindingSource _bs = new();

        public FormPayment()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;

            ConfigureView();
            _bs.DataSource = dgvPayment;

            LoadStaffIDs();
            LoadUtilityIDs();
            LoadReservationIDs();
            LoadServiceIDs();

            cbbStaffID.SelectedIndexChanged += CbbStaffID_SelectedIndexChanged;
            cbbUtilityID.SelectedIndexChanged += CbbUtilityID_SelectedIndexChanged;
            cbUtilityID.CheckedChanged += CbUtilityID_CheckedChanged;
            cbbServiceID.SelectedIndexChanged += CbbServiceID_SelectedIndexChanged;
            cbServiceID.CheckedChanged += CbServiceID_CheckedChanged;
            cbbReservationID.SelectedIndexChanged += CbbReservationID_SelectedIndexChanged;
            txtPaidAmount.TextChanged += TxtPaidAmount_TextChanged;
            cbReservationID.CheckedChanged += CbReservationID_CheckedChanged;
            txtPaidAmount.TextChanged += TxtPaidAmount_TextChanged;
            dgvPayment.CellClick += new DataGridViewCellEventHandler(DoClickRecord);

            cbbUtilityID.Enabled = false;
            cbbServiceID.Enabled = false;
            cbbReservationID.Enabled = false;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnPaymentInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnPaymentInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnPaymentUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnPaymentUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnPaymentDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnPaymentDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvPayment.SelectionChanged += DoClickRecord;
            txtSearchPayment.KeyDown += DoSearch;
        }

        private void LoadStaffIDs()
        {
            SqlCommand cmd = new("SP_LoadStaffIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr["StaffID"] != DBNull.Value)
                    {
                        string? staffID = dr["StaffID"].ToString();
                        cbbStaffID.Items.Add(staffID);
                    }
                }
            }
        }

        private void LoadUtilityIDs()
        {
            SqlCommand cmd = new("SP_LoadUtilityIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr["UtilityID"] != DBNull.Value)
                    {
                        string? utilityID = dr["UtilityID"].ToString();
                        cbbUtilityID.Items.Add(utilityID);
                    }
                }
            }
        }

        private void LoadReservationIDs()
        {
            SqlCommand cmd = new("SP_LoadReservationIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr["ReservationID"] != DBNull.Value)
                    {
                        string? resID = dr["ReservationID"].ToString();
                        cbbReservationID.Items.Add(resID);
                    }
                }
            }
        }
        private void LoadServiceIDs()
        {
            SqlCommand cmd = new("SP_LoadServiceIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr["ServiceID"] != DBNull.Value)
                    {
                        string? serID = dr["ServiceID"].ToString();
                        cbbServiceID.Items.Add(serID);
                    }
                }
            }
        }

        private void CbbStaffID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbStaffID.SelectedItem != null)
            {
                SqlCommand cmd = new("SP_GetStaffByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffID", cbbStaffID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtStaffName.Text = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                    }
                }
            }
        }

        private void CbbUtilityID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbUtilityID.SelectedItem != null)
            {
                SqlCommand cmd = new("SP_GetUtilityByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UtilityID", cbbUtilityID.SelectedItem);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtUtilityName.Text = dr["UtilityType"].ToString();
                        txtRemainAmount.Text = dr["Cost"].ToString();
                        txtRemainAmount.ReadOnly = true;
                        txtPaidAmount.ReadOnly = false;
                        txtPaidAmount.Clear();
                    }
                }
            }
        }
        private void CbbServiceID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbServiceID.SelectedItem != null)
            {
                SqlCommand cmd = new("SP_GetServiceByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", cbbServiceID.SelectedItem);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtServiceType.Text = dr["ServiceName"].ToString();
                        txtRemainAmount.Text = dr["ServiceCost"].ToString();
                        txtRemainAmount.ReadOnly = true;
                        txtPaidAmount.ReadOnly = false;
                        txtPaidAmount.Clear();
                    }
                }
            }
        }


        private void CbUtilityID_CheckedChanged(object? sender, EventArgs e)
        {
            bool isUtilityPayment = cbUtilityID.Checked;
            cbbUtilityID.Enabled = isUtilityPayment;
            txtUtilityName.Enabled = isUtilityPayment;

            cbServiceID.Enabled = !isUtilityPayment;
            cbReservationID.Enabled = !isUtilityPayment;

            if (!isUtilityPayment)
            {
                cbbUtilityID.SelectedIndex = -1;
                txtUtilityName.Clear();
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
            }
        }
        private void CbServiceID_CheckedChanged(object? sender, EventArgs e)
        {
            bool isServicePayment = cbServiceID.Checked;
            cbbServiceID.Enabled = isServicePayment;
            txtServiceType.Enabled = isServicePayment;

            cbUtilityID.Enabled = !isServicePayment;
            cbReservationID.Enabled = !isServicePayment;

            if (!isServicePayment)
            {
                cbbServiceID.SelectedIndex = -1;
                txtServiceType.Clear();
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearchPayment.Text.Trim();
                dgvPayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearchPayment.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvPayment.Rows.Count;

                    for (int i = startIndex; i < dgvPayment.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvPayment.Rows.Count;
                        DataGridViewRow row = dgvPayment.Rows[currentIndex];

                        string? id = row.Cells["colPaymentID"].Value?.ToString();
                        string? amount = row.Cells["colAmount"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (amount != null && amount.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvPayment.ClearSelection();
                            row.Selected = true;
                            dgvPayment.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching payments found. Starting over.", "Search Result",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvPayment.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPayment.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvPayment.Rows[rowIndex];

                object cellValue = row.Cells["colPaymentID"].Value;
                int? paymentId = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (paymentId.HasValue)
                {
                    var payment = Helper.GetEntityById<Payment>(Program.Connection, paymentId.Value, "SP_GetPaymentByID");
                    if (payment != null)
                    {
                        PopulateFields(payment);
                    }
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtPaymentNo, false);
        }

        private decimal GetTotalAmount(Payment payment)
        {
            if (payment.IsUtilityOnly)
                return GetUtilityCost(payment.UtilityID!.Value);
            else if (payment.IsServiceOnly)
                return GetServiceCost(payment.ServiceID!.Value);
            else
                return GetReservationAmount(payment.ReservationID!.Value);
        }
        private void CbbReservationID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbReservationID.SelectedItem == null) return;

            int reservationId = int.Parse(cbbReservationID.SelectedItem.ToString()!);

            // Check first payment status
            using SqlCommand checkCmd = new("SELECT TOP 1 IsSecondPaymentDone FROM tblPayment WHERE ReservationID = @ReservationID AND Status = 1", Program.Connection);
            checkCmd.Parameters.AddWithValue("@ReservationID", reservationId);
            object? result = checkCmd.ExecuteScalar();
            bool isSecondPaymentDone = result != null && (bool)result;

            if (isSecondPaymentDone)
            {
                MessageBox.Show("Second payment already completed.", "Payment Status");
                cbbReservationID.SelectedIndex = -1;
                return;
            }

            using SqlCommand cmd = new("SP_GetReservationByID", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReservationID", reservationId);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                decimal roomAmount = Convert.ToDecimal(dr["RoomAmount"]);
                bool hasFirstPayment = result != null;

                txtTotalAmount.Text = roomAmount.ToString("N2");
                if (!hasFirstPayment)
                {
                    txtPaidAmount.Clear();
                    txtRemainAmount.Clear();
                }
                else
                {
                    txtPaidAmount.Text = dr["RemainingAmount"].ToString();
                    txtRemainAmount.Clear();
                }

                txtPaidAmount.ReadOnly = false;
                txtRemainAmount.ReadOnly = true;
                cbUtilityID.Enabled = false;
                cbServiceID.Enabled = false;
            }
        }


        private void ConfigureView()
        {
            dgvPayment.Columns.Clear();
            dgvPayment.Columns.Add("colPaymentID", "Payment ID");
            dgvPayment.Columns.Add("colDate", "Payment Date");
            dgvPayment.Columns.Add("colAmount", "Remaining Amount");
            dgvPayment.Columns.Add("colType", "Payment Type");

            dgvPayment.Columns[0].Width = 100;
            dgvPayment.Columns[1].Width = 150;
            dgvPayment.Columns[2].Width = 150;
            dgvPayment.Columns[3].Width = 150;

            dgvPayment.DefaultCellStyle.BackColor = Color.White;
            dgvPayment.ScrollBars = ScrollBars.Both;
            dgvPayment.Sort(dgvPayment.Columns["colPaymentID"], System.ComponentModel.ListSortDirection.Descending);

            UpdatePaymentView();
        }

        private void UpdatePaymentView()
        {
            try
            {
                dgvPayment.Rows.Clear();
                string SP_Name = "SP_GetAllPayments";
                var result = Helper.GetAllEntities<Payment>(Program.Connection, SP_Name);

                foreach (var payment in result)
                {
                    AddToView(payment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Payments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Payment payment)
        {
            string paymentType;

            if (payment.IsUtilityOnly)
            {
                paymentType = "Utility";
            }
            else if (payment.IsServiceOnly)
            {
                paymentType = "Service";
            }
            else if (payment.ReservationID.HasValue)
            {
                paymentType = "Reservation";
            }
            else
            {
                paymentType = "Unknown";
            }

            DataGridViewRow row = new();
            row.CreateCells(dgvPayment,
                payment.ID,
                payment.PaymentDate.HasValue ? payment.PaymentDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                payment.RemainingAmount,
                paymentType
            );
            row.Tag = payment.ID;
            dgvPayment.Rows.Add(row);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtPaymentNo, false);

            txtPaidAmount.ReadOnly = false;
            txtRemainAmount.ReadOnly = false;
            cbUtilityID.Enabled = true;
            cbServiceID.Enabled = true;
        }

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var payment = GatherPaymentInput();
            if (payment != null && ValidatePayment(payment))
            {
                try
                {
                    using (var cmd = new SqlCommand("SP_InsertPayment", Program.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        payment.AddParameters(cmd);

                        decimal totalAmount = GetTotalAmount(payment);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Check if the exception is due to the CHECK constraint
                    if (ex.Message.Contains("CK_Payment_Type"))
                    {
                        MessageBox.Show("You can only select one payment type: Reservation, Utility, or Service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Error inserting payment: {ex.Message}", "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private decimal GetUtilityCost(int utilityId)
        {
            using SqlCommand cmd = new("SP_GetUtilityByID", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UtilityID", utilityId);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return Convert.ToDecimal(dr["Cost"]);
            }
            return 0;
        }

        private decimal GetServiceCost(int serviceId)
        {
            using SqlCommand cmd = new("SP_GetServiceByID", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceID", serviceId);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return Convert.ToDecimal(dr["ServiceCost"]);
            }
            return 0;
        }

        private decimal GetReservationAmount(int reservationId)
        {
            using SqlCommand cmd = new("SP_GetReservationByID", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReservationID", reservationId);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return Convert.ToDecimal(dr["PaidAmount"]);
            }
            return 0;
        }

        private void DoOnPaymentInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;

            try
            {
                var result = Helper.GetEntityById<Payment>(Program.Connection, e.ByteId, "SP_GetPaymentByID");
                if (result != null)
                {
                    // Use Invoke to update UI from background thread
                    Invoke((MethodInvoker)delegate
                    {
                        AddToView(result);
                        dgvPayment.Refresh();
                        dgvPayment.Sort(dgvPayment.Columns["colPaymentID"], System.ComponentModel.ListSortDirection.Descending);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DoClickNew(sender, e);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvPayment.SelectedCells.Count > 0)
            {
                var payment = GatherPaymentInput();
                if (payment != null)
                {
                    payment.ID = int.Parse(txtPaymentNo.Text);
                    if (ValidatePayment(payment))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(payment, "SP_UpdatePayment", "Update");
                    }
                }
            }
        }

        private void DoOnPaymentUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvPayment.CurrentCell == null) return;
            int rowIndex = dgvPayment.CurrentCell.RowIndex;
            UpdatePaymentView();
            if (rowIndex < dgvPayment.Rows.Count)
            {
                dgvPayment.Rows[rowIndex].Selected = true;
                dgvPayment.CurrentCell = dgvPayment[0, rowIndex];
            }
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvPayment.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvPayment.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvPayment.Rows[rowIndex].Cells["colPaymentID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this payment?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeletePayment";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PaymentID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Payment ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdatePaymentView();
                    DoClickNew(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbReservationID_CheckedChanged(object? sender, EventArgs e)
        {
            bool isReservationPayment = cbReservationID.Checked;
            cbbReservationID.Enabled = isReservationPayment;

            cbUtilityID.Enabled = !isReservationPayment;
            cbServiceID.Enabled = !isReservationPayment;

            if (!isReservationPayment)
            {
                cbbReservationID.SelectedIndex = -1;
                txtPaidAmount.ReadOnly = false;
                txtRemainAmount.ReadOnly = false;
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
            }
        }

        private void DoOnPaymentDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdatePaymentView();
                });
            });
        }

        private Payment? GatherPaymentInput()
        {
            try
            {
                int? reservationId = null;
                int? utilityId = null;
                int? serviceId = null;
                bool isUtilityOnly = false;
                bool isServiceOnly = false;
                bool isSecondPaymentDone = false;
                decimal totalAmount = decimal.Parse(txtTotalAmount.Text);

                if (cbReservationID.Checked && cbbReservationID.SelectedItem != null)
                {
                    reservationId = int.Parse(cbbReservationID.SelectedItem.ToString()!);

                    using SqlCommand cmd = new("SELECT TOP 1 PaymentID FROM tblPayment WHERE ReservationID = @ReservationID AND Status = 1", Program.Connection);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    isSecondPaymentDone = cmd.ExecuteScalar() != null;
                }
                else if (cbUtilityID.Checked && cbbUtilityID.SelectedItem != null)
                {
                    utilityId = int.Parse(cbbUtilityID.SelectedItem.ToString()!);
                    isUtilityOnly = true;
                }
                else if (cbServiceID.Checked && cbbServiceID.SelectedItem != null)
                {
                    serviceId = int.Parse(cbbServiceID.SelectedItem.ToString()!);
                    isServiceOnly = true;
                }

                if (cbbStaffID.SelectedItem == null)
                {
                    MessageBox.Show("Please select a staff member", "Validation Error");
                    return null;
                }

                return new Payment
                {
                    PaymentDate = dtPaymentDate.Value,
                    ReservationID = reservationId,
                    StaffID = int.Parse(cbbStaffID.SelectedItem.ToString()!),
                    UtilityID = utilityId,
                    ServiceID = serviceId,
                    PaidAmount = decimal.Parse(txtPaidAmount.Text),
                    IsSecondPaymentDone = isSecondPaymentDone,
                    IsUtilityOnly = isUtilityOnly,
                    IsServiceOnly = isServiceOnly
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error gathering payment input: {ex.Message}", "Input Error");
                return null;
            }
        }


        private bool ValidatePayment(Payment payment)
        {
            if (payment.PaymentDate > DateTime.Now)
            {
                MessageBox.Show("Payment date cannot be in the future", "Validation Error");
                return false;
            }

            if (payment.PaidAmount <= 0)
            {
                MessageBox.Show("Paid amount must be greater than zero", "Validation Error");
                return false;
            }

            if (payment.RemainingAmount < 0)
            {
                MessageBox.Show("Remaining amount cannot be negative", "Validation Error");
                return false;
            }

            if (cbUtilityID.Checked && !payment.UtilityID.HasValue)
            {
                MessageBox.Show("Please select a utility for utility payment", "Validation Error");
                return false;
            }

            if (cbServiceID.Checked && !payment.ServiceID.HasValue)
            {
                MessageBox.Show("Please select a service for service payment", "Validation Error");
                return false;
            }

            if (cbReservationID.Checked && !payment.ReservationID.HasValue)
            {
                MessageBox.Show("Please select a reservation for reservation payment", "Validation Error");
                return false;
            }

            return true;
        }
        private void PopulateFields(Payment? payment)
        {
            if (payment != null)
            {
                txtPaymentNo.Text = payment.ID.ToString();
                dtPaymentDate.Value = payment.PaymentDate ?? DateTime.Now;
                txtPaidAmount.Text = payment.PaidAmount.ToString();
                txtRemainAmount.Text = payment.RemainingAmount.ToString();
                cbServiceID.Checked = payment.IsServiceOnly;
                cbUtilityID.Checked = payment.IsUtilityOnly;

                if (payment.IsUtilityOnly)
                {
                    cbbUtilityID.Text = payment.UtilityID.ToString();
                    txtUtilityName.Text = payment.Type;
                }
                if (payment.IsServiceOnly)
                {
                    cbbServiceID.Text = payment.ServiceID.ToString();
                    txtServiceType.Text = payment.Type;
                }
                else
                {
                    cbbReservationID.Text = payment.ReservationID.ToString();
                }

                cbUtilityID.Enabled = !payment.IsServiceOnly;
                cbServiceID.Enabled = !payment.IsUtilityOnly;
                cbbStaffID.Text = payment.StaffID.ToString();
            }
            else
            {
                txtPaymentNo.Clear();
                dtPaymentDate.Value = DateTime.Now;
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
                cbbUtilityID.SelectedIndex = -1;
                txtUtilityName.Clear();
                cbbReservationID.SelectedIndex = -1;
                cbbStaffID.SelectedIndex = -1;
                txtStaffName.Clear();
                cbUtilityID.Checked = false;
                cbbServiceID.SelectedIndex = -1;
                txtServiceType.Clear();
                cbServiceID.Checked = false;
            }
        }
        private void TxtPaidAmount_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text) || string.IsNullOrEmpty(txtTotalAmount.Text)) return;

            if (decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount) &&
                decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount))
            {
                txtRemainAmount.Text = (totalAmount - paidAmount).ToString("N2");
            }
        }
        private void InitializeButtons()
        {
            btnInsert.Enabled = false;

            // Enable insert when valid inputs exist
            txtPaidAmount.TextChanged += (s, e) => ValidateInputs();
            cbUtilityID.CheckedChanged += (s, e) => ValidateInputs();
            cbServiceID.CheckedChanged += (s, e) => ValidateInputs();
            cbReservationID.CheckedChanged += (s, e) => ValidateInputs();
        }
        private void ValidateInputs()
        {
            bool hasValidInput = false;

            if (cbUtilityID.Checked && cbbUtilityID.SelectedItem != null && !string.IsNullOrEmpty(txtPaidAmount.Text))
                hasValidInput = true;
            else if (cbServiceID.Checked && cbbServiceID.SelectedItem != null && !string.IsNullOrEmpty(txtPaidAmount.Text))
                hasValidInput = true;
            else if (cbReservationID.Checked && cbbReservationID.SelectedItem != null && !string.IsNullOrEmpty(txtPaidAmount.Text))
                hasValidInput = true;

            btnInsert.Enabled = hasValidInput;
        }
    }
}