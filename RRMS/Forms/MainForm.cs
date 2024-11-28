using RRMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

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

            //Add Exit Button and Styles
            btnexit.Click += btnexit_Click;
            btnexit.FlatStyle = FlatStyle.Flat;
            btnexit.FlatAppearance.BorderSize = 0;
            btnexit.Cursor = Cursors.Hand;
        }

        private void CustomizeDesign()
        {
            // Hide all submenu panels initially
            panelsubmenu1.Visible = false;
            panelsubmenu2.Visible = false;
            panelsubmenu3.Visible = false;

            // Set up the Utility button click event
            btnUtility.Click += btnUtility_Click;
        }

        private void SetupPanels()
        {
            // Setup List1 submenu
            panelsubmenu1.Controls.Add(button4);
            panelsubmenu1.Controls.Add(button3);
            panelsubmenu1.Controls.Add(btnUtility);

            // Setup List2 submenu
            panelsubmenu2.Controls.Add(button8);
            panelsubmenu2.Controls.Add(button7);
            panelsubmenu2.Controls.Add(button6);

            // Setup List3 submenu
            panelsubmenu3.Controls.Add(button12);
            panelsubmenu3.Controls.Add(button11);
            panelsubmenu3.Controls.Add(button10);

            // Configure all panels
            ConfigurePanel(panelsubmenu1);
            ConfigurePanel(panelsubmenu2);
            ConfigurePanel(panelsubmenu3);

            // Wire up click events
            btnlist1.Click += (s, e) => ToggleSubMenu(panelsubmenu1);
            btnlist2.Click += (s, e) => ToggleSubMenu(panelsubmenu2);
            btnlist3.Click += (s, e) => ToggleSubMenu(panelsubmenu3);
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
            int targetHeight = 120; // Adjust based on your button heights (e.g., 3 buttons * 40 height)

            if (subMenu.Height == 0) // If collapsed, expand
            {
                // Hide other submenus first
                HideOtherSubMenus(subMenu);

                subMenu.Visible = true;
                while (subMenu.Height < targetHeight)
                {
                    subMenu.Height += 10; // Adjust speed by changing increment
                    await Task.Delay(10);  // Adjust animation smoothness
                }
                subMenu.Height = targetHeight; // Ensure final height is exact
            }
            else // If expanded, collapse
            {
                while (subMenu.Height > 0)
                {
                    subMenu.Height -= 10; // Adjust speed by changing decrement
                    await Task.Delay(10);  // Adjust animation smoothness
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
        private void btnexit_Click(object sender, EventArgs e)
        {
            // Show confirmation message box before exiting
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                                "Exit Application",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }

}
