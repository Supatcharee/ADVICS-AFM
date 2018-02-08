namespace StartUp.MainFrame
{
    partial class MainSkin
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
            this.gctTheme = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            ((System.ComponentModel.ISupportInitialize)(this.gctTheme)).BeginInit();
            this.gctTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // gctTheme
            // 
            this.gctTheme.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gctTheme.Controls.Add(this.galleryControlClient1);
            this.gctTheme.DesignGalleryGroupIndex = 0;
            this.gctTheme.DesignGalleryItemIndex = 0;
            this.gctTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // galleryControlGallery1
            // 
            this.gctTheme.Gallery.FixedHoverImageSize = false;
            this.gctTheme.Gallery.FixedImageSize = false;
            this.gctTheme.Gallery.ShowItemText = true;
            this.gctTheme.Location = new System.Drawing.Point(0, 0);
            this.gctTheme.Name = "gctTheme";
            this.gctTheme.Size = new System.Drawing.Size(786, 468);
            this.gctTheme.TabIndex = 9;
            this.gctTheme.Click += new System.EventHandler(this.gctTheme_Click);
            this.gctTheme.MouseLeave += new System.EventHandler(this.gctTheme_MouseLeave);
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.gctTheme;
            this.galleryControlClient1.Location = new System.Drawing.Point(3, 3);
            this.galleryControlClient1.Size = new System.Drawing.Size(763, 462);
            // 
            // MainSkin
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 468);
            this.ControlBox = false;
            this.Controls.Add(this.gctTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainSkin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gctTheme)).EndInit();
            this.gctTheme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl gctTheme;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}