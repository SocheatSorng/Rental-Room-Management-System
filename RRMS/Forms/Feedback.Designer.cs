namespace RRMS
{
    partial class Feedback
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
            listView1 = new ListView();
            txtID = new TextBox();
            txtComments = new TextBox();
            txtResidentID = new TextBox();
            numRating = new NumericUpDown();
            dateFeedback = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtResidentName = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(112, 22);
            label1.TabIndex = 0;
            label1.Text = "FeedbackID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 1;
            label2.Text = "Comments:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(67, 22);
            label3.TabIndex = 2;
            label3.Text = "Rating:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(134, 22);
            label4.TabIndex = 3;
            label4.Text = "Feedback Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(110, 22);
            label5.TabIndex = 4;
            label5.Text = "Resident ID:";
            // 
            // listView1
            // 
            listView1.Location = new Point(400, 100);
            listView1.Name = "listView1";
            listView1.Size = new Size(388, 304);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // txtID
            // 
            txtID.Location = new Point(149, 36);
            txtID.Name = "txtID";
            txtID.Size = new Size(183, 27);
            txtID.TabIndex = 8;
            // 
            // txtComments
            // 
            txtComments.Location = new Point(149, 94);
            txtComments.Multiline = true;
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(183, 27);
            txtComments.TabIndex = 9;
            // 
            // txtResidentID
            // 
            txtResidentID.Location = new Point(149, 267);
            txtResidentID.Name = "txtResidentID";
            txtResidentID.Size = new Size(183, 27);
            txtResidentID.TabIndex = 12;
            // 
            // numRating
            // 
            numRating.Location = new Point(149, 157);
            numRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(183, 27);
            numRating.TabIndex = 10;
            numRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateFeedback
            // 
            dateFeedback.Location = new Point(149, 214);
            dateFeedback.Name = "dateFeedback";
            dateFeedback.Size = new Size(250, 27);
            dateFeedback.TabIndex = 11;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(400, 40);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(553, 40);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(694, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // txtResidentName
            // 
            txtResidentName.Location = new Point(149, 320);
            txtResidentName.Name = "txtResidentName";
            txtResidentName.Size = new Size(183, 27);
            txtResidentName.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 322);
            label6.Name = "label6";
            label6.Size = new Size(136, 22);
            label6.TabIndex = 6;
            label6.Text = "Resident Name:";
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtResidentID);
            Controls.Add(dateFeedback);
            Controls.Add(numRating);
            Controls.Add(txtComments);
            Controls.Add(txtID);
            Controls.Add(listView1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResidentName);
            Controls.Add(label6);
            Name = "Feedback";
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
        private ListView listView1;
        private TextBox txtID;
        private TextBox txtComments;
        private NumericUpDown numRating;
        private DateTimePicker dateFeedback;
        private TextBox txtResidentID;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label6;
        private TextBox txtResidentName;
    }
} 