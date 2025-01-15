using BullseyeDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BullseyeDesktopApp
{
    public partial class LogIn : Form
    {
        BullseyeContext context;
        Employee employee;
        private static int loginAttemptsRemaining = 3;

        public LogIn()
        {
            InitializeComponent();
        }


        private void LogIn_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin; //Sets enter button to login
            context = new BullseyeContext(); //Instatiates context
            LoadContextData();
        }


        //
        //Loads context data
        private void LoadContextData()
        {
            context.Employees.Load();
        }


        //
        //
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = context.Employees.FirstOrDefault(e => e.Username == username);
            employee = user;

            if (user == null) //User not found
            {
                MessageBox.Show($"Username and/or Password incorrect!\nYou have {loginAttemptsRemaining} attempts" +
                    $" left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginAttemptsRemaining--;
            }
            else if (user.Locked == 1) //User is already locked
            {
                MessageBox.Show($"Your account has been locked because of too many incorrect login attempts. Please " +
                    $"contact your Administrator at admin@bullseye.ca for assistance", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user.Active == 0) //User has become inactive
            {
                MessageBox.Show($"Invalid username and/or password. Please contact your Administrator" +
                    $" admin@bullseye.ca for assistance", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //If password matches use hashing
                if (StaticHelpers.Hasher.VerifyPassword(user.Password, password))
                {
                    MessageBox.Show("Log in success");
                    loginAttemptsRemaining = 3;
                }
                else //Invalid password
                {
                    loginAttemptsRemaining--;

                    if (loginAttemptsRemaining > 0)
                    {
                        MessageBox.Show($"Username and/or Password incorrect!\nYou have {loginAttemptsRemaining} attempts" +
                            $" left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Lock the account after 3 failed attempts
                        user.Locked = 1;
                        context.SaveChanges();
                        MessageBox.Show($"Your account has been locked due to too many failed attempts. Please contact" +
                            $" admin@bullseye.ca for assistance.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }


        //
        //
        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = (employee == null) ? string.Empty : employee.Username;
            ResetPass form = new ResetPass(username);
            form.ShowDialog();

        }


        //
        // Exit button closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //
        //Hashes all passwords in the db for me only
        private void btnHashAll_Click(object sender, EventArgs e)
        {
            /* var employees = context.Employees.ToList();

            foreach (var employee in employees)
            {
                employee.Password = StaticHelpers.Hasher.HashPassword(employee.Password);
            }

            context.SaveChanges();
            MessageBox.Show("PAsswords hashed"); */
        }


        //
        //Closes the context as the page ends
        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
