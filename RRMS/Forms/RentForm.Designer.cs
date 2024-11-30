namespace WinFormsApp1
{
    partial class RentForm
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
            rentid = new TextBox();
            text1 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            rentamount = new TextBox();
            roomid = new TextBox();
            residentname = new TextBox();
            roomnum = new TextBox();
            residentid = new TextBox();
            startdate = new DateTimePicker();
            enddate = new DateTimePicker();
            btnClear = new Button();
            btnUpdate = new Button();
            dataGridView1 = new DataGridView();
            label8 = new Label();
            searchbox = new TextBox();
            btnInsert = new Button();
            btnDelete = new Button();
            inputGroup = new Panel();
            titleLabel = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            inputGroup.SuspendLayout();
            SuspendLayout();
            // 
            // rentid
            // 
            rentid.Font = new Font("Segoe UI", 12F);
            rentid.Location = new Point(136, 34);
            rentid.Name = "rentid";
            rentid.ReadOnly = true;
            rentid.Size = new Size(230, 29);
            rentid.TabIndex = 0;
            rentid.TextAlign = HorizontalAlignment.Center;
            // 
            // text1
            // 
            text1.AutoSize = true;
            text1.Font = new Font("Segoe UI", 12F);
            text1.Location = new Point(17, 42);
            text1.Name = "text1";
            text1.Size = new Size(64, 21);
            text1.TabIndex = 1;
            text1.Text = "RentID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(17, 77);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 2;
            label1.Text = "StartDate :";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(17, 120);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 3;
            label2.Text = "EndDate :";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(17, 164);
            label3.Name = "label3";
            label3.Size = new Size(105, 21);
            label3.TabIndex = 4;
            label3.Text = "RentAmount :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(17, 341);
            label4.Name = "label4";
            label4.Size = new Size(92, 21);
            label4.TabIndex = 5;
            label4.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(17, 206);
            label5.Name = "label5";
            label5.Size = new Size(74, 21);
            label5.TabIndex = 6;
            label5.Text = "RoomID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(17, 245);
            label6.Name = "label6";
            label6.Size = new Size(119, 21);
            label6.TabIndex = 7;
            label6.Text = "ResidentName :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(19, 298);
            label7.Name = "label7";
            label7.Size = new Size(117, 21);
            label7.TabIndex = 8;
            label7.Text = "RoomNumber :";
            // 
            // rentamount
            // 
            rentamount.Font = new Font("Segoe UI", 12F);
            rentamount.Location = new Point(136, 156);
            rentamount.Name = "rentamount";
            rentamount.Size = new Size(230, 29);
            rentamount.TabIndex = 9;
            rentamount.TextAlign = HorizontalAlignment.Center;
            // 
            // roomid
            // 
            roomid.Font = new Font("Segoe UI", 12F);
            roomid.Location = new Point(136, 198);
            roomid.Name = "roomid";
            roomid.Size = new Size(230, 29);
            roomid.TabIndex = 10;
            roomid.TextAlign = HorizontalAlignment.Center;
            // 
            // residentname
            // 
            residentname.Font = new Font("Segoe UI", 12F);
            residentname.Location = new Point(136, 245);
            residentname.Name = "residentname";
            residentname.ReadOnly = true;
            residentname.Size = new Size(230, 29);
            residentname.TabIndex = 11;
            residentname.TextAlign = HorizontalAlignment.Center;
            // 
            // roomnum
            // 
            roomnum.Font = new Font("Segoe UI", 12F);
            roomnum.Location = new Point(136, 290);
            roomnum.Name = "roomnum";
            roomnum.ReadOnly = true;
            roomnum.Size = new Size(230, 29);
            roomnum.TabIndex = 12;
            roomnum.TextAlign = HorizontalAlignment.Center;
            // 
            // residentid
            // 
            residentid.Font = new Font("Segoe UI", 12F);
            residentid.Location = new Point(136, 333);
            residentid.Name = "residentid";
            residentid.Size = new Size(230, 29);
            residentid.TabIndex = 13;
            residentid.TextAlign = HorizontalAlignment.Center;
            // 
            // startdate
            // 
            startdate.CalendarFont = new Font("Segoe UI", 9F);
            startdate.Font = new Font("Segoe UI", 9F);
            startdate.Location = new Point(136, 77);
            startdate.Name = "startdate";
            startdate.Size = new Size(230, 23);
            startdate.TabIndex = 14;
            // 
            // enddate
            // 
            enddate.CalendarFont = new Font("Segoe UI", 9F);
            enddate.Font = new Font("Segoe UI", 9F);
            enddate.Location = new Point(136, 118);
            enddate.Name = "enddate";
            enddate.Size = new Size(230, 23);
            enddate.TabIndex = 15;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(217, 83, 79);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(283, 432);
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
            btnUpdate.Location = new Point(98, 432);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(421, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(352, 472);
            dataGridView1.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(17, 376);
            label8.Name = "label8";
            label8.Size = new Size(64, 21);
            label8.TabIndex = 42;
            label8.Text = "Search :";
            // 
            // searchbox
            // 
            searchbox.Location = new Point(136, 376);
            searchbox.Name = "searchbox";
            searchbox.Size = new Size(230, 25);
            searchbox.TabIndex = 43;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(9, 432);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(187, 432);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // inputGroup
            // 
            inputGroup.BackColor = Color.White;
            inputGroup.Controls.Add(label10);
            inputGroup.Controls.Add(searchbox);
            inputGroup.Controls.Add(btnDelete);
            inputGroup.Controls.Add(label8);
            inputGroup.Controls.Add(btnInsert);
            inputGroup.Controls.Add(label3);
            inputGroup.Controls.Add(label2);
            inputGroup.Controls.Add(btnClear);
            inputGroup.Controls.Add(label1);
            inputGroup.Controls.Add(btnUpdate);
            inputGroup.Controls.Add(text1);
            inputGroup.Controls.Add(rentid);
            inputGroup.Controls.Add(residentid);
            inputGroup.Controls.Add(enddate);
            inputGroup.Controls.Add(roomnum);
            inputGroup.Controls.Add(rentamount);
            inputGroup.Controls.Add(residentname);
            inputGroup.Controls.Add(startdate);
            inputGroup.Controls.Add(roomid);
            inputGroup.Controls.Add(label4);
            inputGroup.Controls.Add(label7);
            inputGroup.Controls.Add(label5);
            inputGroup.Controls.Add(label6);
            inputGroup.Font = new Font("Segoe UI", 10F);
            inputGroup.Location = new Point(18, 45);
            inputGroup.Margin = new Padding(3, 2, 3, 2);
            inputGroup.Name = "inputGroup";
            inputGroup.Padding = new Padding(3, 2, 3, 2);
            inputGroup.Size = new Size(372, 472);
            inputGroup.TabIndex = 1;
            inputGroup.Text = "Lease Agreement Details";
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(800, 30);
            titleLabel.TabIndex = 42;
            titleLabel.Text = "Rent Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(3, 2);
            label10.Name = "label10";
            label10.Size = new Size(366, 29);
            label10.TabIndex = 47;
            label10.Text = "Rent Management";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            label10.Click += label10_Click;
            // 
            // RentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(titleLabel);
            Controls.Add(inputGroup);
            Controls.Add(dataGridView1);
            Name = "RentForm";
            Text = "RentForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            inputGroup.ResumeLayout(false);
            inputGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox rentid;
        private Label text1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox rentamount;
        private TextBox roomid;
        private TextBox residentname;
        private TextBox roomnum;
        private TextBox residentid;
        private DateTimePicker startdate;
        private DateTimePicker enddate;
        private Button btnClear;
        private Button btnUpdate;
        private DataGridView dataGridView1;
        private Label label8;
        private TextBox searchbox;
        private Button btnDelete;
        private Panel inputGroup;
        private Label titleLabel;
        private Button btnInsert;
        private Label label10;
    }
}