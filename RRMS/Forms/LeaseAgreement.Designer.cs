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
            titleLabel = new Label();
            inputGroup = new GroupBox();
            buttonPanel = new Panel();
            inputGroup.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();

            // Title Label
            titleLabel.BackColor = Color.FromArgb(51, 122, 183);
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(10, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(780, 40);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Lease Agreement Management";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Labels
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 40);
            label1.Name = "label1";
            label1.Size = new Size(80, 23);
            label1.TabIndex = 0;
            label1.Text = "Lease ID:";

            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 1;
            label2.Text = "Start Date:";

            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(79, 23);
            label3.TabIndex = 2;
            label3.Text = "End Date:";

            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(20, 160);
            label4.Name = "label4";
            label4.Size = new Size(110, 23);
            label4.TabIndex = 3;
            label4.Text = "Monthly Rent:";

            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(20, 200);
            label5.Name = "label5";
            label5.Size = new Size(57, 23);
            label5.TabIndex = 4;
            label5.Text = "Terms:";

            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(20, 280);
            label6.Name = "label6";
            label6.Size = new Size(96, 23);
            label6.TabIndex = 5;
            label6.Text = "Resident ID:";

            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(20, 320);
            label7.Name = "label7";
            label7.Size = new Size(120, 23);
            label7.TabIndex = 6;
            label7.Text = "Resident Name:";

            // Input Controls
            txtID.BackColor = Color.FromArgb(240, 240, 240);
            txtID.Location = new Point(140, 38);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(180, 30);
            txtID.TabIndex = 7;

            dateStart.Format = DateTimePickerFormat.Short;
            dateStart.Location = new Point(140, 78);
            dateStart.Name = "dateStart";
            dateStart.Size = new Size(180, 30);
            dateStart.TabIndex = 8;

            dateEnd.Format = DateTimePickerFormat.Short;
            dateEnd.Location = new Point(140, 118);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(180, 30);
            dateEnd.TabIndex = 9;

            txtMonthlyRent.Location = new Point(140, 158);
            txtMonthlyRent.Name = "txtMonthlyRent";
            txtMonthlyRent.Size = new Size(180, 30);
            txtMonthlyRent.TabIndex = 10;

            txtTerms.Location = new Point(140, 198);
            txtTerms.Multiline = true;
            txtTerms.Name = "txtTerms";
            txtTerms.Size = new Size(180, 70);
            txtTerms.TabIndex = 11;

            txtResidentID.Location = new Point(140, 278);
            txtResidentID.Name = "txtResidentID";
            txtResidentID.Size = new Size(180, 30);
            txtResidentID.TabIndex = 12;

            txtResidentName.BackColor = Color.FromArgb(240, 240, 240);
            txtResidentName.Location = new Point(140, 318);
            txtResidentName.Name = "txtResidentName";
            txtResidentName.ReadOnly = true;
            txtResidentName.Size = new Size(180, 30);
            txtResidentName.TabIndex = 13;

            // Buttons
            btnInsert.BackColor = Color.FromArgb(92, 184, 92);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(0, 0);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(95, 35);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;

            btnUpdate.BackColor = Color.FromArgb(240, 173, 78);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(105, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 35);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;

            btnDelete.BackColor = Color.FromArgb(217, 83, 79);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(210, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(95, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;

            // Button Panel
            buttonPanel.Controls.Add(btnInsert);
            buttonPanel.Controls.Add(btnUpdate);
            buttonPanel.Controls.Add(btnDelete);
            buttonPanel.Location = new Point(20, 370);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(310, 50);
            buttonPanel.TabIndex = 14;

            // ListView
            listView1.BackColor = Color.White;
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(390, 60);
            listView1.Name = "listView1";
            listView1.Size = new Size(380, 440);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Start Date", 100);
            listView1.Columns.Add("End Date", 100);
            listView1.Columns.Add("Monthly Rent", 100);
            listView1.Columns.Add("Terms", 150);
            listView1.Columns.Add("Resident ID", 80);

            // Input Group
            inputGroup.BackColor = Color.White;
            inputGroup.Controls.Add(label1);
            inputGroup.Controls.Add(label2);
            inputGroup.Controls.Add(label3);
            inputGroup.Controls.Add(label4);
            inputGroup.Controls.Add(label5);
            inputGroup.Controls.Add(label6);
            inputGroup.Controls.Add(label7);
            inputGroup.Controls.Add(txtID);
            inputGroup.Controls.Add(dateStart);
            inputGroup.Controls.Add(dateEnd);
            inputGroup.Controls.Add(txtMonthlyRent);
            inputGroup.Controls.Add(txtTerms);
            inputGroup.Controls.Add(txtResidentID);
            inputGroup.Controls.Add(txtResidentName);
            inputGroup.Controls.Add(buttonPanel);
            inputGroup.Font = new Font("Segoe UI", 10F);
            inputGroup.Location = new Point(20, 60);
            inputGroup.Name = "inputGroup";
            inputGroup.Size = new Size(350, 440);
            inputGroup.TabIndex = 1;
            inputGroup.TabStop = false;
            inputGroup.Text = "Lease Agreement Details";

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(800, 520);
            Controls.Add(titleLabel);
            Controls.Add(inputGroup);
            Controls.Add(listView1);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 520);
            Name = "LeaseAgreement";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lease Agreement Management";
            inputGroup.ResumeLayout(false);
            inputGroup.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
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
        private Label titleLabel;
        private GroupBox inputGroup;
        private Panel buttonPanel;
    }
} 