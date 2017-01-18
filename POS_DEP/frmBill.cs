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
using System.Drawing.Printing;

namespace POS
{
    public partial class frmBill : Form
    {
        public int InvoiceID { get; set; }
        public List<int> kotIDs { get; set; }
        public bool ApplyGeneralDiscount { get; set; }
        public bool ApplyManualDiscount { get; set; }
        public string PrintMessage { get; set; }
        public bool IsNormalUSer { get; set; }
        public decimal GeneralDiscountPercentage { get; set; }
        public bool CompusaryBillPrint { get; set; }
        public bool CompulsaryBillPrintWhilenormalUser { get; set; }
        public decimal VatPercentage { get; set; }
        public bool VATEnabled { get; set; }

        public frmBill()
        {
            InitializeComponent();
            txtDiscountReason.Enabled = txtDiscount.Enabled = false;
        }
        public void BindTable()
        {
            var res = clsBCodeMaster.GetAllRecordsList("TB");
            ddlTableNo.DisplayMember = "Name";
            ddlTableNo.ValueMember = "ID";
            ddlTableNo.DataSource = res;
        }
        private void MakeSerieal()
        {
            if (grdBill.Rows.Count > 1)
            {
                for (int i = 0; i < grdBill.Rows.Count - 1; i++)
                {
                    grdBill.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }
        public void BindRunningKOT()
        {
            var res = clsBKOT.GetRunningKOT(DateTime.Now.Date);
            grdRunningKot.DataSource = res;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grdRunningKot_DoubleClick(object sender, EventArgs e)
        {
            GetBillDetailsFromKOT();
        }

        public void GetBillDetailsFromKOT()
        {
            clearControls();
            List<KOTMasterDTO> kots = new List<KOTMasterDTO>();
            List<int> ids = new List<int>();
            foreach (DataGridViewRow row in grdRunningKot.SelectedRows)
            {
                var id = Convert.ToInt32(row.Cells[0].Value);
                kots.Add(clsBKOT.GetKOTDetails(id));
                ids.Add(id);
            }
            this.kotIDs = ids;
            int srno = 1;
            decimal GrossAmount = 0;
            decimal DiscountAmount = 0;
            foreach (var item in kots)
            {
                foreach (var detail in item.detailList)
                {
                    decimal itemdiscount = ((detail.ItemRate.Value * detail.Discount.Value / 100) + detail.OtherDiscount.Value);
                    GrossAmount += detail.Quantity * (detail.ItemRate.Value - itemdiscount);
                    //DiscountAmount += itemdiscount;
                    grdBill.Rows.Add(srno++, detail.Quantity, detail.ItemCode, detail.ItemName, detail.ItemRate, itemdiscount.GetDecimalString(), (detail.Quantity * (detail.ItemRate.Value - itemdiscount)).GetDecimalString(), detail.ItemID);
                }
            }
            txtDiscountReason.Enabled = txtDiscountReason.Enabled = this.ApplyManualDiscount;
            txtQuantity.Text = (srno - 1).ToString();
            txtGrossAmount.Text = GrossAmount.GetDecimalString();
            txtDiscount.Text = this.GeneralDiscountPercentage.GetDecimalString();
            this.txtVatPercentage.Text = this.VatPercentage.GetDecimalString();
            decimal netAmount = (GrossAmount - (DiscountAmount + GrossAmount * this.GeneralDiscountPercentage / 100));
            txtNetAmount.Text = (netAmount + (netAmount * this.VatPercentage / 100)).GetDecimalString();
            txtCashReceived.Text = (GrossAmount - (DiscountAmount + GrossAmount * this.GeneralDiscountPercentage / 100)).GetDecimalString();
            ddlTableNo.SelectedValue = kots[0].TableID;
            txtInvoiceDate.Text = kots[0].KOTDateTime.Date.GetShortDateString();
        }

        private void txtCashReceived_KeyUp(object sender, KeyEventArgs e)
        {
            decimal netAmount = Convert.ToDecimal(txtNetAmount.Text);
            decimal cashreceived = Convert.ToDecimal(txtCashReceived.Text.Trim() == "" ? "0" : txtCashReceived.Text.Trim());
            if (netAmount > cashreceived)
            {
                txtRoundOffAmount.Text = (netAmount - cashreceived).GetDecimalString();
                txtChange.Text = "0.00";
            }
            else
            {
                txtChange.Text = (netAmount - cashreceived).GetDecimalString();
                txtRoundOffAmount.Text = "0.00";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public void GetNextInvoideNumber()
        {
            txtBillNumber.Text = clsBBill.GetNextInvoiceNumber().ToString();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumber(sender, e);
        }

        private void txtCashReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumber(sender, e);
        }

        public void clearControls()
        {
            GetNextInvoideNumber();
            txtBillSeries.Text = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillSeries) + String.Format("{0}/{1}/{2}/","SALE",DateTime.Now.Year,DateTime.Now.Month);
            txtInvoiceDate.Text = DateTime.Now.Date.GetShortDateString();
            grdBill.Rows.Clear();
            ddlTableNo.SelectedIndex = 0;
            txtDiscount.Text = "0.00";
            txtDiscountReason.Text = "";
            txtQuantity.Text = "0";
            txtCashReceived.Text = "0.00";
            txtChange.Text = "0.00";
            txtGrossAmount.Text = "0.00";
            txtRoundOffAmount.Text = "0.00";
            txtNetAmount.Text = "0.00";
            txtVatPercentage.Text = "0.00";
            ButtonEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            txtInvoiceDate.Text = DateTime.Now.GetShortDateString();
            grdBill.AutoGenerateColumns = false;
            grdRunningKot.AutoGenerateColumns = false;

            BindTable();
            MakeSerieal();
            BindRunningKOT();

            GetNextInvoideNumber();
            this.PrintMessage = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.PrintMessage);
            this.ApplyGeneralDiscount = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.Discount) == "1" ? true : false;
            this.ApplyManualDiscount = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ManualDiscount) == "1" ? true : false;
            this.CompusaryBillPrint = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillPrintOption) == "1" ? true : false;

