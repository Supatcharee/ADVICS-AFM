using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;

namespace Advics.Screen.Packing
{
    public partial class frmZHPA010_PackingEntry : formBase
    {
        #region Member

        #endregion

        #region Properties

        #endregion

        #region Override Method
        public override bool OnCommandOK()
        {
            try
            {
                if (dtPackingDate.Text == null)
                {
                    MessageBox.Show("กรุณากรอกวันที่ตามแผนการบรรจุภัณฑ์สินค้า");
                    return false;
                }
                else
                {
                    frmZHPA020_PackingConfirmationList frm = new frmZHPA020_PackingConfirmationList();
                    frm.PackingDate = dtPackingDate.Value;
                    frm.Show();
                    this.Hide();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Constructor
        public frmZHPA010_PackingEntry()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
        }
        #endregion

        #region Event Handler
        private void frmZHPA010_PackingEntry_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Generic Function

        #endregion
    }
}