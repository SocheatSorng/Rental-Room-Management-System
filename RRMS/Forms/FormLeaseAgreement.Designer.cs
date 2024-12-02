namespace RRMS.Forms
{
    partial class FormLeaseAgreement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtLeaseID = new TextBox();
            dtpLeaseSD = new DateTimePicker();
            dtpLeaseED = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            titleLabel = new Label();
            inputGroup = new GroupBox();
            btnNew = new Button();
            cbbResID = new ComboBox();
            label8 = new Label();
            txtSearch = new TextBox();
            dgvLease = new DataGridView();
            txtLeaseTAC = new TextBox();
            txtResName = new TextBox();
            inputGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLease).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(64, 19);
            label1.TabIndex = 0;
            label1.Text = "Lease ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(18, 60);
            label2.Name = "label2";
            label2.Size = new Size(74, 19);
            label2.TabIndex = 1;
            label2.Text = "Start Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(18, 90);
            label3.Name = "label3";
            label3.Size = new Size(68, 19);
            label3.TabIndex = 2;
            label3.Text = "End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(18, 144);
            label5.Name = "label5";
            label5.Size = new Size(48, 19);
            label5.TabIndex = 4;
            label5.Text = "Terms:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(18, 195);
            label6.Name = "label6";
            label6.Size = new Size(82, 19);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(18, 237);
            label7.Name = "label7";
            label7.Size = new Size(104, 19);
            label7.TabIndex = 6;
            label7.Text = "Resident Name:";
            // 
            // txtLeaseID
            // 
            txtLeaseID.BackColor = Color.FromArgb(240, 240, 240);
            txtLeaseID.Location = new Point(122, 28);
            txtLeaseID.Margin = new Padding(3, 2, 3, 2);
            txtLeaseID.Name = "txtLeaseID";
            txtLeaseID.ReadOnly = true;
            txtLeaseID.Size = new Size(252, 25);
            txtLeaseID.TabIndex = 7;
            // 
            // dtpLeaseSD
            // 
            dtpLeaseSD.Format = DateTimePickerFormat.Short;
            dtpLeaseSD.Location = new Point(122, 58);
            dtpLeaseSD.Margin = new Padding(3, 2, 3, 2);
            dtpLeaseSD.Name = "dtpLeaseSD";
            dtpLeaseSD.Size = new Size(252, 25);
            dtpLeaseSD.TabIndex = 8;
            // 
            // dtpLeaseED
            // 
            dtpLeaseED.Format = DateTimePickerFormat.Short;
            dtpLeaseED.Location = new Point(122, 88);
            dtpLeaseED.Margin = new Padding(3, 2, 3, 2);
            dtpLeaseED.Name = "dtpLeaseED";
            dtpLeaseED.Size = new Size(252, 25);
            dtpLeaseED.TabIndex = 9;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(113, 283);
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
            btnUpdate.Location = new Point(202, 284);
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
            btnDelete.Location = new Point(291, 284);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(9, 8);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(790, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Lease Agreement Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // inputGroup
            // 
            inputGroup.BackColor = Color.White;
            inputGroup.Controls.Add(txtResName);
            inputGroup.Controls.Add(txtLeaseTAC);
            inputGroup.Controls.Add(btnDelete);
            inputGroup.Controls.Add(btnUpdate);
            inputGroup.Controls.Add(btnInsert);
            inputGroup.Controls.Add(btnNew);
            inputGroup.Controls.Add(cbbResID);
            inputGroup.Controls.Add(label1);
            inputGroup.Controls.Add(label2);
            inputGroup.Controls.Add(label3);
            inputGroup.Controls.Add(label5);
            inputGroup.Controls.Add(label6);
            inputGroup.Controls.Add(label7);
            inputGroup.Controls.Add(txtLeaseID);
            inputGroup.Controls.Add(dtpLeaseSD);
            inputGroup.Controls.Add(dtpLeaseED);
            inputGroup.Font = new Font("Segoe UI", 10F);
            inputGroup.Location = new Point(18, 45);
            inputGroup.Margin = new Padding(3, 2, 3, 2);
            inputGroup.Name = "inputGroup";
            inputGroup.Padding = new Padding(3, 2, 3, 2);
            inputGroup.Size = new Size(386, 330);
            inputGroup.TabIndex = 1;
            inputGroup.TabStop = false;
            inputGroup.Text = "Lease Agreement Details";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(24, 283);
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
            cbbResID.Location = new Point(122, 189);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(252, 25);
            cbbResID.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(408, 45);
            label8.Name = "label8";
            label8.Size = new Size(49, 19);
            label8.TabIndex = 16;
            label8.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(463, 45);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(333, 23);
            txtSearch.TabIndex = 16;
            // 
            // dgvLease
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLease.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLease.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLease.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLease.Location = new Point(410, 73);
            dgvLease.Name = "dgvLease";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLease.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLease.Size = new Size(386, 301);
            dgvLease.TabIndex = 17;
            // 
            // txtLeaseTAC
            // 
            txtLeaseTAC.Location = new Point(122, 144);
            txtLeaseTAC.Margin = new Padding(3, 2, 3, 2);
            txtLeaseTAC.Name = "txtLeaseTAC";
            txtLeaseTAC.Size = new Size(252, 25);
            txtLeaseTAC.TabIndex = 18;
            // 
            // txtResName
            // 
            txtResName.Location = new Point(122, 234);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(252, 25);
            txtResName.TabIndex = 19;
            // 
            // FormLeaseAgreement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(808, 390);
            Controls.Add(dgvLease);
            Controls.Add(txtSearch);
            Controls.Add(label8);
            Controls.Add(titleLabel);
            Controls.Add(inputGroup);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(702, 400);
            Name = "FormLeaseAgreement";
            Padding = new Padding(9, 8, 9, 8);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lease Agreement Management";
            inputGroup.ResumeLayout(false);
            inputGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLease).EndInit();
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
        private TextBox txtLeaseID;
        private DateTimePicker dtpLeaseSD;
        private DateTimePicker dtpLeaseED;
        private TextBox txtMonthlyRent;
        private TextBox txtTerms;
        private TextBox txtResidentName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label titleLabel;
        private GroupBox inputGroup;
        private ComboBox cbbResID;
        private Button btnNew;
        private Label label8;
        private TextBox txtSearch;
        private DataGridView dgvLease;
        private TextBox txtLeaseTAC;
        private TextBox txtResName;
    }
} 