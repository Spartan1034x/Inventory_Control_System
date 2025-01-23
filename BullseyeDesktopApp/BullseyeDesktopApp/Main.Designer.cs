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
            grpAdminPermissionEdit = new GroupBox();
            lblAdminPermissionsEditUser = new Label();
            label5 = new Label();
            btnAdminPermissionsEditCancel = new Button();
            btnAdminPermissionsEditSave = new Button();
            cmbAdminPermissionsEditPositions = new ComboBox();
            label9 = new Label();
            btnAdminPermissionEdit = new Button();
            btnAdminPermissionRefresh = new Button();
            dgvPermissions = new DataGridView();
            posnBindingSource = new BindingSource(components);
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            picLogo = new PictureBox();
            lblStatus = new Label();
            label4 = new Label();
            btnExit = new Button();
            lblLocation = new Label();
            lblUser = new Label();
            btnHashAll = new Button();
            btnViewAudits = new Button();
            tabctrlMain.SuspendLayout();
            tabAdmin.SuspendLayout();
            tabctrlAdminUsers.SuspendLayout();
            tabAdminUsersEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeBindingSource).BeginInit();
            tabAdminUsersPermissions.SuspendLayout();
            grpAdminPermissionEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)posnBindingSource).BeginInit();
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
            btnAdminEmployeesRefresh.Text = "&Refresh";
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
            btnAdminEmployeeDelete.Text = "&Deactivate";
            btnAdminEmployeeDelete.UseVisualStyleBackColor = true;
            btnAdminEmployeeDelete.Click += btnAdminEmployeeDelete_Click;
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
            btnAdminEmployeeEdit.Text = "&Edit";
            btnAdminEmployeeEdit.UseVisualStyleBackColor = true;
            btnAdminEmployeeEdit.Click += btnAdminEmployeeEdit_Click;
            // 
            // btnAdminEmployeeAdd
            // 
            btnAdminEmployeeAdd.Anchor = AnchorStyles.Bottom;
            btnAdminEmployeeAdd.Enabled = false;
            btnAdminEmployeeAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminEmployeeAdd.Location = new Point(393, 448);
            btnAdminEmployeeAdd.Name = "btnAdminEmployeeAdd";
            btnAdminEmployeeAdd.Size = new Size(114, 29);
            btnAdminEmployeeAdd.TabIndex = 1;
            btnAdminEmployeeAdd.Text = "&Add New";
            btnAdminEmployeeAdd.UseVisualStyleBackColor = true;
            btnAdminEmployeeAdd.Click += btnAdminEmployeeAdd_Click;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToResizeColumns = false;
            dgvEmployees.AllowUserToResizeRows = false;
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
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            tabAdminUsersPermissions.Controls.Add(grpAdminPermissionEdit);
            tabAdminUsersPermissions.Controls.Add(btnAdminPermissionEdit);
            tabAdminUsersPermissions.Controls.Add(btnAdminPermissionRefresh);
            tabAdminUsersPermissions.Controls.Add(dgvPermissions);
            tabAdminUsersPermissions.Location = new Point(4, 29);
            tabAdminUsersPermissions.Name = "tabAdminUsersPermissions";
            tabAdminUsersPermissions.Padding = new Padding(3);
            tabAdminUsersPermissions.Size = new Size(1224, 507);
            tabAdminUsersPermissions.TabIndex = 1;
            tabAdminUsersPermissions.Text = "Permissions";
            tabAdminUsersPermissions.UseVisualStyleBackColor = true;
            // 
            // grpAdminPermissionEdit
            // 
            grpAdminPermissionEdit.BackColor = Color.MistyRose;
            grpAdminPermissionEdit.Controls.Add(lblAdminPermissionsEditUser);
            grpAdminPermissionEdit.Controls.Add(label5);
            grpAdminPermissionEdit.Controls.Add(btnAdminPermissionsEditCancel);
            grpAdminPermissionEdit.Controls.Add(btnAdminPermissionsEditSave);
            grpAdminPermissionEdit.Controls.Add(cmbAdminPermissionsEditPositions);
            grpAdminPermissionEdit.Controls.Add(label9);
            grpAdminPermissionEdit.Enabled = false;
            grpAdminPermissionEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpAdminPermissionEdit.Location = new Point(853, 19);
            grpAdminPermissionEdit.Name = "grpAdminPermissionEdit";
            grpAdminPermissionEdit.Size = new Size(323, 282);
            grpAdminPermissionEdit.TabIndex = 7;
            grpAdminPermissionEdit.TabStop = false;
            grpAdminPermissionEdit.Text = "Edit Position";
            // 
            // lblAdminPermissionsEditUser
            // 
            lblAdminPermissionsEditUser.AutoSize = true;
            lblAdminPermissionsEditUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdminPermissionsEditUser.ForeColor = Color.FromArgb(0, 192, 0);
            lblAdminPermissionsEditUser.Location = new Point(89, 48);
            lblAdminPermissionsEditUser.Name = "lblAdminPermissionsEditUser";
            lblAdminPermissionsEditUser.Size = new Size(37, 28);
            lblAdminPermissionsEditUser.TabIndex = 43;
            lblAdminPermissionsEditUser.Text = "Nil";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 48);
            label5.Name = "label5";
            label5.Size = new Size(55, 28);
            label5.TabIndex = 42;
            label5.Text = "User:";
            // 
            // btnAdminPermissionsEditCancel
            // 
            btnAdminPermissionsEditCancel.Location = new Point(195, 220);
            btnAdminPermissionsEditCancel.Name = "btnAdminPermissionsEditCancel";
            btnAdminPermissionsEditCancel.Size = new Size(94, 29);
            btnAdminPermissionsEditCancel.TabIndex = 41;
            btnAdminPermissionsEditCancel.Text = "&Cancel";
            btnAdminPermissionsEditCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdminPermissionsEditSave
            // 
            btnAdminPermissionsEditSave.Location = new Point(28, 220);
            btnAdminPermissionsEditSave.Name = "btnAdminPermissionsEditSave";
            btnAdminPermissionsEditSave.Size = new Size(94, 29);
            btnAdminPermissionsEditSave.TabIndex = 40;
            btnAdminPermissionsEditSave.Text = "&Save";
            btnAdminPermissionsEditSave.UseVisualStyleBackColor = true;
            btnAdminPermissionsEditSave.Click += btnAdminPermissionsEditSave_Click;
            // 
            // cmbAdminPermissionsEditPositions
            // 
            cmbAdminPermissionsEditPositions.FormattingEnabled = true;
            cmbAdminPermissionsEditPositions.Location = new Point(28, 153);
            cmbAdminPermissionsEditPositions.Name = "cmbAdminPermissionsEditPositions";
            cmbAdminPermissionsEditPositions.Size = new Size(261, 31);
            cmbAdminPermissionsEditPositions.Sorted = true;
            cmbAdminPermissionsEditPositions.TabIndex = 39;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(115, 103);
            label9.Name = "label9";
            label9.Size = new Size(86, 28);
            label9.TabIndex = 38;
            label9.Text = "Position:";
            // 
            // btnAdminPermissionEdit
            // 
            btnAdminPermissionEdit.Anchor = AnchorStyles.Bottom;
            btnAdminPermissionEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminPermissionEdit.Location = new Point(633, 446);
            btnAdminPermissionEdit.Name = "btnAdminPermissionEdit";
            btnAdminPermissionEdit.Size = new Size(114, 29);
            btnAdminPermissionEdit.TabIndex = 6;
            btnAdminPermissionEdit.Text = "&Edit";
            btnAdminPermissionEdit.UseVisualStyleBackColor = true;
            btnAdminPermissionEdit.Click += btnAdminPermissionEdit_Click;
            // 
            // btnAdminPermissionRefresh
            // 
            btnAdminPermissionRefresh.Anchor = AnchorStyles.Bottom;
            btnAdminPermissionRefresh.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdminPermissionRefresh.Location = new Point(222, 446);
            btnAdminPermissionRefresh.Name = "btnAdminPermissionRefresh";
            btnAdminPermissionRefresh.Size = new Size(114, 29);
            btnAdminPermissionRefresh.TabIndex = 5;
            btnAdminPermissionRefresh.Text = "&Refresh";
            btnAdminPermissionRefresh.UseVisualStyleBackColor = true;
            btnAdminPermissionRefresh.Click += btnAdminPermissionRefresh_Click;
            // 
            // dgvPermissions
            // 
            dgvPermissions.AllowUserToAddRows = false;
            dgvPermissions.AllowUserToDeleteRows = false;
            dgvPermissions.AllowUserToResizeColumns = false;
            dgvPermissions.AllowUserToResizeRows = false;
            dgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermissions.Location = new Point(134, 6);
            dgvPermissions.Name = "dgvPermissions";
            dgvPermissions.ReadOnly = true;
            dgvPermissions.RowHeadersVisible = false;
            dgvPermissions.RowHeadersWidth = 51;
            dgvPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermissions.Size = new Size(665, 398);
            dgvPermissions.TabIndex = 0;
            // 
            // posnBindingSource
            // 
            posnBindingSource.DataSource = typeof(Models.Posn);
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(902, 33);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 12;
            label3.Text = "Location:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(930, 9);
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
            label1.Location = new Point(529, 12);
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
            lblStatus.Location = new Point(676, 762);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(70, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Unknown";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Location = new Point(551, 762);
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
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(977, 33);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(0, 20);
            lblLocation.TabIndex = 18;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(977, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 20);
            lblUser.TabIndex = 19;
            // 
            // btnHashAll
            // 
            btnHashAll.Anchor = AnchorStyles.Bottom;
            btnHashAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHashAll.Location = new Point(559, 698);
            btnHashAll.Name = "btnHashAll";
            btnHashAll.Size = new Size(122, 43);
            btnHashAll.TabIndex = 20;
            btnHashAll.Text = "Hash All";
            btnHashAll.UseVisualStyleBackColor = true;
            btnHashAll.Visible = false;
            btnHashAll.Click += btnHashAll_Click;
            // 
            // btnViewAudits
            // 
            btnViewAudits.Anchor = AnchorStyles.Bottom;
            btnViewAudits.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewAudits.Location = new Point(45, 718);
            btnViewAudits.Name = "btnViewAudits";
            btnViewAudits.Size = new Size(122, 43);
            btnViewAudits.TabIndex = 21;
            btnViewAudits.Text = "&View Audits";
            btnViewAudits.UseVisualStyleBackColor = true;
            btnViewAudits.Click += btnViewAudits_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 803);
            Controls.Add(btnViewAudits);
            Controls.Add(btnHashAll);
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
            tabAdminUsersPermissions.ResumeLayout(false);
            grpAdminPermissionEdit.ResumeLayout(false);
            grpAdminPermissionEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)posnBindingSource).EndInit();
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
        private DataGridView dgvPermissions;
        private BindingSource posnBindingSource;
        private Button btnHashAll;
        private Button btnAdminPermissionRefresh;
        private Button btnAdminPermissionEdit;
        private GroupBox grpAdminPermissionEdit;
        private Button btnAdminPermissionsEditCancel;
        private Button btnAdminPermissionsEditSave;
        private ComboBox cmbAdminPermissionsEditPositions;
        private Label label9;
        private Label lblAdminPermissionsEditUser;
        private Label label5;
        private Button btnViewAudits;
    }
}