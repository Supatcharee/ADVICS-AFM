using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;
using BusinessLayer;

namespace Advics.Screen.TransitAfterPack
{
    public partial class frmZHTP010_TransitAfterPackEntry : formBase
    {


        #region Member
        TransitAfterPackBusiness _db;
        int Flag = 0;
        #endregion

        #region Properties
        private TransitAfterPackBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new TransitAfterPackBusiness();
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        #endregion

        #region Constructor
       
        public frmZHTP010_TransitAfterPackEntry()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
            txtQRCode.Focus();
        }

        #endregion

        #region Override Method

        #endregion

        #region Event Handler
       

        private void frmZHTP010_TransitAfterPackEntry_Load(object sender, EventArgs e)
        {
            txtQRCode.Text = string.Empty;
        }

        private void txtQRCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (txtQRCode.Text.Trim() == "")
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }

                        if (!CheckPalletNo())
                        {
                            MessageDialog.Show("สแกนหมายเลข QRCode ไม่ถูกต้อง", AppConfig.Caption);
                            txtQRCode.Text = string.Empty;
                            txtQRCode.Focus();
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            frmZHTP020_TransitafterPackEntryScanLocation frm = new frmZHTP020_TransitafterPackEntryScanLocation();
                            frm.PalletNo = txtQRCode.Text;
                            frm.DetailDS = Database.GetDetailByPallet(txtQRCode.Text);
                            txtQRCode.Text = string.Empty;
                            txtQRCode.Focus();
                            frm.Show();
                            this.Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show(ex.Message, AppConfig.Caption);
                        txtQRCode.Text = string.Empty;
                        txtQRCode.Focus();
                        Cursor.Current = Cursors.Default;
                    }
                   
                }
            }

        }
        #endregion

        #region Generic Function
        
        private bool CheckPalletNo()
        {
            bool flag = false;
            if (txtQRCode.Text.Trim() != "")
            {
                flag = Database.TransitPack_CheckPalletOrLocation(txtQRCode.Text.Trim(), "");
            }

            return flag;
        }
        #endregion

     
       

        

        
       
       
    }
}