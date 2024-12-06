namespace RRMS.Forms
{
    partial class FormPolicy
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtPolID = new TextBox();
            txtPolName = new TextBox();
            txtPolDesc = new TextBox();
            txtResName = new TextBox();
            dtpPolCD = new DateTimePicker();
            dtpPolUD = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            txtStaffID = new ComboBox();
            txtStaffName = new TextBox();
            label9 = new Label();
            label11 = new Label();
            btnNew = new Button();
            cbbResID = new ComboBox();
            label10 = new Label();
            titleLabel = new Label();
            dgvPol = new DataGridView();
            label8 = new Label();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPol).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Policy ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Policy Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 120);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 2;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 160);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 3;
            label4.Text = "Create Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 200);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 4;
            label5.Text = "Update Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 240);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 280);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 6;
            label7.Text = "Resident Name:";
            // 
            // txtPolID
            // 
            txtPolID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPolID.Location = new Point(160, 40);
            txtPolID.Margin = new Padding(3, 2, 3, 2);
            txtPolID.Name = "txtPolID";
            txtPolID.ReadOnly = true;
            txtPolID.Size = new Size(215, 26);
            txtPolID.TabIndex = 2;
            // 
            // txtPolName
            // 
            txtPolName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPolName.Location = new Point(160, 80);
            txtPolName.Margin = new Padding(3, 2, 3, 2);
            txtPolName.Name = "txtPolName";
            txtPolName.Size = new Size(215, 26);
            txtPolName.TabIndex = 3;
            // 
            // txtPolDesc
            // 
            txtPolDesc.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPolDesc.Location = new Point(160, 120);
            txtPolDesc.Margin = new Padding(3, 2, 3, 2);
            txtPolDesc.Multiline = true;
            txtPolDesc.Name = "txtPolDesc";
            txtPolDesc.Size = new Size(215, 21);
            txtPolDesc.TabIndex = 4;
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(160, 280);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(215, 26);
            txtResName.TabIndex = 8;
            // 
            // dtpPolCD
            // 
            dtpPolCD.Location = new Point(160, 160);
            dtpPolCD.Margin = new Padding(3, 2, 3, 2);
            dtpPolCD.Name = "dtpPolCD";
            dtpPolCD.Size = new Size(215, 23);
            dtpPolCD.TabIndex = 5;
            // 
            // dtpPolUD
            // 
            dtpPolUD.Location = new Point(160, 200);
            dtpPolUD.Margin = new Padding(3, 2, 3, 2);
            dtpPolUD.Name = "dtpPolUD";
            dtpPolUD.Size = new Size(215, 23);
            dtpPolUD.TabIndex = 6;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 403);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 403);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 403);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtStaffID);
            panel1.Controls.Add(txtStaffName);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(cbbResID);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(dtpPolUD);
            panel1.Controls.Add(dtpPolCD);
            panel1.Controls.Add(txtPolDesc);
            panel1.Controls.Add(txtPolName);
            panel1.Controls.Add(txtPolID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 18;
            // 
            // txtStaffID
            // 
            txtStaffID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffID.FormattingEnabled = true;
            txtStaffID.Location = new Point(160, 320);
            txtStaffID.Name = "txtStaffID";
            txtStaffID.Size = new Size(215, 28);
            txtStaffID.TabIndex = 9;
            // 
            // txtStaffName
            // 
            txtStaffName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffName.Location = new Point(160, 360);
            txtStaffName.Margin = new Padding(3, 2, 3, 2);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(215, 26);
            txtStaffName.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(25, 360);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 51;
            label9.Text = "Staff Name:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(25, 320);
            label11.Name = "label11";
            label11.Size = new Size(69, 20);
            label11.TabIndex = 50;
            label11.Text = "Staff ID:";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 403);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 11;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(160, 240);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(215, 23);
            cbbResID.TabIndex = 7;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(550, 29);
            label10.TabIndex = 48;
            label10.Text = "Policy Details";
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
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Policy Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPol
            // 
            dgvPol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPol.Location = new Point(557, 73);
            dgvPol.Name = "dgvPol";
            dgvPol.Size = new Size(475, 657);
            dgvPol.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(550, 40);
            label8.Name = "label8";
            label8.Size = new Size(60, 20);
            label8.TabIndex = 51;
            label8.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(616, 37);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(368, 26);
            txtSearch.TabIndex = 1;
            // 
            // FormPolicy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(txtSearch);
            Controls.Add(label8);
            Controls.Add(dgvPol);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPolicy";
            Text = "Policy Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPol).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtPolID;
        private TextBox txtPolName;
        private TextBox txtPolDesc;
        private DateTimePicker dtpPolCD;
        private DateTimePicker dtpPolUD;
        private TextBox txtResName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private DataGridView dgvPol;
        private ComboBox cbbResID;
        private Button btnNew;
        private Label label8;
        private TextBox txtSearch;
        private ComboBox txtStaffID;
        private TextBox txtStaffName;
        private Label label9;
        private Label label11;
    }
}
