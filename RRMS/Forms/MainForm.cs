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
        public MainForm()
        {
            InitializeComponent();
            SetupButtons();
        }

        private void SetupButtons()
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
