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
            btnNew = new Button();
            dTInvoiceDate = new DateTimePicker();
            txtInvoiceNo = new TextBox();
            labelStaffID = new Label();
            labelInvoiceDate = new Label();
            LabelInvoiceNo = new Label();
            lsInvoice = new ListBox();
            txtSearchInvoice = new TextBox();
            labelSearch = new Label();
            btnClose = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            txtStaffID = new TextBox();
            cBPaymentStatusID = new ComboBox();
            labelPaymentStatusID = new Label();
            labelMajorCost = new Label();
            txtMajorCost = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(25, 149, 173);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnNew.Location = new Point(51, 568);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(121, 49);
            btnNew.TabIndex = 147;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // dTInvoiceDate
            // 
            dTInvoiceDate.CustomFormat = "yyyy/MM/dd";
            dTInvoiceDate.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            dTInvoiceDate.Location = new Point(426, 175);
            dTInvoiceDate.Name = "dTInvoiceDate";
            dTInvoiceDate.Size = new Size(295, 27);
            dTInvoiceDate.TabIndex = 146;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtInvoiceNo.Location = new Point(426, 128);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.ReadOnly = true;
            txtInvoiceNo.Size = new Size(295, 27);
            txtInvoiceNo.TabIndex = 141;
            // 
            // labelStaffID
            // 
            labelStaffID.AutoSize = true;
            labelStaffID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelStaffID.Location = new Point(250, 277);
            labelStaffID.Name = "labelStaffID";
            labelStaffID.Size = new Size(137, 24);
            labelStaffID.TabIndex = 138;
            labelStaffID.Text = "Resident Name";
            // 
            // labelInvoiceDate
            // 
            labelInvoiceDate.AutoSize = true;
            labelInvoiceDate.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelInvoiceDate.Location = new Point(250, 178);
            labelInvoiceDate.Name = "labelInvoiceDate";
            labelInvoiceDate.Size = new Size(115, 24);
            labelInvoiceDate.TabIndex = 134;
            labelInvoiceDate.Text = "Invoice Date";
            // 
            // LabelInvoiceNo
            // 
            LabelInvoiceNo.AutoSize = true;
            LabelInvoiceNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            LabelInvoiceNo.Location = new Point(250, 128);
            LabelInvoiceNo.Name = "LabelInvoiceNo";
            LabelInvoiceNo.Size = new Size(99, 24);
            LabelInvoiceNo.TabIndex = 133;
            LabelInvoiceNo.Text = "Invoice No";
            // 
            // lsInvoice
            // 
            lsInvoice.Font = new Font("Microsoft Sans Serif", 12F);
            lsInvoice.FormattingEnabled = true;
            lsInvoice.ItemHeight = 20;
            lsInvoice.Location = new Point(16, 162);
            lsInvoice.Name = "lsInvoice";
            lsInvoice.Size = new Size(211, 364);
            lsInvoice.TabIndex = 132;
            // 
            // txtSearchInvoice
            // 
            txtSearchInvoice.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtSearchInvoice.Location = new Point(16, 128);
            txtSearchInvoice.Name = "txtSearchInvoice";
            txtSearchInvoice.Size = new Size(211, 27);
            txtSearchInvoice.TabIndex = 131;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            labelSearch.Location = new Point(16, 97);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(112, 28);
            labelSearch.TabIndex = 130;
            labelSearch.Text = "Search By";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(255, 128, 128);
            btnClose.FlatAppearance.BorderColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(650, 568);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(121, 49);
            btnClose.TabIndex = 159;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(85, 194, 218);
            btnUpdate.FlatAppearance.BorderColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(445, 568);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 49);
            btnUpdate.TabIndex = 158;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(25, 149, 173);
            btnInsert.FlatAppearance.BorderColor = Color.White;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Sitka Small", 14F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(244, 568);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(121, 49);
            btnInsert.TabIndex = 157;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 89);
            panel1.TabIndex = 160;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(15, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 78;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 11.249999F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(616, 59);
            label3.Name = "label3";
            label3.Size = new Size(192, 23);
            label3.TabIndex = 76;
            label3.Text = "ISAD M3 GROUP1 2024";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 15.7499981F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(111, 30);
            label1.Name = "label1";
            label1.Size = new Size(178, 31);
            label1.TabIndex = 73;
            label1.Text = "Invoice's Form";
            // 
            // txtStaffID
            // 
            txtStaffID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtStaffID.Location = new Point(426, 272);
            txtStaffID.Name = "txtStaffID";
            txtStaffID.ReadOnly = true;
            txtStaffID.Size = new Size(295, 27);
            txtStaffID.TabIndex = 161;
            // 
            // cBPaymentStatusID
            // 
            cBPaymentStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPaymentStatusID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cBPaymentStatusID.FormattingEnabled = true;
            cBPaymentStatusID.Location = new Point(426, 223);
            cBPaymentStatusID.Name = "cBPaymentStatusID";
            cBPaymentStatusID.Size = new Size(295, 32);
            cBPaymentStatusID.TabIndex = 143;
            // 
            // labelPaymentStatusID
            // 
            labelPaymentStatusID.AutoSize = true;
            labelPaymentStatusID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelPaymentStatusID.Location = new Point(250, 227);
            labelPaymentStatusID.Name = "labelPaymentStatusID";
            labelPaymentStatusID.Size = new Size(109, 24);
            labelPaymentStatusID.TabIndex = 136;
            labelPaymentStatusID.Text = "Payment ID";
            // 
            // labelMajorCost
            // 
            labelMajorCost.AutoSize = true;
            labelMajorCost.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            labelMajorCost.Location = new Point(250, 360);
            labelMajorCost.Name = "labelMajorCost";
            labelMajorCost.Size = new Size(77, 24);
            labelMajorCost.TabIndex = 153;
            labelMajorCost.Text = "Amount";
            // 
            // txtMajorCost
            // 
            txtMajorCost.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtMajorCost.Location = new Point(426, 356);
            txtMajorCost.Name = "txtMajorCost";
            txtMajorCost.ReadOnly = true;
            txtMajorCost.Size = new Size(295, 27);
            txtMajorCost.TabIndex = 154;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(426, 315);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(295, 23);
            textBox1.TabIndex = 181;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(252, 319);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 180;
            label2.Text = "Staff Name:";
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(811, 633);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(txtStaffID);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtMajorCost);
            Controls.Add(labelMajorCost);
            Controls.Add(btnNew);
            Controls.Add(dTInvoiceDate);
            Controls.Add(cBPaymentStatusID);
            Controls.Add(txtInvoiceNo);
            Controls.Add(labelStaffID);
            Controls.Add(labelPaymentStatusID);
            Controls.Add(labelInvoiceDate);
            Controls.Add(LabelInvoiceNo);
            Controls.Add(lsInvoice);
            Controls.Add(txtSearchInvoice);
            Controls.Add(labelSearch);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormInvoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InvoiceForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnNew;
        private DateTimePicker dTInvoiceDate;
        private TextBox txtInvoiceNo;
        private Label labelStaffID;
        private Label labelInvoiceDate;
        private Label LabelInvoiceNo;
        private ListBox lsInvoice;
        private TextBox txtSearchInvoice;
        private Label labelSearch;
        private Button btnClose;
        private Button btnUpdate;
        private Button btnInsert;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private TextBox txtStaffID;
        private ComboBox cBPaymentStatusID;
        private Label labelPaymentStatusID;
        private Label labelMajorCost;
        private TextBox txtMajorCost;
        private TextBox textBox1;
        private Label label2;
    }
}