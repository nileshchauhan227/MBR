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
    public partial class frmOpeningBalance : Form
    {
        public frmOpeningBalance()
        {
            InitializeComponent();
            grdStockBalance.AutoGenerateColumns = false;

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);

        }
        private void frmOpeningBalance_Load(object sender, EventArgs e)
        {
            this.BindGrid();
        }
        private Boolean findByItemname(StcokBalanceDTO obj)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return (obj.ItemName.ToLower().Trim().Contains(this.txtSearch.Text.ToLower().Trim()));
        }
        private void BindGrid()
        {
            List<StcokBalanceDTO> lstStcokBalanceDTO = clsBStockBalance.GetAllRecordList();
            lstStcokBalanceDTO = lstStcokBalanceDTO.FindAll(findByItemname);
            grdStockBalance.DataSource = lstStcokBalanceDTO;
            for (int i = 0; i < lstStcokBalanceDTO.Count; i++)
            {
                if (lstStcokBalanceDTO[i].OpeningQty > 0)
                {
                    grdStockBalance.Rows[i].Cells[1].ReadOnly = true;
                }
                else
                    grdStockBalance.Rows[i].Cells[1].ReadOnly = false;
            }
        }

        private void btmStockSave_Click(object sender, EventArgs e)
        {
            List<StcokBalanceDTO> lst = new List<StcokBalanceDTO>();
            StcokBalanceDTO obj = null;
            for (int i = 0; i < grdStockBalance.Rows.Count; i++)
            {
                if (!grdStockBalance.Rows[i].Cells[1].ReadOnly)
                {
                    obj = new StcokBalanceDTO();
                    obj.Id = Convert.ToInt64(grdStockBalance.Rows[i].Cells[2].Value);
                    obj.OpeningQty = Convert.ToInt64(grdStockBalance.Rows[i].Cells[1].Value);
                    lst.Add(obj);
                }
            }
            Int64 cnt = clsBStockBalance.Update(lst);
            if (cnt > 0)
            {
                MessageBox.Show("Opening balance successfully updated.", "Success");
                this.BindGrid();
                this.txtSearch.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            this.BindGrid();
        }


    }
}
