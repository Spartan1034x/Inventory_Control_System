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
            else
                RefreshItemsDGV(20);

        }


        //                FORM RESIZE
        //
        // Resizes form and dgv depending on selection
        private void ResizeEmployeeTab()
        {
            var selection = tabctrlAdminUsers.SelectedTab;

            this.Size = (selection == tabAdminUsersEmployees) ? new Size(1550, 850) : new Size(1350, 850);
            dgvEmployees.Size = (selection == tabAdminUsersEmployees) ? new Size(1425, 426) : new Size(1225, 426);
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
