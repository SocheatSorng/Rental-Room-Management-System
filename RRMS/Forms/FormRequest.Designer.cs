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
            requestid = new TextBox();
            description = new TextBox();
            residentid = new TextBox();
            serviceid = new TextBox();
            dgvReq = new DataGridView();
            btnClear = new Button();
            btnUpdate = new Button();
            requestdate = new DateTimePicker();
            status = new ComboBox();
            residentname = new TextBox();
            label7 = new Label();
            servicename = new TextBox();
            label8 = new Label();
            btnInsert = new Button();
            txtSearch = new TextBox();
            label9 = new Label();
            btnDelete = new Button();
            panel1 = new Panel();
            label10 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReq).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(14, 45);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 0;
            label1.Text = "RequestID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(14, 91);
            label2.Name = "label2";
            label2.Size = new Size(105, 21);
            label2.TabIndex = 1;
            label2.Text = "RequestDate :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(14, 130);
            label3.Name = "label3";
            label3.Size = new Size(96, 21);
            label3.TabIndex = 2;
            label3.Text = "Description :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(14, 262);
            label4.Name = "label4";
            label4.Size = new Size(92, 21);
            label4.TabIndex = 3;
            label4.Text = "ResidentID :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(14, 222);
            label5.Name = "label5";
            label5.Size = new Size(59, 21);
            label5.TabIndex = 4;
            label5.Text = "Status :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(14, 302);
            label6.Name = "label6";
            label6.Size = new Size(82, 21);
            label6.TabIndex = 5;
            label6.Text = "ServiceID :";
            // 
            // requestid
            // 
            requestid.Location = new Point(145, 47);
            requestid.Name = "requestid";
            requestid.ReadOnly = true;
            requestid.Size = new Size(276, 23);
            requestid.TabIndex = 6;
            // 
            // description
            // 
            description.Location = new Point(145, 132);
            description.Name = "description";
            description.PlaceholderText = "Input Description";
            description.Size = new Size(276, 23);
            description.TabIndex = 8;
            description.TextAlign = HorizontalAlignment.Center;
            // 
            // residentid
            // 
            residentid.AccessibleDescription = "";
            residentid.Location = new Point(145, 260);
            residentid.Name = "residentid";
            residentid.PlaceholderText = "Input ResidentID To Display Resident Name";
            residentid.Size = new Size(276, 23);
            residentid.TabIndex = 10;
            residentid.TextAlign = HorizontalAlignment.Center;
            // 
            // serviceid
            // 
            serviceid.Location = new Point(145, 300);
            serviceid.Name = "serviceid";
            serviceid.PlaceholderText = "Input ServiceID To Display Service Name";
            serviceid.Size = new Size(276, 23);
            serviceid.TabIndex = 11;
            serviceid.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvReq
            // 
            dgvReq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReq.Location = new Point(447, 80);
            dgvReq.Name = "dgvReq";
            dgvReq.Size = new Size(414, 430);
            dgvReq.TabIndex = 12;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(217, 83, 79);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(123, 433);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 26);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(212, 433);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // requestdate
            // 
            requestdate.Location = new Point(145, 91);
            requestdate.Name = "requestdate";
            requestdate.Size = new Size(276, 23);
            requestdate.TabIndex = 39;
            // 
            // status
            // 
            status.FormattingEnabled = true;
            status.Location = new Point(145, 220);
            status.Name = "status";
            status.Size = new Size(276, 23);
            status.TabIndex = 41;
            // 
            // residentname
            // 
            residentname.Location = new Point(145, 178);
            residentname.Name = "residentname";
            residentname.ReadOnly = true;
            residentname.Size = new Size(276, 23);
            residentname.TabIndex = 42;
            residentname.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(14, 176);
            label7.Name = "label7";
            label7.Size = new Size(123, 21);
            label7.TabIndex = 43;
            label7.Text = "Resident Name :";
            // 
            // servicename
            // 
            servicename.Location = new Point(145, 337);
            servicename.Name = "servicename";
            servicename.ReadOnly = true;
            servicename.Size = new Size(276, 23);
            servicename.TabIndex = 44;
            servicename.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(14, 339);
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
            btnInsert.Location = new Point(27, 433);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(517, 43);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Status, Name, Service";
            txtSearch.Size = new Size(344, 23);
            txtSearch.TabIndex = 48;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(447, 43);
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
            btnDelete.Location = new Point(301, 433);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(servicename);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(residentname);
            panel1.Controls.Add(status);
            panel1.Controls.Add(requestdate);
            panel1.Controls.Add(serviceid);
            panel1.Controls.Add(residentid);
            panel1.Controls.Add(description);
            panel1.Controls.Add(requestid);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(5, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(436, 475);
            panel1.TabIndex = 50;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(436, 29);
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
            titleLabel.Size = new Size(873, 30);
            titleLabel.TabIndex = 51;
            titleLabel.Text = "Request Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 521);
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
        private TextBox requestid;
        private TextBox description;
        private TextBox residentid;
        private TextBox serviceid;
        private DataGridView dgvReq;
        private Button btnClear;
        private Button btnUpdate;
        private DateTimePicker requestdate;
        private ComboBox status;
        private TextBox residentname;
        private Label label7;
        private TextBox servicename;
        private Label label8;
        private Button btnInsert;
        private TextBox txtSearch;
        private Label label9;
        private Button btnDelete;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
    }
}