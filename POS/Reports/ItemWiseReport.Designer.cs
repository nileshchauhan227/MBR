namespace POS.Reports
{
    partial class ItemWiseReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.itemwiseReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pOS_Rutu_NDataSet = new POS.POS_Rutu_NDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.itemwiseReportTableAdapter = new POS.POS_Rutu_NDataSetTableAdapters.ItemwiseReportTableAdapter();
            this.pOS_Rutu_NDataSet3 = new POS.POS_Rutu_NDataSet3();
            this.pOSRutuNDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemwiseReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.itemwiseReportTableAdapter1 = new POS.POS_Rutu_NDataSet3TableAdapters.ItemwiseReportTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemwiseReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSRutuNDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemwiseReportBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemwiseReportBindingSource
            // 
            this.itemwiseReportBindingSource.DataMember = "ItemwiseReport";
            this.itemwiseReportBindingSource.DataSource = this.pOS_Rutu_NDataSet;
            // 
            // pOS_Rutu_NDataSet
            // 
            this.pOS_Rutu_NDataSet.DataSetName = "POS_Rutu_NDataSet";
            this.pOS_Rutu_NDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.itemwiseReportBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.ItemwiseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1216, 460);
            this.reportViewer1.TabIndex = 0;
            // 
            // itemwiseReportTableAdapter
            // 
            this.itemwiseReportTableAdapter.ClearBeforeFill = true;
            // 
            // pOS_Rutu_NDataSet3
            // 
            this.pOS_Rutu_NDataSet3.DataSetName = "POS_Rutu_NDataSet3";
            this.pOS_Rutu_NDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pOSRutuNDataSet3BindingSource
            // 
            this.pOSRutuNDataSet3BindingSource.DataSource = this.pOS_Rutu_NDataSet3;
            this.pOSRutuNDataSet3BindingSource.Position = 0;
            // 
            // itemwiseReportBindingSource1
            // 
            this.itemwiseReportBindingSource1.DataMember = "ItemwiseReport";
            this.itemwiseReportBindingSource1.DataSource = this.pOSRutuNDataSet3BindingSource;
            // 
            // itemwiseReportTableAdapter1
            // 
            this.itemwiseReportTableAdapter1.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Location = new System.Drawing.Point(-8, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 479);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnShow);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Font = new System.Drawing.Font("Bell MT", 12.75F);
            this.groupBox2.Location = new System.Drawing.Point(2, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 107);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itemwise Report";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(609, 61);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 26);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtTodate
            // 
            this.dtTodate.Location = new System.Drawing.Point(385, 61);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(200, 26);
            this.dtTodate.TabIndex = 11;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(99, 61);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(200, 26);
            this.dtFromDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(542, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 29);
            this.label3.TabIndex = 13;
            this.label3.Text = "ItemWise Report";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "From Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(305, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "To Date";
            // 
            // ItemWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ItemWiseReport";
            this.Text = "ItemWiseReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItemWiseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemwiseReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOS_Rutu_NDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSRutuNDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemwiseReportBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private POS_Rutu_NDataSet pOS_Rutu_NDataSet;
        private System.Windows.Forms.BindingSource itemwiseReportBindingSource;
        private POS_Rutu_NDataSetTableAdapters.ItemwiseReportTableAdapter itemwiseReportTableAdapter;
        private System.Windows.Forms.BindingSource itemwiseReportBindingSource1;
        private System.Windows.Forms.BindingSource pOSRutuNDataSet3BindingSource;
        private POS_Rutu_NDataSet3 pOS_Rutu_NDataSet3;
        private POS_Rutu_NDataSet3TableAdapters.ItemwiseReportTableAdapter itemwiseReportTableAdapter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}