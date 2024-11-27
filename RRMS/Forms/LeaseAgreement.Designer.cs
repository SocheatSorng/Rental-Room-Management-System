namespace RRMS
{
    partial class LeaseAgreement
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
            label6 = new Label();
            label7 = new Label();
            listView1 = new ListView();
            txtID = new TextBox();
            txtMonthlyRent = new TextBox();
            txtTerms = new TextBox();
            txtResidentID = new TextBox();
            txtResidentName = new TextBox();
            dateStart = new DateTimePicker();
            dateEnd = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();
            
            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(92, 22);
            label1.TabIndex = 0;
            label1.Text = "Lease ID:";
            
            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 1;
            label2.Text = "Start Date:";
            
            // label3
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(89, 22);
            label3.TabIndex = 2;
            label3.Text = "End Date:";
            
            // label4
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(121, 22);
            label4.TabIndex = 3;
            label4.Text = "Monthly Rent:";
            
            // label5
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(110, 22);
            label5.TabIndex = 4;
            label5.Text = "Terms:";
            
            // label6
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 320);
            label6.Name = "label6";
            label6.Size = new Size(110, 22);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";
            
            // label7
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 373);
            label7.Name = "label7";
            label7.Size = new Size(136, 22);
            label7.TabIndex = 7;
            label7.Text = "Resident Name:";
            
            // listView1
            listView1.Location = new Point(400, 100);
            listView1.Name = "listView1";
            listView1.Size = new Size(388, 304);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            
            // txtID
            txtID.Location = new Point(149, 36);
            txtID.Name = "txtID";
            txtID.Size = new Size(183, 27);
            txtID.TabIndex = 8;
            
            // dateStart
            dateStart.Location = new Point(149, 94);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(250, 27);
            dateStart.TabIndex = 9;
            
            // dateEnd
            dateEnd.Location = new Point(149, 157);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(250, 27);
            dateEnd.TabIndex = 10;
            
            // txtMonthlyRent
            txtMonthlyRent.Location = new Point(149, 216);
            txtMonthlyRent.Name = "txtMonthlyRent";
            txtMonthlyRent.Size = new Size(183, 27);
            txtMonthlyRent.TabIndex = 11;
            
            // txtTerms
            txtTerms.Location = new Point(149, 267);
            txtTerms.Multiline = true;
            txtTerms.Name = "txtTerms";
            txtTerms.Size = new Size(183, 27);
            txtTerms.TabIndex = 12;
            
            // txtResidentID
            txtResidentID.Location = new Point(149, 318);
            txtResidentID.Name = "txtResidentID";
            txtResidentID.Size = new Size(183, 27);
            txtResidentID.TabIndex = 13;
            
            // txtResidentName
            txtResidentName.Location = new Point(149, 371);
            txtResidentName.Name = "txtResidentName";
            txtResidentName.Size = new Size(183, 27);
            txtResidentName.TabIndex = 14;
            
            // btnInsert
            btnInsert.Location = new Point(400, 40);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            
            // btnUpdate
            btnUpdate.Location = new Point(553, 40);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            
            // btnDelete
            btnDelete.Location = new Point(694, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            
            // LeaseAgreement Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtResidentID);
            Controls.Add(txtTerms);
            Controls.Add(txtMonthlyRent);
            Controls.Add(dateEnd);
            Controls.Add(dateStart);
            Controls.Add(txtID);
            Controls.Add(listView1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResidentName);
            Controls.Add(label7);
            Name = "LeaseAgreement";
            Text = "Lease Agreement Management";
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
        private Label label7;
        private ListView listView1;
        private TextBox txtID;
        private DateTimePicker dateStart;
        private DateTimePicker dateEnd;
        private TextBox txtMonthlyRent;
        private TextBox txtTerms;
        private TextBox txtResidentID;
        private TextBox txtResidentName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
    }
} 