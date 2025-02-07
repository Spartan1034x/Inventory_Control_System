namespace BullseyeDesktopApp
{
    partial class CreateOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrder));
            lblUser = new Label();
            lblLocation = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvOrders = new DataGridView();
            label1 = new Label();
            grpOrderType = new GroupBox();
            radEmergency = new RadioButton();
            radRegular = new RadioButton();
            lblEmergency = new Label();
            btnOrdersRefresh = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            btnSubmit = new Button();
            btnExit = new Button();
            label4 = new Label();
            txtSearch = new TextBox();
            lblStandard = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            grpOrderType.SuspendLayout();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(1013, 13);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 23;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(1013, 37);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 22;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(938, 37);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 21;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(966, 13);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 20;
            label2.Text = "User:";
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 126);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1308, 516);
            dgvOrders.TabIndex = 24;
            dgvOrders.EditingControlShowing += dgvOrders_EditingControlShowing;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(569, 20);
            label1.Name = "label1";
            label1.Size = new Size(194, 41);
            label1.TabIndex = 25;
            label1.Text = "Create Order";
            // 
            // grpOrderType
            // 
            grpOrderType.Controls.Add(radEmergency);
            grpOrderType.Controls.Add(radRegular);
            grpOrderType.Location = new Point(37, 13);
            grpOrderType.Name = "grpOrderType";
            grpOrderType.Size = new Size(177, 92);
            grpOrderType.TabIndex = 26;
            grpOrderType.TabStop = false;
            grpOrderType.Text = "Order Type";
            // 
            // radEmergency
            // 
            radEmergency.AutoSize = true;
            radEmergency.Location = new Point(37, 56);
            radEmergency.Name = "radEmergency";
            radEmergency.Size = new Size(103, 24);
            radEmergency.TabIndex = 1;
            radEmergency.Text = "Emergency";
            radEmergency.UseVisualStyleBackColor = true;
            radEmergency.CheckedChanged += radEmergency_CheckedChanged;
            // 
            // radRegular
            // 
            radRegular.AutoSize = true;
            radRegular.Checked = true;
            radRegular.Location = new Point(37, 26);
            radRegular.Name = "radRegular";
            radRegular.Size = new Size(81, 24);
            radRegular.TabIndex = 0;
            radRegular.TabStop = true;
            radRegular.Text = "Regular";
            radRegular.UseVisualStyleBackColor = true;
            // 
            // lblEmergency
            // 
            lblEmergency.Anchor = AnchorStyles.Top;
            lblEmergency.AutoSize = true;
            lblEmergency.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmergency.ForeColor = Color.Red;
            lblEmergency.Location = new Point(582, 69);
            lblEmergency.Name = "lblEmergency";
            lblEmergency.Size = new Size(169, 41);
            lblEmergency.TabIndex = 27;
            lblEmergency.Text = "Emergency";
            lblEmergency.Visible = false;
            // 
            // btnOrdersRefresh
            // 
            btnOrdersRefresh.Anchor = AnchorStyles.Bottom;
            btnOrdersRefresh.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrdersRefresh.Location = new Point(37, 711);
            btnOrdersRefresh.Name = "btnOrdersRefresh";
            btnOrdersRefresh.Size = new Size(141, 40);
            btnOrdersRefresh.TabIndex = 28;
            btnOrdersRefresh.Text = "&Refresh";
            btnOrdersRefresh.UseVisualStyleBackColor = true;
            btnOrdersRefresh.Click += btnOrdersRefresh_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom;
            btnRemove.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.Location = new Point(913, 713);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(109, 36);
            btnRemove.TabIndex = 29;
            btnRemove.Text = "R&emove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(774, 713);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(109, 36);
            btnAdd.TabIndex = 30;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom;
            btnSubmit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(1052, 713);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(109, 36);
            btnSubmit.TabIndex = 31;
            btnSubmit.Text = "&Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1191, 713);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(109, 36);
            btnExit.TabIndex = 32;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(246, 717);
            label4.Name = "label4";
            label4.Size = new Size(74, 28);
            label4.TabIndex = 33;
            label4.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Bottom;
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(326, 714);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(391, 34);
            txtSearch.TabIndex = 34;
            // 
            // lblStandard
            // 
            lblStandard.Anchor = AnchorStyles.Top;
            lblStandard.AutoSize = true;
            lblStandard.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStandard.ForeColor = Color.Green;
            lblStandard.Location = new Point(596, 69);
            lblStandard.Name = "lblStandard";
            lblStandard.Size = new Size(141, 41);
            lblStandard.TabIndex = 35;
            lblStandard.Text = "Standard";
            // 
            // CreateOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 803);
            Controls.Add(lblStandard);
            Controls.Add(txtSearch);
            Controls.Add(label4);
            Controls.Add(btnExit);
            Controls.Add(btnSubmit);
            Controls.Add(btnAdd);
            Controls.Add(btnRemove);
            Controls.Add(btnOrdersRefresh);
            Controls.Add(lblEmergency);
            Controls.Add(grpOrderType);
            Controls.Add(label1);
            Controls.Add(dgvOrders);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Order";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            grpOrderType.ResumeLayout(false);
            grpOrderType.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblLocation;
        private Label label3;
        private Label label2;
        private DataGridView dgvOrders;
        private Label label1;
        private GroupBox grpOrderType;
        private RadioButton radEmergency;
        private RadioButton radRegular;
        private Label lblEmergency;
        private Button btnOrdersRefresh;
        private Button btnRemove;
        private Button btnAdd;
        private Button btnSubmit;
        private Button btnExit;
        private Label label4;
        private TextBox txtSearch;
        private Label lblStandard;
    }
}