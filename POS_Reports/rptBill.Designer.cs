namespace POS_Reports
{
    partial class rptBill
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsRutu = new POS_Reports.dsRutu();
            this.GetBillDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.GetBillDetailTableAdapter = new POS_Reports.dsRutuTableAdapters.GetBillDetailTableAdapter();
            this.ConfigurationSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConfigurationSettingTableAdapter = new POS_Reports.dsRutuTableAdapters.ConfigurationSettingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GetBillDetailBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.ConfigurationSettingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1214, 569);
            this.reportViewer1.TabIndex = 2;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GetBillDetailBindingSource
            // 
            this.GetBillDetailBindingSource.DataMember = "GetBillDetail";
            this.GetBillDetailBindingSource.DataSource = this.dsRutu;
            // 
            // GetBillDetailTableAdapter
            // 
           // this.GetBillDetailTableAdapter.ClearBeforeFill = true;
            // 
            // ConfigurationSettingBindingSource
            // 
            this.ConfigurationSettingBindingSource.DataMember = "ConfigurationSetting";
            this.ConfigurationSettingBindingSource.DataSource = this.dsRutu;
            // 
            // ConfigurationSettingTableAdapter
            // 
            this.ConfigurationSettingTableAdapter.ClearBeforeFill = true;
            // 
            // rptBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 569);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptBill";
            this.Text = "rptBill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationSettingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetBillDetailBindingSource;
        private dsRutu dsRutu;
        private System.Windows.Forms.BindingSource ConfigurationSettingBindingSource;
        //private dsRutuTableAdapters.GetBillDetailTableAdapter GetBillDetailTableAdapter;
        private dsRutuTableAdapters.ConfigurationSettingTableAdapter ConfigurationSettingTableAdapter;
    }
}