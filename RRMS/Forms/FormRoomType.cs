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
        private int lastHighlightedIndex = -1;

        public FormRoomType()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;

            // Initialize Status ComboBox
            cbbStatus.Items.AddRange(new string[] { "Active", "Inactive" });
            cbbStatus.SelectedIndex = 0;

            // Configure Form
            ConfigView();
            txtRoomTypeID.ReadOnly = true;

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
            dgvRoomType.SelectionChanged += DoClickRecord;
            txtSearch.KeyDown += DoSearch;
        }

        private void ConfigView()
        {
            dgvRoomType.Columns.Clear();
            dgvRoomType.Columns.Add("colRoomTypeId", "Room Type ID");
            dgvRoomType.Columns.Add("colTypeName", "Type Name");
            dgvRoomType.Columns.Add("colBasePrice", "Base Price");
            dgvRoomType.Columns.Add("colDescription", "Description");
            dgvRoomType.Columns.Add("colStatus", "Status");

            dgvRoomType.Columns[0].Width = 100;
            dgvRoomType.Columns[1].Width = 150;
            dgvRoomType.Columns[2].Width = 100;
            dgvRoomType.Columns[3].Width = 200;
            dgvRoomType.Columns[4].Width = 100;

            dgvRoomType.DefaultCellStyle.BackColor = Color.White;
            dgvRoomType.ScrollBars = ScrollBars.Both;

            UpdateRoomTypeView();
        }

        private void UpdateRoomTypeView()
        {
            try
            {
                dgvRoomType.Rows.Clear();
                string SP_Name = "SP_GetAllRoomTypes";
                var result = Helper.GetAllEntities<RoomType>(Program.Connection, SP_Name);

                foreach (var roomType in result)
                {
                    AddToView(roomType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Room Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(RoomType roomType)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvRoomType,
                roomType.RoomTypeID,
                roomType.TypeName,
                roomType.BasePrice.ToString("C"),
                roomType.Description,
                roomType.Status);
            row.Tag = roomType.RoomTypeID;
            dgvRoomType.Rows.Add(row);
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = txtSearch.Text.Trim().ToLower();
                bool found = false;

                for (int i = lastHighlightedIndex + 1; i < dgvRoomType.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvRoomType.Rows[i];
                    if (row.Cells.Cast<DataGridViewCell>().Any(cell =>
                        cell.Value?.ToString().ToLower().Contains(searchValue) == true))
                    {
                        dgvRoomType.ClearSelection();
                        row.Selected = true;
                        dgvRoomType.FirstDisplayedScrollingRowIndex = i;
                        lastHighlightedIndex = i;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    lastHighlightedIndex = -1;
                    MessageBox.Show("No more matching room types found. Starting over.",
                        "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DoClickRecord(object? sender, EventArgs e)
        {
            if (dgvRoomType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRoomType.SelectedRows[0];
                PopulateFields(new RoomType
                {
                    RoomTypeID = Convert.ToInt32(row.Cells["colRoomTypeId"].Value),
                    TypeName = row.Cells["colTypeName"].Value.ToString(),
                    BasePrice = decimal.Parse(row.Cells["colBasePrice"].Value.ToString().TrimStart('$')),
                    Description = row.Cells["colDescription"].Value.ToString(),
                    Status = row.Cells["colStatus"].Value.ToString()
                });

                ManageControl.EnableControl(btnInsert, false);
                ManageControl.EnableControl(btnUpdate, true);
                ManageControl.EnableControl(btnDelete, true);
                ManageControl.EnableControl(txtRoomTypeID, false);
            }
        }

        private void PopulateFields(RoomType? roomType)
        {
            if (roomType != null)
            {
                txtRoomTypeID.Text = roomType.RoomTypeID.ToString();
                txtDescription.Text = roomType.Description;
                txtBasePrice.Text = roomType.BasePrice.ToString();
                cbbStatus.Text = roomType.Status;
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtRoomTypeID.Clear();
            txtDescription.Clear();
            txtBasePrice.Clear();
            cbbStatus.SelectedIndex = 0;
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            ClearForm();
            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(txtRoomTypeID, false);
        }

        private RoomType GatherRoomTypeInput()
        {
            return new RoomType
            {
                TypeName = txtDescription.Text.Trim(),
                BasePrice = decimal.Parse(txtBasePrice.Text),
                Description = txtDescription.Text.Trim(),
                Status = cbbStatus.Text
            };
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Type name must not be empty.", "Validation Error");
                return false;
            }

            if (!decimal.TryParse(txtBasePrice.Text, out decimal basePrice) || basePrice <= 0)
            {
                MessageBox.Show("Please enter a valid base price greater than zero.", "Validation Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbbStatus.Text))
            {
                MessageBox.Show("Please select a status.", "Validation Error");
                return false;
            }

            return true;
        }

        private void DoOnRoomTypeInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<RoomType>(
                        Program.Connection, e.ByteId, "SP_GetRoomTypeByID");

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
            var roomType = GatherRoomTypeInput();

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(roomType, "SP_InsertRoomType", "Insert");
            }
        }

        private void DoOnRoomTypeUpdated(object? sender, EntityEventArgs e)
        {
            UpdateRoomTypeView();
            if (dgvRoomType.SelectedRows.Count > 0)
            {
                dgvRoomType.FirstDisplayedScrollingRowIndex = dgvRoomType.SelectedRows[0].Index;
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (dgvRoomType.SelectedRows.Count > 0)
            {
                var roomType = GatherRoomTypeInput();
                roomType.RoomTypeID = int.Parse(txtRoomTypeID.Text);

                if (ValidateInputs())
                {
                    var entityService = new EntityService();
                    entityService.InsertOrUpdateEntity(roomType, "SP_UpdateRoomType", "Update");
                }
            }
            else
            {
                MessageBox.Show("Please select a room type to update.", "Selection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DoOnRoomTypeDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateRoomTypeView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (dgvRoomType.SelectedRows.Count <= 0) return;

            try
            {
                int id = Convert.ToInt32(dgvRoomType.SelectedRows[0].Cells["colRoomTypeId"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this room type?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteRoomType";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomTypeID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Room Type ID > {id}", "Deleting",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateRoomTypeView();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}