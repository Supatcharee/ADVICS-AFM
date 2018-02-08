namespace Advics.Screen
{
    partial class formBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formBase));
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMainMenu = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl1.Location = new System.Drawing.Point(80, 3);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(8, 15);
            this.lbl1.Text = "l";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(87, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 22);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl2.Location = new System.Drawing.Point(157, 3);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(10, 15);
            this.lbl2.Text = "l";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(165, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 22);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.Location = new System.Drawing.Point(166, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 22);
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(-2, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 2);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainMenu.Image")));
            this.btnMainMenu.Location = new System.Drawing.Point(0, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(81, 22);
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // statusBar
            // 
            this.statusBar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.statusBar.Location = new System.Drawing.Point(0, 252);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(238, 20);
            this.statusBar.Text = "ชื่อผู้ใช้ : Administrator   |  Version : 0.1";
            // 
            // formBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbl1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formBase";
            this.Text = "formBase";
            this.Load += new System.EventHandler(this.formBase_Load);
            this.Closed += new System.EventHandler(this.formBase_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.PictureBox btnOK;
        private System.Windows.Forms.PictureBox btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnMainMenu;
        private System.Windows.Forms.StatusBar statusBar;
    }
}