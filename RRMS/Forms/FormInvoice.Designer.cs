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
            labelInvoiceDate = new Label();
            LabelInvoiceNo = new Label();
            txtSearch = new TextBox();
            labelSearch = new Label();
            cbbPaymentID = new ComboBox();
            labelPaymentStatusID = new Label();
            panel1 = new Panel();
            txtPaymentType = new TextBox();
            label1 = new Label();
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
            dtInvoiceDate.Location = new Point(160, 80);
            dtInvoiceDate.Name = "dtInvoiceDate";
            dtInvoiceDate.Size = new Size(257, 24);
            dtInvoiceDate.TabIndex = 3;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtInvoiceNo.Location = new Point(160, 40);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.ReadOnly = true;
            txtInvoiceNo.Size = new Size(257, 27);
            txtInvoiceNo.TabIndex = 2;
            // 
            // labelInvoiceDate
            // 
            labelInvoiceDate.AutoSize = true;
            labelInvoiceDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInvoiceDate.Location = new Point(25, 80);
            labelInvoiceDate.Name = "labelInvoiceDate";
            labelInvoiceDate.Size = new Size(98, 20);
            labelInvoiceDate.TabIndex = 134;
            labelInvoiceDate.Text = "Invoice Date";
            // 
            // LabelInvoiceNo
            // 
            LabelInvoiceNo.AutoSize = true;
            LabelInvoiceNo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelInvoiceNo.Location = new Point(25, 40);
            LabelInvoiceNo.Name = "LabelInvoiceNo";
            LabelInvoiceNo.Size = new Size(83, 20);
            LabelInvoiceNo.TabIndex = 133;
            LabelInvoiceNo.Text = "Invoice No";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtSearch.Location = new Point(622, 41);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(355, 27);
            txtSearch.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSearch.Location = new Point(556, 43);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(60, 20);
            labelSearch.TabIndex = 130;
            labelSearch.Text = "Search";
            // 
            // cbbPaymentID
            // 
            cbbPaymentID.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbPaymentID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cbbPaymentID.FormattingEnabled = true;
            cbbPaymentID.Location = new Point(160, 120);
            cbbPaymentID.Name = "cbbPaymentID";
            cbbPaymentID.Size = new Size(257, 32);
            cbbPaymentID.TabIndex = 4;
            // 
            // labelPaymentStatusID
            // 
            labelPaymentStatusID.AutoSize = true;
            labelPaymentStatusID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPaymentStatusID.Location = new Point(25, 120);
            labelPaymentStatusID.Name = "labelPaymentStatusID";
            labelPaymentStatusID.Size = new Size(92, 20);
            labelPaymentStatusID.TabIndex = 136;
            labelPaymentStatusID.Text = "Payment ID";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtPaymentType);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(dtInvoiceDate);
            panel1.Controls.Add(cbbPaymentID);
            panel1.Controls.Add(txtInvoiceNo);
            panel1.Controls.Add(labelPaymentStatusID);
            panel1.Controls.Add(labelInvoiceDate);
            panel1.Controls.Add(LabelInvoiceNo);
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 182;
            // 
            // txtPaymentType
            // 
            txtPaymentType.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentType.Location = new Point(160, 160);
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Size = new Size(257, 27);
            txtPaymentType.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 160);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 187;
            label1.Text = "Payment Type";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(334, 210);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(229, 210);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(126, 210);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 210);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 6;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(550, 29);
            label17.TabIndex = 182;
            label17.Text = "Invoice Details";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(980, 30);
            titleLabel.TabIndex = 183;
            titleLabel.Text = "Invoice Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvInvoice
            // 
            dgvInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoice.Location = new Point(550, 76);
            dgvInvoice.Name = "dgvInvoice";
            dgvInvoice.Size = new Size(480, 586);
            dgvInvoice.TabIndex = 10;
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(980, 657);
            Controls.Add(dgvInvoice);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(labelSearch);
            Controls.Add(txtSearch);
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
        private Label labelInvoiceDate;
        private Label LabelInvoiceNo;
        private TextBox txtSearch;
        private Label labelSearch;
        private ComboBox cbbPaymentID;
        private Label labelPaymentStatusID;
        private Panel panel1;
        private Label titleLabel;
        private Label label17;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private Button btnNew;
        private DataGridView dgvInvoice;
        private Label label1;
        private TextBox txtPaymentType;
    }
}