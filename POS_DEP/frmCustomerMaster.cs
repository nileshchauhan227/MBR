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

namespace POS
{
    public partial class frmCustomerMaster : Form
    {
         
         #region Declartion and Page Events
        int CustomerId = 0;
        public frmCustomerMaster()
        {
            InitializeComponent();
            this.DefaultProperty();
            this.EnableSortmode();
            this.BindGrid();
        } 
        #endregion

        #region Control Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDTO objToAdd = new CustomerDTO();
            Int32 phoneno = 0;
            Int32 PhoneNo = 0;
            if (String.IsNullOrWhiteSpace(this.txtCustomerName.Text))
            {
                MessageBox.Show("Please enter Customer Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtEmailId.Text))
            {
                MessageBox.Show("Please enter Email Id", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtPhoneNo.Text))
            {
                MessageBox.Show("Please enter Phone No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (!string.IsNullOrWhiteSpace(this.txtPhoneNo.Text))
            //{
            //    if (!Int32.TryParse(this.txtPhoneNo.Text, out phoneno))
            //    {
            //        MessageBox.Show("Please enter Phone no in numeric", "Information");
            //        return;
            //    }
            //    else
            //        PhoneNo = phoneno;
            //}
            objToAdd.CustomerName = this.txtCustomerName.Text.Trim();
            objToAdd.EmailId = this.txtEmailId.Text.Trim();
            objToAdd.CustomerAddress = this.txtAddress.Text.Trim();
            objToAdd.PhoneNo = this.txtPhoneNo.Text.Trim();
            if (CustomerId > 0)
            {
                objToAdd.CustomerId = CustomerId;
                clsBCustomerMaster.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.CustomerId = 0;
                MessageBox.Show("Customer details successfully updated", "Success");
            }
            else
            {
                clsBCustomerMaster.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.CustomerId = 0;
                MessageBox.Show("Customer details successfully added", "Success");
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
            this.CustomerId = 0;
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
                this.CustomerId = Convert.ToInt32(this.grdCode.Rows[0].Cells[0].Value);
                this.grdCode.Rows[0].Selected = true;
                EditData(this.CustomerId);
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
                this.CustomerId = Convert.ToInt32(this.grdCode.Rows[this.grdCode.Rows.Count - 1].Cells[0].Value);
                this.grdCode.Rows[this.grdCode.Rows.Count - 1].Selected = true;
                EditData(this.CustomerId);
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
                    this.CustomerId = Convert.ToInt32(this.grdCode.Rows[currentIndex + 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex + 1].Selected = true;
                    EditData(this.CustomerId);
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
                    this.CustomerId = Convert.ToInt32(this.grdCode.Rows[currentIndex - 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex - 1].Selected = true;
                    EditData(this.CustomerId);
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
            this.CustomerId = Convert.ToInt32(this.grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.CustomerId);
        } 
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        private void ClearControls()
        {
            this.txtCustomerName.Text = string.Empty; ;
            this.txtEmailId.Text = string.Empty;
            this.txtPhoneNo.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid()
        {
            var lst = clsBCustomerMaster.GetItems(txtSearch.Text.Trim());
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
                this.CustomerId = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.CustomerId);
                else if (flag.ToLower() == "d")
                {
                    if (clsBCustomerMaster.Delete(this.CustomerId))
                    {
                        this.CustomerId = 0;
                        ClearControls();
                        this.BindGrid();
                        MessageBox.Show("Customer details successfully deleted", "Information");
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
        /// <param name="CustomerId"></param>
        private void EditData(int CustomerId)
        {
            var item = clsBCustomerMaster.GetItems(CustomerId);
            if (item != null)
            {
                this.txtCustomerName.Text = item.CustomerName;
                this.txtEmailId.Text = item.EmailId;
                this.txtPhoneNo.Text = item.PhoneNo;
                this.txtAddress.Text = item.CustomerAddress;
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

        private void grdCode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            this.CustomerId = Convert.ToInt32(grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.CustomerId);
        }


    }
}
