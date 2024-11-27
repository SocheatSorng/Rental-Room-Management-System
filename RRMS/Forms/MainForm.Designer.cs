namespace RRMS.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnResident = new Button();
            btnVendor = new Button();
            btnAmenity = new Button();
            btnStaff = new Button();
            btnLeaseAgreement = new Button();
            btnPolicy = new Button();
            btnUtility = new Button();
            btnFeedback = new Button();
            btnRequest = new Button();
            btnReservation = new Button();
            btnService = new Button();
            btnRent = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(276, 29);
            label1.Name = "label1";
            label1.Size = new Size(190, 15);
            label1.TabIndex = 0;
            label1.Text = "Rental Room Management System";
            // 
            // btnResident
            // 
            btnResident.Location = new Point(28, 74);
            btnResident.Name = "btnResident";
            btnResident.Size = new Size(75, 23);
            btnResident.TabIndex = 1;
            btnResident.Text = "Resident";
            btnResident.UseVisualStyleBackColor = true;
            // 
            // btnVendor
            // 
            btnVendor.Location = new Point(130, 74);
            btnVendor.Name = "btnVendor";
            btnVendor.Size = new Size(75, 23);
            btnVendor.TabIndex = 2;
            btnVendor.Text = "Vendor";
            btnVendor.UseVisualStyleBackColor = true;
            // 
            // btnAmenity
            // 
            btnAmenity.Location = new Point(130, 128);
            btnAmenity.Name = "btnAmenity";
            btnAmenity.Size = new Size(75, 23);
            btnAmenity.TabIndex = 3;
            btnAmenity.Text = "Amenity";
            btnAmenity.UseVisualStyleBackColor = true;
            // 
            // btnStaff
            // 
            btnStaff.Location = new Point(28, 128);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(75, 23);
            btnStaff.TabIndex = 4;
            btnStaff.Text = "Staff";
            btnStaff.UseVisualStyleBackColor = true;
            // 
            // btnLeaseAgreement
            // 
            btnLeaseAgreement.Location = new Point(240, 74);
            btnLeaseAgreement.Name = "btnLeaseAgreement";
            btnLeaseAgreement.Size = new Size(113, 23);
            btnLeaseAgreement.TabIndex = 5;
            btnLeaseAgreement.Text = "Lease Agreement";
            btnLeaseAgreement.UseVisualStyleBackColor = true;
            // 
            // btnPolicy
            // 
            btnPolicy.Location = new Point(375, 74);
            btnPolicy.Name = "btnPolicy";
            btnPolicy.Size = new Size(75, 23);
            btnPolicy.TabIndex = 6;
            btnPolicy.Text = "Policy";
            btnPolicy.UseVisualStyleBackColor = true;
            // 
            // btnUtility
            // 
            btnUtility.Location = new Point(257, 128);
            btnUtility.Name = "btnUtility";
            btnUtility.Size = new Size(75, 23);
            btnUtility.TabIndex = 7;
            btnUtility.Text = "Utility";
            btnUtility.UseVisualStyleBackColor = true;
            // 
            // btnFeedback
            // 
            btnFeedback.Location = new Point(375, 128);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.Size = new Size(75, 23);
            btnFeedback.TabIndex = 8;
            btnFeedback.Text = "Feedback";
            btnFeedback.UseVisualStyleBackColor = true;
            // 
            // btnRequest
            // 
            btnRequest.Location = new Point(487, 74);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new Size(75, 23);
            btnRequest.TabIndex = 9;
            btnRequest.Text = "Request";
            btnRequest.UseVisualStyleBackColor = true;
            // 
            // btnReservation
            // 
            btnReservation.Location = new Point(487, 128);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(84, 23);
            btnReservation.TabIndex = 10;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = true;
            // 
            // btnService
            // 
            btnService.Location = new Point(599, 74);
            btnService.Name = "btnService";
            btnService.Size = new Size(75, 23);
            btnService.TabIndex = 11;
            btnService.Text = "Service";
            btnService.UseVisualStyleBackColor = true;
            // 
            // btnRent
            // 
            btnRent.Location = new Point(599, 128);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(75, 23);
            btnRent.TabIndex = 12;
            btnRent.Text = "Rent";
            btnRent.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRent);
            Controls.Add(btnService);
            Controls.Add(btnReservation);
            Controls.Add(btnRequest);
            Controls.Add(btnFeedback);
            Controls.Add(btnUtility);
            Controls.Add(btnPolicy);
            Controls.Add(btnLeaseAgreement);
            Controls.Add(btnStaff);
            Controls.Add(btnAmenity);
            Controls.Add(btnVendor);
            Controls.Add(btnResident);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnResident;
        private Button btnVendor;
        private Button btnAmenity;
        private Button btnStaff;
        private Button btnLeaseAgreement;
        private Button btnPolicy;
        private Button btnUtility;
        private Button btnFeedback;
        private Button btnRequest;
        private Button btnReservation;
        private Button btnService;
        private Button btnRent;
    }
}