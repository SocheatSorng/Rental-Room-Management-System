using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RRMS.Forms
{
    public partial class FormFeedback : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;
        public FormFeedback()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvFeed;
            LoadResidentIDs();
            cbbResID.SelectedIndexChanged += cbbResID_SelectedIndexChanged;
            

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnFeedbackInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnFeedbackInserted;
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

            btnNew.Click += DoClickNew;
            dgvFeed.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }
        private void cbbResID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cbbResID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResID", cbbResID.SelectedItem);
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtResName.Text = dr[2].ToString();
                    }
                }
            }
            else
            {
                txtResName.Text = "";
            }
        }
        private void LoadResidentIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using(SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object resIDObj = dr["ID"];
                    if(resIDObj != DBNull.Value)
                    {
                        string? resID = resIDObj.ToString();
                        cbbResID.Items.Add(resID);
                        cbbResID.DisplayMember = resID;
                        cbbResID.ValueMember = resID;
                    }
                }
            }
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvFeed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvFeed.Rows.Count;

                    for (int i = startIndex; i < dgvFeed.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvFeed.Rows.Count;
                        DataGridViewRow row = dgvFeed.Rows[currentIndex];

                        string? id = row.Cells["colFeedID"].Value?.ToString();
                        string? contentName = row.Cells["colFeedCon"].Value?.ToString();
                        //string? residentName = row.Cells["colResName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (contentName != null && contentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {

                            dgvFeed.ClearSelection();

                            row.Selected = true;
                            dgvFeed.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching feedbacks found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvFeed.SelectedCells.Count > 0)
            {
                int rowIndex = dgvFeed.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvFeed.Rows[rowIndex];

                object cellValue = row.Cells["colFeedID"].Value;
                int? feedbackID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (feedbackID.HasValue)
                {
                    var feedback = Helper.GetEntityById<Feedback>(Program.Connection, feedbackID.Value, "SP_GetFeedbackbyID");
                    if (feedback != null)
                    {
                        PopulateFields(feedback);
                    }
                    else
                    {
                        MessageBox.Show("Feedback not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Feedback ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtFeedID, false);
        }
        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtFeedID, false);
        }
        private void DoOnFeedbackDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateFeedbackView();
                });
            });
        }
        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvFeed.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvFeed.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvFeed.Rows[rowIndex].Cells["colFeedID"].Value);

                using var cmd = Program.Connection.CreateCommand();
                cmd.CommandText = "SP_DeleteFeedback";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeedID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Feedback ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoOnFeedbackUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvFeed.CurrentCell == null) return;
            int rowIndex = dgvFeed.CurrentCell.RowIndex;

            UpdateFeedbackView();

            // Restore selection to the updated row
            if (rowIndex < dgvFeed.Rows.Count)
            {
                dgvFeed.Rows[rowIndex].Selected = true;
                dgvFeed.CurrentCell = dgvFeed[0, rowIndex];
            }
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvFeed.SelectedCells.Count > 0)
            {
                int rowIndex = dgvFeed.SelectedCells[0].RowIndex;
                object cellValue = dgvFeed.Rows[rowIndex].Cells["colFeedID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var feedback = GatherFeedbackInput();
                    feedback.ID = id;

                    if (TryParseInputs(feedback.Type, feedback.Description, feedback.ResID))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(feedback, "SP_UpdateStaff", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid feedback to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a staff to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnFeedbackInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetFeedbackByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Feedback>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvFeed.Invoke((MethodInvoker)delegate
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
        private void DoClickInsert(object? sender, EventArgs e)
        {
            var feedback = GatherFeedbackInput();

            if (TryParseInputs(feedback.Type, feedback.Description, feedback.ResID))
            {
                // Create an instance of EntityService
                var entityService = new EntityService();

                // Call InsertOrUpdateEntity method
                entityService.InsertOrUpdateEntity(feedback, "SP_InsertFeedback", "Insert");
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool TryParseInputs(string type, string desc, int resID)
        {

            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Content must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show("Comment must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (resID < 0)
            {
                MessageBox.Show("Resident ID is not selected", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateFeedbackView()
        {
            try
            {
                dgvFeed.Rows.Clear();
                string SP_Name = "SP_GetAllFeedbacks";

                var result = Helper.GetAllEntities<Feedback>(Program.Connection, SP_Name);

                foreach (var feedback in result)
                {
                    AddToView(feedback);
                }
                dgvFeed.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFeed.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Feedbacks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Feedback GatherFeedbackInput()
        {
            int resID;
            if (cbbResID.SelectedItem != null && int.TryParse(cbbResID.SelectedItem.ToString(), out resID))
            {
                return new Feedback()
                {
                    Date = dtpFeedDate.Value,
                    Type = txtFeedCon.Text.Trim(),
                    Description = txtFeedCom.Text.Trim(),
                    ResID = resID,
                    ResName = txtResName.Text.Trim(),
                };
            }
            
            else
            {
                MessageBox.Show("Please select a valid Resident ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        private void PopulateFields(Feedback? feedback)
        {
            if(feedback != null)
            {
                txtFeedID.Text = feedback.ID.ToString();
                dtpFeedDate.Value = feedback.Start;
                txtFeedCon.Text = feedback.Type;
                txtFeedCom.Text = feedback.Description;
                cbbResID.Text = feedback.ResID.ToString();
                txtResName.Text = feedback.ResName;
            }
            else
            {
                txtFeedID.Text = string.Empty;
                dtpFeedDate.Value = DateTime.Now;
                txtFeedCon.Text = string.Empty;
                txtFeedCom.Text = string.Empty;
                cbbResID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
            }
        }
        private void ConfigView()
        {
            dgvFeed.Columns.Clear();
            dgvFeed.Columns.Add("colFeedID", "Feedback ID");
            dgvFeed.Columns.Add("colFeedCon", "Content");
            //dgvFeed.Columns.Add("colResName", "Resident Name");
            dgvFeed.Columns[0].Width = 100;
            dgvFeed.Columns[1].Width = 200;
            dgvFeed.DefaultCellStyle.BackColor = Color.White;
            dgvFeed.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllFeedbacks";
                var result = Helper.GetAllEntities<Feedback>(Program.Connection, SP_Name);
                dgvFeed.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Feedback>(dgvFeed, feedback => new object[] { feedback.ID, feedback.Type});
                foreach (var feedback in result)
                {
                    entityViewAdder.AddToView(feedback);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving feedbacks", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Feedback feedback)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvFeed, feedback.ID, feedback.Type);
            row.Tag = feedback.ID;
            dgvFeed.Rows.Add(row);
        }
    }
}