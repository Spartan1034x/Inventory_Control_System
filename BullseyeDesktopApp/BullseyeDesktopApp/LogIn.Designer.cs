namespace BullseyeDesktopApp
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            picLogo = new PictureBox();
            label1 = new Label();
            btnHelp = new Button();
            label2 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lnkForgot = new LinkLabel();
            btnLogin = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(75, 61);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(193, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 46);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // btnHelp
            // 
            btnHelp.FlatAppearance.BorderColor = Color.Black;
            btnHelp.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 12F);
            btnHelp.Location = new Point(752, 13);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(36, 34);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "?";
            btnHelp.TextAlign = ContentAlignment.TopCenter;
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 113);
            label2.Name = "label2";
            label2.Size = new Size(159, 41);
            label2.TabIndex = 4;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 191);
            label3.Name = "label3";
            label3.Size = new Size(150, 41);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(215, 113);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "jsmith";
            txtUsername.Size = new Size(465, 47);
            txtUsername.TabIndex = 0;
            txtUsername.Text = "aadmin";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(215, 191);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(465, 47);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "P@ssw0rd-";
            // 
            // lnkForgot
            // 
            lnkForgot.AutoSize = true;
            lnkForgot.Location = new Point(35, 356);
            lnkForgot.Name = "lnkForgot";
            lnkForgot.Size = new Size(127, 20);
            lnkForgot.TabIndex = 4;
            lnkForgot.TabStop = true;
            lnkForgot.Text = "Forgot password?";
            lnkForgot.LinkClicked += lnkForgot_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(273, 284);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(114, 43);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "&Log In";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(488, 284);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 43);
            btnExit.TabIndex = 3;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 399);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(lnkForgot);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnHelp);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Login";
            FormClosing += LogIn_FormClosing;
            Load += LogIn_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label label1;
        private Button btnHelp;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private LinkLabel lnkForgot;
        private Button btnLogin;
        private Button btnExit;
    }
}