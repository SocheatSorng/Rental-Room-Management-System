namespace RRMS
{
    partial class Utility
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
            txtCost = new TextBox();
            cboUtilityType = new ComboBox();
            txtRoomID = new TextBox();
            dateUsage = new DateTimePicker();
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
            label1.Text = "Utility ID:";
            
            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 96);
            label2.Name = "label2";
            label2.Size = new Size(110, 22);
            label2.TabIndex = 1;
            label2.Text = "Utility Type:";
            
            // label3
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(52, 22);
            label3.TabIndex = 2;
            label3.Text = "Cost:";
            
            // label4
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 218);
            label4.Name = "label4";
            label4.Size = new Size(108, 22);
            label4.TabIndex = 3;
            label4.Text = "Usage Date:";
            
            // label5
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 269);
            label5.Name = "label5";
            label5.Size = new Size(89, 22);
            label5.TabIndex = 4;
            label5.Text = "Room ID:";
            
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
            
            // cboUtilityType
            cboUtilityType.Location = new Point(149, 94);
            cboUtilityType.Name = "cboUtilityType";
            cboUtilityType.Size = new Size(183, 27);
            cboUtilityType.TabIndex = 9;
            cboUtilityType.Items.AddRange(new string[] { "Electricity", "Water", "Internet", "Other" });
            
            // txtCost
            txtCost.Location = new Point(149, 157);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(183, 27);
            txtCost.TabIndex = 10;
            
            // dateUsage
            dateUsage.Location = new Point(149, 214);
            dateUsage.Name = "dateUsage";
            dateUsage.Size = new Size(250, 27);
            dateUsage.TabIndex = 11;
            
            // txtRoomID
            txtRoomID.Location = new Point(149, 267);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(183, 27);
            txtRoomID.TabIndex = 12;
            
            // btnInsert
            btnInsert.Location = new Point(400, 40);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(94, 29);
            btnInsert.TabIndex = 13;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            
            // btnUpdate
            btnUpdate.Location = new Point(553, 40);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            
            // btnDelete
            btnDelete.Location = new Point(694, 40);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            
            // Utility Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtRoomID);
            Controls.Add(dateUsage);
            Controls.Add(txtCost);
            Controls.Add(cboUtilityType);
            Controls.Add(txtID);
            Controls.Add(listView1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Utility";
            Text = "Utility Management";
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
        private ComboBox cboUtilityType;
        private TextBox txtCost;
        private DateTimePicker dateUsage;
        private TextBox txtRoomID;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
    }
} 