using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRMS
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }
    }
}

// Hello everyone

//namespace RRMS
//{
//    public partial class Feedback : Form
//    {
//        public Feedback()
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
//            LoadFeedbackData();
//        }

//        private void SetupListView()
//        {
//            listView1.View = View.Details;
//            listView1.FullRowSelect = true;
//            listView1.GridLines = true;

//            // Add columns
//            listView1.Columns.Add("ID", 50);
//            listView1.Columns.Add("Date", 100);
//            listView1.Columns.Add("Comments", 150);
//            listView1.Columns.Add("Rating", 50);
//            listView1.Columns.Add("Resident ID", 80);
//            listView1.Columns.Add("Resident Name", 120);
//        }

//        private void LoadFeedbackData()
//        {
//            try
//            {
//                listView1.Items.Clear();
//                using (SqlConnection conn = DbHelper.GetConnection())
//                {
//                    using (SqlCommand cmd = new SqlCommand("sp_ReadFeedback", conn))
//                    {
//                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                        conn.Open();
//                        using (SqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                ListViewItem item = new ListViewItem(reader["FeedbackID"].ToString());
//                                item.SubItems.Add(Convert.ToDateTime(reader["FeedbackDate"]).ToString("yyyy-MM-dd"));
//                                item.SubItems.Add(reader["Comments"].ToString());
//                                item.SubItems.Add(reader["Rating"].ToString());
//                                item.SubItems.Add(reader["ResidentID"].ToString());

//                                // Get resident name using another query
//                                using (SqlConnection conn2 = DbHelper.GetConnection())
//                                using (SqlCommand cmd2 = new SqlCommand("SELECT ResidentName FROM tblResident WHERE ResidentID = @ResidentID", conn2))
//                                {
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
//                MessageBox.Show($"Error loading feedback data: {ex.Message}", "Error",
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
//                    using (SqlCommand cmd = new SqlCommand("SELECT ResidentName FROM tblResident WHERE ResidentID = @ResidentID", conn))
//                    {
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

//        private void BtnInsert_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ValidateInputs())
//                {
//                    var feedback = new Model.Feedback
//                    {
//                        Comments = txtComments.Text,
//                        Rating = (int)numRating.Value,
//                        ResidentID = int.Parse(txtResidentID.Text)
//                    };

//                    int newFeedbackId = InsertFeedback(feedback);
//                    txtID.Text = newFeedbackId.ToString();
//                    MessageBox.Show("Feedback inserted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadFeedbackData(); // Refresh the ListView
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error inserting feedback: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(txtComments.Text))
//            {
//                MessageBox.Show("Please enter comments.", "Validation Error");
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

//        private int InsertFeedback(Model.Feedback feedback)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_CreateFeedback", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
//                    cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
//                    cmd.Parameters.AddWithValue("@ResidentID", feedback.ResidentID);

//                    conn.Open();
//                    var result = cmd.ExecuteScalar();
//                    return Convert.ToInt32(result);
//                }
//            }
//        }

//        private void ClearForm()
//        {
//            txtID.Clear();
//            txtComments.Clear();
//            numRating.Value = 1;
//            dateFeedback.Value = DateTime.Now;
//            txtResidentID.Clear();
//            txtResidentName.Clear();
//        }

//        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (listView1.SelectedItems.Count > 0)
//            {
//                ListViewItem item = listView1.SelectedItems[0];

//                // Fill the form fields with the selected item's data
//                txtID.Text = item.SubItems[0].Text;
//                dateFeedback.Value = DateTime.Parse(item.SubItems[1].Text);
//                txtComments.Text = item.SubItems[2].Text;
//                numRating.Value = decimal.Parse(item.SubItems[3].Text);
//                txtResidentID.Text = item.SubItems[4].Text;
//                txtResidentName.Text = item.SubItems[5].Text;
//            }
//        }

//        private void BtnUpdate_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(txtID.Text))
//                {
//                    MessageBox.Show("Please select a feedback to update.", "Validation Error");
//                    return;
//                }

//                if (ValidateInputs())
//                {
//                    var feedback = new Model.Feedback
//                    {
//                        FeedbackID = int.Parse(txtID.Text),
//                        Comments = txtComments.Text,
//                        Rating = (int)numRating.Value,
//                        ResidentID = int.Parse(txtResidentID.Text),
//                        FeedbackDate = dateFeedback.Value
//                    };

//                    DialogResult result = MessageBox.Show(
//                        "Are you sure you want to update this feedback?",
//                        "Confirm Update",
//                        MessageBoxButtons.YesNo,
//                        MessageBoxIcon.Question);

//                    if (result == DialogResult.Yes)
//                    {
//                        UpdateFeedback(feedback);
//                        MessageBox.Show("Feedback updated successfully!", "Success", 
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        LoadFeedbackData(); // Refresh the ListView
//                        ClearForm();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error updating feedback: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateFeedback(Model.Feedback feedback)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_UpdateFeedback", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                    cmd.Parameters.AddWithValue("@FeedbackID", feedback.FeedbackID);
//                    cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
//                    cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
//                    cmd.Parameters.AddWithValue("@ResidentID", feedback.ResidentID);

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
//                    MessageBox.Show("Please select a feedback to delete.", "Validation Error");
//                    return;
//                }

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this feedback?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    DeleteFeedback(int.Parse(txtID.Text));
//                    MessageBox.Show("Feedback deleted successfully!", "Success", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadFeedbackData(); // Refresh the ListView
//                    ClearForm();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error deleting feedback: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DeleteFeedback(int feedbackId)
//        {
//            using (SqlConnection conn = DbHelper.GetConnection())
//            {
//                using (SqlCommand cmd = new SqlCommand("sp_DeleteFeedback", conn))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@FeedbackID", feedbackId);

//                    conn.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//} 