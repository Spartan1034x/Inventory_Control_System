using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullseyeDesktopApp
{
    public partial class SupplierEdit : Form
    {
        bool edit = false;
        bool canClose = true;

        public SupplierEdit(bool edit)
        {
            InitializeComponent();
            this.edit = edit;
        }

        private void SupplierEdit_Load(object sender, EventArgs e)
        {
            lblMain.Text = edit ? "Edit Supplier" : "Add Supplier";
            PopulateInputs();
        }


        //           POPULATE INPUTS
        //
        //
        private void PopulateInputs()
        {
            txtID.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.SupplierId.ToString() : ""; // ID
            txtName.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Name : "";                // Name
            txtAddress.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Address1 : "";         // Address
            txtCity.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.City : "";                // City
            txtContact.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Contact : "";          // Contact
            txtNotes.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Notes : "";              // Notes
            chkActive.Checked = edit ? (StaticHelpers.UserSession.SelectedSupplier?.Active == 1 ? true : false) : true;      // Active
            mtxtPhone.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Phone : "";             // Phone
            mtxtPostal.Text = edit ? StaticHelpers.UserSession.SelectedSupplier?.Postalcode : "";           // Postal

            // Countries
            List<string> countries = StaticHelpers.MiscHelper.countries;
            countries.Sort();
            cmbCountry.DataSource = countries;
            cmbCountry.SelectedItem = edit ? StaticHelpers.UserSession.SelectedSupplier?.Country : "Canada";

            // Province cmb
            cmbProvince.DataSource = StaticHelpers.MiscHelper.provCodes;
            cmbProvince.SelectedItem = edit ? StaticHelpers.UserSession.SelectedSupplier?.Province : "NB";
        }



        //           EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //          SAVE BUTTON
        //
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                canClose = false;
                return;
            }

            if (cmbCountry.SelectedItem == null || cmbProvince.SelectedItem == null)
                return;

            canClose = true;

            if (edit)
            {
                if (StaticHelpers.UserSession.SelectedSupplier == null)
                    return;

                // Update
                using (var context = new BullseyeContext())
                {
                    var supplier = context.Suppliers.Where(s => s.SupplierId == StaticHelpers.UserSession.SelectedSupplier.SupplierId).First();
                    supplier.Name = txtName.Text;
                    supplier.Address1 = txtAddress.Text;
                    supplier.City = txtCity.Text;
                    supplier.Contact = txtContact.Text;
                    supplier.Notes = txtNotes.Text;
                    supplier.Active = (sbyte)(chkActive.Checked ? 1 : 0);
                    supplier.Phone = mtxtPhone.Text;
                    supplier.Postalcode = mtxtPostal.Text.Replace(" ", "").ToUpper();
                    supplier.Country = cmbCountry.SelectedItem.ToString() ?? "";
                    supplier.Province = cmbProvince.SelectedItem.ToString() ?? "";
                    context.SaveChanges();

                    this.Close();
                }
            }
            else
            {
                // Add
                using (var context = new BullseyeContext())
                {
                    Supplier supplier = new Supplier()
                    {
                        Name = txtName.Text,
                        Address1 = txtAddress.Text,
                        City = txtCity.Text,
                        Contact = txtContact.Text,
                        Notes = txtNotes.Text,
                        Active = (sbyte)(chkActive.Checked ? 1 : 0),
                        Phone = mtxtPhone.Text,
                        Postalcode = mtxtPostal.Text.Replace(" ", "").ToUpper(),
                        Country = cmbCountry.SelectedItem.ToString(),
                        Province = cmbProvince.SelectedItem.ToString()
                    };
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();

                    this.Close();
                }
            }
        } // End Save Button



        //                VALIDATE DATA
        //
        // Returns true if all data is good
        private bool ValidateInput()
        {
            // True if any input (except notes) is empty
            bool emptyField = txtAddress.Text == String.Empty || txtCity.Text == String.Empty || txtContact.Text == String.Empty || txtName.Text == String.Empty;

            if (emptyField)
            {
                MessageBox.Show("One or more required inputs are empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!mtxtPhone.MaskCompleted) // Ensure complete phonew number entered
            {
                MessageBox.Show("Please enter complete Phone Number", "Phone Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!mtxtPostal.MaskCompleted) // Ensure complete postal code
            {
                MessageBox.Show("Please enter complete Postal Code", "Postal Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SupplierEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
            }
        }
    }
}
