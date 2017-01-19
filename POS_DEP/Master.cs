using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Classes;
using POS_Reports;
using POS.BAL;
using System.Configuration;

namespace POS
{
    public partial class Master : Form
    {
        private int childFormNumber = 0;

        public Master()
        {
            InitializeComponent();
            if (CurrentUser.UserType == 30)
            {
                masterToolStripMenuItem.Enabled = false;
                utilityToolStripMenuItem.Enabled = false;
            }
            else
            {
                masterToolStripMenuItem.Enabled = true;
                utilityToolStripMenuItem.Enabled = true;
            }

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }




        private void codeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("Code Master");
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("Item Master");
        }

        private void btnItemMaster_Click(object sender, EventArgs e)
        {

            this.OpenForm("Item Master");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OpenForm("Code Master");
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
        private void CloseAllForms()
        {
            foreach (Form fm in this.MdiChildren)
            {
                fm.Close();
            }
        }

        public void OpenForm(string formname)
        {
            CloseAllForms();
            switch (formname)
            {
                case "Code Master":
                    frmCodeMaster frmCodeMaster = new frmCodeMaster();
                    //if (!CheckForDuplicate(frmCodeMaster))
                    //{
                    frmCodeMaster.MdiParent = this;
                    frmCodeMaster.Show();
                    //}
                    break;
                case "Item Master":

                    ItemMaster ItemMaster = new ItemMaster();
                    //if (!CheckForDuplicate(ItemMaster))
                    //{
                    ItemMaster.MdiParent = this;
                    ItemMaster.Show();
                    //}
                    break;
                case "CashExpense":

                    frmCashExpense frmCashExpense = new frmCashExpense();
                    //if (!CheckForDuplicate(ItemMaster))
                    //{
                    frmCashExpense.MdiParent = this;
                    frmCashExpense.Show();
                    //}
                    break;
                case "CompanyMaster":

                    frmCompanyMaster frmCompanyMaster = new frmCompanyMaster();
                    //if (!CheckForDuplicate(ItemMaster))
                    //{
                    frmCompanyMaster.MdiParent = this;
                    frmCompanyMaster.Show();
                    //}
                    break;
                case "frmCustomerMaster":
                    frmCustomerMaster frmCustomerMaster = new frmCustomerMaster();
                    //if (!CheckForDuplicate(ItemMaster))
                    //{
                    frmCustomerMaster.MdiParent = this;
                    frmCustomerMaster.Show();
                    break;
                case "frmCustomerMapping":
                    frmCustomerMapping frmCustomerMapping = new frmCustomerMapping();
                    //if (!CheckForDuplicate(ItemMaster))
                    //{
                    frmCustomerMapping.MdiParent = this;
                    frmCustomerMapping.Show();
                    break;
                case "KOT":

                    frmKOT frmKOT = new frmKOT();
                    //if (!CheckForDuplicate(frmKOT))
                    //{
                    frmKOT.MdiParent = this;
                    frmKOT.Show();
                    //} 
                    break;
                case "Bill":
                    frmBill frmBill = new frmBill();
                    //if (!CheckForDuplicate(frmBill))
                    //{
                    frmBill.MdiParent = this;
                    frmBill.Show();
                    //}
                    break;
                case "DirectBill":
                    DirectBill frmDirectBill = new DirectBill();
                    frmDirectBill.MdiParent = this;
                    frmDirectBill.Show();
                    break;
                case "Inward":
                    Inward frmInward = new Inward();
                    frmInward.MdiParent = this;
                    frmInward.Show();
                    break;
                case "InwardReturn":
                    InwardReturn frmInwardReturn = new InwardReturn();
                    frmInwardReturn.MdiParent = this;
                    frmInwardReturn.Show();
                    break;
                case "frmOpeningBalance":
                    frmOpeningBalance objfrmOpeningBalance = new frmOpeningBalance();
                    objfrmOpeningBalance.MdiParent = this;
                    objfrmOpeningBalance.Show();
                    break;

                case "frmDailyOpenClose":
                    frmDailyOpenClose objfrmDailyOpenClose = new frmDailyOpenClose();
                    objfrmDailyOpenClose.MdiParent = this;
                    objfrmDailyOpenClose.Show();
                    break;

                case "Configuration":
                    frmConfiguration frmConfiguration = new frmConfiguration();
                    //if (!CheckForDuplicate(frmConfiguration))
                    //{
                    frmConfiguration.MdiParent = this;
                    frmConfiguration.Show();
                    //}
                    break;
                case "Maintain":
                    frmMaintainBill frmMaintainBill = new frmMaintainBill();
                    //if (!CheckForDuplicate(frmMaintainBill))
                    //{
                    frmMaintainBill.MdiParent = this;
                    frmMaintainBill.Show();
                    //}
                    break;
                case "Reports":
                    SalesReports SalesReports = new SalesReports();
                    //if (!CheckForDuplicate(frmMaintainBill))
                    //{
                    SalesReports.MdiParent = this;
                    SalesReports.Show();
                    //}
                    break;
                case "Login":
                    Login frmLogin = new Login();
                    //if (!CheckForDuplicate(frmLogin))
                    //{
                    //frmLogin.MdiParent = this;
                    frmLogin.Show();
                    // }
                    break;

                case "Logout":
                    Master master = new Master();
                    //if (!CheckForDuplicate(frmLogin))
                    //{
                    //frmLogin.MdiParent = this;
                    master.Show();
                    // }
                    break;

                default:
                    break;
            }
            //  }


        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("Configuration");
        }

        private void kOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("KOT");
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("Bill");
        }

