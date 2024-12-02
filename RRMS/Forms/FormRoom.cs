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
        public FormRoom()
        {
            InitializeComponent();
        }

        private void txtRoomNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

//namespace RRMS.Forms
//{
//    public partial class FormRoom : Form
//    {
//        private int lastHighlightedIndex = -1;

//        public FormRoom()
//        {
//            InitializeComponent();
//            this.FormBorderStyle = FormBorderStyle.FixedSingle;

//            // Initialize controls and view
//            ConfigView();
//            LoadResidentIDs();

//            // Make ID textbox and resident name read-only
//            txtRoomID.ReadOnly = true;
//            txtResName.ReadOnly = true;

//            // Set up event handlers
//            cbbResID.SelectedIndexChanged += cbbResID_SelectedIndexChanged;

//            btnInsert.Click += (sender, e) =>
//            {
//                Helper.Added += DoOnRoomInserted;
//                DoClickInsert(sender, e);
//                Helper.Added -= DoOnRoomInserted;
//            };

//            btnUpdate.Click += (sender, e) =>
//            {
//                Helper.Updated += DoOnRoomUpdated;
//                DoClickUpdate(sender, e);
//                Helper.Updated -= DoOnRoomUpdated;
//            };

//            btnDelete.Click += (sender, e) =>
//            {
//                Helper.Deleted += DoOnRoomDeleted;
//                DoClickDelete(sender, e);
//                Helper.Deleted -= DoOnRoomDeleted;
//            };

//            btnNew.Click += DoClickNew;
//            dgvRoom.SelectionChanged += DoClickRecord;
//            txtSearch.KeyDown += DoSearch;
//        }

//        private void cbbResID_SelectedIndexChanged(object? sender, EventArgs e)
//        {
//            if (cbbResID.SelectedItem != null)
//            {
//                SqlCommand cmd = new SqlCommand("SP_GetResidentByID", Program.Connection);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@ResID", cbbResID.SelectedItem);
//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        txtResName.Text = dr[2].ToString();
//                    }
//                }
//            }
//            else
//            {
//                txtResName.Text = "";
//            }
//        }

//        private void LoadResidentIDs()
//        {
//            SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
//            cmd.CommandType = CommandType.StoredProcedure;
//            using (SqlDataReader dr = cmd.ExecuteReader())
//            {
//                while (dr.Read())
//                {
//                    object resIDObj = dr["ID"];
//                    if (resIDObj != DBNull.Value)
//                    {
//                        string? resID = resIDObj.ToString();
//                        cbbResID.Items.Add(resID);
//                        cbbResID.DisplayMember = resID;
//                        cbbResID.ValueMember = resID;
//                    }
//                }
//            }
//        }

//        private void DoSearch(object? sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                string searchValue = txtSearch.Text.Trim();
//                dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

//                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
//                {
//                    lastHighlightedIndex = -1;
//                }

//                try
//                {
//                    bool found = false;
//                    int startIndex = (lastHighlightedIndex + 1) % dgvRoom.Rows.Count;

//                    for (int i = startIndex; i < dgvRoom.Rows.Count + startIndex; i++)
//                    {
//                        int currentIndex = i % dgvRoom.Rows.Count;
//                        DataGridViewRow row = dgvRoom.Rows[currentIndex];

//                        string? id = row.Cells["colRoomID"].Value?.ToString();
//                        string? roomNumber = row.Cells["colRoomNum"].Value?.ToString();
//                        string? roomType = row.Cells["colRoomType"].Value?.ToString();

//                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                            (roomNumber != null && roomNumber.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                            (roomType != null && roomType.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
//                        {
//                            dgvRoom.ClearSelection();
//                            row.Selected = true;
//                            dgvRoom.FirstDisplayedScrollingRowIndex = row.Index;
//                            lastHighlightedIndex = currentIndex;
//                            found = true;
//                            break;
//                        }
//                    }

//                    if (!found)
//                    {
//                        MessageBox.Show("No more matching rooms found. Starting over.", "Search Result",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        lastHighlightedIndex = -1;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message);
//                }
//            }
//        }

//        private void ConfigView()
//        {
//            dgvRoom.Columns.Clear();
//            dgvRoom.Columns.Add("colRoomID", "Room ID");
//            dgvRoom.Columns.Add("colRoomNum", "Room Number");
//            dgvRoom.Columns.Add("colRoomType", "Room Type");

//            dgvRoom.Columns[0].Width = 80;
//            dgvRoom.Columns[1].Width = 120;
//            dgvRoom.Columns[2].Width = 120;

//            dgvRoom.DefaultCellStyle.BackColor = Color.White;
//            dgvRoom.ScrollBars = ScrollBars.Both;

//            try
//            {
//                var result = Helper.GetAllEntities<Room>(Program.Connection, "SP_GetAllRooms");
//                dgvRoom.Rows.Clear();

//                foreach (var room in result)
//                {
//                    AddToView(room);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Retrieving rooms", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void AddToView(Room room)
//        {
//            DataGridViewRow row = new DataGridViewRow();
//            row.CreateCells(dgvRoom, room.RoomID, room.RoomNumber, room.RoomType);
//            row.Tag = room.RoomID;
//            dgvRoom.Rows.Add(row);
//        }