            this.VATEnabled = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ServiceTaxEnabled) == "1" ? true : false;
            this.IsNormalUSer = false;
            if (CurrentUser.ID == 0)
            {
                this.IsNormalUSer = true;
                this.CompulsaryBillPrintWhilenormalUser = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.PrintBillwhileLoginwithnormaluser) == "1" ? true : false;
            }
            if (this.ApplyGeneralDiscount)
            {
                var value = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.DiscountPercentage);
                this.GeneralDiscountPercentage = value != string.Empty ? Convert.ToInt32(value) : 0;
            }
            else
                this.GeneralDiscountPercentage = 0;
            if (this.VATEnabled)
                this.VatPercentage = Convert.ToInt64(clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ServiceTaxPercentage));

            txtDiscount.Enabled = txtDiscountReason.Enabled = this.ApplyManualDiscount;
            ButtonEnable(false);
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            decimal grossAmount = Convert.ToDecimal(txtGrossAmount.Text);
            decimal discountRate = Convert.ToDecimal(txtDiscount.Text.Trim() == string.Empty ? "0" : txtDiscount.Text.Trim());
            txtNetAmount.Text = txtCashReceived.Text = (grossAmount - (grossAmount * discountRate / 100)).GetDecimalString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBill();
        }

        public void SaveBill()
        {
            BillMasterDTO objMaster = new BillMasterDTO();
            objMaster.KotIDs = this.kotIDs;
            objMaster.Series = txtBillSeries.Text;
            objMaster.Rnumber = Convert.ToInt32(txtBillNumber.Text);
            objMaster.InvoiceDate = DateTime.Now;
            objMaster.Party = txtName.Text;
            objMaster.PaymentMode = txtPartyCode.Text;
            objMaster.TableID = Convert.ToInt32(ddlTableNo.SelectedValue);
            objMaster.Discount = Convert.ToDecimal(txtGrossAmount.Text) - Convert.ToDecimal(txtNetAmount.Text);
            objMaster.DiscountPercentage = Convert.ToDecimal(txtDiscount.Text == "" ? "0" : txtDiscount.Text);
            objMaster.DiscountReason = txtDiscountReason.Text.Trim();
            objMaster.GrossAmount = Convert.ToDecimal(txtGrossAmount.Text == "" ? "0" : txtGrossAmount.Text);
            objMaster.Tax = Convert.ToDecimal(txtVatPercentage.Text == "" ? "0" : txtVatPercentage.Text);
            objMaster.NetAmount = Convert.ToDecimal(txtNetAmount.Text == "" ? "0" : txtNetAmount.Text);
            objMaster.CashReceived = Convert.ToDecimal(txtCashReceived.Text == "" ? "0" : txtCashReceived.Text);
            objMaster.RoundOff = Convert.ToDecimal(txtRoundOffAmount.Text == "" ? "0" : txtRoundOffAmount.Text);
            foreach (DataGridViewRow item in grdBill.Rows)
            {
                if (item.Cells[1] != null && item.Cells[1].Value != null)
                {
                    objMaster.details.Add(new BillDetailsDTO()
                    {
                        ItemID = Convert.ToInt32(item.Cells["ItemID"].Value),
                        Amount = Convert.ToDecimal(item.Cells["Amount"].Value),
                        Discount = Convert.ToDecimal(item.Cells["Discount"].Value),
                        Rate = Convert.ToDecimal(item.Cells["Rate"].Value),
                        Quantity = Convert.ToDecimal(item.Cells["Quantity"].Value)
                    });
                }
            }
            if (this.InvoiceID == 0)
            {
                var res = clsBBill.AddBill(objMaster);
                MessageBox.Show("Bill Saved Successfullly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindRunningKOT();
                //clearControls();
                this.kotIDs.Clear();
                this.InvoiceID = res;
                if (this.CompusaryBillPrint)
                    PrintBill();
                else if (this.IsNormalUSer && this.CompulsaryBillPrintWhilenormalUser)
                    PrintBill();
                this.InvoiceID = 0;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var currentID = Convert.ToInt32(txtBillNumber.Text);
            if (currentID > 1)
            {
                var obj = clsBBill.GetBillDetail(currentID, Enumes.FecthRecord.Previous.ToString());
                this.InvoiceID = obj.BillID;
                Fillcontrols(obj);
            }
        }

        public void Fillcontrols(BillMasterDTO obj)
        {
            clearControls();
            txtBillSeries.Text = obj.Series;
            txtBillNumber.Text = obj.Rnumber.ToString();
            txtInvoiceDate.Text = obj.InvoiceDate.GetShortDateString();
            txtPartyCode.Text = "4";
            txtPartyName.Text = "Cash in hand";
            txtName.Text = obj.Party;
            ddlTableNo.SelectedValue = obj.TableID;
            int srno = 1;
            foreach (var detail in obj.details)
            {
                grdBill.Rows.Add(srno, detail.Quantity, detail.ItemCode, detail.ItemName, detail.Rate, detail.Discount, detail.Amount, detail.ItemID);
                srno++;
            }
            if (this.ApplyGeneralDiscount)
            {
                txtDiscount.Text = obj.DiscountPercentage.GetDecimalString();
                txtDiscountReason.Text = obj.DiscountReason;
            }
            else
            {
                txtDiscount.Text = "0.00";
                txtDiscountReason.Text = "";
            }
            txtGrossAmount.Text = obj.GrossAmount.GetDecimalString();
            txtVatPercentage.Text = obj.Tax.Value.GetDecimalString();
            txtNetAmount.Text = obj.NetAmount.GetDecimalString();
            txtCashReceived.Text = obj.CashReceived.GetDecimalString();
            txtRoundOffAmount.Text = obj.RoundOff.GetDecimalString();
            chkIsPrinted.Checked = obj.IsPrinted;
            if (obj.IsPrinted)
            {

                btnRemove.Enabled =
                btnModify.Enabled =
                btnSave.Enabled =
                btnAdd.Enabled = false;
            }
            else
            {
                btnRemove.Enabled =
              btnModify.Enabled =
              btnSave.Enabled =
              btnAdd.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var currentID = Convert.ToInt32(txtBillNumber.Text);
            if (clsBBill.GetNextInvoiceNumber() - 1 > currentID)
            {
                var obj = clsBBill.GetBillDetail(currentID, Enumes.FecthRecord.Next.ToString());
                this.InvoiceID = obj.BillID;
                Fillcontrols(obj);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var currentID = Convert.ToInt32(txtBillNumber.Text);
            var obj = clsBBill.GetBillDetail(currentID, Enumes.FecthRecord.Last.ToString());
            this.InvoiceID = obj.BillID;
            Fillcontrols(obj);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearControls();
            BindRunningKOT();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetBillDetailsFromKOT();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            clsBBill.Delete(Convert.ToInt32(this.txtBillNumber.Text));
            clearControls();
            BindRunningKOT();
        }
        private bool CheckForDuplicate(Form newForm)
        {
            bool bValue = false;
            foreach (Form fm in this.ParentForm.MdiChildren)
            {
                if (fm.GetType() == newForm.GetType())
                {
                    fm.Activate();
                    fm.WindowState = FormWindowState.Maximized;
                    bValue = true;
                }
            }
            return bValue;
        }
        //protected override void OnKeyPress(KeyPressEventArgs ex)
        //{
        //    string xo = ex.KeyChar.ToString();

        //    if (xo == "k" || xo == "K") //You pressed "q" key on the keyboard
        //    {
        //        foreach (Form childForm in MdiChildren)
        //        {
        //            childForm.Close();
        //        }

        //        frmKOT frmKOT = new frmKOT();
        //        if (!CheckForDuplicate(frmKOT))
        //        {
        //            frmKOT.MdiParent = this.MdiParent;
        //            frmKOT.Show();
        //        }
        //        else
        //        {
        //            frmKOT = null;
        //        }
        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.InvoiceID == 0)
            {
                SaveBill();
            }
            PrintBill();

        }

        public void PrintBill()
        {
            string printer = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillDefaultPrinter);
            //PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            //printDialog.Document = printDocument; //add the document to the dialog box...   
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing
            printDocument.PrinterSettings.PrinterName = printer;
            // printDocument.PrinterSettings.PaperSizes =
            //DialogResult result = printDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            clsBBill.UpdatePrintFlagByRunningNumber(Convert.ToInt32(txtBillNumber.Text));
            chkIsPrinted.Checked = true;
            btnSave.Enabled =
                btnModify.Enabled =
                btnAdd.Enabled =
                btnRemove.Enabled =
                btnSave.Enabled = false;
            printDocument.Print();

            //}
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strRutu = clsBConfiguration.GetConfigVal("ShopName");
            string strRetailInvocie = clsBConfiguration.GetConfigVal("InvoiceName");
            string strTitle1 = clsBConfiguration.GetConfigVal("Firm");
            string strAdd1 = clsBConfiguration.GetConfigVal("Add1");
            string strAdd2 = clsBConfiguration.GetConfigVal("Add2");
            string strTIN = "";// +clsBConfiguration.GetConfigVal("TIN");
            string strTINDate = "";// "Dt:7-9-2005";
            string taxnote = "Amount Inclusive of all applicable taxes";
            //this prints the reciept
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 11); //must use a mono spaced font as the spaces need to line up
            Brush brush = new SolidBrush(Color.Black);
            float fontHeight = font.GetHeight();
            int startX = 30;
            int startY = 10;
            int offset = 10;
            graphic.DrawString("".PadLeft((30 / 2) - (strRetailInvocie.Length / 2)) + strRetailInvocie, font, brush, startX, startY);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft((30 / 2) - (strRutu.Length / 2)) + strRutu, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft((30 / 2) - (strTitle1.Length / 2)) + strTitle1, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft((30 / 2) - (strAdd1.Length / 2)) + strAdd1, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft((30 / 2) - (strAdd2.Length / 2)) + strAdd2, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString(strTIN + " " + strTINDate, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent

            graphic.DrawString(("Bill No : " + txtBillSeries.Text + "/" + txtBillNumber.Text).PadRight(15) + ("Table : " + ddlTableNo.Text).PadRight(15), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(("Date : " + txtInvoiceDate.Text).PadLeft(30), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft(30, '-'), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("Item".PadRight(12) + "Qty".PadRight(5) + "Rate".PadRight(5) + "Amount".PadRight(8), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("".PadLeft(30, '-'), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            float totalprice = 0.00f;
            float totalQuantity = 0.00f;
            foreach (DataGridViewRow item in grdBill.Rows)
            {
                //create the string to print on the reciept
                if (!String.IsNullOrWhiteSpace(Convert.ToString(item.Cells[3].Value)))
                {
                    string productDescription = item.Cells[3].Value.ToString().Substring(0, item.Cells[3].Value.ToString().Length > 12 ? 12 : item.Cells[3].Value.ToString().Length);
                    string quantity = item.Cells[1].Value.ToString();
                    float productQuantity = float.Parse(quantity);
                    float rate = float.Parse(item.Cells[4].Value.ToString()) - float.Parse(item.Cells[5].Value.ToString());
                    float amount = float.Parse(item.Cells[6].Value.ToString());

                    string productLine = productDescription.PadRight(12) + quantity.ToString().PadLeft(5) + rate.ToString("0.00").PadLeft(5) + amount.ToString("0.00").PadLeft(8);
                    graphic.DrawString(productLine, font, brush, startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent

                    totalQuantity += productQuantity;
                    totalprice += amount;

                }
            }
            graphic.DrawString("".PadLeft(30, '-'), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            string total = "Total".PadLeft(10) + totalQuantity.ToString("0.00").PadLeft(6) + totalprice.ToString("0.00").PadLeft(14);
            graphic.DrawString(total, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight;
            if (this.ApplyGeneralDiscount || this.ApplyManualDiscount)
            {
                graphic.DrawString("Discount".PadRight(16) + (Convert.ToDecimal(txtGrossAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)).ToString().PadLeft(14), font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight;
                graphic.DrawString("CASH".PadRight(16) + txtNetAmount.Text.PadLeft(14), font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight;
            }
            else
            {
                graphic.DrawString("CASH :".PadRight(16) + txtNetAmount.Text.PadLeft(14), font, brush, startX, startY + offset);
                offset = offset + (int)fontHeight;
            }
            graphic.DrawString("".PadLeft(30, '-'), font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("".PadLeft((30 / 2) - (taxnote.Length / 2)) + taxnote, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("".PadLeft((30 / 2) - (this.PrintMessage.Length / 2)) + this.PrintMessage, font, brush, startX, startY + offset);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            GetBillDetailsFromKOT();
        }

        public void ButtonEnable(bool flag)
        {
            btnAdd.Enabled =
                btnModify.Enabled =
                btnSave.Enabled =
                btnCancel.Enabled =
                btnRemove.Enabled =
                //btnClose.Enabled =
                //btnPrevious.Enabled =
                //btnNext.Enabled =
                //btnLast.Enabled =
                //btnFind.Enabled =
                //btnRefresh.Enabled =
                btnPrint.Enabled = flag;

        }

    }
}