        private void Master_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void manageDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenForm("Maintain");
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.OpenForm("Configuration");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            this.Close();
        }





        //protected override void OnKeyPress(KeyPressEventArgs ex)
        //{
        //    string xo = ex.KeyChar.ToString();

        //    if (xo == "k" || xo == "K") //You pressed "q" key on the keyboard
        //    {
        //        OpenForm("KOT");
        //    }
        //    else if (xo == "b" || xo == "B") //You pressed "q" key on the keyboard
        //    {
        //        OpenForm("Bill");
        //    }
        //}


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("Login");
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("Reports");
        }

        private void Master_Load(object sender, EventArgs e)
        {
            checkStatus();
        }

        private void checkStatus()
        {
            if (CurrentUser.ID > 0)
            {
                masterToolStripMenuItem.Enabled =
                    utilityToolStripMenuItem.Enabled =
                    reportsToolStripMenuItem.Enabled = true;
                loginToolStripMenuItem.Visible = false;
                logOutToolStripMenuItem.Visible = true;
            }
            else
            {
                masterToolStripMenuItem.Enabled =
                  utilityToolStripMenuItem.Enabled =
                  reportsToolStripMenuItem.Enabled = false;
                loginToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Visible = false;
            }
        }

        //private void Master_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string xo = e.KeyChar.ToString();

        //    if (xo == "k" || xo == "K") //You pressed "q" key on the keyboard
        //    {
        //        OpenForm("KOT");
        //    }
        //    else if (xo == "b" || xo == "B") //You pressed "q" key on the keyboard
        //    {
        //        OpenForm("Bill");
        //    }
        //}

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser.ID = 0;
            CurrentUser.UserType = 0;
            CloseAllForms();
            checkStatus();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

             string dbbackupPath = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.DatabasePath);

             clsBDatabase.GetDatabaseFullBackup(dbbackupPath, "");
            var DBBackup = ConfigurationSettings.AppSettings["DBBackup"].ToString();
            var Connection = ConfigurationSettings.AppSettings["Connection"].ToString();
            clsBBackupService obj = new clsBBackupService(Connection, DBBackup);
            obj.BackupDatabase(ConfigurationSettings.AppSettings["Database"].ToString());
            MessageBox.Show("Database backup successful @" + DBBackup);
        }

        private void directBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("DirectBill");
        }

        private void cashExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("CashExpense");
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("CompanyMaster");
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("DirectBill");
        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPassword frmResetPassword = new ResetPassword();
            if (!CheckForDuplicate(frmResetPassword))
            {
                frmResetPassword.MdiParent = this;
                frmResetPassword.Show();
            }
        }

        private void materialInwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("Inward");
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("InwardReturn");
        }

        private void openingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("frmOpeningBalance");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm("frmDailyOpenClose");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm("frmCustomerMaster");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenForm("frmCustomerMapping");
        }
    }
}
