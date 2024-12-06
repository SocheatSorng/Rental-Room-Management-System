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
            txtPaidAmount.Leave += TxtPaidAmount_Leave;
            cbbReservationID.SelectedIndexChanged += CbbReservationID_SelectedIndexChanged;
            cbServiceID.CheckedChanged += CbServiceID_CheckedChanged;
            cbbServiceID.SelectedIndexChanged += CbbServiceID_SelectedIndexChanged;

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

            txtPaidAmount.ReadOnly = false;
            txtRemainAmount.ReadOnly = true;
            cbbUtilityID.Enabled = false;
            txtUtilityName.Enabled = false;
            cbbServiceID.Enabled = false;
            txtServiceName.Enabled = false;

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
                        string? serviceID = dr["ServiceID"].ToString();
                        cbbServiceID.Items.Add(serviceID);
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
                    while (dr.Read())
                    {
                        txtUtilityName.Text = dr["UtilityType"].ToString();
                        txtRemainAmount.Text = dr["Cost"].ToString();
                    }
                }
            }
        }

        private void CbUtilityID_CheckedChanged(object? sender, EventArgs e)
        {
            bool isUtilityPayment = cbUtilityID.Checked;

            // Enable/disable utility controls
            cbbUtilityID.Enabled = isUtilityPayment;
            txtUtilityName.Enabled = isUtilityPayment;

            // Disable other payment options
            cbbReservationID.Enabled = !isUtilityPayment;
            cbServiceID.Enabled = !isUtilityPayment;
            cbbServiceID.Enabled = false;

            txtPaidAmount.ReadOnly = false;

            if (isUtilityPayment)
            {
                // Clear other payment options
                cbbReservationID.SelectedIndex = -1;
                cbbServiceID.SelectedIndex = -1;
                txtServiceName.Clear();

                // Clear payment fields
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
                txtRemainAmount.ReadOnly = true;
            }
            else
            {
                // Clear utility fields
                cbbUtilityID.SelectedIndex = -1;
                txtUtilityName.Clear();
            }
        }

        private void CbServiceID_CheckedChanged(object? sender, EventArgs e)
        {
            bool isServicePayment = cbServiceID.Checked;

            // Enable/disable service controls
            cbbServiceID.Enabled = isServicePayment;
            txtServiceName.Enabled = isServicePayment;

            // Disable other payment options
            cbbReservationID.Enabled = !isServicePayment;
            cbUtilityID.Enabled = !isServicePayment;
            cbbUtilityID.Enabled = false;

            txtPaidAmount.ReadOnly = false;

            if (isServicePayment)
            {
                // Clear other payment options
                cbbReservationID.SelectedIndex = -1;
                cbbUtilityID.SelectedIndex = -1;
                txtUtilityName.Clear();

                // Clear payment fields
                txtPaidAmount.Clear();
                txtRemainAmount.Clear();
                txtRemainAmount.ReadOnly = true;
            }
            else
            {
                // Clear service fields
                cbbServiceID.SelectedIndex = -1;
                txtServiceName.Clear();
            }
        }
        private void CbbServiceID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbServiceID.SelectedItem != null)
            {
                using SqlCommand cmd = new("SP_GetServiceByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceID", cbbServiceID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtServiceName.Text = dr["ServiceName"].ToString();
                        txtRemainAmount.Text = dr["ServiceCost"].ToString();
                    }
                }
            }
        }
        private void TxtPaidAmount_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text)) return;

            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount))
            {
                MessageBox.Show("Please enter a valid amount", "Invalid Input");
                txtPaidAmount.Clear();
                return;
            }

            try
            {
                decimal totalAmount = 0;
                decimal remainingAmount = 0;

                // Handle Utility Payment
                if (cbUtilityID.Checked && cbbUtilityID.SelectedItem != null)
                {
                    using SqlCommand cmd = new("SP_GetUtilityByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UtilityID", int.Parse(cbbUtilityID.SelectedItem.ToString()!));

                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        totalAmount = Convert.ToDecimal(dr["Cost"]);
                        remainingAmount = totalAmount - paidAmount;

                        if (remainingAmount < 0)
                        {
                            MessageBox.Show("Paid amount cannot exceed the utility cost.", "Invalid Amount");
                            txtPaidAmount.Clear();
                            return;
                        }

                        txtRemainAmount.Text = remainingAmount.ToString("N2");
                    }
                }
                // Handle Service Payment
                else if (cbServiceID.Checked && cbbServiceID.SelectedItem != null)
                {
                    using SqlCommand cmd = new("SP_GetServiceByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", int.Parse(cbbServiceID.SelectedItem.ToString()!));

                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        totalAmount = Convert.ToDecimal(dr["ServiceCost"]);
                        remainingAmount = totalAmount - paidAmount;

                        if (remainingAmount < 0)
                        {
                            MessageBox.Show("Paid amount cannot exceed the service cost.", "Invalid Amount");
                            txtPaidAmount.Clear();
                            return;
                        }

                        txtRemainAmount.Text = remainingAmount.ToString("N2");
                    }
                }
                // Handle Reservation Payment
                else if (cbbReservationID.SelectedItem != null)
                {
                    if (decimal.TryParse(txtRemainAmount.Text, out decimal currentRemaining))
                    {
                        remainingAmount = currentRemaining - paidAmount;

                        if (remainingAmount < 0)
                        {
                            MessageBox.Show("Paid amount cannot exceed the remaining amount.", "Invalid Amount");
                            txtPaidAmount.Clear();
                            return;
                        }

                        txtRemainAmount.Text = remainingAmount.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating remaining amount: {ex.Message}",
                    "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaidAmount.Clear();
            }
        }

        private void CbbReservationID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbReservationID.SelectedItem == null) return;

            using (var connection = new SqlConnection(Program.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    int reservationId = int.Parse(cbbReservationID.SelectedItem.ToString()!);

                    // First check if there are any previous payments for this reservation
                    using (SqlCommand cmdPayment = new("SP_GetLastPaymentByReservationID", connection))
                    {
                        cmdPayment.CommandType = CommandType.StoredProcedure;
                        cmdPayment.Parameters.AddWithValue("@ReservationID", reservationId);

                        using SqlDataReader paymentDr = cmdPayment.ExecuteReader();
                        if (paymentDr.Read() && paymentDr["RemainingAmount"] != DBNull.Value)
                        {
                            // If there's a previous payment, use its remaining amount
                            decimal remainingAmount = Convert.ToDecimal(paymentDr["RemainingAmount"]);
                            txtRemainAmount.Text = remainingAmount.ToString("N2");
                        }
                        else
                        {
                            paymentDr.Close();
                            // If no previous payment, get the base price from room type
                            using SqlCommand cmdRoom = new("SP_GetReservationRoomTypePrice", connection);
                            cmdRoom.CommandType = CommandType.StoredProcedure;
                            cmdRoom.Parameters.AddWithValue("@ReservationID", reservationId);

                            using SqlDataReader roomDr = cmdRoom.ExecuteReader();
                            if (roomDr.Read())
                            {
                                decimal basePrice = Convert.ToDecimal(roomDr["BasePrice"]);
                                txtRemainAmount.Text = basePrice.ToString("N2");
                            }
                        }
                    }

                    txtRemainAmount.ReadOnly = true;
                    txtPaidAmount.ReadOnly = false;
                    txtPaidAmount.Clear();

                    // Disable utility option when reservation is selected
                    cbUtilityID.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving payment information: {ex.Message}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void ConfigureView()
        {
            dgvPayment.Columns.Clear();
            dgvPayment.Columns.Add("colPaymentID", "Payment ID");
            dgvPayment.Columns.Add("colDate", "Payment Date");
            dgvPayment.Columns.Add("colAmount", "Amount");
            dgvPayment.Columns.Add("colType", "Payment Type");

            dgvPayment.Columns[0].Width = 100;
            dgvPayment.Columns[1].Width = 150;
            dgvPayment.Columns[2].Width = 150;
            dgvPayment.Columns[3].Width = 150;

            dgvPayment.DefaultCellStyle.BackColor = Color.White;
            dgvPayment.ScrollBars = ScrollBars.Both;

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
            string paymentType = payment.IsUtilityOnly ? "Utility" :
                                payment.IsServiceOnly ? "Service" :
                                "Reservation";
            DataGridViewRow row = new();
            row.CreateCells(dgvPayment,
                payment.ID,
                payment.PaymentDate.HasValue ? payment.PaymentDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                payment.PaymentDate.HasValue ? payment.PaymentDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                payment.PaidAmount,
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
        }

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var payment = GatherPaymentInput();
            if (payment != null && ValidatePayment(payment))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(payment, "SP_InsertPayment", "Insert");
                ConfigureView();
            }
        }

        private void DoOnPaymentInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Payment>(Program.Connection, e.ByteId, "SP_GetPaymentByID");
                    if (result != null)
                    {
                        Invoke((MethodInvoker)delegate
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

                if (cbUtilityID.Checked && cbbUtilityID.SelectedItem != null)
                {
                    utilityId = int.Parse(cbbUtilityID.SelectedItem.ToString()!);
                }
                else if (cbServiceID.Checked && cbbServiceID.SelectedItem != null)
                {
                    serviceId = int.Parse(cbbServiceID.SelectedItem.ToString()!);
                }
                else if (cbbReservationID.SelectedItem != null)
                {
                    reservationId = int.Parse(cbbReservationID.SelectedItem.ToString()!);
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
                    RemainingAmount = decimal.Parse(txtRemainAmount.Text),
                    IsUtilityOnly = cbUtilityID.Checked,
                    IsServiceOnly = cbServiceID.Checked
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

            if (payment.IsUtilityOnly && !payment.UtilityID.HasValue)
            {
                MessageBox.Show("Please select a utility for utility payment", "Validation Error");
                return false;
            }

            if (payment.IsServiceOnly && !payment.ServiceID.HasValue)
            {
                MessageBox.Show("Please select a service for service payment", "Validation Error");
                return false;
            }

            if (!payment.IsUtilityOnly && !payment.IsServiceOnly && !payment.ReservationID.HasValue)
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

                cbUtilityID.Checked = payment.IsUtilityOnly;
                cbServiceID.Checked = payment.IsServiceOnly;
                if (payment.IsUtilityOnly)
                {
                    cbbUtilityID.Text = payment.UtilityID.ToString();
                    txtUtilityName.Text = payment.Type;
                }
                else if (payment.IsServiceOnly)
                {
                    cbbServiceID.Text = payment.ServiceID.ToString();
                    txtServiceName.Text = payment.FirstName; // Service name is stored in FirstName
                }
                else
                {
                    cbbReservationID.Text = payment.ReservationID.ToString();
                }

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
                cbbServiceID.SelectedIndex = -1;
                txtServiceName.Clear();
                cbbReservationID.SelectedIndex = -1;
                cbbStaffID.SelectedIndex = -1;
                txtStaffName.Clear();
                cbUtilityID.Checked = false;
                cbServiceID.Checked = false;
            }
        }
    }
}