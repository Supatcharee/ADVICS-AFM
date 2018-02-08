namespace Advics.Screen.Receiving
{
    partial class frmZHRC010_ReceivingEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtReceivingDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.Text = "Scan PDS No.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.Text = "(สแกนหมายเลขการรับสินค้า)";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.PowderBlue;
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(2, 83);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(232, 19);
            this.txtBarcode.TabIndex = 13;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(5, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.Text = "(เลือกวันที่ตามแผนการรับสินค้า)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(5, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 20);
            this.label6.Text = "Select Receiving Date";
            // 
            // dtReceivingDate
            // 
            this.dtReceivingDate.CustomFormat = "dd/MM/yyyy";
            this.dtReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivingDate.Location = new System.Drawing.Point(7, 171);
            this.dtReceivingDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtReceivingDate.Name = "dtReceivingDate";
            this.dtReceivingDate.ShowUpDown = true;
            this.dtReceivingDate.Size = new System.Drawing.Size(149, 24);
            this.dtReceivingDate.TabIndex = 23;
            this.dtReceivingDate.TabStop = false;
            this.dtReceivingDate.Value = new System.DateTime(2014, 11, 14, 0, 0, 0, 0);
            this.dtReceivingDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtReceivingDate_KeyUp);
            // 
            // frmZHRC010_ReceivingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.dtReceivingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmZHRC010_ReceivingEntry";
            this.Text = "ZHRC010 : Receiving Entry";
            this.Load += new System.EventHandler(this.frmZHRC010_ReceivingEntry_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBarcode, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtReceivingDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtReceivingDate;
    }
}