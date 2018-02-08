namespace Advics.Startup
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserLogin = new System.Windows.Forms.Label();
            this.pnlReceiving = new System.Windows.Forms.Panel();
            this.lblReceiving = new System.Windows.Forms.Label();
            this.pnlTransit = new System.Windows.Forms.Panel();
            this.lblTransit = new System.Windows.Forms.Label();
            this.pnlPicking = new System.Windows.Forms.Panel();
            this.lblPicking = new System.Windows.Forms.Label();
            this.pnlLogout = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgramVersion = new System.Windows.Forms.Label();
            this.pnlTracking = new System.Windows.Forms.Panel();
            this.lbTracking = new System.Windows.Forms.Label();
            this.pnlPickFS = new System.Windows.Forms.Panel();
            this.lbPickFS = new System.Windows.Forms.Label();
            this.pnlTransitATP = new System.Windows.Forms.Panel();
            this.lbTransitATP = new System.Windows.Forms.Label();
            this.pnlReceiving.SuspendLayout();
            this.pnlTransit.SuspendLayout();
            this.pnlPicking.SuspendLayout();
            this.pnlLogout.SuspendLayout();
            this.pnlTracking.SuspendLayout();
            this.pnlPickFS.SuspendLayout();
            this.pnlTransitATP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(108, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.Text = "RUBIX-WMS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(64, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 19);
            this.label2.Text = "Please select menu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblUserLogin
            // 
            this.lblUserLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lblUserLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserLogin.ForeColor = System.Drawing.Color.Gray;
            this.lblUserLogin.Location = new System.Drawing.Point(0, 0);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(225, 19);
            this.lblUserLogin.Text = "User : Admininstrator ";
            this.lblUserLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlReceiving
            // 
            this.pnlReceiving.BackColor = System.Drawing.Color.PaleVioletRed;
            this.pnlReceiving.Controls.Add(this.lblReceiving);
            this.pnlReceiving.Location = new System.Drawing.Point(0, 93);
            this.pnlReceiving.Name = "pnlReceiving";
            this.pnlReceiving.Size = new System.Drawing.Size(225, 30);
            this.pnlReceiving.Click += new System.EventHandler(this.pnlReceiving_Click);
            // 
            // lblReceiving
            // 
            this.lblReceiving.ForeColor = System.Drawing.Color.White;
            this.lblReceiving.Location = new System.Drawing.Point(4, 6);
            this.lblReceiving.Name = "lblReceiving";
            this.lblReceiving.Size = new System.Drawing.Size(166, 20);
            this.lblReceiving.Text = "Receiving Confirm (1)";
            this.lblReceiving.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlTransit
            // 
            this.pnlTransit.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlTransit.Controls.Add(this.lblTransit);
            this.pnlTransit.Location = new System.Drawing.Point(0, 123);
            this.pnlTransit.Name = "pnlTransit";
            this.pnlTransit.Size = new System.Drawing.Size(225, 30);
            this.pnlTransit.Click += new System.EventHandler(this.pnlTransit_Click);
            // 
            // lblTransit
            // 
            this.lblTransit.ForeColor = System.Drawing.Color.White;
            this.lblTransit.Location = new System.Drawing.Point(0, 6);
            this.lblTransit.Name = "lblTransit";
            this.lblTransit.Size = new System.Drawing.Size(170, 20);
            this.lblTransit.Text = "Transit Confirm (2)";
            this.lblTransit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlPicking
            // 
            this.pnlPicking.BackColor = System.Drawing.Color.ForestGreen;
            this.pnlPicking.Controls.Add(this.lblPicking);
            this.pnlPicking.Location = new System.Drawing.Point(0, 153);
            this.pnlPicking.Name = "pnlPicking";
            this.pnlPicking.Size = new System.Drawing.Size(225, 30);
            this.pnlPicking.Click += new System.EventHandler(this.pnlPicking_Click);
            // 
            // lblPicking
            // 
            this.lblPicking.ForeColor = System.Drawing.Color.White;
            this.lblPicking.Location = new System.Drawing.Point(0, 8);
            this.lblPicking.Name = "lblPicking";
            this.lblPicking.Size = new System.Drawing.Size(170, 20);
            this.lblPicking.Text = "Picking Confirm (3)";
            this.lblPicking.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlLogout
            // 
            this.pnlLogout.BackColor = System.Drawing.Color.Tomato;
            this.pnlLogout.Controls.Add(this.lblLogout);
            this.pnlLogout.Location = new System.Drawing.Point(0, 273);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(225, 30);
            this.pnlLogout.Click += new System.EventHandler(this.pnlLogout_Click);
            // 
            // lblLogout
            // 
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(4, 5);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(166, 20);
            this.lblLogout.Text = "Logout (0)";
            this.lblLogout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(61, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 19);
            this.label3.Text = "กรุณาเลือกรายการ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblProgramVersion.ForeColor = System.Drawing.Color.Green;
            this.lblProgramVersion.Location = new System.Drawing.Point(63, 19);
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size(154, 14);
            this.lblProgramVersion.Text = "Version : 0.1";
            this.lblProgramVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlTracking
            // 
            this.pnlTracking.BackColor = System.Drawing.Color.Orange;
            this.pnlTracking.Controls.Add(this.lbTracking);
            this.pnlTracking.Location = new System.Drawing.Point(0, 183);
            this.pnlTracking.Name = "pnlTracking";
            this.pnlTracking.Size = new System.Drawing.Size(225, 30);
            this.pnlTracking.Click += new System.EventHandler(this.pnlTracking_Click);
            // 
            // lbTracking
            // 
            this.lbTracking.ForeColor = System.Drawing.Color.White;
            this.lbTracking.Location = new System.Drawing.Point(0, 5);
            this.lbTracking.Name = "lbTracking";
            this.lbTracking.Size = new System.Drawing.Size(170, 20);
            this.lbTracking.Text = "QR Tracking (4)";
            this.lbTracking.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlPickFS
            // 
            this.pnlPickFS.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlPickFS.Controls.Add(this.lbPickFS);
            this.pnlPickFS.Location = new System.Drawing.Point(0, 243);
            this.pnlPickFS.Name = "pnlPickFS";
            this.pnlPickFS.Size = new System.Drawing.Size(225, 30);
            this.pnlPickFS.Click += new System.EventHandler(this.pnlPickFS_Click);
            // 
            // lbPickFS
            // 
            this.lbPickFS.ForeColor = System.Drawing.Color.White;
            this.lbPickFS.Location = new System.Drawing.Point(0, 8);
            this.lbPickFS.Name = "lbPickFS";
            this.lbPickFS.Size = new System.Drawing.Size(170, 20);
            this.lbPickFS.Text = "Pick Van (6)";
            this.lbPickFS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlTransitATP
            // 
            this.pnlTransitATP.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlTransitATP.Controls.Add(this.lbTransitATP);
            this.pnlTransitATP.Location = new System.Drawing.Point(0, 213);
            this.pnlTransitATP.Name = "pnlTransitATP";
            this.pnlTransitATP.Size = new System.Drawing.Size(225, 30);
            this.pnlTransitATP.Click += new System.EventHandler(this.pnlTransitATP_Click);
            // 
            // lbTransitATP
            // 
            this.lbTransitATP.ForeColor = System.Drawing.Color.White;
            this.lbTransitATP.Location = new System.Drawing.Point(0, 8);
            this.lbTransitATP.Name = "lbTransitATP";
            this.lbTransitATP.Size = new System.Drawing.Size(170, 20);
            this.lbTransitATP.Text = "Pallet Transit (5)";
            this.lbTransitATP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(242, 272);
            this.Controls.Add(this.pnlTransitATP);
            this.Controls.Add(this.pnlPickFS);
            this.Controls.Add(this.pnlTracking);
            this.Controls.Add(this.lblProgramVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlLogout);
            this.Controls.Add(this.pnlPicking);
            this.Controls.Add(this.pnlTransit);
            this.Controls.Add(this.pnlReceiving);
            this.Controls.Add(this.lblUserLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.Closed += new System.EventHandler(this.frmMainMenu_Closed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMainMenu_KeyUp);
            this.pnlReceiving.ResumeLayout(false);
            this.pnlTransit.ResumeLayout(false);
            this.pnlPicking.ResumeLayout(false);
            this.pnlLogout.ResumeLayout(false);
            this.pnlTracking.ResumeLayout(false);
            this.pnlPickFS.ResumeLayout(false);
            this.pnlTransitATP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserLogin;
        private System.Windows.Forms.Panel pnlReceiving;
        private System.Windows.Forms.Panel pnlTransit;
        private System.Windows.Forms.Panel pnlPicking;
        private System.Windows.Forms.Label lblReceiving;
        private System.Windows.Forms.Panel pnlLogout;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblTransit;
        private System.Windows.Forms.Label lblPicking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Panel pnlTracking;
        private System.Windows.Forms.Label lbTracking;
        private System.Windows.Forms.Panel pnlPickFS;
        private System.Windows.Forms.Label lbPickFS;
        private System.Windows.Forms.Panel pnlTransitATP;
        private System.Windows.Forms.Label lbTransitATP;

    }
}