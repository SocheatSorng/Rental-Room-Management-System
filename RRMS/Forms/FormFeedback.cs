using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace RRMS.Forms
//{
//    public partial class FormFeedback : Form
//    {
//        public FormFeedback()
//        {
//            InitializeComponent();
//        }
//    }
//}

namespace RRMS.Forms
{
    public partial class FormFeedback : Form
    {
        BindingSource _bs = new();

        public FormFeedback()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SetupListView();
            LoadFeedbackData();

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnFeedbackAdded;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnFeedbackAdded;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnFeedbackUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnFeedbackUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnFeedbackDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnFeedbackDeleted;
            };

            txtResID.Leave += txtResID_Leave;
            dgvFeed.SelectedIndexChanged += dgvFeed_SelectedIndexChanged;
        }

        private void SetupListView()
        {
            dgvFeed.View = View.Details;
            dgvFeed.FullRowSelect = true;
            dgvFeed.GridLines = true;

            // Add columns
            dgvFeed.Columns.Add("ID", 50);
            dgvFeed.Columns.Add("Date", 100);
            dgvFeed.Columns.Add("Comments", 150);
            dgvFeed.Columns.Add("Rating", 50);
            dgvFeed.Columns.Add("Resident ID", 80);
            dgvFeed.Columns.Add("Resident Name", 120);
        }

        private void LoadFeedbackData()
        {
            try
            {
                dgvFeed.Items.Clear();
                var feedbackList = Helper.GetAllFeedback(Program.Connection); // Assuming you have a method to get all feedback
                foreach (var feedback in feedbackList)
                {
                    ListViewItem item = new ListViewItem(feedback.FeedbackID.ToString());
                    item.SubItems.Add(feedback.FeedbackDate.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(feedback.Comments);
                    item.SubItems.Add(feedback.Rating.ToString());
                    item.SubItems.Add(feedback.ResidentID.ToString());

                    // Get resident name using another query
                    var residentName = Helper.GetResidentNameById(Program.Connection, feedback.ResidentID); // Assuming you have this method
                    item.SubItems.Add(residentName ?? "Unknown");

                    dgvFeed.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading feedback data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtResID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResID.Text) && int.TryParse(txtResID.Text, out int residentId))
            {
                FillResidentName(residentId);
            }
        }

        private void FillResidentName(int residentId)
        {
            try
            {
                var residentName = Helper.GetResidentNameById(Program.Connection, residentId); // Assuming you have this method
                if (residentName != null)
                {
                    txtResName.Text = residentName;
                }
                else
                {
                    MessageBox.Show("Resident ID not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoClickInsert(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    var feedback = new Model.Feedback
                    {
                        Comments = txtFeedCom.Text,
                        Rating = (int)numRating.Value,
                        ResidentID = int.Parse(txtResID.Text)
                    };

                    int newFeedbackId = Helper.AddFeedback(Program.Connection, feedback); // Assuming you have this method
                    txtFeedID.Text = newFeedbackId.ToString();
                    MessageBox.Show("Feedback inserted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFeedbackData(); // Refresh the ListView
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting feedback: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFeedCom.Text))
            {
                MessageBox.Show("Please enter comments.", "Validation Error");
                return false;
            }

            if (!int.TryParse(txtResID.Text, out _))
            {
                MessageBox.Show("Please enter a valid Resident ID.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResName.Text))
            {
                MessageBox.Show("Invalid Resident ID. Please enter a valid Resident ID.", "Validation Error");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtFeedID.Clear();
            txtFeedCom.Clear();
            numRating.Value = 1;
            dateFeedback.Value = DateTime.Now;
            txtResID.Clear();
            txtResName.Clear();
        }

        private void dgvFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvFeed.SelectedItems.Count > 0)
            {
                ListViewItem item = dgvFeed.SelectedItems[0];

                // Fill the form fields with the selected item's data
                txtFeedID.Text = item.SubItems[0].Text;
                dateFeedback.Value = DateTime.Parse(item.SubItems[1].Text);
                txtFeedCom.Text = item.SubItems[2].Text;
                numRating.Value = decimal.Parse(item.SubItems[3].Text);
                txtResID.Text = item.SubItems[4].Text;
                txtResName.Text = item.SubItems[5].Text;
            }
        }

        private void DoClickUpdate(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFeedID.Text))
                {
                    MessageBox.Show("Please select a feedback to update.", "Validation Error");
                    return;
                }

                if (ValidateInputs())
                {
                    var feedback = new Model.Feedback
                    {
                        FeedbackID = int.Parse(txtFeedID.Text),
                        Comments = txtFeedCom.Text,
                        Rating = (int)numRating.Value,
                        ResidentID = int.Parse(txtResID.Text),
                        FeedbackDate = dateFeedback.Value
                    };

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to update this feedback?",
                        "Confirm Update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Helper.UpdateFeedback(Program.Connection, feedback); // Assuming you have this method
                        MessageBox.Show("Feedback updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFeedbackData(); // Refresh the ListView
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating feedback: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoClickDelete(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFeedID.Text))
                {
                    MessageBox.Show("Please select a feedback to delete.", "Validation Error");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this feedback?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Helper.DeleteFeedback(Program.Connection, int.Parse(txtFeedID.Text)); // Assuming you have this method
                    MessageBox.Show("Feedback deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFeedbackData(); // Refresh the ListView
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting feedback: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnFeedbackAdded(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var feedback = Helper.GetFeedbackById(Program.Connection, e.ByteId); // Assuming you have this method
                    if (feedback != null)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            AddToView(feedback);
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            ClearForm();
        }

        private void DoOnFeedbackUpdated(object? sender, EntityEventArgs e)
        {
            int rowIndex = dgvFeed.SelectedIndices.Count > 0 ? dgvFeed.SelectedIndices[0] : -1;

            if (rowIndex >= 0)
            {
                LoadFeedbackData(); // Refresh the ListView
                dgvFeed.Items[rowIndex].Selected = true;
                dgvFeed.EnsureVisible(rowIndex);
            }
        }

        private void DoOnFeedbackDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        LoadFeedbackData(); // Refresh the ListView
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void AddToView(Model.Feedback feedback)
        {
            ListViewItem item = new ListViewItem(feedback.FeedbackID.ToString());
            item.SubItems.Add(feedback.FeedbackDate.ToString("yyyy-MM-dd"));
            item.SubItems.Add(feedback.Comments);
            item.SubItems.Add(feedback.Rating.ToString());
            item.SubItems.Add(feedback.ResidentID.ToString());

            var residentName = Helper.GetResidentNameById(Program.Connection, feedback.ResidentID); // Assuming you have this method
            item.SubItems.Add(residentName ?? "Unknown");

            dgvFeed.Items.Add(item);
        }
    }
}