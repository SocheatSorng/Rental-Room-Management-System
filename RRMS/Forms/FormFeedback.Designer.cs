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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvFeed = new ListView();
            txtFeedID = new TextBox();
            txtFeedCom = new TextBox();
            txtResID = new TextBox();
            numRating = new NumericUpDown();
            dateFeedback = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtResName = new TextBox();
            label6 = new Label();
            btnNew = new Button();
            btnClose = new Button();
            panel1 = new Panel();
            label10 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 48);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 0;
            label1.Text = "FeedbackID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 86);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 1;
            label2.Text = "Comments:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 125);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 2;
            label3.Text = "Rating:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(19, 167);
            label4.Name = "label4";
            label4.Size = new Size(106, 19);
            label4.TabIndex = 3;
            label4.Text = "Feedback Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 208);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 4;
            label5.Text = "Resident ID:";
            // 
            // dgvFeed
            // 
            dgvFeed.Location = new Point(411, 46);
            dgvFeed.Margin = new Padding(3, 2, 3, 2);
            dgvFeed.Name = "dgvFeed";
            dgvFeed.Size = new Size(346, 355);
            dgvFeed.TabIndex = 7;
            dgvFeed.UseCompatibleStateImageBehavior = false;
            // 
            // txtFeedID
            // 
            txtFeedID.Location = new Point(131, 48);
            txtFeedID.Margin = new Padding(3, 2, 3, 2);
            txtFeedID.Name = "txtFeedID";
            txtFeedID.Size = new Size(248, 23);
            txtFeedID.TabIndex = 8;
            // 
            // txtFeedCom
            // 
            txtFeedCom.Location = new Point(131, 86);
            txtFeedCom.Margin = new Padding(3, 2, 3, 2);
            txtFeedCom.Multiline = true;
            txtFeedCom.Name = "txtFeedCom";
            txtFeedCom.Size = new Size(248, 21);
            txtFeedCom.TabIndex = 9;
            // 
            // txtResID
            // 
            txtResID.Location = new Point(131, 208);
            txtResID.Margin = new Padding(3, 2, 3, 2);
            txtResID.Name = "txtResID";
            txtResID.Size = new Size(248, 23);
            txtResID.TabIndex = 12;
            // 
            // numRating
            // 
            numRating.Location = new Point(131, 126);
            numRating.Margin = new Padding(3, 2, 3, 2);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(248, 23);
            numRating.TabIndex = 10;
            numRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateFeedback
            // 
            dateFeedback.Location = new Point(131, 167);
            dateFeedback.Margin = new Padding(3, 2, 3, 2);
            dateFeedback.Name = "dateFeedback";
            dateFeedback.Size = new Size(248, 23);
            dateFeedback.TabIndex = 11;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(110, 302);
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
            btnUpdate.Location = new Point(199, 302);
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
            btnDelete.Location = new Point(288, 302);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtResName
            // 
            txtResName.Location = new Point(131, 244);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(248, 23);
            txtResName.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 248);
            label6.Name = "label6";
            label6.Size = new Size(105, 19);
            label6.TabIndex = 6;
            label6.Text = "Resident Name:";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 83, 79);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(22, 302);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(83, 26);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(399, 340);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 22);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtResID);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(numRating);
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(txtFeedCom);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(txtFeedID);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(txtResName);
            panel1.Controls.Add(dateFeedback);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(393, 355);
            panel1.TabIndex = 19;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(51, 122, 183);
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(393, 29);
            label10.TabIndex = 48;
            label10.Text = "Feedback Details";
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
            titleLabel.Size = new Size(769, 30);
            titleLabel.TabIndex = 43;
            titleLabel.Text = "Feedback ";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 426);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(dgvFeed);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormFeedback";
            Text = "Feedback Management";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListView dgvFeed;
        private TextBox txtFeedID;
        private TextBox txtFeedCom;
        private NumericUpDown numRating;
        private DateTimePicker dateFeedback;
        private TextBox txtResID;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label6;
        private TextBox txtResName;
        private Button btnNew;
        private Button btnClose;
        private Panel panel1;
        private Label titleLabel;
        private Label label10;
    }
} 