using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BAL;
using POS.DTO;
using POS.Classes;

namespace POS
{
    public partial class CompanySetup : Form
    {
        public string DatabasePath { get; set; }
        public CompanySetup()
        {
            InitializeComponent();
           
        }
        public CompanySetup(string databasePath)
        {
            InitializeComponent();
            this.DatabasePath = databasePath;

        }
        private void CompanySetup_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ConfigurationDTO> lstConfiguration = new List<ConfigurationDTO>();
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 1, ConfigurationKey = Classes.Constants.ConfigurationKey.BillPrintOption, ConfigurationValue = "1", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 2, ConfigurationKey = Classes.Constants.ConfigurationKey.KOTPrintOption, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 3, ConfigurationKey = Classes.Constants.ConfigurationKey.PrintBillwhileLoginwithnormaluser, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 4, ConfigurationKey = Classes.Constants.ConfigurationKey.GeneralDiscountValue, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 5, ConfigurationKey = Classes.Constants.ConfigurationKey.BillSeries, ConfigurationValue = "", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 6, ConfigurationKey = Classes.Constants.ConfigurationKey.KOTDefaultPrinter, ConfigurationValue = "", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 7, ConfigurationKey = Classes.Constants.ConfigurationKey.BillDefaultPrinter, ConfigurationValue = "", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 8, ConfigurationKey = Classes.Constants.ConfigurationKey.Discount, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 9, ConfigurationKey = Classes.Constants.ConfigurationKey.ManualDiscount, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 10, ConfigurationKey = Classes.Constants.ConfigurationKey.AutoLogin, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 11, ConfigurationKey = Classes.Constants.ConfigurationKey.KOTCompulsary, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 12, ConfigurationKey = Classes.Constants.ConfigurationKey.AutoCutter, ConfigurationValue = "1", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 13, ConfigurationKey = Classes.Constants.ConfigurationKey.ServiceTaxEnabled, ConfigurationValue = "1", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 14, ConfigurationKey = Classes.Constants.ConfigurationKey.DiscountPercentage, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 15, ConfigurationKey = Classes.Constants.ConfigurationKey.PrintMessage, ConfigurationValue = "THANKS! VISIT AGAIN!!!", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 16, ConfigurationKey = Classes.Constants.ConfigurationKey.ShopName, ConfigurationValue = txtShopName.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 17, ConfigurationKey = Classes.Constants.ConfigurationKey.InvoiceName, ConfigurationValue = "Retail Invoice", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 18, ConfigurationKey = Classes.Constants.ConfigurationKey.Firm, ConfigurationValue = txtShopName.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 19, ConfigurationKey = Classes.Constants.ConfigurationKey.Add1, ConfigurationValue = txtAdd1.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 20, ConfigurationKey = Classes.Constants.ConfigurationKey.Add2, ConfigurationValue = txtAdd2.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 21, ConfigurationKey = Classes.Constants.ConfigurationKey.ServiceTaxPercentage, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 22, ConfigurationKey = Classes.Constants.ConfigurationKey.GST_TIN, ConfigurationValue = txtTIN.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 23, ConfigurationKey = Classes.Constants.ConfigurationKey.GroupWiseKOTPrint, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 24, ConfigurationKey = Classes.Constants.ConfigurationKey.GSTTINDATE, ConfigurationValue = txtGSTTINDate.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 25, ConfigurationKey = Classes.Constants.ConfigurationKey.Email, ConfigurationValue = txtEmail.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 26, ConfigurationKey = Classes.Constants.ConfigurationKey.Phone, ConfigurationValue = txtPhone.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 27, ConfigurationKey = Classes.Constants.ConfigurationKey.ActivationFromDate, ConfigurationValue = Encrypt_Decrypt.EncryptText(DateTime.Now.ToString(), Constants.encryptKey), CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 28, ConfigurationKey = Classes.Constants.ConfigurationKey.ActivationToDate, ConfigurationValue = Encrypt_Decrypt.EncryptText(DateTime.Now.AddYears(1).ToString(), Constants.encryptKey), CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 29, ConfigurationKey = Classes.Constants.ConfigurationKey.ReportHeader, ConfigurationValue = txtShopName.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 30, ConfigurationKey = Classes.Constants.ConfigurationKey.ManageInventory, ConfigurationValue = "1", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 31, ConfigurationKey = Classes.Constants.ConfigurationKey.DatabasePath, ConfigurationValue = this.DatabasePath, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 32, ConfigurationKey = Classes.Constants.ConfigurationKey.DatabaseBackupPath, ConfigurationValue = txtDatabaseBackupPath.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 33, ConfigurationKey = Classes.Constants.ConfigurationKey.CST_TIN, ConfigurationValue = txtTIN.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 34, ConfigurationKey = Classes.Constants.ConfigurationKey.CSTTINDATE, ConfigurationValue = txtCSTTINDate.Text, CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            lstConfiguration.Add(new ConfigurationDTO { ConfigurationID = 35, ConfigurationKey = Classes.Constants.ConfigurationKey.AdditionalTaxPercentage, ConfigurationValue = "0", CreatedBy = CurrentUser.ID, CreatedDate = DateTime.Now });
            clsBConfiguration.AddWithMultiple(lstConfiguration);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



    }
}
