﻿using System;
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
    public partial class rptPurchaseDetails : Form
    {
        public DateTime dtFromDate;
        public DateTime dtToDate;
        
        public rptPurchaseDetails()
        {
            InitializeComponent();
            DefaultProperty();
        }
        public rptPurchaseDetails(DateTime? FromDate, DateTime? Todate)
        {
            InitializeComponent();
            DefaultProperty();
            dtFromDate = FromDate.HasValue ? FromDate.Value : FromDate.Value;
            dtToDate = Todate.HasValue ? Todate.Value : Todate.Value;
    
        }


        private void rptPurchaseDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsRutu.GetDetailsOfPurchase' table. You can move, or remove it, as needed.
            //this.GetDetailsOfPurchaseTableAdapter.Fill(this.dsRutu.GetDetailsOfPurchase);
            LoadReport();
        }
        private void LoadReport()
        {
            // TODO: This line of code loads data into the 'dsRutu.DetailSalesReport' table. You can move, or remove it, as needed.
            DataSet ds = clsBReports.Reports("GetDetailsOfPurchase", dtFromDate, dtToDate);
            //this.DetailSalesReportTableAdapter.Fill(this.dsRutu.DetailSalesReport, dtFromDate, dtToDate);
            ReportDataSource datasource3 = new ReportDataSource("DataSet1", ds.Tables[0]);

            DateTime dtStartDate = dtFromDate;
            DateTime dtEndDate = dtToDate;
            ReportParameter rp1 = new ReportParameter("FromDate", dtStartDate.ToString());
            ReportParameter rp2 = new ReportParameter("ToDate", dtEndDate.ToString());
            ReportParameter rp3 = new ReportParameter("rptHeader", clsBConfiguration.GetConfigVal("ReportHeader").ToString());

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
            this.reportViewer1.LocalReport.DataSources.Add(datasource3);
            //if (IsWindows)
            this.reportViewer1.RefreshReport();
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
    }
}
