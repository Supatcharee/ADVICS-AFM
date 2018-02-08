namespace Advics.Screen.Packing
{
    partial class frmZHPA040_PackagingMaterialConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZHPA040_PackagingMaterialConfirmation));
            this.txtRMTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPlus = new System.Windows.Forms.PictureBox();
            this.btnMinus = new System.Windows.Forms.PictureBox();
            this.btnOKQTY = new System.Windows.Forms.PictureBox();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcProductCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grcMaterialType = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grdProductName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcMaterialTag = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // txtRMTag
            // 
            this.txtRMTag.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTag.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtRMTag.Location = new System.Drawing.Point(3, 56);
            this.txtRMTag.Name = "txtRMTag";
            this.txtRMTag.Size = new System.Drawing.Size(372, 26);
            this.txtRMTag.TabIndex = 57;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 21);
            this.label3.Text = "สแกน Packaging Material Tag :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.Text = "จำนวน (ชิ้น) :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Moccasin;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(114, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 26);
            this.textBox1.TabIndex = 61;
            // 
            // btnPlus
            // 
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(206, 91);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(14, 13);
            this.btnPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnMinus
            // 
            this.btnMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnMinus.Image")));
            this.btnMinus.Location = new System.Drawing.Point(206, 105);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(14, 11);
            this.btnMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnOKQTY
            // 
            this.btnOKQTY.Image = ((System.Drawing.Image)(resources.GetObject("btnOKQTY.Image")));
            this.btnOKQTY.Location = new System.Drawing.Point(233, 93);
            this.btnOKQTY.Name = "btnOKQTY";
            this.btnOKQTY.Size = new System.Drawing.Size(73, 21);
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(5, 123);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(370, 262);
            this.grdResult.TabIndex = 67;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcProductCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.grcMaterialType);
            this.gdtTableStyle.GridColumnStyles.Add(this.grdProductName);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcMaterialTag);
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.Format = "";
            this.gdcProductCode.FormatInfo = null;
            this.gdcProductCode.HeaderText = "รหัส (Code)";
            this.gdcProductCode.MappingName = "ProductCode";
            // 
            // gdcQTY
            // 
            this.gdcQTY.Format = "";
            this.gdcQTY.FormatInfo = null;
            this.gdcQTY.HeaderText = "จำนวน (ชิ้น)";
            this.gdcQTY.MappingName = "QTY";
            // 
            // grcMaterialType
            // 
            this.grcMaterialType.Format = "";
            this.grcMaterialType.FormatInfo = null;
            this.grcMaterialType.HeaderText = "ประเภท";
            this.grcMaterialType.MappingName = "MaterialType";
            // 
            // grdProductName
            // 
            this.grdProductName.Format = "";
            this.grdProductName.FormatInfo = null;
            this.grdProductName.HeaderText = "ชื่อ (Name)";
            this.grdProductName.MappingName = "ProductName";
            // 
            // gdcMaterialTag
            // 
            this.gdcMaterialTag.Format = "";
            this.gdcMaterialTag.FormatInfo = null;
            this.gdcMaterialTag.HeaderText = "Packing R/M Tag";
            this.gdcMaterialTag.MappingName = "RMTag";
            // 
            // frmZHPA040_PackagingMaterialConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 415);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.btnOKQTY);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRMTag);
            this.Controls.Add(this.label3);
            this.Name = "frmZHPA040_PackagingMaterialConfirmation";
            this.Text = "ZHPA040 : Packaging Material Confirmation";
            this.Load += new System.EventHandler(this.frmZHPA040_PackagingMaterialConfirmation_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtRMTag, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.btnPlus, 0);
            this.Controls.SetChildIndex(this.btnMinus, 0);
            this.Controls.SetChildIndex(this.btnOKQTY, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRMTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox btnPlus;
        private System.Windows.Forms.PictureBox btnMinus;
        private System.Windows.Forms.PictureBox btnOKQTY;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn gdcProductCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcQTY;
        private System.Windows.Forms.DataGridTextBoxColumn grdProductName;
        private System.Windows.Forms.DataGridTextBoxColumn gdcMaterialTag;
        private System.Windows.Forms.DataGridTextBoxColumn grcMaterialType;
    }
}