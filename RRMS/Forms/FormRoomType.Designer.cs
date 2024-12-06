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
            txtRTypeName = new TextBox();
            label8 = new Label();
            txtRTypeCapa = new TextBox();
            label7 = new Label();
            label5 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRType).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRTypeDesc
            // 
            txtRTypeDesc.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRTypeDesc.Location = new Point(160, 120);
            txtRTypeDesc.Multiline = true;
            txtRTypeDesc.Name = "txtRTypeDesc";
            txtRTypeDesc.Size = new Size(215, 69);
            txtRTypeDesc.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 40);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 1;
            label3.Text = "Room Type ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 2;
            label2.Text = "Type Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 200);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 4;
            label4.Text = "Base Price:";
            // 
            // txtRTypeID
            // 
            txtRTypeID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRTypeID.Location = new Point(160, 40);
            txtRTypeID.Name = "txtRTypeID";
            txtRTypeID.ReadOnly = true;
            txtRTypeID.Size = new Size(215, 26);
            txtRTypeID.TabIndex = 2;
            // 
            // txtRTypeBP
            // 
            txtRTypeBP.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRTypeBP.Location = new Point(160, 200);
            txtRTypeBP.Name = "txtRTypeBP";
            txtRTypeBP.Size = new Size(215, 26);
            txtRTypeBP.TabIndex = 5;
            txtRTypeBP.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 287);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 287);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 7;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 287);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dgvRType
            // 
            dgvRType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRType.Location = new Point(549, 79);
            dgvRType.Name = "dgvRType";
            dgvRType.RowHeadersWidth = 51;
            dgvRType.Size = new Size(483, 585);
            dgvRType.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(550, 40);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(620, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(364, 26);
            txtSearch.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 287);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 10;
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
            panel1.Location = new Point(0, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 1;
            // 
            // txtRTypeName
            // 
            txtRTypeName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRTypeName.Location = new Point(160, 80);
            txtRTypeName.Name = "txtRTypeName";
            txtRTypeName.Size = new Size(215, 26);
            txtRTypeName.TabIndex = 3;
            txtRTypeName.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(25, 123);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 13;
            label8.Text = "Description:";
            // 
            // txtRTypeCapa
            // 
            txtRTypeCapa.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRTypeCapa.Location = new Point(160, 240);
            txtRTypeCapa.Name = "txtRTypeCapa";
            txtRTypeCapa.Size = new Size(215, 26);
            txtRTypeCapa.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 240);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 10;
            label7.Text = "Capacity:";
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 122, 183);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(550, 27);
            label5.TabIndex = 12;
            label5.Text = "Room Type Details";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(984, 34);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Room Type Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRoomType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
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