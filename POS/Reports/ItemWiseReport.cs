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
    public partial class ItemWiseReport : Form
    {
        public ItemWiseReport()
        {
            InitializeComponent();
        }

        private void ItemWiseReport_Load(object sender, EventArgs e)
        {
          
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dtFromDate.CustomFormat = "yyyy-MM-dd";
            // TODO: This line of code loads data into the 'pOS_Rutu_NDataSet .ItemwiseReport' table. You can move, or remove it, as needed.
            this.itemwiseReportTableAdapter1.Fill(this.pOS_Rutu_NDataSet3.ItemwiseReport, dtFromDate.Value,dtTodate.Value );
            //this.itemwiseReportTableAdapter1.Fill(this.pOS_Rutu_NDataSet3.ItemwiseReport, Convert.ToDateTime("2016-07-30"), Convert.ToDateTime("2016-07-30"));
            ReportDataSource datasource3 = new ReportDataSource("DataSet1", pOS_Rutu_NDataSet3.ItemwiseReport.DataSet.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);

            this.reportViewer1.RefreshReport();
        }
    }
}
