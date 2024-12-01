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
            txtID = new TextBox();
            txtName = new TextBox();
            txtDesc = new TextBox();
            txtResidentName = new TextBox();
            dateCreate = new DateTimePicker();
            dateUpdate = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            btnNew = new Button();
            cbbResidentID = new ComboBox();
            label10 = new Label();
            titleLabel = new Label();
            dgvPolicy = new DataGridView();
            label8 = new Label();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPolicy).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(11, 38);
            label1.Name = "label1";
            label1.Size = new Size(69, 19);
            label1.TabIndex = 0;
            label1.Text = "Policy ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(11, 75);
            label2.Name = "label2";
            label2.Size = new Size(90, 19);
            label2.TabIndex = 1;
            label2.Text = "Policy Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(11, 112);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 2;
            label3.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(11, 151);
            label4.Name = "label4";
            label4.Size = new Size(86, 19);
            label4.TabIndex = 3;
            label4.Text = "Create Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(11, 189);
            label5.Name = "label5";
            label5.Size = new Size(90, 19);
            label5.TabIndex = 4;
            label5.Text = "Update Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(11, 226);
            label6.Name = "label6";
            label6.Size = new Size(84, 19);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F);
            label7.Location = new Point(11, 266);
            label7.Name = "label7";
            label7.Size = new Size(105, 19);
            label7.TabIndex = 6;
            label7.Text = "Resident Name:";
            // 
            // txtID
            // 
            txtID.Location = new Point(131, 37);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(219, 23);
            txtID.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 73);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(219, 23);
            txtName.TabIndex = 9;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(131, 111);
            txtDesc.Margin = new Padding(3, 2, 3, 2);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(219, 21);
            txtDesc.TabIndex = 10;
            // 
            // txtResidentName
            // 
            txtResidentName.Location = new Point(131, 264);
            txtResidentName.Margin = new Padding(3, 2, 3, 2);
            txtResidentName.Name = "txtResidentName";
            txtResidentName.Size = new Size(219, 23);
            txtResidentName.TabIndex = 14;
            // 
            // dateCreate
            // 
            dateCreate.Location = new Point(131, 147);
            dateCreate.Margin = new Padding(3, 2, 3, 2);
            dateCreate.Name = "dateCreate";
            dateCreate.Size = new Size(219, 23);
            dateCreate.TabIndex = 11;
            // 
            // dateUpdate
            // 
            dateUpdate.Location = new Point(131, 187);
            dateUpdate.Margin = new Padding(3, 2, 3, 2);
            dateUpdate.Name = "dateUpdate";
            dateUpdate.Size = new Size(219, 23);
            dateUpdate.TabIndex = 12;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(100, 314);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(189, 314);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(278, 314);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(cbbResidentID);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtResidentName);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(dateUpdate);
            panel1.Controls.Add(dateCreate);
            panel1.Controls.Add(txtDesc);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 363);
            panel1.TabIndex = 18;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(11, 314);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // cbbResidentID
            // 
            cbbResidentID.FormattingEnabled = true;
            cbbResidentID.Location = new Point(131, 222);
            cbbResidentID.Name = "cbbResidentID";
            cbbResidentID.Size = new Size(217, 23);
            cbbResidentID.TabIndex = 49;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(366, 29);
            label10.TabIndex = 48;
            label10.Text = "Policy Details";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(743, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Policy Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPolicy
            // 
            dgvPolicy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPolicy.Location = new Point(380, 73);
            dgvPolicy.Name = "dgvPolicy";
            dgvPolicy.Size = new Size(354, 320);
            dgvPolicy.TabIndex = 44;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F);
            label8.Location = new Point(380, 39);
            label8.Name = "label8";
            label8.Size = new Size(69, 19);
            label8.TabIndex = 51;
            label8.Text = "Policy ID:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(455, 35);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(279, 23);
            txtSearch.TabIndex = 51;
            // 
            // FormPolicy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 406);
            Controls.Add(txtSearch);
            Controls.Add(label8);
            Controls.Add(dgvPolicy);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPolicy";
            Text = "Policy Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPolicy).EndInit();
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
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtDesc;
        private DateTimePicker dateCreate;
        private DateTimePicker dateUpdate;
        private TextBox txtResidentName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private DataGridView dgvPolicy;
        private ComboBox cbbResidentID;
        private Button btnNew;
        private Label label8;
        private TextBox txtSearch;
    }
}
