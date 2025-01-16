namespace BullseyeDesktopApp
{
    partial class ResetPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPass));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblUsername = new Label();
            txtNew = new TextBox();
            txtConfirm = new TextBox();
            btnConfirm = new Button();
            btnExit = new Button();
            picNew = new PictureBox();
            picConfirm = new PictureBox();
            btnGenerate = new Button();
            picConfirmError = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picNew).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picConfirm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picConfirmError).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 9);
            label1.Name = "label1";
            label1.Size = new Size(265, 46);
            label1.TabIndex = 3;
            label1.Text = "Reset Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 77);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 4;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 137);
            label3.Name = "label3";
            label3.Size = new Size(141, 28);
            label3.TabIndex = 5;
            label3.Text = "New Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(87, 197);
            label4.Name = "label4";
            label4.Size = new Size(86, 28);
            label4.TabIndex = 6;
            label4.Text = "Confirm:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(191, 77);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(48, 28);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "N/A";
            // 
            // txtNew
            // 
            txtNew.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNew.Location = new Point(191, 134);
            txtNew.MaxLength = 200;
            txtNew.Name = "txtNew";
            txtNew.PasswordChar = '*';
            txtNew.Size = new Size(386, 34);
            txtNew.TabIndex = 0;
            // 
            // txtConfirm
            // 
            txtConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirm.Location = new Point(191, 194);
            txtConfirm.MaxLength = 200;
            txtConfirm.Name = "txtConfirm";
            txtConfirm.PasswordChar = '*';
            txtConfirm.Size = new Size(386, 34);
            txtConfirm.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 10.8F);
            btnConfirm.Location = new Point(207, 297);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(114, 35);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 10.8F);
            btnExit.Location = new Point(393, 297);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 35);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // picNew
            // 
            picNew.Cursor = Cursors.Hand;
            picNew.Image = (Image)resources.GetObject("picNew.Image");
            picNew.Location = new Point(545, 138);
            picNew.Name = "picNew";
            picNew.Size = new Size(30, 26);
            picNew.SizeMode = PictureBoxSizeMode.Zoom;
            picNew.TabIndex = 12;
            picNew.TabStop = false;
            picNew.Click += picNew_Click;
            // 
            // picConfirm
            // 
            picConfirm.Cursor = Cursors.Hand;
            picConfirm.Image = (Image)resources.GetObject("picConfirm.Image");
            picConfirm.Location = new Point(545, 198);
            picConfirm.Name = "picConfirm";
            picConfirm.Size = new Size(30, 26);
            picConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picConfirm.TabIndex = 13;
            picConfirm.TabStop = false;
            picConfirm.Click += picConfirm_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(298, 244);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(117, 29);
            btnGenerate.TabIndex = 14;
            btnGenerate.Text = "Auto Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // picConfirmError
            // 
            picConfirmError.Image = (Image)resources.GetObject("picConfirmError.Image");
            picConfirmError.Location = new Point(592, 196);
            picConfirmError.Name = "picConfirmError";
            picConfirmError.Size = new Size(28, 31);
            picConfirmError.SizeMode = PictureBoxSizeMode.Zoom;
            picConfirmError.TabIndex = 16;
            picConfirmError.TabStop = false;
            picConfirmError.Visible = false;
            // 
            // ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 349);
            Controls.Add(picConfirmError);
            Controls.Add(btnGenerate);
            Controls.Add(picConfirm);
            Controls.Add(picNew);
            Controls.Add(btnExit);
            Controls.Add(btnConfirm);
            Controls.Add(txtConfirm);
            Controls.Add(txtNew);
            Controls.Add(lblUsername);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ResetPass";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ResetPass";
            ((System.ComponentModel.ISupportInitialize)picNew).EndInit();
            ((System.ComponentModel.ISupportInitialize)picConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)picConfirmError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblUsername;
        private TextBox txtNew;
        private TextBox txtConfirm;
        private Button btnConfirm;
        private Button btnExit;
        private PictureBox picNew;
        private PictureBox picConfirm;
        private Button btnGenerate;
        private PictureBox picConfirmError;
    }
}