namespace RRMS
{
    partial class Policy
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
            txtName = new TextBox();
            txtDesc = new TextBox();
            txtResidentID = new TextBox();
            txtResidentName = new TextBox();
            dateCreate = new DateTimePicker();
            dateUpdate = new DateTimePicker();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(92, 22);
            label1.TabIndex = 0;
            label1.Text = "Policy ID:";

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(118, 22);
            label2.TabIndex = 1;
            label2.Text = "Policy Name:";

            // label3
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(103, 22);
            label3.TabIndex = 2;
            label3.Text = "Description:";

            // label4
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(110, 22);
            label4.TabIndex = 3;
            label4.Text = "Create Date:";

            // label5
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(114, 22);
            label5.TabIndex = 4;
            label5.Text = "Update Date:";

            // label6
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(12, 320);
            label6.Name = "label6";
            label6.Size = new Size(110, 22);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";

            // label7
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F);
            label7.Location = new Point(12, 373);
            label7.Name = "label7";
            label7.Size = new Size(136, 22);
            label7.TabIndex = 6;
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

            // txtName
            txtName.Location = new Point(149, 94);
            txtName.Name = "txtName";
            txtName.Size = new Size(183, 27);
            txtName.TabIndex = 9;

            // txtDesc
            txtDesc.Location = new Point(149, 157);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(183, 27);
            txtDesc.TabIndex = 10;

            // dateCreate
            dateCreate.Location = new Point(149, 214);
            dateCreate.Name = "dateCreate";
            dateCreate.Size = new Size(250, 27);
            dateCreate.TabIndex = 11;

            // dateUpdate
            dateUpdate.Location = new Point(149, 267);
            dateUpdate.Name = "dateUpdate";
            dateUpdate.Size = new Size(250, 27);
            dateUpdate.TabIndex = 12;

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
            btnInsert.TabIndex = 15;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;

            // btnUpdate
            btnUpdate.Location = new Point(553, 40);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;

            // btnDelete
            btnDelete.Location = new Point(694, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;

            // Policy Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.AddRange(new Control[] {
                btnDelete, btnUpdate, btnInsert,
                txtResidentName, txtResidentID, dateUpdate, dateCreate,
                txtDesc, txtName, txtID, listView1,
                label7, label6, label5, label4, label3, label2, label1
            });
            Name = "Policy";
            Text = "Policy Management";
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
        private TextBox txtName;
        private TextBox txtDesc;
        private DateTimePicker dateCreate;
        private DateTimePicker dateUpdate;
        private TextBox txtResidentID;
        private TextBox txtResidentName;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
