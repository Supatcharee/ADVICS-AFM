using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using Rubix.Framework;
namespace StartUp.MainFrame
{
    public partial class MainSkin : DevExpress.XtraEditors.XtraForm
    {
        public MainMenu Main
        {
            get;
            set;
        }

        public MainSkin()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(gctTheme, true, true, true);
            DevExpress.LookAndFeel.Helpers.ControlUserLookAndFeel.Default.StyleChanged += new EventHandler(gctTheme_StyleChanged);
        }

        private void gctTheme_MouseLeave(object sender, EventArgs e)
        {
            Point mouseLocation = ((MouseEventArgs)(e)).Location;

            if (mouseLocation.X > this.Size.Width ||
                mouseLocation.X < 0 ||
                mouseLocation.Y > this.Size.Height ||
                mouseLocation.Y < 0)
            {
                this.Hide();
            }
        }

        private void gctTheme_StyleChanged(object sender, EventArgs e)
        {
            AppConfig.ScreenThemeStyle = DevExpress.LookAndFeel.Helpers.ControlUserLookAndFeel.Default.ActiveSkinName;
        }

        private void gctTheme_Click(object sender, EventArgs e)
        {
            //Main.SetPanelColor();
        }

    }
}