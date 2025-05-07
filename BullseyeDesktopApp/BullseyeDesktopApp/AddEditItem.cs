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
    public partial class AddEditItem : Form
    {
        Item selectedItem;
        String picFolderPath = StaticHelpers.UserSession.PictureDirectoryPath; // From static variables current users path to pic folder


        public AddEditItem(Item selectedItem)
        {
            InitializeComponent();
            this.selectedItem = selectedItem;
        }


        //             FORM LOAD
        //
        //
        private void EditItem_Load(object sender, EventArgs e)
        {
            PopulateCmbs();

            if (StaticHelpers.UserSession.AddItem)
            {
                this.Text = "Add Item";
                txtID.Text = "Auto Generated";
            }
            else
            {
                this.Text = "Edit Item";
                PopulateContent();
            }
            
            HandleChk();
        }


        //         POPULATE CONTENT
        //
        //
        private void PopulateContent()
        {

            cmbSupplierID.SelectedValue = selectedItem.SupplierId;
            cmbCategory.SelectedValue = selectedItem.Category;

            txtID.Text = selectedItem.ItemId.ToString();
            txtSKU.Text = selectedItem.Sku.ToString();
            txtName.Text = selectedItem.Name.ToString();
            txtDescription.Text = selectedItem.Description;
            nudWeight.Value = (int)selectedItem.Weight;
            nudCaseSize.Value = (int)selectedItem.CaseSize;
            nudCost.Value = selectedItem.CostPrice;
            nudPrice.Value = selectedItem.RetailPrice;
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

        private void PopulateCmbs()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var suppliers = context.Suppliers
                        .Select(s => new { SupplierId = s.SupplierId, SupplierName = (s.SupplierId + " - " + s.Name) })
                        .ToList();

                    if (suppliers.Any())
                    {
                        cmbSupplierID.DataSource = suppliers;
                        cmbSupplierID.DisplayMember = "SupplierName";
                        cmbSupplierID.ValueMember = "SupplierId";
                    }

                    var categories = context.Categories
                        .Select(c => new { Name = c.CategoryName })
                        .ToList();

                    if (categories.Any())
                    {
                        cmbCategory.DataSource = categories;
                        cmbCategory.DisplayMember = "Name";
                        cmbCategory.ValueMember = "Name";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error (Supplier Load)");
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

                            picItem.Image = Image.FromFile(picPath);
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
            if (StaticHelpers.UserSession.AddItem)
            {
                Item newItem = new Item
                {
                    Name = txtName.Text,
                    Sku = GenerateSKU(),
                    Description = txtDescription.Text,
                    Category = cmbCategory.SelectedValue.ToString(),
                    SupplierId = (int)cmbSupplierID.SelectedValue,
                    CaseSize = (int)nudCaseSize.Value,
                    Weight = nudWeight.Value,
                    CostPrice = nudCost.Value,
                    RetailPrice = nudPrice.Value,
                    Notes = txtNotes.Text,
                    Active = (sbyte)(chkActive.Checked ? 1 : 0)
                };
                try
                {
                    using (var context = new BullseyeContext())
                    {
                        context.Items.Add(newItem);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error (Add Item)");
                }
            }
            else { 
                try
                {
                    using (var context = new BullseyeContext())
                    {
                        context.Items.Attach(selectedItem);

                        selectedItem.Name = txtName.Text;
                        selectedItem.Description = txtDescription.Text;
                        selectedItem.Category = cmbCategory.SelectedValue.ToString();
                        selectedItem.SupplierId = (int)cmbSupplierID.SelectedValue;
                        selectedItem.CaseSize = (int)nudCaseSize.Value;
                        selectedItem.Weight = nudWeight.Value;
                        selectedItem.CostPrice = nudCost.Value;
                        selectedItem.RetailPrice = nudPrice.Value;
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
        }


        //            GENERATE SKU
        //
        // Starts at 10000 and increments until a unique SKU is found, returns null if error occurs
        private string GenerateSKU()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var skus = new HashSet<string>(context.Items.Select(i => i.Sku).ToList());

                    int startSKU = 10000;
                    string newSKU = "";

                    do
                    {
                        newSKU = startSKU.ToString();
                        startSKU++;

                    } while (skus.Contains(newSKU));

                    return newSKU;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
                return null;
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
