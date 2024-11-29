namespace RRMS.Forms
{
    partial class User
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
            UserName = new TextBox();
            UserPass = new TextBox();
            UserPos = new TextBox();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 78);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Position";
            // 
            // UserName
            // 
            UserName.Location = new Point(104, 6);
            UserName.Name = "UserName";
            UserName.Size = new Size(100, 23);
            UserName.TabIndex = 3;
            // 
            // UserPass
            // 
            UserPass.Location = new Point(104, 39);
            UserPass.Name = "UserPass";
            UserPass.Size = new Size(100, 23);
            UserPass.TabIndex = 4;
            // 
            // UserPos
            // 
            UserPos.Location = new Point(104, 75);
            UserPos.Name = "UserPos";
            UserPos.Size = new Size(100, 23);
            UserPos.TabIndex = 5;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Top;
            btnNew.Location = new Point(0, 150);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(176, 50);
            btnNew.TabIndex = 6;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Dock = DockStyle.Top;
            btnInsert.Location = new Point(0, 100);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(176, 50);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Top;
            btnUpdate.Location = new Point(0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(176, 50);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Top;
            btnDelete.Location = new Point(0, 50);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(176, 50);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNew);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Location = new Point(425, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(176, 457);
            panel1.TabIndex = 11;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(UserPos);
            Controls.Add(UserPass);
            Controls.Add(UserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "User";
            Text = "User";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox UserName;
        private TextBox UserPass;
        private TextBox UserPos;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Panel panel1;
    }
}