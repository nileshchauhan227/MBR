using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using POS.BAL;
using POS.Classes;
using POS.DTO;



namespace POS
{
    public partial class DirectBill : Form
    {
        public int InvoiceID { get; set; }
        //public int RunningKOTID { get; set; }
        bool IsManageInventory = false;
        public bool ApplyGeneralDiscount { get; set; }
        public bool ApplyManualDiscount { get; set; }
        public string PrintMessage { get; set; }
        public bool IsNormalUSer { get; set; }
        public decimal GeneralDiscountPercentage { get; set; }
        public bool CompusaryBillPrint { get; set; }
        public bool CompulsaryBillPrintWhilenormalUser { get; set; }
        public decimal ServiceTaxPercentage { get; set; }
        public bool ServiceTaxEnabled { get; set; }
        public List<ItemMasterDTO> itemlist { get; set; }
        //public bool KOTPrintOption { get; set; }
        //public bool GroupWiseKOTPrint { get; set; }
        //public List<int> kotIDs { get; set; }
        public long GroupID = 0;
        public string GroupName = string.Empty;

        public DirectBill()
        {
            InitializeComponent();
        }
        private void DirectBill_Load(object sender, EventArgs e)
        {

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            grdBill.AutoGenerateColumns = false;
            txtInvoiceDate.Text = DateTime.Now.GetShortDateString();
            txtInvoiceTime.Text = DateTime.Now.ToString("hh:mm:ss");
            BindTable();
            BindParty();
            FillItemList();

            //this.KOTPrintOption = clsBConfiguration.GetConfigVal("KOT Print Option") == "1" ? true : false;
            //this.GroupWiseKOTPrint = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.GroupWiseKOTPrint) == "1" ? true : false;

            MakeSerieal();
            //this.kotIDs.Clear();
            //BindRunningKOT();
            GetNextInvoideNumber();

            this.PrintMessage = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.PrintMessage);
            this.ApplyGeneralDiscount = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.Discount) == "1" ? true : false;
            this.ApplyManualDiscount = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ManualDiscount) == "1" ? true : false;
            this.CompusaryBillPrint = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillPrintOption) == "1" ? true : false;
            this.ServiceTaxEnabled = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ServiceTaxEnabled) == "1" ? true : false;
            this.IsNormalUSer = false;

            //grdBill.Columns["Rate"].ReadOnly = !this.ApplyManualDiscount;
            txtManualDiscount.Enabled = this.ApplyManualDiscount;
            if (CurrentUser.ID == 0)
            {
                this.IsNormalUSer = true;
                this.CompulsaryBillPrintWhilenormalUser = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.PrintBillwhileLoginwithnormaluser) == "1" ? true : false;
                this.btnRemove.Enabled = false;
            }
            if (this.ApplyGeneralDiscount)
            {
                var value = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.DiscountPercentage);
                this.GeneralDiscountPercentage = value != string.Empty ? Convert.ToInt32(value) : 0;
                txtManualDiscount.Text = this.GeneralDiscountPercentage.ToString("0.00");
            }
            else
                this.GeneralDiscountPercentage = 0;
            if (this.ServiceTaxEnabled)
            {
                this.ServiceTaxPercentage = Convert.ToInt64(clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ServiceTaxPercentage));
                txtServiceTaxPercentage.Text = this.ServiceTaxPercentage.ToString();
            }
            else
            {
                this.ServiceTaxPercentage = 0;
                txtServiceTaxPercentage.Text = "0.00";
            }
            txtBillSeries.Text = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillSeries) + String.Format("{0}/{1}/{2}", "SALE", DateTime.Now.Year, DateTime.Now.Month);
            //clearControls();

            if (!clsBStockBalance.IsOpeningExists(DateTime.Now))
            {
                MessageBox.Show("You cannot do transaction without Start Day Transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }
        public void FillItemList()
        {
            itemlist = new List<ItemMasterDTO>();
            itemlist = clsBItemMaster.GetItemsForBilling();
        }
        private void BindParty()
        {
            var res = clsBCodeMaster.GetAllRecordsList("PARTY");
            ddlParty.DisplayMember = "Name";
            ddlParty.ValueMember = "ID";
            ddlParty.DataSource = res;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void txtCashReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumber(sender, e);
        }

        public void clearControls()
        {
            GetNextInvoideNumber();
            txtBillSeries.Text = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.BillSeries) + String.Format("{0}/{1}/{2}", "SALE", DateTime.Now.Year, DateTime.Now.Month);
            txtInvoiceDate.Text = DateTime.Now.Date.GetShortDateString();
            grdBill.Rows.Clear();
            ddlTableNo.SelectedIndex = 0;
            txtQuantity.Text = "0";
            txtCashReceived.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtServiceTax.Text = "0.00";
            txtDiscountReason.Text = string.Empty;
            txtChange.Text = "0.00";
            txtGrossAmount.Text = "0.00";
            txtRoundOffAmount.Text = "0.00";
            txtNetAmount.Text = "0.00";
            btnSave.Enabled = true;
            btnRemove.Enabled = false;
            grdBill.Rows[0].Cells["Name"].Selected = true;
            FillItemList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
            this.InvoiceID = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsItemExists())
            {
                SaveBill();
                //this.InvoiceID = 0;
            }
            else
            {
                MessageBox.Show("Please enter atleast one item.", "Information", MessageBoxButtons.OK);
            }
        }

        public void SaveBill()
        {
            //if (this.kotIDs == null || this.kotIDs.Count == 0)
            //{
            //    this.kotIDs.Add(SaveKOT());
            //}
            BillMasterDTO objMaster = new BillMasterDTO();
            objMaster.Series = txtBillSeries.Text;
            objMaster.Rnumber = Convert.ToInt32(txtBillNumber.Text);
            objMaster.InvoiceDate = DateTime.Now;
            objMaster.Party = txtName.Text;
            objMaster.PaymentMode = ddlParty.SelectedValue.ToString();
            objMaster.TableID = Convert.ToInt32(ddlTableNo.SelectedValue);
            //objMaster.KotIDs = this.kotIDs;
            objMaster.IsDeleted = false;
            objMaster.GrossAmount = Convert.ToDecimal(txtGrossAmount.Text == "" ? "0" : txtGrossAmount.Text);
            objMaster.NetAmount = Convert.ToDecimal(txtNetAmount.Text == "" ? "0" : txtNetAmount.Text);
            objMaster.CashReceived = Convert.ToDecimal(txtCashReceived.Text == "" ? "0" : txtCashReceived.Text);
            objMaster.RoundOff = Convert.ToDecimal(txtRoundOffAmount.Text == "" ? "0" : txtRoundOffAmount.Text);

            foreach (DataGridViewRow item in grdBill.Rows)
            {
                if (item.Cells["ItemID"] != null && item.Cells["Code"].Value != null)
                {
                    var detitem = new BillDetailsDTO()
                    {
                        ItemID = Convert.ToInt32(item.Cells["ItemID"].Value),
                        ItemCode = Convert.ToString(item.Cells["Code"].Value),
                        Rate = Convert.ToDecimal(item.Cells["Rate"].Value),
                        Quantity = Convert.ToDecimal(item.Cells["Quantity"].Value),
                        IsDeleted = false,
                    };
                    objMaster.details.Add(detitem);
                }
            }
            if (this.ApplyGeneralDiscount)
            {
                objMaster.DiscountPercentage = Convert.ToDecimal(txtManualDiscount.Text);
                objMaster.Discount = Convert.ToDecimal(txtDiscount.Text);
                objMaster.DiscountReason = txtDiscountReason.Text.Trim();
            }
            else
            {
                objMaster.DiscountPercentage = 0;
                objMaster.Discount = 0;
                objMaster.DiscountReason = "";
            }
            if (this.ServiceTaxEnabled)
            {
                objMaster.Tax = Convert.ToDecimal(txtServiceTax.Text);
            }
            objMaster.NoOfItems = objMaster.details.Count;
            int res = 0;
            if (this.InvoiceID == 0)
            {
                res = clsBBill.AddBill(objMaster);
                this.InvoiceID = res;
                //MessageBox.Show("Bill Saved Successfullly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.CompusaryBillPrint)
                    PrintBill();
                else if (this.IsNormalUSer && this.CompulsaryBillPrintWhilenormalUser)
                    PrintBill();

                //this.kotIDs.Clear();
                //BindRunningKOT();
                clearControls();
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
            ddlParty.SelectedText = obj.Party;
            txtName.Text = obj.Party;
            ddlTableNo.SelectedValue = obj.TableID;
            int srno = 1;
            foreach (var detail in obj.details)
            {
                grdBill.Rows.Add(srno, detail.ItemCode, detail.ItemName, detail.Unit, detail.Quantity, detail.Rate, (detail.Rate * detail.Quantity).ToString("0.00"), detail.ItemID);
                srno++;
            }
            txtGrossAmount.Text = obj.GrossAmount.GetDecimalString();
            txtDiscount.Text = obj.Discount.GetDecimalString();
            txtServiceTax.Text = obj.Tax.HasValue ? obj.Tax.Value.GetDecimalString() : "0.00";
            txtNetAmount.Text = obj.NetAmount.GetDecimalString();
            txtCashReceived.Text = obj.CashReceived.GetDecimalString();
            txtRoundOffAmount.Text = obj.RoundOff.GetDecimalString();
            txtDiscountReason.Text = obj.DiscountReason;
            txtManualDiscount.Text = obj.DiscountPercentage.GetDecimalString();
            //txtServiceTaxPercentage.Text = obj.taxper.HasValue ? obj.Tax.Value.GetDecimalString() : "0.00";
            //chkIsPrinted.Checked = obj.IsPrinted;
            if (obj.IsPrinted)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
            btnRemove.Enabled = true && !this.IsNormalUSer;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var currentID = Convert.ToInt32(txtBillNumber.Text);
            if (clsBBill.GetNextInvoiceNumber() - 1 > currentID)
            {
                var obj = clsBBill.GetBillDetail(currentID, Enumes.FecthRecord.Next.ToString());
                if (obj.BillID > 0)
                {
                    this.InvoiceID = obj.BillID;
                    Fillcontrols(obj);

                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var currentID = Convert.ToInt32(txtBillNumber.Text);
            var obj = clsBBill.GetBillDetail(currentID, Enumes.FecthRecord.Last.ToString());
            this.InvoiceID = obj.BillID;
            Fillcontrols(obj);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            clsBBill.Delete(Convert.ToInt32(this.txtBillNumber.Text));
            clearControls();
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
            POS_Reports.rptBill rptBill = new POS_Reports.rptBill(this.InvoiceID);
            rptBill.PrintReport();
            clsBBill.UpdatePrintFlagByRunningNumber(Convert.ToInt32(txtBillNumber.Text));
        }



        public void ButtonEnable(bool flag)
        {
            // btnPayLater.Enabled =
            btnSave.Enabled =
            btnCancel.Enabled =
            btnRemove.Enabled =
            btnPrint.Enabled = flag;
        }

        private void grdBill_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GetItemName(e);
        }
        private void grdBill_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MakeSerieal();
        }

        private void grdBill_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //GetItemName(e);
        }
        public void GetItemName(DataGridViewCellEventArgs e)
        {
            if (grdBill.CurrentRow != null)
            {
                ItemMasterDTO item = null;

                if (e.ColumnIndex == 1 && grdBill.CurrentRow.Cells["Code"].Value != null)
                {
                    item = itemlist.FirstOrDefault(x => x.ItemCode.ToUpper() == grdBill.CurrentRow.Cells["Code"].Value.ToString().ToUpper());// clsBItemMaster.GetItemByCode(grdBill.CurrentRow.Cells[1].Value.ToString());
                }
                else if (e.ColumnIndex == 2 && grdBill.CurrentRow.Cells["Name"].Value != null)
                {
                    item = itemlist.FirstOrDefault(x => x.ItemName.ToUpper() == grdBill.CurrentRow.Cells["Name"].Value.ToString().ToUpper());
                }
                else if (e.ColumnIndex == 3 && grdBill.CurrentRow.Cells["Quantity"].Value != null)
                {
                    CalculateDetails();
                }
                if (item != null)
                {
                    grdBill.CurrentRow.Cells["Code"].Value = item.ItemCode;
                    grdBill.CurrentRow.Cells["Name"].Value = item.ItemName;
                    grdBill.CurrentRow.Cells["Rate"].Value = item.Rate;
                    grdBill.CurrentRow.Cells["Unit"].Value = item.unit;
                    grdBill.CurrentRow.Cells["Quantity"].Value = 1;
                    //grdBill.CurrentRow.Cells["GrossAmount"].Value = (Convert.ToInt64(grdBill.CurrentRow.Cells["Rate"].Value) * Convert.ToInt64(grdBill.CurrentRow.Cells["Quantity"].Value)).ToString();
                    grdBill.CurrentRow.Cells["ItemID"].Value = item.ItemID;
                    CalculateDetails();
                }
                else
                {
                    CalculateDetails();
                }
            }
        }

        public void CalculateDetails()
        {

            decimal totalGross = 0, totalNetAmount = 0, totalServicetax = 0, totalDiscount = 0;
            int qty = 0;
            foreach (DataGridViewRow row in grdBill.Rows)
            {
                if (row.Cells["Code"].Value != null)
                {
                    string code = row.Cells["Code"].Value.ToString();
                    var item = itemlist.FirstOrDefault(x => x.ItemCode.ToUpper() == code.ToString().ToUpper());
                    if (item != null)
                    {
                        qty++;
                        decimal grossamount = 0;
                        //decimal discountamount = 0;
                        //decimal netamount = 0;
                        //decimal servicetaxamount = 0;
                        grossamount = (Convert.ToDecimal(row.Cells["Rate"].Value) * Convert.ToDecimal(row.Cells["Quantity"].Value));
                        //if (item.ServiceTax ?? false)
                        //{
                        //    servicetaxamount = (grossamount * (this.ServiceTaxPercentage / 100));
                        //    grossamount = grossamount - servicetaxamount;
                        //}

                        //if (this.ApplyGeneralDiscount)
                        //{
                        //    discountamount = grossamount * (this.GeneralDiscountPercentage / 100);
                        //}
                        //else if (this.ApplyManualDiscount)
                        //{
                        //    discountamount = grossamount * (Convert.ToDecimal(txtManualDiscount.Text.Trim() == "" ? "0" : txtManualDiscount.Text.Trim()) / 100);
                        //}
                        //netamount = (grossamount + servicetaxamount - discountamount);

                        row.Cells["Unit"].Value = item.unit;
                        //row.Cells["ServiceTax"].Value = servicetaxamount.ToString("0.00");
                        //row.Cells["Discount"].Value = discountamount.ToString("0.00");
                        row.Cells["GrossAmount"].Value = grossamount.ToString("0.00");
                        //row.Cells["Amount"].Value = (grossamount + servicetaxamount).ToString("0.00");

                        totalGross += grossamount;
                        //totalNetAmount += netamount;
                        //totalSalestax += servicetaxamount;
                        //totalDiscount += discountamount;
                    }
                }
            }
            txtGrossAmount.Text = totalGross.ToString("0.00");
            totalDiscount = totalGross * Convert.ToDecimal(txtManualDiscount.Text.Trim() == "" ? "0" : txtManualDiscount.Text.Trim()) / 100;
            txtDiscount.Text = totalDiscount.ToString("0.00");

            totalServicetax = (totalGross - totalDiscount) * Convert.ToDecimal(txtServiceTaxPercentage.Text.Trim() == "" ? "0" : txtServiceTaxPercentage.Text.Trim()) / 100;
            txtServiceTax.Text = totalServicetax.ToString("0.00");

            totalNetAmount = totalGross - totalDiscount + totalServicetax;
            txtNetAmount.Text = totalNetAmount.ToString("0.00");

            txtQuantity.Text = qty.ToString();
            txtCashReceived.Text = totalNetAmount.ToString("0.00");

        }

        private void grdBill_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = grdBill.Columns[((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex].HeaderText;

            if (titleText.Equals("Item Name"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(DataCollection, 1);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
            else if (titleText.Equals("Code"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(DataCollection, 2);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        public void addItems(AutoCompleteStringCollection col, int id)
        {
            if (id == 1)
            {
                string[] res = itemlist.Select(x => x.ItemName).ToArray();
                col.AddRange(res);
            }
            else
            {
                string[] res = itemlist.Select(x => x.ItemCode).ToArray();
                col.AddRange(res);
            }
        }




        public bool IsItemExists()
        {

            foreach (DataGridViewRow row in grdBill.Rows)
            {
                if (!String.IsNullOrWhiteSpace(Convert.ToString(row.Cells["ItemID"].Value)))
                {
                    return true;
                    //objMaster.detailList.Add(new KOTDetailDTO() { ItemID = Convert.ToInt32(row.Cells["ItemID"].Value), Quantity = Convert.ToDecimal(row.Cells["Quantity"].Value) });
                }
            }
            return false;
        }



        private void grdBill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = grdBill.CurrentCell.ColumnIndex;
                int iRow = grdBill.CurrentCell.RowIndex;
                if (iColumn == 1)
                {
                    grdBill.CurrentCell = grdBill[2, iRow - 1];
                }
                else if (iColumn == 2)
                {
                    grdBill.CurrentCell = grdBill[4, iRow - 1];
                }
                else if (iColumn == 4)
                {
                    grdBill.CurrentCell = grdBill[5, iRow - 1];
                }
                if (iColumn == 5)
                    grdBill.CurrentCell = grdBill[1, iRow];
            }
        }

        private void txtManualDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //decimal grossAmount = Convert.ToDecimal(txtGrossAmount.Text);
            //decimal discountAmount = Convert.ToDecimal(txtDiscount.Text);
            //txtDiscount.Text = (grossAmount * Convert.ToDecimal(txtManualDiscount.Text.Trim() == "" ? "0" : txtManualDiscount.Text.Trim()) / 100).ToString("0.00");
            //CalculateDetails();
            //txtDiscount.Text= grossAmount.


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F12))
            {
                SaveBill();
                return true;
            }
            //else if (keyData == (Keys.Left))
            //{
            //    btnPrevious_Click(null, null);
            //    return true;
            //}
            //else if (keyData == (Keys.Right))
            //{
            //    btnNext_Click(null, null);
            //    return true;
            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtManualDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateDetails();
        }
    }
}
