using Microsoft.Data.SqlClient;
using RRMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRMS.Forms
{
    public partial class FormReservation : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormReservation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;
            cbbStatus.Items.AddRange(new string[] {
                "Pending",
                "Completed",
                "In Progress"
            });
            cbbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStatus.SelectedIndex = 0; // Set default to "Pending"
            ConfigView();
            _bs.DataSource = dgvReservation;
            LoadResidentIDs();
            LoadRoomIDs();

            // Event handlers
            cbbResID.SelectedIndexChanged += CbbResidentID_SelectedIndexChanged;
            cbbRoomID.SelectedIndexChanged += CbbRoomID_SelectedIndexChanged;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnReservationInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnReservationInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnReservationUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnReservationUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnReservationDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnReservationDeleted;
            };

            btnNew.Click += DoClickNew;
            dgvReservation.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;


        }

        private void LoadResidentIDs()
        {
            using SqlCommand cmd = new SqlCommand("SP_LoadResidentIDs", Program.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["ResidentID"] != DBNull.Value)
                {
                    string? resID = dr["ResidentID"].ToString();
                    cbbResID.Items.Add(resID);
                }
            }
        }

        private void LoadRoomIDs()
        {
            try
            {
                cbbRoomID.Items.Clear();
                using SqlCommand cmd = new("SP_LoadRoomIDs", Program.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader dr = cmd.ExecuteReader();
                bool hasRooms = false;

                while (dr.Read())
                {
                    hasRooms = true;
                    string roomId = dr["RoomID"]?.ToString() ?? "";
                    string roomNumber = dr["RoomNumber"]?.ToString() ?? "";
                    string typeName = dr["TypeName"]?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(roomId) && !string.IsNullOrEmpty(roomNumber))
                    {
                        string roomInfo = $"{roomId} - {roomNumber} ({typeName})";
                        cbbRoomID.Items.Add(roomInfo);
                    }
                }

                if (!hasRooms)
                {
                    MessageBox.Show("No rooms found in database. Please check room configuration.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbbResidentID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbResID.SelectedItem != null)
            {
                try
                {
                    using SqlCommand cmd = new SqlCommand("SP_GetResidentNameByID", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ResidentID", cbbResID.SelectedItem);
                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string firstName = dr["FirstName"].ToString() ?? string.Empty;
                        string lastName = dr["LastName"].ToString() ?? string.Empty;
                        txtResName.Text = $"{firstName} {lastName}".Trim();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtResName.Text = string.Empty;
                }
            }
        }

        private void CbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbbRoomID.SelectedItem != null)
            {
                try
                {
                    string selectedItem = cbbRoomID.SelectedItem.ToString() ?? string.Empty;
                    int roomId = int.Parse(selectedItem.Split('-')[0].Trim());

                    using SqlCommand cmd = new SqlCommand("SP_GetRoomDetailsWithPrice", Program.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomID", roomId);

                    using SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtRoomNum.Text = dr["RoomNumber"]?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving room details: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRoomNum.Text = string.Empty;
                }
            }
        }
        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim();
                dgvReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % dgvReservation.Rows.Count;

                    for (int i = startIndex; i < dgvReservation.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % dgvReservation.Rows.Count;
                        DataGridViewRow row = dgvReservation.Rows[currentIndex];

                        string? id = row.Cells["colReserID"].Value?.ToString();
                        string? residentName = row.Cells["colResidentName"].Value?.ToString();
                        string? roomNumber = row.Cells["colRoomNumber"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (residentName != null && residentName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (roomNumber != null && roomNumber.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            dgvReservation.ClearSelection();
                            row.Selected = true;
                            dgvReservation.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching reservations found. Starting over.", "Search Result",
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
            if (dgvReservation.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReservation.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvReservation.Rows[rowIndex];

                if (int.TryParse(row.Cells["colReserID"].Value?.ToString(), out int reservationId))
                {
                    var reservation = Helper.GetEntityById<Reservation>(Program.Connection, reservationId, "SP_GetReservationByID");
                    if (reservation != null)
                    {
                        PopulateFields(reservation);
                    }
                    else
                    {
                        MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(txtReserID, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtReserID, false);
        }

        private void DoOnReservationDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateReservationView();
                    MessageBox.Show("Reservation deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvReservation.SelectedCells.Count <= 0) return;

            try
            {
                int rowIndex = dgvReservation.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dgvReservation.Rows[rowIndex].Cells["colReserID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this reservation?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteReservation";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservationID", id);
                    cmd.ExecuteNonQuery();
                    ConfigView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnReservationUpdated(object? sender, EntityEventArgs e)
        {
            if (dgvReservation.CurrentCell == null) return;
            int rowIndex = dgvReservation.CurrentCell.RowIndex;

            UpdateReservationView();

            if (rowIndex < dgvReservation.Rows.Count)
            {
                dgvReservation.Rows[rowIndex].Selected = true;
                dgvReservation.CurrentCell = dgvReservation[0, rowIndex];
            }

            MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvReservation.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReservation.SelectedCells[0].RowIndex;
                object cellValue = dgvReservation.Rows[rowIndex].Cells["colReserID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var reservation = GatherReservationInput();
                    if (reservation != null)
                    {
                        reservation.ID = id;
                        if (ValidateReservationInput(reservation))
                        {
                            var entityService = new EntityService();
                            entityService.InsertOrUpdateEntity(reservation, "SP_UpdateReservation", "Update");
                        }
                    }
                }
            }
        }

        private void DoOnReservationInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Reservation>(Program.Connection, e.ByteId, "SP_GetReservationByID");
                    if (result != null)
                    {
                        dgvReservation.Invoke((MethodInvoker)delegate
                        {
                            AddToView(result);
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            DoClickNew(sender, e);
        }

        private void DoClickInsert(object? sender, EventArgs e)
        {
            var reservation = GatherReservationInput();
            if (reservation != null && ValidateReservationInput(reservation))
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(reservation, "SP_InsertReservation", "Insert");
                UpdateReservationView();
            }
        }

        private Reservation GatherReservationInput()
        {
            try
            {
                // Validate ResidentID
                if (!int.TryParse(cbbResID.SelectedItem?.ToString(), out int residentId))
                {
                    MessageBox.Show("Please select a valid resident.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                // Extract RoomID from the selected item
                if (cbbRoomID.SelectedItem == null)
                {
                    MessageBox.Show("Please select a room.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string roomSelection = cbbRoomID.SelectedItem.ToString();
                int roomId = int.Parse(roomSelection.Split('-')[0].Trim());

                // Validate status is selected
                if (cbbStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a status.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                // Create and return the reservation object
                return new Reservation
                {
                    ReservationDate = dtpReserDate.Value,
                    StartDate = dtpReserSD.Value,
                    EndDate = dtpReserED.Value,
                    _Status = cbbStatus.Text,
                    ResidentID = residentId,
                    RoomID = roomId
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error gathering reservation input: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private bool ValidateReservationInput(Reservation reservation)
        {
            if (reservation.ResidentID <= 0)
            {
                MessageBox.Show("Please select a valid resident.", "Validation Error");
                return false;
            }

            if (reservation.RoomID <= 0)
            {
                MessageBox.Show("Please select a valid room.", "Validation Error");
                return false;
            }

            if (reservation.End <= reservation.Start)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error");
                return false;
            }

            return true;
        }

        private void PopulateFields(Reservation? reservation)
        {
            if (reservation != null)
            {
                txtReserID.Text = reservation.ID.ToString();
                dtpReserDate.Value = reservation.Booking;
                dtpReserSD.Value = reservation.Start ?? DateTime.Now;
                dtpReserED.Value = reservation.End ?? DateTime.Now;
                cbbStatus.Text = reservation.Description ?? "Pending";
                cbbResID.Text = reservation.ResidentID.ToString();

                // Find and select the correct room item
                for (int i = 0; i < cbbRoomID.Items.Count; i++)
                {
                    string item = cbbRoomID.Items[i].ToString() ?? string.Empty;
                    if (item.StartsWith(reservation.RoomID.ToString()))
                    {
                        cbbRoomID.SelectedIndex = i;
                        break;
                    }
                }

                // These will trigger in correct order
                CbbResidentID_SelectedIndexChanged(null, EventArgs.Empty);
                CbbRoomID_SelectedIndexChanged(null, EventArgs.Empty);
            }
            else
            {
                txtReserID.Text = string.Empty;
                dtpReserDate.Value = DateTime.Now;
                dtpReserSD.Value = DateTime.Now;
                dtpReserED.Value = DateTime.Now.AddDays(30);
                cbbStatus.SelectedIndex = 0;
                cbbResID.SelectedIndex = -1;
                cbbRoomID.SelectedIndex = -1;
                txtResName.Text = string.Empty;
                txtRoomNum.Text = string.Empty;
            }
        }

        private void UpdateReservationView()
        {
            try
            {
                dgvReservation.Rows.Clear();
                string SP_Name = "SP_GetAllReservations";

                var result = Helper.GetAllEntities<Reservation>(Program.Connection, SP_Name);

                foreach (var reservation in result)
                {
                    AddToView(reservation);
                }
                dgvReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReservation.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Reservations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigView()
        {
            dgvReservation.Columns.Clear();
            dgvReservation.Columns.Add("colReserID", "Reservation ID");
            dgvReservation.Columns.Add("colReserDate", "Reservation Date");
            dgvReservation.Columns.Add("colStartDate", "Start Date");
            dgvReservation.Columns.Add("colEndDate", "End Date");
            dgvReservation.Columns.Add("colStatus", "Status");
            dgvReservation.Columns.Add("colResidentName", "Resident");
            dgvReservation.Columns.Add("colRoomNumber", "Room");

            dgvReservation.Columns["colReserID"].Width = 80;
            dgvReservation.Columns["colReserDate"].Width = 100;
            dgvReservation.Columns["colStartDate"].Width = 100;
            dgvReservation.Columns["colEndDate"].Width = 100;
            dgvReservation.Columns["colStatus"].Width = 80;
            dgvReservation.Columns["colResidentName"].Width = 150;
            dgvReservation.Columns["colRoomNumber"].Width = 80;

            dgvReservation.DefaultCellStyle.BackColor = Color.White;
            dgvReservation.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllReservations";
                var result = Helper.GetAllEntities<Reservation>(Program.Connection, SP_Name);
                dgvReservation.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Reservation>(
                    dgvReservation,
                    reservation => new object[]
                    {
                        reservation.ID,
                        reservation.Booking.ToString("yyyy-MM-dd"),
                        reservation.Start?.ToString("yyyy-MM-dd") ?? string.Empty,
                        reservation.End?.ToString("yyyy-MM-dd") ?? string.Empty,
                        reservation.Description,
                        reservation.FirstName, // This should contain the resident name from the SP
                        reservation.Type,      // This should contain the room number from the SP
                        reservation.CostPrice.ToString("C"),
                    }
                );

                foreach (var reservation in result)
                {
                    entityViewAdder.AddToView(reservation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving Reservations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Reservation reservation)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvReservation,
            reservation.ID,
            reservation.Booking.ToString("yyyy-MM-dd"),
            reservation.Start?.ToString("yyyy-MM-dd") ?? string.Empty,
            reservation.End?.ToString("yyyy-MM-dd") ?? string.Empty,
            reservation.Description,
            reservation.FirstName, // Resident name
            reservation.Type
            );
            row.Tag = reservation.ID;
            dgvReservation.Rows.Add(row);
        }
    }
}