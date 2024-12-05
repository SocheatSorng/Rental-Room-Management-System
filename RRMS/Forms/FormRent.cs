using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRMS.Forms
{
    public partial class FormRent : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormRent()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvRent;
            LoadRoomIDs();
            cbbRoomID.SelectedIndexChanged += cbbRoomID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnRentInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnRentInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnRentUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnRentUpdated;
            };
            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnRentDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnRentDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvRent.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }
        private void LoadRoomIDs()
        {

            SqlCommand cmd = new SqlCommand("SP_LoadRoomIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object roomIDObj = dr["RoomID"];
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
        private void cbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbRoomID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", cbbRoomID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtRoomNumber.Text = dr["RoomNumber"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving room number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRoomNumber.Text = string.Empty;
                }
            }
            else
            {
                txtRoomNumber.Text = "";
            }
        }
        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvRent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvRent.Rows.Count;

                    for (int i = startIndex; i < dgvRent.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvRent.Rows.Count;
                        DataGridViewRow row = dgvRent.Rows[currentIndex];

                        string? id = row.Cells["colRentID"].Value?.ToString();
                        string? roomNumber = row.Cells["colRoomNumber"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomNumber != null && roomNumber.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvRent.ClearSelection();
                            row.Selected = true;
                            dgvRent.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching records found. Starting over.", "Search Result",
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
            if (dgvRent.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRent.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvRent.Rows[rowIndex];

                object cellValue = row.Cells["colRentID"].Value;
                int? rentID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (rentID.HasValue)
                {
                    var rent = Helper.GetEntityById<Rent>(Program.Connection, rentID.Value, "SP_GetRentByID");
                    if (rent != null)
                    {
                        PopulateFields(rent);
                    }
                    else
                    {
                        MessageBox.Show("Rent record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Rent ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtRentID, false);
        }
        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtRentID, false);
        }
        private void DoOnRentDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateRentView();
                });
            });
        }
        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvRent.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dgvRent.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvRent.Rows[rowIndex].Cells["colRentID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this rent record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRent";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RentID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Rent ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoOnRentUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvRent.CurrentCell == null) return;
            int rowIndex = dgvRent.CurrentCell.RowIndex;

            ConfigView();

            if (rowIndex < dgvRent.Rows.Count)
            {
                dgvRent.Rows[rowIndex].Selected = true;
                dgvRent.CurrentCell = dgvRent[0, rowIndex];
            }
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRent.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRent.SelectedCells[0].RowIndex;
                object cellValue = dgvRent.Rows[rowIndex].Cells["colRentID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var rent = GatherRentInput();
                    rent.ID = id;

                    if (TryParseInputs(rent.RentPrice, rent.RoomID))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(rent, "SP_UpdateRent", "Update");
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid rent to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a rent to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnRentInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetRoomByID";
            if (e.ByteId == 0) return;

            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Rent>(Program.Connection, e.ByteId, SP_Name);

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
            var rent = GatherRentInput();

            if (TryParseInputs(rent.RentPrice, rent.RoomID))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(rent, "SP_InsertRent", "Insert");
                UpdateRentView();
            }
            else
            {
                MessageBox.Show("Invalid ipnut. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool TryParseInputs(double amount, int roomID)
        {
            if (amount < 0)
            {
                MessageBox.Show("Rent Amount must be an integer.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(roomID < 0)
            {
                MessageBox.Show("Room ID is not selected.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateRentView()
        {
            try
            {
                dgvRent.Rows.Clear();
                string SP_Name = "SP_GetAllRents";
                var result = Helper.GetAllEntities<Rent>(Program.Connection, SP_Name);

                foreach (var rent in result)
                {
                    AddToView(rent);
                }

                dgvRent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRent.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Rents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Rent GatherRentInput()
        {
            double amount;
            double.TryParse(txtRentAmount.Text.Trim(), out amount);
            int roomID;
            if (cbbRoomID.SelectedIndex != null && int.TryParse(cbbRoomID.SelectedItem.ToString(), out roomID))
            {
                return new Rent()
                {
                    Start = dtpRentSD.Value,
                    End = dtpRentED.Value,
                    RentPrice = amount,
                    RoomID = roomID
                };
            }
            else
            {
                MessageBox.Show("Please select a valid Room ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void PopulateFields(Rent? rent)
        {
            if (rent != null)
            {
                txtRentID.Text = rent.ID.ToString();
                dtpRentSD.Value = rent.Start ?? DateTime.Now;
                dtpRentED.Value = rent.End ?? DateTime.Now;
                txtRentAmount.Text = rent.RentPrice.ToString();
            }
            else
            {
                txtRentID.Text = string.Empty;
                dtpRentSD.Value = DateTime.Now;
                dtpRentED.Value = DateTime.Now;
                txtRentAmount.Text = string.Empty;
                txtRoomNumber.Text = string.Empty;
            }
        }
        private void ConfigView()
        {
            dgvRent.Columns.Clear();
            dgvRent.Columns.Add("colRentID", "Rent ID");
            dgvRent.Columns.Add("colStartDate", "Start Date");
            dgvRent.Columns.Add("colEndDate", "End Date");
            dgvRent.Columns.Add("colRentAmount", "Rent Amount");
            //dgvRent.Columns.Add("colRoomNumber", "Room Number");

            dgvRent.Columns[0].Width = 50;
            dgvRent.Columns[1].Width = 100;
            dgvRent.Columns[2].Width = 100;
            dgvRent.Columns[3]. Width = 100;
            //dgvRent.Columns[4].Width = 100;

            dgvRent.DefaultCellStyle.BackColor = Color.White;
            dgvRent.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRents";
                var result = Helper.GetAllEntities<Rent>(Program.Connection, SP_Name);
                dgvRent.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Rent>(dgvRent, rent => new object[]
                {
                    rent.ID, rent.Start, rent.End, rent.RentPrice
                });

                foreach (var rent in result)
                {
                    entityViewAdder.AddToView(rent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving rents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Rent rent)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvRent,rent.ID, rent.Start, rent.End, rent.RentPrice);
            row.Tag = rent.ID;
            dgvRent.Rows.Add(row);
        }            
    }
}