using BullseyeDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullseyeDesktopApp
{
    public partial class LogIn : Form
    {
        BullseyeContext context;
        Employee employee;

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

        //Loads context data
        private void LoadContextData()
        {
            context.Employees.Load();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    }
}
