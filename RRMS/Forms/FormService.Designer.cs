namespace RRMS.Forms
{
    partial class FormService
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
            servicedescription = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label = new Label();
            label4 = new Label();
            servicename = new TextBox();
            serviceid = new TextBox();
            servicecost = new TextBox();
            btnInsert = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            servicegrid = new DataGridView();
            label1 = new Label();
            searchbox = new TextBox();
            btnDelete = new Button();
            panel1 = new Panel();
            label5 = new Label();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)servicegrid).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // servicedescription
            // 
            servicedescription.Font = new Font("Segoe UI", 12F);
            servicedescription.Location = new Point(171, 141);
            servicedescription.Multiline = true;
            servicedescription.Name = "servicedescription";
            servicedescription.Size = new Size(270, 69);
            servicedescription.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(18, 42);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 1;
            label3.Text = "ServiceID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 90);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 2;
            label2.Text = "Service Name:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F);
            label.Location = new Point(18, 163);
            label.Name = "label";
            label.Size = new Size(146, 21);
            label.TabIndex = 3;
            label.Text = "Service Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(18, 231);
            label4.Name = "label4";
            label4.Size = new Size(48, 21);
            label4.TabIndex = 4;
            label4.Text = "Cost: ";
            // 
            // servicename
            // 
            servicename.Font = new Font("Segoe UI", 12F);
            servicename.Location = new Point(171, 90);
            servicename.Name = "servicename";
            servicename.Size = new Size(270, 29);
            servicename.TabIndex = 5;
            // 
            // serviceid
            // 
            serviceid.Font = new Font("Segoe UI", 12F);
            serviceid.Location = new Point(171, 39);
            serviceid.Name = "serviceid";
            serviceid.ReadOnly = true;
            serviceid.Size = new Size(270, 29);
            serviceid.TabIndex = 6;
            // 
            // servicecost
            // 
            servicecost.Font = new Font("Segoe UI", 12F);
            servicecost.Location = new Point(171, 223);
            servicecost.Name = "servicecost";
            servicecost.PlaceholderText = "Enter Cost Of The Service";
            servicecost.Size = new Size(270, 29);
            servicecost.TabIndex = 7;
            servicecost.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(54, 312);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(83, 26);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(217, 83, 79);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(232, 312);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 26);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(143, 312);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 26);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // servicegrid
            // 
            servicegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            servicegrid.Location = new Point(470, 37);
            servicegrid.Name = "servicegrid";
            servicegrid.Size = new Size(381, 348);
            servicegrid.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(18, 270);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 52;
            label1.Text = "Search :";
            // 
            // searchbox
            // 
            searchbox.Font = new Font("Segoe UI", 12F);
            searchbox.Location = new Point(170, 262);
            searchbox.Name = "searchbox";
            searchbox.PlaceholderText = "Seach by Name, Description";
            searchbox.Size = new Size(271, 29);
            searchbox.TabIndex = 53;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(321, 312);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 26);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(searchbox);
            panel1.Controls.Add(servicedescription);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnInsert);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(servicecost);
            panel1.Controls.Add(serviceid);
            panel1.Controls.Add(servicename);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(12, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 348);
            panel1.TabIndex = 55;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(51, 122, 183);
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(452, 30);
            label5.TabIndex = 55;
            label5.Text = "Service Details";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(863, 30);
            titleLabel.TabIndex = 56;
            titleLabel.Text = "Sevice Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 397);
            Controls.Add(titleLabel);
            Controls.Add(panel1);
            Controls.Add(servicegrid);
            Name = "ServiceForm";
            Text = "ServiceForm";
            ((System.ComponentModel.ISupportInitialize)servicegrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox servicedescription;
        private Label label3;
        private Label label2;
        private Label label;
        private Label label4;
        private TextBox servicename;
        private TextBox serviceid;
        private TextBox servicecost;
        private Button btnInsert;
        private Button btnClear;
        private Button btnUpdate;
        private DataGridView servicegrid;
        private Label label1;
        private TextBox searchbox;
        private Button btnDelete;
        private Panel panel1;
        private Label label5;
        private Label titleLabel;
    }
}