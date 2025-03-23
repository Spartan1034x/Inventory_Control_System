namespace BullseyeDesktopApp
{
    partial class DeliveryPortal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryPortal));
            dgvDeliveries = new DataGridView();
            label1 = new Label();
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label2 = new Label();
            picHelp = new PictureBox();
            grpStatus = new GroupBox();
            radOnline = new RadioButton();
            radAccept = new RadioButton();
            radHistory = new RadioButton();
            radDelivering = new RadioButton();
            radPickup = new RadioButton();
            label4 = new Label();
            picSignature = new PictureBox();
            btnConfirm = new Button();
            btnExit = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDeliveries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHelp).BeginInit();
            grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSignature).BeginInit();
            SuspendLayout();
            // 
            // dgvDeliveries
            // 
            dgvDeliveries.AllowUserToAddRows = false;
            dgvDeliveries.AllowUserToDeleteRows = false;
            dgvDeliveries.AllowUserToResizeColumns = false;
            dgvDeliveries.AllowUserToResizeRows = false;
            dgvDeliveries.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDeliveries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeliveries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeliveries.Location = new Point(33, 139);
            dgvDeliveries.MultiSelect = false;
            dgvDeliveries.Name = "dgvDeliveries";
            dgvDeliveries.ReadOnly = true;
            dgvDeliveries.RowHeadersVisible = false;
            dgvDeliveries.RowHeadersWidth = 51;
            dgvDeliveries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeliveries.Size = new Size(1173, 533);
            dgvDeliveries.TabIndex = 56;
            dgvDeliveries.SelectionChanged += dgvDeliveries_SelectionChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(544, 61);
            label1.Name = "label1";
            label1.Size = new Size(151, 41);
            label1.TabIndex = 58;
            label1.Text = "Deliveries";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(966, 8);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 62;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(966, 32);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 61;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(891, 32);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 60;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(919, 8);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 59;
            label2.Text = "User:";
            // 
            // picHelp
            // 
            picHelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picHelp.Cursor = Cursors.Hand;
            picHelp.Image = (Image)resources.GetObject("picHelp.Image");
            picHelp.Location = new Point(1177, 73);
            picHelp.Name = "picHelp";
            picHelp.Size = new Size(29, 29);
            picHelp.SizeMode = PictureBoxSizeMode.Zoom;
            picHelp.TabIndex = 63;
            picHelp.TabStop = false;
            picHelp.Click += picHelp_Click;
            // 
            // grpStatus
            // 
            grpStatus.BackColor = Color.MistyRose;
            grpStatus.Controls.Add(radOnline);
            grpStatus.Controls.Add(radAccept);
            grpStatus.Controls.Add(radHistory);
            grpStatus.Controls.Add(radDelivering);
            grpStatus.Controls.Add(radPickup);
            grpStatus.Location = new Point(33, 8);
            grpStatus.Name = "grpStatus";
            grpStatus.Size = new Size(291, 111);
            grpStatus.TabIndex = 64;
            grpStatus.TabStop = false;
            grpStatus.Text = "Status";
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Location = new Point(184, 23);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(73, 24);
            radOnline.TabIndex = 4;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            radOnline.CheckedChanged += radOnline_CheckedChanged;
            // 
            // radAccept
            // 
            radAccept.AutoSize = true;
            radAccept.Location = new Point(14, 81);
            radAccept.Name = "radAccept";
            radAccept.Size = new Size(118, 24);
            radAccept.TabIndex = 3;
            radAccept.Text = "Accept Order";
            radAccept.UseVisualStyleBackColor = true;
            radAccept.CheckedChanged += radAccept_CheckedChanged;
            // 
            // radHistory
            // 
            radHistory.AutoSize = true;
            radHistory.Location = new Point(184, 81);
            radHistory.Name = "radHistory";
            radHistory.Size = new Size(77, 24);
            radHistory.TabIndex = 2;
            radHistory.Text = "History";
            radHistory.UseVisualStyleBackColor = true;
            radHistory.CheckedChanged += radHistory_CheckedChanged;
            // 
            // radDelivering
            // 
            radDelivering.AutoSize = true;
            radDelivering.Location = new Point(14, 53);
            radDelivering.Name = "radDelivering";
            radDelivering.Size = new Size(128, 24);
            radDelivering.TabIndex = 1;
            radDelivering.Text = "Store Drop Off";
            radDelivering.UseVisualStyleBackColor = true;
            radDelivering.CheckedChanged += radDelivering_CheckedChanged;
            // 
            // radPickup
            // 
            radPickup.AutoSize = true;
            radPickup.Checked = true;
            radPickup.Location = new Point(14, 23);
            radPickup.Name = "radPickup";
            radPickup.Size = new Size(150, 24);
            radPickup.TabIndex = 0;
            radPickup.TabStop = true;
            radPickup.Text = "Warehouse Pickup";
            radPickup.UseVisualStyleBackColor = true;
            radPickup.CheckedChanged += radPickup_CheckedChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(158, 720);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 65;
            label4.Text = "Signature:";
            // 
            // picSignature
            // 
            picSignature.Anchor = AnchorStyles.Bottom;
            picSignature.BackColor = SystemColors.ScrollBar;
            picSignature.Location = new Point(295, 720);
            picSignature.Name = "picSignature";
            picSignature.Size = new Size(569, 122);
            picSignature.TabIndex = 66;
            picSignature.TabStop = false;
            picSignature.MouseDown += picSignature_MouseDown;
            picSignature.MouseMove += picSignature_MouseMove;
            picSignature.MouseUp += picSignature_MouseUp;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(1016, 720);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(122, 43);
            btnConfirm.TabIndex = 67;
            btnConfirm.Text = "&Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1016, 788);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 68;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom;
            btnClear.Location = new Point(161, 802);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 69;
            btnClear.Text = "C&lear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // DeliveryPortal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 890);
            Controls.Add(btnClear);
            Controls.Add(btnExit);
            Controls.Add(btnConfirm);
            Controls.Add(picSignature);
            Controls.Add(label4);
            Controls.Add(grpStatus);
            Controls.Add(picHelp);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDeliveries);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DeliveryPortal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Delivery Portal";
            Load += DeliveryPortal_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDeliveries).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHelp).EndInit();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSignature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDeliveries;
        private Label label1;
        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label2;
        private PictureBox picHelp;
        private GroupBox grpStatus;
        private RadioButton radDelivering;
        private RadioButton radPickup;
        private Label label4;
        private PictureBox picSignature;
        private Button btnConfirm;
        private Button btnExit;
        private Button btnClear;
        private RadioButton radHistory;
        private RadioButton radAccept;
        private RadioButton radOnline;
    }
}