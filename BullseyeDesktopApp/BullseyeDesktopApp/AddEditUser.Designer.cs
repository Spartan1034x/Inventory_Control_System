namespace BullseyeDesktopApp
{
    partial class AddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditUser));
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label2 = new Label();
            picLogo = new PictureBox();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtID = new TextBox();
            txtUsername = new TextBox();
            txtFName = new TextBox();
            txtLName = new TextBox();
            txtEmail = new TextBox();
            cmbPosition = new ComboBox();
            cmbLocation = new ComboBox();
            chkActive = new CheckBox();
            btnSave = new Button();
            btnExit = new Button();
            txtPassword = new TextBox();
            label10 = new Label();
            chkLocked = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(157, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 23;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(185, 43);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 43);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 21;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 20;
            label2.Text = "User:";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 24;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 108);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 25;
            label1.Text = "Employee ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 26;
            label4.Text = "Username:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 288);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 27;
            label5.Text = "First Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 348);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 28;
            label6.Text = "Last Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 408);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 29;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 528);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 30;
            label8.Text = "Location:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 468);
            label9.Name = "label9";
            label9.Size = new Size(64, 20);
            label9.TabIndex = 31;
            label9.Text = "Position:";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(124, 105);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 32;
            // 
            // txtUsername
            // 
            txtUsername.Enabled = false;
            txtUsername.Location = new Point(124, 165);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(261, 27);
            txtUsername.TabIndex = 33;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(124, 285);
            txtFName.MaxLength = 20;
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(261, 27);
            txtFName.TabIndex = 34;
            txtFName.TextChanged += txtFName_TextChanged;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(124, 345);
            txtLName.MaxLength = 20;
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(261, 27);
            txtLName.TabIndex = 35;
            txtLName.TextChanged += txtLName_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(124, 405);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(261, 27);
            txtEmail.TabIndex = 36;
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(124, 464);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(261, 28);
            cmbPosition.Sorted = true;
            cmbPosition.TabIndex = 37;
            // 
            // cmbLocation
            // 
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(124, 524);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(261, 28);
            cmbLocation.Sorted = true;
            cmbLocation.TabIndex = 38;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(124, 572);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(72, 24);
            chkActive.TabIndex = 39;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(86, 617);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 40;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(266, 617);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 41;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(124, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(261, 27);
            txtPassword.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 228);
            label10.Name = "label10";
            label10.Size = new Size(73, 20);
            label10.TabIndex = 42;
            label10.Text = "Password:";
            // 
            // chkLocked
            // 
            chkLocked.AutoSize = true;
            chkLocked.Enabled = false;
            chkLocked.Location = new Point(239, 572);
            chkLocked.Name = "chkLocked";
            chkLocked.Size = new Size(78, 24);
            chkLocked.TabIndex = 44;
            chkLocked.Text = "Locked";
            chkLocked.UseVisualStyleBackColor = true;
            // 
            // AddEditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 671);
            Controls.Add(chkLocked);
            Controls.Add(txtPassword);
            Controls.Add(label10);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(chkActive);
            Controls.Add(cmbLocation);
            Controls.Add(cmbPosition);
            Controls.Add(txtEmail);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(txtUsername);
            Controls.Add(txtID);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEditUser";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += AddEditUser_FormClosing;
            Load += AddEditUser_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label2;
        private PictureBox picLogo;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtID;
        private TextBox txtUsername;
        private TextBox txtFName;
        private TextBox txtLName;
        private TextBox txtEmail;
        private ComboBox cmbPosition;
        private ComboBox cmbLocation;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnExit;
        private TextBox txtPassword;
        private Label label10;
        private CheckBox chkLocked;
    }
}