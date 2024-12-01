//using Microsoft.Data.SqlClient;
//using System.Data;
//using RRMS.Model;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RRMS.Forms
{
    public partial class FormReservation : Form
    {
        public FormReservation()
        {
            InitializeComponent();
        }
    }
}

//namespace RRMS.Forms
//{
//    public partial class FormReservation : Form
//    {
//        BindingSource _bs = new();
//        private int lastHighlightedIndex = -1;
//        public FormReservation()
//        {
//            InitializeComponent();
//            this.FormBorderStyle = FormBorderStyle.FixedSingle;
//            DataGridView.CheckForIllegalCrossThreadCalls = false;
//            ConfigView();
//            _bs.DataSource = dgvReser;
//            LoadResidentIDs();
//            cbbResID.SelectedIndexChanged += cbbResID_SelectedIndexChanged;
//            LoadRoomIDs();
//            cbbRoomID.SelectedIndexChanged += cbbRoomID_SelectedIndexChanged;

//            btnInsert.Click += (sender, e) =>
//            {
//                Helper.Added += DoOnReservationInserted;
//                DoClickInsert(sender, e);
//                Helper.Added += DoOnReservationInserted;
//            };

//            btnUpdate.Click += (sender, e) =>
//            {
//                Helper.Updated += DoOnReservationUpdated;
//                DoClickUpdate(sender, e);
//                Helper.Updated -= DoOnReservationUpdated;
//            };

//            btnDelete.Click += (sender, e) =>
//            {
//                Helper.Deleted += DoOnReservationDeleted;
//                DoClickDelete(sender, e);
//                Helper.Deleted -= DoOnReservationDeleted;
//            };

//            btnNew.Click += DoClickNew;
//            dgvReser.SelectionChanged += DoClickRecord;
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

//        private void cbbRoomID_SelectedIndexChanged(object? sender, EventArgs e)
//        {
//            if (cbbRoomID.SelectedItem != null)
//            {
//                SqlCommand cmd = new SqlCommand("SP_GetRoomByID", Program.Connection);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@RoomID", cbbRoomID.SelectedItem);
//                using (SqlDataReader dr = cmd.ExecuteReader())
//                {
//                    while (dr.Read())
//                    {
//                        txtRoomNum.Text = dr[1].ToString();
//                    }
//                }
//            }
//            else
//            {
//                txtRoomNum.Text = "";
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
//        private void LoadRoomIDs()
//        {
//            SqlCommand cmd = new SqlCommand("SP_LoadRoomIDs", Program.Connection);
//            cmd.CommandType = CommandType.StoredProcedure;
//            using (SqlDataReader dr = cmd.ExecuteReader())
//            {
//                while (dr.Read())
//                {
//                    object roomIDObj = dr["RoomID"];
//                    if (roomIDObj != DBNull.Value)
//                    {
//                        string? resID = roomIDObj.ToString();
//                        cbbRoomID.Items.Add(resID);
//                        cbbRoomID.DisplayMember = resID;
//                        cbbRoomID.ValueMember = resID;
//                    }
//                }
//            }
//        }
//        private void DoSearch(object? sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                string searchValue = txtSearch.Text.Trim();
//                dgvReser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

//                if (lastHighlightedIndex == -1 || txtSearch.Text != searchValue)
//                {
//                    lastHighlightedIndex = -1;
//                }

//                try
//                {
//                    bool found = false;
//                    int startIndex = (lastHighlightedIndex + 1) % dgvReser.Rows.Count;

//                    for (int i = startIndex; i < dgvReser.Rows.Count + startIndex; i++)
//                    {
//                        int currentIndex = i % dgvReser.Rows.Count;
//                        DataGridViewRow row = dgvReser.Rows[currentIndex];

//                        string? id = row.Cells["colReserID"].Value?.ToString();
//                        string? reservationName = row.Cells["colReserName"].Value?.ToString();
//                        //string? residentName = row.Cells["colResName"].Value?.ToString();

//                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
//                            (reservationName != null && reservationName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
//                        {

//                            dgvReser.ClearSelection();

//                            row.Selected = true;
//                            dgvReser.FirstDisplayedScrollingRowIndex = row.Index;
//                            lastHighlightedIndex = currentIndex;
//                            found = true;
//                            break;
//                        }
//                    }

//                    if (!found)
//                    {
//                        MessageBox.Show("No more matching reservations found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        lastHighlightedIndex = -1;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message);
//                }
//            }
//        }
//        private void DoClickRecord(object? sender, EventArgs e)
//        {
//            if (dgvReser.SelectedCells.Count > 0)
//            {
//                int rowIndex = dgvReser.SelectedCells[0].RowIndex;
//                DataGridViewRow row = dgvReser.Rows[rowIndex];

//                object cellValue = row.Cells["colReserID"].Value;
//                int? reservationID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

//                if (reservationID.HasValue)
//                {
//                    var reservation = Helper.GetEntityById<Reservation>(Program.Connection, reservationID.Value, "SP_GetReservationbyID");
//                    if (reservation != null)
//                    {
//                        PopulateFields(reservation);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Invalid reservation ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }

