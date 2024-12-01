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
            btnNew = new Button();
            dTPaymentDate = new DateTimePicker();
            txtPaymentAmount = new TextBox();
            txtPaymentNo = new TextBox();
            labelMajorID = new Label();
            labelPaymentDate = new Label();
            LabelPaymentNo = new Label();
            lsPayment = new ListBox();
            txtSearchPayment = new TextBox();
            labelSearch = new Label();
            btnClose = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            cBPaymentStatusID = new ComboBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label12 = new Label();
            textBox1 = new TextBox();
            checkBox2 = new CheckBox();
            txtID = new TextBox();
            label5 = new Label();
            labelPaymentAmount = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(25, 149, 173);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnNew.Location = new Point(45, 574);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(121, 49);
            btnNew.TabIndex = 120;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // dTPaymentDate
            // 
            dTPaymentDate.CustomFormat = "yyyy/MM/dd";
            dTPaymentDate.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            dTPaymentDate.Location = new Point(435, 170);
            dTPaymentDate.Name = "dTPaymentDate";
            dTPaymentDate.Size = new Size(327, 27);
            dTPaymentDate.TabIndex = 118;
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentAmount.Location = new Point(438, 349);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.ReadOnly = true;
            txtPaymentAmount.Size = new Size(219, 27);
            txtPaymentAmount.TabIndex = 113;
            // 
            // txtPaymentNo
            // 
            txtPaymentNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentNo.Location = new Point(435, 130);
            txtPaymentNo.Name = "txtPaymentNo";
            txtPaymentNo.ReadOnly = true;
            txtPaymentNo.Size = new Size(219, 27);
            txtPaymentNo.TabIndex = 111;
            // 
            // labelMajorID
            // 
            labelMajorID.AutoSize = true;
            labelMajorID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelMajorID.Location = new Point(261, 349);
            labelMajorID.Name = "labelMajorID";
            labelMajorID.Size = new Size(146, 24);
            labelMajorID.TabIndex = 107;
            labelMajorID.Text = "Remain Amount";
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelPaymentDate.Location = new Point(261, 173);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(128, 24);
            labelPaymentDate.TabIndex = 104;
            labelPaymentDate.Text = "Payment Date";
            // 
            // LabelPaymentNo
            // 
            LabelPaymentNo.AutoSize = true;
            LabelPaymentNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            LabelPaymentNo.Location = new Point(261, 133);
            LabelPaymentNo.Name = "LabelPaymentNo";
            LabelPaymentNo.Size = new Size(112, 24);
            LabelPaymentNo.TabIndex = 103;
            LabelPaymentNo.Text = "Payment No";
            // 
            // lsPayment
            // 
            lsPayment.Font = new Font("Microsoft Sans Serif", 12F);
            lsPayment.FormattingEnabled = true;
            lsPayment.ItemHeight = 20;
            lsPayment.Location = new Point(21, 176);
            lsPayment.Name = "lsPayment";
            lsPayment.Size = new Size(211, 364);
            lsPayment.TabIndex = 102;
            // 
            // txtSearchPayment
            // 
            txtSearchPayment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            txtSearchPayment.Location = new Point(21, 134);
            txtSearchPayment.Name = "txtSearchPayment";
            txtSearchPayment.Size = new Size(211, 24);
            txtSearchPayment.TabIndex = 101;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            labelSearch.Location = new Point(21, 103);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(112, 28);
            labelSearch.TabIndex = 100;
            labelSearch.Text = "Search By";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(255, 128, 128);
            btnClose.FlatAppearance.BorderColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(663, 574);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(121, 49);
            btnClose.TabIndex = 132;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(85, 194, 218);
            btnUpdate.FlatAppearance.BorderColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(474, 574);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 49);
            btnUpdate.TabIndex = 131;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(25, 149, 173);
            btnInsert.FlatAppearance.BorderColor = Color.White;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(255, 574);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(121, 49);
            btnInsert.TabIndex = 130;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 89);
            panel1.TabIndex = 161;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(22, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 163;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 11.249999F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(616, 60);
            label3.Name = "label3";
            label3.Size = new Size(192, 23);
            label3.TabIndex = 76;
            label3.Text = "ISAD M3 GROUP1 2024";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(118, 26);
            label1.Name = "label1";
            label1.Size = new Size(194, 31);
            label1.TabIndex = 73;
            label1.Text = "Payment's Form";
            // 
            // cBPaymentStatusID
            // 
            cBPaymentStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPaymentStatusID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cBPaymentStatusID.FormattingEnabled = true;
            cBPaymentStatusID.Location = new Point(435, 211);
            cBPaymentStatusID.Name = "cBPaymentStatusID";
            cBPaymentStatusID.Size = new Size(219, 32);
            cBPaymentStatusID.TabIndex = 114;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            label2.Location = new Point(261, 393);
            label2.Name = "label2";
            label2.Size = new Size(268, 24);
            label2.TabIndex = 165;
            label2.Text = "Second Amount Has Been Paid";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(555, 398);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 167;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(261, 306);
            label12.Name = "label12";
            label12.Size = new Size(99, 21);
            label12.TabIndex = 169;
            label12.Text = "Paid Amount";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(438, 303);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(219, 29);
            textBox1.TabIndex = 168;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(679, 264);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 172;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            txtID.Location = new Point(435, 260);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(219, 23);
            txtID.TabIndex = 174;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(261, 264);
            label5.Name = "label5";
            label5.Size = new Size(67, 19);
            label5.TabIndex = 173;
            label5.Text = "Utility ID:";
            // 
            // labelPaymentAmount
            // 
            labelPaymentAmount.AutoSize = true;
            labelPaymentAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelPaymentAmount.Location = new Point(261, 219);
            labelPaymentAmount.Name = "labelPaymentAmount";
            labelPaymentAmount.Size = new Size(136, 24);
            labelPaymentAmount.TabIndex = 105;
            labelPaymentAmount.Text = "Reservation ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(264, 437);
            label4.Name = "label4";
            label4.Size = new Size(60, 19);
            label4.TabIndex = 175;
            label4.Text = "Staff ID:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(438, 473);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(219, 23);
            textBox3.TabIndex = 178;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(264, 477);
            label6.Name = "label6";
            label6.Size = new Size(81, 19);
            label6.TabIndex = 177;
            label6.Text = "Staff Name:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(435, 430);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 32);
            comboBox1.TabIndex = 179;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(809, 643);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(txtID);
            Controls.Add(label5);
            Controls.Add(checkBox2);
            Controls.Add(label12);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnNew);
            Controls.Add(dTPaymentDate);
            Controls.Add(cBPaymentStatusID);
            Controls.Add(txtPaymentAmount);
            Controls.Add(txtPaymentNo);
            Controls.Add(labelMajorID);
            Controls.Add(labelPaymentAmount);
            Controls.Add(labelPaymentDate);
            Controls.Add(LabelPaymentNo);
            Controls.Add(lsPayment);
            Controls.Add(txtSearchPayment);
            Controls.Add(labelSearch);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaymentForm";
            Load += FormPayment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnNew;
        private DateTimePicker dTPaymentDate;
        private TextBox txtPaymentAmount;
        private TextBox txtPaymentNo;
        private Label labelMajorID;
        private Label labelPaymentDate;
        private Label LabelPaymentNo;
        private ListBox lsPayment;
        private TextBox txtSearchPayment;
        private Label labelSearch;
        private Button btnClose;
        private Button btnUpdate;
        private Button btnInsert;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private ComboBox cBPaymentStatusID;
        private Label label2;
        private CheckBox checkBox1;
        private Label label12;
        private TextBox textBox1;
        private CheckBox checkBox2;
        private TextBox txtID;
        private Label label5;
        private Label labelPaymentAmount;
        private Label label4;
        private TextBox textBox3;
        private Label label6;
        private ComboBox comboBox1;
    }
}