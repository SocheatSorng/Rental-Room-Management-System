namespace RRMS.Forms
{
    partial class FormPayment
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
            dTPaymentDate = new DateTimePicker();
            txtPaymentAmount = new TextBox();
            txtPaymentNo = new TextBox();
            labelMajorID = new Label();
            labelPaymentDate = new Label();
            LabelPaymentNo = new Label();
            txtSearchPayment = new TextBox();
            labelSearch = new Label();
            cBPaymentStatusID = new ComboBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label12 = new Label();
            textBox1 = new TextBox();
            checkBox2 = new CheckBox();
            txtID = new TextBox();
            label5 = new Label();
            labelPaymentAmount = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            btnDelete = new Button();
            label17 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dTPaymentDate
            // 
            dTPaymentDate.CustomFormat = "yyyy/MM/dd";
            dTPaymentDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            dTPaymentDate.Location = new Point(140, 76);
            dTPaymentDate.Name = "dTPaymentDate";
            dTPaymentDate.Size = new Size(264, 24);
            dTPaymentDate.TabIndex = 118;
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentAmount.Location = new Point(140, 300);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.ReadOnly = true;
            txtPaymentAmount.Size = new Size(261, 27);
            txtPaymentAmount.TabIndex = 113;
            // 
            // txtPaymentNo
            // 
            txtPaymentNo.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            txtPaymentNo.Location = new Point(140, 34);
            txtPaymentNo.Name = "txtPaymentNo";
            txtPaymentNo.ReadOnly = true;
            txtPaymentNo.Size = new Size(261, 27);
            txtPaymentNo.TabIndex = 111;
            // 
            // labelMajorID
            // 
            labelMajorID.AutoSize = true;
            labelMajorID.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelMajorID.Location = new Point(9, 309);
            labelMajorID.Name = "labelMajorID";
            labelMajorID.Size = new Size(114, 18);
            labelMajorID.TabIndex = 107;
            labelMajorID.Text = "Remain Amount";
            // 
            // labelPaymentDate
            // 
            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelPaymentDate.Location = new Point(8, 83);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(101, 18);
            labelPaymentDate.TabIndex = 104;
            labelPaymentDate.Text = "Payment Date";
            // 
            // LabelPaymentNo
            // 
            LabelPaymentNo.AutoSize = true;
            LabelPaymentNo.Font = new Font("Microsoft Sans Serif", 11.25F);
            LabelPaymentNo.Location = new Point(9, 41);
            LabelPaymentNo.Name = "LabelPaymentNo";
            LabelPaymentNo.Size = new Size(90, 18);
            LabelPaymentNo.TabIndex = 103;
            LabelPaymentNo.Text = "Payment No";
            // 
            // txtSearchPayment
            // 
            txtSearchPayment.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            txtSearchPayment.Location = new Point(509, 43);
            txtSearchPayment.Name = "txtSearchPayment";
            txtSearchPayment.Size = new Size(519, 24);
            txtSearchPayment.TabIndex = 101;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelSearch.Location = new Point(427, 46);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(76, 18);
            labelSearch.TabIndex = 100;
            labelSearch.Text = "Search By";
            // 
            // cBPaymentStatusID
            // 
            cBPaymentStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            cBPaymentStatusID.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            cBPaymentStatusID.FormattingEnabled = true;
            cBPaymentStatusID.Location = new Point(141, 118);
            cBPaymentStatusID.Name = "cBPaymentStatusID";
            cBPaymentStatusID.Size = new Size(261, 32);
            cBPaymentStatusID.TabIndex = 114;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F);
            label2.Location = new Point(9, 354);
            label2.Name = "label2";
            label2.Size = new Size(216, 18);
            label2.TabIndex = 165;
            label2.Text = "Second Amount Has Been Paid";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Microsoft Sans Serif", 11.25F);
            checkBox1.Location = new Point(231, 358);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 167;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 11.25F);
            label12.Location = new Point(9, 264);
            label12.Name = "label12";
            label12.Size = new Size(92, 18);
            label12.TabIndex = 169;
            label12.Text = "Paid Amount";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(141, 253);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(261, 29);
            textBox1.TabIndex = 168;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Microsoft Sans Serif", 11.25F);
            checkBox2.Location = new Point(121, 212);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 172;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            txtID.Location = new Point(140, 210);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(261, 23);
            txtID.TabIndex = 174;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F);
            label5.Location = new Point(9, 209);
            label5.Name = "label5";
            label5.Size = new Size(65, 18);
            label5.TabIndex = 173;
            label5.Text = "Utility ID:";
            // 
            // labelPaymentAmount
            // 
            labelPaymentAmount.AutoSize = true;
            labelPaymentAmount.Font = new Font("Microsoft Sans Serif", 11.25F);
            labelPaymentAmount.Location = new Point(8, 125);
            labelPaymentAmount.Name = "labelPaymentAmount";
            labelPaymentAmount.Size = new Size(105, 18);
            labelPaymentAmount.TabIndex = 105;
            labelPaymentAmount.Text = "Reservation ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F);
            label4.Location = new Point(9, 403);
            label4.Name = "label4";
            label4.Size = new Size(60, 18);
            label4.TabIndex = 175;
            label4.Text = "Staff ID:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(140, 165);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(261, 23);
            textBox3.TabIndex = 178;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F);
            label6.Location = new Point(9, 165);
            label6.Name = "label6";
            label6.Size = new Size(86, 18);
            label6.TabIndex = 177;
            label6.Text = "Staff Name:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Sitka Small", 12F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(141, 396);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(264, 32);
            comboBox1.TabIndex = 179;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dTPaymentDate);
            panel1.Controls.Add(cBPaymentStatusID);
            panel1.Controls.Add(txtPaymentAmount);
            panel1.Controls.Add(txtPaymentNo);
            panel1.Controls.Add(labelMajorID);
            panel1.Controls.Add(labelPaymentAmount);
            panel1.Controls.Add(labelPaymentDate);
            panel1.Controls.Add(LabelPaymentNo);
            panel1.Location = new Point(12, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(410, 688);
            panel1.TabIndex = 180;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(318, 445);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 184;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(51, 122, 183);
            label17.Dock = DockStyle.Top;
            label17.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(0, 0);
            label17.Name = "label17";
            label17.Size = new Size(410, 29);
            label17.TabIndex = 180;
            label17.Text = "Payment Details";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(240, 173, 78);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(212, 445);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(83, 26);
            button1.TabIndex = 183;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(92, 184, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(111, 445);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(83, 26);
            button2.TabIndex = 182;
            button2.Text = "Insert";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(217, 83, 79);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(12, 445);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(83, 26);
            button3.TabIndex = 185;
            button3.Text = "New";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(51, 122, 183);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1040, 30);
            label1.TabIndex = 181;
            label1.Text = "Payment Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(428, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(612, 647);
            dataGridView1.TabIndex = 182;
            // 
            // FormPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 241, 242);
            ClientSize = new Size(1040, 738);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(txtSearchPayment);
            Controls.Add(labelSearch);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaymentForm";
            Load += FormPayment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dTPaymentDate;
        private TextBox txtPaymentAmount;
        private TextBox txtPaymentNo;
        private Label labelMajorID;
        private Label labelPaymentDate;
        private Label LabelPaymentNo;
        private TextBox txtSearchPayment;
        private Label labelSearch;
        private ComboBox cBPaymentStatusID;
        private Label label2;
        private CheckBox checkBox1;
        private Label label12;
        private TextBox textBox1;
        private CheckBox checkBox2;
        private TextBox txtID;
        private Label label5;
        private Label labelPaymentAmount;
        private Label label4;
        private TextBox textBox3;
        private Label label6;
        private ComboBox comboBox1;
        private Panel panel1;
        private Label label1;
        private Label label17;
        private Button btnDelete;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
    }
}