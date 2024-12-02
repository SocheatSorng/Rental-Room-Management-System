namespace RRMS.Forms
{
    partial class FormUtility
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
            txtUtiID = new TextBox();
            txtUtiCost = new TextBox();
            cbbUtiType = new ComboBox();
            dtpUtiUD = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            label7 = new Label();
            txtRoomNum = new TextBox();
            cbbRoomID = new ComboBox();
            btnNew = new Button();
            label10 = new Label();
            titleLabel = new Label();
            label6 = new Label();
            txtSearch = new TextBox();
            dgvUti = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUti).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 42);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 0;
            label1.Text = "Utility ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 84);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 1;
            label2.Text = "Utility Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 120);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 2;
            label3.Text = "Cost:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 156);
            label4.Name = "label4";
            label4.Size = new Size(83, 19);
            label4.TabIndex = 3;
            label4.Text = "Usage Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 183);
            label5.Name = "label5";
            label5.Size = new Size(69, 19);
            label5.TabIndex = 4;
            label5.Text = "Room ID:";
            // 
            // txtUtiID
            // 
            txtUtiID.Location = new Point(122, 42);
            txtUtiID.Margin = new Padding(3, 2, 3, 2);
            txtUtiID.Name = "txtUtiID";
            txtUtiID.ReadOnly = true;
            txtUtiID.Size = new Size(219, 23);
            txtUtiID.TabIndex = 8;
            // 
            // txtUtiCost
            // 
            txtUtiCost.Location = new Point(122, 116);
            txtUtiCost.Margin = new Padding(3, 2, 3, 2);
            txtUtiCost.Name = "txtUtiCost";
            txtUtiCost.Size = new Size(219, 23);
            txtUtiCost.TabIndex = 10;
            // 
            // cbbUtiType
            // 
            cbbUtiType.Items.AddRange(new object[] { "Electricity", "Water", "Internet", "Other" });
            cbbUtiType.Location = new Point(122, 84);
            cbbUtiType.Margin = new Padding(3, 2, 3, 2);
            cbbUtiType.Name = "cbbUtiType";
            cbbUtiType.Size = new Size(219, 23);
            cbbUtiType.TabIndex = 9;
            // 
            // dtpUtiUD
            // 
            dtpUtiUD.Location = new Point(122, 152);
            dtpUtiUD.Margin = new Padding(3, 2, 3, 2);
            dtpUtiUD.Name = "dtpUtiUD";
            dtpUtiUD.Size = new Size(219, 23);
            dtpUtiUD.TabIndex = 11;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(103, 253);
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
            btnUpdate.Location = new Point(192, 253);
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
            btnDelete.Location = new Point(281, 253);
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
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtRoomNum);
            panel1.Controls.Add(cbbRoomID);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(dtpUtiUD);
            panel1.Controls.Add(txtUtiCost);
            panel1.Controls.Add(cbbUtiType);
            panel1.Controls.Add(txtUtiID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 692);
            panel1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 218);
            label7.Name = "label7";
            label7.Size = new Size(103, 19);
            label7.TabIndex = 52;
            label7.Text = "Room Number:";
            // 
            // txtRoomNum
            // 
            txtRoomNum.Location = new Point(122, 214);
            txtRoomNum.Margin = new Padding(3, 2, 3, 2);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.Size = new Size(219, 23);
            txtRoomNum.TabIndex = 51;
            // 
            // cbbRoomID
            // 
            cbbRoomID.Items.AddRange(new object[] { "Electricity", "Water", "Internet", "Other" });
            cbbRoomID.Location = new Point(122, 183);
            cbbRoomID.Margin = new Padding(3, 2, 3, 2);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(219, 23);
            cbbRoomID.TabIndex = 50;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(14, 253);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 49;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(373, 29);
            label10.TabIndex = 48;
            label10.Text = "Utility Details";
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
            titleLabel.Text = "Utility Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(391, 38);
            label6.Name = "label6";
            label6.Size = new Size(67, 19);
            label6.TabIndex = 50;
            label6.Text = "Utility ID:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(464, 38);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(568, 23);
            txtSearch.TabIndex = 50;
            // 
            // dgvUti
            // 
            dgvUti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUti.Location = new Point(391, 66);
            dgvUti.Name = "dgvUti";
            dgvUti.Size = new Size(641, 664);
            dgvUti.TabIndex = 51;
            // 
            // FormUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 742);
            Controls.Add(dgvUti);
            Controls.Add(txtSearch);
            Controls.Add(label6);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormUtility";
            Text = "Utility Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListView listView1;
        private TextBox txtUtiID;
        private ComboBox cbbUtiType;
        private TextBox txtUtiCost;
        private DateTimePicker dtpUtiUD;
        private TextBox txtRoomID;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private Button btnNew;
        private Label label6;
        private TextBox txtSearch;
        private ComboBox cbbRoomID;
        private DataGridView dgvUti;
        private Label label7;
        private TextBox txtRoomNum;
    }
} 