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
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 28);
            label1.Name = "label1";
            label1.Size = new Size(89, 19);
            label1.TabIndex = 0;
            label1.Text = "FeedbackID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 72);
            label2.Name = "label2";
            label2.Size = new Size(77, 19);
            label2.TabIndex = 1;
            label2.Text = "Comments:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 119);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 2;
            label3.Text = "Rating:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 164);
            label4.Name = "label4";
            label4.Size = new Size(106, 19);
            label4.TabIndex = 3;
            label4.Text = "Feedback Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(10, 202);
            label5.Name = "label5";
            label5.Size = new Size(84, 19);
            label5.TabIndex = 4;
            label5.Text = "Resident ID:";
            // 
            // dgvFeed
            // 
            dgvFeed.Location = new Point(350, 75);
            dgvFeed.Margin = new Padding(3, 2, 3, 2);
            dgvFeed.Name = "dgvFeed";
            dgvFeed.Size = new Size(340, 229);
            dgvFeed.TabIndex = 7;
            dgvFeed.UseCompatibleStateImageBehavior = false;
            // 
            // txtFeedID
            // 
            txtFeedID.Location = new Point(130, 27);
            txtFeedID.Margin = new Padding(3, 2, 3, 2);
            txtFeedID.Name = "txtFeedID";
            txtFeedID.Size = new Size(161, 23);
            txtFeedID.TabIndex = 8;
            // 
            // txtFeedCom
            // 
            txtFeedCom.Location = new Point(130, 70);
            txtFeedCom.Margin = new Padding(3, 2, 3, 2);
            txtFeedCom.Multiline = true;
            txtFeedCom.Name = "txtFeedCom";
            txtFeedCom.Size = new Size(161, 21);
            txtFeedCom.TabIndex = 9;
            // 
            // txtResID
            // 
            txtResID.Location = new Point(130, 200);
            txtResID.Margin = new Padding(3, 2, 3, 2);
            txtResID.Name = "txtResID";
            txtResID.Size = new Size(161, 23);
            txtResID.TabIndex = 12;
            // 
            // numRating
            // 
            numRating.Location = new Point(130, 118);
            numRating.Margin = new Padding(3, 2, 3, 2);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(160, 23);
            numRating.TabIndex = 10;
            numRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateFeedback
            // 
            dateFeedback.Location = new Point(130, 160);
            dateFeedback.Margin = new Padding(3, 2, 3, 2);
            dateFeedback.Name = "dateFeedback";
            dateFeedback.Size = new Size(219, 23);
            dateFeedback.TabIndex = 11;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(438, 30);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(82, 22);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(526, 30);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 22);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(614, 28);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtResName
            // 
            txtResName.Location = new Point(130, 240);
            txtResName.Margin = new Padding(3, 2, 3, 2);
            txtResName.Name = "txtResName";
            txtResName.Size = new Size(161, 23);
            txtResName.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 242);
            label6.Name = "label6";
            label6.Size = new Size(105, 19);
            label6.TabIndex = 6;
            label6.Text = "Resident Name:";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(350, 30);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(82, 22);
            btnNew.TabIndex = 17;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(702, 30);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(82, 22);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // FormFeedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 338);
            Controls.Add(btnClose);
            Controls.Add(btnNew);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtResID);
            Controls.Add(dateFeedback);
            Controls.Add(numRating);
            Controls.Add(txtFeedCom);
            Controls.Add(txtFeedID);
            Controls.Add(dgvFeed);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResName);
            Controls.Add(label6);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormFeedback";
            Text = "Feedback Management";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
} 