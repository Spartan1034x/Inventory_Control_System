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
using System.Timers;
using MySqlConnector;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BullseyeDesktopApp
{
    public partial class Main : Form
    {
        // Timer variables
        private System.Windows.Forms.Timer dbTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer activityTimer = new System.Windows.Forms.Timer();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeLogoutTimer();
            StartConnectionMonitor();
            UpdateConnectionStatus();
            MonitorActivity();
            HideAllTabs(tabctrlMain); // Hides all main tabs
            HideAllTabs(tabctrlAdminUsers); // Hides all admin tabs
            ShowTabs();
            PopulateLabels();
            FormatDGVs();
        }


        //          FORMAT DGVs
        //
        //
        private void FormatDGVs()
        {
            //Admin employee dgv
            Font dgvHeader = new Font(dgvEmployees.Font.FontFamily, 14, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = dgvHeader;
            dgvEmployees.AutoResizeColumns();
            dgvPermissions.ColumnHeadersDefaultCellStyle.Font = dgvHeader;
        }


        //           SHOW TABS
        //
        // Shows tabs depending on users permissions
        private void ShowTabs()
        {
            int permissionLevel = StaticHelpers.UserSession.CurrentUser?.PositionId ?? -1;

            // Enables or disables admin buttons depending on user
            bool admin = permissionLevel == 9999;
            btnAdminEmployeeDelete.Enabled = admin;
            btnAdminEmployeeEdit.Enabled = admin;
            btnAdminEmployeeAdd.Enabled = admin;

            // ADMIN
            if (permissionLevel == 9999)
            {
                //Add all tabs
                tabctrlMain.TabPages.Add(tabAdmin);
                tabctrlMain.TabPages.Add(tabOrders);
                tabctrlMain.TabPages.Add(tabReports);
                tabctrlMain.TabPages.Add(tabInventory);
                tabctrlMain.TabPages.Add(tabLoss);

                // Add employee and permission tab if admin
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersPermissions);

                // Manually resize form for splash admin page and call populate first dgv
                ResizeEmployeeTab();
                RefreshEmployeesDGV();
            }
            // WAREHOUSE MANAGER
            else if (permissionLevel == 3)
            {
                // Add tabs for main control
                tabctrlMain.TabPages.Add(tabAdmin);

                // Show allowed Admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminItems);
            }
            // STORE MANAGER
            else if (permissionLevel == 4)
            {
                //Add all tabs
                tabctrlMain.TabPages.Add(tabAdmin);
                tabctrlMain.TabPages.Add(tabOrders);
                tabctrlMain.TabPages.Add(tabReports);
                tabctrlMain.TabPages.Add(tabInventory);
                tabctrlMain.TabPages.Add(tabLoss);

                // Show allowed admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersPermissions);
            }
        }
        //
        // Hides all Tabs
        private void HideAllTabs(TabControl tabControl)
        {
            // Removes all tabs from the received tabCtrl
            foreach (TabPage tab in tabControl.TabPages.Cast<TabPage>().ToList())
            {
                tabControl.TabPages.Remove(tab);
            }
        }


        //           POPULATE LABELS
        //
        // Populates labels with user data from static class
        private void PopulateLabels()
        {
            lblUser.Text = StaticHelpers.UserSession.CurrentUser?.Username ?? ""; //If null empty string
            lblUser.ForeColor = Color.Red;

            lblLocation.Text = StaticHelpers.UserSession.UserLocation ?? "";
            lblLocation.ForeColor = Color.Red;

        }


        //           LOGOUT TIMER
        //
        // Starts 20 minute timer then logs user out changebale in future
        private void InitializeLogoutTimer()
        {
            activityTimer.Interval = (int)TimeSpan.FromMinutes(20).TotalMilliseconds;
            activityTimer.Tick += Logout;
        }
        //
        // Monitors for user input if input is detected resets the timer
        private void MonitorActivity()
        {
            // Event       Event Handler    Function To Call
            this.MouseMove += (s, e) => ResetLogoutTimer();
            this.KeyPress += (s, e) => ResetLogoutTimer();
        }
        //
        // Resets the logout timer
        private void ResetLogoutTimer()
        {
            activityTimer.Stop();
            activityTimer.Start();
        }
        //Closes form
        private void Logout(object? sender, EventArgs e)
        {
            this.Close();
        }


        //             DB CONNECTION MONITOR
        //
        // Timer that calls update conn status method for every tick of the dbTimer, every 30 seconds
        private void StartConnectionMonitor()
        {
            dbTimer.Interval = 30000; // Interval at every 30 seconds
            dbTimer.Tick += CheckConnection; //Assigns event handler to every tick
            dbTimer.Start(); // Restarts dbTimer
        }
        //
        // Event handler for tick, calls update conn status
        private void CheckConnection(object? sender, EventArgs e)
        {
            UpdateConnectionStatus();
        }
        //
        //Attempts to make a connection with the database, displays connection status to user
        private void UpdateConnectionStatus()
        {
            try
            {
                using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["BullseyeDB"].ConnectionString))
                {
                    con.Open();
                    lblStatus.Text = "Connected";
                    lblStatus.ForeColor = Color.Green;
                }
            }
            catch
            {
                lblStatus.Text = "Disconnected";
                lblStatus.ForeColor = Color.Red;
            }
        }


        //             FORM CLOSING
        //
        // Calls logout so final clean up and logout is complete when form is closing
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();
            dbTimer.Stop();
            LogIn form = new LogIn();
            form.Show();
        }


        //            EXIT BUTTON
        //
        // Closes form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //          AUDITS BUTTON
        //
        //
        private void btnViewAudits_Click(object sender, EventArgs e)
        {
            Form audit = new AuditRecords();
            audit.ShowDialog();
        }


        //          RESET PASSWORD LINK
        //
        //
        private void lnkResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPass form = new ResetPass();
            form.ShowDialog();
        }

    }
}
