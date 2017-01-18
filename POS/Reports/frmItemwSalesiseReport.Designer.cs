namespace POS.Reports
{
    partial class frmItemwSalesiseReport
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
            this.itemwSalesiseReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOSRutuNDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOS_Rutu_NDataSet1 = new POS.POS_Rutu_NDataSet1();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.itemwSalesiseReportTableAdapter = new POS.POS_Rutu_NDataSet1TableAdapters.ItemwSalesiseReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.itemwSalesiseReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSRutuNDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemwSalesiseReportBindingSource
            // 
            this.itemwSalesiseReportBindingSource.DataMember = "ItemwSalesiseReport";
            this.itemwSalesiseReportBindingSource.DataSource = this.pOSRutuNDataSet1BindingSource;
            // 
            // pOSRutuNDataSet1BindingSource
            // 
            this.pOSRutuNDataSet1BindingSource.DataSource = this.pOS_Rutu_NDataSet1;
            this.pOSRutuNDataSet1BindingSource.Position = 0;
            // 
            // pOS_Rutu_NDataSet1
            // 
            this.pOS_Rutu_NDataSet1.DataSetName = "POS_Rutu_NDataSet1";
            this.pOS_Rutu_NDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 570);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ItemwSalesiseReport";
            reportDataSource1.Value = this.itemwSalesiseReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.ItemwSalesiseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1216, 551);
            this.reportViewer1.TabIndex = 0;
            // 
            // itemwSalesiseReportTableAdapter
            // 
            this.itemwSalesiseReportTableAdapter.ClearBeforeFill = true;
            // 
            // frmItemwSalesiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 531);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmItemwSalesiseReport";
            this.Text = "frmItemwSalesiseReport";
            this.Load += new System.EventHandler(this.frmItemwSalesiseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemwSalesiseReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSRutuNDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pOSRutuNDataSet1BindingSource;
        private POS_Rutu_NDataSet1 pOS_Rutu_NDataSet1;
        private System.Windows.Forms.BindingSource itemwSalesiseReportBindingSource;
        private POS_Rutu_NDataSet1TableAdapters.ItemwSalesiseReportTableAdapter itemwSalesiseReportTableAdapter;
    }
}