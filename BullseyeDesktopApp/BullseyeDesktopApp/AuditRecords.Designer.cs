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
            txnauditBindingSource = new BindingSource(components);
            btnExit = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtNotes = new TextBox();
            lblCreateDate = new Label();
            lblDeliveryID = new Label();
            lblSiteID = new Label();
            lblTxnDate = new Label();
            lblStaus = new Label();
            lblTxnType = new Label();
            lblEmployeeID = new Label();
            lblTxnID = new Label();
            lblTxnAuditID = new Label();
            TxnAuditId = new DataGridViewTextBoxColumn();
            TxnId = new DataGridViewTextBoxColumn();
            txnTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            txnDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            label1.Location = new Point(647, 9);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TxnAuditId, TxnId, txnTypeDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, txnDateDataGridViewTextBoxColumn });
            dataGridView1.DataSource = txnauditBindingSource;
            dataGridView1.Location = new Point(35, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(821, 560);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // txnauditBindingSource
            // 
            txnauditBindingSource.DataSource = typeof(Models.Txnaudit);
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(690, 763);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 16;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(972, 223);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 17;
            label2.Text = "Txn ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(925, 163);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 18;
            label3.Text = "Created Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(932, 103);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 19;
            label4.Text = "Txn Audit ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(928, 283);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 20;
            label5.Text = "Employee ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(952, 343);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 21;
            label6.Text = "Txn Type: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(973, 403);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 22;
            label7.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(955, 463);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 23;
            label8.Text = "Txn Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(940, 583);
            label9.Name = "label9";
            label9.Size = new Size(85, 20);
            label9.TabIndex = 24;
            label9.Text = "Delivery ID:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(969, 523);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 25;
            label10.Text = "Site ID:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(974, 643);
            label11.Name = "label11";
            label11.Size = new Size(51, 20);
            label11.TabIndex = 26;
            label11.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Enabled = false;
            txtNotes.Location = new Point(1050, 643);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(391, 177);
            txtNotes.TabIndex = 27;
            // 
            // lblCreateDate
            // 
            lblCreateDate.AutoSize = true;
            lblCreateDate.ForeColor = Color.Blue;
            lblCreateDate.Location = new Point(1050, 163);
            lblCreateDate.Name = "lblCreateDate";
            lblCreateDate.Size = new Size(39, 20);
            lblCreateDate.TabIndex = 28;
            lblCreateDate.Text = "data";
            // 
            // lblDeliveryID
            // 
            lblDeliveryID.AutoSize = true;
            lblDeliveryID.ForeColor = Color.Blue;
            lblDeliveryID.Location = new Point(1050, 583);
            lblDeliveryID.Name = "lblDeliveryID";
            lblDeliveryID.Size = new Size(39, 20);
            lblDeliveryID.TabIndex = 29;
            lblDeliveryID.Text = "data";
            // 
            // lblSiteID
            // 
            lblSiteID.AutoSize = true;
            lblSiteID.ForeColor = Color.Blue;
            lblSiteID.Location = new Point(1050, 523);
            lblSiteID.Name = "lblSiteID";
            lblSiteID.Size = new Size(39, 20);
            lblSiteID.TabIndex = 30;
            lblSiteID.Text = "data";
            // 
            // lblTxnDate
            // 
            lblTxnDate.AutoSize = true;
            lblTxnDate.ForeColor = Color.Blue;
            lblTxnDate.Location = new Point(1050, 463);
            lblTxnDate.Name = "lblTxnDate";
            lblTxnDate.Size = new Size(39, 20);
            lblTxnDate.TabIndex = 31;
            lblTxnDate.Text = "data";
            // 
            // lblStaus
            // 
            lblStaus.AutoSize = true;
            lblStaus.ForeColor = Color.Blue;
            lblStaus.Location = new Point(1050, 403);
            lblStaus.Name = "lblStaus";
            lblStaus.Size = new Size(39, 20);
            lblStaus.TabIndex = 32;
            lblStaus.Text = "data";
            // 
            // lblTxnType
            // 
            lblTxnType.AutoSize = true;
            lblTxnType.ForeColor = Color.Blue;
            lblTxnType.Location = new Point(1050, 343);
            lblTxnType.Name = "lblTxnType";
            lblTxnType.Size = new Size(39, 20);
            lblTxnType.TabIndex = 33;
            lblTxnType.Text = "data";
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.ForeColor = Color.Blue;
            lblEmployeeID.Location = new Point(1050, 283);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(39, 20);
            lblEmployeeID.TabIndex = 34;
            lblEmployeeID.Text = "data";
            // 
            // lblTxnID
            // 
            lblTxnID.AutoSize = true;
            lblTxnID.ForeColor = Color.Blue;
            lblTxnID.Location = new Point(1050, 223);
            lblTxnID.Name = "lblTxnID";
            lblTxnID.Size = new Size(39, 20);
            lblTxnID.TabIndex = 35;
            lblTxnID.Text = "data";
            // 
            // lblTxnAuditID
            // 
            lblTxnAuditID.AutoSize = true;
            lblTxnAuditID.ForeColor = Color.Blue;
            lblTxnAuditID.Location = new Point(1050, 103);
            lblTxnAuditID.Name = "lblTxnAuditID";
            lblTxnAuditID.Size = new Size(39, 20);
            lblTxnAuditID.TabIndex = 36;
            lblTxnAuditID.Text = "data";
            // 
            // TxnAuditId
            // 
            TxnAuditId.DataPropertyName = "TxnAuditId";
            TxnAuditId.HeaderText = "TxnAuditId";
            TxnAuditId.MinimumWidth = 6;
            TxnAuditId.Name = "TxnAuditId";
            TxnAuditId.ReadOnly = true;
            // 
            // TxnId
            // 
            TxnId.DataPropertyName = "TxnId";
            TxnId.HeaderText = "TxnId";
            TxnId.MinimumWidth = 6;
            TxnId.Name = "TxnId";
            TxnId.ReadOnly = true;
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
            // AuditRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 831);
            Controls.Add(lblTxnAuditID);
            Controls.Add(lblTxnID);
            Controls.Add(lblEmployeeID);
            Controls.Add(lblTxnType);
            Controls.Add(lblStaus);
            Controls.Add(lblTxnDate);
            Controls.Add(lblSiteID);
            Controls.Add(lblDeliveryID);
            Controls.Add(lblCreateDate);
            Controls.Add(txtNotes);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
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
        private Button btnExit;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtNotes;
        private Label lblCreateDate;
        private Label lblDeliveryID;
        private Label lblSiteID;
        private Label lblTxnDate;
        private Label lblStaus;
        private Label lblTxnType;
        private Label lblEmployeeID;
        private Label lblTxnID;
        private Label lblTxnAuditID;
        private DataGridViewTextBoxColumn TxnAuditId;
        private DataGridViewTextBoxColumn TxnId;
        private DataGridViewTextBoxColumn txnTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn txnDateDataGridViewTextBoxColumn;
    }
}