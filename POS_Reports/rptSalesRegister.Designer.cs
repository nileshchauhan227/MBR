namespace POS_Reports
{
    partial class rptSalesRegister
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
            this.salesRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesRegisterTableAdapter = new POS_Reports.dsRutuTableAdapters.SalesRegisterTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRegisterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.salesRegisterBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptSalesRegister.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1206, 531);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesRegisterBindingSource
            // 
            this.salesRegisterBindingSource.DataMember = "SalesRegister";
            this.salesRegisterBindingSource.DataSource = this.dsRutu;
            // 
            // salesRegisterTableAdapter
            // 
            this.salesRegisterTableAdapter.ClearBeforeFill = true;
            // 
            // rptSalesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 531);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "rptSalesRegister";
            this.Text = "Sales Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptSalesRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRegisterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource salesRegisterBindingSource;
        private dsRutu dsRutu;
        private dsRutuTableAdapters.SalesRegisterTableAdapter salesRegisterTableAdapter;
    }
}