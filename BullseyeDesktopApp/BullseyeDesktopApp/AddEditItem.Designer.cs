namespace BullseyeDesktopApp
{
    partial class AddEditItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditItem));
            txtSKU = new TextBox();
            label10 = new Label();
            btnExit = new Button();
            btnSave = new Button();
            chkActive = new CheckBox();
            cmbCategory = new ComboBox();
            txtDescription = new TextBox();
            txtName = new TextBox();
            txtID = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            picLogo = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            label6 = new Label();
            txtNotes = new TextBox();
            label11 = new Label();
            label12 = new Label();
            picItem = new PictureBox();
            btnChangePic = new Button();
            nudCaseSize = new NumericUpDown();
            nudCost = new NumericUpDown();
            nudPrice = new NumericUpDown();
            nudWeight = new NumericUpDown();
            cmbSupplierID = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCaseSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).BeginInit();
            SuspendLayout();
            // 
            // txtSKU
            // 
            txtSKU.Enabled = false;
            txtSKU.Location = new Point(445, 105);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(125, 27);
            txtSKU.TabIndex = 68;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(333, 108);
            label10.Name = "label10";
            label10.Size = new Size(39, 20);
            label10.TabIndex = 67;
            label10.Text = "SKU:";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(337, 732);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 66;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(157, 732);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 65;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(263, 38);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(72, 24);
            chkActive.TabIndex = 64;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            chkActive.CheckedChanged += chkActive_CheckedChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(124, 299);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(261, 28);
            cmbCategory.Sorted = true;
            cmbCategory.TabIndex = 62;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(124, 219);
            txtDescription.MaxLength = 255;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(446, 54);
            txtDescription.TabIndex = 59;
            // 
            // txtName
            // 
            txtName.Location = new Point(124, 165);
            txtName.Name = "txtName";
            txtName.Size = new Size(446, 27);
            txtName.TabIndex = 58;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(124, 105);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 57;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 354);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 56;
            label9.Text = "Weight:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 404);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 55;
            label8.Text = "Cost:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 303);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 54;
            label7.Text = "Category:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 225);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 52;
            label5.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 51;
            label4.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 108);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 50;
            label1.Text = "Item ID:";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(1, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(96, 73);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 49;
            picLogo.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 354);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 71;
            label2.Text = "Case Size:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 457);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 77;
            label3.Text = "Supplier ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(333, 404);
            label6.Name = "label6";
            label6.Size = new Size(86, 20);
            label6.TabIndex = 75;
            label6.Text = "Retail Price:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(124, 504);
            txtNotes.MaxLength = 255;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(446, 81);
            txtNotes.TabIndex = 80;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 512);
            label11.Name = "label11";
            label11.Size = new Size(51, 20);
            label11.TabIndex = 79;
            label11.Text = "Notes:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 627);
            label12.Name = "label12";
            label12.Size = new Size(57, 20);
            label12.TabIndex = 81;
            label12.Text = "Picture:";
            // 
            // picItem
            // 
            picItem.BorderStyle = BorderStyle.FixedSingle;
            picItem.Location = new Point(124, 607);
            picItem.Name = "picItem";
            picItem.Size = new Size(125, 104);
            picItem.SizeMode = PictureBoxSizeMode.StretchImage;
            picItem.TabIndex = 82;
            picItem.TabStop = false;
            // 
            // btnChangePic
            // 
            btnChangePic.Location = new Point(281, 644);
            btnChangePic.Name = "btnChangePic";
            btnChangePic.Size = new Size(94, 29);
            btnChangePic.TabIndex = 83;
            btnChangePic.Text = "&Change";
            btnChangePic.UseVisualStyleBackColor = true;
            btnChangePic.Click += btnChangePic_Click;
            // 
            // nudCaseSize
            // 
            nudCaseSize.Location = new Point(425, 354);
            nudCaseSize.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCaseSize.Name = "nudCaseSize";
            nudCaseSize.Size = new Size(125, 27);
            nudCaseSize.TabIndex = 84;
            // 
            // nudCost
            // 
            nudCost.DecimalPlaces = 2;
            nudCost.Location = new Point(124, 401);
            nudCost.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudCost.Name = "nudCost";
            nudCost.Size = new Size(125, 27);
            nudCost.TabIndex = 85;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Location = new Point(425, 404);
            nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(125, 27);
            nudPrice.TabIndex = 86;
            // 
            // nudWeight
            // 
            nudWeight.Location = new Point(124, 351);
            nudWeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudWeight.Name = "nudWeight";
            nudWeight.Size = new Size(125, 27);
            nudWeight.TabIndex = 87;
            // 
            // cmbSupplierID
            // 
            cmbSupplierID.FormattingEnabled = true;
            cmbSupplierID.Location = new Point(124, 453);
            cmbSupplierID.Name = "cmbSupplierID";
            cmbSupplierID.Size = new Size(211, 28);
            cmbSupplierID.TabIndex = 88;
            // 
            // AddEditItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 778);
            Controls.Add(cmbSupplierID);
            Controls.Add(nudWeight);
            Controls.Add(nudPrice);
            Controls.Add(nudCost);
            Controls.Add(nudCaseSize);
            Controls.Add(btnChangePic);
            Controls.Add(picItem);
            Controls.Add(label12);
            Controls.Add(txtNotes);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(txtSKU);
            Controls.Add(label10);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(chkActive);
            Controls.Add(cmbCategory);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(txtID);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddEditItem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Item";
            Load += EditItem_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCaseSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCost).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSKU;
        private Label label10;
        private Button btnExit;
        private Button btnSave;
        private CheckBox chkActive;
        private ComboBox cmbCategory;
        private TextBox txtDescription;
        private TextBox txtName;
        private TextBox txtID;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label1;
        private PictureBox picLogo;
        private Label label2;
        private Label label3;
        private Label label6;
        private TextBox txtNotes;
        private Label label11;
        private Label label12;
        private PictureBox picItem;
        private Button btnChangePic;
        private NumericUpDown nudCaseSize;
        private NumericUpDown nudCost;
        private NumericUpDown nudPrice;
        private NumericUpDown nudWeight;
        private ComboBox cmbSupplierID;
    }
}