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
            dgvReservation = new DataGridView();
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
            txtReserStat = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)dgvReservation).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReservation
            // 
            dgvReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservation.Location = new Point(826, 162);
            dgvReservation.Margin = new Padding(6);
            dgvReservation.Name = "dgvReservation";
            dgvReservation.RowHeadersWidth = 82;
            dgvReservation.Size = new Size(1090, 1395);
            dgvReservation.TabIndex = 37;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(33, 909);
            btnNew.Margin = new Padding(6, 4, 6, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(154, 55);
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
            btnUpdate.Location = new Point(410, 909);
            btnUpdate.Margin = new Padding(6, 4, 6, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(154, 55);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dtpReserED
            // 
            dtpReserED.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserED.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserED.Location = new Point(271, 305);
            dtpReserED.Margin = new Padding(6);
            dtpReserED.Name = "dtpReserED";
            dtpReserED.Size = new Size(485, 41);
            dtpReserED.TabIndex = 30;
            // 
            // dtpReserSD
            // 
            dtpReserSD.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserSD.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserSD.Location = new Point(271, 228);
            dtpReserSD.Margin = new Padding(6);
            dtpReserSD.Name = "dtpReserSD";
            dtpReserSD.Size = new Size(485, 41);
            dtpReserSD.TabIndex = 29;
            // 
            // dtpReserDate
            // 
            dtpReserDate.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserDate.Location = new Point(271, 154);
            dtpReserDate.Margin = new Padding(6);
            dtpReserDate.Name = "dtpReserDate";
            dtpReserDate.Size = new Size(485, 41);
            dtpReserDate.TabIndex = 28;
            // 
            // txtReserID
            // 
            txtReserID.Font = new Font("Segoe UI", 12F);
            txtReserID.Location = new Point(271, 85);
            txtReserID.Margin = new Padding(6);
            txtReserID.Name = "txtReserID";
            txtReserID.ReadOnly = true;
            txtReserID.Size = new Size(485, 50);
            txtReserID.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(33, 597);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(151, 45);
            label7.TabIndex = 26;
            label7.Text = "RoomID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(32, 452);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(189, 45);
            label6.TabIndex = 25;
            label6.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(32, 390);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(122, 45);
            label5.TabIndex = 24;
            label5.Text = "Status :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(32, 322);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(155, 45);
            label4.TabIndex = 23;
            label4.Text = "EndDate :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(32, 245);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 45);
            label3.TabIndex = 22;
            label3.Text = "StartDate :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(32, 171);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(266, 45);
            label2.TabIndex = 21;
            label2.Text = "ReservationDate :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(32, 102);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(231, 45);
            label1.TabIndex = 20;
            label1.Text = "ReservationID :";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(217, 909);
            btnInsert.Margin = new Padding(6, 4, 6, 4);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(154, 55);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // txtRoomNum
            // 
            txtRoomNum.Font = new Font("Segoe UI", 12F);
            txtRoomNum.Location = new Point(271, 666);
            txtRoomNum.Margin = new Padding(6);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.ReadOnly = true;
            txtRoomNum.Size = new Size(485, 50);
            txtRoomNum.TabIndex = 46;
            txtRoomNum.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(605, 909);
            btnDelete.Margin = new Padding(6, 4, 6, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 55);
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
            panel1.Location = new Point(15, 77);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 1481);
            panel1.TabIndex = 49;
            // 
            // txtReserStat
            // 
            txtReserStat.Font = new Font("Segoe UI", 12F);
            txtReserStat.Location = new Point(271, 369);
            txtReserStat.Margin = new Padding(6);
            txtReserStat.Name = "txtReserStat";
            txtReserStat.ReadOnly = true;
            txtReserStat.Size = new Size(485, 50);
            txtReserStat.TabIndex = 59;
            txtReserStat.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(32, 821);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(125, 45);
            label13.TabIndex = 58;
            label13.Text = "Remain";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(32, 747);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(204, 45);
            label12.TabIndex = 57;
            label12.Text = "Paid Amount";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(32, 672);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(230, 45);
            label11.TabIndex = 56;
            label11.Text = "Room Number";
            // 
            // txtReserRem
            // 
            txtReserRem.Font = new Font("Segoe UI", 12F);
            txtReserRem.Location = new Point(271, 815);
            txtReserRem.Margin = new Padding(6);
            txtReserRem.Name = "txtReserRem";
            txtReserRem.ReadOnly = true;
            txtReserRem.Size = new Size(485, 50);
            txtReserRem.TabIndex = 55;
            txtReserRem.TextAlign = HorizontalAlignment.Center;
            // 
            // txtReserPA
            // 
            txtReserPA.Font = new Font("Segoe UI", 12F);
            txtReserPA.Location = new Point(271, 740);
            txtReserPA.Margin = new Padding(6);
            txtReserPA.Name = "txtReserPA";
            txtReserPA.ReadOnly = true;
            txtReserPA.Size = new Size(485, 50);
            txtReserPA.TabIndex = 54;
            txtReserPA.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(32, 516);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(236, 45);
            label10.TabIndex = 53;
            label10.Text = "Resident Name";
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Segoe UI", 12F);
            txtResName.Location = new Point(271, 510);
            txtResName.Margin = new Padding(6);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(485, 50);
            txtResName.TabIndex = 52;
            txtResName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(271, 593);
            cbbRoomID.Margin = new Padding(6);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(485, 40);
            cbbRoomID.TabIndex = 51;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(271, 448);
            cbbResID.Margin = new Padding(6);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(485, 40);
            cbbResID.TabIndex = 50;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(51, 122, 183);
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 0);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(800, 64);
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
            titleLabel.Margin = new Padding(6, 0, 6, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1939, 64);
            titleLabel.TabIndex = 50;
            titleLabel.Text = "Reservation Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(826, 92);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(114, 45);
            label9.TabIndex = 50;
            label9.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(943, 85);
            txtSearch.Margin = new Padding(6);
            txtSearch.Name = "txtSearch";
            txtSearch.ReadOnly = true;
            txtSearch.Size = new Size(970, 50);
            txtSearch.TabIndex = 50;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1939, 1583);
            Controls.Add(txtSearch);
            Controls.Add(label9);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvReservation);
            Margin = new Padding(6);
            Name = "FormReservation";
            Text = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)dgvReservation).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvReservation;
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