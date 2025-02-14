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
        private static int loginAttemptsRemaining = 3;

        public LogIn()
        {
            InitializeComponent();
        }


        private void LogIn_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin; //Sets enter button to login
            try
            {
                context = new BullseyeContext(); //Instatiates context
                LoadContextData(); // Loads employee context
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error!");
            }
            StaticHelpers.UserSession.CurrentUser = null; // Wipes employee session variable, sets to null
        }


        //
        //Loads context data
        private void LoadContextData()
        {
            context.Employees.Load();
        }


        //
        // Queries the db using linq and EF to check password and username against db, if it doesnt match displays error if match logs in and goes to main page
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = context.Employees.Include(p => p.Position).Include(s => s.Site).FirstOrDefault(e => e.Username == username);
            StaticHelpers.UserSession.CurrentUser = user;

            if (user == null && loginAttemptsRemaining != 0) //USER NOT FOUND
            {
                loginAttemptsRemaining--;
                MessageBox.Show($"Username and/or Password incorrect!\nYou have {loginAttemptsRemaining} attempts" +
                    $" left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (user == null && loginAttemptsRemaining == 0) // USER NOT FOUND NO ATTEMPTS REMAINING
            {
                MessageBox.Show("You are out of log in attempts", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user.Locked == 1) //USER IS LOCKED
            {
                MessageBox.Show($"Your account has been locked because of too many incorrect login attempts. Please " +
                    $"contact your Administrator at admin@bullseye.ca for assistance", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user.Active == 0) //USER IS INACTIVE
            {
                MessageBox.Show($"Invalid username and/or password. Please contact your Administrator" +
                    $" admin@bullseye.ca for assistance", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // PASSWORDS MATCH
                if (StaticHelpers.PasswordHelper.VerifyPassword(user.Password, password))
                {
                    loginAttemptsRemaining = 3; // Resets attempts
                    StaticHelpers.UserSession.CurrentUser = user; // Sets user session var to user logged in

                    if (user.FirstInsert == true) //Users first log in must change password
                        OpenResetPassword();

                    Main form = new Main();
                    form.Show();
                    this.Hide();
                }
                else // PASSWORD DOES NOT MATCH
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
        // Shows forgot password form
        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenResetPassword();

        }
        private static void OpenResetPassword()
        {
            ResetPass form = new ResetPass();
            form.ShowDialog();
        }


        //
        // Exit button closes the App
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //
        //Closes the context as the page ends
        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }

        //            PASSWORD HASH ALL
        //
        // Hashes all passwords in the db
        private void btnHashAll_Click_1(object sender, EventArgs e)
        {
            BullseyeContext context = new BullseyeContext();
            var employees = context.Employees.ToList();

            foreach (var employee in employees)
            {
                employee.Password = StaticHelpers.PasswordHelper.HashPassword(employee.Password);
            }

            context.SaveChanges();
            MessageBox.Show("PAsswords hashed");
            context.Dispose();
        }
    }
}
