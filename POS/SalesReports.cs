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

namespace POS
{
    public partial class SalesReports : Form
    {
        public SalesReports()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
        }

        private void SalesReports_Load(object sender, EventArgs e)
        {

        }



        private void rdoViewOptionWindow_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectPrinter.Enabled = btnPDF.Enabled = false;
            btnShow.Enabled = true;
        }

        private void rdoViewOptionPrinter_CheckedChanged(object sender, EventArgs e)
        {
            btnShow.Enabled = btnPDF.Enabled = false;
            btnSelectPrinter.Enabled = true;
        }

        private void rdoViewOptionToFile_CheckedChanged(object sender, EventArgs e)
        {
            btnShow.Enabled = btnSelectPrinter.Enabled = false;
            btnPDF.Enabled = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport("show");
        }
        private void ShowReport(String str)
        {
            
            if (rdoSalesSummary.Checked == true)
            {
                POS_Reports.rptSalesSummary rptSalesSummary = new POS_Reports.rptSalesSummary(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptSalesSummary.Show();
                else if (str.ToLower() == "pdf")
                    rptSalesSummary.SavePDF();
                else if (str.ToLower() == "print")
                    rptSalesSummary.PrintReport();

            }
            else if (rdoSalesSummaryFirmwise.Checked == true)
            {
                POS_Reports.rptSalesSummaryFirmwise rptSalesSummaryFirmwise = new POS_Reports.rptSalesSummaryFirmwise(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptSalesSummaryFirmwise.Show();
                else if (str.ToLower() == "pdf")
                    rptSalesSummaryFirmwise.SavePDF();
                else if (str.ToLower() == "print")
                    rptSalesSummaryFirmwise.PrintReport();

            }
            else if (rdoSalesRegister.Checked == true)
            {
                POS_Reports.rptSalesRegister rptSalesRegister = new POS_Reports.rptSalesRegister(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptSalesRegister.Show();
                else if (str.ToLower() == "pdf")
                    rptSalesRegister.SavePDF();
                else if (str.ToLower() == "print")
                    rptSalesRegister.PrintReport();

            }
            else if (rdoItemwiseSalesGroupwise.Checked == true)
            {
                POS_Reports.rptItemwiseReport rptItemwiseReport = new POS_Reports.rptItemwiseReport(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptItemwiseReport.Show();
                else if (str.ToLower() == "pdf")
                    rptItemwiseReport.SavePDF();
                else if (str.ToLower() == "print")
                    rptItemwiseReport.PrintReport();
            }
            else if (rdoItemWiseSales.Checked == true)
            {
                POS_Reports.rptItemwSaleswiseReport rptItemwSaleswiseReport = new POS_Reports.rptItemwSaleswiseReport(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptItemwSaleswiseReport.Show();
                else if (str.ToLower() == "pdf")
                    rptItemwSaleswiseReport.SavePDF();
                else if (str.ToLower() == "print")
                    rptItemwSaleswiseReport.PrintReport();
            }
            else if (rdoDetailSalesReport.Checked == true)
            {
                POS_Reports.rptDetailSalesReport rptDetailSalesReport = new POS_Reports.rptDetailSalesReport(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptDetailSalesReport.Show();
                else if (str.ToLower() == "pdf")
                    rptDetailSalesReport.SavePDF();
                else if (str.ToLower() == "print")
                    rptDetailSalesReport.PrintReport();
            }
            else if (rdoInvoiceWiseSalesReport.Checked == true)
            {
                POS_Reports.rptInvoiceWiseSalesSummary rptInvoiceWiseSalesSummary = new POS_Reports.rptInvoiceWiseSalesSummary(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptInvoiceWiseSalesSummary.Show();
                else if (str.ToLower() == "pdf")
                    rptInvoiceWiseSalesSummary.SavePDF();
                else if (str.ToLower() == "print")
                    rptInvoiceWiseSalesSummary.PrintReport();
            }
            else if (rdEODReport.Checked == true)
            {
                
                POS_Reports.rptEODReport rptEODReport = new POS_Reports.rptEODReport(dtFromDate.Value);
                if (str.ToLower() == "show")
                    rptEODReport.Show();
                else if (str.ToLower() == "pdf")
                    rptEODReport.SavePDF();
                else if (str.ToLower() == "print")
                    rptEODReport.PrintReport();

            }
            else if (rdoDiscountReport.Checked == true)
            {

                POS_Reports.rptEODReport rptEODReport = new POS_Reports.rptEODReport(dtFromDate.Value);
                if (str.ToLower() == "show")
                    rptEODReport.Show();
                else if (str.ToLower() == "pdf")
                    rptEODReport.SavePDF();
                else if (str.ToLower() == "print")
                    rptEODReport.PrintReport();

            }
            if (rdPurchaseDetails.Checked == true)
            {
                POS_Reports.rptPurchaseDetails rptPurchaseDetails = new POS_Reports.rptPurchaseDetails(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptPurchaseDetails.Show();
                else if (str.ToLower() == "pdf")
                    rptPurchaseDetails.SavePDF();
                else if (str.ToLower() == "print")
                    rptPurchaseDetails.PrintReport();

            }
            if (rdSalesDetails.Checked == true)
            {
                POS_Reports.rptSalesDetails rptSalesDetails = new POS_Reports.rptSalesDetails(dtFromDate.Value, dtToDate.Value);
                if (str.ToLower() == "show")
                    rptSalesDetails.Show();
                else if (str.ToLower() == "pdf")
                    rptSalesDetails.SavePDF();
                else if (str.ToLower() == "print")
                    rptSalesDetails.PrintReport();

            }

        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            ShowReport("pdf");
        }
        private void btnSelectPrinter_Click(object sender, EventArgs e)
        {
            ShowReport("print");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void rdEODReport_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = dtToDate.Visible = false;
        }

        private void rdoInvoiceWiseSalesReport_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = dtToDate.Visible = true;
        }

        private void btnBillReportDemo_Click(object sender, EventArgs e)
        {
            POS_Reports.rptBill bill = new POS_Reports.rptBill(4399);
            bill.PrintReport();
        }

    }
}
