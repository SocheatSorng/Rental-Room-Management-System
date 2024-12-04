﻿namespace RRMS.Forms
{
    partial class FormAmenity
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
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtAmeID = new TextBox();
            txtAmeName = new TextBox();
            txtAmeBP = new TextBox();
            txtAmeCPR = new TextBox();
            txtAmeDesc = new TextBox();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvAme = new DataGridView();
            dtpAmeMD = new DateTimePicker();
            panel1 = new Panel();
            label10 = new Label();
            titleLabel = new Label();
            label9 = new Label();
            txtSearch = new TextBox();
            label3 = new Label();
            txtRoomNum = new TextBox();
            label4 = new Label();
            cbbRoomID = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAme).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 43);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Amenity ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 74);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 113);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Bought Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 151);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 5;
            label6.Text = "Cost Per Rent";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 221);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 7;
            label8.Text = "Description";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 188);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 6;
            label7.Text = "Maintenance Date";
            // 
            // txtAmeID
            // 
            txtAmeID.Location = new Point(134, 39);
            txtAmeID.Name = "txtAmeID";
            txtAmeID.ReadOnly = true;
            txtAmeID.Size = new Size(200, 23);
            txtAmeID.TabIndex = 2;
            // 
            // txtAmeName
            // 
            txtAmeName.Location = new Point(134, 74);
            txtAmeName.Name = "txtAmeName";
            txtAmeName.Size = new Size(200, 23);
            txtAmeName.TabIndex = 3;
            // 
            // txtAmeBP
            // 
            txtAmeBP.Location = new Point(134, 113);
            txtAmeBP.Name = "txtAmeBP";
            txtAmeBP.Size = new Size(200, 23);
            txtAmeBP.TabIndex = 4;
            // 
            // txtAmeCPR
            // 
            txtAmeCPR.Location = new Point(134, 151);
            txtAmeCPR.Name = "txtAmeCPR";
            txtAmeCPR.Size = new Size(200, 23);
            txtAmeCPR.TabIndex = 5;
            // 
            // txtAmeDesc
            // 
            txtAmeDesc.Location = new Point(134, 221);
            txtAmeDesc.Name = "txtAmeDesc";
            txtAmeDesc.Size = new Size(200, 23);
            txtAmeDesc.TabIndex = 7;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(12, 320);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 26);
            btnNew.TabIndex = 10;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(98, 320);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(80, 26);
            btnInsert.TabIndex = 11;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(184, 320);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 26);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(270, 320);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 26);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvAme
            // 
            dgvAme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAme.Location = new Point(371, 76);
            dgvAme.Name = "dgvAme";
            dgvAme.Size = new Size(661, 654);
            dgvAme.TabIndex = 14;
            // 
            // dtpAmeMD
            // 
            dtpAmeMD.Location = new Point(134, 188);
            dtpAmeMD.Name = "dtpAmeMD";
            dtpAmeMD.Size = new Size(200, 23);
            dtpAmeMD.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbRoomID);
            panel1.Controls.Add(txtRoomNum);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtAmeDesc);
            panel1.Controls.Add(dtpAmeMD);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtAmeCPR);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtAmeBP);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtAmeName);
            panel1.Controls.Add(txtAmeID);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(353, 697);
            panel1.TabIndex = 25;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(353, 29);
            label10.TabIndex = 48;
            label10.Text = "Amenity Details";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1044, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Amenity Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(377, 45);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 49;
            label9.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(425, 42);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(607, 23);
            txtSearch.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 252);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 49;
            label3.Text = "Room ID";
            // 
            // txtRoomNum
            // 
            txtRoomNum.Location = new Point(134, 281);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.Size = new Size(200, 23);
            txtRoomNum.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 281);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 51;
            label4.Text = "Room Number";
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(134, 252);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(200, 23);
            cbbRoomID.TabIndex = 8;
            // 
            // FormAmenity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(txtSearch);
            Controls.Add(label9);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvAme);
            Name = "FormAmenity";
            Text = "Amenity";
            ((System.ComponentModel.ISupportInitialize)dgvAme).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private TextBox txtAmeID;
        private TextBox txtAmeName;
        private TextBox txtAmeBP;
        private TextBox txtAmeCPR;
        private TextBox txtAmeDesc;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvAme;
        private DateTimePicker dtpAmeMD;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private Label label9;
        private TextBox txtSearch;
        private ComboBox cbbRoomID;
        private TextBox txtRoomNum;
        private Label label4;
        private Label label3;
    }
}