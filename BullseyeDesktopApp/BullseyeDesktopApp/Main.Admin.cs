using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using MySqlConnector;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using BullseyeDesktopApp.Models;
using BullseyeDesktopApp.Models.DisplayObjects;

namespace BullseyeDesktopApp
{
                                                               // ****   ADMIN TAB   ****
    public partial class Main
    {

        //              ITEMS HELP BUTTON
        //
        //
        private void picHelpItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Double click item to edit\n\u202215 Items shown by default select \"Load All\"" +
                " to see all items", "Items Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //           SELECTED INDEX GHANGED TABS
        //
        // Refreshes dgv when tab is selected
        private void tabctrlAdminUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeEmployeeTab();
            ShowHelpIcons(); // Shows reuired icons

            // Refreshes dgv when selected tab
            if (tabctrlAdminUsers.SelectedTab == tabAdminUsersEmployees)
                RefreshEmployeesDGV();
            else if (tabctrlAdminUsers.SelectedTab == tabAdminUsersPermissions)
                RefreshPermissionDGV();
            else if (tabctrlAdminUsers.SelectedTab == tabAdminItems)
                RefreshItemsDGV(20);
            else if (tabctrlAdminUsers.SelectedTab == tabAdminLocations)
                RefreshLocationsDGV();

        }


        //                FORM RESIZE
        //
        // Resizes form and dgv if Employee or User tab selected in Admin
        private void ResizeEmployeeTab()
        {
            var selection = tabctrlAdminUsers.SelectedTab;

            this.Size = (selection == tabAdminUsersEmployees || selection == tabAdminLocations) ? new Size(1550, 850) : new Size(1350, 850);
            dgvEmployees.Size = (selection == tabAdminUsersEmployees) ? new Size(1425, 426) : new Size(1225, 426);
        }


        //            **** LOCATIONS TAB ****
        //

        List<Site> locations;
        List<LocationDisplay> locDisplay;


        //
        //                 REFRESH CLICK
        private void btnAdminLocationRefresh_Click(object sender, EventArgs e)
        {
            RefreshLocationsDGV();
        }