//        private void DoClickRecord(object? sender, EventArgs e)
//        {
//            if (dgvRoom.SelectedCells.Count > 0)
//            {
//                int rowIndex = dgvRoom.SelectedCells[0].RowIndex;
//                DataGridViewRow row = dgvRoom.Rows[rowIndex];

//                object cellValue = row.Cells["colRoomID"].Value;
//                int? roomID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

//                if (roomID.HasValue)
//                {
//                    var room = Helper.GetEntityById<Room>(Program.Connection, roomID.Value, "SP_GetRoomByID");
//                    if (room != null)
//                    {
//                        PopulateFields(room);
//                    }
//                }
//            }

//            ManageControl.EnableControl(btnInsert, false);
//            ManageControl.EnableControl(btnUpdate, true);
//            ManageControl.EnableControl(btnDelete, true);
//            ManageControl.EnableControl(txtRoomID, false);
//        }

//        private void PopulateFields(Room? room)
//        {
//            if (room != null)
//            {
//                txtRoomID.Text = room.ID.ToString();
//                txtRoomNum.Text = room.Description;
//                txtRoomType.Text = room.Tyoe;
//                cbbResID.Text = room.ResID?.ToString() ?? "";
//                // Resident name will be populated by the combo box selected index changed event
//            }
//            else
//            {
//                txtRoomID.Clear();
//                txtRoomNum.Clear();
//                txtRoomType.Clear();
//                cbbResID.SelectedIndex = -1;
//                txtResName.Clear();
//            }
//        }

//        private void DoClickNew(object? sender, EventArgs e)
//        {
//            PopulateFields(null);
//            ManageControl.EnableControl(btnInsert, true);
//            ManageControl.EnableControl(btnUpdate, false);
//            ManageControl.EnableControl(btnDelete, false);
//            ManageControl.EnableControl(txtRoomID, false);
//        }

//        private Room? GatherRoomInput()
//        {
//            int? resID = null;
//            if (cbbResID.SelectedItem != null && int.TryParse(cbbResID.SelectedItem.ToString(), out int parsedResID))
//            {
//                resID = parsedResID;
//            }

//            return new Room
//            {
//                RoomNumber = txtRoomNum.Text.Trim(),
//                RoomType = txtRoomType.Text.Trim(),
//                ResidentID = resID
//            };
//        }

//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(txtRoomNum.Text))
//            {
//                MessageBox.Show("Room Number must not be empty.", "Validation Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(txtRoomType.Text))
//            {
//                MessageBox.Show("Room Type must not be empty.", "Validation Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }

//            return true;
//        }

//        private void DoClickInsert(object? sender, EventArgs e)
//        {
//            var room = GatherRoomInput();
//            if (room != null && ValidateInputs())
//            {
//                var entityService = new EntityService();
//                entityService.InsertOrUpdateEntity(room, "SP_InsertRoom", "Insert");
//            }
//        }

//        private void DoOnRoomInserted(object? sender, EntityEventArgs e)
//        {
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                try
//                {
//                    var result = Helper.GetEntityById<Room>(Program.Connection, e.ByteId, "SP_GetRoomByID");
//                    if (result != null)
//                    {
//                        Invoke((MethodInvoker)delegate
//                        {
//                            AddToView(result);
//                        });
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message, "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            });

//            DoClickNew(sender, e);
//        }

//        private void DoClickUpdate(object? sender, EventArgs e)
//        {
//            if (dgvRoom.SelectedCells.Count > 0)
//            {
//                var room = GatherRoomInput();
//                if (room != null && ValidateInputs())
//                {
//                    room.RoomID = int.Parse(txtRoomID.Text);
//                    var entityService = new EntityService();
//                    entityService.InsertOrUpdateEntity(room, "SP_UpdateRoom", "Update");
//                }
//            }
//        }

//        private void DoOnRoomUpdated(object? sender, EntityEventArgs e)
//        {
//            if (dgvRoom.CurrentCell == null) return;
//            int rowIndex = dgvRoom.CurrentCell.RowIndex;

//            ConfigView();

//            if (rowIndex < dgvRoom.Rows.Count)
//            {
//                dgvRoom.Rows[rowIndex].Selected = true;
//                dgvRoom.CurrentCell = dgvRoom[0, rowIndex];
//            }
//        }

//        private void DoClickDelete(object? sender, EventArgs e)
//        {
//            if (dgvRoom.SelectedCells.Count <= 0) return;

//            try
//            {
//                int rowIndex = dgvRoom.SelectedCells[0].RowIndex;
//                int id = Convert.ToInt32(dgvRoom.Rows[rowIndex].Cells["colRoomID"].Value);

//                DialogResult result = MessageBox.Show(
//                    "Are you sure you want to delete this room?",
//                    "Confirm Delete",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Warning);

//                if (result == DialogResult.Yes)
//                {
//                    using var cmd = Program.Connection.CreateCommand();
//                    cmd.CommandText = "SP_DeleteRoom";
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@RoomID", id);

//                    cmd.ExecuteNonQuery();
//                    MessageBox.Show($"Successfully Deleted Room ID > {id}", "Deleting",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    ConfigView();
//                    PopulateFields(null);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error: {ex.Message}", "Deleting",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void DoOnRoomDeleted(object? sender, EntityEventArgs e)
//        {
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                Invoke((MethodInvoker)delegate
//                {
//                    ConfigView();
//                });
//            });
//        }
//    }
//}