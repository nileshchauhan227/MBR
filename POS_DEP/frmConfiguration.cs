using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.DTO;
using POS.BAL;
using POS.Classes;

namespace POS
{
    public partial class frmConfiguration : Form
    {

        public List<ConfigurationDTO> lstDTO { get; set; }
        public frmConfiguration()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);

        }
        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            EnableControl(false);
            btnOK.Enabled = btnCancel.Enabled = false;
            btnUpdate.Enabled = true;
            for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
            {
                ddlKOTPrinter.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters[i]);
                ddlBillPrinter.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters[i]);
            }
            this.FillControls();
            grpActivation.Visible = CurrentUser.UserType == 10;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lstDTO != null && this.lstDTO.Count > 0)
            {
                UpdateListObject();
                if (clsBConfiguration.AddWithMultiple(lstDTO) > 0)
                {
                    EnableControl(false);
                    btnOK.Enabled = btnCancel.Enabled = false;
                    btnUpdate.Enabled = true;
                    MessageBox.Show("Settings updated successfully.");
                }

                else
                    MessageBox.Show("Some error occured while updating records.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.lstDTO = null;
            this.FillControls();
            EnableControl(false);
            btnOK.Enabled = btnCancel.Enabled = false;
            btnUpdate.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void enterOnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void FillControls()
        {
            lstDTO = clsBConfiguration.GetAllRecordsList();
            if (lstDTO != null && lstDTO.Count > 0)
            {

                //Bill Print Option
                rdoBPOCompusaryPrint.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.BillPrintOption).ConfigurationValue == "1";
                rdoBPONoCompusaryPrint.Checked = !rdoBPOCompusaryPrint.Checked;

                //KOT Print Option
                rdoKPOCompulsaryPrint.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTPrintOption).ConfigurationValue == "1";
                rdoKPONoCompulsaryPrint.Checked = !rdoKPOCompulsaryPrint.Checked;

                //print while login with normal user
                rdoLWNUCompulsaryPrint.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.PrintBillwhileLoginwithnormaluser).ConfigurationValue == "1";
                rdoLWNUNoCompulsaryPrint.Checked = !rdoLWNUCompulsaryPrint.Checked;

                //Default Printer
                ddlBillPrinter.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.BillDefaultPrinter).ConfigurationValue;
                ddlKOTPrinter.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTDefaultPrinter).ConfigurationValue;

                //Discount
                rdoDiscountApplied.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.Discount).ConfigurationValue == "1";
                rdoDiscountNotApplied.Checked = !rdoDiscountApplied.Checked;

                //Manual Discount
                rdoManualDiscountApplied.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ManualDiscount).ConfigurationValue == "1";
                rdoManualDiscountNotApplied.Checked = !rdoManualDiscountApplied.Checked;

                //Auto Login
                rdoAutoLoginApplied.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AutoLogin).ConfigurationValue == "1";
                rdoAutoLoginNotApplied.Checked = !rdoAutoLoginApplied.Checked;

                //KOT Compulsary
                rdoKOTCompulsaryApplied.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTCompulsary).ConfigurationValue == "1";
                rdoKOTNotCompulsaryApplied.Checked = !rdoKOTCompulsaryApplied.Checked;

                //Auto Cutter
                rdoAutoCutterOn.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AutoCutter).ConfigurationValue == "1";
                rdoAutoCutterOff.Checked = !rdoAutoCutterOn.Checked;

                //Auto Cutter
                rdoVATIncludedNo.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ServiceTaxEnabled).ConfigurationValue == "0";
                rdoVATIncludedYes.Checked = !rdoVATIncludedNo.Checked;

                rdoGroupWiseKOTPrintOn.Checked = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.GroupWiseKOTPrint).ConfigurationValue == "1";
                rdoGroupWiseKOTPrintOff.Checked = !rdoGroupWiseKOTPrintOn.Checked;

                txtDiscount.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.DiscountPercentage).ConfigurationValue;
                txtServiceTaxPercentage.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ServiceTaxPercentage).ConfigurationValue;
                txtMessage.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.PrintMessage).ConfigurationValue;

                dtFromDate.Value = Convert.ToDateTime(Encrypt_Decrypt.DecryptText(lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ActivationFromDate).ConfigurationValue, "SilverAmreli"));
                dtToDate.Value = Convert.ToDateTime(Encrypt_Decrypt.DecryptText(lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ActivationToDate).ConfigurationValue, "SilverAmreli"));

                txtAdditionalTax.Text = lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AdditionalTaxPercentage).ConfigurationValue;
            }
        }

        private void UpdateListObject()
        {
            //Bill Print Option
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.BillPrintOption).ConfigurationValue = rdoBPOCompusaryPrint.Checked ? "1" : "0";
            //KOT Print Option
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTPrintOption).ConfigurationValue = rdoKPOCompulsaryPrint.Checked ? "1" : "0";

            //print while login with normal user
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.PrintBillwhileLoginwithnormaluser).ConfigurationValue = rdoLWNUCompulsaryPrint.Checked ? "1" : "0";

            //Default Printer
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.BillDefaultPrinter).ConfigurationValue = ddlBillPrinter.Text;
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTDefaultPrinter).ConfigurationValue = ddlKOTPrinter.Text;

            //Discount
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.Discount).ConfigurationValue = rdoDiscountApplied.Checked ? "1" : "0";

            //Manual Discount
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ManualDiscount).ConfigurationValue = rdoManualDiscountApplied.Checked ? "1" : "0";

            //Auto Login
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AutoLogin).ConfigurationValue = rdoAutoLoginApplied.Checked ? "1" : "0";

            //KOT Compulsary
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.KOTCompulsary).ConfigurationValue = rdoKOTCompulsaryApplied.Checked ? "1" : "0";

            //Auto Cutter
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AutoCutter).ConfigurationValue = rdoAutoCutterOn.Checked ? "1" : "0";

            //Auto Cutter
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ServiceTaxEnabled).ConfigurationValue = rdoVATIncludedYes.Checked ? "1" : "0";

            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.DiscountPercentage).ConfigurationValue = txtDiscount.Text == "" ? "0.00" : txtDiscount.Text;
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.PrintMessage).ConfigurationValue = txtMessage.Text;
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ServiceTaxPercentage).ConfigurationValue = txtServiceTaxPercentage.Text == "" ? "0.00" : txtServiceTaxPercentage.Text;
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.GroupWiseKOTPrint).ConfigurationValue = rdoGroupWiseKOTPrintOn.Checked ? "1" : "0";

            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ActivationFromDate).ConfigurationValue = Encrypt_Decrypt.EncryptText(dtFromDate.Value.ToShortDateString(), "SilverAmreli");
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.ActivationToDate).ConfigurationValue = Encrypt_Decrypt.EncryptText(dtToDate.Value.ToShortDateString(), "SilverAmreli");
            lstDTO.Find(x => x.ConfigurationKey == Constants.ConfigurationKey.AdditionalTaxPercentage).ConfigurationValue = txtAdditionalTax.Text == "" ? "0.00" : txtAdditionalTax.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ConfigurationDTO EditConfigurationList(string key)
        {
            return this.lstDTO.Find(delegate(ConfigurationDTO obj) { return obj.ConfigurationKey == key; });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            EnableControl(true);
        }

        public void EnableControl(Boolean flag)
        {
            pnlAutoCutter.Enabled =
                pnlAutoLogin.Enabled =
                pnlbillPrintOption.Enabled =
                pnlDefaultPrinter.Enabled =
                pnlDiscount.Enabled =
                pnlKOTCompulsary.Enabled =
                pnlKOTPrintOption.Enabled =
                pnlManualDiscount.Enabled =
                pnlVatIncludedInSales.Enabled =
                pnlGeneral.Enabled =
                pnlPrintBillWhileLoginWithNoramlUser.Enabled =
                pnlGroupWiseKotPrint.Enabled =
                txtMessage.Enabled = flag;
        }
    }
}
