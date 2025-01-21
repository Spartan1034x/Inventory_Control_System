using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class DBOperations
    {

        //       FIND SELECTED EMPLOYEE
        //
        // Receives id searches for matching employee, returns empty employee if not found
        public static Employee FindEmployeeByID(int id)
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    Employee employee = context.Employees.FirstOrDefault(x => x.EmployeeId == id) ?? new Employee();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
                return new Employee();
            }
        }
        //
        // Receives username searches for matching employee, returns empty employee if not found
        public static Employee FindEmployeeByUsername(string username)
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    Employee employee = context.Employees.FirstOrDefault(x => x.Username == username) ?? new Employee();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
                return new Employee();
            }
        }
    }
}
