namespace BullseyeDesktopApp
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            picLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tabControl1 = new TabControl();
            tabOrders = new TabPage();
            tabInventory = new TabPage();
            tabLoss = new TabPage();
            tabReports = new TabPage();
            tabAdmin = new TabPage();
            btnRefresh = new Button();
            btnExit = new Button();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(0, 3);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(489, 9);
            label1.Name = "label1";
            label1.Size = new Size(182, 41);
            label1.TabIndex = 1;
            label1.Text = "Bullseye ICS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1018, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "User:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1018, 30);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "Location:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabOrders);
            tabControl1.Controls.Add(tabInventory);
            tabControl1.Controls.Add(tabLoss);
            tabControl1.Controls.Add(tabReports);
            tabControl1.Controls.Add(tabAdmin);
            tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(53, 133);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1119, 472);
            tabControl1.TabIndex = 4;
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
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(53, 628);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(122, 43);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1050, 628);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(476, 674);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 7;
            label4.Text = "Database Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(601, 674);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 8;
            label5.Text = "Unknown";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 703);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnExit);
            Controls.Add(btnRefresh);
            Controls.Add(tabControl1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dashboard";
            Text = "Bullseye Inventory Management Systems - Dashboard";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabOrders;
        private TabPage tabInventory;
        private TabPage tabLoss;
        private TabPage tabReports;
        private TabPage tabAdmin;
        private Button btnRefresh;
        private Button btnExit;
        private Label label4;
        private Label label5;
    }
}
