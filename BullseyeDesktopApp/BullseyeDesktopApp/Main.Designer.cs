namespace BullseyeDesktopApp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            tabPages = new TabControl();
            tabOrders = new TabPage();
            tabInventory = new TabPage();
            tabLoss = new TabPage();
            tabReports = new TabPage();
            tabAdmin = new TabPage();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            picLogo = new PictureBox();
            lblStatus = new Label();
            label4 = new Label();
            btnExit = new Button();
            btnRefresh = new Button();
            lblLocation = new Label();
            lblUser = new Label();
            tabPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tabPages
            // 
            tabPages.Controls.Add(tabOrders);
            tabPages.Controls.Add(tabInventory);
            tabPages.Controls.Add(tabLoss);
            tabPages.Controls.Add(tabReports);
            tabPages.Controls.Add(tabAdmin);
            tabPages.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPages.Location = new Point(54, 136);
            tabPages.Name = "tabPages";
            tabPages.SelectedIndex = 0;
            tabPages.Size = new Size(1119, 472);
            tabPages.TabIndex = 13;
            // 
            // tabOrders
            // 
            tabOrders.Location = new Point(4, 37);
            tabOrders.Name = "tabOrders";
            tabOrders.Padding = new Padding(3);
            tabOrders.Size = new Size(1111, 431);
            tabOrders.TabIndex = 0;
            tabOrders.Text = "Orders";
            tabOrders.UseVisualStyleBackColor = true;
            // 
            // tabInventory
            // 
            tabInventory.Location = new Point(4, 37);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new Padding(3);
            tabInventory.Size = new Size(1111, 431);
            tabInventory.TabIndex = 1;
            tabInventory.Text = "Inventory";
            tabInventory.UseVisualStyleBackColor = true;
            // 
            // tabLoss
            // 
            tabLoss.Location = new Point(4, 37);
            tabLoss.Name = "tabLoss";
            tabLoss.Size = new Size(1111, 431);
            tabLoss.TabIndex = 2;
            tabLoss.Text = "Loss / Return";
            tabLoss.UseVisualStyleBackColor = true;
            // 
            // tabReports
            // 
            tabReports.Location = new Point(4, 37);
            tabReports.Name = "tabReports";
            tabReports.Size = new Size(1111, 431);
            tabReports.TabIndex = 3;
            tabReports.Text = "Reports";
            tabReports.UseVisualStyleBackColor = true;
            // 
            // tabAdmin
            // 
            tabAdmin.Location = new Point(4, 37);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Size = new Size(1111, 431);
            tabAdmin.TabIndex = 4;
            tabAdmin.Text = "Admin";
            tabAdmin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(890, 33);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 12;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(918, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 11;
            label2.Text = "User:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(490, 12);
            label1.Name = "label1";
            label1.Size = new Size(182, 41);
            label1.TabIndex = 10;
            label1.Text = "Bullseye ICS";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, 6);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(602, 677);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Unknown";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(477, 677);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 16;
            label4.Text = "Database Status:";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1051, 631);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 15;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(54, 631);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(122, 43);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(965, 33);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 18;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(965, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 19;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 703);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(tabPages);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(btnExit);
            Controls.Add(btnRefresh);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            tabPages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabPages;
        private TabPage tabOrders;
        private TabPage tabInventory;
        private TabPage tabLoss;
        private TabPage tabReports;
        private TabPage tabAdmin;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox picLogo;
        private Label lblStatus;
        private Label label4;
        private Button btnExit;
        private Button btnRefresh;
        private Label lblLocation;
        private Label lblUser;
    }
}