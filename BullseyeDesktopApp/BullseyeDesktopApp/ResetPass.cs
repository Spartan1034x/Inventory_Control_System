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
    public partial class ResetPass : Form
    {
        private bool newFlag = true;
        private bool conFlag = true;

        public ResetPass(string username)
        {
            InitializeComponent();
            getUsername(username);
            this.AcceptButton = btnConfirm;
        }

        //Sent: string
        //Returned: nil
        //Desc: If username is sent then populates lbl if not txt to enter username appears
        private void getUsername(string username)
        {
            if (username == string.Empty)
            {
                txtUsername.Visible = true;
                txtUsername.PlaceholderText = "jsmith";
                lblUsername.Visible = false;
            }
            else
            {
                lblUsername.Text = username;
            }
        }

        // Shows text by removing the char or hiding password, flips flag
        private void picNew_Click(object sender, EventArgs e)
        {
            txtNew.PasswordChar = newFlag ? '\0' : '*';
            newFlag = !newFlag;
        }

        // Shows text by removing the char or hiding password, flips flag
        private void picConfirm_Click(object sender, EventArgs e)
        {
            txtConfirm.PasswordChar = conFlag ? '\0' : '*';
            conFlag = !conFlag;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pass Reset");
            this.Close();
        }
    }
}
