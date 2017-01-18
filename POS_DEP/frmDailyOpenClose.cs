using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BAL;

namespace POS
{
    public partial class frmDailyOpenClose : Form
    {
        public frmDailyOpenClose()
        {
            InitializeComponent();
            dtDate.Enabled = false;
        }
        private void frmDailyOpenClose_Load(object sender, EventArgs e)
        {
            if (!clsBStockBalance.IsOpeningExists(dtDate.Value))
            {
                txtNote.Text = "You can start transaction after Start Day Transaction.";
                btnStartDayTransaction.Enabled = true;
                btnEndDayTransaction.Enabled = false;
            }
            else
            {
                txtNote.Text = "Opening Balance updated. You can start transaction now.";
                btnStartDayTransaction.Enabled = false;
                btnEndDayTransaction.Enabled = true;
            }
        }
        private void btnStartDayTransaction_Click(object sender, EventArgs e)
        {
            clsBStockBalance.UpodateStockBalance("O");
            btnStartDayTransaction.Enabled = false;
            btnEndDayTransaction.Enabled = true;
        }
        private void btnEndDayTransaction_Click(object sender, EventArgs e)
        {
            clsBStockBalance.UpodateStockBalance("C");
            btnStartDayTransaction.Enabled = true;
            btnEndDayTransaction.Enabled = false;
        }
    }
}
