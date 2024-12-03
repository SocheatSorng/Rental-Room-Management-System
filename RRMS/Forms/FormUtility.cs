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
    public partial class FormUtility : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;
        public FormUtility()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvUti;
            LoadRoomIDs();
            cbbRoomID.SelectedIndexChanged += cbbRoomID_SelectedIndexChanged;

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

            btnNew.Click += DoClickNew;
            dgvUti.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;

            SetupUtilityTypes();
        }
        

        private void SetupUtilityTypes()
        {
            cbbUtiType.Items.Clear();
            cbbUtiType.Items.AddRange(new string[] { "Electricity", "Water", "Internet", "Other" });
            cbbUtiType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void cbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbRoomID.SelectedItem != null)
            {
                SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomID", cbbRoomID.SelectedItem);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtRoomNum.Text = dr[1].ToString();
                    }
                }
            }
        }
        private void LoadRoomIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadRoomIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object roomIDObj = dr["ID"];
                    if (roomIDObj != DBNull.Value)
                    {
                        string? roomID = roomIDObj.ToString();
                        cbbRoomID.Items.Add(roomID);
                        cbbRoomID.DisplayMember = roomID;
                        cbbRoomID.ValueMember = roomID;
                    }
                }
            }
        }
        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim().ToLower();
                dgvUti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvUti.Rows.Count;

                    for (int i = startIndex; i < dgvUti.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvUti.Rows.Count;
                        DataGridViewRow row = dgvUti.Rows[currentIndex];

                        string? id = row.Cells["colUtiID"].Value?.ToString();
                        string? contentName = row.Cells["colUtiType"].Value?.ToString();
                        //string? residentName = row.Cells["colResName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (contentName != null && contentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {

                            dgvUti.ClearSelection();

                            row.Selected = true;
                            dgvUti.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching utilities found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvUti.SelectedCells.Count > 0)
            {
                int rowIndex = dgvUti.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvUti.Rows[rowIndex];

                object cellValue = row.Cells["colUtiID"].Value;
                int? utilityID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (utilityID.HasValue)
                {
                    var utility = Helper.GetEntityById<Utility>(Program.Connection, utilityID.Value, "SP_GetUtilitybyID");
                    if (utility != null)
                    {
                        PopulateFields(utility);
                    }
                    else
                    {
                        MessageBox.Show("Utility not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Utility ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtUtiID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtUtiID, false);
        }
        private void DoOnUtilityDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateUtilityView();
                });
            });
        }
        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvUti.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvUti.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvUti.Rows[rowIndex].Cells["colUtiID"].Value);

                using var cmd = Program.Connection.CreateCommand();
                cmd.CommandText = "SP_DeleteUtility";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UtilityID", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Successfully Deleted Utility ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfigView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoOnUtilityUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvUti.CurrentCell == null) return;
            int rowIndex = dgvUti.CurrentCell.RowIndex;

            UpdateUtilityView();

            // Restore selection to the updated row
            if (rowIndex < dgvUti.Rows.Count)
            {
                dgvUti.Rows[rowIndex].Selected = true;
                dgvUti.CurrentCell = dgvUti[0, rowIndex];
            }
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvUti.SelectedCells.Count > 0)
            {
                int rowIndex = dgvUti.SelectedCells[0].RowIndex;
                object cellValue = dgvUti.Rows[rowIndex].Cells["colUtiID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var utility = GatherUtilityInput();
                    utility.ID = id;

                    if (TryParseInputs(utility.CostPrice))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(utility, "SP_UpdateUtility", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid utility to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a utiltiy to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnUtilityInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetUtilityByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Utility>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvUti.Invoke((MethodInvoker)delegate
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

            if (TryParseInputs(utility.CostPrice))
            {
                // Create an instance of EntityService
                var entityService = new EntityService();

                // Call InsertOrUpdateEntity method
                entityService.InsertOrUpdateEntity(utility, "SP_InsertUtility", "Insert");
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool TryParseInputs(double cost)
        {

            if (cost<0)
            {
                MessageBox.Show("Cost must be a positive number.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateUtilityView()
        {
            try
            {
                dgvUti.Rows.Clear();
                string SP_Name = "SP_GetAllUtilitys";

                var result = Helper.GetAllEntities<Utility>(Program.Connection, SP_Name);

                foreach (var utility in result)
                {
                    AddToView(utility);
                }
                dgvUti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUti.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Utilities", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Utility GatherUtilityInput()
        {
            int roomID;
            if (cbbUtiType.SelectedItem != null && int.TryParse(cbbUtiType.SelectedItem.ToString(), out roomID))
            {
                return new Utility()
                {
                    Type = cbbUtiType.SelectedItem.ToString(),
                    CostPrice = double.Parse(txtUtiCost.Text),
                    Start = dtpUtiUD.Value,
                    RoomID = roomID,
                };
            }

            else
            {
                MessageBox.Show("Please select a valid Utility ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void PopulateFields(Utility? utility)
        {
            if (utility != null)
            {
                txtUtiID.Text = utility.ID.ToString();
                txtUtiCost.Text = utility.CostPrice.ToString();
                dtpUtiUD.Value = utility.Start ?? DateTime.Now;
                cbbRoomID.Text = utility.RoomID.ToString();
            }
            else
            {
                txtUtiID.Text = string.Empty;
                txtUtiCost.Text = string.Empty;
                dtpUtiUD.Value = DateTime.Now;
                cbbRoomID.SelectedIndex = -1;
            }
        }
        private void ConfigView()
        {
            dgvUti.Columns.Clear();
            dgvUti.Columns.Add("colUtiID", "Utility ID");
            dgvUti.Columns.Add("colUtiType", "Type");
            dgvUti.Columns[0].Width = 100;
            dgvUti.Columns[1].Width = 200;
            dgvUti.DefaultCellStyle.BackColor = Color.White;
            dgvUti.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllUtilitys";
                var result = Helper.GetAllEntities<Utility>(Program.Connection, SP_Name);
                dgvUti.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Utility>(dgvUti, utility => new object[] { utility.ID, utility.Type });
                foreach (var utility in result)
                {
                    entityViewAdder.AddToView(utility);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving utilitys", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddToView(Utility utility)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvUti, utility.ID, utility.Type);
            row.Tag = utility.ID;
            dgvUti.Rows.Add(row);
        }
        //private void LoadUtilityData()
        //{
        //    try
        //    {
        //        listView1.Items.Clear();
        //        string SP_Name = "SP_GetAllUtilitys";
        //        var result = Helper.GetAllEntities<Model.Utility>(Program.Connection, SP_Name);

        //        foreach (var utility in result)
        //        {
        //            AddToView(utility);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading utility data: {ex.Message}", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void AddToView(Model.Utility utility)
        //{
        //    ListViewItem item = new ListViewItem(utility.ID.ToString());
        //    item.SubItems.Add(utility.Type);
        //    item.SubItems.Add(utility.Cost.ToString());
        //    item.SubItems.Add(utility.Start.ToString("yyyy-MM-dd"));
        //    item.SubItems.Add(utility.RoomID.ToString());
        //    item.Tag = utility.ID;
        //    listView1.Items.Add(item);
        //}

        //private void ListView1_SelectedIndexChanged(object? sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        ListViewItem item = listView1.SelectedItems[0];
        //        PopulateFields(item);
        //        ManageControl.EnableControl(btnInsert, false);
        //        ManageControl.EnableControl(btnUpdate, true);
        //        ManageControl.EnableControl(btnDelete, true);
        //        ManageControl.EnableControl(txtUtiID, false);
        //    }
        //}

        //private void PopulateFields(ListViewItem item)
        //{
        //    txtUtiID.Text = item.SubItems[0].Text;
        //    cbbUtiType.Text = item.SubItems[1].Text;
        //    txtUtiCost.Text = item.SubItems[2].Text;
        //    dtpUtiUD.Value = DateTime.Parse(item.SubItems[3].Text);
        //    txtRoomID.Text = item.SubItems[4].Text;
        //}

        //private void DoClickNew(object? sender, EventArgs e)
        //{
        //    ClearForm();
        //    ManageControl.EnableControl(btnInsert, true);
        //    ManageControl.EnableControl(btnUpdate, false);
        //    ManageControl.EnableControl(btnDelete, false);
        //    ManageControl.EnableControl(txtUtiID, false);
        //}

        //private void DoOnUtilityInserted(object? sender, EntityEventArgs e)
        //{
        //    if (e.ByteId == 0) return;
        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            var result = Helper.GetEntityById<Model.Utility>(
        //                Program.Connection, e.ByteId, "SP_GetUtilityByID");

        //            if (result != null)
        //            {
        //                Invoke((MethodInvoker)delegate
        //                {
        //                    AddToView(result);
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    });

        //    DoClickNew(sender, e);
        //}

        //private void DoClickInsert(object? sender, EventArgs e)
        //{
        //    var utility = GatherUtilityInput();

        //    if (ValidateInputs())
        //    {
        //        var entityService = new EntityService();
        //        entityService.InsertOrUpdateEntity(utility, "SP_InsertUtility", "Insert");
        //    }
        //}

        //private void DoOnUtilityUpdated(object? sender, EntityEventArgs e)
        //{
        //    LoadUtilityData();
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        listView1.SelectedItems[0].EnsureVisible();
        //    }
        //}

        //private void DoClickUpdate(object? sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        var utility = GatherUtilityInput();
        //        utility.ID = int.Parse(txtUtiID.Text);

        //        if (ValidateInputs())
        //        {
        //            var entityService = new EntityService();
        //            entityService.InsertOrUpdateEntity(utility, "SP_UpdateUtility", "Update");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a utility to update.", "Selection Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void DoOnUtilityDeleted(object? sender, EntityEventArgs e)
        //{
        //    if (e.ByteId == 0) return;
        //    Task.Run(() =>
        //    {
        //        Invoke((MethodInvoker)delegate
        //        {
        //            LoadUtilityData();
        //        });
        //    });
        //}

        //private void DoClickDelete(object? sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count <= 0) return;

        //    try
        //    {
        //        int id = int.Parse(listView1.SelectedItems[0].Text);

        //        DialogResult result = MessageBox.Show(
        //            "Are you sure you want to delete this utility record?",
        //            "Confirm Delete",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Warning);

        //        if (result == DialogResult.Yes)
        //        {
        //            using var cmd = Program.Connection.CreateCommand();
        //            cmd.CommandText = "SP_DeleteUtility";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@UtilityID", id);

        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show($"Successfully Deleted Utility ID > {id}", "Deleting",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadUtilityData();
        //            ClearForm();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}", "Deleting",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private Model.Utility GatherUtilityInput()
        //{
        //    return new Model.Utility
        //    {
        //        Type = cbbUtiType.Text,
        //        Cost = decimal.Parse(txtUtiCost.Text),
        //        Start = dtpUtiUD.Value,
        //        RoomID = int.Parse(txtRoomID.Text)
        //    };
        //}

        //private bool ValidateInputs()
        //{
        //    if (string.IsNullOrWhiteSpace(cbbUtiType.Text))
        //    {
        //        MessageBox.Show("Please select utility type.", "Validation Error");
        //        return false;
        //    }

        //    if (!decimal.TryParse(txtUtiCost.Text, out _))
        //    {
        //        MessageBox.Show("Please enter a valid cost amount.", "Validation Error");
        //        return false;
        //    }

        //    if (!int.TryParse(txtRoomID.Text, out int roomId))
        //    {
        //        MessageBox.Show("Please enter a valid Room ID.", "Validation Error");
        //        return false;
        //    }
        //    return true;
        //}

        //private void ClearForm()
        //{
        //    txtUtiID.Clear();
        //    cbbUtiType.SelectedIndex = -1;
        //    txtUtiCost.Clear();
        //    dtpUtiUD.Value = DateTime.Now;
        //    txtRoomID.Clear();
        //}
    }
}