using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BAL;
using Microsoft.Reporting.WinForms;

namespace POS_Reports
{
    public partial class rptBill : Form
    {
        public int BillID = 0;
        public rptBill()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
        }
        public rptBill(int billid)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
            this.BillID = billid;
        }
        private void rptBill_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {
            DataSet ds = clsBReports.GetBillDetail(this.BillID);
            ReportDataSource datasource4 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportDataSource datasource3 = new ReportDataSource("DataSet2", ds.Tables[1]);
            ReportParameter rp1 = new ReportParameter("BillId",this.BillID.ToString());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1 });
            this.reportViewer1.LocalReport.DataSources.Add(datasource4);
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);
            this.reportViewer1.RefreshReport();
        }
        public void PrintReport()
        {
            LoadReport();
            using (Demo demo = new Demo())
            {
                demo.Export(reportViewer1);
                demo.Print();
            }
        }
    }
}
