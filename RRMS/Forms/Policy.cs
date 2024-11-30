using Microsoft.Data.SqlClient;
using RRMS.Model;

namespace RRMS
{
    public partial class Policy : Form
    {
        public Policy()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

//namespace RRMS
//{
//    public partial class Policy : Form
//    {
//        public Policy()
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
//            dateCreate.Enabled = false;
//            dateUpdate.Enabled = false;

//            // Setup ListView
//            SetupListView();
//            // Load initial data
//            LoadPolicyData();
//        }

//        private void SetupListView()
//        {
//            listView1.View = View.Details;
//            listView1.FullRowSelect = true;
//            listView1.GridLines = true;

//            // Add columns
//            listView1.Columns.Add("ID", 50);
//            listView1.Columns.Add("Name", 100);
//            listView1.Columns.Add("Description", 150);
//            listView1.Columns.Add("Created Date", 100);
//            listView1.Columns.Add("Updated Date", 100);
//            listView1.Columns.Add("Resident ID", 80);
//            listView1.Columns.Add("Resident Name", 120);
//        }

//        private void LoadPolicyData()
//        {
//            try
//            {
//                listView1.Items.Clear();
//                using (SqlConnection conn = DbHelper.GetConnection())
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_ReadPolicy", conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        conn.Open();
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                ListViewItem item = new ListViewItem(reader["PolicyID"].ToString());
//                                item.SubItems.Add(reader["PolicyName"].ToString());
//                                item.SubItems.Add(reader["Description"].ToString());
//                                item.SubItems.Add(Convert.ToDateTime(reader["CreatedDate"]).ToString("yyyy-MM-dd"));
//                                item.SubItems.Add(reader["UpdatedDate"] != DBNull.Value ? 
//                                    Convert.ToDateTime(reader["UpdatedDate"]).ToString("yyyy-MM-dd") : "");
//                                item.SubItems.Add(reader["ResidentID"].ToString());

//                                using (SqlConnection conn2 = DbHelper.GetConnection())
//                                using (SqlCommand cmd2 = new SqlCommand("sp_GetResidentName", conn2))
//                                {
//                                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
//                                    cmd2.Parameters.AddWithValue("@ResidentID", reader["ResidentID"]);
//                                    conn2.Open();
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
//                MessageBox.Show($"Error loading policy data: {ex.Message}", "Error",
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
//                txtName.Text = item.SubItems[1].Text;
//                txtDesc.Text = item.SubItems[2].Text;
//                dateCreate.Value = DateTime.Parse(item.SubItems[3].Text);
//                dateUpdate.Value = !string.IsNullOrEmpty(item.SubItems[4].Text) ? 
//                    DateTime.Parse(item.SubItems[4].Text) : DateTime.Now;
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
//                    var policy = new Model.Policy
//                    {
//                        PolicyName = txtName.Text,
//                        Description = txtDesc.Text,
//                        ResidentID = int.Parse(txtResidentID.Text)
//                    };

//                    int newPolicyId = InsertPolicy(policy);
//                    txtID.Text = newPolicyId.ToString();
//                    MessageBox.Show("Policy inserted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadPolicyData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error inserting policy: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(txtName.Text))
//            {
//                MessageBox.Show("Please enter policy name.", "Validation Error");
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(txtDesc.Text))
//            {
//                MessageBox.Show("Please enter description.", "Validation Error");
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

//        private int InsertPolicy(Model.Policy policy)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_CreatePolicy", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
//                    cmd.Parameters.AddWithValue("@Description", policy.Description);
//                    cmd.Parameters.AddWithValue("@ResidentID", policy.ResidentID);

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
//                    MessageBox.Show("Please select a policy to update.", "Validation Error");
//                    return;
//                }

//                if (ValidateInputs())
//                {
//                    var policy = new Model.Policy
//                    {
//                        PolicyID = int.Parse(txtID.Text),
//                        PolicyName = txtName.Text,
//                        Description = txtDesc.Text,
//                        ResidentID = int.Parse(txtResidentID.Text)
//                    };

//                    DialogResult result = MessageBox.Show(
//                        "Are you sure you want to update this policy?",
//                        "Confirm Update",
//                        MessageBoxButtons.YesNo,
//                        MessageBoxIcon.Question);

//                    if (result == DialogResult.Yes)
//                    {
//                        UpdatePolicy(policy);
//                        MessageBox.Show("Policy updated successfully!", "Success", 
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadPolicyData();
//                        ClearForm();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error updating policy: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdatePolicy(Model.Policy policy)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_UpdatePolicy", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyID);
//                    cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
//                    cmd.Parameters.AddWithValue("@Description", policy.Description);
//                    cmd.Parameters.AddWithValue("@ResidentID", policy.ResidentID);

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
//                    MessageBox.Show("Please select a policy to delete.", "Validation Error");
//                    return;
//                }

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this policy?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    DeletePolicy(int.Parse(txtID.Text));
//                    MessageBox.Show("Policy deleted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadPolicyData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error deleting policy: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DeletePolicy(int policyId)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_DeletePolicy", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@PolicyID", policyId);

//                    conn.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        private void ClearForm()
//        {
//            txtID.Clear();
//            txtName.Clear();
//            txtDesc.Clear();
//            dateCreate.Value = DateTime.Now;
//            dateUpdate.Value = DateTime.Now;
//            txtResidentID.Clear();
//            txtResidentName.Clear();
//        }
//    }
//}
