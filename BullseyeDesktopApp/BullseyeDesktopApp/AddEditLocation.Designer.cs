namespace BullseyeDesktopApp
{
    partial class AddEditLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditLocation));
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label2 = new Label();
            lblAdd = new Label();
            picLogo = new PictureBox();
            lblEdit = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            txtID = new TextBox();
            cmbDeliveryDay = new ComboBox();
            txtLoc = new TextBox();
            txtAddress = new TextBox();
            cmbProv = new ComboBox();
            txtCity = new TextBox();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnExit = new Button();
            cmbSiteType = new ComboBox();
            cmbCountry = new ComboBox();
            chkActive = new CheckBox();
            nudDistance = new NumericUpDown();
            mtxtPostal = new MaskedTextBox();
            mtxtPhone = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDistance).BeginInit();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(181, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 25;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(440, 9);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 9);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 23;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 22;
            label2.Text = "User:";
            // 
            // lblAdd
            // 
            lblAdd.AutoSize = true;
            lblAdd.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdd.Location = new Point(299, 56);
            lblAdd.Name = "lblAdd";
            lblAdd.Size = new Size(200, 41);
            lblAdd.TabIndex = 21;
            lblAdd.Text = "Add Location";
            lblAdd.Visible = false;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(2, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 20;
            picLogo.TabStop = false;
            // 
            // lblEdit
            // 
            lblEdit.AutoSize = true;
            lblEdit.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEdit.Location = new Point(301, 56);
            lblEdit.Name = "lblEdit";
            lblEdit.Size = new Size(197, 41);
            lblEdit.TabIndex = 26;
            lblEdit.Text = "Edit Location";
            lblEdit.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 143);
            label1.Name = "label1";
            label1.Size = new Size(73, 28);
            label1.TabIndex = 27;
            label1.Text = "Site ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 647);
            label4.Name = "label4";
            label4.Size = new Size(68, 28);
            label4.TabIndex = 28;
            label4.Text = "Notes:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 584);
            label5.Name = "label5";
            label5.Size = new Size(95, 28);
            label5.TabIndex = 29;
            label5.Text = "Site Type:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 521);
            label6.Name = "label6";
            label6.Size = new Size(126, 28);
            label6.TabIndex = 30;
            label6.Text = "Delivery Day:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(33, 458);
            label7.Name = "label7";
            label7.Size = new Size(114, 28);
            label7.TabIndex = 31;
            label7.Text = "PostalCode:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(33, 395);
            label8.Name = "label8";
            label8.Size = new Size(91, 28);
            label8.TabIndex = 32;
            label8.Text = "Province:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(33, 332);
            label9.Name = "label9";
            label9.Size = new Size(50, 28);
            label9.TabIndex = 33;
            label9.Text = "City:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(33, 206);
            label10.Name = "label10";
            label10.Size = new Size(91, 28);
            label10.TabIndex = 34;
            label10.Text = "Location:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(400, 395);
            label11.Name = "label11";
            label11.Size = new Size(86, 28);
            label11.TabIndex = 35;
            label11.Text = "Country:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(400, 458);
            label12.Name = "label12";
            label12.Size = new Size(71, 28);
            label12.TabIndex = 36;
            label12.Text = "Phone:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(440, 521);
            label13.Name = "label13";
            label13.Size = new Size(134, 28);
            label13.TabIndex = 37;
            label13.Text = "Distance (km):";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(33, 269);
            label14.Name = "label14";
            label14.Size = new Size(86, 28);
            label14.TabIndex = 38;
            label14.Text = "Address:";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(181, 144);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 0;
            // 
            // cmbDeliveryDay
            // 
            cmbDeliveryDay.FormattingEnabled = true;
            cmbDeliveryDay.Location = new Point(181, 521);
            cmbDeliveryDay.Name = "cmbDeliveryDay";
            cmbDeliveryDay.Size = new Size(197, 28);
            cmbDeliveryDay.TabIndex = 8;
            // 
            // txtLoc
            // 
            txtLoc.Location = new Point(181, 207);
            txtLoc.Name = "txtLoc";
            txtLoc.Size = new Size(586, 27);
            txtLoc.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(181, 270);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(586, 27);
            txtAddress.TabIndex = 2;
            // 
            // cmbProv
            // 
            cmbProv.FormattingEnabled = true;
            cmbProv.Location = new Point(181, 395);
            cmbProv.Name = "cmbProv";
            cmbProv.Size = new Size(102, 28);
            cmbProv.TabIndex = 4;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(181, 333);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(586, 27);
            txtCity.TabIndex = 3;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(181, 651);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(586, 223);
            txtNotes.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(256, 899);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 43);
            btnSave.TabIndex = 12;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(452, 899);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 13;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cmbSiteType
            // 
            cmbSiteType.FormattingEnabled = true;
            cmbSiteType.Location = new Point(181, 584);
            cmbSiteType.Name = "cmbSiteType";
            cmbSiteType.Size = new Size(197, 28);
            cmbSiteType.TabIndex = 10;
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(492, 395);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(275, 28);
            cmbCountry.TabIndex = 5;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkActive.Location = new Point(505, 141);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(88, 32);
            chkActive.TabIndex = 54;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // nudDistance
            // 
            nudDistance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudDistance.Location = new Point(589, 522);
            nudDistance.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDistance.Name = "nudDistance";
            nudDistance.Size = new Size(150, 34);
            nudDistance.TabIndex = 9;
            // 
            // mtxtPostal
            // 
            mtxtPostal.Location = new Point(181, 459);
            mtxtPostal.Mask = "L0L 0L0";
            mtxtPostal.Name = "mtxtPostal";
            mtxtPostal.Size = new Size(125, 27);
            mtxtPostal.TabIndex = 6;
            // 
            // mtxtPhone
            // 
            mtxtPhone.Location = new Point(492, 459);
            mtxtPhone.Mask = "(000) 000-0000";
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Size = new Size(275, 27);
            mtxtPhone.TabIndex = 7;
            mtxtPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // AddEditLocation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 966);
            Controls.Add(mtxtPhone);
            Controls.Add(mtxtPostal);
            Controls.Add(nudDistance);
            Controls.Add(chkActive);
            Controls.Add(cmbCountry);
            Controls.Add(cmbSiteType);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(txtCity);
            Controls.Add(cmbProv);
            Controls.Add(txtAddress);
            Controls.Add(txtLoc);
            Controls.Add(cmbDeliveryDay);
            Controls.Add(txtID);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(lblEdit);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblAdd);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(816, 1013);
            Name = "AddEditLocation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Location";
            Load += AddEditLocation_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDistance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label2;
        private Label lblAdd;
        private PictureBox picLogo;
        private Label lblEdit;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtID;
        private ComboBox cmbDeliveryDay;
        private TextBox txtLoc;
        private TextBox txtAddress;
        private ComboBox cmbProv;
        private TextBox txtCity;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnExit;
        private ComboBox cmbSiteType;
        private ComboBox cmbCountry;
        private CheckBox chkActive;
        private NumericUpDown nudDistance;
        private MaskedTextBox mtxtPostal;
        private MaskedTextBox mtxtPhone;
    }
}