using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using POS.BAL;
using POS.Classes;
using POS.DTO;
using POS.Utilities;
namespace POS
{
    public partial class InwardReturn : Form
    {

        #region "Properties"
        public long PurchaseReturnID { get; set; }
        public bool IsNormalUSer { get; set; }
        public List<PurchaseDetailDTO> itemlist { get; set; }
        #endregion

        #region ControlEvents
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
            this.PurchaseReturnID = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckRequiredFields())
            {
                SavePurchaseReturn();
                this.PurchaseReturnID = 0;
            }

        }
        private void txtInvoiceAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterOnlyNumber(sender, e);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearControls();
            this.PurchaseReturnID = 0;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            clsBPurchaseReturn.Delete(this.PurchaseReturnID);
            clearControls();
            this.PurchaseReturnID = 0;
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
            BindPurchaseReturnGrid();
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
                    grdBill.CurrentCell = grdBill[4, iRow - 1];
                }
                else if (iColumn == 2)
                {
                    grdBill.CurrentCell = grdBill[4, iRow - 1];
                }
                else if (iColumn == 4)
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
            this.PurchaseReturnID = Convert.ToInt32(grdPurchase.Rows[rowid].Cells[0].Value);
            this.Fillcontrols(clsBPurchaseReturn.GetByID(this.PurchaseReturnID));
        }
        #endregion

        #region CommonMethods
        private void BindInvoiceNumbers()
        {
            ddlInvoiceNumber.DisplayMember = "InvoiceNumber";
            ddlInvoiceNumber.ValueMember = "PurchaseID";
            var res = clsBInward.GetAll().OrderByDescending(x => x.PurchaseID).ToList();
            ddlInvoiceNumber.DataSource = res;
        }
        public void FillItemList()
        {
            itemlist = new List<PurchaseDetailDTO>();
            itemlist = clsBInward.GetByID(Convert.ToInt64(ddlInvoiceNumber.SelectedValue)).PurchaseDetailList;
            //itemlist = clsBItemMaster.GetItems("", true, null);
        }
        private void BindPurchaseReturnGrid()
        {
            var res = clsBPurchaseReturn.GetAll().OrderByDescending(x => x.ID).ToList();
            grdPurchase.DataSource = res;
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
            txtReturnDate.Text = DateTime.Now.Date.GetShortDateString();
            txtReasonForReturn.Text = string.Empty;
            ddlInvoiceNumber.SelectedIndex = -1;

            grdBill.Rows.Clear();
            btnSave.Enabled = true;
            btnRemove.Enabled = false;

        }
        private bool CheckRequiredFields()
        {
            TextBox[] newTextBox = { txtReturnDate };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please fill the text box");
                    newTextBox[inti].Focus();
                    return false;
                }
            }
            if (ddlInvoiceNumber.SelectedItem == null)
            {
                MessageBox.Show("Please select purchase invoice number");
                return false;
            }

            return true;
        }
        public void SavePurchaseReturn()
        {
            PurchaseReturnMasterDTO objMaster = new PurchaseReturnMasterDTO();
            objMaster.ID = this.PurchaseReturnID;
            objMaster.ReturnDate = txtReturnDate.Text.GetDateTime();
            objMaster.PurchaseID = ((PurchaseMasterDTO)(ddlInvoiceNumber.SelectedItem)).PurchaseID;
            objMaster.ReasonForReturn = txtReasonForReturn.Text;

            if (this.PurchaseReturnID == 0)
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
                    var detitem = new PurchaseReturnDetailDTO()
                    {
                        ID = Convert.ToInt32(item.Cells["PurchaseDetailID"].Value),
                        ItemID = Convert.ToInt32(item.Cells["ItemID"].Value),
                        ItemCode = Convert.ToString(item.Cells["Code"].Value),
                        //PurchaseDetailID = Convert.ToInt64(item.Cells["PurchaseDetailID"].Value == null ? "0" : item.Cells["PurchaseDetailID"].Value.ToString()),
                        Qty = Convert.ToDecimal(item.Cells["Quantity"].Value),
                        //Description = Convert.ToString(item.Cells["Description"].Value),
                        //PricePerItem = Convert.ToDecimal(item.Cells["PricePerItem"] == null ? new Nullable<decimal>() : item.Cells["PricePerItem"].Value),
                        IsDeleted = false,
                    };
                    objMaster.PurchaseReturnDetailList.Add(detitem);
                }
            }
            if (objMaster.PurchaseReturnDetailList.Count == 0)
            {
                MessageBox.Show("Please add atleast one item", "Validation Error", MessageBoxButtons.OK);
                return;
            }

            long res = 0;
            if (this.PurchaseReturnID == 0)
            {
                res = clsBPurchaseReturn.Create(objMaster);
                MessageBox.Show("Record saved successfully", "Success");
                clearControls();
            }
            else
            {
                clsBPurchaseReturn.Update(objMaster);
                MessageBox.Show("Record saved successfully", "Success");
                clearControls();
            }
        }
        public void Fillcontrols(PurchaseReturnMasterDTO obj)
        {
            clearControls();
            foreach (PurchaseMasterDTO item in ddlInvoiceNumber.Items)
            {
                if (item.PurchaseID == obj.PurchaseID)
                {
                    ddlInvoiceNumber.SelectedItem = item;
                    break;
                }
            }
            obj.PurchaseID.ToString();
            txtReturnDate.Text = obj.ReturnDate.GetShortDateString();
            txtReasonForReturn.Text = obj.ReasonForReturn;
            int srno = 1;
            foreach (var detail in obj.PurchaseReturnDetailList)
            {
                grdBill.Rows.Add(srno, detail.ItemCode, detail.ItemName, detail.Unit, detail.Qty, detail.ItemID, detail.ID);
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
                PurchaseDetailDTO item = null;

                if (e.ColumnIndex == 1 && grdBill.CurrentRow.Cells["Code"].Value != null)
                {
                    item = itemlist.FirstOrDefault(x => x.ItemCode.ToLower() == grdBill.CurrentRow.Cells["Code"].Value.ToString().ToLower());// clsBItemMaster.GetItemByCode(grdBill.CurrentRow.Cells[1].Value.ToString());
                }
                else if (e.ColumnIndex == 2 && grdBill.CurrentRow.Cells["Name"].Value != null)
                {
                    item = itemlist.FirstOrDefault(x => x.ItemName == grdBill.CurrentRow.Cells["Name"].Value.ToString());
                }
                else if (grdBill.CurrentRow.Cells["Quantity"].Value != null)
                {
                    CalculateDetails();
                }
                if (item != null)
                {
                    grdBill.CurrentRow.Cells["Code"].Value = item.ItemCode;
                    grdBill.CurrentRow.Cells["Name"].Value = item.ItemName;
                    grdBill.CurrentRow.Cells["Unit"].Value = item.Unit;
                    grdBill.CurrentRow.Cells["Quantity"].Value = 1;
                    grdBill.CurrentRow.Cells["Rate"].Value = item.PricePerItem;
                    grdBill.CurrentRow.Cells["ItemID"].Value = item.ItemID;
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
        public void CalculateDetails()
        {
            decimal  totalAmount = 0; 
            decimal amount = 0;
            foreach (DataGridViewRow item in grdBill.Rows)
            {
                amount = 0;
                if (item.Cells["ItemID"] != null  && item.Cells["Quantity"] != null && item.Cells["Rate"] != null)
                amount  = Convert.ToDecimal(item.Cells["Quantity"].Value) * Convert.ToDecimal(item.Cells["Rate"].Value);
                item.Cells["Amount"].Value = amount.GetDecimalString();
                totalAmount = totalAmount + amount;
            }
        }



        #endregion

        #region PageEvent
        public InwardReturn()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            this.Load += new EventHandler(InwardReturn_Load);
            grdBill.AutoGenerateColumns = false;
            grdPurchase.AutoGenerateColumns = false;
        }
        private void InwardReturn_Load(object sender, EventArgs e)
        {
            bool IsManageInventory = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.ManageInventory) == "1";
            if (!clsBStockBalance.IsOpeningExists(DateTime.Now) && IsManageInventory)
            {
                MessageBox.Show("You cannot do transaction without Start Day Transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
            txtReturnDate.Text = DateTime.Now.GetShortDateString();
            BindInvoiceNumbers();
            //FillItemList();

            MakeSerieal();
            clearControls();
            pnlSearch.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F12))
            {
                SavePurchaseReturn();
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

        private void ddlInvoiceNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdBill.Rows.Clear();
            FillItemList();
        }




    }
}
