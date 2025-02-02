using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullseyeDesktopApp
{
    public partial class EditItem : Form
    {
        Item selectedItem;
        String picFolderPath = StaticHelpers.UserSession.PictureDirectoryPath; // From static variables current users path to pic folder


        public EditItem(Item selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }


        //             FORM LOAD
        //
        //
        private void EditItem_Load(object sender, EventArgs e)
        {
            PopulateContent();
            HandleChk();
        }


        //         POPULATE CONTENT
        //
        //
        private void PopulateContent()
        {
            txtID.Text = selectedItem.ItemId.ToString();
            txtSKU.Text = selectedItem.Sku.ToString();
            txtName.Text = selectedItem.Name.ToString();
            txtDescription.Text = selectedItem.Description;
            cmbCategory.Text = selectedItem.Category;
            txtWeight.Text = selectedItem?.Weight.ToString();
            txtCaseSize.Text = selectedItem?.CaseSize.ToString();
            txtCost.Text = selectedItem?.CostPrice.ToString();
            txtRetail.Text = selectedItem?.RetailPrice.ToString();
            txtSupplier.Text = selectedItem?.SupplierId.ToString();
            txtNotes.Text = selectedItem?.Notes;
            chkActive.Checked = selectedItem?.Active == 1;
            // Trys to load the image from the folder path specified from user path and db file name
            try
            {   // Selected item null check and item image location empty check 
                if (selectedItem != null && !String.IsNullOrEmpty(selectedItem.ImageLocation))
                {
                    string imagePath = Path.Combine(picFolderPath, selectedItem.ImageLocation);

                    // If image is there load it into pic box
                    if (File.Exists(imagePath))
                    {
                        picItem.Image = Image.FromFile(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error loading image" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //         CHANGE PICTURE
        //
        // Changes picture and updates file name in db
        private void btnChangePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = picFolderPath;
            ofd.Title = "Select a picture";
            ofd.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.wmf;*.emf";

            if (Directory.Exists(picFolderPath) && ofd.ShowDialog() == DialogResult.OK)
            {
                string picPath = ofd.FileName;
                string fileName = Path.GetFileName(picPath);

                // Query to ssave pic filename
                try
                {
                    using (var context = new BullseyeContext())
                    {
                        //Attach user in static class to context for updating, then update picture field and refresh page
                        if (selectedItem != null)
                        {
                            context.Items.Attach(selectedItem);

                            selectedItem.ImageLocation = fileName;

                            context.SaveChanges();

                            PopulateContent();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                }
            }
        }


        //           SAVE BUTTON
        //
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    context.Items.Attach(selectedItem);

                    selectedItem.Description = txtDescription.Text;
                    selectedItem.Notes = txtNotes.Text;
                    selectedItem.Active = (sbyte)(chkActive.Checked ? 1 : 0);

                    context.SaveChanges();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //           EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //          CHECK CHANGED 
        //
        //
        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            HandleChk();
        }
        private void HandleChk()
        {
            chkActive.ForeColor = chkActive.Checked ? Color.Green : Color.Red;
            chkActive.Text = chkActive.Checked ? "Active" : "Deactive";
        }
    }
}
