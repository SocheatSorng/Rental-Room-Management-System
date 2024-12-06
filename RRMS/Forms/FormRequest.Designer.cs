namespace RRMS.Forms
{
    partial class FormRequest
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtReqID = new TextBox();
            txtReqDesc = new TextBox();
            txtResName = new TextBox();
            dgvReq = new DataGridView();
            btnNew = new Button();
            btnUpdate = new Button();
            dtpReqDate = new DateTimePicker();
            cbbResID = new ComboBox();
            label7 = new Label();
            txtSerName = new TextBox();
            label8 = new Label();
            btnInsert = new Button();
            txtSearch = new TextBox();
            label9 = new Label();
            btnDelete = new Button();
            panel1 = new Panel();
            cbbSerStatus = new ComboBox();
            cbbSerID = new ComboBox();
            label10 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReq).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "RequestID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 1;
            label2.Text = "RequestDate :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 120);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Description :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 200);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 3;
            label4.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 160);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 4;
            label5.Text = "Status :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 280);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 5;
            label6.Text = "ServiceID :";
            // 
            // txtReqID
            // 
            txtReqID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReqID.Location = new Point(160, 40);
            txtReqID.Name = "txtReqID";
            txtReqID.ReadOnly = true;
            txtReqID.Size = new Size(215, 26);
            txtReqID.TabIndex = 2;
            // 
            // txtReqDesc
            // 
            txtReqDesc.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReqDesc.Location = new Point(160, 120);
            txtReqDesc.Name = "txtReqDesc";
            txtReqDesc.PlaceholderText = "Input Description";
            txtReqDesc.Size = new Size(215, 26);
            txtReqDesc.TabIndex = 4;
            txtReqDesc.TextAlign = HorizontalAlignment.Center;
            // 
            // txtResName
            // 
            txtResName.AccessibleDescription = "";
            txtResName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(160, 240);
            txtResName.Name = "txtResName";
            txtResName.PlaceholderText = "Input ResidentID To Display Resident Name";
            txtResName.Size = new Size(215, 26);
            txtResName.TabIndex = 7;
            txtResName.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvReq
            // 
            dgvReq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReq.Location = new Point(550, 72);
            dgvReq.Name = "dgvReq";
            dgvReq.Size = new Size(482, 588);
            dgvReq.TabIndex = 14;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 366);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 10;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 366);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // dtpReqDate
            // 
            dtpReqDate.Location = new Point(160, 80);
            dtpReqDate.Name = "dtpReqDate";
            dtpReqDate.Size = new Size(215, 23);
            dtpReqDate.TabIndex = 3;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(160, 200);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(215, 23);
            cbbResID.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(25, 240);
            label7.Name = "label7";
            label7.Size = new Size(123, 21);
            label7.TabIndex = 43;
            label7.Text = "Resident Name :";
            // 
            // txtSerName
            // 
            txtSerName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSerName.Location = new Point(160, 320);
            txtSerName.Name = "txtSerName";
            txtSerName.ReadOnly = true;
            txtSerName.Size = new Size(215, 26);
            txtSerName.TabIndex = 9;
            txtSerName.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(25, 320);
            label8.Name = "label8";
            label8.Size = new Size(113, 21);
            label8.TabIndex = 45;
            label8.Text = "Service Name :";
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 366);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 11;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(620, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Status, Name, Service";
            txtSearch.Size = new Size(406, 26);
            txtSearch.TabIndex = 1;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(550, 40);
            label9.Name = "label9";
            label9.Size = new Size(64, 21);
            label9.TabIndex = 47;
            label9.Text = "Search :";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 366);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbSerStatus);
            panel1.Controls.Add(cbbSerID);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtSerName);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbbResID);
            panel1.Controls.Add(dtpReqDate);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(txtReqDesc);
            panel1.Controls.Add(txtReqID);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 50;
            // 
            // cbbSerStatus
            // 
            cbbSerStatus.FormattingEnabled = true;
            cbbSerStatus.Location = new Point(160, 160);
            cbbSerStatus.Name = "cbbSerStatus";
            cbbSerStatus.Size = new Size(215, 23);
            cbbSerStatus.TabIndex = 5;
            // 
            // cbbSerID
            // 
            cbbSerID.FormattingEnabled = true;
            cbbSerID.Location = new Point(160, 280);
            cbbSerID.Name = "cbbSerID";
            cbbSerID.Size = new Size(215, 23);
            cbbSerID.TabIndex = 8;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(550, 29);
            label10.TabIndex = 50;
            label10.Text = "Request Details";
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
            titleLabel.Size = new Size(984, 30);
            titleLabel.TabIndex = 51;
            titleLabel.Text = "Request Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(titleLabel);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Controls.Add(dgvReq);
            Controls.Add(label9);
            Name = "FormRequest";
            Text = "RequestForm";
            ((System.ComponentModel.ISupportInitialize)dgvReq).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox txtReqID;
        private TextBox txtReqDesc;
        private TextBox txtResName;
        private DataGridView dgvReq;
        private Button btnNew;
        private Button btnUpdate;
        private DateTimePicker dtpReqDate;
        private ComboBox cbbResID;
        private Label label7;
        private TextBox txtSerName;
        private Label label8;
        private Button btnInsert;
        private TextBox txtSearch;
        private Label label9;
        private Button btnDelete;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private ComboBox cbbSerID;
        private ComboBox cbbSerStatus;
    }
}