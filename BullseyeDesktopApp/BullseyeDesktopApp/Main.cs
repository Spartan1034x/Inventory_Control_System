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
using BullseyeDesktopApp.StaticHelpers;

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
            //HideAllTabs(tabctrlMain); // Hides all main tabs
            HideAllTabs(tabctrlAdminUsers); // Hides all admin tabs
            ShowTabs();
            PopulateLabels();
            FormatDGVs();

            // If user is a warehouse manager start the timer for order notis
            if (UserSession.CurrentUser.PositionId == 3)
            {
                DBOperations.StartOrderNotificationTimer();
            }
        }


        //                FORMAT DGVs
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


        //                 SHOW TABS
        //
        // Shows tabs depending on users permissions
        private void ShowTabs()
        {
            int permissionLevel = StaticHelpers.UserSession.CurrentUser?.PositionId ?? -1;

            // ADMIN
            if (permissionLevel == 9999)
            {
                // Add employee and permission tab if admin
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersPermissions);
                tabctrlAdminUsers.TabPages.Add(tabAdminItems);

                // Enabled Create Order/Receive/Fulfil Order Button
                btnOrdersCreate.Enabled = true;
                btnOrdersReceive.Enabled = true;
                btnOrdersFulfil.Enabled = true;

                // Enable CRUD buttons
                btnAdminEmployeeDelete.Enabled = true;
                btnAdminEmployeeEdit.Enabled = true;
                btnAdminEmployeeAdd.Enabled = true;

            }
            // REGIONAL MANAGER
            else if (permissionLevel == 1)
            {
                // Remove required tabs

                // Show allowed Admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminItems);

            }
            // FINICIAL MANAGER
            else if (permissionLevel == 2)
            {
                // Remove required tabs

                // Show allowed Admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminItems);
            }
            // WAREHOUSE MANAGER
            else if (permissionLevel == 3)
            {
                // Remove required tabs

                // Show allowed Admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);
                tabctrlAdminUsers.TabPages.Add(tabAdminItems);

                // Enabled Create Order/Receive/Fulfil Order Button
                btnOrdersCreate.Enabled = true;
                btnOrdersReceive.Enabled = true;
                btnOrdersFulfil.Enabled = true;

            }
            // STORE MANAGER
            else if (permissionLevel == 4)
            {
                // Remove required tabs

                // Show allowed admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);

                // Enabled Create Order Button
                btnOrdersCreate.Enabled = true;
            }
            // WAREHOUSE WORKER
            else if (permissionLevel == 5)
            {
                // Remove required tabs
                tabctrlMain.TabPages.Remove(tabReports);

                // Show allowed admin tabs
                tabctrlAdminUsers.TabPages.Add(tabAdminUsersEmployees);

                // Show Order fulfil button
                btnOrdersFulfil.Enabled = true;
            }

            // Manually resize form for splash admin page and call populate first dgv
            tabctrlMain.SelectedTab = tabAdmin;
            ResizeEmployeeTab();
            RefreshEmployeesDGV();
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


        //                   LOGOUT TIMER
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


        //                 DB CONNECTION MONITOR
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


        //                 FORM CLOSING
        //
        // Calls logout so final clean up and logout is complete when form is closing
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop Timers on logout
            activityTimer.Stop();
            dbTimer.Stop();
            StaticHelpers.DBOperations.StopOrderTimer();

            LogIn form = new LogIn();
            form.Show();
        }


        //                   EXIT BUTTON
        //
        // Closes form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //                  AUDITS BUTTON
        //
        //
        private void btnViewAudits_Click(object sender, EventArgs e)
        {
            Form audit = new AuditRecords();
            audit.ShowDialog();
        }


        //                 RESET PASSWORD LINK
        //
        //
        private void lnkResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPass form = new ResetPass();
            form.ShowDialog();
        }


        //              TAB MAIN SELECTION CHANGED
        //
        // Resizes form if admin tab is selected or not, Populates DGVs on first selection of tab, shows hides help buttons
        private void tabctrlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHelpIcons();

            var selection = tabctrlMain.SelectedTab;

            // Resizes form is tab main is selected            
            this.Size = (selection == tabAdmin) ? new Size(1550, 850) : new Size(1350, 850);
            if (selection == tabAdmin)
                ResizeEmployeeTab();

            // Default load for orders tab
            if (selection == tabOrders && defaultOrdersLoad)
            {
                PopulateCmbs();
                RefreshOrders();
            }
            // Default load for Inventory tab
            else if (selection == tabInventory && defaultInventoryLoad)
            {
                InitialInventoryPopulation();
            }
        }

        //           Shows help buttons depending on tab selected, callled from selection changed events
        private void ShowHelpIcons()
        {
            var selection = tabctrlMain.SelectedTab;
            var adminSelection = tabctrlAdminUsers.SelectedTab;

            // Show hide help buttons based on tab selection
            picHelpOrders.Visible = selection == tabOrders; // Orders help
            picHelpItems.Visible = selection == tabAdmin && adminSelection == tabAdminItems; // Items help
            picHelpInventory.Visible = selection == tabInventory; // Inventory help
        }

    }
}
