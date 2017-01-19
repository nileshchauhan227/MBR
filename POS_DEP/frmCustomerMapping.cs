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
    public partial class frmCustomerMapping : Form
    {


        #region Declartion and Page Events
        int MappingId = 0;
        public frmCustomerMapping()
        {
            InitializeComponent();
            this.DefaultProperty();

        }
        private void frmCustomerMapping_Load(object sender, EventArgs e)
        {
            this.EnableSortmode();
            this.BindGrid();
            this.BindControls();
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
            CustomerMappingDTO objToAdd = new CustomerMappingDTO();
            double rate = 0;
            double ItemRate = 0;
            if (this.ddlCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Customer Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.ddlItem.SelectedIndex == 0)
            {
                MessageBox.Show("Please select item name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtRate.Text))
            {
                MessageBox.Show("Please enter rate", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtRate.Text))
            {
                if (!double.TryParse(this.txtRate.Text, out rate))
                {
                    MessageBox.Show("Please enter Phone no in numeric", "Information");
                    return;
                }
                else
                    ItemRate = rate;
            }
            if(clsBCustomerMapping.isExistCode(Convert.ToInt32(ddlCustomer.SelectedValue),Convert.ToInt32(ddlItem.SelectedValue)))
            {
                MessageBox.Show("Customer and Item already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            objToAdd.CustomerId = Convert.ToInt32(this.ddlCustomer.SelectedValue);
            objToAdd.ItemId = Convert.ToInt32(this.ddlItem.SelectedValue);
            
            objToAdd.Rate = ItemRate;

            if (MappingId > 0)
            {
                objToAdd.MappingId = MappingId;
                clsBCustomerMapping.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.MappingId = 0;
                MessageBox.Show("Customer mapping details successfully updated", "Success");
            }
            else
            {
                clsBCustomerMapping.Add(objToAdd);
                this.ClearControls();
                this.BindGrid();
                this.MappingId = 0;
                MessageBox.Show("Customer mapping details successfully added", "Success");
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
            this.MappingId = 0;
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
                this.MappingId = Convert.ToInt32(this.grdCode.Rows[0].Cells[0].Value);
                this.grdCode.Rows[0].Selected = true;
                EditData(this.MappingId);
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
                this.MappingId = Convert.ToInt32(this.grdCode.Rows[this.grdCode.Rows.Count - 1].Cells[0].Value);
                this.grdCode.Rows[this.grdCode.Rows.Count - 1].Selected = true;
                EditData(this.MappingId);
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
                    this.MappingId = Convert.ToInt32(this.grdCode.Rows[currentIndex + 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex + 1].Selected = true;
                    EditData(this.MappingId);
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
                    this.MappingId = Convert.ToInt32(this.grdCode.Rows[currentIndex - 1].Cells[0].Value);
                    this.grdCode.Rows[currentIndex - 1].Selected = true;
                    EditData(this.MappingId);
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
            this.MappingId = Convert.ToInt32(this.grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.MappingId);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        private void ClearControls()
        {
            this.ddlCustomer.SelectedIndex = 0;
            this.ddlItem.SelectedIndex = 0;
            this.txtRate.Text = "0.00";
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid()
        {
            var lst = clsBCustomerMapping.GetItems(txtSearch.Text.Trim());
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
                this.MappingId = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.MappingId);
                else if (flag.ToLower() == "d")
                {
                    if (clsBCustomerMapping.Delete(this.MappingId))
                    {
                        this.MappingId = 0;
                        ClearControls();
                        this.BindGrid();
                        MessageBox.Show("Customer mapping details successfully deleted", "Information");
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
        /// <param name="MappingId"></param>
        private void EditData(int MappingId)
        {
            var item = clsBCustomerMapping.GetItems(MappingId);
            if (item != null)
            {
                this.ddlCustomer.SelectedValue = item.CustomerId;
                this.ddlItem.SelectedValue = item.ItemId;
                this.txtRate.Text = Convert.ToString(item.Rate);

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
            this.MappingId = Convert.ToInt32(grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.MappingId);
        }


        private void BindControls()
        {
            var CustomerList = clsBCustomerMaster.GetAllRecordsList();
            ddlCustomer.DisplayMember = "CustomerName";
            ddlCustomer.ValueMember = "CustomerId";
            ddlCustomer.DataSource = CustomerList;

            var ItemList = clsBItemMaster.GetItems();
            ddlItem.DisplayMember = "ItemName";
            ddlItem.ValueMember = "ItemId";
            ddlItem.DataSource = ItemList;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        



    }
}
