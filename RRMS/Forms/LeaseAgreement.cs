using Microsoft.Data.SqlClient;
using RRMS.Model;

namespace RRMS
{
    public partial class LeaseAgreement : Form
    {
        public LeaseAgreement()
        {
            InitializeComponent();
        }
    }
}

//namespace RRMS
//{
//    public partial class LeaseAgreement : Form
//    {
//        public LeaseAgreement()
//        {
//            InitializeComponent();
//            btnInsert.Click += BtnInsert_Click;
//            btnUpdate.Click += BtnUpdate_Click;
//            btnDelete.Click += BtnDelete_Click;
//            txtResidentID.Leave += TxtResidentID_Leave;
//            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;

//            // Make ID textbox read-only since it's auto-generated
//            txtID.ReadOnly = true;
//            txtResidentName.ReadOnly = true;

//            // Setup ListView
//            SetupListView();
//            // Load initial data
//            LoadLeaseData();
//        }

//        private void SetupListView()
//        {
//            listView1.View = View.Details;
//            listView1.FullRowSelect = true;
//            listView1.GridLines = true;

//            // Add columns
//            listView1.Columns.Add("ID", 50);
//            listView1.Columns.Add("Start Date", 100);
//            listView1.Columns.Add("End Date", 100);
//            listView1.Columns.Add("Monthly Rent", 100);
//            listView1.Columns.Add("Terms", 150);
//            listView1.Columns.Add("Resident ID", 80);
//            listView1.Columns.Add("Resident Name", 120);
//        }

//        private void LoadLeaseData()
//        {
//            try
//            {
//                listView1.Items.Clear();
//                using (SqlConnection conn = DbHelper.GetConnection())
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_ReadLeaseAgreement", conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        conn.Open();
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                ListViewItem item = new ListViewItem(reader["LeaseAgreementID"].ToString());
//                                item.SubItems.Add(Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd"));
//                                item.SubItems.Add(Convert.ToDateTime(reader["EndDate"]).ToString("yyyy-MM-dd"));
//                                item.SubItems.Add(reader["MonthlyRent"].ToString());
//                                item.SubItems.Add(reader["TermsAndConditions"].ToString());
//                                item.SubItems.Add(reader["ResidentID"].ToString());

//                                using (SqlCommand cmd2 = new SqlCommand("sp_GetResidentName", conn))
//                                {
//                                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//                                    cmd2.Parameters.AddWithValue("@ResidentID", reader["ResidentID"]);
//                                    var residentName = cmd2.ExecuteScalar()?.ToString() ?? "";
//                                    item.SubItems.Add(residentName);
//                                }

//                                listView1.Items.Add(item);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading lease data: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void TxtResidentID_Leave(object sender, EventArgs e)
//        {
//            if (!string.IsNullOrWhiteSpace(txtResidentID.Text) && int.TryParse(txtResidentID.Text, out int residentId))
//            {
//                FillResidentName(residentId);
//            }
//        }

//        private void FillResidentName(int residentId)
//        {
//            try
//            {
//                using (SqlConnection conn = DbHelper.GetConnection())
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_GetResidentName", conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        cmd.Parameters.AddWithValue("@ResidentID", residentId);
//                        conn.Open();
//                        var result = cmd.ExecuteScalar();

//                        if (result != null)
//                        {
//                            txtResidentName.Text = result.ToString();
//                        }
//                        else
//                        {
//                            MessageBox.Show("Resident ID not found!", "Error", 
//                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                            txtResidentName.Clear();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (listView1.SelectedItems.Count > 0)
//            {
//                ListViewItem item = listView1.SelectedItems[0];

//                txtID.Text = item.SubItems[0].Text;
//                dateStart.Value = DateTime.Parse(item.SubItems[1].Text);
//                dateEnd.Value = DateTime.Parse(item.SubItems[2].Text);
//                txtMonthlyRent.Text = item.SubItems[3].Text;
//                txtTerms.Text = item.SubItems[4].Text;
//                txtResidentID.Text = item.SubItems[5].Text;
//                txtResidentName.Text = item.SubItems[6].Text;
//            }
//        }

