namespace Advics.Screen.Transit
{
    partial class frmZHTS010_TransitEntry
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
            this.txtRMTagNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRMTagNo
            // 
            this.txtRMTagNo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTagNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtRMTagNo.Location = new System.Drawing.Point(2, 81);
            this.txtRMTagNo.Name = "txtRMTagNo";
            this.txtRMTagNo.Size = new System.Drawing.Size(234, 19);
            this.txtRMTagNo.TabIndex = 32;
            this.txtRMTagNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRMTagNo_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.Text = "Scan R/M Tag";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.Text = "(สแกนหมายเลข R/M สินค้าที่ต้องการจัดเก็บ)";
            // 
            // frmZHTS010_TransitEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRMTagNo);
            this.Controls.Add(this.label3);
            this.Name = "frmZHTS010_TransitEntry";
            this.Text = "ZHTS010 : Transit Entry";
            this.Load += new System.EventHandler(this.frmZHTS010_TransitEntry_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtRMTagNo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRMTagNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}