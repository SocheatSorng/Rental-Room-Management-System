namespace RRMS.Forms
{
    partial class FormInvoice
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
            dtInvoiceDate = new DateTimePicker();
            txtInvoiceNo = new TextBox();
            labelStaffID = new Label();
            labelInvoiceDate = new Label();
            LabelInvoiceNo = new Label();
            txtSearchInvoice = new TextBox();
            labelSearch = new Label();
            txtResName = new TextBox();
            cbbPaymentID = new ComboBox();
            labelPaymentStatusID = new Label();
            labelMajorCost = new Label();
            txtAmount = new TextBox();
            txtStaName = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            btnNew = new Button();
            label17 = new Label();
            titleLabel = new Label();
            dgvInvoice = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).BeginInit();
            SuspendLayout();
            // 
            // dtInvoiceDate
            // 
            dtInvoiceDate.CustomFormat = "yyyy/MM/dd";
            dtInvoiceDate.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtInvoiceDate.Location = new Point(143, 112);
            dtInvoiceDate.Name = "dtInvoiceDate";
            dtInvoiceDate.Size = new Size(257, 24);
            dtInvoiceDate.TabIndex = 146;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtInvoiceNo.Location = new Point(143, 65);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.ReadOnly = true;
            txtInvoiceNo.Size = new Size(257, 27);
            txtInvoiceNo.TabIndex = 141;
            // 
            // labelStaffID
            // 
            labelStaffID.AutoSize = true;
            labelStaffID.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelStaffID.Location = new Point(12, 189);
            labelStaffID.Name = "labelStaffID";
            labelStaffID.Size = new Size(110, 18);
            labelStaffID.TabIndex = 138;
            labelStaffID.Text = "Resident Name";
            // 
            // labelInvoiceDate
            // 
            labelInvoiceDate.AutoSize = true;
            labelInvoiceDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelInvoiceDate.Location = new Point(12, 112);
            labelInvoiceDate.Name = "labelInvoiceDate";
            labelInvoiceDate.Size = new Size(89, 18);
            labelInvoiceDate.TabIndex = 134;
            labelInvoiceDate.Text = "Invoice Date";
            // 
            // LabelInvoiceNo
            // 
            LabelInvoiceNo.AutoSize = true;
            LabelInvoiceNo.Font = new Font("Microsoft Sans Serif", 11.25F);
            LabelInvoiceNo.Location = new Point(12, 67);
            LabelInvoiceNo.Name = "LabelInvoiceNo";
            LabelInvoiceNo.Size = new Size(78, 18);
            LabelInvoiceNo.TabIndex = 133;
            LabelInvoiceNo.Text = "Invoice No";
            // 
            // txtSearchInvoice
            // 
            txtSearchInvoice.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtSearchInvoice.Location = new Point(527, 43);
            txtSearchInvoice.Name = "txtSearchInvoice";
            txtSearchInvoice.Size = new Size(513, 27);
            txtSearchInvoice.TabIndex = 131;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelSearch.Location = new Point(445, 50);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(76, 18);
            labelSearch.TabIndex = 130;
            labelSearch.Text = "Search By";
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtResName.Location = new Point(143, 189);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(257, 27);
            txtResName.TabIndex = 161;
            // 
            // cbbPaymentID
            // 
            cbbPaymentID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPaymentID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbPaymentID.FormattingEnabled = true;
            cbbPaymentID.Location = new Point(143, 142);
            cbbPaymentID.Name = "cbbPaymentID";
            cbbPaymentID.Size = new Size(257, 32);
            cbbPaymentID.TabIndex = 143;
            // 
            // labelPaymentStatusID
            // 
            labelPaymentStatusID.AutoSize = true;
            labelPaymentStatusID.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelPaymentStatusID.Location = new Point(12, 149);
            labelPaymentStatusID.Name = "labelPaymentStatusID";
            labelPaymentStatusID.Size = new Size(84, 18);
            labelPaymentStatusID.TabIndex = 136;
            labelPaymentStatusID.Text = "Payment ID";
            // 
            // labelMajorCost
            // 
            labelMajorCost.AutoSize = true;
            labelMajorCost.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelMajorCost.Location = new Point(12, 269);
            labelMajorCost.Name = "labelMajorCost";
            labelMajorCost.Size = new Size(59, 18);
            labelMajorCost.TabIndex = 153;
            labelMajorCost.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtAmount.Location = new Point(143, 267);
            txtAmount.Name = "txtAmount";
            txtAmount.ReadOnly = true;
            txtAmount.Size = new Size(257, 27);
            txtAmount.TabIndex = 154;
            // 
            // txtStaName
            // 
            txtStaName.Location = new Point(143, 230);
            txtStaName.Margin = new Padding(3, 2, 3, 2);
            txtStaName.Name = "txtStaName";
            txtStaName.ReadOnly = true;
            txtStaName.Size = new Size(257, 23);
            txtStaName.TabIndex = 181;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F);
            label2.Location = new Point(12, 230);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 180;
            label2.Text = "Staff Name:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(txtStaName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(txtAmount);
            panel1.Controls.Add(labelMajorCost);
            panel1.Controls.Add(dtInvoiceDate);
            panel1.Controls.Add(cbbPaymentID);
            panel1.Controls.Add(txtInvoiceNo);
            panel1.Controls.Add(labelStaffID);
            panel1.Controls.Add(labelPaymentStatusID);
            panel1.Controls.Add(labelInvoiceDate);
            panel1.Controls.Add(LabelInvoiceNo);
            panel1.Location = new Point(10, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 687);
            panel1.TabIndex = 182;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(317, 305);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 185;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(213, 305);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 184;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(115, 305);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 183;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(18, 305);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 186;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(429, 29);
            label17.TabIndex = 182;
            label17.Text = "Invoice Details";
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
            titleLabel.Size = new Size(1040, 30);
            titleLabel.TabIndex = 183;
            titleLabel.Text = "Invoice Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvInvoice
            // 
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoice.Location = new Point(445, 76);
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.Size = new Size(595, 650);
            dgvInvoice.TabIndex = 184;
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(1040, 738);
            Controls.Add(dgvInvoice);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(labelSearch);
            Controls.Add(txtSearchInvoice);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtInvoiceDate;
        private TextBox txtInvoiceNo;
        private Label labelStaffID;
        private Label labelInvoiceDate;
        private Label LabelInvoiceNo;
        private TextBox txtSearchInvoice;
        private Label labelSearch;
        private TextBox txtResName;
        private ComboBox cbbPaymentID;
        private Label labelPaymentStatusID;
        private Label labelMajorCost;
        private TextBox txtAmount;
        private TextBox txtStaName;
        private Label label2;
        private Panel panel1;
        private Label titleLabel;
        private Label label17;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private Button btnNew;
        private DataGridView dgvInvoice;
    }
}