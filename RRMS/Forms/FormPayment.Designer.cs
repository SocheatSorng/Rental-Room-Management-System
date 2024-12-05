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
            txtRemainAmount = new TextBox();
            txtPaymentNo = new TextBox();
            labelMajorID = new Label();
            labelPaymentDate = new Label();
            LabelPaymentNo = new Label();
            txtSearchPayment = new TextBox();
            labelSearch = new Label();
            cbbReservationID = new ComboBox();
            label12 = new Label();
            txtPaidAmount = new TextBox();
            cbUtilityID = new CheckBox();
            label5 = new Label();
            labelPaymentAmount = new Label();
            label4 = new Label();
            txtStaffName = new TextBox();
            label6 = new Label();
            cbbStaffID = new ComboBox();
            panel1 = new Panel();
            txtServiceType = new TextBox();
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
            label1 = new Label();
            dgvPayment = new DataGridView();
            cbReservationID = new CheckBox();
            txtTotalAmount = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayment).BeginInit();
            SuspendLayout();
            // 
            // dtPaymentDate
            // 
            dtPaymentDate.CustomFormat = "yyyy/MM/dd";
            dtPaymentDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtPaymentDate.Location = new Point(140, 76);
            dtPaymentDate.Name = "dtPaymentDate";
            dtPaymentDate.Size = new Size(264, 24);
            dtPaymentDate.TabIndex = 118;
            // 
            // txtRemainAmount
            // 
            txtRemainAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtRemainAmount.Location = new Point(138, 454);
            txtRemainAmount.Name = "txtRemainAmount";
            txtRemainAmount.ReadOnly = true;
            txtRemainAmount.Size = new Size(261, 27);
            txtRemainAmount.TabIndex = 113;
            // 
            // txtPaymentNo
            // 
            txtPaymentNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentNo.Location = new Point(140, 34);
            txtPaymentNo.Name = "txtPaymentNo";
            txtPaymentNo.ReadOnly = true;
            txtPaymentNo.Size = new Size(261, 27);
            txtPaymentNo.TabIndex = 111;
            // 
            // labelMajorID
            // 
            labelMajorID.AutoSize = true;
            labelMajorID.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelMajorID.Location = new Point(12, 461);
            labelMajorID.Name = "labelMajorID";
            labelMajorID.Size = new Size(114, 18);
            labelMajorID.TabIndex = 107;
            labelMajorID.Text = "Remain Amount";
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelPaymentDate.Location = new Point(12, 81);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(101, 18);
            labelPaymentDate.TabIndex = 104;
            labelPaymentDate.Text = "Payment Date";
            // 
            // LabelPaymentNo
            // 
            LabelPaymentNo.AutoSize = true;
            LabelPaymentNo.Font = new Font("Microsoft Sans Serif", 11.25F);
            LabelPaymentNo.Location = new Point(12, 43);
            LabelPaymentNo.Name = "LabelPaymentNo";
            LabelPaymentNo.Size = new Size(90, 18);
            LabelPaymentNo.TabIndex = 103;
            LabelPaymentNo.Text = "Payment No";
            // 
            // txtSearchPayment
            // 
            txtSearchPayment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            txtSearchPayment.Location = new Point(509, 43);
            txtSearchPayment.Name = "txtSearchPayment";
            txtSearchPayment.Size = new Size(519, 24);
            txtSearchPayment.TabIndex = 101;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelSearch.Location = new Point(427, 46);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(76, 18);
            labelSearch.TabIndex = 100;
            labelSearch.Text = "Search By";
            // 
            // cbbReservationID
            // 
            cbbReservationID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbReservationID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbReservationID.FormattingEnabled = true;
            cbbReservationID.Location = new Point(141, 118);
            cbbReservationID.Name = "cbbReservationID";
            cbbReservationID.Size = new Size(261, 32);
            cbbReservationID.TabIndex = 114;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 11.25F);
            label12.Location = new Point(12, 418);
            label12.Name = "label12";
            label12.Size = new Size(92, 18);
            label12.TabIndex = 169;
            label12.Text = "Paid Amount";
            // 
            // txtPaidAmount
            // 
            txtPaidAmount.Font = new Font("Segoe UI", 12F);
            txtPaidAmount.Location = new Point(139, 407);
            txtPaidAmount.Name = "txtPaidAmount";
            txtPaidAmount.Size = new Size(261, 29);
            txtPaidAmount.TabIndex = 168;
            txtPaidAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // cbUtilityID
            // 
            cbUtilityID.AutoSize = true;
            cbUtilityID.Font = new Font("Microsoft Sans Serif", 11.25F);
            cbUtilityID.Location = new Point(117, 252);
            cbUtilityID.Name = "cbUtilityID";
            cbUtilityID.Size = new Size(15, 14);
            cbUtilityID.TabIndex = 172;
            cbUtilityID.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F);
            label5.Location = new Point(12, 248);
            label5.Name = "label5";
            label5.Size = new Size(65, 18);
            label5.TabIndex = 173;
            label5.Text = "Utility ID:";
            // 
            // labelPaymentAmount
            // 
            labelPaymentAmount.AutoSize = true;
            labelPaymentAmount.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelPaymentAmount.Location = new Point(12, 132);
            labelPaymentAmount.Name = "labelPaymentAmount";
            labelPaymentAmount.Size = new Size(105, 18);
            labelPaymentAmount.TabIndex = 105;
            labelPaymentAmount.Text = "Reservation ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F);
            label4.Location = new Point(12, 170);
            label4.Name = "label4";
            label4.Size = new Size(60, 18);
            label4.TabIndex = 175;
            label4.Text = "Staff ID:";
            // 
            // txtStaffName
            // 
            txtStaffName.Location = new Point(141, 208);
            txtStaffName.Margin = new Padding(3, 2, 3, 2);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(261, 23);
            txtStaffName.TabIndex = 178;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F);
            label6.Location = new Point(12, 213);
            label6.Name = "label6";
            label6.Size = new Size(86, 18);
            label6.TabIndex = 177;
            label6.Text = "Staff Name:";
            // 
            // cbbStaffID
            // 
            cbbStaffID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbStaffID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbStaffID.FormattingEnabled = true;
            cbbStaffID.Location = new Point(140, 163);
            cbbStaffID.Name = "cbbStaffID";
            cbbStaffID.Size = new Size(264, 32);
            cbbStaffID.TabIndex = 179;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtTotalAmount);
            panel1.Controls.Add(cbReservationID);
            panel1.Controls.Add(txtServiceType);
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
            panel1.Location = new Point(12, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(410, 688);
            panel1.TabIndex = 180;
            // 
            // txtServiceType
            // 
            txtServiceType.Font = new Font("Segoe UI", 12F);
            txtServiceType.Location = new Point(138, 363);
            txtServiceType.Name = "txtServiceType";
            txtServiceType.ReadOnly = true;
            txtServiceType.Size = new Size(261, 29);
            txtServiceType.TabIndex = 193;
            txtServiceType.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbServiceID
            // 
            cbbServiceID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbServiceID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbServiceID.FormattingEnabled = true;
            cbbServiceID.Location = new Point(138, 320);
            cbbServiceID.Name = "cbbServiceID";
            cbbServiceID.Size = new Size(264, 32);
            cbbServiceID.TabIndex = 192;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F);
            label3.Location = new Point(12, 374);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 191;
            label3.Text = "Service Type";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 11.25F);
            label7.Location = new Point(12, 327);
            label7.Name = "label7";
            label7.Size = new Size(83, 18);
            label7.TabIndex = 190;
            label7.Text = "Service ID :";
            // 
            // cbServiceID
            // 
            cbServiceID.AutoSize = true;
            cbServiceID.Font = new Font("Microsoft Sans Serif", 11.25F);
            cbServiceID.Location = new Point(117, 331);
            cbServiceID.Name = "cbServiceID";
            cbServiceID.Size = new Size(15, 14);
            cbServiceID.TabIndex = 189;
            cbServiceID.UseVisualStyleBackColor = true;
            // 
            // txtUtilityName
            // 
            txtUtilityName.Font = new Font("Segoe UI", 12F);
            txtUtilityName.Location = new Point(138, 284);
            txtUtilityName.Name = "txtUtilityName";
            txtUtilityName.ReadOnly = true;
            txtUtilityName.Size = new Size(261, 29);
            txtUtilityName.TabIndex = 188;
            txtUtilityName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbUtilityID
            // 
            cbbUtilityID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbUtilityID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbUtilityID.FormattingEnabled = true;
            cbbUtilityID.Location = new Point(138, 241);
            cbbUtilityID.Name = "cbbUtilityID";
            cbbUtilityID.Size = new Size(264, 32);
            cbbUtilityID.TabIndex = 187;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F);
            label2.Location = new Point(12, 295);
            label2.Name = "label2";
            label2.Size = new Size(91, 18);
            label2.TabIndex = 186;
            label2.Text = "Utility Name:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(316, 497);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 184;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(410, 29);
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
            btnUpdate.Location = new Point(210, 497);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 183;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(109, 497);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 182;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(10, 497);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 185;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 122, 183);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1040, 30);
            label1.TabIndex = 181;
            label1.Text = "Payment Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPayment
            // 
            dgvPayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayment.Location = new Point(428, 79);
            dgvPayment.Name = "dgvPayment";
            dgvPayment.Size = new Size(612, 647);
            dgvPayment.TabIndex = 182;
            // 
            // cbReservationID
            // 
            cbReservationID.AutoSize = true;
            cbReservationID.Font = new Font("Microsoft Sans Serif", 11.25F);
            cbReservationID.Location = new Point(120, 132);
            cbReservationID.Name = "cbReservationID";
            cbReservationID.Size = new Size(15, 14);
            cbReservationID.TabIndex = 194;
            cbReservationID.UseVisualStyleBackColor = true;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Font = new Font("Segoe UI", 12F);
            txtTotalAmount.Location = new Point(138, 544);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(261, 29);
            txtTotalAmount.TabIndex = 195;
            txtTotalAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(1040, 738);
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
        private TextBox txtRemainAmount;
        private TextBox txtPaymentNo;
        private Label labelMajorID;
        private Label labelPaymentDate;
        private Label LabelPaymentNo;
        private TextBox txtSearchPayment;
        private Label labelSearch;
        private ComboBox cbbReservationID;
        private Label label12;
        private TextBox txtPaidAmount;
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
        private TextBox txtServiceType;
        private ComboBox cbbServiceID;
        private Label label3;
        private Label label7;
        private CheckBox cbServiceID;
        private CheckBox cbReservationID;
        private TextBox txtTotalAmount;
    }
}