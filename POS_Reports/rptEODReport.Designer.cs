namespace POS_Reports
{
    partial class rptEODReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsRutu = new POS_Reports.dsRutu();
            this.EODReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EODReportTableAdapter = new POS_Reports.dsRutuTableAdapters.EODReportTableAdapter();
            this.eODReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EODReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eODReportBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsEOD";
            reportDataSource1.Value = this.EODReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptEODReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1065, 553);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EODReportBindingSource
            // 
            this.EODReportBindingSource.DataMember = "EODReport";
            this.EODReportBindingSource.DataSource = this.dsRutu;
            // 
            // EODReportTableAdapter
            // 
            this.EODReportTableAdapter.ClearBeforeFill = true;
            // 
            // eODReportBindingSource1
            // 
            this.eODReportBindingSource1.DataMember = "EODReport";
            this.eODReportBindingSource1.DataSource = this.dsRutu;
            // 
            // rptEODReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 553);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptEODReport";
            this.Text = "rptEODReport";
            this.Load += new System.EventHandler(this.rptEODReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EODReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eODReportBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EODReportBindingSource;
        private dsRutu dsRutu;
        private dsRutuTableAdapters.EODReportTableAdapter EODReportTableAdapter;
        private System.Windows.Forms.BindingSource eODReportBindingSource1;
    }
}