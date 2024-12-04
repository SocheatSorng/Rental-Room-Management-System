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
    public partial class FormRoomType : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormRoomType()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            ConfigView();
            _bs.DataSource = dgvRType;

            // Setup Event Handlers
            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnRoomTypeInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnRoomTypeInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnRoomTypeUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnRoomTypeUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnRoomTypeDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnRoomTypeDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvRType.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvRType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvRType.Rows.Count;

                    for (int i = startIndex; i < dgvRType.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvRType.Rows.Count;
                        DataGridViewRow row = dgvRType.Rows[currentIndex];

                        string? id = row.Cells["colRTypeID"].Value?.ToString();
                        string? roomTypeName = row.Cells["colRTName"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomTypeName != null && roomTypeName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {

                            dgvRType.ClearSelection();

                            row.Selected = true;
                            dgvRType.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching room types found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvRType.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRType.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvRType.Rows[rowIndex];

                object cellValue = row.Cells["colRTypeID"].Value;
                int? roomTypeID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (roomTypeID.HasValue)
                {
                    // Use the generic GetEntityById method to retrieve the Resident
                    var roomType = Helper.GetEntityById<RoomType>(Program.Connection, roomTypeID.Value, "SP_GetRoomTypeByID");
                    if (roomType != null)
                    {
                        PopulateFields(roomType);
                    }
                    else
                    {
                        MessageBox.Show("Room Type not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Room Type ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtRTypeID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtRTypeID, false);
        }
        private void DoOnRoomTypeDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateRoomTypeView();
                    MessageBox.Show("Room Type deleted successfully!", "Delete Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }
        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvRType.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvRType.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvRType.Rows[rowIndex].Cells["colRTypeID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this room type?\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRoomType";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomTypeID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Room Type ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoOnRoomTypeUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvRType.CurrentCell == null) return;
            int rowIndex = dgvRType.CurrentCell.RowIndex;

            UpdateRoomTypeView();

            if (rowIndex < dgvRType.Rows.Count)
            {
                dgvRType.Rows[rowIndex].Selected = true;
                dgvRType.CurrentCell = dgvRType[0, rowIndex];
            }

            // Show success message
            MessageBox.Show("Room Type updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRType.SelectedCells.Count > 0)
            {
                int rowIndex = dgvRType.SelectedCells[0].RowIndex;
                object cellValue = dgvRType.Rows[rowIndex].Cells["colRTypeID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var roomType = GatherRoomTypeInput();
                    roomType.ID = id;

                    if (TryParseInputs(roomType.Type, roomType.CostPrice, roomType.RoomTypeCapacity))
                    {
                        // Show confirmation dialog
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to update this room type?",
                            "Confirm Update",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(roomType, "SP_UpdateRoomType", "Update");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please check your entries.", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid room type to update.", "Selection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a room type to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DoOnRoomTypeInserted(object? sender, EntityEventArgs e)
        {
            string SP_Name = "SP_GetRoomTypeByID";
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<RoomType>(Program.Connection, e.ByteId, SP_Name);

                    if (result != null)
                    {
                        dgvRType.Invoke((MethodInvoker)delegate
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
            var roomType = GatherRoomTypeInput();

            if (TryParseInputs(roomType.Type, roomType.CostPrice, roomType.RoomTypeCapacity))
            {
                // Create an instance of EntityService
                var entityService = new EntityService();

                // Call InsertOrUpdateEntity method
                entityService.InsertOrUpdateEntity(roomType, "SP_InsertRoomType", "Insert");
            }
            else
            {
                MessageBox.Show("Invalid input. Please check your entries.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool TryParseInputs(string roomTypeName, double roomTypePrice, int roomTypeCapacity)
        {
            if (string.IsNullOrEmpty(roomTypeName))
            {
                MessageBox.Show("Room Type Name must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (roomTypePrice < 0)
            {
                MessageBox.Show("Room Type Price must be greater than 0.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (roomTypeCapacity < 0)
            {
                MessageBox.Show("Room Type Capacity must be greater than 0.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void UpdateRoomTypeView()
        {
            try
            {
                dgvRType.Rows.Clear();
                string SP_Name = "SP_GetAllRoomTypes";
                var result = Helper.GetAllEntities<RoomType>(Program.Connection, SP_Name);

                foreach (var roomType in result)
                {
                    AddToView(roomType);
                }
                dgvRType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRType.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Room Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private RoomType GatherRoomTypeInput()
        {
            return new RoomType
            {
                Type = txtRTypeName.Text.Trim(),
                Description = txtRTypeDesc.Text.Trim(),
                CostPrice = double.Parse(txtRTypeBP.Text),
                RoomTypeCapacity = int.Parse(txtRTypeCapa.Text)
            };
        }
        private void PopulateFields(RoomType? roomType)
        {
            if (roomType != null)
            {
                txtRTypeID.Text = roomType.ID.ToString();
                txtRTypeName.Text = roomType.Type;
                txtRTypeDesc.Text = roomType.Description;
                txtRTypeBP.Text = roomType.CostPrice.ToString();
                txtRTypeCapa.Text = roomType.RoomTypeCapacity.ToString();
            }
            else
            {
                txtRTypeID.Text = string.Empty;
                txtRTypeName.Text = string.Empty;
                txtRTypeDesc.Text = string.Empty;
                txtRTypeBP.Text = string.Empty;
                txtRTypeCapa.Text = string.Empty;
            }
        }
        private void ConfigView()
        {
            dgvRType.Columns.Clear();
            dgvRType.Columns.Add("colRTypeId", "Room Type ID");
            dgvRType.Columns.Add("colRTypeName", "Type Name");
            dgvRType.Columns.Add("colRTypeBP", "Base Price");
            dgvRType.Columns.Add("colRTypeCap", "Capacity");

            dgvRType.Columns[0].Width = 100;
            dgvRType.Columns[1].Width = 150;
            dgvRType.Columns[2].Width = 100;
            dgvRType.Columns[3].Width = 100;

            dgvRType.DefaultCellStyle.BackColor = Color.White;
            dgvRType.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllRoomTypes";
                var result = Helper.GetAllEntities<RoomType>(Program.Connection, SP_Name);
                dgvRType.Rows.Clear();

                // Create an instance of EntityViewAdder
                var entityViewAdder = new EntityViewAdder<RoomType>(
                    dgvRType,
                    roomType => new object[] { roomType.ID, roomType.Type, roomType.CostPrice, roomType.RoomTypeCapacity }
                );

                // Use the AddToView method to add each resident to the DataGridView
                foreach (var roomType in result)
                {
                    entityViewAdder.AddToView(roomType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving room types", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(RoomType roomType)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvRType, roomType.ID, roomType.Type, roomType.CostPrice, roomType.RoomTypeCapacity);
            row.Tag = roomType.ID;
            dgvRType.Rows.Add(row);
        }
    }
}