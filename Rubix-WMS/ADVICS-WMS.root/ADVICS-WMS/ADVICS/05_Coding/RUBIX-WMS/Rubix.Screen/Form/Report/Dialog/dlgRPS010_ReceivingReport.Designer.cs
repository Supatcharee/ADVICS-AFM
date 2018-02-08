namespace Rubix.Screen.Form.Report.Dialog
{
    partial class dlgRPS010_ReceivingReport
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
            this.attentionControl = new Rubix.Control.AttentionControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // attentionControl
            // 
            this.attentionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attentionControl.DistinctOwnerIDs = null;
            this.attentionControl.Location = new System.Drawing.Point(1, 31);
            this.attentionControl.Name = "attentionControl";
            this.attentionControl.Size = new System.Drawing.Size(503, 337);
            this.attentionControl.TabIndex = 4;
            // 
            // dlgRPS010_ReceivingReport
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 400);
            this.Controls.Add(this.attentionControl);
            this.Name = "dlgRPS010_ReceivingReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPS011 : Receiving Report Dialog";
            this.Load += new System.EventHandler(this.dlgRPS010_ReceivingReport_Load);
            this.Controls.SetChildIndex(this.attentionControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.AttentionControl attentionControl;
    }
}