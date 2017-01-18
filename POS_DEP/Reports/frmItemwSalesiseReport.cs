using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace POS.Reports
{
    public partial class frmItemwSalesiseReport : Form
    {
        public frmItemwSalesiseReport()
        {
            InitializeComponent();
        }

        private void frmItemwSalesiseReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOS_Rutu_NDataSet1.ItemwSalesiseReport' table. You can move, or remove it, as needed.
            this.itemwSalesiseReportTableAdapter.Fill(this.pOS_Rutu_NDataSet1.ItemwSalesiseReport);
            ReportDataSource datasource3 = new ReportDataSource("ItemwSalesiseReport", pOS_Rutu_NDataSet1.ItemwSalesiseReport.DataSet.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);

            this.reportViewer1.RefreshReport();
        }
    }
}
