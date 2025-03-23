namespace BullseyeDesktopApp
{
    partial class OrderReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReceive));
            picHelp = new PictureBox();
            label1 = new Label();
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label2 = new Label();
            grpOrderDetails = new GroupBox();
            lblDate = new Label();
            label7 = new Label();
            lblType = new Label();
            label6 = new Label();
            lblStoreTo = new Label();
            label4 = new Label();
            dgvOrderItems = new DataGridView();
            btnDelete = new Button();
            btnExit = new Button();
            btnSubmit = new Button();
            label5 = new Label();
            txtNotes = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picHelp).BeginInit();
            grpOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            SuspendLayout();
            // 
            // picHelp
            // 
            picHelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picHelp.Cursor = Cursors.Hand;
            picHelp.Image = (Image)resources.GetObject("picHelp.Image");
            picHelp.Location = new Point(1295, 70);
            picHelp.Name = "picHelp";
            picHelp.Size = new Size(29, 29);
            picHelp.SizeMode = PictureBoxSizeMode.Zoom;
            picHelp.TabIndex = 42;
            picHelp.TabStop = false;
            picHelp.Click += picHelp_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(573, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 41);
            label1.TabIndex = 41;
            label1.Text = "Receive Order";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(1017, 2);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 40;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(1017, 26);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 39;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(942, 26);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 38;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(970, 2);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 37;
            label2.Text = "User:";
            // 
            // grpOrderDetails
            // 
            grpOrderDetails.Controls.Add(lblDate);
            grpOrderDetails.Controls.Add(label7);
            grpOrderDetails.Controls.Add(lblType);
            grpOrderDetails.Controls.Add(label6);
            grpOrderDetails.Controls.Add(lblStoreTo);
            grpOrderDetails.Controls.Add(label4);
            grpOrderDetails.Location = new Point(12, 9);
            grpOrderDetails.Name = "grpOrderDetails";
            grpOrderDetails.Size = new Size(294, 165);
            grpOrderDetails.TabIndex = 43;
            grpOrderDetails.TabStop = false;
            grpOrderDetails.Text = "Order Details";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.FromArgb(192, 0, 0);
            lblDate.Location = new Point(79, 117);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(39, 20);
            lblDate.TabIndex = 5;
            lblDate.Text = "date";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 117);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 4;
            label7.Text = "Created:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.ForeColor = Color.FromArgb(192, 0, 0);
            lblType.Location = new Point(79, 78);
            lblType.Name = "lblType";
            lblType.Size = new Size(38, 20);
            lblType.TabIndex = 3;
            lblType.Text = "type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 78);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 2;
            label6.Text = "Type:";
            // 
            // lblStoreTo
            // 
            lblStoreTo.AutoSize = true;
            lblStoreTo.ForeColor = Color.FromArgb(192, 0, 0);
            lblStoreTo.Location = new Point(79, 39);
            lblStoreTo.Name = "lblStoreTo";
            lblStoreTo.Size = new Size(44, 20);
            lblStoreTo.TabIndex = 1;
            lblStoreTo.Text = "Store";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 39);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 0;
            label4.Text = "Store To:";
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.AllowUserToResizeColumns = false;
            dgvOrderItems.AllowUserToResizeRows = false;
            dgvOrderItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(91, 194);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.ReadOnly = true;
            dgvOrderItems.RowHeadersVisible = false;
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItems.Size = new Size(1142, 483);
            dgvOrderItems.TabIndex = 44;
            dgvOrderItems.KeyDown += dgvOrderItems_KeyDown;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(669, 760);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 40);
            btnDelete.TabIndex = 45;
            btnDelete.Text = "&Delete Item";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1089, 760);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(141, 40);
            btnExit.TabIndex = 46;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom;
            btnSubmit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(879, 760);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(141, 40);
            btnSubmit.TabIndex = 47;
            btnSubmit.Text = "&Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(34, 696);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 62;
            label5.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(91, 696);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(459, 125);
            txtNotes.TabIndex = 61;
            // 
            // ReceiveOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 833);
            Controls.Add(label5);
            Controls.Add(txtNotes);
            Controls.Add(btnSubmit);
            Controls.Add(btnExit);
            Controls.Add(btnDelete);
            Controls.Add(dgvOrderItems);
            Controls.Add(grpOrderDetails);
            Controls.Add(picHelp);
            Controls.Add(label1);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReceiveOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receive Order";
            Load += ReceiveOrder_Load;
            ((System.ComponentModel.ISupportInitialize)picHelp).EndInit();
            grpOrderDetails.ResumeLayout(false);
            grpOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picHelp;
        private Label label1;
        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label2;
        private GroupBox grpOrderDetails;
        private Label lblDate;
        private Label label7;
        private Label lblType;
        private Label label6;
        private Label lblStoreTo;
        private Label label4;
        private DataGridView dgvOrderItems;
        private Button btnDelete;
        private Button btnExit;
        private Button btnSubmit;
        private Label label5;
        private TextBox txtNotes;
    }
}