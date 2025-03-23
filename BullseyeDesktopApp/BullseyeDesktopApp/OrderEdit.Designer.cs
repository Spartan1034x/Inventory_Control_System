namespace BullseyeDesktopApp
{
    partial class OrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEdit));
            picLogo = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtOrderID = new TextBox();
            txtCreatedDate = new TextBox();
            txtDeliveryID = new TextBox();
            cmbStatus = new ComboBox();
            cmbSiteTo = new ComboBox();
            cmbSiteFrom = new ComboBox();
            cmbType = new ComboBox();
            txtBarcode = new TextBox();
            chkEmergency = new CheckBox();
            btnSave = new Button();
            btnCancelOrder = new Button();
            btnExit = new Button();
            dtpShip = new DateTimePicker();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Top;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(0, 1);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 112);
            label1.Name = "label1";
            label1.Size = new Size(91, 28);
            label1.TabIndex = 11;
            label1.Text = "Order ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 184);
            label2.Name = "label2";
            label2.Size = new Size(84, 28);
            label2.TabIndex = 12;
            label2.Text = "Created:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 256);
            label3.Name = "label3";
            label3.Size = new Size(69, 28);
            label3.TabIndex = 13;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 328);
            label4.Name = "label4";
            label4.Size = new Size(101, 28);
            label4.TabIndex = 14;
            label4.Text = "Ship Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 400);
            label5.Name = "label5";
            label5.Size = new Size(74, 28);
            label5.TabIndex = 15;
            label5.Text = "Site To:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(21, 472);
            label6.Name = "label6";
            label6.Size = new Size(100, 28);
            label6.TabIndex = 16;
            label6.Text = "Site From:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(21, 544);
            label7.Name = "label7";
            label7.Size = new Size(90, 28);
            label7.TabIndex = 17;
            label7.Text = "Txn Type:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(21, 616);
            label8.Name = "label8";
            label8.Size = new Size(95, 28);
            label8.TabIndex = 18;
            label8.Text = "Bar Code:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(21, 688);
            label9.Name = "label9";
            label9.Size = new Size(111, 28);
            label9.TabIndex = 19;
            label9.Text = "Delivery ID:";
            // 
            // txtOrderID
            // 
            txtOrderID.Enabled = false;
            txtOrderID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOrderID.Location = new Point(146, 109);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(132, 34);
            txtOrderID.TabIndex = 0;
            // 
            // txtCreatedDate
            // 
            txtCreatedDate.Enabled = false;
            txtCreatedDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCreatedDate.Location = new Point(146, 180);
            txtCreatedDate.Name = "txtCreatedDate";
            txtCreatedDate.Size = new Size(256, 34);
            txtCreatedDate.TabIndex = 1;
            // 
            // txtDeliveryID
            // 
            txtDeliveryID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeliveryID.Location = new Point(146, 685);
            txtDeliveryID.Name = "txtDeliveryID";
            txtDeliveryID.Size = new Size(132, 34);
            txtDeliveryID.TabIndex = 8;
            txtDeliveryID.KeyPress += txtDeliveryID_KeyPress;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(146, 251);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 36);
            cmbStatus.TabIndex = 2;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // cmbSiteTo
            // 
            cmbSiteTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSiteTo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSiteTo.FormattingEnabled = true;
            cmbSiteTo.Location = new Point(146, 395);
            cmbSiteTo.Name = "cmbSiteTo";
            cmbSiteTo.Size = new Size(256, 36);
            cmbSiteTo.TabIndex = 4;
            // 
            // cmbSiteFrom
            // 
            cmbSiteFrom.Enabled = false;
            cmbSiteFrom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSiteFrom.FormattingEnabled = true;
            cmbSiteFrom.Location = new Point(146, 468);
            cmbSiteFrom.Name = "cmbSiteFrom";
            cmbSiteFrom.Size = new Size(256, 36);
            cmbSiteFrom.TabIndex = 5;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(146, 541);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(221, 36);
            cmbType.TabIndex = 6;
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarcode.Location = new Point(146, 614);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(256, 34);
            txtBarcode.TabIndex = 7;
            // 
            // chkEmergency
            // 
            chkEmergency.AutoSize = true;
            chkEmergency.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEmergency.Location = new Point(226, 742);
            chkEmergency.Name = "chkEmergency";
            chkEmergency.Size = new Size(186, 32);
            chkEmergency.TabIndex = 9;
            chkEmergency.Text = "Emergency Order";
            chkEmergency.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LawnGreen;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(98, 811);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(164, 54);
            btnSave.TabIndex = 10;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.BackColor = Color.IndianRed;
            btnCancelOrder.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelOrder.Location = new Point(373, 811);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(164, 54);
            btnCancelOrder.TabIndex = 11;
            btnCancelOrder.Text = "&Cancel Order";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ControlDark;
            btnExit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(230, 891);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(164, 54);
            btnExit.TabIndex = 12;
            btnExit.Text = "&Go Back";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // dtpShip
            // 
            dtpShip.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpShip.Format = DateTimePickerFormat.Custom;
            dtpShip.Location = new Point(146, 329);
            dtpShip.MaxDate = new DateTime(3000, 12, 31, 0, 0, 0, 0);
            dtpShip.MaximumSize = new Size(250, 27);
            dtpShip.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
            dtpShip.MinimumSize = new Size(250, 27);
            dtpShip.Name = "dtpShip";
            dtpShip.Size = new Size(250, 27);
            dtpShip.TabIndex = 3;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(233, 33);
            label10.Name = "label10";
            label10.Size = new Size(158, 41);
            label10.TabIndex = 20;
            label10.Text = "Edit Order";
            // 
            // OrderEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 976);
            Controls.Add(label10);
            Controls.Add(dtpShip);
            Controls.Add(btnExit);
            Controls.Add(btnCancelOrder);
            Controls.Add(btnSave);
            Controls.Add(chkEmergency);
            Controls.Add(txtBarcode);
            Controls.Add(cmbType);
            Controls.Add(cmbSiteFrom);
            Controls.Add(cmbSiteTo);
            Controls.Add(cmbStatus);
            Controls.Add(txtDeliveryID);
            Controls.Add(txtCreatedDate);
            Controls.Add(txtOrderID);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OrderEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Order";
            Load += OrderEdit_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtOrderID;
        private TextBox txtCreatedDate;
        private TextBox txtDeliveryID;
        private ComboBox cmbStatus;
        private ComboBox cmbSiteTo;
        private ComboBox cmbSiteFrom;
        private ComboBox cmbType;
        private TextBox txtBarcode;
        private CheckBox chkEmergency;
        private Button btnSave;
        private Button btnCancelOrder;
        private Button btnExit;
        private DateTimePicker dtpShip;
        private Label label10;
    }
}