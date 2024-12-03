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
            _bs.DataSource = dataGridView1;
            LoadResidentIDs();
            LoadRoomIDs();

            // Wire up all event handlers
            searchbox.TextChanged += searchbox_TextChanged;
            dataGridView1.SelectionChanged += DoClickRecord;

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnRentUpdated;
                update_Click(sender, e);
                Helper.Updated -= DoOnRentUpdated;
            };

            btnClear.Click += clear_Click;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnRentInserted;
                insert_Click(sender, e);
                Helper.Added -= DoOnRentInserted;
            };

            residentid.TextChanged += residentid_TextChanged;
            roomid.TextChanged += roomid_TextChanged;

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnRentDeleted;
                delete_Click(sender, e);
                Helper.Deleted -= DoOnRentDeleted;
            };

            btnClear.Click += DoClickNew;
            searchbox.KeyDown += DoSearch;
        }

        private void LoadResidentIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object resIDObj = dr["ID"];
                    if (resIDObj != DBNull.Value)
                    {
                        string? resID = resIDObj.ToString();
                        residentid.Text = resID;
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
                        roomid.Text = roomID;
                    }
                }
            }
        }

        private void ConfigView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("colRentID", "Rent ID");
            dataGridView1.Columns.Add("colStartDate", "Start Date");
            dataGridView1.Columns.Add("colEndDate", "End Date");
            dataGridView1.Columns.Add("colRentAmount", "Rent Amount");
            dataGridView1.Columns.Add("colRoomID", "Room ID");
            dataGridView1.Columns.Add("colResidentID", "Resident ID");
            dataGridView1.Columns.Add("colRoomNumber", "Room Number");
            dataGridView1.Columns.Add("colResidentName", "Resident Name");

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRents";
                var result = Helper.GetAllEntities<Rent>(Program.Connection, SP_Name);
                dataGridView1.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Rent>(dataGridView1, rent => new object[]
                {
                    rent.ID,
                    rent.Start,
                    rent.End,
                    rent.RentPrice,
                    rent.RoomID,
                    rent.ResID,
                    rent.RoomNum,
                    rent.FirstName
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
            row.CreateCells(dataGridView1,
                rent.ID,
                    rent.Start,
                    rent.End,
                    rent.RentPrice,
                    rent.RoomID,
                    rent.ResID,
                    rent.RoomNum,
                    rent.FirstName);
            row.Tag = rent.ID;
            dataGridView1.Rows.Add(row);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(rentid, false);
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

        private void delete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["colRentID"].Value);

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
                    MessageBox.Show($"Successfully Deleted Rent ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnRentUpdated(object? sender, EntityEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            UpdateRentView();

            if (rowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[rowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1[0, rowIndex];
            }
        }

        private void update_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                object cellValue = dataGridView1.Rows[rowIndex].Cells["colRentID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var rent = GatherRentInput();
                    rent.ID = id;

                    if (ValidateInputs(rent))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(rent, "SP_UpdateRent", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid rent to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a rent record to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnRentInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Rent>(Program.Connection, e.ByteId, "SP_GetRentByID");

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

        private void insert_Click(object? sender, EventArgs e)
        {
            var rent = GatherRentInput();

            if (ValidateInputs(rent))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(rent, "SP_InsertRent", "Insert");
            }
        }

        private bool ValidateInputs(Rent rent)
        {
            if (rent.RentPrice <= 0)
            {
                MessageBox.Show("Rent amount must be greater than zero.", "Validation Error");
                return false;
            }

            if (rent.EndDate < rent.Start)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Validation Error");
                return false;
            }

            if (rent.RoomID <= 0)
            {
                MessageBox.Show("Please select a valid Room ID.", "Validation Error");
                return false;
            }

            if (rent.ResID <= 0)
            {
                MessageBox.Show("Please select a valid Resident ID.", "Validation Error");
                return false;
            }

            return true;
        }

        private void UpdateRentView()
        {
            try
            {
                dataGridView1.Rows.Clear();
                string SP_Name = "SP_GetAllRents";
                var result = Helper.GetAllEntities<Rent>(Program.Connection, SP_Name);

                foreach (var rent in result)
                {
                    AddToView(rent);
                }

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Rents", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Rent GatherRentInput()
        {
            if (!string.IsNullOrWhiteSpace(rentamount.Text) &&
                !string.IsNullOrWhiteSpace(roomid.Text) &&
                !string.IsNullOrWhiteSpace(residentid.Text) &&
                double.TryParse(rentamount.Text, out double rentPrice) &&
                int.TryParse(roomid.Text, out int roomId) &&
                int.TryParse(residentid.Text, out int residentId))
            {
                return new Rent()
                {
                    Start = startdate.Value,
                    End = enddate.Value,
                    RentPrice = rentPrice,  // This now matches with double
                    RoomID = roomId,
                    RoomNum = roomnum.Text.Trim(),
                    ResID = residentId,
                    FirstName = residentname.Text.Trim()
                };
            }
            else
            {
                MessageBox.Show("Please enter valid values for all fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void PopulateFields(Rent? rent)
        {
            if (rent != null)
            {
                rentid.Text = rent.ID.ToString();
                startdate.Value = rent.Start ?? DateTime.Now;
                enddate.Value = rent.End ?? DateTime.Now;
                rentamount.Text = rent.RentPrice.ToString();
                roomid.Text = rent.RoomID.ToString();
                roomnum.Text = rent.RoomNum;
                residentid.Text = rent.ResID.ToString();
                residentname.Text = rent.FirstName;
            }
            else
            {
                rentid.Text = string.Empty;
                startdate.Value = DateTime.Now;
                enddate.Value = DateTime.Now;
                rentamount.Text = string.Empty;
                roomid.Text = string.Empty;
                roomnum.Text = string.Empty;
                residentid.Text = string.Empty;
                residentname.Text = string.Empty;
            }
        }

        private void DoClickRecord(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

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
            ManageControl.EnableControl(rentid, false);
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = searchbox.Text.Trim();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || searchbox.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dataGridView1.Rows.Count;

                    for (int i = startIndex; i < dataGridView1.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dataGridView1.Rows.Count;
                        DataGridViewRow row = dataGridView1.Rows[currentIndex];

                        string? id = row.Cells["colRentID"].Value?.ToString();
                        string? residentName = row.Cells["colResidentName"].Value?.ToString();
                        string? roomNumber = row.Cells["colRoomNumber"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (residentName != null && residentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomNumber != null && roomNumber.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dataGridView1.ClearSelection();
                            row.Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
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

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            lastHighlightedIndex = -1;
            string searchValue = searchbox.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string? id = row.Cells["colRentID"].Value?.ToString()?.ToLower();
                string? residentName = row.Cells["colResidentName"].Value?.ToString()?.ToLower();
                string? roomNumber = row.Cells["colRoomNumber"].Value?.ToString()?.ToLower();

                bool visible = string.IsNullOrEmpty(searchValue) ||
                    (id != null && id.Contains(searchValue)) ||
                    (residentName != null && residentName.Contains(searchValue)) ||
                    (roomNumber != null && roomNumber.Contains(searchValue));

                row.Visible = visible;
            }
        }

        private void residentid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(residentid.Text) && int.TryParse(residentid.Text, out int id))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            residentname.Text = dr[2].ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    residentname.Clear();
                }
            }
            else
            {
                residentname.Clear();
            }
        }

        private void roomid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(roomid.Text) && int.TryParse(roomid.Text, out int id))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            roomnum.Text = dr[1].ToString();
                        }
                    }
                }
                catch (Exception)
                {
                    roomnum.Clear();
                }
            }
            else
            {
                roomnum.Clear();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to clear all fields?",
                    "Confirm Clear",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClearFields();
                    if (dataGridView1.CurrentRow != null)
                    {
                        dataGridView1.ClearSelection();
                    }

                    ManageControl.EnableControl(btnInsert, true);
                    ManageControl.EnableControl(btnUpdate, false);
                    ManageControl.EnableControl(btnDelete, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing fields: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            rentid.Clear();
            rentamount.Clear();
            roomid.Clear();
            residentname.Clear();
            roomnum.Clear();
            residentid.Clear();
            startdate.Value = DateTime.Now;
            enddate.Value = DateTime.Now;
        }
    }
}