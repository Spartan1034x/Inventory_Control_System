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
        //Flags for the hiding and showing passwords
        private bool newFlag = true;
        private bool conFlag = true;

        public ResetPass()
        {
            InitializeComponent();
            getUsername();
            this.AcceptButton = btnConfirm;
        }

        //Sent: string
        //Returned: nil
        //Desc: If username is sent then populates lbl if not txt to enter username appears
        private void getUsername()
        {
            if (StaticHelpers.UserSession.CurrentUser != null)
            {
                lblUsername.Text = StaticHelpers.UserSession.CurrentUser.Username;
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
            if (StaticHelpers.UserSession.CurrentUser == null)
            {
                MessageBox.Show("Must be an active user to reset password, contact admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }

            this.Close();
        }


        //        GENERATE BUTTON
        //
        // Auto generates password and autofills password inputs
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtNew.Text = StaticHelpers.PasswordHelper.Generate();
            txtConfirm.Text = txtNew.Text;
        }
    }
}
