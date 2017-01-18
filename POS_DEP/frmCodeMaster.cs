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
    public partial class frmCodeMaster : Form
    {
        int CodeID = 0;
        public frmCodeMaster()
        {
            InitializeComponent();
            EnableSortmode();
            BindCodeType();
            BindGrid();
            SetButtonEnableDisable();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);

        }

        #region Button Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            CodeMasterDTO objToAdd = new CodeMasterDTO();
            if (String.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please enter Code", "Information");
                return;
            }
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Name", "Information");
                return;
            }
            if (clsBCodeMaster.isExistCode(txtName.Text.Trim(), this.CodeID))
            {
                MessageBox.Show("Name already used. Please try using another name.", "Information");
                return;
            }
            objToAdd.Code = txtCode.Text;
            objToAdd.Name = txtName.Text;
            objToAdd.CodeTypeID = Convert.ToInt16(ddlCodeType.SelectedValue);
            if (CodeID > 0)
            {
                objToAdd.ID = CodeID;
                clsBCodeMaster.Add(objToAdd);
                MessageBox.Show("Code successfully updated", "Success");
                ClearControls();
                BindGrid();
                this.CodeID = 0;
            }
            else
            {
                clsBCodeMaster.Add(objToAdd);
                MessageBox.Show("Code successfully added", "Success");
                ClearControls();
                BindGrid();
                this.CodeID = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            ClearControls();
            this.CodeID = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click_1(object sender, EventArgs e)
        {
            Modify_Delete("M");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            if (grdCode.Rows.Count > 0)
            {
                this.CodeID = Convert.ToInt32(grdCode.Rows[0].Cells[0].Value);
                grdCode.Rows[0].Selected = true;
                EditData(this.CodeID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click_1(object sender, EventArgs e)
        {
            if (grdCode.Rows.Count > 0)
            {
                this.CodeID = Convert.ToInt32(grdCode.Rows[grdCode.Rows.Count - 1].Cells[0].Value);
                grdCode.Rows[grdCode.Rows.Count - 1].Selected = true;
                EditData(this.CodeID);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (grdCode.SelectedRows != null)
            {
                int currentIndex = grdCode.SelectedRows[0].Index;
                if (currentIndex < grdCode.Rows.Count - 1)
                {
                    this.CodeID = Convert.ToInt32(grdCode.Rows[currentIndex + 1].Cells[0].Value);
                    grdCode.Rows[currentIndex + 1].Selected = true;
                    EditData(this.CodeID);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (grdCode.SelectedRows != null)
            {
                int currentIndex = grdCode.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    this.CodeID = Convert.ToInt32(grdCode.Rows[currentIndex - 1].Cells[0].Value);
                    grdCode.Rows[currentIndex - 1].Selected = true;
                    EditData(this.CodeID);
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

        #region Control and Grid Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyUp_1(object sender, KeyEventArgs e)
        {
            BindGrid();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdCode_DoubleClick_1(object sender, EventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            this.CodeID = Convert.ToInt32(grdCode.Rows[rowid].Cells[0].Value);
            this.EditData(this.CodeID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCodeType.SelectedValue != "")
            {
                try
                {
                    var item = clsBCodeTypeMaster.FindRecord(Convert.ToInt32(ddlCodeType.SelectedValue));
                    txtCode.Text = item != null ? item.Code : string.Empty;
                }
                catch (Exception)
                {

                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        public void SetButtonEnableDisable()
        {
            //    if (grdCode.Rows.Count == 0)
            //    {
            //        btnNext.Enabled = false;
            //        btnPrevious.Enabled = false;
            //        btnFirst.Enabled = false;
            //        btnLast.Enabled = false; 
            //    }
            //    else if (grdCode.Rows.Count > 0)
            //    {
            //        var row = grdCode.SelectedRows;
            //        if (row != null)
            //        {
            //            this.CodeID = row[0].Index;
            //            EditData(this.CodeID);
            //        }
            //    }
        }
        /// <summary>
        /// 
        /// </summary>
        private void EnableSortmode()
        {
            foreach (DataGridViewColumn column in grdCode.Columns)
            {
                grdCode.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindCodeType()
        {
            List<CodeTypeDTO> lst = clsBCodeTypeMaster.GetAllRecordsList();
            ddlCodeType.DataSource = lst;
            ddlCodeType.DisplayMember = "Name";
            ddlCodeType.ValueMember = "ID";

            ddlCodeType.SelectedIndex = lst.Count > 0 ? 0 : -1;
            ddlCodeType_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        public void BindGrid()
        {
            var lst = clsBCodeMaster.GetItems(txtSearch.Text.Trim());
            grdCode.AutoGenerateColumns = false;
            grdCode.DataSource = lst;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearControls()
        {
            txtCode.Text = txtName.Text = "";
            grdCode.ClearSelection();
            ddlCodeType.SelectedIndex = -1;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void Modify_Delete(string flag)
        {
            var row = grdCode.SelectedRows;
            if (row != null && row.Count > 0)
            {
                this.CodeID = Convert.ToInt32(row[0].Cells[0].Value);
                if (flag.ToLower() == "m")
                    EditData(this.CodeID);
                else if (flag.ToLower() == "d")
                {
                    if (clsBCodeMaster.Delete(this.CodeID))
                    {
                        BindGrid();
                        MessageBox.Show("Code successfully deleted", "Information");
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
        /// <param name="codeid"></param>
        private void EditData(int codeid)
        {
            var item = clsBCodeMaster.GetItems(codeid);
            txtCode.Text = item.Code;
            txtName.Text = item.Name;
            ddlCodeType.SelectedValue = item.CodeTypeID;

        }
        #endregion
    }
}
