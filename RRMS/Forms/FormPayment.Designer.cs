namespace RRMS.Forms
{
    partial class FormPayment
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
            dtPaymentDate = new DateTimePicker();
            txtPaymentNo = new TextBox();
            labelPaymentDate = new Label();
            LabelPaymentNo = new Label();
            txtSearchPayment = new TextBox();
            labelSearch = new Label();
            cbbReservationID = new ComboBox();
            cbUtilityID = new CheckBox();
            label5 = new Label();
            labelPaymentAmount = new Label();
            label4 = new Label();
            txtStaffName = new TextBox();
            label6 = new Label();
            cbbStaffID = new ComboBox();
            panel1 = new Panel();
            txtServiceName = new TextBox();
            cbbServiceID = new ComboBox();
            label3 = new Label();
            label7 = new Label();
            cbServiceID = new CheckBox();
            txtUtilityName = new TextBox();
            cbbUtilityID = new ComboBox();
            label2 = new Label();
            btnDelete = new Button();
            label17 = new Label();
            btnUpdate = new Button();
            btnInsert = new Button();
            btnNew = new Button();
            label12 = new Label();
            txtPaidAmount = new TextBox();
            txtRemainAmount = new TextBox();
            labelMajorID = new Label();
            label1 = new Label();
            dgvPayment = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayment).BeginInit();
            SuspendLayout();
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.CustomFormat = "yyyy/MM/dd";
            dtPaymentDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtPaymentDate.Location = new Point(160, 80);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Size = new Size(215, 24);
            dtPaymentDate.TabIndex = 3;
            // 
            // txtPaymentNo
            // 
            txtPaymentNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentNo.Location = new Point(160, 40);
            txtPaymentNo.Name = "txtPaymentNo";
            txtPaymentNo.ReadOnly = true;
            txtPaymentNo.Size = new Size(215, 27);
            txtPaymentNo.TabIndex = 2;
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPaymentDate.Location = new Point(25, 80);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(110, 20);
            labelPaymentDate.TabIndex = 104;
            labelPaymentDate.Text = "Payment Date";
            // 
            // LabelPaymentNo
            // 
            LabelPaymentNo.AutoSize = true;
            LabelPaymentNo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelPaymentNo.Location = new Point(25, 40);
            LabelPaymentNo.Name = "LabelPaymentNo";
            LabelPaymentNo.Size = new Size(95, 20);
            LabelPaymentNo.TabIndex = 103;
            LabelPaymentNo.Text = "Payment No";
            // 
            // txtSearchPayment
            // 
            txtSearchPayment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            txtSearchPayment.Location = new Point(632, 43);
            txtSearchPayment.Name = "txtSearchPayment";
            txtSearchPayment.Size = new Size(348, 24);
            txtSearchPayment.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSearch.Location = new Point(566, 47);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(60, 20);
            labelSearch.TabIndex = 100;
            labelSearch.Text = "Search";
            // 
            // cbbReservationID
            // 
            cbbReservationID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReservationID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbReservationID.FormattingEnabled = true;
            cbbReservationID.Location = new Point(160, 120);
            cbbReservationID.Name = "cbbReservationID";
            cbbReservationID.Size = new Size(215, 32);
            cbbReservationID.TabIndex = 4;
            // 
            // cbUtilityID
            // 
            cbUtilityID.AutoSize = true;
            cbUtilityID.Font = new Font("Microsoft Sans Serif", 11.25F);
            cbUtilityID.Location = new Point(140, 250);
            cbUtilityID.Name = "cbUtilityID";
            cbUtilityID.Size = new Size(15, 14);
            cbUtilityID.TabIndex = 7;
            cbUtilityID.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 240);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 173;
            label5.Text = "Utility ID:";
            // 
            // labelPaymentAmount
            // 
            labelPaymentAmount.AutoSize = true;
            labelPaymentAmount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPaymentAmount.Location = new Point(25, 120);
            labelPaymentAmount.Name = "labelPaymentAmount";
            labelPaymentAmount.Size = new Size(115, 20);
            labelPaymentAmount.TabIndex = 105;
            labelPaymentAmount.Text = "Reservation ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 160);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 175;
            label4.Text = "Staff ID:";
            // 
            // txtStaffName
            // 
            txtStaffName.Location = new Point(160, 200);
            txtStaffName.Margin = new Padding(3, 2, 3, 2);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(215, 23);
            txtStaffName.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 200);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 177;
            label6.Text = "Staff Name:";
            // 
            // cbbStaffID
            // 
            cbbStaffID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStaffID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbStaffID.FormattingEnabled = true;
            cbbStaffID.Location = new Point(160, 160);
            cbbStaffID.Name = "cbbStaffID";
            cbbStaffID.Size = new Size(215, 32);
            cbbStaffID.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtServiceName);
            panel1.Controls.Add(cbbServiceID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbServiceID);
            panel1.Controls.Add(txtUtilityName);
            panel1.Controls.Add(cbbUtilityID);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(cbbStaffID);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtStaffName);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbUtilityID);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtPaidAmount);
            panel1.Controls.Add(dtPaymentDate);
            panel1.Controls.Add(cbbReservationID);
            panel1.Controls.Add(txtRemainAmount);
            panel1.Controls.Add(txtPaymentNo);
            panel1.Controls.Add(labelMajorID);
            panel1.Controls.Add(labelPaymentAmount);
            panel1.Controls.Add(labelPaymentDate);
            panel1.Controls.Add(LabelPaymentNo);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(560, 626);
            panel1.TabIndex = 180;
            // 
            // txtServiceName
            // 
            txtServiceName.Font = new Font("Segoe UI", 12F);
            txtServiceName.Location = new Point(160, 360);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.ReadOnly = true;
            txtServiceName.Size = new Size(215, 29);
            txtServiceName.TabIndex = 12;
            txtServiceName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbServiceID
            // 
            cbbServiceID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbServiceID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbServiceID.FormattingEnabled = true;
            cbbServiceID.Location = new Point(160, 320);
            cbbServiceID.Name = "cbbServiceID";
            cbbServiceID.Size = new Size(215, 32);
            cbbServiceID.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 360);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 191;
            label3.Text = "Service Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 320);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 190;
            label7.Text = "Service ID";
            // 
            // cbServiceID
            // 
            cbServiceID.AutoSize = true;
            cbServiceID.Font = new Font("Microsoft Sans Serif", 11.25F);
            cbServiceID.Location = new Point(140, 330);
            cbServiceID.Name = "cbServiceID";
            cbServiceID.Size = new Size(15, 14);
            cbServiceID.TabIndex = 10;
            cbServiceID.UseVisualStyleBackColor = true;
            // 
            // txtUtilityName
            // 
            txtUtilityName.Font = new Font("Segoe UI", 12F);
            txtUtilityName.Location = new Point(160, 280);
            txtUtilityName.Name = "txtUtilityName";
            txtUtilityName.ReadOnly = true;
            txtUtilityName.Size = new Size(215, 29);
            txtUtilityName.TabIndex = 9;
            txtUtilityName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbUtilityID
            // 
            cbbUtilityID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbUtilityID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbUtilityID.FormattingEnabled = true;
            cbbUtilityID.Location = new Point(160, 240);
            cbbUtilityID.Name = "cbbUtilityID";
            cbbUtilityID.Size = new Size(215, 32);
            cbbUtilityID.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 280);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 186;
            label2.Text = "Utility Name:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 496);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(560, 29);
            label17.TabIndex = 180;
            label17.Text = "Payment Details";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 496);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 496);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 16;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 496);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 15;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(25, 400);
            label12.Name = "label12";
            label12.Size = new Size(100, 20);
            label12.TabIndex = 169;
            label12.Text = "Paid Amount";
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Font = new Font("Segoe UI", 12F);
            txtPaidAmount.Location = new Point(160, 400);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new Size(215, 29);
            txtPaidAmount.TabIndex = 13;
            txtPaidAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // txtRemainAmount
            // 
            txtRemainAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtRemainAmount.Location = new Point(160, 440);
            txtRemainAmount.Name = "txtRemainAmount";
            txtRemainAmount.ReadOnly = true;
            txtRemainAmount.Size = new Size(215, 27);
            txtRemainAmount.TabIndex = 14;
            // 
            // labelMajorID
            // 
            labelMajorID.AutoSize = true;
            labelMajorID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMajorID.Location = new Point(25, 440);
            labelMajorID.Name = "labelMajorID";
            labelMajorID.Size = new Size(124, 20);
            labelMajorID.TabIndex = 107;
            labelMajorID.Text = "Remain Amount";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 122, 183);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(980, 30);
            label1.TabIndex = 181;
            label1.Text = "Payment Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPayment
            // 
            dgvPayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayment.Location = new Point(561, 79);
            dgvPayment.Name = "dgvPayment";
            dgvPayment.Size = new Size(419, 580);
            dgvPayment.TabIndex = 19;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(980, 657);
            Controls.Add(dgvPayment);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(txtSearchPayment);
            Controls.Add(labelSearch);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaymentForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtPaymentDate;
        private TextBox txtPaymentNo;
        private Label labelPaymentDate;
        private Label LabelPaymentNo;
        private TextBox txtSearchPayment;
        private Label labelSearch;
        private ComboBox cbbReservationID;
        private CheckBox cbUtilityID;
        private Label label5;
        private Label labelPaymentAmount;
        private Label label4;
        private TextBox txtStaffName;
        private Label label6;
        private ComboBox cbbStaffID;
        private Panel panel1;
        private Label label1;
        private Label label17;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private Button btnNew;
        private DataGridView dgvPayment;
        private TextBox txtUtilityName;
        private ComboBox cbbUtilityID;
        private Label label2;
        private Label label12;
        private TextBox txtPaidAmount;
        private TextBox txtRemainAmount;
        private Label labelMajorID;
        private TextBox txtServiceName;
        private ComboBox cbbServiceID;
        private Label label3;
        private Label label7;
        private CheckBox cbServiceID;
    }
}