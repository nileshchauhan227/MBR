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
    public partial class frmSalesSummary : Form
    {
        public frmSalesSummary()
        {
            InitializeComponent();
        }

        private void frmSalesSummary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pOS_Rutu_NDataSet2.SalesSummary' table. You can move, or remove it, as needed.
            this.salesSummaryTableAdapter.Fill(this.pOS_Rutu_NDataSet2.SalesSummary);

            ReportDataSource datasource3 = new ReportDataSource("dsSalesSummary", this.pOS_Rutu_NDataSet2.SalesSummary.DataSet.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);

            this.reportViewer1.RefreshReport();
        }
    }
}
