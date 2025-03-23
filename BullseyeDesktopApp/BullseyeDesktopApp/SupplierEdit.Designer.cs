namespace BullseyeDesktopApp
{
    partial class SupplierEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierEdit));
            picLogo = new PictureBox();
            lblMain = new Label();
            label1 = new Label();
            btnExit = new Button();
            btnSave = new Button();
            txtID = new TextBox();
            cmbProvince = new ComboBox();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            cmbCountry = new ComboBox();
            txtContact = new TextBox();
            txtNotes = new TextBox();
            mtxtPhone = new MaskedTextBox();
            mtxtPostal = new MaskedTextBox();
            chkActive = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Top;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, -1);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 10;
            picLogo.TabStop = false;
            // 
            // lblMain
            // 
            lblMain.Anchor = AnchorStyles.Top;
            lblMain.AutoSize = true;
            lblMain.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMain.Location = new Point(171, 9);
            lblMain.Name = "lblMain";
            lblMain.Size = new Size(192, 41);
            lblMain.TabIndex = 11;
            lblMain.Text = "Edit Supplier";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 51;
            label1.Text = "Supplier ID:";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(327, 684);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 12;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(147, 684);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(116, 102);
            txtID.Name = "txtID";
            txtID.Size = new Size(143, 27);
            txtID.TabIndex = 0;
            // 
            // cmbProvince
            // 
            cmbProvince.FormattingEnabled = true;
            cmbProvince.Location = new Point(116, 329);
            cmbProvince.Name = "cmbProvince";
            cmbProvince.Size = new Size(143, 28);
            cmbProvince.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(116, 159);
            txtName.Name = "txtName";
            txtName.Size = new Size(363, 27);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 162);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 72;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 504);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 73;
            label3.Text = "Notes:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 333);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 74;
            label4.Text = "Province:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(284, 390);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 75;
            label5.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(284, 333);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 76;
            label6.Text = "Country:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 447);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 77;
            label7.Text = "Contact:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 390);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 78;
            label8.Text = "Postal:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 276);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 79;
            label9.Text = "City:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 219);
            label10.Name = "label10";
            label10.Size = new Size(65, 20);
            label10.TabIndex = 80;
            label10.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(116, 216);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(363, 27);
            txtAddress.TabIndex = 3;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(116, 273);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(363, 27);
            txtCity.TabIndex = 4;
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(351, 329);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(143, 28);
            cmbCountry.TabIndex = 6;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(116, 444);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(363, 27);
            txtContact.TabIndex = 9;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(116, 504);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(363, 140);
            txtNotes.TabIndex = 10;
            // 
            // mtxtPhone
            // 
            mtxtPhone.Location = new Point(351, 387);
            mtxtPhone.Mask = "(000) 000-0000";
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Size = new Size(143, 27);
            mtxtPhone.TabIndex = 8;
            mtxtPhone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtxtPostal
            // 
            mtxtPostal.Location = new Point(116, 387);
            mtxtPostal.Mask = "L0L 0L0";
            mtxtPostal.Name = "mtxtPostal";
            mtxtPostal.Size = new Size(77, 27);
            mtxtPostal.TabIndex = 7;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Location = new Point(327, 103);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(72, 24);
            chkActive.TabIndex = 1;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // SupplierEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 745);
            Controls.Add(chkActive);
            Controls.Add(mtxtPhone);
            Controls.Add(mtxtPostal);
            Controls.Add(txtNotes);
            Controls.Add(txtContact);
            Controls.Add(cmbCountry);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(cmbProvince);
            Controls.Add(txtID);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(lblMain);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SupplierEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Supplier Edit";
            FormClosing += SupplierEdit_FormClosing;
            Load += SupplierEdit_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblMain;
        private Label label1;
        private Button btnExit;
        private Button btnSave;
        private TextBox txtID;
        private ComboBox cmbProvince;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtAddress;
        private TextBox txtCity;
        private ComboBox cmbCountry;
        private TextBox txtContact;
        private TextBox txtNotes;
        private MaskedTextBox mtxtPhone;
        private MaskedTextBox mtxtPostal;
        private CheckBox chkActive;
    }
}