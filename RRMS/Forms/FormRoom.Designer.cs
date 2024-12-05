namespace RRMS.Forms
{
    partial class FormRoom
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
            label4 = new Label();
            dgvRoom = new DataGridView();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtRoomID = new TextBox();
            txtResName = new TextBox();
            label16 = new Label();
            txtSearch = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            txtRoomNumber = new TextBox();
            cbbRoomTypeID = new ComboBox();
            txtRoomType = new TextBox();
            label6 = new Label();
            label18 = new Label();
            label5 = new Label();
            cbbResID = new ComboBox();
            label17 = new Label();
            titleLabel = new Label();
            label19 = new Label();
            chkStatus = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 44);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 0;
            label1.Text = "RoomID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 96);
            label2.Name = "label2";
            label2.Size = new Size(82, 18);
            label2.TabIndex = 1;
            label2.Text = "RoomType";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 187);
            label4.Name = "label4";
            label4.Size = new Size(92, 18);
            label4.TabIndex = 3;
            label4.Text = "Resident ID :";
            // 
            // dgvRoom
            // 
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Location = new Point(392, 71);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.Size = new Size(640, 659);
            dgvRoom.TabIndex = 12;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(21, 374);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(110, 374);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(199, 374);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(288, 374);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomID.Location = new Point(161, 44);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(206, 24);
            txtRoomID.TabIndex = 2;
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(164, 233);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(206, 24);
            txtResName.TabIndex = 5;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(392, 43);
            label16.Name = "label16";
            label16.Size = new Size(55, 18);
            label16.TabIndex = 30;
            label16.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(453, 38);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(579, 23);
            txtSearch.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(chkStatus);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtRoomNumber);
            panel1.Controls.Add(cbbRoomTypeID);
            panel1.Controls.Add(txtRoomType);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbbResID);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(txtRoomID);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 687);
            panel1.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 236);
            label3.Name = "label3";
            label3.Size = new Size(110, 18);
            label3.TabIndex = 56;
            label3.Text = "Resident Name";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNumber.Location = new Point(161, 85);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(206, 24);
            txtRoomNumber.TabIndex = 3;
            // 
            // cbbRoomTypeID
            // 
            cbbRoomTypeID.FormattingEnabled = true;
            cbbRoomTypeID.Location = new Point(162, 276);
            cbbRoomTypeID.Name = "cbbRoomTypeID";
            cbbRoomTypeID.Size = new Size(208, 23);
            cbbRoomTypeID.TabIndex = 6;
            // 
            // txtRoomType
            // 
            txtRoomType.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomType.Location = new Point(164, 322);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(206, 24);
            txtRoomType.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 276);
            label6.Name = "label6";
            label6.Size = new Size(112, 18);
            label6.TabIndex = 54;
            label6.Text = "Room Type ID :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(20, 322);
            label18.Name = "label18";
            label18.Size = new Size(107, 18);
            label18.TabIndex = 53;
            label18.Text = "Room Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 85);
            label5.Name = "label5";
            label5.Size = new Size(107, 18);
            label5.TabIndex = 50;
            label5.Text = "Room Number";
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(162, 187);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(208, 23);
            cbbResID.TabIndex = 4;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(374, 29);
            label17.TabIndex = 48;
            label17.Text = "Room Details";
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
            titleLabel.Size = new Size(1044, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Room Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(20, 134);
            label19.Name = "label19";
            label19.Size = new Size(50, 18);
            label19.TabIndex = 57;
            label19.Text = "Status";
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.Location = new Point(163, 134);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(77, 19);
            chkStatus.TabIndex = 58;
            chkStatus.Text = "Occupied";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // FormRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(txtSearch);
            Controls.Add(label16);
            Controls.Add(dgvRoom);
            Name = "FormRoom";
            Text = "Resident";
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label titleLabel;
        private Label label1;
        private Label label2;
        private Label label4;
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
        private DataGridView dgvRoom;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtRoomID; // Resident ID
        private TextBox txtResName; // Resident Type
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
        private Label label17;
        private TextBox txtRoomNum;
        private Label label5;
        private ComboBox cbbResID;
        private ComboBox comboBox1;
        private ComboBox cbbRoomTypeID;
        private TextBox txtRoomType;
        private Label label6;
        private Label label18;
        private Label label3;
        private TextBox txtRoomNumber;
        private CheckBox chkStatus;
        private Label label19;
    }
}