//            ManageControl.EnableControl(btnInsert, false);
//            ManageControl.EnableControl(btnUpdate, true);
//            ManageControl.EnableControl(btnDelete, true);
//            ManageControl.EnableControl(txtReserID, false);
//        }
//        private void DoClickNew(object? sender, EventArgs e)
//        {
//            PopulateFields(null);

//            ManageControl.EnableControl(btnInsert, true);
//            ManageControl.EnableControl(btnUpdate, false);
//            ManageControl.EnableControl(btnDelete, false);
//            ManageControl.EnableControl(txtReserID, false);
//        }
//        private void DoOnReservationDeleted(object? sender, EntityEventArgs e)
//        {
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                Invoke((MethodInvoker)delegate
//                {
//                    UpdateReservationView();
//                });
//            });
//        }
//        private void DoClickDelete(object? sender, EventArgs e)
//        {
//            if (dgvReser.SelectedCells.Count <= 0) return;
//            try
//            {
//                int rowIndex = dgvReser.SelectedCells[0].RowIndex;
//                int id = Convert.ToInt32(dgvReser.Rows[rowIndex].Cells["colReserID"].Value);

//                using var cmd = Program.Connection.CreateCommand();
//                cmd.CommandText = "SP_DeleteReservation";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@ReserID", id);

//                cmd.ExecuteNonQuery();
//                MessageBox.Show($"Successfully Deleted Reservation ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                ConfigView();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//        private void DoOnReservationUpdated(object? sender, EntityEventArgs e)
//        {
//            if (dgvReser.CurrentCell == null) return;
//            int rowIndex = dgvReser.CurrentCell.RowIndex;

//            UpdateReservationView();

//            // Restore selection to the updated row
//            if (rowIndex < dgvReser.Rows.Count)
//            {
//                dgvReser.Rows[rowIndex].Selected = true;
//                dgvReser.CurrentCell = dgvReser[0, rowIndex];
//            }
//        }
//        private void DoClickUpdate(object? sender, EventArgs e)
//        {
//            if (dgvReser.SelectedCells.Count > 0)
//            {
//                int rowIndex = dgvReser.SelectedCells[0].RowIndex;
//                object cellValue = dgvReser.Rows[rowIndex].Cells["colReserID"].Value;

//                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
//                {
//                    var reservation = GatherReservationInput();
//                    reservation.ID = id;

//                    var entityService = new EntityService();
//                    entityService.InsertOrUpdateEntity(reservation, "SP_UpdateReservation", "Update");
//                }
//                else
//                {
//                    MessageBox.Show("Please select a valid reservation to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a reservation to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }
//        private void DoOnReservationInserted(object? sender, EntityEventArgs e)
//        {
//            string SP_Name = "SP_GetReservationByID";
//            if (e.ByteId == 0) return;
//            Task.Run(() =>
//            {
//                try
//                {
//                    var result = Helper.GetEntityById<Reservation>(Program.Connection, e.ByteId, SP_Name);

//                    if (result != null)
//                    {
//                        dgvReser.Invoke((MethodInvoker)delegate
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
//        private void DoClickInsert(object? sender, EventArgs e)
//        {
//            var feedback = GatherReservationInput();

//            // Create an instance of EntityService
//            var entityService = new EntityService();

//            // Call InsertOrUpdateEntity method
//            entityService.InsertOrUpdateEntity(feedback, "SP_InsertReservation", "Insert");
//        }

//        //private bool TryParseInputs(string type, string desc, int resID)
//        //{

//        //    if (string.IsNullOrEmpty(type))
//        //    {
//        //        MessageBox.Show("Content must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        return false;
//        //    }
//        //    if (string.IsNullOrEmpty(desc))
//        //    {
//        //        MessageBox.Show("Comment must not be empty.", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        return false;
//        //    }
//        //    if (resID < 0)
//        //    {
//        //        MessageBox.Show("Resident ID is not selected", "Inserting", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        return false;
//        //    }
//        //    return true;
//        //}
//        private void UpdateReservationView()
//        {
//            try
//            {
//                dgvReser.Rows.Clear();
//                string SP_Name = "SP_GetAllReservations";

//                var result = Helper.GetAllEntities<Reservation>(Program.Connection, SP_Name);

//                foreach (var reservation in result)
//                {
//                    AddToView(reservation);
//                }
//                dgvReser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//                dgvReser.ClearSelection();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message, "Updating Reservations", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//        private Feedback GatherFeedbackInput()
//        {
//            int resID;
//            if (cbbResID.SelectedItem != null && int.TryParse(cbbResID.SelectedItem.ToString(), out resID))
//            {
//                return new Feedback()
//                {
//                    Date = dtpFeedDate.Value,
//                    Type = txtFeedCon.Text.Trim(),
//                    Description = txtFeedCom.Text.Trim(),
//                    ResID = resID,
//                    ResName = txtResName.Text.Trim(),
//                };
//            }

//            else
//            {
//                MessageBox.Show("Please select a valid Resident ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return null;
//            }

//        }
//    }
//}