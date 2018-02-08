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

namespace Advics.Screen.Picking
{
    public partial class frmZHPK010_PickingEntry : formBase
    {        
        #region Member
        PickingBusiness _db;
        #endregion

        #region Properties
        private PickingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new PickingBusiness();
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
        public frmZHPK010_PickingEntry()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
        }
        #endregion

        #region Override Method
        public override bool OnCommandOK()
        {
            try
            {
                if (dtPickingDate.Text == null)
                {
                    MessageDialog.Show("กรุณากรอกวันที่ตามแผนการหยิบสินค้า", AppConfig.Caption);
                    return false;
                }
                else
                {
                    DataTable dt = Database.PickingEntry_SearchBy_PickingDate(dtPickingDate.Value.ToString("yyyy/MM/dd"), AppConfig.UserLogin);
                    if (dt.Rows.Count <= 0)
                    {
                        MessageDialog.Show("ไม่มีรายการหยิบสินค้าในวันนี้", AppConfig.Caption);
                        txtPickingNo.Text = string.Empty;
                        return false;
                    }
                    else
                    {
                        txtPickingNo.Text = string.Empty;
                        frmZHPK020_PickingConfirmationList frm = new frmZHPK020_PickingConfirmationList();
                        frm.PickingDate = dtPickingDate.Value;
                        frm.dtPicking = dt;
                        frm.Show();
                        this.Hide();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtPickingNo.Text = string.Empty;
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmZHPK010_PickingEntry_Load(object sender, EventArgs e)
        {
            txtPickingNo.Focus();
            txtPickingNo.Text = string.Empty;
        }

        private void txtPickingNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (base.OnKeyCommand(e))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (txtPickingNo.Text.Trim() == string.Empty)
                        {
                            return;
                        }

                        char[] arrSplit = new char[] { ':' };
                        string[] arrBarCode = txtPickingNo.Text.Trim().Split(arrSplit);
                        string strPickingNo = string.Empty;

                        if (arrBarCode.Length != 1 && arrBarCode.Length != 4)
                        {
                            MessageDialog.Show("สแกนหมายเลขใบหยิบไม่ถูกต้อง", AppConfig.Caption);
                            txtPickingNo.Text = string.Empty;
                            return;
                        }

                        if (arrBarCode.Length == 4)
                        {
                            strPickingNo = arrBarCode[3];
                        }
                        else
                        {
                            strPickingNo = txtPickingNo.Text.Trim();
                        }
                        
                        DataSet ds = Database.PickingEntry_SearchBy_PickingNo(strPickingNo, 1);
                        if (ds.Tables.Count != 3 || ds.Tables[0].Rows.Count <= 0 || ds.Tables[1].Rows.Count <= 0 || ds.Tables[2].Rows.Count <= 0)
                        {
                            MessageDialog.Show("ไม่พบหมายเลขใบหยิบนี้ หรือ  หมายเลขใบหยิบนี้ได้ทำการหยิบไปแล้ว",AppConfig.Caption);
                            txtPickingNo.Text = string.Empty;
                            return;
                        }

                        txtPickingNo.Text = string.Empty;
                        frmZHPK030_PickingConfirmationDetail frm = new frmZHPK030_PickingConfirmationDetail();
                        frm.dsPicking = ds;
                        frm.CallFromScreen = 1;
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtPickingNo.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dtPickingDate_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }
        #endregion
                              
        #region Generic Function

        #endregion
    }
}