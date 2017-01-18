using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class frmGetBarcode : Form
    {
        public List<string> barcodes; 

        public frmGetBarcode()
        {
            InitializeComponent();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            barcodes = new List<string>(
                           txtCodes.Text.Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
