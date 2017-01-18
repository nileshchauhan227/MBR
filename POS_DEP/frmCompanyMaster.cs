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

namespace POS
{
    public partial class frmCompanyMaster : Form
    {
        int CompanyId = 0;
        public frmCompanyMaster()
        {
            InitializeComponent();
            this.DefaultProperty();
            this.EnableSortmode();
            this.BindGrid();
        }

        #region Control Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            CompanyMasterDTO objToAdd = new CompanyMasterDTO();
            
            if (String.IsNullOrWhiteSpace(this.txtCompanyName.Text))
            {
                MessageBox.Show("Please enter Company Name", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtCompanyAddress.Text))
            {
                MessageBox.Show("Please enter Company Addresss", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtPhoneNo.Text))
            {
                MessageBox.Show("Please enter Phone No", "Information");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtMobileNo.Text))
            {
                
                    MessageBox.Show("Please enter Mobile No", "Information");
                    return;
                
            }
            if (string.IsNullOrWhiteSpace(this.txtEmailId.Text))
            {

                MessageBox.Show("Please enter Email Id", "Information");
                return;

            }
            objToAdd.CompanyName = this.txtCompanyName.Text;
            objToAdd.CompanyAddress = this.txtCompanyAddress.Text;
            objToAdd.PhoneNo = this.txtPhoneNo.Text;
            objToAdd.MobileNo = this.txtMobileNo.Text; 
            objToAdd.EmailId = this.txtEmailId.Text; 
            objToAdd.CreatedDate = objToAdd.UpdatedDate = DateTime.Now;
            objToAdd.IsDeleted = false;
            if (CompanyId > 0)
            {
                objToAdd.Id = CompanyId;
                clsBCompanyMaster.Update(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.CompanyId = 0;
                MessageBox.Show("Company details successfully updated", "Success");
            }
            else
            {
                clsBCompanyMaster.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.CompanyId = 0;
                MessageBox.Show("Company details successfully added", "Success");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Modify_Delete("M");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearControls();
            this.CompanyId = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (this.grdCode.Rows.Count > 0)
            {
                this.CompanyId = Convert.ToInt32(this.grdCode.Rows[0].Cells[0].Value);
                this.grdCode.Rows[0].Selected = true;
                EditData(this.CompanyId);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.grdCode.Rows.Count > 0)
            {
                this.CompanyId = Convert.ToInt32(this.grdCode.Rows[this.grdCode.Rows.Count - 1].Cells[0].Value);
                this.grdCode.Rows[this.grdCode.Rows.Count - 1].Selected = true;
                EditData(this.CompanyId);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.grdCode.SelectedRows != null)
            {
                int currentIndex = this.grdCode.SelectedRows[0].Index;
                if (currentIndex < this.grdCode.Rows.Count - 1)
                {
                    this.CompanyId = Convert.ToInt32(this.grdCode.Rows[currentIndex + 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex + 1].Selected = true;
                    EditData(this.CompanyId);
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
            if (this.grdCode.SelectedRows != null)
            {
                int currentIndex = this.grdCode.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    this.CompanyId = Convert.ToInt32(this.grdCode.Rows[currentIndex - 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex - 1].Selected = true;
                    EditData(this.CompanyId);
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
            this.Modify_Delete("d");
        }
        private void grdCode_DoubleClick(object sender, EventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            this.CompanyId = Convert.ToInt32(this.grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.CompanyId);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        private void ClearControls()
        {
            this.txtCompanyAddress.Text = string.Empty; ;
            this.txtCompanyName.Text = string.Empty;
            this.txtPhoneNo.Text = string.Empty;
            this.txtMobileNo.Text = string.Empty;
            this.txtEmailId.Text = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid()
        {
            var lst = clsBCompanyMaster.GetItems(txtSearch.Text.Trim());
            this.grdCode.AutoGenerateColumns = false;
            this.grdCode.DataSource = lst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void Modify_Delete(string flag)
        {
            var row = this.grdCode.SelectedRows;
            if (row != null && row.Count > 0)
            {
                this.CompanyId = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.CompanyId);
                else if (flag.ToLower() == "d")
                {
                    if (clsBCompanyMaster.Delete(this.CompanyId))
                    {
                        this.CompanyId = 0;
                        ClearControls();
                        this.BindGrid();
                        MessageBox.Show("Cash Expense details successfully deleted", "Information");
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
        /// <param name="expid"></param>
        private void EditData(int expid)
        {
            var item = clsBCompanyMaster.FindRecord(expid);
            if (item != null)
            {
                this.txtCompanyName.Text = item.CompanyName;
                this.txtCompanyAddress.Text = item.CompanyAddress;
                this.txtPhoneNo.Text = item.PhoneNo;
                this.txtMobileNo.Text = item.MobileNo;
                this.txtEmailId.Text = item.EmailId;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void EnableSortmode()
        {
            foreach (DataGridViewColumn column in this.grdCode.Columns)
            {
                this.grdCode.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.BindGrid();
        }
        /// <summary>
        /// 
        /// </summary>
        public void DefaultProperty()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
        }
        #endregion

         
        private void txtSearch_KeyUp_1(object sender, KeyEventArgs e)
        {
            this.BindGrid();

        } 
         
    }
}
