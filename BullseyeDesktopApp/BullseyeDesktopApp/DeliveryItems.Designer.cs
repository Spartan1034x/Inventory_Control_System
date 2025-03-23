namespace BullseyeDesktopApp
{
    partial class DeliveryItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryItems));
            btnConfirm = new Button();
            btnCancel = new Button();
            grpOrderDetails = new GroupBox();
            lblDate = new Label();
            label6 = new Label();
            lblID = new Label();
            label4 = new Label();
            label1 = new Label();
            dgvItems = new DataGridView();
            grpOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Bottom;
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(123, 846);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(144, 43);
            btnConfirm.TabIndex = 72;
            btnConfirm.Text = "Confirm &Items";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(505, 846);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 43);
            btnCancel.TabIndex = 71;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // grpOrderDetails
            // 
            grpOrderDetails.Controls.Add(lblDate);
            grpOrderDetails.Controls.Add(label6);
            grpOrderDetails.Controls.Add(lblID);
            grpOrderDetails.Controls.Add(label4);
            grpOrderDetails.Location = new Point(12, 12);
            grpOrderDetails.Name = "grpOrderDetails";
            grpOrderDetails.Size = new Size(734, 74);
            grpOrderDetails.TabIndex = 73;
            grpOrderDetails.TabStop = false;
            grpOrderDetails.Text = "Delivery Details";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.FromArgb(192, 0, 0);
            lblDate.Location = new Point(483, 33);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(38, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "type";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(370, 33);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 2;
            label6.Text = "Delivery Date:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = Color.FromArgb(192, 0, 0);
            lblID.Location = new Point(119, 33);
            lblID.Name = "lblID";
            lblID.Size = new Size(44, 20);
            lblID.TabIndex = 1;
            lblID.Text = "Store";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 33);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 0;
            label4.Text = "Delivery ID:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(288, 98);
            label1.Name = "label1";
            label1.Size = new Size(214, 41);
            label1.TabIndex = 74;
            label1.Text = "Delivery Items";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.AllowUserToResizeColumns = false;
            dgvItems.AllowUserToResizeRows = false;
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(12, 156);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 51;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(766, 659);
            dgvItems.TabIndex = 75;
            // 
            // DeliveryItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 920);
            ControlBox = false;
            Controls.Add(dgvItems);
            Controls.Add(label1);
            Controls.Add(grpOrderDetails);
            Controls.Add(btnConfirm);
            Controls.Add(btnCancel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DeliveryItems";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Delivery Items";
            Load += DeliveryItems_Load;
            grpOrderDetails.ResumeLayout(false);
            grpOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnCancel;
        private GroupBox grpOrderDetails;
        private Label lblDate;
        private Label label6;
        private Label lblID;
        private Label label4;
        private Label label1;
        private DataGridView dgvItems;
    }
}