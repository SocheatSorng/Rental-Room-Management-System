namespace RRMS.Forms
{
    partial class FormFeedback
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
            label4 = new Label();
            label5 = new Label();
            txtFeedID = new TextBox();
            txtFeedCom = new TextBox();
            dtpFeedDate = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtResName = new TextBox();
            label6 = new Label();
            btnNew = new Button();
            panel1 = new Panel();
            cbbResID = new ComboBox();
            txtFeedCon = new TextBox();
            label7 = new Label();
            label10 = new Label();
            titleLabel = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            dgvFeed = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeed).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Feedback ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 120);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 1;
            label2.Text = "Comments:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 160);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 3;
            label4.Text = "Feedback Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 200);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 4;
            label5.Text = "Resident ID:";
            // 
            // txtFeedID
            // 
            txtFeedID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFeedID.Location = new Point(160, 40);
            txtFeedID.Margin = new Padding(3, 2, 3, 2);
            txtFeedID.Name = "txtFeedID";
            txtFeedID.ReadOnly = true;
            txtFeedID.Size = new Size(215, 26);
            txtFeedID.TabIndex = 2;
            // 
            // txtFeedCom
            // 
            txtFeedCom.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFeedCom.Location = new Point(160, 120);
            txtFeedCom.Margin = new Padding(3, 2, 3, 2);
            txtFeedCom.Multiline = true;
            txtFeedCom.Name = "txtFeedCom";
            txtFeedCom.Size = new Size(215, 21);
            txtFeedCom.TabIndex = 4;
            // 
            // dtpFeedDate
            // 
            dtpFeedDate.Location = new Point(160, 160);
            dtpFeedDate.Margin = new Padding(3, 2, 3, 2);
            dtpFeedDate.Name = "dtpFeedDate";
            dtpFeedDate.Size = new Size(215, 23);
            dtpFeedDate.TabIndex = 5;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(114, 302);
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
            btnUpdate.Location = new Point(203, 302);
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
            btnDelete.Location = new Point(292, 302);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtResName
            // 
            txtResName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResName.Location = new Point(160, 240);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.ReadOnly = true;
            txtResName.Size = new Size(215, 26);
            txtResName.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 240);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 6;
            label6.Text = "Resident Name:";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(25, 302);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 8;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbbResID);
            panel1.Controls.Add(txtFeedCon);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtFeedCom);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtFeedID);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(dtpFeedDate);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 709);
            panel1.TabIndex = 19;
            // 
            // cbbResID
            // 
            cbbResID.FormattingEnabled = true;
            cbbResID.Location = new Point(160, 200);
            cbbResID.Name = "cbbResID";
            cbbResID.Size = new Size(215, 23);
            cbbResID.TabIndex = 6;
            // 
            // txtFeedCon
            // 
            txtFeedCon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFeedCon.Location = new Point(160, 80);
            txtFeedCon.Margin = new Padding(3, 2, 3, 2);
            txtFeedCon.Name = "txtFeedCon";
            txtFeedCon.Size = new Size(215, 26);
            txtFeedCon.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 80);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 49;
            label7.Text = "Content: ";
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
            label10.Text = "Feedback Details";
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
            titleLabel.Text = "Feedback  Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(550, 40);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 49;
            label3.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(616, 40);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(368, 26);
            txtSearch.TabIndex = 1;
            // 
            // dgvFeed
            // 
            dgvFeed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeed.Location = new Point(550, 73);
            dgvFeed.Name = "dgvFeed";
            dgvFeed.Size = new Size(434, 662);
            dgvFeed.TabIndex = 12;
            // 
            // FormFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(dgvFeed);
            Controls.Add(txtSearch);
            Controls.Add(label3);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormFeedback";
            Text = "Feedback Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox txtFeedID;
        private TextBox txtFeedCom;
        private DateTimePicker dtpFeedDate;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label6;
        private TextBox txtResName;
        private Button btnNew;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
        private Label label3;
        private TextBox txtSearch;
        private DataGridView dgvFeed;
        private Label label7;
        private TextBox txtFeedCon;
        private ComboBox cbbResID;
    }
} 