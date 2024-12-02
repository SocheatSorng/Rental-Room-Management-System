namespace RRMS.Forms
{
    partial class FormService
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
            txtSerDesc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label = new Label();
            label4 = new Label();
            txtSerName = new TextBox();
            txtSerID = new TextBox();
            txtSerCost = new TextBox();
            btnInsert = new Button();
            btnNew = new Button();
            btnUpdate = new Button();
            dgvSer = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label9 = new Label();
            txtRoomID = new TextBox();
            label8 = new Label();
            cbbRoomID = new ComboBox();
            label7 = new Label();
            txtVenName = new TextBox();
            cbbVenID = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSer).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSerDesc
            // 
            txtSerDesc.Font = new Font("Segoe UI", 12F);
            txtSerDesc.Location = new Point(171, 141);
            txtSerDesc.Multiline = true;
            txtSerDesc.Name = "txtSerDesc";
            txtSerDesc.Size = new Size(270, 69);
            txtSerDesc.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(18, 42);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 1;
            label3.Text = "ServiceID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 90);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 2;
            label2.Text = "Service Name:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F);
            label.Location = new Point(18, 163);
            label.Name = "label";
            label.Size = new Size(146, 21);
            label.TabIndex = 3;
            label.Text = "Service Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(18, 226);
            label4.Name = "label4";
            label4.Size = new Size(48, 21);
            label4.TabIndex = 4;
            label4.Text = "Cost: ";
            // 
            // txtSerName
            // 
            txtSerName.Font = new Font("Segoe UI", 12F);
            txtSerName.Location = new Point(171, 90);
            txtSerName.Name = "txtSerName";
            txtSerName.Size = new Size(270, 29);
            txtSerName.TabIndex = 5;
            // 
            // txtSerID
            // 
            txtSerID.Font = new Font("Segoe UI", 12F);
            txtSerID.Location = new Point(171, 39);
            txtSerID.Name = "txtSerID";
            txtSerID.ReadOnly = true;
            txtSerID.Size = new Size(270, 29);
            txtSerID.TabIndex = 6;
            // 
            // txtSerCost
            // 
            txtSerCost.Font = new Font("Segoe UI", 12F);
            txtSerCost.Location = new Point(171, 223);
            txtSerCost.Name = "txtSerCost";
            txtSerCost.PlaceholderText = "Enter Cost Of The Service";
            txtSerCost.Size = new Size(270, 29);
            txtSerCost.TabIndex = 7;
            txtSerCost.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(128, 426);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(21, 426);
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
            btnUpdate.Location = new Point(232, 426);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvSer
            // 
            dgvSer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSer.Location = new Point(470, 79);
            dgvSer.Name = "dgvSer";
            dgvSer.Size = new Size(562, 651);
            dgvSer.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(470, 43);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 52;
            label1.Text = "Search :";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(540, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Seach by Name, Description";
            txtSearch.Size = new Size(492, 29);
            txtSearch.TabIndex = 53;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(335, 426);
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
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtRoomID);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(cbbRoomID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtVenName);
            panel1.Controls.Add(cbbVenID);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtSerDesc);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtSerCost);
            panel1.Controls.Add(txtSerID);
            panel1.Controls.Add(txtSerName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 693);
            panel1.TabIndex = 55;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(18, 386);
            label9.Name = "label9";
            label9.Size = new Size(114, 21);
            label9.TabIndex = 63;
            label9.Text = "Room Number";
            // 
            // txtRoomID
            // 
            txtRoomID.Font = new Font("Segoe UI", 12F);
            txtRoomID.Location = new Point(171, 383);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(270, 29);
            txtRoomID.TabIndex = 62;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(18, 345);
            label8.Name = "label8";
            label8.Size = new Size(78, 21);
            label8.TabIndex = 61;
            label8.Text = "Room ID: ";
            // 
            // cbbRoomID
            // 
            cbbRoomID.FormattingEnabled = true;
            cbbRoomID.Location = new Point(170, 345);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(271, 23);
            cbbRoomID.TabIndex = 60;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(18, 302);
            label7.Name = "label7";
            label7.Size = new Size(109, 21);
            label7.TabIndex = 59;
            label7.Text = "Vendor Name:";
            // 
            // txtVenName
            // 
            txtVenName.Font = new Font("Segoe UI", 12F);
            txtVenName.Location = new Point(171, 299);
            txtVenName.Name = "txtVenName";
            txtVenName.Size = new Size(270, 29);
            txtVenName.TabIndex = 58;
            // 
            // cbbVenID
            // 
            cbbVenID.FormattingEnabled = true;
            cbbVenID.Location = new Point(170, 270);
            cbbVenID.Name = "cbbVenID";
            cbbVenID.Size = new Size(271, 23);
            cbbVenID.TabIndex = 57;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(18, 268);
            label6.Name = "label6";
            label6.Size = new Size(86, 21);
            label6.TabIndex = 56;
            label6.Text = "Vendor ID: ";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 122, 183);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(452, 30);
            label5.TabIndex = 55;
            label5.Text = "Service Details";
            label5.TextAlign = ContentAlignment.MiddleCenter;
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
            titleLabel.TabIndex = 56;
            titleLabel.Text = "Sevice Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormService
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvSer);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "FormService";
            Text = "ServiceForm";
            ((System.ComponentModel.ISupportInitialize)dgvSer).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSerDesc;
        private Label label3;
        private Label label2;
        private Label label;
        private Label label4;
        private TextBox txtSerName;
        private TextBox txtSerID;
        private TextBox txtSerCost;
        private Button btnInsert;
        private Button btnNew;
        private Button btnUpdate;
        private DataGridView dgvSer;
        private Label label1;
        private TextBox txtSearch;
        private Button btnDelete;
        private Panel panel1;
        private Label label5;
        private Label titleLabel;
        private Label label9;
        private TextBox txtRoomID;
        private Label label8;
        private ComboBox cbbRoomID;
        private Label label7;
        private TextBox txtVenName;
        private ComboBox cbbVenID;
        private Label label6;
    }
}