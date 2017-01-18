namespace POS
{
    partial class SalesReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSalesDetails = new System.Windows.Forms.RadioButton();
            this.rdPurchaseDetails = new System.Windows.Forms.RadioButton();
            this.rdoSalesSummaryFirmwise = new System.Windows.Forms.RadioButton();
            this.rdoDiscountReport = new System.Windows.Forms.RadioButton();
            this.rdEODReport = new System.Windows.Forms.RadioButton();
            this.rdoDetailSalesReport = new System.Windows.Forms.RadioButton();
            this.rdoInvoiceWiseSalesReport = new System.Windows.Forms.RadioButton();
            this.rdoItemwiseSalesGroupwise = new System.Windows.Forms.RadioButton();
            this.rdoItemWiseSales = new System.Windows.Forms.RadioButton();
            this.rdoSalesRegister = new System.Windows.Forms.RadioButton();
            this.rdoSalesSummary = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoViewOptionToFile = new System.Windows.Forms.RadioButton();
            this.rdoViewOptionPrinter = new System.Windows.Forms.RadioButton();
            this.rdoViewOptionWindow = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelectPrinter = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnBillReportDemo = new System.Windows.Forms.Button();
            this.rdStockBalance = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Khaki;
            this.groupBox1.Controls.Add(this.rdStockBalance);
            this.groupBox1.Controls.Add(this.rdSalesDetails);
            this.groupBox1.Controls.Add(this.rdPurchaseDetails);
            this.groupBox1.Controls.Add(this.rdoSalesSummaryFirmwise);
            this.groupBox1.Controls.Add(this.rdoDiscountReport);
            this.groupBox1.Controls.Add(this.rdEODReport);
            this.groupBox1.Controls.Add(this.rdoDetailSalesReport);
            this.groupBox1.Controls.Add(this.rdoInvoiceWiseSalesReport);
            this.groupBox1.Controls.Add(this.rdoItemwiseSalesGroupwise);
            this.groupBox1.Controls.Add(this.rdoItemWiseSales);
            this.groupBox1.Controls.Add(this.rdoSalesRegister);
            this.groupBox1.Controls.Add(this.rdoSalesSummary);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 650);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reports";
            // 
            // rdSalesDetails
            // 
            this.rdSalesDetails.AutoSize = true;
            this.rdSalesDetails.Location = new System.Drawing.Point(33, 300);
            this.rdSalesDetails.Name = "rdSalesDetails";
            this.rdSalesDetails.Size = new System.Drawing.Size(108, 21);
            this.rdSalesDetails.TabIndex = 15;
            this.rdSalesDetails.TabStop = true;
            this.rdSalesDetails.Text = "Sales Details";
            this.rdSalesDetails.UseVisualStyleBackColor = true;
            // 
            // rdPurchaseDetails
            // 
            this.rdPurchaseDetails.AutoSize = true;
            this.rdPurchaseDetails.Location = new System.Drawing.Point(33, 273);
            this.rdPurchaseDetails.Name = "rdPurchaseDetails";
            this.rdPurchaseDetails.Size = new System.Drawing.Size(133, 21);
            this.rdPurchaseDetails.TabIndex = 14;
            this.rdPurchaseDetails.TabStop = true;
            this.rdPurchaseDetails.Text = "Purchase Details";
            this.rdPurchaseDetails.UseVisualStyleBackColor = true;
            // 
            // rdoSalesSummaryFirmwise
            // 
            this.rdoSalesSummaryFirmwise.AutoSize = true;
            this.rdoSalesSummaryFirmwise.Location = new System.Drawing.Point(33, 246);
            this.rdoSalesSummaryFirmwise.Name = "rdoSalesSummaryFirmwise";
            this.rdoSalesSummaryFirmwise.Size = new System.Drawing.Size(182, 21);
            this.rdoSalesSummaryFirmwise.TabIndex = 13;
            this.rdoSalesSummaryFirmwise.TabStop = true;
            this.rdoSalesSummaryFirmwise.Text = "Sales Summary Firmwise";
            this.rdoSalesSummaryFirmwise.UseVisualStyleBackColor = true;
            // 
            // rdoDiscountReport
            // 
            this.rdoDiscountReport.AutoSize = true;
            this.rdoDiscountReport.Location = new System.Drawing.Point(33, 219);
            this.rdoDiscountReport.Name = "rdoDiscountReport";
            this.rdoDiscountReport.Size = new System.Drawing.Size(128, 21);
            this.rdoDiscountReport.TabIndex = 12;
            this.rdoDiscountReport.TabStop = true;
            this.rdoDiscountReport.Text = "Discount Report";
            this.rdoDiscountReport.UseVisualStyleBackColor = true;
            // 
            // rdEODReport
            // 
            this.rdEODReport.AutoSize = true;
            this.rdEODReport.Location = new System.Drawing.Point(33, 192);
            this.rdEODReport.Name = "rdEODReport";
            this.rdEODReport.Size = new System.Drawing.Size(103, 21);
            this.rdEODReport.TabIndex = 11;
            this.rdEODReport.TabStop = true;
            this.rdEODReport.Text = "EOD Report";
            this.rdEODReport.UseVisualStyleBackColor = true;
            this.rdEODReport.CheckedChanged += new System.EventHandler(this.rdEODReport_CheckedChanged);
            // 
            // rdoDetailSalesReport
            // 
            this.rdoDetailSalesReport.AutoSize = true;
            this.rdoDetailSalesReport.Location = new System.Drawing.Point(33, 138);
            this.rdoDetailSalesReport.Name = "rdoDetailSalesReport";
            this.rdoDetailSalesReport.Size = new System.Drawing.Size(155, 21);
            this.rdoDetailSalesReport.TabIndex = 10;
            this.rdoDetailSalesReport.TabStop = true;
            this.rdoDetailSalesReport.Text = "Details Sales Report";
            this.rdoDetailSalesReport.UseVisualStyleBackColor = true;
            this.rdoDetailSalesReport.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // rdoInvoiceWiseSalesReport
            // 
            this.rdoInvoiceWiseSalesReport.AutoSize = true;
            this.rdoInvoiceWiseSalesReport.Location = new System.Drawing.Point(33, 165);
            this.rdoInvoiceWiseSalesReport.Name = "rdoInvoiceWiseSalesReport";
            this.rdoInvoiceWiseSalesReport.Size = new System.Drawing.Size(144, 21);
            this.rdoInvoiceWiseSalesReport.TabIndex = 9;
            this.rdoInvoiceWiseSalesReport.TabStop = true;
            this.rdoInvoiceWiseSalesReport.Text = "Invoice Wise Sales";
            this.rdoInvoiceWiseSalesReport.UseVisualStyleBackColor = true;
            this.rdoInvoiceWiseSalesReport.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // rdoItemwiseSalesGroupwise
            // 
            this.rdoItemwiseSalesGroupwise.AutoSize = true;
            this.rdoItemwiseSalesGroupwise.Location = new System.Drawing.Point(33, 111);
            this.rdoItemwiseSalesGroupwise.Name = "rdoItemwiseSalesGroupwise";
            this.rdoItemwiseSalesGroupwise.Size = new System.Drawing.Size(140, 21);
            this.rdoItemwiseSalesGroupwise.TabIndex = 7;
            this.rdoItemwiseSalesGroupwise.TabStop = true;
            this.rdoItemwiseSalesGroupwise.Text = "Group Wise Sales";
            this.rdoItemwiseSalesGroupwise.UseVisualStyleBackColor = true;
            this.rdoItemwiseSalesGroupwise.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // rdoItemWiseSales
            // 
            this.rdoItemWiseSales.AutoSize = true;
            this.rdoItemWiseSales.Location = new System.Drawing.Point(33, 86);
            this.rdoItemWiseSales.Name = "rdoItemWiseSales";
            this.rdoItemWiseSales.Size = new System.Drawing.Size(126, 21);
            this.rdoItemWiseSales.TabIndex = 5;
            this.rdoItemWiseSales.TabStop = true;
            this.rdoItemWiseSales.Text = "Item Wise Sales";
            this.rdoItemWiseSales.UseVisualStyleBackColor = true;
            this.rdoItemWiseSales.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // rdoSalesRegister
            // 
            this.rdoSalesRegister.AutoSize = true;
            this.rdoSalesRegister.Location = new System.Drawing.Point(33, 58);
            this.rdoSalesRegister.Name = "rdoSalesRegister";
            this.rdoSalesRegister.Size = new System.Drawing.Size(118, 21);
            this.rdoSalesRegister.TabIndex = 3;
            this.rdoSalesRegister.TabStop = true;
            this.rdoSalesRegister.Text = "Sales Register";
            this.rdoSalesRegister.UseVisualStyleBackColor = true;
            this.rdoSalesRegister.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // rdoSalesSummary
            // 
            this.rdoSalesSummary.AutoSize = true;
            this.rdoSalesSummary.Location = new System.Drawing.Point(33, 31);
            this.rdoSalesSummary.Name = "rdoSalesSummary";
            this.rdoSalesSummary.Size = new System.Drawing.Size(124, 21);
            this.rdoSalesSummary.TabIndex = 0;
            this.rdoSalesSummary.TabStop = true;
            this.rdoSalesSummary.Text = "Sales Summary";
            this.rdoSalesSummary.UseVisualStyleBackColor = true;
            this.rdoSalesSummary.CheckedChanged += new System.EventHandler(this.rdoInvoiceWiseSalesReport_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.IndianRed;
            this.groupBox2.Controls.Add(this.rdoViewOptionToFile);
            this.groupBox2.Controls.Add(this.rdoViewOptionPrinter);
            this.groupBox2.Controls.Add(this.rdoViewOptionWindow);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(685, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Options";
            // 
            // rdoViewOptionToFile
            // 
            this.rdoViewOptionToFile.AutoSize = true;
            this.rdoViewOptionToFile.Location = new System.Drawing.Point(25, 143);
            this.rdoViewOptionToFile.Name = "rdoViewOptionToFile";
            this.rdoViewOptionToFile.Size = new System.Drawing.Size(69, 21);
            this.rdoViewOptionToFile.TabIndex = 7;
            this.rdoViewOptionToFile.Text = "To File";
            this.rdoViewOptionToFile.UseVisualStyleBackColor = true;
            this.rdoViewOptionToFile.CheckedChanged += new System.EventHandler(this.rdoViewOptionToFile_CheckedChanged);
            // 
            // rdoViewOptionPrinter
            // 
            this.rdoViewOptionPrinter.AutoSize = true;
            this.rdoViewOptionPrinter.Location = new System.Drawing.Point(25, 91);
            this.rdoViewOptionPrinter.Name = "rdoViewOptionPrinter";
            this.rdoViewOptionPrinter.Size = new System.Drawing.Size(68, 21);
            this.rdoViewOptionPrinter.TabIndex = 6;
            this.rdoViewOptionPrinter.Text = "Printer";
            this.rdoViewOptionPrinter.UseVisualStyleBackColor = true;
            this.rdoViewOptionPrinter.CheckedChanged += new System.EventHandler(this.rdoViewOptionPrinter_CheckedChanged);
            // 
            // rdoViewOptionWindow
            // 
            this.rdoViewOptionWindow.AutoSize = true;
            this.rdoViewOptionWindow.Checked = true;
            this.rdoViewOptionWindow.Location = new System.Drawing.Point(25, 39);
            this.rdoViewOptionWindow.Name = "rdoViewOptionWindow";
            this.rdoViewOptionWindow.Size = new System.Drawing.Size(75, 21);
            this.rdoViewOptionWindow.TabIndex = 5;
            this.rdoViewOptionWindow.TabStop = true;
            this.rdoViewOptionWindow.Text = "Window";
            this.rdoViewOptionWindow.UseVisualStyleBackColor = true;
            this.rdoViewOptionWindow.CheckedChanged += new System.EventHandler(this.rdoViewOptionWindow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(718, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(718, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.LightGreen;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnShow.Location = new System.Drawing.Point(908, 515);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 40);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightGreen;
            this.btnPDF.Enabled = false;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPDF.Location = new System.Drawing.Point(908, 562);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(94, 43);
            this.btnPDF.TabIndex = 5;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightGreen;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExit.Location = new System.Drawing.Point(908, 611);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 37);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelectPrinter
            // 
            this.btnSelectPrinter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSelectPrinter.Enabled = false;
            this.btnSelectPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSelectPrinter.Location = new System.Drawing.Point(908, 460);
            this.btnSelectPrinter.Name = "btnSelectPrinter";
            this.btnSelectPrinter.Size = new System.Drawing.Size(94, 49);
            this.btnSelectPrinter.TabIndex = 7;
            this.btnSelectPrinter.Text = "Select Printer";
            this.btnSelectPrinter.UseVisualStyleBackColor = false;
            this.btnSelectPrinter.Click += new System.EventHandler(this.btnSelectPrinter_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(798, 134);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(153, 20);
            this.dtFromDate.TabIndex = 8;
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(798, 174);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(153, 20);
            this.dtToDate.TabIndex = 9;
            // 
            // btnBillReportDemo
            // 
            this.btnBillReportDemo.Location = new System.Drawing.Point(1104, 364);
            this.btnBillReportDemo.Name = "btnBillReportDemo";
            this.btnBillReportDemo.Size = new System.Drawing.Size(75, 23);
            this.btnBillReportDemo.TabIndex = 10;
            this.btnBillReportDemo.Text = "BillReportDemo";
            this.btnBillReportDemo.UseVisualStyleBackColor = true;
            this.btnBillReportDemo.Visible = false;
            this.btnBillReportDemo.Click += new System.EventHandler(this.btnBillReportDemo_Click);
            // 
            // rdStockBalance
            // 
            this.rdStockBalance.AutoSize = true;
            this.rdStockBalance.Location = new System.Drawing.Point(33, 327);
            this.rdStockBalance.Name = "rdStockBalance";
            this.rdStockBalance.Size = new System.Drawing.Size(116, 21);
            this.rdStockBalance.TabIndex = 16;
            this.rdStockBalance.TabStop = true;
            this.rdStockBalance.Text = "Stock Balance";
            this.rdStockBalance.UseVisualStyleBackColor = true;
            this.rdStockBalance.CheckedChanged += new System.EventHandler(this.rdStockBalance_CheckedChanged);
            // 
            // SalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 650);
            this.Controls.Add(this.btnBillReportDemo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnSelectPrinter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SalesReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesReports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSalesSummary;
        private System.Windows.Forms.RadioButton rdoSalesRegister;
        private System.Windows.Forms.RadioButton rdoItemwiseSalesGroupwise;
        private System.Windows.Forms.RadioButton rdoItemWiseSales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoViewOptionToFile;
        private System.Windows.Forms.RadioButton rdoViewOptionPrinter;
        private System.Windows.Forms.RadioButton rdoViewOptionWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelectPrinter;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.RadioButton rdoDetailSalesReport;
        private System.Windows.Forms.RadioButton rdoInvoiceWiseSalesReport;
        private System.Windows.Forms.RadioButton rdEODReport;
        private System.Windows.Forms.RadioButton rdoDiscountReport;
        private System.Windows.Forms.RadioButton rdoSalesSummaryFirmwise;
        private System.Windows.Forms.Button btnBillReportDemo;
        private System.Windows.Forms.RadioButton rdPurchaseDetails;
        private System.Windows.Forms.RadioButton rdSalesDetails;
        private System.Windows.Forms.RadioButton rdStockBalance;
    }
}