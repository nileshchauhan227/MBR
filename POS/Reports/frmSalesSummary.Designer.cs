namespace POS.Reports
{
    partial class frmSalesSummary
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
            this.salesSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOS_Rutu_NDataSet2 = new POS.POS_Rutu_NDataSet2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.salesSummaryTableAdapter = new POS.POS_Rutu_NDataSet2TableAdapters.SalesSummaryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salesSummaryBindingSource
            // 
            this.salesSummaryBindingSource.DataMember = "SalesSummary";
            this.salesSummaryBindingSource.DataSource = this.pOS_Rutu_NDataSet2;
            // 
            // pOS_Rutu_NDataSet2
            // 
            this.pOS_Rutu_NDataSet2.DataSetName = "POS_Rutu_NDataSet2";
            this.pOS_Rutu_NDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(3, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsSalesSummary";
            reportDataSource1.Value = this.salesSummaryBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.SalesSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1034, 396);
            this.reportViewer1.TabIndex = 0;
            // 
            // salesSummaryTableAdapter
            // 
            this.salesSummaryTableAdapter.ClearBeforeFill = true;
            // 
            // frmSalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 531);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSalesSummary";
            this.Text = "frmSalesSummary";
            this.Load += new System.EventHandler(this.frmSalesSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private POS_Rutu_NDataSet2 pOS_Rutu_NDataSet2;
        private System.Windows.Forms.BindingSource salesSummaryBindingSource;
        private POS_Rutu_NDataSet2TableAdapters.SalesSummaryTableAdapter salesSummaryTableAdapter;
    }
}