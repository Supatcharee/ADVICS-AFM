namespace Advics.Screen.Picking
{
    partial class frmZHPK010_PickingEntry
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
            this.dtPickingDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPickingNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtPickingDate
            // 
            this.dtPickingDate.CustomFormat = "dd/MM/yyyy";
            this.dtPickingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickingDate.Location = new System.Drawing.Point(5, 161);
            this.dtPickingDate.Name = "dtPickingDate";
            this.dtPickingDate.ShowUpDown = true;
            this.dtPickingDate.Size = new System.Drawing.Size(159, 24);
            this.dtPickingDate.TabIndex = 32;
            this.dtPickingDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtPickingDate_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(5, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 20);
            this.label4.Text = "(เลือกวันที่ตามแผนการหยิบสินค้า)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(5, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.Text = "Select Picking Date";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.Text = "(สแกนหมายเลขใบหยิบสินค้า)";
            // 
            // txtPickingNo
            // 
            this.txtPickingNo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPickingNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPickingNo.Location = new System.Drawing.Point(2, 78);
            this.txtPickingNo.Name = "txtPickingNo";
            this.txtPickingNo.Size = new System.Drawing.Size(232, 19);
            this.txtPickingNo.TabIndex = 31;
            this.txtPickingNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPickingNo_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.Text = "Scan Picking No.";
            // 
            // frmZHPK010_PickingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.dtPickingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPickingNo);
            this.Controls.Add(this.label3);
            this.Name = "frmZHPK010_PickingEntry";
            this.Text = "ZHPK010 : Picking Entry";
            this.Load += new System.EventHandler(this.frmZHPK010_PickingEntry_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPickingNo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dtPickingDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPickingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPickingNo;
        private System.Windows.Forms.Label label3;

    }
}