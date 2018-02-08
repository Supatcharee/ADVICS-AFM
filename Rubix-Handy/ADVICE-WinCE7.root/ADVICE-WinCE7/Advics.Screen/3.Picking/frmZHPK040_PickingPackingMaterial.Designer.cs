namespace Advics.Screen.Picking
{
    partial class frmZHPK040_PickingPackingMaterial
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRMTagNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.Text = "Scan R/M Tag";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.Text = "(สแกนหมายเลข R/M ที่ต้องการ)";
            // 
            // txtRMTagNo
            // 
            this.txtRMTagNo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTagNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtRMTagNo.Location = new System.Drawing.Point(1, 82);
            this.txtRMTagNo.Name = "txtRMTagNo";
            this.txtRMTagNo.Size = new System.Drawing.Size(234, 19);
            this.txtRMTagNo.TabIndex = 33;
            this.txtRMTagNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRMTagNo_KeyUp);
            // 
            // frmZHPK040_PickingPackingMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 267);
            this.Controls.Add(this.txtRMTagNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "frmZHPK040_PickingPackingMaterial";
            this.Text = "ZHPK040 : PickingPackingMaterial";
            this.Load += new System.EventHandler(this.frmZHPK040_PickingPackingMaterial_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRMTagNo, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRMTagNo;
    }
}