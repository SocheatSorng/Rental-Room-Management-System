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
            txtRTypeDesc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtRTypeID = new TextBox();
            txtRTypeBP = new TextBox();
            btnInsert = new Button();
            btnNew = new Button();
            btnUpdate = new Button();
            dgvRType = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label8 = new Label();
            txtRTypeCapa = new TextBox();
            label7 = new Label();
            label5 = new Label();
            titleLabel = new Label();
            txtRTypeName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRType).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRTypeDesc
            // 
            txtRTypeDesc.Font = new Font("Segoe UI", 12F);
            txtRTypeDesc.Location = new Point(171, 141);
            txtRTypeDesc.Multiline = true;
            txtRTypeDesc.Name = "txtRTypeDesc";
            txtRTypeDesc.Size = new Size(270, 69);
            txtRTypeDesc.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(18, 42);
            label3.Name = "label3";
            label3.Size = new Size(110, 21);
            label3.TabIndex = 1;
            label3.Text = "Room Type ID:";
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
            // txtRTypeID
            // 
            txtRTypeID.Font = new Font("Segoe UI", 12F);
            txtRTypeID.Location = new Point(171, 39);
            txtRTypeID.Name = "txtRTypeID";
            txtRTypeID.ReadOnly = true;
            txtRTypeID.Size = new Size(270, 29);
            txtRTypeID.TabIndex = 2;
            // 
            // txtRTypeBP
            // 
            txtRTypeBP.Font = new Font("Segoe UI", 12F);
            txtRTypeBP.Location = new Point(171, 223);
            txtRTypeBP.Name = "txtRTypeBP";
            txtRTypeBP.Size = new Size(270, 29);
            txtRTypeBP.TabIndex = 5;
            txtRTypeBP.TextAlign = HorizontalAlignment.Center;
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
            btnInsert.TabIndex = 9;
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
            btnUpdate.Location = new Point(229, 365);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvRType
            // 
            dgvRType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRType.Location = new Point(470, 79);
            dgvRType.Name = "dgvRType";
            dgvRType.RowHeadersWidth = 51;
            dgvRType.Size = new Size(562, 651);
            dgvRType.TabIndex = 12;
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
            txtSearch.TabIndex = 1;
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
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtRTypeName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtRTypeDesc);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtRTypeBP);
            panel1.Controls.Add(txtRTypeID);
            panel1.Controls.Add(txtRTypeCapa);
            panel1.Controls.Add(label7);
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
            // txtRTypeCapa
            // 
            txtRTypeCapa.Font = new Font("Segoe UI", 12F);
            txtRTypeCapa.Location = new Point(171, 270);
            txtRTypeCapa.Name = "txtRTypeCapa";
            txtRTypeCapa.Size = new Size(270, 29);
            txtRTypeCapa.TabIndex = 6;
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
            // txtRTypeName
            // 
            txtRTypeName.Font = new Font("Segoe UI", 12F);
            txtRTypeName.Location = new Point(171, 87);
            txtRTypeName.Name = "txtRTypeName";
            txtRTypeName.Size = new Size(270, 29);
            txtRTypeName.TabIndex = 3;
            txtRTypeName.TextAlign = HorizontalAlignment.Center;
            // 
            // FormRoomType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvRType);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "FormRoomType";
            Text = "Room Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvRType).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #region Windows Form Designer generated code

        private TextBox txtRTypeDesc;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txtRTypeID;
        private TextBox txtRTypeBP;
        private Button btnInsert;
        private Button btnNew;
        private Button btnUpdate;
        private DataGridView dgvRType;
        private Label label1;
        private TextBox txtSearch;
        private Button btnDelete;
        private Panel panel1;
        private Label label5;
        private Label titleLabel;
        private Label label7;
        private TextBox txtRTypeCapa;

        #endregion

        private Label label8;
        private TextBox txtRTypeName;
    }
}