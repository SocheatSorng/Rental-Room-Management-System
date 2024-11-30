﻿namespace RRMS.Forms
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
            txtResPro = new TextBox();
            label10 = new Label();
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
            dtpResBOD = new DateTimePicker();
            dtpResCID = new DateTimePicker();
            dtpResCOD = new DateTimePicker();
            panel1 = new Panel();
            label17 = new Label();
            titleLabel = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 36);
            label1.Name = "label1";
            label1.Size = new Size(80, 18);
            label1.TabIndex = 0;
            label1.Text = "ResidentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 174);
            label2.Name = "label2";
            label2.Size = new Size(102, 18);
            label2.TabIndex = 1;
            label2.Text = "Resident Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 74);
            label3.Name = "label3";
            label3.Size = new Size(110, 18);
            label3.TabIndex = 2;
            label3.Text = "Resident Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 217);
            label4.Name = "label4";
            label4.Size = new Size(33, 18);
            label4.TabIndex = 3;
            label4.Text = "Sex";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 29);
            label5.Name = "label5";
            label5.Size = new Size(80, 18);
            label5.TabIndex = 4;
            label5.Text = "House No.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 128);
            label6.Name = "label6";
            label6.Size = new Size(73, 18);
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
            groupBox1.Location = new Point(12, 255);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(543, 176);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Previous Address";
            // 
            // txtResPro
            // 
            txtResPro.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResPro.Location = new Point(155, 121);
            txtResPro.Name = "txtResPro";
            txtResPro.Size = new Size(100, 24);
            txtResPro.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(16, 124);
            label10.Name = "label10";
            label10.Size = new Size(66, 18);
            label10.TabIndex = 25;
            label10.Text = "Province";
            // 
            // txtResDis
            // 
            txtResDis.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResDis.Location = new Point(360, 79);
            txtResDis.Name = "txtResDis";
            txtResDis.Size = new Size(123, 24);
            txtResDis.TabIndex = 24;
            // 
            // txtResCom
            // 
            txtResCom.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResCom.Location = new Point(155, 76);
            txtResCom.Name = "txtResCom";
            txtResCom.Size = new Size(100, 24);
            txtResCom.TabIndex = 23;
            // 
            // txtResStNo
            // 
            txtResStNo.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResStNo.Location = new Point(360, 21);
            txtResStNo.Name = "txtResStNo";
            txtResStNo.Size = new Size(123, 24);
            txtResStNo.TabIndex = 22;
            // 
            // txtResHNo
            // 
            txtResHNo.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResHNo.Location = new Point(154, 21);
            txtResHNo.Name = "txtResHNo";
            txtResHNo.Size = new Size(100, 24);
            txtResHNo.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 171);
            label11.Name = "label11";
            label11.Size = new Size(0, 18);
            label11.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(275, 82);
            label9.Name = "label9";
            label9.Size = new Size(54, 18);
            label9.TabIndex = 7;
            label9.Text = "District";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(13, 76);
            label8.Name = "label8";
            label8.Size = new Size(78, 18);
            label8.TabIndex = 6;
            label8.Text = "Commune";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(275, 24);
            label7.Name = "label7";
            label7.Size = new Size(75, 18);
            label7.TabIndex = 5;
            label7.Text = "Street No.";
            // 
            // txtResPN
            // 
            txtResPN.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResPN.Location = new Point(166, 441);
            txtResPN.Name = "txtResPN";
            txtResPN.Size = new Size(100, 24);
            txtResPN.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 444);
            label12.Name = "label12";
            label12.Size = new Size(124, 18);
            label12.TabIndex = 7;
            label12.Text = "Personal Number";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(12, 483);
            label13.Name = "label13";
            label13.Size = new Size(117, 18);
            label13.TabIndex = 8;
            label13.Text = "Contact Number";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(16, 528);
            label14.Name = "label14";
            label14.Size = new Size(102, 18);
            label14.TabIndex = 9;
            label14.Text = "Check-In Date";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(16, 568);
            label15.Name = "label15";
            label15.Size = new Size(115, 18);
            label15.TabIndex = 10;
            label15.Text = "Check-Out Date";
            // 
            // dgvRes
            // 
            dgvRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRes.Location = new Point(537, 71);
            dgvRes.Name = "dgvRes";
            dgvRes.Size = new Size(481, 620);
            dgvRes.TabIndex = 11;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(46, 611);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 2;
            btnNew.Text = "Clear";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(161, 611);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(279, 611);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(389, 611);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtResID
            // 
            txtResID.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResID.Location = new Point(161, 31);
            txtResID.Name = "txtResID";
            txtResID.Size = new Size(100, 24);
            txtResID.TabIndex = 3;
            // 
            // txtResType
            // 
            txtResType.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResType.Location = new Point(162, 174);
            txtResType.Name = "txtResType";
            txtResType.Size = new Size(100, 24);
            txtResType.TabIndex = 17;
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(161, 80);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(100, 24);
            txtResName.TabIndex = 18;
            // 
            // txtResSex
            // 
            txtResSex.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResSex.Location = new Point(161, 214);
            txtResSex.Name = "txtResSex";
            txtResSex.Size = new Size(100, 24);
            txtResSex.TabIndex = 19;
            // 
            // txtResCN
            // 
            txtResCN.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResCN.Location = new Point(166, 477);
            txtResCN.Name = "txtResCN";
            txtResCN.Size = new Size(100, 24);
            txtResCN.TabIndex = 27;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(537, 43);
            label16.Name = "label16";
            label16.Size = new Size(55, 18);
            label16.TabIndex = 30;
            label16.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(607, 43);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(411, 23);
            txtSearch.TabIndex = 31;
            // 
            // dtpResBOD
            // 
            dtpResBOD.Location = new Point(162, 132);
            dtpResBOD.Name = "dtpResBOD";
            dtpResBOD.Size = new Size(200, 23);
            dtpResBOD.TabIndex = 33;
            // 
            // dtpResCID
            // 
            dtpResCID.Location = new Point(166, 523);
            dtpResCID.Name = "dtpResCID";
            dtpResCID.Size = new Size(200, 23);
            dtpResCID.TabIndex = 34;
            // 
            // dtpResCOD
            // 
            dtpResCOD.Location = new Point(166, 565);
            dtpResCOD.Name = "dtpResCOD";
            dtpResCOD.Size = new Size(200, 23);
            dtpResCOD.TabIndex = 35;
            // 
            // panel1
            // 
            panel1.Controls.Add(label17);
            panel1.Controls.Add(txtResPN);
            panel1.Controls.Add(dtpResCOD);
            panel1.Controls.Add(dtpResCID);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(dtpResBOD);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtResCN);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtResSex);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(txtResType);
            panel1.Controls.Add(txtResID);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(508, 648);
            panel1.TabIndex = 36;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(508, 29);
            label17.TabIndex = 48;
            label17.Text = "Resident Details";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1030, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Resident Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormResident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 705);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(txtSearch);
            Controls.Add(label16);
            Controls.Add(dgvRes);
            Name = "FormResident";
            Text = "Resident";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private DateTimePicker dtpResBOD;
        private DateTimePicker dtpResCID;
        private DateTimePicker dtpResCOD;
        private Label label10;
        private TextBox txtResPro;
        private Panel panel1;
        private Label titleLabel;
        private Label label17;
    }
}