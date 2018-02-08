using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS070_FinalDestinationPicture : DevExpress.XtraEditors.XtraForm
	{


        #region Member
        private Image m_Image; 
        #endregion

        #region Properties

        public Image Picture
        {
            get { return m_Image; }
            set { m_Image = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS070_FinalDestinationPicture()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function

        private void dlgXMSS070_FinalDestinationPicture_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Picture;
            this.WindowState = FormWindowState.Maximized;
            this.ContextMenuStrip = contextMenuStrip1;
            contextMenuStrip1.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrinterResolution pr = e.PageSettings.PrinterResolution;
            DrawForm(e.Graphics, pr.X, pr.Y);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            printDialog1.Document = printDocument1;
        }
 
	#endregion

        #region Generic Function
        private void DrawForm(Graphics g, int resX, int resY)
        {
            int x = printDocument1.DefaultPageSettings.PaperSize.Width;
            int y = printDocument1.DefaultPageSettings.PaperSize.Height;
            g.DrawImage(pictureBox1.Image, 10, 20, x, y);

        } 
        #endregion
	}
}
