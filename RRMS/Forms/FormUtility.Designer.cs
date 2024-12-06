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
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Utility ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 80);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Utility Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 120);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Cost:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 160);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "Usage Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 200);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 4;
            label5.Text = "Room ID:";
            // 
            // txtUtiID
            // 
            txtUtiID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUtiID.Location = new Point(160, 40);
            txtUtiID.Margin = new Padding(3, 2, 3, 2);
            txtUtiID.Name = "txtUtiID";
            txtUtiID.ReadOnly = true;
            txtUtiID.Size = new Size(215, 26);
            txtUtiID.TabIndex = 2;
            // 
            // txtUtiCost
            // 
            txtUtiCost.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUtiCost.Location = new Point(160, 120);
            txtUtiCost.Margin = new Padding(3, 2, 3, 2);
            txtUtiCost.Name = "txtUtiCost";
            txtUtiCost.Size = new Size(215, 26);
            txtUtiCost.TabIndex = 4;
            // 
            // cbbUtiType
            // 
            cbbUtiType.Items.AddRange(new object[] { "Electricity", "Water", "Internet", "Other" });
            cbbUtiType.Location = new Point(160, 80);
            cbbUtiType.Margin = new Padding(3, 2, 3, 2);
            cbbUtiType.Name = "cbbUtiType";
            cbbUtiType.Size = new Size(215, 23);
            cbbUtiType.TabIndex = 3;
            // 
            // dtpUtiUD
            // 
            dtpUtiUD.Location = new Point(160, 160);
            dtpUtiUD.Margin = new Padding(3, 2, 3, 2);
            dtpUtiUD.Name = "dtpUtiUD";
            dtpUtiUD.Size = new Size(215, 23);
            dtpUtiUD.TabIndex = 5;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 295);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 295);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 295);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 11;
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
            panel1.Size = new Size(550, 630);
            panel1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 240);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 52;
            label7.Text = "Room Number:";
            // 
            // txtRoomNum
            // 
            txtRoomNum.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomNum.Location = new Point(160, 240);
            txtRoomNum.Margin = new Padding(3, 2, 3, 2);
            txtRoomNum.Name = "txtRoomNum";
            txtRoomNum.Size = new Size(215, 26);
            txtRoomNum.TabIndex = 7;
            // 
            // cbbRoomID
            // 
            cbbRoomID.Items.AddRange(new object[] { "Electricity", "Water", "Internet", "Other" });
            cbbRoomID.Location = new Point(160, 200);
            cbbRoomID.Margin = new Padding(3, 2, 3, 2);
            cbbRoomID.Name = "cbbRoomID";
            cbbRoomID.Size = new Size(215, 23);
            cbbRoomID.TabIndex = 6;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 295);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(550, 29);
            label10.TabIndex = 48;
            label10.Text = "Utility Details";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(984, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Utility Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(570, 40);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 50;
            label6.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(636, 35);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(396, 26);
            txtSearch.TabIndex = 1;
            // 
            // dgvUti
            // 
            dgvUti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUti.Location = new Point(565, 66);
            dgvUti.Name = "dgvUti";
            dgvUti.Size = new Size(467, 602);
            dgvUti.TabIndex = 12;
            // 
            // FormUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
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