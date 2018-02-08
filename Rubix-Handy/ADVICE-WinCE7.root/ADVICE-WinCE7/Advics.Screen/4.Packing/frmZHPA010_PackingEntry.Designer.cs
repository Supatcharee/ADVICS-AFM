namespace Advics.Screen.Packing
{
    partial class frmZHPA010_PackingEntry
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
            this.dtPackingDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackingNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtPackingDate
            // 
            this.dtPackingDate.CustomFormat = "dd/MM/yyyy";
            this.dtPackingDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.dtPackingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPackingDate.Location = new System.Drawing.Point(28, 199);
            this.dtPackingDate.Name = "dtPackingDate";
            this.dtPackingDate.Size = new System.Drawing.Size(316, 27);
            this.dtPackingDate.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(28, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 20);
            this.label4.Text = "(เลือกวันที่ตามแผนการแพ็ค)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(28, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 20);
            this.label6.Text = "Select Packing Date";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 20);
            this.label2.Text = "(สแกนหมายเลขแพ็ค)";
            // 
            // txtPackingNo
            // 
            this.txtPackingNo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPackingNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtPackingNo.Location = new System.Drawing.Point(28, 102);
            this.txtPackingNo.Name = "txtPackingNo";
            this.txtPackingNo.Size = new System.Drawing.Size(316, 26);
            this.txtPackingNo.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(28, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 20);
            this.label3.Text = "Scan Packing No.";
            // 
            // frmZHPA010_PackingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 415);
            this.Controls.Add(this.dtPackingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPackingNo);
            this.Controls.Add(this.label3);
            this.Name = "frmZHPA010_PackingEntry";
            this.Text = "ZHPA010 : Packing Entry";
            this.Load += new System.EventHandler(this.frmZHPA010_PackingEntry_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPackingNo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtPackingDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPackingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPackingNo;
        private System.Windows.Forms.Label label3;
    }
}