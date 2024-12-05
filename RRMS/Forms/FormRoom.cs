using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using RRMS;
using RRMS.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RRMS.Forms
{
    public partial class FormRoom : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormRoom()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvRoom;
            LoadResidentIDs();
            LoadRoomTypeIDs();

            cbbResID.SelectedIndexChanged += cbbResidentID_SelectedIndexChanged;
            cbbRoomTypeID.SelectedIndexChanged += cbbRoomTypeID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnRoomInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnRoomInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnRoomUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnRoomUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnRoomDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnRoomDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvRoom.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }
        private void LoadResidentIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object resIDObj = dr["ResidentID"];
                    if (resIDObj != DBNull.Value)
                    {
                        string? resID = resIDObj.ToString();
                        cbbResID.Items.Add(resID);
                        cbbResID.DisplayMember = resID;
                        cbbResID.ValueMember = resID;
                    }
                }
            }
        }
        private void cbbResidentID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbResID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentID", cbbResID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string firstName = dr["FirstName"].ToString() ?? string.Empty;
                            string lastName = dr["LastName"].ToString() ?? string.Empty;
                            txtResName.Text = $"{firstName} {lastName}".Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResName.Text = string.Empty;
                }
            }
            else
            {
                txtResName.Text = "";
            }
        }
        private void LoadRoomTypeIDs()
        {
            SqlCommand cmd = new SqlCommand("SP_LoadRoomTypeIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    object roomTypeIDObj = dr["RoomTypeID"];
                    if (roomTypeIDObj != DBNull.Value)
                    {
                        string? roomTypeID = roomTypeIDObj.ToString();
                        cbbRoomTypeID.Items.Add(roomTypeID);
                        cbbRoomTypeID.DisplayMember = roomTypeID;
                        cbbRoomTypeID.ValueMember = roomTypeID;
                    }
                }
            }
        }
        private void cbbRoomTypeID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbRoomTypeID.SelectedItem != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_GetRoomTypeByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomTypeID", cbbRoomTypeID.SelectedItem);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtRoomType.Text = dr["TypeName"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving room type name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResName.Text = string.Empty;
                }
            }
            else
            {
                txtRoomType.Text = "";
            }
        }
        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvRoom.Rows.Count;

                    for (int i = startIndex; i < dgvRoom.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvRoom.Rows.Count;
                        DataGridViewRow row = dgvRoom.Rows[currentIndex];

                        string? id = row.Cells["colRoomID"].Value?.ToString();
                        string? roomNumber = row.Cells["colRoomNum"].Value?.ToString();
                        string? residentName = row.Cells["colResName"].Value?.ToString();
                        string? roomType = row.Cells["colRoomType"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (residentName != null && residentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomNumber != null && roomNumber.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomType != null && roomType.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvRoom.ClearSelection();
                            row.Selected = true;
                            dgvRoom.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching rooms found. Starting over.", "Search Result",
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
            if (dgvRoom.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRoom.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvRoom.Rows[rowIndex];

                object cellValue = row.Cells["colRoomID"].Value;
                int? roomID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (roomID.HasValue)
                {
                    var room = Helper.GetEntityById<Room>(Program.Connection, roomID.Value, "SP_GetRoomByID");
                    if (room != null)
                    {
                        PopulateFields(room);
                    }
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtRoomID, false);
        }
        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtRoomID, false);
        }
        private void DoOnRoomDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    ConfigView();
                });
            });
        }
        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvRoom.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvRoom.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvRoom.Rows[rowIndex].Cells["colRoomID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this room?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRoom";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Room ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                    PopulateFields(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoOnRoomUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvRoom.CurrentCell == null) return;
            int rowIndex = dgvRoom.CurrentCell.RowIndex;

            ConfigView();

            if (rowIndex < dgvRoom.Rows.Count)
            {
                dgvRoom.Rows[rowIndex].Selected = true;
                dgvRoom.CurrentCell = dgvRoom[0, rowIndex];
            }
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRoom.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRoom.SelectedCells[0].RowIndex;
                object cellValue = dgvRoom.Rows[rowIndex].Cells["colRoomID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var room = GatherRoomInput();
                    room.ID = id;

                    if (TryParseInputs(room.ResidentID, room.RoomTypeID))
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(room, "SP_UpdateRoom", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid room to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnRoomInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Room>(Program.Connection, e.ByteId, "SP_GetRoomByID");
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
            var room = GatherRoomInput();
            if (TryParseInputs(room.ResidentID, room.RoomTypeID))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(room, "SP_InsertRoom", "Insert");
                UpdateRoomView();
            }
        }
        private Room GatherRoomInput()
        {
            if (cbbResID.SelectedItem != null &&
                cbbRoomTypeID.SelectedItem != null &&
                int.TryParse(cbbResID.SelectedItem.ToString(), out int resID) &&
                int.TryParse(cbbRoomTypeID.SelectedItem.ToString(), out int roomTypeID))
            {
                return new Room
                {
                    RoomNumber = txtRoomNumber.Text.Trim(),
                    ResidentID = resID,
                    RoomTypeID = roomTypeID,
                    Status = chkStatus.Checked
                };
            }
            return null;
        }

        private void PopulateFields(Room? room)
        {
            if (room != null)
            {
                txtRoomID.Text = room.ID.ToString();
                txtRoomNumber.Text = room.Description;
                cbbResID.Text = room.ResidentID.ToString();
                cbbRoomTypeID.Text = room.RoomTypeID.ToString();
                chkStatus.Checked = room.Status;
            }
            else
            {
                txtRoomID.Text = string.Empty;
                txtRoomNumber.Text = string.Empty;
                cbbResID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
                cbbRoomTypeID.SelectedIndex = -1;
                txtRoomType.Text = string.Empty;
                chkStatus.Checked = false;
            }
        }
        private bool TryParseInputs(int? residentID, int roomTypeID)
        {
            if(residentID < 0)
            {
                MessageBox.Show("Please select a resident ID.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(roomTypeID < 0)
            {
                MessageBox.Show("Please select a roomtype ID.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room Number must not be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResName.Text))
            {
                MessageBox.Show("Room Type must not be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void UpdateRoomView()
        {
            try
            {
                dgvRoom.Rows.Clear();
                string SP_Name = "SP_GetAllRooms";
                var result = Helper.GetAllEntities<Room>(Program.Connection, SP_Name);

                foreach (var room in result)
                {
                    AddToView(room);
                }
                dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRoom.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Room ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigView()
        {
            dgvRoom.Columns.Clear();
            dgvRoom.Columns.Add("colRoomID", "Room ID");
            dgvRoom.Columns.Add("colRoomNum", "Room Number");
            dgvRoom.Columns.Add("colStatus", "Status");

            dgvRoom.Columns[0].Width = 80;
            dgvRoom.Columns[1].Width = 120;
            dgvRoom.Columns[2].Width = 100;

            dgvRoom.DefaultCellStyle.BackColor = Color.White;
            dgvRoom.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRooms";
                var result = Helper.GetAllEntities<Room>(Program.Connection, "SP_GetAllRooms");
                dgvRoom.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Room>(dgvRoom, room => new object[]
                {
                    room.ID,
                    room.Description,
                    room.Status ? "Occupied" : "Available"
                });
                foreach (var room in result)
                {
                    entityViewAdder.AddToView(room);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving rooms", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Room room)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvRoom, room.RoomID, room.RoomNumber,
                room.Status ? "Occupied" : "Available");
            row.Tag = room.RoomID;
            dgvRoom.Rows.Add(row);
        }

    }
}