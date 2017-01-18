namespace POS
{
    partial class frmMaintainBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ddlKOTDate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDifference = new System.Windows.Forms.Label();
            this.lblSelectedTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDayDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdMaintainKOTDetails = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenrateBill = new System.Windows.Forms.Button();
            this.KotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaintainKOTDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlKOTDate
            // 
            this.ddlKOTDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlKOTDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlKOTDate.FormattingEnabled = true;
            this.ddlKOTDate.Location = new System.Drawing.Point(146, 10);
            this.ddlKOTDate.Name = "ddlKOTDate";
            this.ddlKOTDate.Size = new System.Drawing.Size(167, 28);
            this.ddlKOTDate.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(753, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Difference";
            // 
            // lblDifference
            // 
            this.lblDifference.AutoSize = true;
            this.lblDifference.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifference.Location = new System.Drawing.Point(920, 368);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(40, 20);
            this.lblDifference.TabIndex = 49;
            this.lblDifference.Text = "0.00";
            // 
            // lblSelectedTotal
            // 
            this.lblSelectedTotal.AutoSize = true;
            this.lblSelectedTotal.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTotal.Location = new System.Drawing.Point(533, 368);
            this.lblSelectedTotal.Name = "lblSelectedTotal";
            this.lblSelectedTotal.Size = new System.Drawing.Size(40, 20);
            this.lblSelectedTotal.TabIndex = 48;
            this.lblSelectedTotal.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Selected Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Day Total";
            // 
            // lblDayDate
            // 
            this.lblDayDate.AutoSize = true;
            this.lblDayDate.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayDate.Location = new System.Drawing.Point(165, 368);
            this.lblDayDate.Name = "lblDayDate";
            this.lblDayDate.Size = new System.Drawing.Size(40, 20);
            this.lblDayDate.TabIndex = 45;
            this.lblDayDate.Text = "0.00";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Bell MT", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(529, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 31);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaintain
            // 
            this.btnMaintain.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMaintain.Font = new System.Drawing.Font("Bell MT", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintain.Location = new System.Drawing.Point(424, 392);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(87, 31);
            this.btnMaintain.TabIndex = 43;
            this.btnMaintain.Text = "Maintain";
            this.btnMaintain.UseVisualStyleBackColor = true;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Bell MT", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(370, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 31);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Show";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdMaintainKOTDetails
            // 
            this.grdMaintainKOTDetails.AllowUserToDeleteRows = false;
            this.grdMaintainKOTDetails.AllowUserToOrderColumns = true;
            this.grdMaintainKOTDetails.AllowUserToResizeRows = false;
            this.grdMaintainKOTDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMaintainKOTDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KotId,
            this.Column1,
            this.InvoiceNo,
            this.InvoiceDate,
            this.Time,
            this.Name,
            this.NetAmount,
            this.column2});
            this.grdMaintainKOTDetails.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.grdMaintainKOTDetails.Location = new System.Drawing.Point(12, 47);
            this.grdMaintainKOTDetails.MultiSelect = false;
            this.grdMaintainKOTDetails.Name = "grdMaintainKOTDetails";
            this.grdMaintainKOTDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMaintainKOTDetails.Size = new System.Drawing.Size(1182, 312);
            this.grdMaintainKOTDetails.TabIndex = 41;
            this.grdMaintainKOTDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMaintainKOTDetails_CellContentClick);
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bell MT", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Date";
            // 
            // btnGenrateBill
            // 
            this.btnGenrateBill.Font = new System.Drawing.Font("Bell MT", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenrateBill.Location = new System.Drawing.Point(1018, 392);
            this.btnGenrateBill.Name = "btnGenrateBill";
            this.btnGenrateBill.Size = new System.Drawing.Size(110, 31);
            this.btnGenrateBill.TabIndex = 53;
            this.btnGenrateBill.Text = "Genrate Bill";
            this.btnGenrateBill.UseVisualStyleBackColor = true;
            this.btnGenrateBill.Click += new System.EventHandler(this.btnGenrateBill_Click);
            // 
            // KotId
            // 
            this.KotId.DataPropertyName = "KOTID";
            this.KotId.HeaderText = "Id";
            this.KotId.Name = "KotId";
            this.KotId.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IsSelected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = false;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Day Bo";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.DataPropertyName = "SRNumber";
            this.InvoiceNo.HeaderText = "Inv No";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "strKOTDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvoiceDate.HeaderText = "Inv Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "strKOTTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle3;
            this.Time.FillWeight = 300F;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 300;
            // 
            // NetAmount
            // 
            this.NetAmount.DataPropertyName = "NetAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // column2
            // 
            this.column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column2.HeaderText = "";
            this.column2.Name = "column2";
            // 
            // frmMaintainBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 531);
            this.Controls.Add(this.btnGenrateBill);
            this.Controls.Add(this.ddlKOTDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDifference);
            this.Controls.Add(this.lblSelectedTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDayDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMaintain);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdMaintainKOTDetails);
            this.Controls.Add(this.label3);
            //this.Name = "frmMaintainBill";
            this.Text = "Maintain";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.grdMaintainKOTDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlKOTDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDifference;
        private System.Windows.Forms.Label lblSelectedTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDayDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMaintain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grdMaintainKOTDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenrateBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn KotId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;

    }
}