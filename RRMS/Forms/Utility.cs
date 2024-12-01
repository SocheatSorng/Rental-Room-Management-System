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
    public partial class Utility : Form
    {
        private int lastHighlightedIndex = -1;

        public Utility()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Setup ListView
            ConfigView();
            SetupUtilityTypes();

            // Make ID textbox read-only
            txtID.ReadOnly = true;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnUtilityInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnUtilityInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnUtilityUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnUtilityUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnUtilityDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnUtilityDeleted;
            };

            btnClear.Click += DoClickNew;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            txtSearch.KeyDown += DoSearch;

            // Load initial data
            LoadUtilityData();
        }

        private void SetupUtilityTypes()
        {
            cboUtilityType.Items.Clear();
            cboUtilityType.Items.AddRange(new string[] { "Electricity", "Water", "Internet", "Other" });
            cboUtilityType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim().ToLower();
                bool found = false;

                for (int i = lastHighlightedIndex + 1; i < listView1.Items.Count; i++)
                {
                    ListViewItem item = listView1.Items[i];
                    if (item.Text.ToLower().Contains(searchValue) ||
                        item.SubItems[1].Text.ToLower().Contains(searchValue))
                    {
                        listView1.SelectedItems.Clear();
                        item.Selected = true;
                        item.EnsureVisible();
                        lastHighlightedIndex = i;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    lastHighlightedIndex = -1;
                    MessageBox.Show("No more matching utilities found. Starting over.", "Search Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfigView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Cost", 100);
            listView1.Columns.Add("Usage Date", 100);
            listView1.Columns.Add("Room ID", 80);

            LoadUtilityData();
        }

        private void LoadUtilityData()
        {
            try
            {
                listView1.Items.Clear();
                string SP_Name = "SP_GetAllUtilities";
                var result = Helper.GetAllEntities<Model.Utility>(Program.Connection, SP_Name);

                foreach (var utility in result)
                {
                    AddToView(utility);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading utility data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Model.Utility utility)
        {
            ListViewItem item = new ListViewItem(utility.ID.ToString());
            item.SubItems.Add(utility.Type);
            item.SubItems.Add(utility.Cost.ToString());
            item.SubItems.Add(utility.Start.ToString("yyyy-MM-dd"));
            item.SubItems.Add(utility.RoomID.ToString());
            item.Tag = utility.ID;
            listView1.Items.Add(item);
        }

        private void ListView1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                PopulateFields(item);
                ManageControl.EnableControl(btnInsert, false);
                ManageControl.EnableControl(btnUpdate, true);
                ManageControl.EnableControl(btnDelete, true);
                ManageControl.EnableControl(txtID, false);
            }
        }

        private void PopulateFields(ListViewItem item)
        {
            txtID.Text = item.SubItems[0].Text;
            cboUtilityType.Text = item.SubItems[1].Text;
            txtCost.Text = item.SubItems[2].Text;
            dateUsage.Value = DateTime.Parse(item.SubItems[3].Text);
            txtRoomID.Text = item.SubItems[4].Text;
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            ClearForm();
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtID, false);
        }

        private void DoOnUtilityInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Model.Utility>(
                        Program.Connection, e.ByteId, "SP_GetUtilityByID");

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

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var utility = GatherUtilityInput();

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(utility, "SP_InsertUtility", "Insert");
            }
        }

        private void DoOnUtilityUpdated(object? sender, EntityEventArgs e)
        {
            LoadUtilityData();
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].EnsureVisible();
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var utility = GatherUtilityInput();
                utility.ID = int.Parse(txtID.Text);

                if (ValidateInputs())
                {
                    var entityService = new EntityService();
                    entityService.InsertOrUpdateEntity(utility, "SP_UpdateUtility", "Update");
                }
            }
            else
            {
                MessageBox.Show("Please select a utility to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnUtilityDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    LoadUtilityData();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;

            try
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this utility record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteUtility";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UtilityID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Utility ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUtilityData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Model.Utility GatherUtilityInput()
        {
            return new Model.Utility
            {
                Type = cboUtilityType.Text,
                Cost = decimal.Parse(txtCost.Text),
                Start = dateUsage.Value,
                RoomID = int.Parse(txtRoomID.Text)
            };
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(cboUtilityType.Text))
            {
                MessageBox.Show("Please select utility type.", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(txtCost.Text, out _))
            {
                MessageBox.Show("Please enter a valid cost amount.", "Validation Error");
                return false;
            }

            if (!int.TryParse(txtRoomID.Text, out int roomId))
            {
                MessageBox.Show("Please enter a valid Room ID.", "Validation Error");
                return false;
            }

            using (SqlCommand cmd = new SqlCommand("SP_CheckRoomID", Program.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Room not found.", "Validation Error");
                    return false;
                }
            }

            return true;
        }

        private void ClearForm()
        {
            txtID.Clear();
            cboUtilityType.SelectedIndex = -1;
            txtCost.Clear();
            dateUsage.Value = DateTime.Now;
            txtRoomID.Clear();
        }
    }
}