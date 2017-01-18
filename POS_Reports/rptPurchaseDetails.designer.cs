namespace POS_Reports
{
    partial class rptPurchaseDetails
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
            this.GetDetailsOfPurchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GetDetailsOfPurchaseTableAdapter = new POS_Reports.dsRutuTableAdapters.GetDetailsOfPurchaseTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetDetailsOfPurchaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GetDetailsOfPurchaseBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptPurchaseDetails.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(518, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GetDetailsOfPurchaseBindingSource
            // 
            this.GetDetailsOfPurchaseBindingSource.DataMember = "GetDetailsOfPurchase";
            this.GetDetailsOfPurchaseBindingSource.DataSource = this.dsRutu;
            // 
            // GetDetailsOfPurchaseTableAdapter
            // 
            this.GetDetailsOfPurchaseTableAdapter.ClearBeforeFill = true;
            // 
            // rptPurchaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptPurchaseDetails";
            this.Text = "rptPurchaseDetails";
            this.Load += new System.EventHandler(this.rptPurchaseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetDetailsOfPurchaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetDetailsOfPurchaseBindingSource;
        private dsRutu dsRutu;
        private dsRutuTableAdapters.GetDetailsOfPurchaseTableAdapter GetDetailsOfPurchaseTableAdapter;
    }
}