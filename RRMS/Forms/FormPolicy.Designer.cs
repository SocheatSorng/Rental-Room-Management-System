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
            // txtPolID
            // 
            txtPolID.Location = new Point(131, 37);
            txtPolID.Margin = new Padding(3, 2, 3, 2);
            txtPolID.Name = "txtPolID";
            txtPolID.ReadOnly = true;
            txtPolID.Size = new Size(219, 23);
            txtPolID.TabIndex = 8;
            // 
            // txtPolName
            // 
            txtPolName.Location = new Point(131, 73);
            txtPolName.Margin = new Padding(3, 2, 3, 2);
            txtPolName.Name = "txtPolName";
            txtPolName.Size = new Size(219, 23);
            txtPolName.TabIndex = 9;
            // 
            // txtPolDesc
            // 
            txtPolDesc.Location = new Point(131, 111);
            txtPolDesc.Margin = new Padding(3, 2, 3, 2);
            txtPolDesc.Multiline = true;
            txtPolDesc.Name = "txtPolDesc";
            txtPolDesc.Size = new Size(219, 21);
            txtPolDesc.TabIndex = 10;
            // 
            // txtResName
            // 
            txtResName.Location = new Point(131, 264);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(219, 23);
            txtResName.TabIndex = 14;
            // 
            // dtpPolCD
            // 
            dtpPolCD.Location = new Point(131, 147);
            dtpPolCD.Margin = new Padding(3, 2, 3, 2);
            dtpPolCD.Name = "dtpPolCD";
            dtpPolCD.Size = new Size(219, 23);
            dtpPolCD.TabIndex = 11;
            // 
            // dtpPolUD
            // 
            dtpPolUD.Location = new Point(131, 187);
            dtpPolUD.Margin = new Padding(3, 2, 3, 2);
            dtpPolUD.Name = "dtpPolUD";
            dtpPolUD.Size = new Size(219, 23);
            dtpPolUD.TabIndex = 12;
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
            panel1.BackColor = Color.White;
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
            panel1.Size = new Size(366, 695);
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
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(131, 222);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(217, 23);
            cbbResID.TabIndex = 49;
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
            titleLabel.Size = new Size(1044, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Policy Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPol
            // 
            dgvPol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPol.Location = new Point(380, 73);
            dgvPol.Name = "dgvPol";
            dgvPol.Size = new Size(652, 657);
            dgvPol.TabIndex = 44;
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
            txtSearch.Size = new Size(577, 23);
            txtSearch.TabIndex = 51;
            // 
            // FormPolicy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
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
    }
}
