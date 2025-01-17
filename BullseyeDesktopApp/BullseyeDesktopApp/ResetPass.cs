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
        private bool canClose = true;


        //    FORM LOADING
        //
        //
        public ResetPass()
        {
            InitializeComponent();
        }
        private void ResetPass_Load(object sender, EventArgs e)
        {
            getUsername();
            this.AcceptButton = btnConfirm;

            // IF Current user is NULL form can close, if not null and First isert form can not close
            if (StaticHelpers.UserSession.CurrentUser != null)
                canClose = !(StaticHelpers.UserSession.CurrentUser.FirstInsert ?? true); //Should never be null but if it is will let page close
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


        //      SHOW/HIDE PASSWORD
        //
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


        //       CONFIRM BUTTON
        //
        //
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            picConfirmError.Visible = false;
            //Checks to see if passwords match
            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("Passwords must match", "Mismatch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picConfirmError.Visible = true;
                return;
            }

            //If no valid user is logged in throws error
            if (StaticHelpers.UserSession.CurrentUser == null)
            {
                MessageBox.Show("Must be an active user to reset password, contact admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else //If valid user logged in
            {

                if (StaticHelpers.PasswordHelper.VerifyPasswordRequirements(txtConfirm.Text)) //If password meets requirments
                {
                    try
                    {
                        using (var context = new Models.BullseyeContext())
                        {
                            var dbUser = context.Employees.FirstOrDefault(u => u.EmployeeId == StaticHelpers.UserSession.CurrentUser.EmployeeId);
                            if (dbUser != null)
                            {
                                dbUser.Password = StaticHelpers.PasswordHelper.HashPassword(txtConfirm.Text); //Hash and change password
                                dbUser.FirstInsert = false; // Change first insert to false
                                if (context.SaveChanges() > 0)
                                {
                                    canClose = true; // Can close once password if changed
                                    MessageBox.Show("Password updated", "Success", MessageBoxButtons.OK);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("DB Error, password not updated", "Error");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "DB Error");
                    }
                }
                else //Password requirements not met
                    MessageBox.Show("Password must be 8 characters long, with 1 non-numeric," +
                        " 1 capitol letter, and 1 number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //        GENERATE BUTTON
        //
        // Auto generates password and autofills password inputs
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtNew.Text = StaticHelpers.PasswordHelper.Generate();
            txtConfirm.Text = txtNew.Text;
        }


        //       FORM CLOSING
        //
        // Blocks form closing for user first log in if password not changed
        private void ResetPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                MessageBox.Show("You must change your initial password before closing!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                e.Cancel = true;
            }
        }
    }
}
