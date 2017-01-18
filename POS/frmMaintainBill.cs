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
    public partial class frmMaintainBill : Form
    {
        public frmMaintainBill()
        {
            InitializeComponent();
            grdMaintainKOTDetails.AutoGenerateColumns = false;

            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            BindKOTDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BindMaintainDetails();
        }
        private void BindKOTDate()
        {

            var res = clsBKOT.GetKotRecordsList();
            ddlKOTDate.DisplayMember = "KOTDate";
            ddlKOTDate.ValueMember = "KOTDate";
            ddlKOTDate.DataSource = res.Distinct().ToList();
        }
        private void BindMaintainDetails()
        {
            List<KOTMasterDTO> lstKOT = clsBKOT.GetKotRecordsList(Convert.ToDateTime(ddlKOTDate.SelectedValue));
            this.lblDayDate.Text = Convert.ToString(lstKOT.Sum(x => x.NetAmount));
            grdMaintainKOTDetails.DataSource = lstKOT;
            GetTotal();
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            KOTMasterDTO objDTO = null;
            List<KOTMasterDTO> lstkotId = new List<KOTMasterDTO>();
            for (int i = 0; i < grdMaintainKOTDetails.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)grdMaintainKOTDetails.Rows[i].Cells[1];
                if (ch1 != null)
                {
                    objDTO = new KOTMasterDTO();
                    objDTO.KOTID = Convert.ToInt32(grdMaintainKOTDetails.Rows[i].Cells[0].Value);
                    objDTO.TobeMaintained = Convert.ToBoolean(grdMaintainKOTDetails.Rows[i].Cells[1].Value);
                    lstkotId.Add(objDTO);
                }
            }
            int cnt = clsBKOT.Update_TobeMaintain(lstkotId);
            if (cnt > 0)
            {
                BindMaintainDetails();
                MessageBox.Show("Maintain bill successfully.", "Success");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void grdMaintainKOTDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowid = (((System.Windows.Forms.DataGridView)(sender)).CurrentCell).RowIndex;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)grdMaintainKOTDetails.Rows[grdMaintainKOTDetails.CurrentRow.Index].Cells[1];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    decimal selectedTotal = Convert.ToDecimal(grdMaintainKOTDetails.Rows[rowid].Cells[6].Value);
                    this.lblSelectedTotal.Text = Convert.ToString(Convert.ToDecimal(this.lblSelectedTotal.Text) - selectedTotal);
                    this.lblDifference.Text = Convert.ToString(Convert.ToDecimal(this.lblDayDate.Text) - Convert.ToDecimal(this.lblSelectedTotal.Text));
                    break;
                case "False":
                    ch1.Value = true;
                    decimal selectedTotal1 = Convert.ToDecimal(grdMaintainKOTDetails.Rows[rowid].Cells[6].Value);
                    this.lblSelectedTotal.Text = Convert.ToString(Convert.ToDecimal(this.lblSelectedTotal.Text) + selectedTotal1);
                    this.lblDifference.Text = Convert.ToString(Convert.ToDecimal(this.lblDayDate.Text) - Convert.ToDecimal(this.lblSelectedTotal.Text));
                    break;
            }
        }
        private void GetTotal()
        {
            lblDifference.Text = lblSelectedTotal.Text = "0.00";
            for (int rowid = 0; rowid < grdMaintainKOTDetails.Rows.Count; rowid++)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)grdMaintainKOTDetails.Rows[rowid].Cells[1];

                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {

                    case "True":
                        decimal selectedTotal1 = Convert.ToDecimal(grdMaintainKOTDetails.Rows[rowid].Cells[6].Value);
                        this.lblSelectedTotal.Text = Convert.ToString(Convert.ToDecimal(this.lblSelectedTotal.Text) + selectedTotal1);
                        this.lblDifference.Text = Convert.ToString(Convert.ToDecimal(this.lblDayDate.Text) - Convert.ToDecimal(this.lblSelectedTotal.Text));
                        break;
                }
            }
        }

        private void btnGenrateBill_Click(object sender, EventArgs e)
        {
            List<Int32> lstkotId = new List<Int32>();
            for (int i = 0; i < grdMaintainKOTDetails.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)grdMaintainKOTDetails.Rows[i].Cells[1];
                if (ch1 != null && ch1.Value.ToString().ToLower() == "true")
                {
                    lstkotId.Add(Convert.ToInt32(grdMaintainKOTDetails.Rows[i].Cells[0].Value));
                }
            }
            if (lstkotId.Count == 0)
            {
                MessageBox.Show("Please select atleast one record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BillMasterDTO obj = clsBKOT.GenrateBill(lstkotId);
            if (obj != null)
            {
                if (obj.BillID > 0)
                {
                    BindMaintainDetails();
                    MessageBox.Show("Bill Genrated successfully.", "Success");
                }
                else
                {
                    MessageBox.Show("Selected Bill already Genrated.", "Success");
                }
            }
        }

        //private void grdMaintainKOTDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (grdMaintainKOTDetails.Rows.Count > 0)
        //    {
        //        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
        //        ch1 = (DataGridViewCheckBoxCell)grdMaintainKOTDetails.Rows[e.RowIndex].Cells[1];
        //        if (ch1.Value == null)
        //            ch1.Value = false;
        //        else
        //            ch1.Value = true;
        //    }
        //}



    }
}
