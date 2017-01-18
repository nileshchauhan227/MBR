using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BAL;
using POS.Classes;
using Microsoft.Win32;
using POS.Utilities;
using POS.DTO;


namespace POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtusername.Text))
            {
                MessageBox.Show("Please enter Login ID", "Information");
                return;
            }
            if (String.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Please enter Password", "Information");
                return;
            }
            if (!clsBUserLogin.IsUserExist(txtusername.Text))
            {
                MessageBox.Show("Login ID or Password does not exist", "Information");
                return;
            }
            var obj = clsBUserLogin.GetUserLogin(txtusername.Text, txtpassword.Text);
            if (obj != null)
            {
                CurrentUser.ID = obj.ID;
                CurrentUser.LoginID = obj.LoginID;
                CurrentUser.UserType = obj.UserType ?? 0;
                CurrentUser.DisplayName = obj.DisplayName;

                if (CurrentUser.UserType == 10)
                {
                    //no need to check activation;
                }
                else if (!IsActivatedCopy())
                {
                    MessageBox.Show("Your product copy is expired. Please contact to administrator", "Activate Product", MessageBoxButtons.OK);
                    Application.Exit();
                }

                //this.MdiParent.Activate();
                //this.MdiParent.Show();
                this.Hide();
                Master objMaster = new Master();
                objMaster.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login ID or Password does not exist", "Information");
                return;
            }
        }

        private bool CheckForDuplicate(Form newForm)
        {
            bool bValue = false;
            foreach (Form fm in this.MdiChildren)
            {
                if (fm.GetType() == newForm.GetType())
                {
                    fm.Activate();
                    fm.WindowState = FormWindowState.Maximized;
                    bValue = true;
                    bValue = false;
                }
            }
            return bValue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        public bool IsLicenseExpired()
        {

            if (!clsBConfiguration.IsKeyExists("ExpiryDate"))
            {
                clsBConfiguration.Add(new ConfigurationDTO { ConfigurationKey = "ExpiryDate", ConfigurationValue = "" });
                return false;
            }
            else
            {
                var obj = clsBConfiguration.GetConfigVal("ExpiryDate");
                if (obj == string.Empty)
                    return false;
                else
                {
                    DateTime expdate;
                    if (DateTime.TryParse(obj, out expdate))
                        return DateTime.Now.Date > Convert.ToDateTime(obj).Date;
                    else
                        return false;

                }
            }
        }

        public bool IsActivatedCopy()
        {
            DateTime dtFrom = Convert.ToDateTime(Encrypt_Decrypt.DecryptText(clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ActivationFromDate), "SilverAmreli"));
            DateTime dtTo = Convert.ToDateTime(Encrypt_Decrypt.DecryptText(clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ActivationToDate), "SilverAmreli"));

            if (dtFrom.Date <= DateTime.Now.Date && DateTime.Now.Date <= dtTo.Date)
            {
                return true;
            }
            else
            {

                return false;
            }
            //string keyname = "TISPOS";
            //RegistryKey key;
            //key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyname, true);


            //RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            //RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI", false);
            //if (registryKey != null)
            //{

            //}
            //if (key != null)
            //{
            //    string date = StringCipher.Decrypt(key.GetValue("Ex").ToString());
            //    DateTime dt;
            //    if (DateTime.TryParse(date, out dt))
            //    {
            //        if (dt != DateTime.MinValue)
            //        {
            //            return dt > DateTime.Now;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Register your product copy.");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Product copy is expired. Please contact to administrator");
            //    }
            //}
            //return false;
        }
    }
}
