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
    public partial class frmCashExpense : Form
    {
        #region Declartion and Page Events
        int ExpID = 0;
        public frmCashExpense()
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
            CashExpenseDTO objToAdd = new CashExpenseDTO();
            decimal amt = 0;
            decimal Amount = 0;
            if (String.IsNullOrWhiteSpace(this.txtExpenseDetails.Text))
            {
                MessageBox.Show("Please enter Expense Details", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtReceiverName.Text))
            {
                MessageBox.Show("Please enter Receiver Name", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                MessageBox.Show("Please enter Amount", "Information");
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                if (!decimal.TryParse(this.txtAmount.Text, out amt))
                {
                    MessageBox.Show("Please enter Amount in numeric", "Information");
                    return;
                }
                else
                    Amount = amt;
            }
            objToAdd.ExpDetail = this.txtExpenseDetails.Text;
            objToAdd.ExpDate = this.dtDate.Value;
            objToAdd.ReceiverName = this.txtReceiverName.Text;
            objToAdd.Amount = Amount;
            objToAdd.CreatedDate = objToAdd.UpdatedDate = DateTime.Now;
            objToAdd.IsDeleted = false;
            if (ExpID > 0)
            {
                objToAdd.Id = ExpID;
                clsBCashExpense.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.ExpID = 0;
                MessageBox.Show("Cash Expense details successfully updated", "Success");
            }
            else
            {
                clsBCashExpense.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.ExpID = 0;
                MessageBox.Show("Cash Expense details successfully added", "Success");
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
            this.ExpID = 0;
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
                this.ExpID = Convert.ToInt32(this.grdCode.Rows[0].Cells[0].Value);
                this.grdCode.Rows[0].Selected = true;
                EditData(this.ExpID);
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
                this.ExpID = Convert.ToInt32(this.grdCode.Rows[this.grdCode.Rows.Count - 1].Cells[0].Value);
                this.grdCode.Rows[this.grdCode.Rows.Count - 1].Selected = true;
                EditData(this.ExpID);
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
                    this.ExpID = Convert.ToInt32(this.grdCode.Rows[currentIndex + 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex + 1].Selected = true;
                    EditData(this.ExpID);
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
                    this.ExpID = Convert.ToInt32(this.grdCode.Rows[currentIndex - 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex - 1].Selected = true;
                    EditData(this.ExpID);
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
            this.ExpID = Convert.ToInt32(this.grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.ExpID);
        } 
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        private void ClearControls()
        {
            this.txtExpenseDetails.Text = string.Empty; ;
            this.dtDate.Value = DateTime.Now;
            this.txtReceiverName.Text = string.Empty;
            this.txtAmount.Text = "0.00";
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid()
        {
            var lst = clsBCashExpense.GetItems(txtSearch.Text.Trim());
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
                this.ExpID = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.ExpID);
                else if (flag.ToLower() == "d")
                {
                    if (clsBCashExpense.Delete(this.ExpID))
                    {
                        this.ExpID = 0;
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
            var item = clsBCashExpense.FindRecord(expid);
            if (item != null)
            {
                this.txtExpenseDetails.Text = item.ExpDetail;
                this.txtReceiverName.Text = item.ReceiverName;
                this.dtDate.Value = item.ExpDate;
                this.txtAmount.Text = Convert.ToString(item.Amount);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     
    }
}
