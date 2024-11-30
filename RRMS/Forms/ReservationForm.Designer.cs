namespace RRMS
{
    partial class ReservationForm
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
            dataGridView1 = new DataGridView();
            column7 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnClear = new Button();
            btnUpdate = new Button();
            reservationenddate = new DateTimePicker();
            reservationstartdate = new DateTimePicker();
            reservationdate = new DateTimePicker();
            reservationid = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            reservationstatus = new ComboBox();
            residentid = new TextBox();
            roomid = new TextBox();
            btnInsert = new Button();
            residentname = new TextBox();
            roomnum = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label8 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { column7, Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(445, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(413, 387);
            dataGridView1.TabIndex = 37;
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
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(217, 83, 79);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(230, 347);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 26);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(141, 347);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // reservationenddate
            // 
            reservationenddate.Font = new Font("Segoe UI", 12F);
            reservationenddate.Location = new Point(154, 143);
            reservationenddate.Name = "reservationenddate";
            reservationenddate.Size = new Size(273, 29);
            reservationenddate.TabIndex = 30;
            // 
            // reservationstartdate
            // 
            reservationstartdate.Font = new Font("Segoe UI", 12F);
            reservationstartdate.Location = new Point(154, 107);
            reservationstartdate.Name = "reservationstartdate";
            reservationstartdate.Size = new Size(273, 29);
            reservationstartdate.TabIndex = 29;
            // 
            // reservationdate
            // 
            reservationdate.Font = new Font("Segoe UI", 12F);
            reservationdate.Location = new Point(154, 72);
            reservationdate.Name = "reservationdate";
            reservationdate.Size = new Size(273, 29);
            reservationdate.TabIndex = 28;
            // 
            // reservationid
            // 
            reservationid.Font = new Font("Segoe UI", 12F);
            reservationid.Location = new Point(154, 40);
            reservationid.Name = "reservationid";
            reservationid.ReadOnly = true;
            reservationid.Size = new Size(273, 29);
            reservationid.TabIndex = 27;
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
            label6.Location = new Point(17, 218);
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
            // reservationstatus
            // 
            reservationstatus.Font = new Font("Segoe UI", 12F);
            reservationstatus.FormattingEnabled = true;
            reservationstatus.Location = new Point(154, 175);
            reservationstatus.Name = "reservationstatus";
            reservationstatus.Size = new Size(273, 29);
            reservationstatus.TabIndex = 39;
            // 
            // residentid
            // 
            residentid.Font = new Font("Segoe UI", 12F);
            residentid.Location = new Point(154, 210);
            residentid.Name = "residentid";
            residentid.PlaceholderText = "Input Resident ID To Display Name";
            residentid.Size = new Size(273, 29);
            residentid.TabIndex = 42;
            residentid.TextAlign = HorizontalAlignment.Center;
            // 
            // roomid
            // 
            roomid.Font = new Font("Segoe UI", 12F);
            roomid.Location = new Point(154, 277);
            roomid.Name = "roomid";
            roomid.ReadOnly = true;
            roomid.Size = new Size(273, 29);
            roomid.TabIndex = 43;
            roomid.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(48, 347);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // residentname
            // 
            residentname.Font = new Font("Segoe UI", 12F);
            residentname.Location = new Point(154, 242);
            residentname.Name = "residentname";
            residentname.ReadOnly = true;
            residentname.Size = new Size(89, 29);
            residentname.TabIndex = 45;
            residentname.TextAlign = HorizontalAlignment.Center;
            // 
            // roomnum
            // 
            roomnum.Font = new Font("Segoe UI", 12F);
            roomnum.Location = new Point(154, 312);
            roomnum.Name = "roomnum";
            roomnum.ReadOnly = true;
            roomnum.Size = new Size(89, 29);
            roomnum.TabIndex = 46;
            roomnum.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(319, 347);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(roomnum);
            panel1.Controls.Add(residentname);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(roomid);
            panel1.Controls.Add(residentid);
            panel1.Controls.Add(reservationstatus);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(reservationenddate);
            panel1.Controls.Add(reservationstartdate);
            panel1.Controls.Add(reservationdate);
            panel1.Controls.Add(reservationid);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(431, 387);
            panel1.TabIndex = 49;
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
            label8.Text = "Rent Management";
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
            titleLabel.Size = new Size(870, 30);
            titleLabel.TabIndex = 50;
            titleLabel.Text = "Rent Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(870, 435);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ReservationForm";
            Text = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btnClear;
        private Button btnUpdate;
        private DateTimePicker reservationenddate;
        private DateTimePicker reservationstartdate;
        private DateTimePicker reservationdate;
        private TextBox reservationid;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox reservationstatus;
        private DataGridViewTextBoxColumn column7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private TextBox residentid;
        private TextBox roomid;
        private Button btnInsert;
        private TextBox residentname;
        private TextBox roomnum;
        private Button btnDelete;
        private Panel panel1;
        private Label label8;
        private Label titleLabel;
    }
}