namespace POS
{
    partial class frmDailyOpenClose
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
            this.btnStartDayTransaction = new System.Windows.Forms.Button();
            this.btnEndDayTransaction = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnStartDayTransaction
            // 
            this.btnStartDayTransaction.Enabled = false;
            this.btnStartDayTransaction.Location = new System.Drawing.Point(48, 205);
            this.btnStartDayTransaction.Name = "btnStartDayTransaction";
            this.btnStartDayTransaction.Size = new System.Drawing.Size(131, 23);
            this.btnStartDayTransaction.TabIndex = 24;
            this.btnStartDayTransaction.Text = "Start Day Transaction";
            this.btnStartDayTransaction.UseVisualStyleBackColor = true;
            this.btnStartDayTransaction.Click += new System.EventHandler(this.btnStartDayTransaction_Click);
            // 
            // btnEndDayTransaction
            // 
            this.btnEndDayTransaction.Enabled = false;
            this.btnEndDayTransaction.Location = new System.Drawing.Point(195, 205);
            this.btnEndDayTransaction.Name = "btnEndDayTransaction";
            this.btnEndDayTransaction.Size = new System.Drawing.Size(126, 23);
            this.btnEndDayTransaction.TabIndex = 25;
            this.btnEndDayTransaction.Text = "End Day Transaction\r\n";
            this.btnEndDayTransaction.UseVisualStyleBackColor = true;
            this.btnEndDayTransaction.Click += new System.EventHandler(this.btnEndDayTransaction_Click);
            // 
            // dtDate
            // 
            this.dtDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(168, 60);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(153, 20);
            this.dtDate.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(45, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "From Date";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNote.Location = new System.Drawing.Point(45, 103);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(46, 17);
            this.lblNote.TabIndex = 28;
            this.lblNote.Text = "Note :";
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNote.Location = new System.Drawing.Point(98, 103);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(223, 65);
            this.txtNote.TabIndex = 30;
            this.txtNote.Text = "You can start transaction after Start Day Transaction.";
            // 
            // frmDailyOpenClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEndDayTransaction);
            this.Controls.Add(this.btnStartDayTransaction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyOpenClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Open/Close";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDailyOpenClose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartDayTransaction;
        private System.Windows.Forms.Button btnEndDayTransaction;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.RichTextBox txtNote;
    }
}