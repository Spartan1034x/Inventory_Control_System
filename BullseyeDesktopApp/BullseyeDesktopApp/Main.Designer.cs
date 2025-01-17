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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            tabctrlMain = new TabControl();
            tabOrders = new TabPage();
            tabInventory = new TabPage();
            tabLoss = new TabPage();
            tabReports = new TabPage();
            tabAdmin = new TabPage();
            tabctrlAdminUsers = new TabControl();
            tabAdminUsersEmployees = new TabPage();
            btnAdminEmployeesRefresh = new Button();
            btnAdminEmployeeDelete = new Button();
            btnAdminEmployeeEdit = new Button();
            btnAdminEmployeeAdd = new Button();
            dgvEmployees = new DataGridView();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            activeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            siteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeBindingSource = new BindingSource(components);
            tabAdminUsersPermissions = new TabPage();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            picLogo = new PictureBox();
            lblStatus = new Label();
            label4 = new Label();
            btnExit = new Button();
            lblLocation = new Label();
            lblUser = new Label();
            tabctrlMain.SuspendLayout();
            tabAdmin.SuspendLayout();
            tabctrlAdminUsers.SuspendLayout();
            tabAdminUsersEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // tabctrlMain
            // 
            tabctrlMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabctrlMain.Controls.Add(tabOrders);
            tabctrlMain.Controls.Add(tabInventory);
            tabctrlMain.Controls.Add(tabLoss);
            tabctrlMain.Controls.Add(tabReports);
            tabctrlMain.Controls.Add(tabAdmin);
            tabctrlMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabctrlMain.Location = new Point(41, 111);
            tabctrlMain.Name = "tabctrlMain";
            tabctrlMain.SelectedIndex = 0;
            tabctrlMain.Size = new Size(1240, 581);
            tabctrlMain.TabIndex = 13;
            // 
            // tabOrders
            // 
            tabOrders.Location = new Point(4, 37);
            tabOrders.Name = "tabOrders";
            tabOrders.Padding = new Padding(3);
            tabOrders.Size = new Size(1232, 540);
            tabOrders.TabIndex = 0;
            tabOrders.Text = "Orders";
            tabOrders.UseVisualStyleBackColor = true;
            // 
            // tabInventory
            // 
            tabInventory.Location = new Point(4, 37);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new Padding(3);
            tabInventory.Size = new Size(1232, 540);
            tabInventory.TabIndex = 1;
            tabInventory.Text = "Inventory";
            tabInventory.UseVisualStyleBackColor = true;
            // 
            // tabLoss
            // 
            tabLoss.Location = new Point(4, 37);
            tabLoss.Name = "tabLoss";
            tabLoss.Size = new Size(1232, 540);
            tabLoss.TabIndex = 2;
            tabLoss.Text = "Loss / Return";
            tabLoss.UseVisualStyleBackColor = true;
            // 
            // tabReports
            // 
            tabReports.Location = new Point(4, 37);
            tabReports.Name = "tabReports";
            tabReports.Size = new Size(1232, 540);
            tabReports.TabIndex = 3;
            tabReports.Text = "Reports";
            tabReports.UseVisualStyleBackColor = true;
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(tabctrlAdminUsers);
            tabAdmin.Location = new Point(4, 37);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Size = new Size(1232, 540);
            tabAdmin.TabIndex = 4;
            tabAdmin.Text = "Admin";
            tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabctrlAdminUsers
            // 
            tabctrlAdminUsers.Controls.Add(tabAdminUsersEmployees);
            tabctrlAdminUsers.Controls.Add(tabAdminUsersPermissions);
            tabctrlAdminUsers.Dock = DockStyle.Fill;
            tabctrlAdminUsers.Location = new Point(0, 0);
            tabctrlAdminUsers.MinimumSize = new Size(1119, 466);
            tabctrlAdminUsers.Multiline = true;
            tabctrlAdminUsers.Name = "tabctrlAdminUsers";
            tabctrlAdminUsers.SelectedIndex = 0;
            tabctrlAdminUsers.Size = new Size(1232, 540);
            tabctrlAdminUsers.TabIndex = 0;
            tabctrlAdminUsers.SelectedIndexChanged += tabctrlAdminUsers_SelectedIndexChanged;
            // 
            // tabAdminUsersEmployees
            // 
            tabAdminUsersEmployees.Controls.Add(btnAdminEmployeesRefresh);
            tabAdminUsersEmployees.Controls.Add(btnAdminEmployeeDelete);
            tabAdminUsersEmployees.Controls.Add(btnAdminEmployeeEdit);
            tabAdminUsersEmployees.Controls.Add(btnAdminEmployeeAdd);
            tabAdminUsersEmployees.Controls.Add(dgvEmployees);
            tabAdminUsersEmployees.Location = new Point(4, 37);
            tabAdminUsersEmployees.Name = "tabAdminUsersEmployees";
            tabAdminUsersEmployees.Padding = new Padding(3);
            tabAdminUsersEmployees.Size = new Size(1224, 499);
            tabAdminUsersEmployees.TabIndex = 0;
            tabAdminUsersEmployees.Text = "Employees";
            tabAdminUsersEmployees.UseVisualStyleBackColor = true;
            // 
            // btnAdminEmployeesRefresh
            // 
            btnAdminEmployeesRefresh.Anchor = AnchorStyles.Bottom;
            btnAdminEmployeesRefresh.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminEmployeesRefresh.Location = new Point(78, 448);
            btnAdminEmployeesRefresh.Name = "btnAdminEmployeesRefresh";
            btnAdminEmployeesRefresh.Size = new Size(114, 29);
            btnAdminEmployeesRefresh.TabIndex = 4;
            btnAdminEmployeesRefresh.Text = "Refresh";
            btnAdminEmployeesRefresh.UseVisualStyleBackColor = true;
            btnAdminEmployeesRefresh.Click += btnAdminEmployeesRefresh_Click;
            // 
            // btnAdminEmployeeDelete
            // 
            btnAdminEmployeeDelete.Anchor = AnchorStyles.Bottom;
            btnAdminEmployeeDelete.Enabled = false;
            btnAdminEmployeeDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminEmployeeDelete.Location = new Point(1023, 448);
            btnAdminEmployeeDelete.Name = "btnAdminEmployeeDelete";
            btnAdminEmployeeDelete.Size = new Size(114, 29);
            btnAdminEmployeeDelete.TabIndex = 3;
            btnAdminEmployeeDelete.Text = "Delete";
            btnAdminEmployeeDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdminEmployeeEdit
            // 
            btnAdminEmployeeEdit.Anchor = AnchorStyles.Bottom;
            btnAdminEmployeeEdit.Enabled = false;
            btnAdminEmployeeEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminEmployeeEdit.Location = new Point(708, 448);
            btnAdminEmployeeEdit.Name = "btnAdminEmployeeEdit";
            btnAdminEmployeeEdit.Size = new Size(114, 29);
            btnAdminEmployeeEdit.TabIndex = 2;
            btnAdminEmployeeEdit.Text = "Edit";
            btnAdminEmployeeEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdminEmployeeAdd
            // 
            btnAdminEmployeeAdd.Anchor = AnchorStyles.Bottom;
            btnAdminEmployeeAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminEmployeeAdd.Location = new Point(393, 448);
            btnAdminEmployeeAdd.Name = "btnAdminEmployeeAdd";
            btnAdminEmployeeAdd.Size = new Size(114, 29);
            btnAdminEmployeeAdd.TabIndex = 1;
            btnAdminEmployeeAdd.Text = "Add New";
            btnAdminEmployeeAdd.UseVisualStyleBackColor = true;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn, usernameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, activeDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn, siteDataGridViewTextBoxColumn });
            dgvEmployees.DataSource = employeeBindingSource;
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.MinimumSize = new Size(1111, 352);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(1225, 426);
            dgvEmployees.TabIndex = 0;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "ID";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            usernameDataGridViewTextBoxColumn.MinimumWidth = 6;
            usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            usernameDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // activeDataGridViewTextBoxColumn
            // 
            activeDataGridViewTextBoxColumn.DataPropertyName = "Active";
            activeDataGridViewTextBoxColumn.HeaderText = "Active";
            activeDataGridViewTextBoxColumn.MinimumWidth = 6;
            activeDataGridViewTextBoxColumn.Name = "activeDataGridViewTextBoxColumn";
            activeDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Position";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // siteDataGridViewTextBoxColumn
            // 
            siteDataGridViewTextBoxColumn.DataPropertyName = "Site";
            siteDataGridViewTextBoxColumn.HeaderText = "Site";
            siteDataGridViewTextBoxColumn.MinimumWidth = 6;
            siteDataGridViewTextBoxColumn.Name = "siteDataGridViewTextBoxColumn";
            siteDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeBindingSource
            // 
            employeeBindingSource.DataSource = typeof(Models.Employee);
            // 
            // tabAdminUsersPermissions
            // 
            tabAdminUsersPermissions.Location = new Point(4, 29);
            tabAdminUsersPermissions.Name = "tabAdminUsersPermissions";
            tabAdminUsersPermissions.Padding = new Padding(3);
            tabAdminUsersPermissions.Size = new Size(1224, 507);
            tabAdminUsersPermissions.TabIndex = 1;
            tabAdminUsersPermissions.Text = "Permissions";
            tabAdminUsersPermissions.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(874, 33);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 12;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(902, 9);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 11;
            label2.Text = "User:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(473, 12);
            label1.Name = "label1";
            label1.Size = new Size(182, 41);
            label1.TabIndex = 10;
            label1.Text = "Bullseye ICS";
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Top;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(552, 762);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Unknown";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(427, 762);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 16;
            label4.Text = "Database Status:";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(1151, 718);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 43);
            btnExit.TabIndex = 15;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(949, 33);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 18;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(949, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 19;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 803);
            Controls.Add(lblUser);
            Controls.Add(lblLocation);
            Controls.Add(tabctrlMain);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(btnExit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1350, 750);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            tabctrlMain.ResumeLayout(false);
            tabAdmin.ResumeLayout(false);
            tabctrlAdminUsers.ResumeLayout(false);
            tabAdminUsersEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabctrlMain;
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
        private Label lblLocation;
        private Label lblUser;
        private TabControl tabctrlAdminUsers;
        private TabPage tabAdminUsersEmployees;
        private TabPage tabAdminUsersPermissions;
        private DataGridView dgvEmployees;
        private Button btnAdminEmployeeDelete;
        private Button btnAdminEmployeeEdit;
        private Button btnAdminEmployeeAdd;
        private Button btnAdminEmployeesRefresh;
        private BindingSource employeeBindingSource;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn activeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn siteDataGridViewTextBoxColumn;
    }
}