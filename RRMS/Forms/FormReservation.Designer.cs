namespace RRMS.Forms
{
    partial class FormReservation
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
            dgvReser = new DataGridView();
            column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnNew = new Button();
            btnUpdate = new Button();
            dtpReserED = new DateTimePicker();
            dtpReserSD = new DateTimePicker();
            dtpReserDate = new DateTimePicker();
            txtReserID = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnInsert = new Button();
            txtRoomNum = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            txtReserRem = new TextBox();
            txtReserPA = new TextBox();
            label10 = new Label();
            txtResName = new TextBox();
            cbbRoomID = new ComboBox();
            cbbResID = new ComboBox();
            label8 = new Label();
            titleLabel = new Label();
            label9 = new Label();
            txtSearch = new TextBox();
            txtReserStat = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvReser).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReser
            // 
            dgvReser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReser.Columns.AddRange(new DataGridViewColumn[] { column7, Column1, Column2, Column3, Column4, Column5, Column6 });
            dgvReser.Location = new Point(445, 76);
            dgvReser.Name = "dgvReser";
            dgvReser.Size = new Size(587, 654);
            dgvReser.TabIndex = 37;
            // 
            // column7
            // 
            column7.HeaderText = "ReservationID";
            column7.Name = "column7";
            // 
            // Column1
            // 
            Column1.HeaderText = "ReservationDate";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "StartDate";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "EndDate";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Status";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "ResidentID";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "RoomID";
            Column6.Name = "Column6";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(18, 426);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(221, 426);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dtpReserED
            // 
            dtpReserED.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserED.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserED.Location = new Point(146, 143);
            dtpReserED.Name = "dtpReserED";
            dtpReserED.Size = new Size(263, 24);
            dtpReserED.TabIndex = 30;
            // 
            // dtpReserSD
            // 
            dtpReserSD.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserSD.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserSD.Location = new Point(146, 107);
            dtpReserSD.Name = "dtpReserSD";
            dtpReserSD.Size = new Size(263, 24);
            dtpReserSD.TabIndex = 29;
            // 
            // dtpReserDate
            // 
            dtpReserDate.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserDate.Location = new Point(146, 72);
            dtpReserDate.Name = "dtpReserDate";
            dtpReserDate.Size = new Size(263, 24);
            dtpReserDate.TabIndex = 28;
            // 
            // txtReserID
            // 
            txtReserID.Font = new Font("Segoe UI", 12F);
            txtReserID.Location = new Point(146, 40);
            txtReserID.Name = "txtReserID";
            txtReserID.ReadOnly = true;
            txtReserID.Size = new Size(263, 29);
            txtReserID.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(18, 285);
            label7.Name = "label7";
            label7.Size = new Size(74, 21);
            label7.TabIndex = 26;
            label7.Text = "RoomID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(17, 212);
            label6.Name = "label6";
            label6.Size = new Size(92, 21);
            label6.TabIndex = 25;
            label6.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(17, 183);
            label5.Name = "label5";
            label5.Size = new Size(59, 21);
            label5.TabIndex = 24;
            label5.Text = "Status :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(17, 151);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 23;
            label4.Text = "EndDate :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(17, 115);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 22;
            label3.Text = "StartDate :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(17, 80);
            label2.Name = "label2";
            label2.Size = new Size(131, 21);
            label2.TabIndex = 21;
            label2.Text = "ReservationDate :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 48);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 20;
            label1.Text = "ReservationID :";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(117, 426);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // txtRoomNum
            // 
            txtRoomNum.Font = new Font("Segoe UI", 12F);
            txtRoomNum.Location = new Point(146, 312);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.ReadOnly = true;
            txtRoomNum.Size = new Size(263, 29);
            txtRoomNum.TabIndex = 46;
            txtRoomNum.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(326, 426);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtReserStat);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtReserRem);
            panel1.Controls.Add(txtReserPA);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(cbbRoomID);
            panel1.Controls.Add(cbbResID);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtRoomNum);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(dtpReserED);
            panel1.Controls.Add(dtpReserSD);
            panel1.Controls.Add(dtpReserDate);
            panel1.Controls.Add(txtReserID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 694);
            panel1.TabIndex = 49;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(17, 385);
            label13.Name = "label13";
            label13.Size = new Size(63, 21);
            label13.TabIndex = 58;
            label13.Text = "Remain";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(17, 350);
            label12.Name = "label12";
            label12.Size = new Size(99, 21);
            label12.TabIndex = 57;
            label12.Text = "Paid Amount";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(17, 315);
            label11.Name = "label11";
            label11.Size = new Size(114, 21);
            label11.TabIndex = 56;
            label11.Text = "Room Number";
            // 
            // txtReserRem
            // 
            txtReserRem.Font = new Font("Segoe UI", 12F);
            txtReserRem.Location = new Point(146, 382);
            txtReserRem.Name = "txtReserRem";
            txtReserRem.ReadOnly = true;
            txtReserRem.Size = new Size(263, 29);
            txtReserRem.TabIndex = 55;
            txtReserRem.TextAlign = HorizontalAlignment.Center;
            // 
            // txtReserPA
            // 
            txtReserPA.Font = new Font("Segoe UI", 12F);
            txtReserPA.Location = new Point(146, 347);
            txtReserPA.Name = "txtReserPA";
            txtReserPA.ReadOnly = true;
            txtReserPA.Size = new Size(263, 29);
            txtReserPA.TabIndex = 54;
            txtReserPA.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(17, 242);
            label10.Name = "label10";
            label10.Size = new Size(116, 21);
            label10.TabIndex = 53;
            label10.Text = "Resident Name";
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Segoe UI", 12F);
            txtResName.Location = new Point(146, 239);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(263, 29);
            txtResName.TabIndex = 52;
            txtResName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(146, 283);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(263, 23);
            cbbRoomID.TabIndex = 51;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(146, 210);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(263, 23);
            cbbResID.TabIndex = 50;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(51, 122, 183);
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(431, 30);
            label8.TabIndex = 49;
            label8.Text = "Reservation Details";
            label8.TextAlign = ContentAlignment.MiddleCenter;
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
            titleLabel.TabIndex = 50;
            titleLabel.Text = "Reservation Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(445, 43);
            label9.Name = "label9";
            label9.Size = new Size(57, 21);
            label9.TabIndex = 50;
            label9.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(508, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.ReadOnly = true;
            txtSearch.Size = new Size(524, 29);
            txtSearch.TabIndex = 50;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // txtReserStat
            // 
            txtReserStat.Font = new Font("Segoe UI", 12F);
            txtReserStat.Location = new Point(146, 173);
            txtReserStat.Name = "txtReserStat";
            txtReserStat.ReadOnly = true;
            txtReserStat.Size = new Size(263, 29);
            txtReserStat.TabIndex = 59;
            txtReserStat.TextAlign = HorizontalAlignment.Center;
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1044, 742);
            Controls.Add(txtSearch);
            Controls.Add(label9);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvReser);
            Name = "FormReservation";
            Text = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)dgvReser).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvReser;
        private Button btnNew;
        private Button btnUpdate;
        private DateTimePicker dtpReserED;
        private DateTimePicker dtpReserSD;
        private DateTimePicker dtpReserDate;
        private TextBox txtReserID;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn column7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private TextBox txt;
        private TextBox roomid;
        private Button btnInsert;
        private TextBox residentname;
        private TextBox txtRoomNum;
        private Button btnDelete;
        private Panel panel1;
        private Label label8;
        private Label titleLabel;
        private Label label9;
        private TextBox txtSearch;
        private ComboBox cbbResID;
        private ComboBox cbbRoomID;
        private TextBox txtResName;
        private Label label10;
        private TextBox txtReserRem;
        private TextBox txtReserPA;
        private Label label13;
        private Label label12;
        private Label label11;
        private TextBox txtReserStat;
    }
}