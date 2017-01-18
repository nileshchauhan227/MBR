namespace POS_Reports
{
    partial class rptBillDental
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
            this.ConfigurationSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRutu = new POS_Reports.dsRutu();
            this.GetBillDetail1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetBillDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConfigurationSettingTableAdapter = new POS_Reports.dsRutuTableAdapters.ConfigurationSettingTableAdapter();
            this.GetBillDetail1TableAdapter = new POS_Reports.dsRutuTableAdapters.GetBillDetail1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetail1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfigurationSettingBindingSource
            // 
            this.ConfigurationSettingBindingSource.DataMember = "ConfigurationSetting";
            this.ConfigurationSettingBindingSource.DataSource = this.dsRutu;
            // 
            // dsRutu
            // 
            this.dsRutu.DataSetName = "dsRutu";
            this.dsRutu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GetBillDetail1BindingSource
            // 
            this.GetBillDetail1BindingSource.DataMember = "GetBillDetail1";
            this.GetBillDetail1BindingSource.DataSource = this.dsRutu;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.ConfigurationSettingBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.GetBillDetail1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_Reports.rptBillDental.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(794, 339);
            this.reportViewer1.TabIndex = 0;
            // 
            // GetBillDetailBindingSource
            // 
            this.GetBillDetailBindingSource.DataMember = "GetBillDetail";
            this.GetBillDetailBindingSource.DataSource = this.dsRutu;
            // 
            // ConfigurationSettingTableAdapter
            // 
            this.ConfigurationSettingTableAdapter.ClearBeforeFill = true;
            // 
            // GetBillDetail1TableAdapter
            // 
            this.GetBillDetail1TableAdapter.ClearBeforeFill = true;
            // 
            // rptBillDental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 339);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptBillDental";
            this.Text = "rptBillDental";
            this.Load += new System.EventHandler(this.rptBillDental_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRutu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetail1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetBillDetailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetBillDetail1BindingSource;
        private dsRutu dsRutu;
        private System.Windows.Forms.BindingSource GetBillDetailBindingSource;
        private System.Windows.Forms.BindingSource ConfigurationSettingBindingSource;
        private dsRutuTableAdapters.GetBillDetailTableAdapter GetBillDetailTableAdapter;
        private dsRutuTableAdapters.ConfigurationSettingTableAdapter ConfigurationSettingTableAdapter;
        private dsRutuTableAdapters.GetBillDetail1TableAdapter GetBillDetail1TableAdapter;
        //private dsRutuTableAdapters.GetBillDetail1TableAdapter GetBillDetail1TableAdapter;
    }
}