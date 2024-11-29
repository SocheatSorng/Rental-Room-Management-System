using RRMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RRMS.Forms
{
    public partial class MainForm : Form
    {

        private Form activeForm = null;

        public MainForm()
        {
            InitializeComponent();
            //SetupButtons();
            CustomizeDesign();
            SetupPanels();

        }

        private void CustomizeDesign()
        {
            // Hide all submenu panels initially
            panelsubmenu1.Visible = false;
            panelsubmenu2.Visible = false;
            panelsubmenu3.Visible = false;
            panelsubmenu4.Visible = false;

            // Set up the Utility button click event
            btnUser.Click += btnUtility_Click;
        }

        private void SetupPanels()
        {
            // Setup List1 submenu
            panelsubmenu1.Controls.Add(btnStaff);
            panelsubmenu1.Controls.Add(btnResident);
            panelsubmenu1.Controls.Add(btnUser);

            // Setup List2 submenu
            panelsubmenu2.Controls.Add(btnRoom);
            panelsubmenu2.Controls.Add(btnVendor);

            // Setup List3 submenu
            panelsubmenu3.Controls.Add(btnUtility);
            panelsubmenu3.Controls.Add(btnAmenity);
            panelsubmenu3.Controls.Add(btnRoomType);

            // Setup List4 submenu
            panelsubmenu4.Controls.Add(btnRent);
            panelsubmenu4.Controls.Add(btnReservation);
            panelsubmenu4.Controls.Add(btnRequest);
            panelsubmenu4.Controls.Add(btnService);
            panelsubmenu4.Controls.Add(btnPayment);
            panelsubmenu4.Controls.Add(btnInvoice);
            panelsubmenu4.Controls.Add(btnLeaseAgreement);
            panelsubmenu4.Controls.Add(btnPolicy);
            panelsubmenu4.Controls.Add(btnFeedback);


            // Configure all panels
            ConfigurePanel(panelsubmenu1);
            ConfigurePanel(panelsubmenu2);
            ConfigurePanel(panelsubmenu3);
            ConfigurePanel(panelsubmenu4);

            // Wire up click events
            btnlist1.Click += (s, e) => ToggleSubMenu(panelsubmenu1);
            btnPlace.Click += (s, e) => ToggleSubMenu(panelsubmenu2);
            btnAsset.Click += (s, e) => ToggleSubMenu(panelsubmenu3);
            btnTransaction.Click += (s, e) => ToggleSubMenu(panelsubmenu4);
        }

        private void ConfigurePanel(Panel panel)
        {
            panel.AutoSize = false;
            panel.Height = 0; // Start collapsed
            panel.BackColor = Color.WhiteSmoke; // Use a color that matches your design

            // Configure each button in the panel
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button button)
                {
                    button.Dock = DockStyle.Top;
                    button.Height = 40; // Set consistent height
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private async void ToggleSubMenu(Panel subMenu)
        {
            // Calculate height based on children
            int targetHeight = subMenu.Controls.Cast<Control>()
                                     .Sum(control => control.Height + control.Margin.Vertical);

            if (subMenu.Height == 0)
            {
                HideOtherSubMenus(subMenu);
                subMenu.Visible = true;
                while (subMenu.Height < targetHeight)
                {
                    subMenu.Height += 10;
                    await Task.Delay(10);
                }
                subMenu.Height = targetHeight;
            }
            else
            {
                while (subMenu.Height > 0)
                {
                    subMenu.Height -= 10;
                    await Task.Delay(10);
                }
                subMenu.Height = 0;
                subMenu.Visible = false;
            }
        }

        private void HideOtherSubMenus(Panel currentPanel)
        {
            if (currentPanel != panelsubmenu1 && panelsubmenu1.Height > 0)
                ToggleSubMenu(panelsubmenu1);
            if (currentPanel != panelsubmenu2 && panelsubmenu2.Height > 0)
                ToggleSubMenu(panelsubmenu2);
            if (currentPanel != panelsubmenu3 && panelsubmenu3.Height > 0)
                ToggleSubMenu(panelsubmenu3);
            if (currentPanel != panelsubmenu4 && panelsubmenu4.Height > 0)
                ToggleSubMenu(panelsubmenu4);
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            // Set up the child form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Enable auto-scaling
            childForm.AutoScaleMode = AutoScaleMode.Dpi;
            childForm.AutoSize = true;

            // Set minimum size
            childForm.MinimumSize = new Size(panelform.ClientSize.Width, panelform.ClientSize.Height);

            // Handle parent panel resize
            panelform.Resize += (sender, e) =>
            {
                childForm.Size = panelform.ClientSize;
            };

            // Add and show the form
            panelform.Controls.Add(childForm);
            panelform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /*   private void SetupButtons()
             {
                 // Staff Management Button
                 btnResident.Click += (sender, e) =>
                 {
                     FormResident staffForm = new FormResident();
                     staffForm.Show();
                 };

                 // Vendor Management Button
                 btnVendor.Click += (sender, e) =>
                 {
                     FormVendor vendorForm = new FormVendor();
                     vendorForm.Show();
                 };

                 // Staff Management Button
                 btnStaff.Click += (sender, e) =>
                 {
                     FormStaff staffForm = new FormStaff();
                     staffForm.Show();
                 };

                 // Leave Management Button
                 btnAmenity.Click += (sender, e) =>
                 {
                     FormAmenity amenityForm = new FormAmenity();
                     amenityForm.Show();
                 };

                 // Lease Agreement Button
                 btnLeaseAgreement.Click += (sender, e) =>
                 {
                     LeaseAgreement leaseAgreement = new LeaseAgreement();
                     leaseAgreement.Show();
                 };

                 // Policy Button
                 btnPolicy.Click += (sender, e) =>
                 {
                     Policy policy = new Policy();
                     policy.Show();
                 };

                 // Utility Button
                 btnUtility.Click += (sender, e) =>
                 {
                     Utility utility = new Utility();
                     utility.Show();
                 };

                 // Feedback Button
                 //btnFeedback.Click += (sender, e) =>
                 //{
                 //    Feedback feedback = new Feedback();
                 //    feedback.Show();
                 //};

                 // Request Button
                 btnRequest.Click += (sender, e) =>
                 {
                     RequestForm requestForm = new RequestForm();
                     requestForm.Show();
                 };

                 // Reservation Button
                 btnReservation.Click += (sender, e) =>
                 {
                     ReservationForm reservationForm = new ReservationForm();
                     reservationForm.Show();
                 };

                 // Service Button
                 btnService.Click += (sender, e) =>
                 {
                     ServiceForm serviceForm = new ServiceForm();
                     serviceForm.Show();
                 };

                 // Rent Button
                 btnRent.Click += (sender, e) =>
                 {
                     RentForm rentForm = new RentForm();
                     rentForm.Show();
                 };
             }
        */

        private void btnUtility_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Utility());
        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormResident());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User());
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new User());
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVendor());
        }

        private void btnUtility_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Utility());
        }

        private void btnAmenity_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAmenity());
        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAmenity());
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentForm());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReservationForm());
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RequestForm());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServiceForm());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServiceForm());
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ServiceForm());
        }

        private void btnLeaseAgreement_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LeaseAgreement());
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Policy());
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormFeedback());
        }
    }
}
