namespace RRMS.Forms
{
    partial class FormResident
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            txtResDis = new TextBox();
            txtResCom = new TextBox();
            txtResStNo = new TextBox();
            txtResHNo = new TextBox();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtResPN = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            dgvRes = new DataGridView();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtResID = new TextBox();
            txtResType = new TextBox();
            txtResName = new TextBox();
            txtResSex = new TextBox();
            txtResCN = new TextBox();
            label16 = new Label();
            txtSearch = new TextBox();
            btnClose = new Button();
            dtpResBOD = new DateTimePicker();
            dtpResCID = new DateTimePicker();
            dtpResCOD = new DateTimePicker();
            label10 = new Label();
            txtResPro = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(267, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 27);
            label1.TabIndex = 0;
            label1.Text = "ResidentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(546, 7);
            label2.Name = "label2";
            label2.Size = new Size(105, 27);
            label2.TabIndex = 1;
            label2.Text = "Resident Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(266, 47);
            label3.Name = "label3";
            label3.Size = new Size(112, 27);
            label3.TabIndex = 2;
            label3.Text = "Resident Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(575, 47);
            label4.Name = "label4";
            label4.Size = new Size(36, 27);
            label4.TabIndex = 3;
            label4.Text = "Sex";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 29);
            label5.Name = "label5";
            label5.Size = new Size(81, 27);
            label5.TabIndex = 4;
            label5.Text = "House No.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(267, 101);
            label6.Name = "label6";
            label6.Size = new Size(76, 27);
            label6.TabIndex = 5;
            label6.Text = "Birth Date";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtResPro);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtResDis);
            groupBox1.Controls.Add(txtResCom);
            groupBox1.Controls.Add(txtResStNo);
            groupBox1.Controls.Add(txtResHNo);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(257, 172);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(543, 176);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Previous Address";
            // 
            // txtResDis
            // 
            txtResDis.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResDis.Location = new Point(436, 76);
            txtResDis.Name = "txtResDis";
            txtResDis.Size = new Size(100, 35);
            txtResDis.TabIndex = 24;
            // 
            // txtResCom
            // 
            txtResCom.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResCom.Location = new Point(155, 76);
            txtResCom.Name = "txtResCom";
            txtResCom.Size = new Size(100, 35);
            txtResCom.TabIndex = 23;
            // 
            // txtResStNo
            // 
            txtResStNo.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResStNo.Location = new Point(436, 21);
            txtResStNo.Name = "txtResStNo";
            txtResStNo.Size = new Size(100, 35);
            txtResStNo.TabIndex = 22;
            // 
            // txtResHNo
            // 
            txtResHNo.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResHNo.Location = new Point(154, 21);
            txtResHNo.Name = "txtResHNo";
            txtResHNo.Size = new Size(100, 35);
            txtResHNo.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 171);
            label11.Name = "label11";
            label11.Size = new Size(0, 27);
            label11.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(298, 84);
            label9.Name = "label9";
            label9.Size = new Size(57, 27);
            label9.TabIndex = 7;
            label9.Text = "District";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(13, 76);
            label8.Name = "label8";
            label8.Size = new Size(81, 27);
            label8.TabIndex = 6;
            label8.Text = "Commune";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(298, 24);
            label7.Name = "label7";
            label7.Size = new Size(76, 27);
            label7.TabIndex = 5;
            label7.Text = "Street No.";
            // 
            // txtResPN
            // 
            txtResPN.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResPN.Location = new Point(420, 382);
            txtResPN.Name = "txtResPN";
            txtResPN.Size = new Size(100, 35);
            txtResPN.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(258, 382);
            label12.Name = "label12";
            label12.Size = new Size(127, 27);
            label12.TabIndex = 7;
            label12.Text = "Personal Number";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(546, 387);
            label13.Name = "label13";
            label13.Size = new Size(119, 27);
            label13.TabIndex = 8;
            label13.Text = "Contact Number";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(266, 438);
            label14.Name = "label14";
            label14.Size = new Size(107, 27);
            label14.TabIndex = 9;
            label14.Text = "Check-In Date";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(257, 497);
            label15.Name = "label15";
            label15.Size = new Size(116, 27);
            label15.TabIndex = 10;
            label15.Text = "Check-Out Date";
            // 
            // dgvRes
            // 
            dgvRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRes.Location = new Point(12, 47);
            dgvRes.Name = "dgvRes";
            dgvRes.Size = new Size(227, 498);
            dgvRes.TabIndex = 11;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(255, 255, 128);
            btnNew.FlatStyle = FlatStyle.Popup;
            btnNew.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNew.Location = new Point(836, 16);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(97, 42);
            btnNew.TabIndex = 12;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(255, 255, 128);
            btnInsert.FlatStyle = FlatStyle.Popup;
            btnInsert.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInsert.Location = new Point(836, 67);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(97, 42);
            btnInsert.TabIndex = 13;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 255, 128);
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(836, 125);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(97, 42);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 255, 128);
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(836, 171);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(97, 42);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtResID
            // 
            txtResID.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResID.Location = new Point(411, 4);
            txtResID.Name = "txtResID";
            txtResID.Size = new Size(100, 35);
            txtResID.TabIndex = 3;
            // 
            // txtResType
            // 
            txtResType.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResType.Location = new Point(672, 6);
            txtResType.Name = "txtResType";
            txtResType.Size = new Size(100, 35);
            txtResType.TabIndex = 17;
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(411, 53);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(100, 35);
            txtResName.TabIndex = 18;
            // 
            // txtResSex
            // 
            txtResSex.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResSex.Location = new Point(672, 53);
            txtResSex.Name = "txtResSex";
            txtResSex.Size = new Size(100, 35);
            txtResSex.TabIndex = 19;
            // 
            // txtResCN
            // 
            txtResCN.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResCN.Location = new Point(684, 379);
            txtResCN.Name = "txtResCN";
            txtResCN.Size = new Size(100, 35);
            txtResCN.TabIndex = 27;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(12, 20);
            label16.Name = "label16";
            label16.Size = new Size(59, 27);
            label16.TabIndex = 30;
            label16.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(62, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 31;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(836, 218);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 32;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dtpResBOD
            // 
            dtpResBOD.Location = new Point(412, 105);
            dtpResBOD.Name = "dtpResBOD";
            dtpResBOD.Size = new Size(200, 23);
            dtpResBOD.TabIndex = 33;
            // 
            // dtpResCID
            // 
            dtpResCID.Location = new Point(411, 442);
            dtpResCID.Name = "dtpResCID";
            dtpResCID.Size = new Size(200, 23);
            dtpResCID.TabIndex = 34;
            // 
            // dtpResCOD
            // 
            dtpResCOD.Location = new Point(402, 497);
            dtpResCOD.Name = "dtpResCOD";
            dtpResCOD.Size = new Size(200, 23);
            dtpResCOD.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(16, 124);
            label10.Name = "label10";
            label10.Size = new Size(69, 27);
            label10.TabIndex = 25;
            label10.Text = "Province";
            // 
            // txtResPro
            // 
            txtResPro.Font = new Font("Khmer OS Siemreap", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResPro.Location = new Point(155, 121);
            txtResPro.Name = "txtResPro";
            txtResPro.Size = new Size(100, 35);
            txtResPro.TabIndex = 26;
            // 
            // FormResident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 557);
            Controls.Add(txtResPN);
            Controls.Add(dtpResCOD);
            Controls.Add(dtpResCID);
            Controls.Add(dtpResBOD);
            Controls.Add(btnClose);
            Controls.Add(txtSearch);
            Controls.Add(label16);
            Controls.Add(txtResCN);
            Controls.Add(txtResSex);
            Controls.Add(label12);
            Controls.Add(txtResName);
            Controls.Add(txtResType);
            Controls.Add(txtResID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnNew);
            Controls.Add(dgvRes);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormResident";
            Text = "Resident";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private Label label7;
        private Label label8;
        private TextBox txtResPN; // Resident Personal Number
        private TextBox txtResDis; // Resident District
        private TextBox txtResCom; // Resident Commune
        private TextBox txtResStNo; // Resident Street No.
        private TextBox txtResHNo; // Resident Previous No.
        private Label label11;
        private Label label9;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private DataGridView dgvRes;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtResID; // Resident ID
        private TextBox txtResType; // Resident Type
        private TextBox txtResName; // Resident Name
        private TextBox txtResSex; // Resident Sex
        private TextBox txtResCN; // Resident Contact Number
        private Label label16;
        private TextBox txtSearch;
        private Button btnClose;
        private DateTimePicker dtpResBOD;
        private DateTimePicker dtpResCID;
        private DateTimePicker dtpResCOD;
        private Label label10;
        private TextBox txtResPro;
    }
}