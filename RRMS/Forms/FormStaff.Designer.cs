namespace RRMS.Forms
{
    partial class FormStaff
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
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtStaID = new TextBox();
            txtStaFN = new TextBox();
            txtStaLN = new TextBox();
            txtStaSex = new TextBox();
            txtStaHNo = new TextBox();
            txtStaSNo = new TextBox();
            txtStaCom = new TextBox();
            txtStaDis = new TextBox();
            txtStaPro = new TextBox();
            txtStaPN = new TextBox();
            txtStaSal = new TextBox();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvSta = new DataGridView();
            dtpStaBD = new DateTimePicker();
            dtpStaHD = new DateTimePicker();
            panel1 = new Panel();
            cbbStaPos = new ComboBox();
            dtpStaStop = new DateTimePicker();
            label5 = new Label();
            titleLabel = new Label();
            label17 = new Label();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSta).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 0;
            label1.Text = "Staff ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 70);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 1;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 460);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 2;
            label3.Text = "Stopped Work";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 430);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 3;
            label4.Text = "HiredDate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 400);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 5;
            label6.Text = "Salary";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 370);
            label7.Name = "label7";
            label7.Size = new Size(131, 20);
            label7.TabIndex = 6;
            label7.Text = "Personal Number";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(25, 340);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 7;
            label8.Text = "Province";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(25, 310);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 8;
            label9.Text = "District";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(25, 280);
            label10.Name = "label10";
            label10.Size = new Size(82, 20);
            label10.TabIndex = 9;
            label10.Text = "Commune";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(25, 250);
            label11.Name = "label11";
            label11.Size = new Size(81, 20);
            label11.TabIndex = 10;
            label11.Text = "Street No.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(25, 220);
            label12.Name = "label12";
            label12.Size = new Size(84, 20);
            label12.TabIndex = 11;
            label12.Text = "House No.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(25, 190);
            label13.Name = "label13";
            label13.Size = new Size(65, 20);
            label13.TabIndex = 12;
            label13.Text = "Position";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(25, 160);
            label14.Name = "label14";
            label14.Size = new Size(81, 20);
            label14.TabIndex = 13;
            label14.Text = "Birth Date";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(25, 130);
            label15.Name = "label15";
            label15.Size = new Size(36, 20);
            label15.TabIndex = 14;
            label15.Text = "Sex";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(25, 100);
            label16.Name = "label16";
            label16.Size = new Size(86, 20);
            label16.TabIndex = 15;
            label16.Text = "Last Name";
            // 
            // txtStaID
            // 
            txtStaID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaID.Location = new Point(170, 40);
            txtStaID.Name = "txtStaID";
            txtStaID.ReadOnly = true;
            txtStaID.Size = new Size(224, 26);
            txtStaID.TabIndex = 2;
            // 
            // txtStaFN
            // 
            txtStaFN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaFN.Location = new Point(170, 70);
            txtStaFN.Name = "txtStaFN";
            txtStaFN.Size = new Size(224, 26);
            txtStaFN.TabIndex = 3;
            // 
            // txtStaLN
            // 
            txtStaLN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaLN.Location = new Point(170, 100);
            txtStaLN.Name = "txtStaLN";
            txtStaLN.Size = new Size(224, 26);
            txtStaLN.TabIndex = 4;
            // 
            // txtStaSex
            // 
            txtStaSex.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaSex.Location = new Point(170, 130);
            txtStaSex.Name = "txtStaSex";
            txtStaSex.Size = new Size(224, 26);
            txtStaSex.TabIndex = 5;
            // 
            // txtStaHNo
            // 
            txtStaHNo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaHNo.Location = new Point(170, 220);
            txtStaHNo.Name = "txtStaHNo";
            txtStaHNo.Size = new Size(224, 26);
            txtStaHNo.TabIndex = 8;
            // 
            // txtStaSNo
            // 
            txtStaSNo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaSNo.Location = new Point(170, 250);
            txtStaSNo.Name = "txtStaSNo";
            txtStaSNo.Size = new Size(224, 26);
            txtStaSNo.TabIndex = 9;
            // 
            // txtStaCom
            // 
            txtStaCom.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaCom.Location = new Point(170, 280);
            txtStaCom.Name = "txtStaCom";
            txtStaCom.Size = new Size(224, 26);
            txtStaCom.TabIndex = 10;
            // 
            // txtStaDis
            // 
            txtStaDis.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaDis.Location = new Point(170, 310);
            txtStaDis.Name = "txtStaDis";
            txtStaDis.Size = new Size(224, 26);
            txtStaDis.TabIndex = 11;
            // 
            // txtStaPro
            // 
            txtStaPro.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaPro.Location = new Point(170, 340);
            txtStaPro.Name = "txtStaPro";
            txtStaPro.Size = new Size(224, 26);
            txtStaPro.TabIndex = 12;
            // 
            // txtStaPN
            // 
            txtStaPN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaPN.Location = new Point(170, 370);
            txtStaPN.Name = "txtStaPN";
            txtStaPN.Size = new Size(224, 26);
            txtStaPN.TabIndex = 13;
            // 
            // txtStaSal
            // 
            txtStaSal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaSal.Location = new Point(170, 400);
            txtStaSal.Name = "txtStaSal";
            txtStaSal.Size = new Size(224, 26);
            txtStaSal.TabIndex = 14;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 506);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(72, 26);
            btnNew.TabIndex = 17;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(123, 506);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(72, 26);
            btnInsert.TabIndex = 18;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(223, 506);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(72, 26);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(322, 506);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(72, 26);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvSta
            // 
            dgvSta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSta.Location = new Point(550, 64);
            dgvSta.Name = "dgvSta";
            dgvSta.Size = new Size(482, 596);
            dgvSta.TabIndex = 21;
            // 
            // dtpStaBD
            // 
            dtpStaBD.Location = new Point(170, 160);
            dtpStaBD.Name = "dtpStaBD";
            dtpStaBD.Size = new Size(224, 23);
            dtpStaBD.TabIndex = 6;
            // 
            // dtpStaHD
            // 
            dtpStaHD.Location = new Point(170, 430);
            dtpStaHD.Name = "dtpStaHD";
            dtpStaHD.Size = new Size(224, 23);
            dtpStaHD.TabIndex = 15;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbStaPos);
            panel1.Controls.Add(dtpStaStop);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(dtpStaHD);
            panel1.Controls.Add(txtStaSal);
            panel1.Controls.Add(dtpStaBD);
            panel1.Controls.Add(txtStaPN);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtStaPro);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtStaDis);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(txtStaCom);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtStaSNo);
            panel1.Controls.Add(txtStaHNo);
            panel1.Controls.Add(txtStaSex);
            panel1.Controls.Add(txtStaLN);
            panel1.Controls.Add(txtStaFN);
            panel1.Controls.Add(txtStaID);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 42;
            // 
            // cbbStaPos
            // 
            cbbStaPos.FormattingEnabled = true;
            cbbStaPos.Location = new Point(170, 190);
            cbbStaPos.Name = "cbbStaPos";
            cbbStaPos.Size = new Size(224, 23);
            cbbStaPos.TabIndex = 7;
            // 
            // dtpStaStop
            // 
            dtpStaStop.Location = new Point(170, 460);
            dtpStaStop.Name = "dtpStaStop";
            dtpStaStop.Size = new Size(224, 23);
            dtpStaStop.TabIndex = 16;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 122, 183);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(550, 29);
            label5.TabIndex = 48;
            label5.Text = "Staff Details";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(984, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Staff Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(550, 40);
            label17.Name = "label17";
            label17.Size = new Size(68, 20);
            label17.TabIndex = 49;
            label17.Text = "Search: ";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(626, 34);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(406, 23);
            txtSearch.TabIndex = 1;
            // 
            // FormStaff
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(txtSearch);
            Controls.Add(label17);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvSta);
            Name = "FormStaff";
            Text = "Staff";
            ((System.ComponentModel.ISupportInitialize)dgvSta).EndInit();
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
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox txtStaID;
        private TextBox txtStaFN;
        private TextBox txtStaLN;
        private TextBox txtStaSex;
        private TextBox txtStaHNo;
        private TextBox txtStaSNo;
        private TextBox txtStaCom;
        private TextBox txtStaDis;
        private TextBox txtStaPro;
        private TextBox txtStaPN;
        private TextBox txtStaSal;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvSta;
        private DateTimePicker dtpStaBD;
        private DateTimePicker dtpStaHD;
        private Panel panel1;
        private Label titleLabel;
        private Label label5;
        private Label label17;
        private TextBox txtSearch;
        private DateTimePicker dtpStaStop;
        private ComboBox cbbStaPos;
    }
}