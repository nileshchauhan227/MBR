namespace POS_Reports
{
    partial class rptDetailSalesReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.detailSalesReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsRutu = new POS_Reports.dsRutu();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DetailSalesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DetailSalesReportTableAdapter = new POS_Reports.dsRutuTableAdapters.DetailSalesReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.detailSalesReportBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailSalesReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // detailSalesReportBindingSource1
            // 
            this.detailSalesReportBindingSource1.DataMember = "DetailSalesReport";
            this.detailSalesReportBindingSource1.DataSource = this.dsRutu;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.detailSalesReportBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptDetailSalesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1214, 569);
            this.reportViewer1.TabIndex = 0;
            // 
            // DetailSalesReportBindingSource
            // 
            this.DetailSalesReportBindingSource.DataMember = "DetailSalesReport";
            this.DetailSalesReportBindingSource.DataSource = this.dsRutu;
            // 
            // DetailSalesReportTableAdapter
            // 
            this.DetailSalesReportTableAdapter.ClearBeforeFill = true;
            // 
            // rptDetailSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 569);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "rptDetailSalesReport";
            this.Text = "Detail Sales Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptDetailSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailSalesReportBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailSalesReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DetailSalesReportBindingSource;
        private dsRutu dsRutu;
        private dsRutuTableAdapters.DetailSalesReportTableAdapter DetailSalesReportTableAdapter;
        private System.Windows.Forms.BindingSource detailSalesReportBindingSource1;
    }
}