//        private void BtnInsert_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ValidateInputs())
//                {
//                    var lease = new Model.LeaseAgreement
//                    {
//                        StartDate = dateStart.Value,
//                        EndDate = dateEnd.Value,
//                        MonthlyRent = decimal.Parse(txtMonthlyRent.Text),
//                        TermsAndConditions = txtTerms.Text,
//                        ResidentID = int.Parse(txtResidentID.Text)
//                    };

//                    int newLeaseId = InsertLease(lease);
//                    txtID.Text = newLeaseId.ToString();
//                    MessageBox.Show("Lease agreement inserted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadLeaseData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error inserting lease agreement: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private bool ValidateInputs()
//        {
//            if (dateEnd.Value < dateStart.Value)
//            {
//                MessageBox.Show("End date must be after start date.", "Validation Error");
//                return false;
//            }

//            if (!decimal.TryParse(txtMonthlyRent.Text, out _))
//            {
//                MessageBox.Show("Please enter a valid monthly rent amount.", "Validation Error");
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(txtTerms.Text))
//            {
//                MessageBox.Show("Please enter terms and conditions.", "Validation Error");
//                return false;
//            }

//            if (!int.TryParse(txtResidentID.Text, out _))
//            {
//                MessageBox.Show("Please enter a valid Resident ID.", "Validation Error");
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(txtResidentName.Text))
//            {
//                MessageBox.Show("Invalid Resident ID. Please enter a valid Resident ID.", "Validation Error");
//                return false;
//            }

//            return true;
//        }

//        private int InsertLease(Model.LeaseAgreement lease)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_CreateLeaseAgreement", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
//                    cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
//                    cmd.Parameters.AddWithValue("@MonthlyRent", lease.MonthlyRent);
//                    cmd.Parameters.AddWithValue("@TermsAndConditions", lease.TermsAndConditions);
//                    cmd.Parameters.AddWithValue("@ResidentID", lease.ResidentID);

//                    conn.Open();
//                    var result = cmd.ExecuteScalar();
//                    return Convert.ToInt32(result);
//                }
//            }
//        }

//        private void BtnUpdate_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(txtID.Text))
//                {
//                    MessageBox.Show("Please select a lease agreement to update.", "Validation Error");
//                    return;
//                }

//                if (ValidateInputs())
//                {
//                    var lease = new Model.LeaseAgreement
//                    {
//                        LeaseAgreementID = int.Parse(txtID.Text),
//                        StartDate = dateStart.Value,
//                        EndDate = dateEnd.Value,
//                        MonthlyRent = decimal.Parse(txtMonthlyRent.Text),
//                        TermsAndConditions = txtTerms.Text,
//                        ResidentID = int.Parse(txtResidentID.Text)
//                    };

//                    DialogResult result = MessageBox.Show(
//                        "Are you sure you want to update this lease agreement?",
//                        "Confirm Update",
//                        MessageBoxButtons.YesNo,
//                        MessageBoxIcon.Question);

//                    if (result == DialogResult.Yes)
//                    {
//                        UpdateLease(lease);
//                        MessageBox.Show("Lease agreement updated successfully!", "Success", 
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadLeaseData();
//                        ClearForm();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error updating lease agreement: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateLease(Model.LeaseAgreement lease)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_UpdateLeaseAgreement", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@LeaseAgreementID", lease.LeaseAgreementID);
//                    cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
//                    cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
//                    cmd.Parameters.AddWithValue("@MonthlyRent", lease.MonthlyRent);
//                    cmd.Parameters.AddWithValue("@TermsAndConditions", lease.TermsAndConditions);
//                    cmd.Parameters.AddWithValue("@ResidentID", lease.ResidentID);

//                    conn.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        private void BtnDelete_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(txtID.Text))
//                {
//                    MessageBox.Show("Please select a lease agreement to delete.", "Validation Error");
//                    return;
//                }

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this lease agreement?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    DeleteLease(int.Parse(txtID.Text));
//                    MessageBox.Show("Lease agreement deleted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadLeaseData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error deleting lease agreement: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DeleteLease(int leaseId)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_DeleteLeaseAgreement", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@LeaseAgreementID", leaseId);

//                    conn.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        private void ClearForm()
//        {
//            txtID.Clear();
//            dateStart.Value = DateTime.Now;
//            dateEnd.Value = DateTime.Now;
//            txtMonthlyRent.Clear();
//            txtTerms.Clear();
//            txtResidentID.Clear();
//            txtResidentName.Clear();
//        }
//    }
//} 