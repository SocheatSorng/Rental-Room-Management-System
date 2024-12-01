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
    public partial class FormService : Form
    {
        BindingSource _bs = new();
        private int lastHighlightedIndex = -1;

        public FormService()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DataGridView.CheckForIllegalCrossThreadCalls = false;

            ConfigView();
            _bs.DataSource = servicegrid;

            btnInsert.Click += (sender, e) =>
            {
                Helper.Added += DoOnServiceInserted;
                DoClickInsert(sender, e);
                Helper.Added -= DoOnServiceInserted;
            };

            btnUpdate.Click += (sender, e) =>
            {
                Helper.Updated += DoOnServiceUpdated;
                DoClickUpdate(sender, e);
                Helper.Updated -= DoOnServiceUpdated;
            };

            btnDelete.Click += (sender, e) =>
            {
                Helper.Deleted += DoOnServiceDeleted;
                DoClickDelete(sender, e);
                Helper.Deleted -= DoOnServiceDeleted;
            };

            btnClear.Click += DoClickNew;
            servicegrid.SelectionChanged += DoClickRecord;
            searchbox.KeyDown += DoSearch;
        }

        private void DoSearch(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = searchbox.Text.Trim();
                servicegrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (lastHighlightedIndex == -1 || searchbox.Text != searchValue)
                {
                    lastHighlightedIndex = -1;
                }

                try
                {
                    bool found = false;
                    int startIndex = (lastHighlightedIndex + 1) % servicegrid.Rows.Count;

                    for (int i = startIndex; i < servicegrid.Rows.Count + startIndex; i++)
                    {
                        int currentIndex = i % servicegrid.Rows.Count;
                        DataGridViewRow row = servicegrid.Rows[currentIndex];

                        string? id = row.Cells["colServiceID"].Value?.ToString();
                        string? serviceName = row.Cells["colServiceName"].Value?.ToString();
                        string? description = row.Cells["colServiceDesc"].Value?.ToString();

                        if ((id != null && id.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (serviceName != null && serviceName.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (description != null && description.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            servicegrid.ClearSelection();
                            row.Selected = true;
                            servicegrid.FirstDisplayedScrollingRowIndex = row.Index;
                            lastHighlightedIndex = currentIndex;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No more matching services found. Starting over.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (servicegrid.SelectedCells.Count > 0)
            {
                int rowIndex = servicegrid.SelectedCells[0].RowIndex;
                DataGridViewRow row = servicegrid.Rows[rowIndex];

                object cellValue = row.Cells["colServiceID"].Value;
                int? serviceID = cellValue != null ? (int?)Convert.ToInt32(cellValue) : null;

                if (serviceID.HasValue)
                {
                    var service = Helper.GetEntityById<Service>(Program.Connection, serviceID.Value, "SP_GetServiceByID");
                    if (service != null)
                    {
                        PopulateFields(service);
                    }
                    else
                    {
                        MessageBox.Show("Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Service ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            ManageControl.EnableControl(btnInsert, false);
            ManageControl.EnableControl(btnUpdate, true);
            ManageControl.EnableControl(btnDelete, true);
            ManageControl.EnableControl(serviceid, false);
        }

        private void DoClickNew(object? sender, EventArgs e)
        {
            PopulateFields(null);

            ManageControl.EnableControl(btnInsert, true);
            ManageControl.EnableControl(btnUpdate, false);
            ManageControl.EnableControl(btnDelete, false);
            ManageControl.EnableControl(serviceid, false);
        }

        private void DoOnServiceDeleted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateServiceView();
                });
            });
        }

        private void DoClickDelete(object? sender, EventArgs e)
        {
            if (servicegrid.SelectedCells.Count <= 0) return;
            try
            {
                int rowIndex = servicegrid.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(servicegrid.Rows[rowIndex].Cells["colServiceID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this service?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using var cmd = Program.Connection.CreateCommand();
                    cmd.CommandText = "SP_DeleteService";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ServiceID", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Successfully Deleted Service ID > {id}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateServiceView();
                    PopulateFields(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoOnServiceUpdated(object? sender, EntityEventArgs e)
        {
            if (servicegrid.CurrentCell == null) return;
            int rowIndex = servicegrid.CurrentCell.RowIndex;

            UpdateServiceView();

            if (rowIndex < servicegrid.Rows.Count)
            {
                servicegrid.Rows[rowIndex].Selected = true;
                servicegrid.CurrentCell = servicegrid[0, rowIndex];
            }
        }

        private void DoClickUpdate(object? sender, EventArgs e)
        {
            if (servicegrid.SelectedCells.Count > 0)
            {
                int rowIndex = servicegrid.SelectedCells[0].RowIndex;
                object cellValue = servicegrid.Rows[rowIndex].Cells["colServiceID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                {
                    var service = GatherServiceInput();
                    service.ID = id;

                    if (ValidateInputs())
                    {
                        var entityService = new EntityService();
                        entityService.InsertOrUpdateEntity(service, "SP_UpdateService", "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid service to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DoOnServiceInserted(object? sender, EntityEventArgs e)
        {
            if (e.ByteId == 0) return;
            Task.Run(() =>
            {
                try
                {
                    var result = Helper.GetEntityById<Service>(Program.Connection, e.ByteId, "SP_GetServiceByID");

                    if (result != null)
                    {
                        servicegrid.Invoke((MethodInvoker)delegate
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
            var service = GatherServiceInput();

            if (ValidateInputs())
            {
                var entityService = new EntityService();
                entityService.InsertOrUpdateEntity(service, "SP_InsertService", "Insert");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(servicename.Text))
            {
                MessageBox.Show("Service name must not be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decimal.TryParse(servicecost.Text, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Please enter a valid cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateServiceView()
        {
            try
            {
                servicegrid.Rows.Clear();
                string SP_Name = "SP_GetAllServices";

                var result = Helper.GetAllEntities<Service>(Program.Connection, SP_Name);

                foreach (var service in result)
                {
                    AddToView(service);
                }
                servicegrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                servicegrid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating Services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Service GatherServiceInput()
        {
            return new Service()
            {
                FirstName = servicename.Text.Trim(),
                Description = servicedescription.Text.Trim(),
                Cost = decimal.Parse(servicecost.Text)
            };
        }

        private void PopulateFields(Service? service)
        {
            if (service != null)
            {
                serviceid.Text = service.ID.ToString();
                servicename.Text = service.FirstName;
                servicedescription.Text = service.Description;
                servicecost.Text = service.Cost.ToString();
            }
            else
            {
                serviceid.Text = string.Empty;
                servicename.Text = string.Empty;
                servicedescription.Text = string.Empty;
                servicecost.Text = string.Empty;
            }
        }

        private void ConfigView()
        {
            servicegrid.Columns.Clear();
            servicegrid.Columns.Add("colServiceID", "Service ID");
            servicegrid.Columns.Add("colServiceName", "Service Name");
            servicegrid.Columns.Add("colServiceDesc", "Description");
            servicegrid.Columns.Add("colServiceCost", "Cost");

            servicegrid.Columns[0].Width = 100;
            servicegrid.Columns[1].Width = 200;
            servicegrid.Columns[2].Width = 300;
            servicegrid.Columns[3].Width = 100;

            servicegrid.DefaultCellStyle.BackColor = Color.White;
            servicegrid.ScrollBars = ScrollBars.Both;

            try
            {
                string SP_Name = "SP_GetAllServices";
                var result = Helper.GetAllEntities<Service>(Program.Connection, SP_Name);
                servicegrid.Rows.Clear();

                var entityViewAdder = new EntityViewAdder<Service>(servicegrid,
                    service => new object[] { service.ID, service.FirstName, service.Description, service.Cost });
                foreach (var service in result)
                {
                    entityViewAdder.AddToView(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retrieving services", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToView(Service service)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(servicegrid, service.ID, service.FirstName, service.Description, service.Cost);
            row.Tag = service.ID;
            servicegrid.Rows.Add(row);
        }
    }
}