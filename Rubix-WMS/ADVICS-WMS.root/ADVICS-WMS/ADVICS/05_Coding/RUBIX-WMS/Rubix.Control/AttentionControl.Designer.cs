namespace Rubix.Control
{
    partial class AttentionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttentionControl));
            this.trlAttention = new DevExpress.XtraTreeList.TreeList();
            this.trcColAttention = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList();
            this.trcCustomerId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trlAttention)).BeginInit();
            this.SuspendLayout();
            // 
            // trlAttention
            // 
            this.trlAttention.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trlAttention.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcColAttention,
            this.trcCustomerId});
            this.trlAttention.Location = new System.Drawing.Point(3, 3);
            this.trlAttention.Name = "trlAttention";
            this.trlAttention.OptionsBehavior.Editable = false;
            this.trlAttention.OptionsView.ShowHorzLines = false;
            this.trlAttention.OptionsView.ShowVertLines = false;
            this.trlAttention.SelectImageList = this.imgList;
            this.trlAttention.Size = new System.Drawing.Size(272, 189);
            this.trlAttention.TabIndex = 0;
            this.trlAttention.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.trlAttention_AfterExpand);
            this.trlAttention.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trlAttention_MouseClick);
            // 
            // trcColAttention
            // 
            this.trcColAttention.Caption = "Attention";
            this.trcColAttention.FieldName = "Attention";
            this.trcColAttention.MinWidth = 33;
            this.trcColAttention.Name = "trcColAttention";
            this.trcColAttention.Visible = true;
            this.trcColAttention.VisibleIndex = 0;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "screen.png");
            this.imgList.Images.SetKeyName(1, "computer.png");
            this.imgList.Images.SetKeyName(2, "user1.png");
            this.imgList.Images.SetKeyName(3, "user2.png");
            this.imgList.Images.SetKeyName(4, "emblem-people.png");
            this.imgList.Images.SetKeyName(5, "group_permission.png");
            this.imgList.Images.SetKeyName(6, "1327374351_edit_group.png");
            this.imgList.Images.SetKeyName(7, "screen1.png");
            this.imgList.Images.SetKeyName(8, "screen2.png");
            this.imgList.Images.SetKeyName(9, "screen3.png");
            this.imgList.Images.SetKeyName(10, "screen4.png");
            this.imgList.Images.SetKeyName(11, "screen5.png");
            this.imgList.Images.SetKeyName(12, "screen6.png");
            this.imgList.Images.SetKeyName(13, "Check-icon.png");
            // 
            // trcCustomerId
            // 
            this.trcCustomerId.Caption = "CustomerId";
            this.trcCustomerId.FieldName = "CustomerId";
            this.trcCustomerId.Name = "trcCustomerId";
            // 
            // AttentionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trlAttention);
            this.Name = "AttentionControl";
            this.Size = new System.Drawing.Size(278, 195);
            ((System.ComponentModel.ISupportInitialize)(this.trlAttention)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trlAttention;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcColAttention;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcCustomerId;
    }
}
