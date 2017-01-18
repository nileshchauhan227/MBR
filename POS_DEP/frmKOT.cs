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
using POS.Classes;
using System.Drawing.Printing;

namespace POS
{
    public partial class frmKOT : Form
    {
        public bool KOTPrintOption { get; set; }
        public int KOTID { get; set; }

        public frmKOT()
        {
            InitializeComponent();

        }

        public void BindTable()
        {
            var res = clsBCodeMaster.GetAllRecordsList("TB");
            ddlTableNo.DisplayMember = "Name";
            ddlTableNo.ValueMember = "ID";
            ddlTableNo.DataSource = res;
        }

        public int GetNextKotNumber()
        {
            return clsBKOT.GetNextKOTID(DateTime.Now);
        }

        private void MakeSerieal()
        {
            if (grdKotDettails.Rows.Count > 1)
            {
                for (int i = 0; i < grdKotDettails.Rows.Count - 1; i++)
                {
                    grdKotDettails.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
        }

        private void frmKOT_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            grdKotDettails.AutoGenerateColumns = false;
            grdRunningKot.AutoGenerateColumns = false;

            this.KOTPrintOption = clsBConfiguration.GetConfigVal("KOT Print Option") == "1" ? true : false;
            txtKotDate.Text = DateTime.Now.GetShortDateString();
            txtKotTime.Text = DateTime.Now.ToString("hh:mm:ss");
            BindTable();
            txtKotNumber.Text = GetNextKotNumber().ToString();
            BindRunningKOT();
            MakeSerieal();
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

        //protected override void OnKeyPress(KeyPressEventArgs ex)
        //{
        //    string xo = ex.KeyChar.ToString();
        //    if (xo == "b" || xo == "B")
        //    {
        //        foreach (Form childForm in MdiChildren)
        //        {
        //            childForm.Hide();
        //        }
        //        frmBill frmBill = new frmBill();
        //        if (!CheckForDuplicate(frmBill))
        //        {
        //            frmBill.MdiParent = this.MdiParent;
        //            frmBill.Show();
        //        }
        //        else
        //        {
        //            frmBill = null;
        //        }
        //    }
        //}
        private void grdKotDettails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MakeSerieal();
        }

        //private void grdKotDettails_CellLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    GetItemName();
        //}

        public void GetItemName()
        {
            if (grdKotDettails.CurrentRow != null)
                if (grdKotDettails.CurrentRow.Cells[2].Value != null && !String.IsNullOrWhiteSpace(grdKotDettails.CurrentRow.Cells[2].Value.ToString()))
                {
                    int ind = grdKotDettails.CurrentRow.Cells[2].RowIndex;
                    var item = clsBItemMaster.GetItemByCode(grdKotDettails.CurrentRow.Cells[2].Value.ToString());
                    if (item != null)
                    {
                        grdKotDettails.Rows[ind].Cells[3].Value = item.ItemName;
                        grdKotDettails.Rows[ind].Cells[4].Value = item.ItemID;
                        //grdKotDettails.Rows[ind + 1].Cells[2].Selected = true;
                    }
                    else
                    {
                        grdKotDettails.Rows[ind].Cells[3].Value = "";
                        grdKotDettails.Rows[ind].Cells[4].Value = "";
                        //grdKotDettails.Rows.Remove(grdKotDettails.Rows[ind]);
                        MessageBox.Show("Item not found", "Information");
                        return;
                    }
                }
                else
                {
                    var index = grdKotDettails.CurrentRow.Index;
                    grdKotDettails.Rows[index].Cells[3].Value = "";
                    grdKotDettails.Rows[index].Cells[4].Value = "";
                }

        }

        //private void grdKotDettails_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    GetItemName();
        //}

        //private void grdKotDettails_RowLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    GetItemName();
        //}

        private void grdKotDettails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            GetItemName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        public void clearControls()
        {
            this.KOTID = 0;
            txtKotNumber.Text = "";
            grdKotDettails.Rows.Clear();
            ddlTableNo.SelectedIndex = -1;
            txtKotNumber.Text = GetNextKotNumber().ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.KOTID > 0)
            {
                if (clsBKOT.Delete(this.KOTID))
                {
                    MessageBox.Show("Record deleted successfully", "Success");
                    clearControls();
                    BindRunningKOT();
                }
                else
                {
                    MessageBox.Show("Error while delete record", "Error");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(ddlTableNo.SelectedValue) <= 0)
            {
                MessageBox.Show("Please select table", "Information");
                return;
            }
            if (grdKotDettails.RowCount == 0)
            {
                MessageBox.Show("Please enter atleast one item", "Information");
            }

            KOTMasterDTO objMaster = new KOTMasterDTO();
            objMaster.KOTDateTime = DateTime.Now;
            objMaster.SRNumber = Convert.ToInt32(txtKotNumber.Text);
            objMaster.TableID = Convert.ToInt32(ddlTableNo.SelectedValue);
            objMaster.Quantity = grdKotDettails.RowCount;
            objMaster.IsBillGenerated = false;
            foreach (DataGridViewRow row in grdKotDettails.Rows)
            {
                if (!String.IsNullOrWhiteSpace(Convert.ToString(row.Cells[2].Value)))
                {
                    objMaster.detailList.Add(new KOTDetailDTO() { ItemID = Convert.ToInt32(row.Cells[4].Value), Quantity = Convert.ToDecimal(row.Cells[1].Value) });
                }
            }
            if (this.KOTID == 0)
            {
                objMaster.KOTID = this.KOTID;
                var res = clsBKOT.Add(objMaster);
                if (res > 0)
                {
                    BindRunningKOT();
                    if (this.KOTPrintOption)
                        PrintKOT();
                    clearControls();
                }
            }
            else
            {
                var res = clsBKOT.Update(objMaster);
                if (res > 0)
                {
                    BindRunningKOT();
                    if (this.KOTPrintOption)
                        PrintKOT();
                    clearControls();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Edit(int id)
        {
            KOTMasterDTO objEdit = clsBKOT.GetKOTDetails(id);
            Edit(objEdit);
        }


        public void BindRunningKOT()
        {
            var res = clsBKOT.GetRunningKOT(DateTime.Now.Date);
            grdRunningKot.DataSource = res;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var kotsrno = Convert.ToInt32(txtKotNumber.Text);
            if (kotsrno > 1)
            {
                kotsrno--;
                grdKotDettails.Rows.Clear();
                var res = clsBKOT.GetKOTDetailsBySrNo(kotsrno);
                Edit(res);
            }
        }

        public void Edit(KOTMasterDTO objEdit)
        {
            this.KOTID = objEdit.KOTID;
            txtKotNumber.Text = objEdit.SRNumber.ToString();
            txtKotDate.Text = objEdit.KOTDateTime.GetShortDateString();
            txtKotTime.Text = objEdit.KOTDateTime.ToString("hh:mm:ss");
            ddlTableNo.SelectedValue = objEdit.TableID;
            int i = 1;
            foreach (var item in objEdit.detailList)
            {
                grdKotDettails.Rows.Add(i, item.Quantity, item.ItemCode, item.ItemName, item.ItemID);
            }
            //objEdit.detailList.Add(new KOTDetailDTO { ID = item.ID, IsServed = false, ItemCode = "", ItemID = 0 });
            //grdKotDettails.DataSource = objEdit.detailList;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            int nextid = GetNextKotNumber();
            var kotsrno = Convert.ToInt32(txtKotNumber.Text);
            if (kotsrno < nextid - 1)
            {
                kotsrno++;
                grdKotDettails.Rows.Clear();
                var res = clsBKOT.GetKOTDetailsBySrNo(kotsrno);
                Edit(res);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int nextid = GetNextKotNumber();
            var kotsrno = nextid - 1;
            grdKotDettails.Rows.Clear();
            var res = clsBKOT.GetKOTDetailsBySrNo(kotsrno);
            Edit(res);
        }

        private void grdKotDettails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            GetItemName();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintKOT();
        }
        public void PrintKOT()
        {
            string printer = clsBConfiguration.GetConfigVal(Constants.ConfigurationKey.KOTDefaultPrinter);
            //PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            //printDialog.Document = printDocument; //add the document to the dialog box...   
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing
            printDocument.PrinterSettings.PrinterName = printer;
            //DialogResult result = printDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            printDocument.Print();
            //}
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //this prints the reciept
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            Brush brush = new SolidBrush(Color.Black);
            float fontHeight = font.GetHeight();
            int startX = 30;
            int startY = 10;
            int offset = 10;
            graphic.DrawString("".PadRight(15) +  clsBConfiguration.GetConfigVal("ShopName"), font, brush, startX, startY);
            offset = offset + (int)fontHeight;
            graphic.DrawString("Date : " + txtKotDate.Text, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("KOT No : " + txtKotNumber.Text.PadRight(10) + "Table : " + ddlTableNo.Text, font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString("----------------------------------", font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("Item".PadRight(30) + "Qty", font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("----------------------------------", font, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;

            int itemCount = 0;
            foreach (DataGridViewRow item in grdKotDettails.Rows)
            {
                //create the string to print on the reciept
                if (!String.IsNullOrWhiteSpace(Convert.ToString(item.Cells[3].Value)))
                {
                    string productDescription = item.Cells[3].Value.ToString().Substring(0, item.Cells[3].Value.ToString().Length > 24 ? 24 : item.Cells[3].Value.ToString().Length);
                    string quantity = item.Cells[1].Value.ToString();
                    float productQuantity = float.Parse(quantity);

                    string productLine = productDescription.PadRight(34 - quantity.Length) + quantity.ToString();
                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), brush, startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    itemCount++;

                }
            }
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            string words = "Total qty : " + itemCount.ToString("0.00");
            graphic.DrawString("".PadRight(34 - words.Length) + words, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

        }




    }
}
