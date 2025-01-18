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
            HideAllTabs();
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
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEmployees.Font.FontFamily, 14, FontStyle.Bold);
            dgvEmployees.AutoResizeColumns();
        }


        //           SHOW TABS
        //
        // Shows tabs depending on users permissions
        private void ShowTabs()
        {
            int permissionLevel = StaticHelpers.UserSession.CurrentUser?.PositionId ?? -1;

            //Admin
            if (permissionLevel == 9999)
            {
                tabctrlMain.TabPages.Add(tabAdmin);
                // Manually resize form for splash admin page
                ResizeEmployeeTab();
            }
        }
        //
        // Hides all Tabs
        private void HideAllTabs()
        {
            foreach (TabPage tab in tabctrlMain.TabPages.Cast<TabPage>().ToList())
            {
                tabctrlMain.TabPages.Remove(tab);
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
        private void Logout(object sender, EventArgs e)
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
        private void CheckConnection(object sender, EventArgs e)
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

    }
}
