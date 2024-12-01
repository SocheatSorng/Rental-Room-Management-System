namespace RRMS.Forms
{
    partial class LeaseAgreement
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtID = new TextBox();
            txtMonthlyRent = new TextBox();
            txtTerms = new TextBox();
            txtResidentName = new TextBox();
            dateStart = new DateTimePicker();
            dateEnd = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            titleLabel = new Label();
            inputGroup = new GroupBox();
            btnNew = new Button();
            cbbResidentID = new ComboBox();
            label8 = new Label();
            txtSearch = new TextBox();
            dgvLease = new DataGridView();
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(18, 120);
            label4.Name = "label4";
            label4.Size = new Size(96, 19);
            label4.TabIndex = 3;
            label4.Text = "Monthly Rent:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(18, 150);
            label5.Name = "label5";
            label5.Size = new Size(48, 19);
            label5.TabIndex = 4;
            label5.Text = "Terms:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(18, 210);
            label6.Name = "label6";
            label6.Size = new Size(82, 19);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(18, 240);
            label7.Name = "label7";
            label7.Size = new Size(104, 19);
            label7.TabIndex = 6;
            label7.Text = "Resident Name:";
            // 
            // txtID
            // 
            txtID.BackColor = Color.FromArgb(240, 240, 240);
            txtID.Location = new Point(122, 28);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(252, 25);
            txtID.TabIndex = 7;
            // 
            // txtMonthlyRent
            // 
            txtMonthlyRent.Location = new Point(122, 118);
            txtMonthlyRent.Margin = new Padding(3, 2, 3, 2);
            txtMonthlyRent.Name = "txtMonthlyRent";
            txtMonthlyRent.Size = new Size(252, 25);
            txtMonthlyRent.TabIndex = 10;
            // 
            // txtTerms
            // 
            txtTerms.Location = new Point(122, 148);
            txtTerms.Margin = new Padding(3, 2, 3, 2);
            txtTerms.Multiline = true;
            txtTerms.Name = "txtTerms";
            txtTerms.Size = new Size(252, 54);
            txtTerms.TabIndex = 11;
            // 
            // txtResidentName
            // 
            txtResidentName.BackColor = Color.FromArgb(240, 240, 240);
            txtResidentName.Location = new Point(122, 238);
            txtResidentName.Margin = new Padding(3, 2, 3, 2);
            txtResidentName.Name = "txtResidentName";
            txtResidentName.ReadOnly = true;
            txtResidentName.Size = new Size(252, 25);
            txtResidentName.TabIndex = 13;
            // 
            // dateStart
            // 
            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Location = new Point(122, 58);
            dateStart.Margin = new Padding(3, 2, 3, 2);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(252, 25);
            dateStart.TabIndex = 8;
            // 
            // dateEnd
            // 
            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Location = new Point(122, 88);
            dateEnd.Margin = new Padding(3, 2, 3, 2);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(252, 25);
            dateEnd.TabIndex = 9;
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
            inputGroup.Controls.Add(btnDelete);
            inputGroup.Controls.Add(btnUpdate);
            inputGroup.Controls.Add(btnInsert);
            inputGroup.Controls.Add(btnNew);
            inputGroup.Controls.Add(cbbResidentID);
            inputGroup.Controls.Add(label1);
            inputGroup.Controls.Add(label2);
            inputGroup.Controls.Add(label3);
            inputGroup.Controls.Add(label4);
            inputGroup.Controls.Add(label5);
            inputGroup.Controls.Add(label6);
            inputGroup.Controls.Add(label7);
            inputGroup.Controls.Add(txtID);
            inputGroup.Controls.Add(dateStart);
            inputGroup.Controls.Add(dateEnd);
            inputGroup.Controls.Add(txtMonthlyRent);
            inputGroup.Controls.Add(txtTerms);
            inputGroup.Controls.Add(txtResidentName);
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
            btnNew.UseVisualStyleBackColor = true;
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
            // cbbResidentID
            // 
            cbbResidentID.FormattingEnabled = true;
            cbbResidentID.Location = new Point(122, 207);
            cbbResidentID.Name = "cbbResidentID";
            cbbResidentID.Size = new Size(252, 25);
            cbbResidentID.TabIndex = 15;
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLease.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLease.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvLease.DefaultCellStyle = dataGridViewCellStyle5;
            dgvLease.Location = new Point(410, 73);
            dgvLease.Name = "dgvLease";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvLease.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvLease.Size = new Size(386, 301);
            dgvLease.TabIndex = 17;
            // 
            // LeaseAgreement
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
            Name = "LeaseAgreement";
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
        private TextBox txtID;
        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private TextBox txtMonthlyRent;
        private TextBox txtTerms;
        private TextBox txtResidentName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label titleLabel;
        private GroupBox inputGroup;
        private ComboBox cbbResidentID;
        private Button btnNew;
        private Label label8;
        private TextBox txtSearch;
        private DataGridView dgvLease;
    }
} 