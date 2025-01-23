namespace BullseyeDesktopApp
{
    partial class AuditRecords
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditRecords));
            picLogo = new PictureBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            createdDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            txnIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            txnTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            txnDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            siteIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            deliveryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            txnauditBindingSource = new BindingSource(components);
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txnauditBindingSource).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(-1, 1);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(379, 19);
            label1.Name = "label1";
            label1.Size = new Size(209, 41);
            label1.TabIndex = 2;
            label1.Text = "Audit Records";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { createdDateDataGridViewTextBoxColumn, txnIdDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, txnTypeDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, txnDateDataGridViewTextBoxColumn, siteIdDataGridViewTextBoxColumn, deliveryIdDataGridViewTextBoxColumn });
            dataGridView1.DataSource = txnauditBindingSource;
            dataGridView1.Location = new Point(35, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1408, 560);
            dataGridView1.TabIndex = 3;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            createdDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // txnIdDataGridViewTextBoxColumn
            // 
            txnIdDataGridViewTextBoxColumn.DataPropertyName = "TxnId";
            txnIdDataGridViewTextBoxColumn.HeaderText = "TxnId";
            txnIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            txnIdDataGridViewTextBoxColumn.Name = "txnIdDataGridViewTextBoxColumn";
            txnIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // txnTypeDataGridViewTextBoxColumn
            // 
            txnTypeDataGridViewTextBoxColumn.DataPropertyName = "TxnType";
            txnTypeDataGridViewTextBoxColumn.HeaderText = "TxnType";
            txnTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            txnTypeDataGridViewTextBoxColumn.Name = "txnTypeDataGridViewTextBoxColumn";
            txnTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // txnDateDataGridViewTextBoxColumn
            // 
            txnDateDataGridViewTextBoxColumn.DataPropertyName = "TxnDate";
            txnDateDataGridViewTextBoxColumn.HeaderText = "TxnDate";
            txnDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            txnDateDataGridViewTextBoxColumn.Name = "txnDateDataGridViewTextBoxColumn";
            txnDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siteIdDataGridViewTextBoxColumn
            // 
            siteIdDataGridViewTextBoxColumn.DataPropertyName = "SiteId";
            siteIdDataGridViewTextBoxColumn.HeaderText = "SiteId";
            siteIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            siteIdDataGridViewTextBoxColumn.Name = "siteIdDataGridViewTextBoxColumn";
            siteIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deliveryIdDataGridViewTextBoxColumn
            // 
            deliveryIdDataGridViewTextBoxColumn.DataPropertyName = "DeliveryId";
            deliveryIdDataGridViewTextBoxColumn.HeaderText = "DeliveryId";
            deliveryIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            deliveryIdDataGridViewTextBoxColumn.Name = "deliveryIdDataGridViewTextBoxColumn";
            deliveryIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // txnauditBindingSource
            // 
            txnauditBindingSource.DataSource = typeof(Models.Txnaudit);
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1299, 747);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 16;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // AuditRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 831);
            Controls.Add(btnExit);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AuditRecords";
            Text = "Bullseye Inventory Management Systems - Audit Records";
            Load += AuditRecords_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txnauditBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource txnauditBindingSource;
        private DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn txnIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn txnTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn txnDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn siteIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryIdDataGridViewTextBoxColumn;
        private Button btnExit;
    }
}