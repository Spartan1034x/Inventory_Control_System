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
    public partial class Main : Form
    {
        //           EMPLOYEE TAB
        //
        //   REFRESH CLICK
        private void btnAdminEmployeesRefresh_Click(object sender, EventArgs e)
        {
            // Enables add button is user is admin
            if (StaticHelpers.UserSession.CurrentUser != null && StaticHelpers.UserSession.CurrentUser.PositionId == 9999)
                btnAdminEmployeeAdd.Enabled = true;
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


        //   FORM RESIZE
        private void tabctrlAdminUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeEmployeeTab();

        }
        // Resizes form and dgv depending on selection
        private void ResizeEmployeeTab()
        {
            var selection = tabctrlAdminUsers.SelectedTab;

            this.Size = (selection == tabAdminUsersEmployees) ? new Size(1550, 850) : new Size(1350, 850);
            dgvEmployees.Size = (selection == tabAdminUsersEmployees) ? new Size(1425, 426) : new Size(1225, 426);
        }

        //    Selection changed dgv to enable buttons if permissions allow
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (StaticHelpers.UserSession.CurrentUser != null && StaticHelpers.UserSession.CurrentUser.PositionId == 9999 && dgvEmployees.SelectedRows.Count > 0)
            {
                btnAdminEmployeeDelete.Enabled = true;
                btnAdminEmployeeEdit.Enabled = true;
            }
        }

        //    DELETE USER
        //
        //
        private void btnAdminEmployeeDelete_Click(object sender, EventArgs e)
        {
            // If a row is selected find employee from db matching selected one and change active to 0
            if (dgvEmployees.SelectedRows.Count > 0) {
                Employee employee = StaticHelpers.DBOperations.FindEmployee(Convert.ToInt32(dgvEmployees.SelectedCells[0].Value));
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


        //     ADD USER BUTTON
        //
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


        //   EDIT USER BUTTON
        //
        //
        private void btnAdminEmployeeEdit_Click(object sender, EventArgs e)
        {
            Employee employee = StaticHelpers.DBOperations.FindEmployee(Convert.ToInt32(dgvEmployees.SelectedCells[0].Value));
            if (employee.EmployeeId != 0) // If an actual employee was found
            {
                StaticHelpers.UserSession.SelectedUser = employee; // Sets selected user to user selected
                ShowEditForm(false);
            }
            else
                MessageBox.Show("User is already deactivated, or not found in DB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }
}