        //                REFRESH LOCATION DGV
        //
        //
        private void RefreshLocationsDGV()
        {
            // Populate sites
            try
            {
                using (var context = new BullseyeContext())
                {
                    locations = context.Sites.ToList();
                    CreateLocationDisplay(locations);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //            CREATE LOCATION DISPLAY
        //
        //
        private void CreateLocationDisplay(List<Site> locs)
        {
            locDisplay = new List<LocationDisplay>(); // Clear old list

            foreach (var l in locs)
            {
                locDisplay.Add(new LocationDisplay()
                {
                    ID = l.SiteId,
                    Location = l.SiteName,
                    Adress = l.Address,
                    City = l.City,
                    Active = l.Active,
                    Country = l.Country,
                    Prov = l.ProvinceId,
                    Postal = l.PostalCode,
                    Delivery = l.DayOfWeek,
                    Distance = l.DistanceFromWh,
                    Phone = l.Phone,
                    Notes = l.Notes
                });
            }

            dgvLocations.DataSource = new BindingSource() { DataSource = locDisplay };
            
            dgvLocations.AutoResizeColumns();
            dgvLocations.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvLocations.Columns["Notes"].Width = 150;
        }


        //              CELL FORMATING
        //
        //
        private void dgvLocations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formats Distance cell
            if (dgvLocations.Columns[e.ColumnIndex].Name == "Distance" && e.Value is int distance)
            {
                e.Value = $"{distance} km";
                e.FormattingApplied = true;
            }

            // Formats Phone cell
            if (dgvLocations.Columns[e.ColumnIndex].Name == "Phone" && e.Value is string num)
            {
                if (num.Length == 10) {
                    e.Value = $"({num.Substring(0,3)}) {num.Substring(3, 3)}-{num.Substring(6, 4)}";
                    e.FormattingApplied = true;
                }
            }
        }

        //               LOCATION HELP
        //
        //
        private void picAdminLocation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("/u2022Select location to remove or edit/n/u2022Only admin has permissions to Add/Edit/Remove locations", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //             EDIT BUTTON
        //
        //
        private void btnAdminLocationEdit_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count > 0)
            {
                int ID = (int)dgvLocations.SelectedRows[0].Cells[0].Value; // Get selected location ID

                StaticHelpers.UserSession.SelectedLocation = locations.FirstOrDefault(l => l.SiteId == ID); // Set user variable to selected location, found in local location list

                if (StaticHelpers.UserSession.SelectedLocation != null)
                {
                    AddEditLocation frm = new AddEditLocation(false); // Show form add = false
                    frm.ShowDialog();
                    StaticHelpers.UserSession.SelectedLocation = null; // Clear selected location
                    RefreshLocationsDGV(); // Refresh display
                }
                else
                    MessageBox.Show("Error finding matching Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //             ADD BUTTON
        //
        //
        private void btnAdminLocationAdd_Click(object sender, EventArgs e)
        {
            AddEditLocation frm = new AddEditLocation(true); // Show form add = true
            frm.ShowDialog();
            RefreshLocationsDGV(); // Refresh display
        }


        //            REMOVE BUTTON
        //
        //
        private void btnAdminLocationRemove_Click(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count > 0)
            {
                string loc = (string)dgvLocations.SelectedRows[0].Cells[1].Value;

                DialogResult dia = MessageBox.Show($"Are you sure you want to remove {loc} from the database?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dia == DialogResult.Yes) // Remove selected item from db
                {
                    int ID = (int)dgvLocations.SelectedRows[0].Cells[0].Value; // Get selected site ID

                    Site selectedSite = locations.First(l => l.SiteId == ID); // Get selected Site

                    try
                    {
                        using (var context = new BullseyeContext())
                        {
                            context.Sites.Remove(selectedSite); // Remove from context
                            context.SaveChanges(); // Save removal in DB

                            RefreshLocationsDGV(); // Refresh display
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "DB Error");
                    }
                }
            }
        }



        //            **** EMPLOYEE TAB ****
        //
        //
        //                 REFRESH CLICK
        private void btnAdminEmployeesRefresh_Click(object sender, EventArgs e)
        {
            RefreshEmployeesDGV();
        }
        //
        //
        private void RefreshEmployeesDGV()
        {
            try
            {
                using (var context = new BullseyeContext())
                {   //Populates employee dgv
                    var employeeData = context.Employees.Include(e => e.Position).Include(e => e.Site).Select(e => new
                    {
                        e.EmployeeId,
                        e.Username,
                        e.FirstName,
                        e.LastName,
                        e.Email,
                        e.Active,
                        e.Position,
                        e.Site
                    }).ToList();
                    employeeBindingSource.DataSource = employeeData;
                    dgvEmployees.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //                 DELETE USER
        //
        private void btnAdminEmployeeDelete_Click(object sender, EventArgs e)
        {
            // If a row is selected find employee from db matching selected one and change active to 0
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                Employee employee = StaticHelpers.DBOperations.FindEmployeeByID(Convert.ToInt32(dgvEmployees.SelectedCells[0].Value));
                try
                {
                    DialogResult var = MessageBox.Show("Deactivate user: " + employee.Username, "Deactivate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (var == DialogResult.Yes)
                    {
                        using (var context = new BullseyeContext())
                        {
                            if (employee.EmployeeId != 0 && employee.Active != 0)
                            {
                                context.Employees.Attach(employee);
                                employee.Active = 0;
                                context.SaveChanges();
                                RefreshEmployeesDGV();
                            }
                            else
                                MessageBox.Show("User is already deactivated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                }

            }
        }


        //                ADD USER BUTTON
        //
        private void btnAdminEmployeeAdd_Click(object sender, EventArgs e)
        {
            ShowEditForm(true);
        }
        //
        // Shows edit form
        private void ShowEditForm(bool add)
        {
            //Ensures user trying to access edit/add form is admin
            if (StaticHelpers.UserSession.CurrentUser != null && StaticHelpers.UserSession.CurrentUser.PositionId == 9999)
            {
                Form userForm = new AddEditUser(add);
                userForm.ShowDialog();              
                RefreshEmployeesDGV();
                
            }
        }


        //                 EDIT USER BUTTON
        //
        private void btnAdminEmployeeEdit_Click(object sender, EventArgs e)
        {
            Employee employee = StaticHelpers.DBOperations.FindEmployeeByID(Convert.ToInt32(dgvEmployees.SelectedCells[0].Value));
            if (employee.EmployeeId != 0) // If an actual employee was found
            {
                StaticHelpers.UserSession.SelectedUser = employee; // Sets selected user to user selected
                ShowEditForm(false);
            }
            else
                MessageBox.Show("User is already deactivated, or not found in DB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        //            **** PERMISSIONS TAB ****
        //
        //
        //              REFRESH PERMISSION DGV
        //
        private void btnAdminPermissionRefresh_Click(object sender, EventArgs e)
        {
            RefreshPermissionDGV();
        }
        //
        private void RefreshPermissionDGV()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var employeePositions = from emp in context.Employees
                                            join posn in context.Posns on emp.PositionId equals posn.PositionId
                                            select new
                                            {
                                                FirstName = emp.FirstName,
                                                LastName = emp.LastName,
                                                Username = emp.Username,
                                                Position = emp.Position
                                            };
                    dgvPermissions.DataSource = employeePositions.ToList();
                    dgvPermissions.AutoResizeColumns();
                    dgvPermissions.Width = dgvPermissions.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 25;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //             EDIT EMPLOYEE PERMISSIONS
        //
        private void dgvPermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If a row is selected find employee from db matching selected one and change active to 0
            if (dgvPermissions.SelectedRows.Count > 0)
            {
                if (dgvPermissions.SelectedCells.Count > 2) // Ensures more than 2 cells selected
                {
                    string username = dgvPermissions.SelectedCells[2].Value.ToString() ?? "";

                    if (!string.IsNullOrEmpty(username)) // Ensures string is not null or empty
                    {
                        StaticHelpers.UserSession.SelectedUser = StaticHelpers.DBOperations.FindEmployeeByUsername(username); // Set selected user to one selected

                        if (StaticHelpers.UserSession.SelectedUser.EmployeeId != 0) //Ensures an actual employee was returned default is 0 for not found
                        {
                            try
                            {
                                using (var context = new BullseyeContext())
                                {   // Populate data
                                    grpAdminPermissionEdit.Enabled = true;

                                    if (cmbAdminPermissionsEditPositions.Items.Count == 0)// If cmb is empty populate
                                    {
                                        var pos = context.Posns.ToList();
                                        cmbAdminPermissionsEditPositions.Items.AddRange(pos.ToArray());
                                    }
                                    lblAdminPermissionsEditUser.Text = username;
                                }
                                // Select the selected employees position in the cmb
                                cmbAdminPermissionsEditPositions.SelectedItem = cmbAdminPermissionsEditPositions.Items
                                                                                .Cast<Posn>()
                                                                                .FirstOrDefault(p => p.PositionId == StaticHelpers.UserSession.SelectedUser.Position.PositionId);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "DB Error");
                            }
                        }
                    }
                }

            }
        }
        //                   SAVE PERMISSIONS
        //                   
        private void btnAdminPermissionsEditSave_Click(object sender, EventArgs e)
        {
            if (cmbAdminPermissionsEditPositions.SelectedItem != null)
            {
                //Variable for easier coding
                Employee updatedUser = StaticHelpers.UserSession.SelectedUser ?? new Employee();

                try
                {
                    using (var context = new BullseyeContext())
                    {
                        //Attach user in static class to context for updating
                        context.Employees.Attach(updatedUser);

                        Posn position = (Posn)cmbAdminPermissionsEditPositions.SelectedItem;
                        updatedUser.PositionId = position.PositionId;
                        if (context.SaveChanges() == 1)
                        {
                            StaticHelpers.UserSession.SelectedUser = null; // Reset selected user
                            ResetPermissionsEdit();
                            RefreshPermissionDGV();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                }
            }
            else 
                MessageBox.Show("Please select a position", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //
        //              RESET PERMISSIONS EDIT
        private void ResetPermissionsEdit()
        {
            lblAdminPermissionsEditUser.Text = "Nil";
            cmbAdminPermissionsEditPositions.SelectedIndex = -1;
            grpAdminPermissionEdit.Enabled = false;
        }


        //               **** ITEMS TABS *****
        //
        //
        //                 REFRESH ITEMS DGV
        private void RefreshItemsDGV(int itemAmount)
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    if (itemAmount > 0) //
                    {
                        itemBindingSource.DataSource = context.Items.Include(i => i.CategoryNavigation).Take(itemAmount).ToList();
                    }
                    else 
                    {
                        itemBindingSource.DataSource = context.Items.Include(i => i.CategoryNavigation).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB ERROR", ex.Message);
            }

        }


        //
        //       REFRESH ITEMS BUTTON     
        private void btnAdminItemsRefresh_Click(object sender, EventArgs e)
        {
            RefreshItemsDGV(20);
        }


        //
        //     LOAD ALL ITEMS BUTTON
        private void btnAdminItemsLoadAll_Click(object sender, EventArgs e)
        {
            RefreshItemsDGV(0); // 0 Loads all in refresh ftn
        }


        //
        //     DGV ITEM DOUBLE CLICK
        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Item selectedItem = (Item)dgvItems.SelectedRows[0].DataBoundItem;
            Form editItemForm = new EditItem(selectedItem);

            if (editItemForm.ShowDialog() == DialogResult.OK)
            {
                RefreshItemsDGV(20); // Refresh only if changes were made
            }
        }
    }
}
