using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using POS.BAL;

namespace POS_Reports
{
    public partial class rptEODReport : Form
    {
        public DateTime dtFromDate;
        public rptEODReport()
        {
            InitializeComponent();
        }
        public rptEODReport(DateTime? FromDate)
        {
            InitializeComponent();
            DefaultProperty();
            dtFromDate = FromDate.HasValue ? FromDate.Value : FromDate.Value;


        }
        private void rptEODReport_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            // TODO: This line of code loads data into the 'dsRutu.ItemwSalesiseReport' table. You can move, or remove it, as needed.
            DataSet ds = clsBReports.Reports("EODReport", dtFromDate, dtFromDate);
            DataSet ds1 = clsBReports.Reports("EODReportByPaymentMode", dtFromDate, dtFromDate);
            ReportDataSource datasource2 = new ReportDataSource("DataSet1", ds1.Tables[0]);
            ReportDataSource datasource3 = new ReportDataSource("EODReport", ds.Tables[0]);
            DateTime dtStartDate = dtFromDate;
            ReportParameter rp1 = new ReportParameter("FromDate", dtStartDate.ToString());
            ReportParameter rp3 = new ReportParameter("rptHeader", clsBConfiguration.GetConfigVal("ReportHeader").ToString());

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp3 });
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);
            this.reportViewer1.LocalReport.DataSources.Add(datasource2);
            this.reportViewer1.RefreshReport();
        }
        public void DefaultProperty()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 10;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
        }
        public void SavePDF()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            LoadReport();
            SaveFileDialog obj = new SaveFileDialog();
            obj.Filter = "PDF document (*.pdf)|*.pdf";

            DialogResult result = obj.ShowDialog();
            string fileName = this.Name;
            if (result == DialogResult.OK)
            {
                byte[] bytes = reportViewer1.LocalReport.Render(
              "PDF", null, out mimeType, out encoding,
               out extension,
              out streamids, out warnings);

                using (FileStream fs = new FileStream(obj.FileName,
                   FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
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


