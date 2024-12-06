namespace RRMS.Forms
{
    partial class FormRent
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
            txtRentID = new TextBox();
            text1 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            txtRentAmount = new TextBox();
            txtRoomNumber = new TextBox();
            dtpRentSD = new DateTimePicker();
            dtpRentED = new DateTimePicker();
            btnNew = new Button();
            btnUpdate = new Button();
            dgvRent = new DataGridView();
            label8 = new Label();
            txtSearch = new TextBox();
            btnInsert = new Button();
            btnDelete = new Button();
            inputGroup = new Panel();
            cbbRoomID = new ComboBox();
            label10 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRent).BeginInit();
            inputGroup.SuspendLayout();
            SuspendLayout();
            // 
            // txtRentID
            // 
            txtRentID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRentID.Location = new Point(160, 40);
            txtRentID.Name = "txtRentID";
            txtRentID.ReadOnly = true;
            txtRentID.Size = new Size(215, 26);
            txtRentID.TabIndex = 2;
            txtRentID.TextAlign = HorizontalAlignment.Center;
            // 
            // text1
            // 
            text1.AutoSize = true;
            text1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text1.Location = new Point(25, 40);
            text1.Name = "text1";
            text1.Size = new Size(69, 20);
            text1.TabIndex = 1;
            text1.Text = "RentID :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 80);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 2;
            label1.Text = "StartDate :";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 120);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 3;
            label2.Text = "EndDate :";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 160);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 4;
            label3.Text = "RentAmount :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 200);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 6;
            label5.Text = "RoomID :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 240);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 8;
            label7.Text = "RoomNumber :";
            // 
            // txtRentAmount
            // 
            txtRentAmount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRentAmount.Location = new Point(160, 160);
            txtRentAmount.Name = "txtRentAmount";
            txtRentAmount.Size = new Size(215, 26);
            txtRentAmount.TabIndex = 5;
            txtRentAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNumber.Location = new Point(160, 240);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(215, 26);
            txtRoomNumber.TabIndex = 7;
            txtRoomNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpRentSD
            // 
            dtpRentSD.CalendarFont = new Font("Segoe UI", 9F);
            dtpRentSD.Font = new Font("Segoe UI", 9F);
            dtpRentSD.Location = new Point(160, 80);
            dtpRentSD.Name = "dtpRentSD";
            dtpRentSD.Size = new Size(215, 23);
            dtpRentSD.TabIndex = 3;
            // 
            // dtpRentED
            // 
            dtpRentED.CalendarFont = new Font("Segoe UI", 9F);
            dtpRentED.Font = new Font("Segoe UI", 9F);
            dtpRentED.Location = new Point(160, 120);
            dtpRentED.Name = "dtpRentED";
            dtpRentED.Size = new Size(215, 23);
            dtpRentED.TabIndex = 4;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 286);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 286);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvRent
            // 
            dgvRent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRent.Location = new Point(550, 72);
            dgvRent.Name = "dgvRent";
            dgvRent.Size = new Size(434, 590);
            dgvRent.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(550, 40);
            label8.Name = "label8";
            label8.Size = new Size(68, 20);
            label8.TabIndex = 42;
            label8.Text = "Search :";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(624, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(360, 26);
            txtSearch.TabIndex = 1;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 286);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 286);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // inputGroup
            // 
            inputGroup.BackColor = Color.White;
            inputGroup.Controls.Add(cbbRoomID);
            inputGroup.Controls.Add(label10);
            inputGroup.Controls.Add(btnDelete);
            inputGroup.Controls.Add(btnInsert);
            inputGroup.Controls.Add(label3);
            inputGroup.Controls.Add(label2);
            inputGroup.Controls.Add(btnNew);
            inputGroup.Controls.Add(label1);
            inputGroup.Controls.Add(btnUpdate);
            inputGroup.Controls.Add(text1);
            inputGroup.Controls.Add(txtRentID);
            inputGroup.Controls.Add(dtpRentED);
            inputGroup.Controls.Add(txtRoomNumber);
            inputGroup.Controls.Add(txtRentAmount);
            inputGroup.Controls.Add(dtpRentSD);
            inputGroup.Controls.Add(label7);
            inputGroup.Controls.Add(label5);
            inputGroup.Font = new Font("Segoe UI", 10F);
            inputGroup.Location = new Point(0, 32);
            inputGroup.Margin = new Padding(3, 2, 3, 2);
            inputGroup.Name = "inputGroup";
            inputGroup.Padding = new Padding(3, 2, 3, 2);
            inputGroup.Size = new Size(550, 630);
            inputGroup.TabIndex = 1;
            inputGroup.Text = "Lease Agreement Details";
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(160, 200);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(215, 25);
            cbbRoomID.TabIndex = 6;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(3, 2);
            label10.Name = "label10";
            label10.Size = new Size(544, 29);
            label10.TabIndex = 47;
            label10.Text = "Rent Management";
            label10.TextAlign = ContentAlignment.MiddleCenter;
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
            titleLabel.TabIndex = 42;
            titleLabel.Text = "Rent Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(titleLabel);
            Controls.Add(txtSearch);
            Controls.Add(inputGroup);
            Controls.Add(label8);
            Controls.Add(dgvRent);
            Name = "FormRent";
            Text = "RentForm";
            ((System.ComponentModel.ISupportInitialize)dgvRent).EndInit();
            inputGroup.ResumeLayout(false);
            inputGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRentID;
        private Label text1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label7;
        private TextBox txtRentAmount;
        private TextBox txtRoomNumber;
        private DateTimePicker dtpRentSD;
        private DateTimePicker dtpRentED;
        private Button btnNew;
        private Button btnUpdate;
        private DataGridView dgvRent;
        private Label label8;
        private TextBox txtSearch;
        private Button btnDelete;
        private Panel inputGroup;
        private Label titleLabel;
        private Button btnInsert;
        private Label label10;
        private ComboBox cbbRoomID;
    }
}