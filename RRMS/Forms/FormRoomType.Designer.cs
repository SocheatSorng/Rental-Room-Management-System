namespace RRMS.Forms
{
    partial class FormRoomType
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtDescription = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtRoomTypeID = new TextBox();
            txtBasePrice = new TextBox();
            btnInsert = new Button();
            btnNew = new Button();
            btnUpdate = new Button();
            dgvRoomType = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label8 = new Label();
            txtCapacity = new TextBox();
            cbbStatus = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            titleLabel = new Label();
            cbbTypeName = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvRoomType).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(171, 141);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(270, 69);
            txtDescription.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(18, 42);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 1;
            label3.Text = "RoomTypeID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 90);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 2;
            label2.Text = "Type Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(18, 226);
            label4.Name = "label4";
            label4.Size = new Size(83, 21);
            label4.TabIndex = 4;
            label4.Text = "Base Price:";
            // 
            // txtRoomTypeID
            // 
            txtRoomTypeID.Font = new Font("Segoe UI", 12F);
            txtRoomTypeID.Location = new Point(171, 39);
            txtRoomTypeID.Name = "txtRoomTypeID";
            txtRoomTypeID.ReadOnly = true;
            txtRoomTypeID.Size = new Size(270, 29);
            txtRoomTypeID.TabIndex = 6;
            // 
            // txtBasePrice
            // 
            txtBasePrice.Font = new Font("Segoe UI", 12F);
            txtBasePrice.Location = new Point(171, 223);
            txtBasePrice.Name = "txtBasePrice";
            txtBasePrice.Size = new Size(270, 29);
            txtBasePrice.TabIndex = 7;
            txtBasePrice.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(125, 365);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(18, 365);
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
            btnUpdate.Location = new Point(229, 365);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvRoomType
            // 
            dgvRoomType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomType.Location = new Point(470, 79);
            dgvRoomType.Name = "dgvRoomType";
            dgvRoomType.RowHeadersWidth = 51;
            dgvRoomType.Size = new Size(562, 651);
            dgvRoomType.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(470, 43);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 4;
            label1.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(540, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(492, 29);
            txtSearch.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(332, 365);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbTypeName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtBasePrice);
            panel1.Controls.Add(txtRoomTypeID);
            panel1.Controls.Add(txtCapacity);
            panel1.Controls.Add(cbbStatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 693);
            panel1.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(18, 141);
            label8.Name = "label8";
            label8.Size = new Size(92, 21);
            label8.TabIndex = 13;
            label8.Text = "Description:";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Segoe UI", 12F);
            txtCapacity.Location = new Point(171, 270);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(270, 29);
            txtCapacity.TabIndex = 8;
            // 
            // cbbStatus
            // 
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cbbStatus.Location = new Point(171, 317);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(270, 23);
            cbbStatus.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(18, 273);
            label7.Name = "label7";
            label7.Size = new Size(72, 21);
            label7.TabIndex = 10;
            label7.Text = "Capacity:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(18, 317);
            label6.Name = "label6";
            label6.Size = new Size(55, 21);
            label6.TabIndex = 11;
            label6.Text = "Status:";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 122, 183);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(452, 27);
            label5.TabIndex = 12;
            label5.Text = "Room Type Details";
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
            titleLabel.Size = new Size(1044, 34);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Room Type Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbbTypeName
            // 
            cbbTypeName.FormattingEnabled = true;
            cbbTypeName.Items.AddRange(new object[] { "Active", "Inactive" });
            cbbTypeName.Location = new Point(171, 88);
            cbbTypeName.Name = "cbbTypeName";
            cbbTypeName.Size = new Size(270, 23);
            cbbTypeName.TabIndex = 14;
            // 
            // FormRoomType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvRoomType);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "FormRoomType";
            Text = "Room Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvRoomType).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #region Windows Form Designer generated code

        private TextBox txtDescription;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txtRoomTypeID;
        private TextBox txtBasePrice;
        private Button btnInsert;
        private Button btnNew;
        private Button btnUpdate;
        private DataGridView dgvRoomType;
        private Label label1;
        private TextBox txtSearch;
        private Button btnDelete;
        private Panel panel1;
        private Label label5;
        private Label titleLabel;
        private Label label7;
        private TextBox txtCapacity;
        private ComboBox cbbStatus;
        private Label label6;

        #endregion

        private Label label8;
        private ComboBox cbbTypeName;
    }
}