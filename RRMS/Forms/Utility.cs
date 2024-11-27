using Microsoft.Data.SqlClient;
//using RRMS.Helper;
using RRMS.Model;

namespace RRMS
{
    public partial class Utility : Form
    {
        public Utility()
        {
            InitializeComponent();
        }
    }
}

//namespace RRMS
//{
//    public partial class Utility : Form
//    {
//        public Utility()
//        {
//            InitializeComponent();
//            btnInsert.Click += BtnInsert_Click;
//            btnUpdate.Click += BtnUpdate_Click;
//            btnDelete.Click += BtnDelete_Click;
//            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;

//            // Make ID textbox read-only since it's auto-generated
//            txtID.ReadOnly = true;

//            // Setup ListView
//            SetupListView();
//            // Load initial data
//            LoadUtilityData();

//            // Clear existing items first
//            cboUtilityType.Items.Clear();
//            // Setup utility type combo box with unique items
//            cboUtilityType.Items.AddRange(new string[] { "Electricity", "Water", "Internet", "Other" });
//            cboUtilityType.DropDownStyle = ComboBoxStyle.DropDownList; // Make it read-only
//        }

//        private void SetupListView()
//        {
//            listView1.View = View.Details;
//            listView1.FullRowSelect = true;
//            listView1.GridLines = true;

//            // Add columns
//            listView1.Columns.Add("ID", 50);
//            listView1.Columns.Add("Type", 100);
//            listView1.Columns.Add("Cost", 100);
//            listView1.Columns.Add("Usage Date", 100);
//            listView1.Columns.Add("Room ID", 80);
//        }

//        private void LoadUtilityData()
//        {
//            try
//            {
//                listView1.Items.Clear();
//                using (SqlConnection conn = DbHelper.GetConnection())
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_ReadUtility", conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        conn.Open();
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                ListViewItem item = new ListViewItem(reader["UtilityID"].ToString());
//                                item.SubItems.Add(reader["UtilityType"].ToString());
//                                item.SubItems.Add(reader["Cost"].ToString());
//                                item.SubItems.Add(Convert.ToDateTime(reader["UsageDate"]).ToString("yyyy-MM-dd"));
//                                item.SubItems.Add(reader["RoomID"].ToString());
//                                listView1.Items.Add(item);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading utility data: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (listView1.SelectedItems.Count > 0)
//            {
//                ListViewItem item = listView1.SelectedItems[0];

//                txtID.Text = item.SubItems[0].Text;
//                cboUtilityType.Text = item.SubItems[1].Text;
//                txtCost.Text = item.SubItems[2].Text;
//                dateUsage.Value = DateTime.Parse(item.SubItems[3].Text);
//                txtRoomID.Text = item.SubItems[4].Text;
//            }
//        }

//        private void BtnInsert_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ValidateInputs())
//                {
//                    var utility = new Model.Utility
//                    {
//                        UtilityType = cboUtilityType.Text,
//                        Cost = decimal.Parse(txtCost.Text),
//                        UsageDate = dateUsage.Value,
//                        RoomID = int.Parse(txtRoomID.Text)
//                    };

//                    int newUtilityId = InsertUtility(utility);
//                    txtID.Text = newUtilityId.ToString();
//                    MessageBox.Show("Utility record inserted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadUtilityData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error inserting utility record: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(cboUtilityType.Text))
//            {
//                MessageBox.Show("Please select utility type.", "Validation Error");
//                return false;
//            }

//            if (!decimal.TryParse(txtCost.Text, out _))
//            {
//                MessageBox.Show("Please enter a valid cost amount.", "Validation Error");
//                return false;
//            }

//            if (!int.TryParse(txtRoomID.Text, out _))
//            {
//                MessageBox.Show("Please enter a valid Room ID.", "Validation Error");
//                return false;
//            }

//            if (!CheckRoomID(int.Parse(txtRoomID.Text)))
//            {
//                MessageBox.Show("Room not found.", "Validation Error");
//                return false;
//            }

//            return true;
//        }

//        private bool CheckRoomID(int roomId)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_CheckRoomID", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@RoomID", roomId);

//                    conn.Open();
//                    var result = cmd.ExecuteScalar();
//                    return result != null;
//                }
//            }
//        }

//        private int InsertUtility(Model.Utility utility)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_CreateUtility", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@UtilityType", utility.UtilityType);
//                    cmd.Parameters.AddWithValue("@Cost", utility.Cost);
//                    cmd.Parameters.AddWithValue("@UsageDate", utility.UsageDate);
//                    cmd.Parameters.AddWithValue("@RoomID", utility.RoomID);

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
//                    MessageBox.Show("Please select a utility record to update.", "Validation Error");
//                    return;
//                }

//                if (ValidateInputs())
//                {
//                    var utility = new Model.Utility
//                    {
//                        UtilityID = int.Parse(txtID.Text),
//                        UtilityType = cboUtilityType.Text,
//                        Cost = decimal.Parse(txtCost.Text),
//                        UsageDate = dateUsage.Value,
//                        RoomID = int.Parse(txtRoomID.Text)
//                    };

//                    DialogResult result = MessageBox.Show(
//                        "Are you sure you want to update this utility record?",
//                        "Confirm Update",
//                        MessageBoxButtons.YesNo,
//                        MessageBoxIcon.Question);

//                    if (result == DialogResult.Yes)
//                    {
//                        UpdateUtility(utility);
//                        MessageBox.Show("Utility record updated successfully!", "Success", 
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadUtilityData();
//                        ClearForm();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error updating utility record: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateUtility(Model.Utility utility)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_UpdateUtility", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@UtilityID", utility.UtilityID);
//                    cmd.Parameters.AddWithValue("@UtilityType", utility.UtilityType);
//                    cmd.Parameters.AddWithValue("@Cost", utility.Cost);
//                    cmd.Parameters.AddWithValue("@UsageDate", utility.UsageDate);
//                    cmd.Parameters.AddWithValue("@RoomID", utility.RoomID);

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
//                    MessageBox.Show("Please select a utility record to delete.", "Validation Error");
//                    return;
//                }

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this utility record?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    DeleteUtility(int.Parse(txtID.Text));
//                    MessageBox.Show("Utility record deleted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadUtilityData();
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error deleting utility record: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DeleteUtility(int utilityId)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_DeleteUtility", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@UtilityID", utilityId);

//                    conn.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        private void ClearForm()
//        {
//            txtID.Clear();
//            cboUtilityType.SelectedIndex = -1;
//            txtCost.Clear();
//            dateUsage.Value = DateTime.Now;
//            txtRoomID.Clear();
//        }
//    }
//} 