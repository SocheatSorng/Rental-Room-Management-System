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
            cbbStatus = new ComboBox();
            label11 = new Label();
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
            dgvReservation.Location = new Point(560, 73);
            dgvReservation.Name = "dgvReservation";
            dgvReservation.RowHeadersWidth = 82;
            dgvReservation.Size = new Size(453, 590);
            dgvReservation.TabIndex = 17;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 410);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 13;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 410);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dtpReserED
            // 
            dtpReserED.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserED.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserED.Location = new Point(160, 160);
            dtpReserED.Name = "dtpReserED";
            dtpReserED.Size = new Size(215, 24);
            dtpReserED.TabIndex = 5;
            // 
            // dtpReserSD
            // 
            dtpReserSD.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserSD.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserSD.Location = new Point(160, 120);
            dtpReserSD.Name = "dtpReserSD";
            dtpReserSD.Size = new Size(215, 24);
            dtpReserSD.TabIndex = 4;
            // 
            // dtpReserDate
            // 
            dtpReserDate.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            dtpReserDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dtpReserDate.Location = new Point(160, 80);
            dtpReserDate.Name = "dtpReserDate";
            dtpReserDate.Size = new Size(215, 24);
            dtpReserDate.TabIndex = 3;
            // 
            // txtReserID
            // 
            txtReserID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReserID.Location = new Point(160, 40);
            txtReserID.Name = "txtReserID";
            txtReserID.ReadOnly = true;
            txtReserID.Size = new Size(215, 26);
            txtReserID.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 320);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 26;
            label7.Text = "RoomID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 240);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 25;
            label6.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 200);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 24;
            label5.Text = "Status :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 160);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 23;
            label4.Text = "EndDate :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 120);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 22;
            label3.Text = "StartDate :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 21;
            label2.Text = "ReservationDate :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 20;
            label1.Text = "ReservationID :";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 410);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // txtRoomNum
            // 
            txtRoomNum.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNum.Location = new Point(160, 360);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.ReadOnly = true;
            txtRoomNum.Size = new Size(215, 26);
            txtRoomNum.TabIndex = 10;
            txtRoomNum.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 410);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbStatus);
            panel1.Controls.Add(label11);
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
            panel1.Location = new Point(2, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(558, 627);
            panel1.TabIndex = 49;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(160, 200);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(215, 23);
            cbbStatus.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(25, 360);
            label11.Name = "label11";
            label11.Size = new Size(112, 20);
            label11.TabIndex = 56;
            label11.Text = "Room Number";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(25, 280);
            label10.Name = "label10";
            label10.Size = new Size(119, 20);
            label10.TabIndex = 53;
            label10.Text = "Resident Name";
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(160, 280);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(215, 26);
            txtResName.TabIndex = 8;
            txtResName.TextAlign = HorizontalAlignment.Center;
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(160, 320);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(215, 23);
            cbbRoomID.TabIndex = 9;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(160, 240);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(215, 23);
            cbbResID.TabIndex = 7;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(51, 122, 183);
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(558, 30);
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
            titleLabel.Size = new Size(984, 30);
            titleLabel.TabIndex = 50;
            titleLabel.Text = "Reservation Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(566, 43);
            label9.Name = "label9";
            label9.Size = new Size(60, 20);
            label9.TabIndex = 50;
            label9.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(644, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.ReadOnly = true;
            txtSearch.Size = new Size(388, 26);
            txtSearch.TabIndex = 1;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(984, 661);
            Controls.Add(txtSearch);
            Controls.Add(label9);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvReservation);
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
        private Label label11;
        private ComboBox cbbStatus;
    }
}