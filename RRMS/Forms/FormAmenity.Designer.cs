namespace RRMS.Forms
{
    partial class FormAmenity
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            txtAmeID = new TextBox();
            txtAmeName = new TextBox();
            txtAmeAvail = new TextBox();
            txtAmeLoc = new TextBox();
            txtAmeBP = new TextBox();
            txtAmeCPR = new TextBox();
            txtAmeDesc = new TextBox();
            btnNew = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvAme = new DataGridView();
            btnClose = new Button();
            txtSearch = new TextBox();
            label9 = new Label();
            dtpAmeMD = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvAme).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Amenity ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 77);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 2;
            label3.Text = "Availability";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 108);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 3;
            label4.Text = "Location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 140);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Bought Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 178);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 5;
            label6.Text = "Cost Per Rent";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 248);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 7;
            label8.Text = "Description";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 215);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 6;
            label7.Text = "Maintenance Date";
            // 
            // txtAmeID
            // 
            txtAmeID.Location = new Point(190, 5);
            txtAmeID.Name = "txtAmeID";
            txtAmeID.Size = new Size(100, 23);
            txtAmeID.TabIndex = 8;
            // 
            // txtAmeName
            // 
            txtAmeName.Location = new Point(190, 40);
            txtAmeName.Name = "txtAmeName";
            txtAmeName.Size = new Size(100, 23);
            txtAmeName.TabIndex = 9;
            // 
            // txtAmeAvail
            // 
            txtAmeAvail.Location = new Point(190, 69);
            txtAmeAvail.Name = "txtAmeAvail";
            txtAmeAvail.Size = new Size(100, 23);
            txtAmeAvail.TabIndex = 10;
            // 
            // txtAmeLoc
            // 
            txtAmeLoc.Location = new Point(190, 105);
            txtAmeLoc.Name = "txtAmeLoc";
            txtAmeLoc.Size = new Size(100, 23);
            txtAmeLoc.TabIndex = 11;
            // 
            // txtAmeBP
            // 
            txtAmeBP.Location = new Point(190, 140);
            txtAmeBP.Name = "txtAmeBP";
            txtAmeBP.Size = new Size(100, 23);
            txtAmeBP.TabIndex = 12;
            // 
            // txtAmeCPR
            // 
            txtAmeCPR.Location = new Point(190, 178);
            txtAmeCPR.Name = "txtAmeCPR";
            txtAmeCPR.Size = new Size(100, 23);
            txtAmeCPR.TabIndex = 13;
            // 
            // txtAmeDesc
            // 
            txtAmeDesc.Location = new Point(190, 248);
            txtAmeDesc.Name = "txtAmeDesc";
            txtAmeDesc.Size = new Size(100, 23);
            txtAmeDesc.TabIndex = 15;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(334, 11);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 16;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(415, 12);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 17;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(496, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(577, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvAme
            // 
            dgvAme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAme.Location = new Point(452, 113);
            dgvAme.Name = "dgvAme";
            dgvAme.Size = new Size(240, 150);
            dgvAme.TabIndex = 20;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(658, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 21;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(506, 59);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(374, 62);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 22;
            label9.Text = "Amenity ID";
            // 
            // dtpAmeMD
            // 
            dtpAmeMD.Location = new Point(190, 215);
            dtpAmeMD.Name = "dtpAmeMD";
            dtpAmeMD.Size = new Size(200, 23);
            dtpAmeMD.TabIndex = 24;
            // 
            // FormAmenity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpAmeMD);
            Controls.Add(txtSearch);
            Controls.Add(label9);
            Controls.Add(btnClose);
            Controls.Add(dgvAme);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnNew);
            Controls.Add(txtAmeDesc);
            Controls.Add(txtAmeCPR);
            Controls.Add(txtAmeBP);
            Controls.Add(txtAmeLoc);
            Controls.Add(txtAmeAvail);
            Controls.Add(txtAmeName);
            Controls.Add(txtAmeID);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAmenity";
            Text = "Amenity";
            ((System.ComponentModel.ISupportInitialize)dgvAme).EndInit();
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
        private Label label8;
        private Label label7;
        private TextBox txtAmeID;
        private TextBox txtAmeName;
        private TextBox txtAmeAvail;
        private TextBox txtAmeLoc;
        private TextBox txtAmeBP;
        private TextBox txtAmeCPR;
        private TextBox txtAmeDesc;
        private Button btnNew;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvAme;
        private Button btnClose;
        private TextBox txtSearch;
        private Label label9;
        private DateTimePicker dtpAmeMD;
    }
}