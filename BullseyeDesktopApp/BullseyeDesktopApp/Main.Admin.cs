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
        //            PASSWORD HASH ALL
        //
        // Hashes all passwords in the db
        private void btnHashAll_Click(object sender, EventArgs e)
        {
            /*
             BullseyeContext context = new BullseyeContext();
             var employees = context.Employees.ToList();

             foreach (var employee in employees)
             {
                 employee.Password = StaticHelpers.PasswordHelper.HashPassword(employee.Password);
             }

             context.SaveChanges();
             MessageBox.Show("PAsswords hashed"); 
            context.Dispose(); */
        }


        //           SELECTED INDEX GHANGED TABS
        //
        // Refreshes dgv when tab is selected
        private void tabctrlAdminUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeEmployeeTab();
            // Refreshes dgv when selected tab
            if (tabctrlAdminUsers.SelectedTab == tabAdminUsersEmployees)
                RefreshEmployeesDGV();
            else
                RefreshPermissionDGV();

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
                    using (var context = new BullseyeContext())
                    {
                        if (employee.EmployeeId != 0 && employee.Active != 0)
                        {
                            employee.Active = 0;
                            context.SaveChanges();
                            MessageBox.Show("User Deactivated", "Success");
                        }
                        else
                            MessageBox.Show("User is already deactivated, or not found in DB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private static void ShowEditForm(bool add)
        {
            //Ensures user trying to access edit/add form is admin
            if (StaticHelpers.UserSession.CurrentUser != null && StaticHelpers.UserSession.CurrentUser.PositionId == 9999)
            {
                Form userForm = new AddEditUser(add);
                userForm.ShowDialog();
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
        private void btnAdminPermissionEdit_Click(object sender, EventArgs e)
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
                                    if (cmbAdminPermissionsEditPositions.Items.Count == 0) // If cmb is empty populate
                                        context.Posns.ToList().ForEach(pos => cmbAdminPermissionsEditPositions.Items.Add(pos));
                                    lblAdminPermissionsEditUser.Text = username;                                   
                                }
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
                            MessageBox.Show("Users position has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //           RESET PERMISSIONS EDIT
        private void ResetPermissionsEdit()
        {
            lblAdminPermissionsEditUser.Text = "Nil";
            cmbAdminPermissionsEditPositions.SelectedIndex = -1;
            grpAdminPermissionEdit.Enabled = false;
        }

    }
}
