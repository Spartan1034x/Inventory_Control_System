using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BullseyeDesktopApp
{
    public partial class AddEditLocation : Form
    {
        bool Add;

        Models.Site SelectedSite = new Models.Site();

        public AddEditLocation(bool add)
        {
            InitializeComponent();
            Add = add;
        }


        //           FORM LOAD
        //
        //
        private void AddEditLocation_Load(object sender, EventArgs e)
        {
            SelectedSite = StaticHelpers.UserSession.SelectedLocation ?? new Models.Site(); // Set local var to selected site
            
            PopulateLabels();

            PopulateCmbs();

            PopulateEditData();

            lblAdd.Visible = Add; // Labels for add or edit
            lblEdit.Visible = !Add;

            this.Text = Add ? "Add Location" : "Edit Location"; // Form text for add or edit

            txtLoc.Focus();

        }


        //                POPULATE EDIT DATA
        //
        // Populates inputs with data from selected location
        private void PopulateEditData()
        {
            txtID.Text = Add ? "Auto Generated" : SelectedSite.SiteId.ToString();
            
            if (!Add) // If edit 
            {
                txtLoc.Text = SelectedSite.SiteName;
                txtAddress.Text = SelectedSite.Address;
                txtCity.Text = SelectedSite.City;
                cmbProv.SelectedItem = SelectedSite.ProvinceId;
                cmbCountry.SelectedItem = SelectedSite.Country;
                mtxtPostal.Text = SelectedSite.PostalCode;
                mtxtPhone.Text = SelectedSite.Phone;

                DayOfWeek dayEnum = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), SelectedSite.DayOfWeek, true); // Need to parse and check enum vs cmb as that is whats stored not satring
                cmbDeliveryDay.SelectedItem = dayEnum;

                nudDistance.Value = SelectedSite.DistanceFromWh;
                txtNotes.Text = SelectedSite.Notes;


            }
        }



        //                 POPULATE COMBO BOXES
        //
        //
        private void PopulateCmbs()
        {
            // Days of week cmb
            cmbDeliveryDay.DataSource = Enum.GetValues(typeof(DayOfWeek));
            cmbDeliveryDay.SelectedItem = DayOfWeek.Monday;

            // Province cmb
            List<String> provCodes = new List<string>() { "AB", "BC", "MB", "NB", "NL", "NT", "NS", "NU", "ON", "PE", "QC", "SK", "YT", "US" };
            cmbProv.DataSource = provCodes;
            cmbProv.SelectedItem = "NB";

            // Site types
            List<String> sites = new List<string>() { "Warehouse", "Retail", "Office" };
            cmbSiteType.DataSource = sites;
            cmbSiteType.SelectedItem = "Retail";

            // Countries
            List<string> countries = new List<string>
                {
                    "United States", "Canada", "United Kingdom", "Germany", "France",
                    "Italy", "Spain", "Australia", "Japan", "China",
                    "India", "Brazil", "Mexico", "Russia", "South Korea",
                    "Netherlands", "Sweden", "Switzerland", "Argentina", "South Africa",
                    "Turkey", "Saudi Arabia", "United Arab Emirates", "Indonesia", "Thailand",
                    "Vietnam", "Malaysia", "Philippines", "Egypt", "Pakistan",
                    "Bangladesh", "Nigeria", "Colombia", "Poland", "Chile",
                    "Belgium", "Austria", "Denmark", "Norway", "Finland"
                };
            countries.Sort();
            cmbCountry.DataSource = countries;
            cmbCountry.SelectedItem = "Canada";
        }


        //                  POPULATE LABELS
        //
        // Populates labels with user data from static class
        private void PopulateLabels()
        {
            lblUser.Text = StaticHelpers.UserSession.CurrentUser?.Username ?? ""; //If null empty string
            lblUser.ForeColor = Color.Red;

            lblLocation.Text = StaticHelpers.UserSession.UserLocation ?? "";
            lblLocation.ForeColor = Color.Red;

        }


        //              EXIT CLICK
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //              SAVE CLICK
        //
        //
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) // If data is good
            {
                if (Add) // ADD SAVE
                {
                    Models.Site newLoc = new Models.Site();

                    newLoc.SiteName = txtLoc.Text;
                    newLoc.Address = txtAddress.Text;
                    newLoc.City = txtCity.Text;
                    newLoc.ProvinceId = cmbProv.SelectedValue?.ToString() ?? "";
                    newLoc.Country = cmbCountry.SelectedValue?.ToString() ?? "";
                    newLoc.PostalCode = mtxtPostal.Text.Replace(" ", "").ToUpper(); // Removes middle space, uppercases for db
                    newLoc.Phone = mtxtPhone.Text; // ExcludePromptAndLiterals set at design time so extra chars not included just digits
                    newLoc.DayOfWeek = cmbDeliveryDay.SelectedValue?.ToString()?.ToUpper() ?? "";
                    newLoc.DistanceFromWh = (int)nudDistance.Value;
                    newLoc.Notes = txtNotes.Text;
                    newLoc.Active = (sbyte)(chkActive.Checked ? 1 : 0);

                    DBCall(newLoc);

                }
                else // EDIT SAVE
                {
                    // Get all input from user and update selected location
                    SelectedSite.SiteName = txtLoc.Text;
                    SelectedSite.Address = txtAddress.Text;
                    SelectedSite.City = txtCity.Text;
                    SelectedSite.ProvinceId = cmbProv.SelectedValue?.ToString() ?? "";
                    SelectedSite.Country = cmbCountry.SelectedValue?.ToString() ?? "";
                    SelectedSite.PostalCode = mtxtPostal.Text.Replace(" ", "").ToUpper(); // Removes middle space, uppercases for db
                    SelectedSite.Phone = mtxtPhone.Text; // ExcludePromptAndLiterals set at design time so extra chars not included just digits
                    SelectedSite.DayOfWeek = cmbDeliveryDay.SelectedValue?.ToString()?.ToUpper() ?? "";
                    SelectedSite.DistanceFromWh = (int)nudDistance.Value;
                    SelectedSite.Notes = txtNotes.Text;
                    SelectedSite.Active = (sbyte)(chkActive.Checked ? 1 : 0);

                    DBCall(SelectedSite);

                }
            }
        }


        //             DATABASE CALL
        //
        // Receives a site depending on wether add or update makes required DB call
        private void DBCall(Models.Site loc)
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    if (!Add) // EDIT 
                    {
                        context.Update(loc);
                        context.SaveChanges(); // Save
                    }
                    else // ADD
                    {
                        context.Sites.Add(loc);
                        context.SaveChanges();
                    }

                    this.Close(); // And close
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //                VALIDATE DATA
        //
        // Returns true if all data is good
        private bool ValidateInput()
        {
            // True if any input (except notes) is empty
            bool emptyField = txtLoc.Text == String.Empty || txtAddress.Text == String.Empty || txtCity.Text == String.Empty;

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
    }
}
