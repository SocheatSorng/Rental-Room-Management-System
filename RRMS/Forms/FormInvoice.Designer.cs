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
            dTInvoiceDate = new DateTimePicker();
            txtInvoiceNo = new TextBox();
            labelStaffID = new Label();
            labelInvoiceDate = new Label();
            LabelInvoiceNo = new Label();
            txtSearchInvoice = new TextBox();
            labelSearch = new Label();
            txtStaffID = new TextBox();
            cBPaymentStatusID = new ComboBox();
            labelPaymentStatusID = new Label();
            labelMajorCost = new Label();
            txtMajorCost = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            btnDelete = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label17 = new Label();
            titleLabel = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dTInvoiceDate
            // 
            dTInvoiceDate.CustomFormat = "yyyy/MM/dd";
            dTInvoiceDate.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dTInvoiceDate.Location = new Point(143, 112);
            dTInvoiceDate.Name = "dTInvoiceDate";
            dTInvoiceDate.Size = new Size(257, 24);
            dTInvoiceDate.TabIndex = 146;
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
            // txtStaffID
            // 
            txtStaffID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtStaffID.Location = new Point(143, 189);
            txtStaffID.Name = "txtStaffID";
            txtStaffID.ReadOnly = true;
            txtStaffID.Size = new Size(257, 27);
            txtStaffID.TabIndex = 161;
            // 
            // cBPaymentStatusID
            // 
            cBPaymentStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPaymentStatusID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cBPaymentStatusID.FormattingEnabled = true;
            cBPaymentStatusID.Location = new Point(143, 142);
            cBPaymentStatusID.Name = "cBPaymentStatusID";
            cBPaymentStatusID.Size = new Size(257, 32);
            cBPaymentStatusID.TabIndex = 143;
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
            // txtMajorCost
            // 
            txtMajorCost.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtMajorCost.Location = new Point(143, 267);
            txtMajorCost.Name = "txtMajorCost";
            txtMajorCost.ReadOnly = true;
            txtMajorCost.Size = new Size(257, 27);
            txtMajorCost.TabIndex = 154;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 230);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(257, 23);
            textBox1.TabIndex = 181;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F);
            label2.Location = new Point(12, 228);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 180;
            label2.Text = "Staff Name:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtStaffID);
            panel1.Controls.Add(txtMajorCost);
            panel1.Controls.Add(labelMajorCost);
            panel1.Controls.Add(dTInvoiceDate);
            panel1.Controls.Add(cBPaymentStatusID);
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(240, 173, 78);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(213, 305);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(83, 26);
            button1.TabIndex = 184;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(92, 184, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(115, 305);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(83, 26);
            button2.TabIndex = 183;
            button2.Text = "Insert";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(217, 83, 79);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(18, 305);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(83, 26);
            button3.TabIndex = 186;
            button3.Text = "New";
            button3.UseVisualStyleBackColor = false;
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(445, 76);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(595, 650);
            dataGridView1.TabIndex = 184;
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(1040, 738);
            Controls.Add(dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dTInvoiceDate;
        private TextBox txtInvoiceNo;
        private Label labelStaffID;
        private Label labelInvoiceDate;
        private Label LabelInvoiceNo;
        private TextBox txtSearchInvoice;
        private Label labelSearch;
        private TextBox txtStaffID;
        private ComboBox cBPaymentStatusID;
        private Label labelPaymentStatusID;
        private Label labelMajorCost;
        private TextBox txtMajorCost;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private Label titleLabel;
        private Label label17;
        private Button btnDelete;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
    }
}