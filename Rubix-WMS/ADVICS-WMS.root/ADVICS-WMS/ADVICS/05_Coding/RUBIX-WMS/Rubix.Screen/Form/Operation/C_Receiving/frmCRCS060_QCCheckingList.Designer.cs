namespace Rubix.Screen.Form.Operation.C_Receiving
{
    partial class frmCRCS060_QCCheckingList
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
            this.components = new System.ComponentModel.Container();
            this.picQCPicture = new System.Windows.Forms.PictureBox();
            this.lblErrorMessage = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Rubix.Screen.WaitFormBase), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQCPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(415, 47);
            // 
            // picQCPicture
            // 
            this.picQCPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picQCPicture.Location = new System.Drawing.Point(0, 31);
            this.picQCPicture.Name = "picQCPicture";
            this.picQCPicture.Size = new System.Drawing.Size(415, 343);
            this.picQCPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQCPicture.TabIndex = 69;
            this.picQCPicture.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(12, 12);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(136, 23);
            this.lblErrorMessage.TabIndex = 70;
            this.lblErrorMessage.Text = "Error Message";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCRCS060_QCCheckingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 374);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.picQCPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCRCS060_QCCheckingList";
            this.ShowInTaskbar = false;
            this.Text = "CRCS060 : QC Checking List";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCRCS060_QCCheckingList_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCRCS060_QCCheckingList_KeyPress);
            this.Controls.SetChildIndex(this.picQCPicture, 0);
            this.Controls.SetChildIndex(this.lblErrorMessage, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQCPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picQCPicture;
        private DevExpress.XtraEditors.LabelControl lblErrorMessage;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}