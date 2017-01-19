using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using POS.Classes;
using System.Windows.Forms;
using POS.BAL;
using POS.DTO;

namespace POS
{
    public partial class ItemMaster : Form
    {
        int ItemID = 0;
        bool IsManageInventory = false;
        List<string> barcodes = new List<string>();
        public ItemMaster()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);

            EnableSortmode();
            BindUnit();
            BindGroup();
            BindGrid();
            BindFrim();
            SetButtonEnableDisable();
            IsManageInventory = clsBConfiguration.GetConfigVal("ManageInventory") == "1";
        }

        #region Button Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemMasterDTO objToAdd = new ItemMasterDTO();
            if (String.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                MessageBox.Show("Please enter Item Code", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter Item Name", "Information");
                return;
            }
            if (clsBItemMaster.isExistCode(txtItemCode.Text.Trim(), this.ItemID))
            {
                MessageBox.Show("Item code already used. Please try using another code.", "Information");
                return;
            }
            objToAdd.ItemCode = txtItemCode.Text;
            objToAdd.ItemName = txtItemName.Text;
            objToAdd.GroupID = Convert.ToInt16(ddlGroup.SelectedValue);
            objToAdd.UnitID = Convert.ToInt16(ddlUnit.SelectedValue);
            objToAdd.Discount = Convert.ToDecimal(txtDiscountRate.Text == "" ? "0" : txtDiscountRate.Text);
            objToAdd.Rate = Convert.ToInt64(txtItemRate.Text == "" ? "0" : txtItemRate.Text);
            objToAdd.OtherDiscount = Convert.ToDecimal(txtOtherDiscount.Text == "" ? "0" : txtOtherDiscount.Text);
            objToAdd.FirmId = Convert.ToInt16(ddlFirm.SelectedValue);
            objToAdd.ServiceTax = chkServiceTax.Checked;
            objToAdd.IsActive = chkStatus.Checked;
            objToAdd.IsSaleable = chkIsSaleable.Checked;
            objToAdd.IsUniqueSerialNumber = chIsUniqueSerialNumber.Checked;
            if (chIsUniqueSerialNumber.Checked)
            {
                objToAdd.barcodes = barcodes;
            }
            objToAdd.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text == string.Empty ? "0" : txtOpeningBalance.Text);

            if (ItemID > 0)
            {
                objToAdd.ItemID = ItemID;
                clsBItemMaster.Update(objToAdd);
                MessageBox.Show("Item successfully updated", "Success");
                ClearControls();
                BindGrid(objToAdd.ItemCode);
                this.ItemID = 0;
            }
            else
            {
                clsBItemMaster.Add(objToAdd);
                MessageBox.Show("Item successfully added", "Success");
                ClearControls();
                BindGrid();
                this.ItemID = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            this.ItemID = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            Modify_Delete("m");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (grdItems.Rows.Count > 0)
            {
                this.ItemID = Convert.ToInt32(grdItems.Rows[0].Cells[0].Value);
                grdItems.Rows[0].Selected = true;
                EditData(this.ItemID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (grdItems.Rows.Count > 0)
            {
                this.ItemID = Convert.ToInt32(grdItems.Rows[grdItems.Rows.Count - 1].Cells[0].Value);
                grdItems.Rows[grdItems.Rows.Count - 1].Selected = true;
                EditData(this.ItemID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (grdItems.SelectedRows != null)
            {
                int currentIndex = grdItems.SelectedRows.Count > 0 ? grdItems.SelectedRows[0].Index : 0;
                if (currentIndex < grdItems.Rows.Count - 1)
                {
                    this.ItemID = Convert.ToInt32(grdItems.Rows[currentIndex + 1].Cells[0].Value);
                    grdItems.Rows[currentIndex + 1].Selected = true;
                    EditData(this.ItemID);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (grdItems.SelectedRows != null)
            {
                int currentIndex = grdItems.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    this.ItemID = Convert.ToInt32(grdItems.Rows[currentIndex - 1].Cells[0].Value);
                    grdItems.Rows[currentIndex - 1].Selected = true;
                    EditData(this.ItemID);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Modify_Delete("d");
        }
        #endregion

        #region Grid and Control Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdItems_DoubleClick(object sender, EventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            this.ItemID = Convert.ToInt32(grdItems.Rows[rowid].Cells[0].Value);
            this.EditData(this.ItemID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.enterOnlyNumber(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BindGrid();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemid"></param>
        private void EditData(int itemid)
        {
            var item = clsBItemMaster.GetItems(itemid);
            txtItemCode.Text = item.ItemCode;
            txtItemName.Text = item.ItemName;
            txtItemRate.Text = item.Rate.Value.ToString("00");
            txtOtherDiscount.Text = item.OtherDiscount.Value.ToString("00");
            ddlGroup.SelectedValue = item.GroupID;
            ddlUnit.SelectedValue = item.UnitID;
            ddlFirm.SelectedValue = item.FirmId;
            chkStatus.Checked = item.IsActive ?? false;
            chkServiceTax.Checked = item.ServiceTax ?? false;
            chkIsSaleable.Checked = item.IsSaleable;
            chIsUniqueSerialNumber.Checked = item.IsUniqueSerialNumber.HasValue ? item.IsUniqueSerialNumber.Value : false;
            chIsUniqueSerialNumber.Enabled = false;
            txtOpeningBalance.Text = item.OpeningBalance.HasValue ? item.OpeningBalance.Value.ToString() : "0";
            txtOpeningBalance.Enabled = !clsBStockBalance.IsItemExistsInStockBalance(itemid);
        }
        /// <summary>
        /// 
        /// </summary>
        public void SetButtonEnableDisable()
        {
            //    if (grdItems.Rows.Count == 0)
            //    {
            //        btnNext.Enabled = false;
            //        btnPrevious.Enabled = false;
            //        btnFirst.Enabled = false;
            //        btnLast.Enabled = false; 
            //    }
            //    else if (grdItems.Rows.Count > 0)
            //    {
            //        var row = grdItems.SelectedRows;
            //        if (row != null)
            //        {
            //            this.ItemID = row[0].Index;
            //            EditData(this.ItemID);
            //        }
            //    }
        }
        /// <summary>
        /// 
        /// </summary>
        private void EnableSortmode()
        {
            foreach (DataGridViewColumn column in grdItems.Columns)
            {
                grdItems.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindUnit()
        {
            List<CodeMasterDTO> lst = clsBCodeMaster.GetAllRecordsList("UN");
            ddlUnit.DataSource = lst;
            ddlUnit.DisplayMember = "Name";
            ddlUnit.ValueMember = "ID";
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGroup()
        {


            List<CodeMasterDTO> lst = clsBCodeMaster.GetAllRecordsList("GR");
            ddlGroup.DataSource = lst;
            ddlGroup.DisplayMember = "Name";
            ddlGroup.ValueMember = "ID";
        }
        public void BindFrim()
        {
            List<CodeMasterDTO> lst = clsBCodeMaster.GetAllRecordsList("FM");
            ddlFirm.DataSource = lst;
            ddlFirm.DisplayMember = "Name";
            ddlFirm.ValueMember = "ID";
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid(string code = "")
        {
            var lst = clsBItemMaster.GetItems(txtSearch.Text.Trim(), null, null);
            grdItems.AutoGenerateColumns = false;
            grdItems.DataSource = lst;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearControls()
        {
            txtItemCode.Text = txtItemName.Text = "";
            txtDiscountRate.Text = txtItemRate.Text = txtOtherDiscount.Text = "0";
            grdItems.ClearSelection();
            ddlGroup.SelectedIndex = -1;
            ddlUnit.SelectedIndex = -1;
            chkServiceTax.Checked = false;
            chkStatus.Checked = false;
            chkIsSaleable.Checked = false;
            ddlFirm.SelectedIndex = -1;
            chIsUniqueSerialNumber.Checked = false;
            txtOpeningBalance.Text = "";
            txtOpeningBalance.Enabled = true;
            chIsUniqueSerialNumber.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void Modify_Delete(string flag)
        {
            var row = grdItems.SelectedRows;
            if (row != null && row.Count > 0)
            {
                this.ItemID = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.ItemID);
                else if (flag.ToLower() == "d")
                {
                    if (clsBItemMaster.Delete(this.ItemID))
                    {
                        BindGrid();
                        MessageBox.Show("Item successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Item cannot deleted. because it is used as reference.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select any record from list.", "information");
                return;
            }
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
        #endregion

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            lblAvailableBalance.Visible = txtOpeningBalance.Visible = IsManageInventory;
        }

        private void chIsUniqueSerialNumber_Click(object sender, EventArgs e)
        {
            if (chIsUniqueSerialNumber.Checked)
            {
                using (var objChildform = new frmGetBarcode())
                {
                    var result = objChildform.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        barcodes = objChildform.barcodes;
                        txtOpeningBalance.Text = objChildform.barcodes.Count.ToString();
                    }
                    else
                    {
                        chIsUniqueSerialNumber.Checked = false;
                    }
                }
            }
        }
    }
}
