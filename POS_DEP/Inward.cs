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
    public partial class Inward : Form
    {

        #region "Properties"
        public long MasterPurchaseID { get; set; }
        public bool IsNormalUSer { get; set; }
        public List<ItemMasterDTO> itemlist { get; set; }
        #endregion

        #region ControlEvents
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
            this.MasterPurchaseID = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckRequiredFields())
            {
                SavePurchase();
                this.MasterPurchaseID = 0;
            }

        }
        private void txtInvoiceAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumber(sender, e);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearControls();
            this.MasterPurchaseID = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            clsBInward.Delete(this.MasterPurchaseID);
            clearControls();
            this.MasterPurchaseID = 0;
        }



        private void grdBill_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GetItemName(e);
        }

        private void grdBill_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MakeSerieal();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = true;
            BindPurchaseGrid();
        }



        private void btnPanelClose_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = false;
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
            //else if (titleText.Equals("Code"))
            //{
            //    TextBox autoText = e.Control as TextBox;
            //    if (autoText != null)
            //    {
            //        autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
            //        autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //        AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            //        addItems(DataCollection, 2);
            //        autoText.AutoCompleteCustomSource = DataCollection;
            //    }
            //}
            else
            {
                TextBox autoText = e.Control as TextBox;
                autoText.AutoCompleteMode = AutoCompleteMode.None;
            }
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
                    grdBill.CurrentCell = grdBill[3, iRow - 1];
                }
                else if (iColumn == 3)
                {
                    grdBill.CurrentCell = grdBill[5, iRow - 1];
                }
                else if (iColumn == 5)
                {
                    grdBill.CurrentCell = grdBill[6, iRow - 1];
                }
                else if (iColumn == 6)
                {
                    grdBill.CurrentCell = grdBill[7, iRow - 1];
                }
                else if (iColumn == 7)
                    grdBill.CurrentCell = grdBill[1, iRow];
            }
            else if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    grdBill.Rows.RemoveAt(grdBill.CurrentCell.RowIndex);
                    CalculateDetails();
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void grdPurchase_DoubleClick(object sender, EventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            this.MasterPurchaseID = Convert.ToInt32(grdPurchase.Rows[rowid].Cells[0].Value);
            this.Fillcontrols(clsBInward.GetByID(this.MasterPurchaseID));
        }
        #endregion

        #region CommonMethods
        public void FillItemList()
        {
            itemlist = new List<ItemMasterDTO>();
            itemlist = clsBItemMaster.GetItems("", true, null);
        }
        private void BindPurchaseGrid()
        {
            grdPurchase.DataSource = clsBInward.GetAll().OrderByDescending(x => x.PurchaseID).ToList();
        }
        private void BindVendor()
        {
            var res = clsBCompanyMaster.GetAllRecordsList();
            ddlVandor.DisplayMember = "CompanyName";
            ddlVandor.ValueMember = "Id";
            ddlVandor.DataSource = res;
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
        public void clearControls()
        {
            txtInvoiceDate.Text = DateTime.Now.Date.GetShortDateString();
            ddlVandor.SelectedIndex = -1;
            txtInvoiceNumber.Text =
                txtPONumber.Text =
                txtReceivedBy.Text =
                txtRemarks.Text =
                txtInvoiceAmount.Text = string.Empty;

            txtInvoiceNumber.Text = "PURC/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString("00") + "/" + clsBInward.GetNextInwardNumber();
            txtInvoiceDate.Text = DateTime.Now.GetShortDateString();

            grdBill.Rows.Clear();
            btnSave.Enabled = true;
            btnRemove.Enabled = false;
        }
        private bool CheckRequiredFields()
        {
            TextBox[] newTextBox = { txtInvoiceNumber, txtInvoiceDate, txtReceivedBy, txtInvoiceAmount };
            string[] title = { "Invoice No.", "Invoice Date", "Received By", "Invoice Amount" };

            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please fill the value in " + title[inti]);
                    newTextBox[inti].Focus();
                    return false;
                }
            }
            return true;
        }
        public void SavePurchase()
        {
            PurchaseMasterDTO objMaster = new PurchaseMasterDTO();
            objMaster.PurchaseID = this.MasterPurchaseID;
            objMaster.PONumber = txtPONumber.Text.Trim();
            if (!string.IsNullOrEmpty(dtPODate.Text))
                objMaster.PODate = dtPODate.Value;
            objMaster.InvoiceDate = DateTime.Now;
            objMaster.InvoiceNumber = txtInvoiceNumber.Text.Trim();
            objMaster.VendorID = Convert.ToInt32(ddlVandor.SelectedValue);
            objMaster.ReceivedBy = txtReceivedBy.Text.Trim();
            objMaster.Remarks = txtRemarks.Text.Trim();
            objMaster.InvoiceAmount = Convert.ToDecimal(txtInvoiceAmount.Text.Trim());
            objMaster.Career = "";

            if (this.MasterPurchaseID == 0)
            {
                objMaster.IsDeleted = false;
                objMaster.CreatedBy = CurrentUser.ID;
                objMaster.CreatedDate = DateTime.Now;
            }
            else
            {
                objMaster.UpdatedBy = CurrentUser.ID;
                objMaster.UpdatedDate = DateTime.Now;
            }

            foreach (DataGridViewRow item in grdBill.Rows)
            {
                if (item.Cells["ItemID"] != null && item.Cells["Code"].Value != null)
                {
                    var detitem = new PurchaseDetailDTO()
                    {
                        ItemID = Convert.ToInt32(item.Cells["ItemID"].Value),
                        ItemCode = Convert.ToString(item.Cells["Code"].Value),
                        PurchaseDetailID = Convert.ToInt64(item.Cells["PurchaseDetailID"].Value == null ? "0" : item.Cells["PurchaseDetailID"].Value.ToString()),
                        Quantity = Convert.ToDecimal(item.Cells["Quantity"].Value),
                        Description = Convert.ToString(item.Cells["Description"].Value),
                        PricePerItem = Convert.ToDecimal(item.Cells["PricePerItem"] == null ? new Nullable<decimal>() : item.Cells["PricePerItem"].Value),
                        MRPPerItem = Convert.ToDecimal(item.Cells["MRP"] == null ? new Nullable<decimal>() : item.Cells["MRP"].Value),
                        barcodes = item.Cells["barcodes"].Value != null ? item.Cells["barcodes"].Value.ToString().Split(',').ToList() : null,
                        IsDeleted = false,
                    };
                    objMaster.PurchaseDetailList.Add(detitem);
                }
            }
            if (objMaster.PurchaseDetailList.Count == 0)
            {
                MessageBox.Show("Please enter atleast one item", "Validation Error", MessageBoxButtons.OK);
                return;
            }

            long res = 0;
            if (this.MasterPurchaseID == 0)
            {
                res = clsBInward.Create(objMaster);
                MessageBox.Show("Record saved successfully", "Success");
                clearControls();
            }
            else
            {
                clsBInward.Update(objMaster);
                MessageBox.Show("Record saved successfully", "Success");
                clearControls();
            }
        }
        public void CalculateDetails()
        {
            decimal totalGross = 0;
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
                        grossamount = (Convert.ToDecimal(row.Cells["PricePerItem"].Value) * Convert.ToDecimal(row.Cells["Quantity"].Value));
                        totalGross += grossamount;
                    }
                }
            }
            txtInvoiceAmount.Text = totalGross.ToString("0.00");
        }

        public void Fillcontrols(PurchaseMasterDTO obj)
        {
            clearControls();
            txtInvoiceNumber.Text = obj.InvoiceNumber;
            txtInvoiceDate.Text = obj.InvoiceDate.Value.GetShortDateString();
            txtPONumber.Text = obj.PONumber;
            if (obj.PODate.HasValue) dtPODate.Value = obj.PODate.Value;
            txtRemarks.Text = obj.Remarks;
            txtInvoiceAmount.Text = obj.InvoiceAmount.ToString("0.00");
            txtReceivedBy.Text = obj.ReceivedBy;

            foreach (CompanyMasterDTO item in ddlVandor.Items)
            {
                if (item.Id == obj.VendorID)
                {
                    ddlVandor.SelectedItem = item;
                    break;
                }
            }
            //ddlVandor.SelectedValue = obj.VendorID.ToString();  //obj.VendorID.ToString();

            int srno = 1;
            foreach (var detail in obj.PurchaseDetailList)
            {
                grdBill.Rows.Add(srno, detail.ItemCode, detail.ItemName, detail.Description, detail.Unit, detail.Quantity, detail.PricePerItem, detail.MRPPerItem, detail.ItemID, detail.PurchaseDetailID);
                srno++;
            }
            btnRemove.Enabled = true && !this.IsNormalUSer;
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
        public void ButtonEnable(bool flag)
        {
            btnSave.Enabled =
            btnCancel.Enabled =
            btnRemove.Enabled = flag;
        }
        public void GetItemName(DataGridViewCellEventArgs e)
        {
            if (grdBill.CurrentRow != null)
            {
                ItemMasterDTO item = null;

                //if (e.ColumnIndex == 1 && grdBill.CurrentRow.Cells["Code"].Value != null)
                //{
                //    item = itemlist.FirstOrDefault(x => x.ItemCode == grdBill.CurrentRow.Cells["Code"].Value.ToString());// clsBItemMaster.GetItemByCode(grdBill.CurrentRow.Cells[1].Value.ToString());
                //}
                //else 
                if (e.ColumnIndex == 2 && grdBill.CurrentRow.Cells["Name"].Value != null)
                {
                    item = itemlist.FirstOrDefault(x => x.ItemName == grdBill.CurrentRow.Cells["Name"].Value.ToString());
                }
                else if (e.ColumnIndex == 6 && grdBill.CurrentRow.Cells["Quantity"].Value != null)
                {
                    CalculateDetails();
                }
                if (item != null)
                {
                    grdBill.CurrentRow.Cells["Code"].Value = item.ItemCode;
                    grdBill.CurrentRow.Cells["Name"].Value = item.ItemName;
                    grdBill.CurrentRow.Cells["Unit"].Value = item.unit;
                    grdBill.CurrentRow.Cells["Quantity"].Value = 1;
                    grdBill.CurrentRow.Cells["ItemID"].Value = item.ItemID;

                    if ((item.IsUniqueSerialNumber ?? false))
                    {
                        using (var objChildform = new frmGetBarcode())
                        {
                            var result = objChildform.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                string barcodes = String.Join(",", objChildform.barcodes);
                                grdBill.CurrentRow.Cells["Quantity"].Value = objChildform.barcodes.Count;
                                grdBill.CurrentRow.Cells["barcodes"].Value = barcodes;
                            }
                        }
                    }
                    CalculateDetails();
                }
                else
                {
                    CalculateDetails();
                }
                grdBill.BeginEdit(true);
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
        #endregion

        #region PageEvent
        public Inward()
        {
            InitializeComponent();
        }
        private void Inward_Load(object sender, EventArgs e)
        {

            if (!clsBStockBalance.IsOpeningExists(DateTime.Now) && clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ManageInventory) == "1")
            {
                MessageBox.Show("You cannot do transaction without Start Day Transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            grdBill.AutoGenerateColumns = false;
            grdPurchase.AutoGenerateColumns = false;
            txtInvoiceDate.Text = DateTime.Now.GetShortDateString();

            BindVendor();
            FillItemList();

            MakeSerieal();
            clearControls();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F12))
            {
                SavePurchase();
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


        #endregion


    }
}
