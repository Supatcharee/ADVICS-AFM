using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using Advics.Framework;

namespace Advics.Screen.TransitAfterPack
{
    public partial class frmZHTP020_TransitafterPackEntryScanLocation : formBase
    {
        #region Member
        TransitAfterPackBusiness _db;
        DataSet _detailDS;
        int Flag = 0;
        string _PalletNo;
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

        public string PalletNo
        {
            get { return _PalletNo; }
            set { _PalletNo = value; }
        }

        public DataSet DetailDS
        {
            get { return _detailDS; }
            set { _detailDS = value; }
        }
        #endregion

        #region Constructor
        public frmZHTP020_TransitafterPackEntryScanLocation()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
        }
        #endregion

        #region Event Hendler

        private void frmZHTP020_TransitafterPackEntryScanLocation_Load(object sender, EventArgs e)
        {
            lblPalletNo.Text = PalletNo;
            if (DetailDS.Tables.Count > 0)
            {
                if (DetailDS.Tables[0].Rows.Count > 0)
                {
                    lblLocation.Text = DetailDS.Tables[0].Rows[0]["LocationCode"].ToString();
                }
            }
            txtLocationCode.Text = string.Empty;
            txtLocationCode.Focus();
        }

        private void txtLocationCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (txtLocationCode.Text.Trim() == "")
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }

                        if (!CheckLocationCode())
                        {
                            MessageDialog.Show("สแกนหมายเลข LocationCode ไม่ถูกต้อง", AppConfig.Caption);
                            txtLocationCode.Text = string.Empty;
                            txtLocationCode.Focus();
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            SaveUpdateTransitPack();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show(ex.Message, AppConfig.Caption);
                        txtLocationCode.Text = string.Empty;
                        Cursor.Current = Cursors.Default;
                    }
                }

            }
        }
        #endregion

        #region Generic Function
        private void SaveUpdateTransitPack()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtLocationCode.Text.Trim() == string.Empty)
                {
                    MessageDialog.Show("สแกนหมายเลข LocationCode ไม่ถูกต้อง", AppConfig.Caption);
                    txtLocationCode.Text = string.Empty;
                    txtLocationCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;

                }




                Database.TransitPack_SaveUpdate(lblPalletNo.Text.Trim(), txtLocationCode.Text.Trim(), Flag, AppConfig.UserLogin);

                //MessageDialog.Show("Transit After Pack Complete.", AppConfig.Caption);
                frmZHTP010_TransitAfterPackEntry frm = new frmZHTP010_TransitAfterPackEntry();
                AppConfig.FormList.Add(AppConfig.MainMenu);
                frm.Show();
                this.Dispose();
                //return;

            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtLocationCode.Text = string.Empty;
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private bool CheckLocationCode()
        {
            bool flag = false;
            if (txtLocationCode.Text.Trim() != "")
            {
                flag = Database.TransitPack_CheckPalletOrLocation("", txtLocationCode.Text.Trim());
            }

            return flag;
        }
        #endregion

        



    }
}