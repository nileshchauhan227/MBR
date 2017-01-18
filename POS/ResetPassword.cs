using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Classes;
using POS.BAL;
using POS.DTO;

namespace POS
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = CurrentUser.LoginID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password doesn't match.", "Information", MessageBoxButtons.OK);
                return; 
            }

            UserLoginDTO res = clsBUserLogin.GetUserLogin(txtUserName.Text.Trim(), txtPassword.Text);
            if (res.ID > 0)
            {
                if (clsBUserLogin.UpdatePassword(txtUserName.Text.Trim(), txtPassword.Text, txtNewPassword.Text))
                {
                    MessageBox.Show("Password Successfully updated. You need logout and login to the system", "Success", MessageBoxButtons.OK);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Failed to reset password.", "Failure", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Existing password does not match. Please try again", "Information", MessageBoxButtons.OK);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
