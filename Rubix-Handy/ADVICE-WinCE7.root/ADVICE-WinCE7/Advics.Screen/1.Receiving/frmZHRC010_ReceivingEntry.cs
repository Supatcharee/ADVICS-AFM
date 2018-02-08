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

namespace Advics.Screen.Receiving
{
    public partial class frmZHRC010_ReceivingEntry : formBase
    {
        #region Member
        ReceivingBusiness _db;
        #endregion

        #region Properties
        private ReceivingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new ReceivingBusiness();
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
        public frmZHRC010_ReceivingEntry()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
        }
        #endregion

        #region Override Method
        public override bool  OnCommandOK()
        {
            try
            {
                if (dtReceivingDate.Text == null)
                {
                    MessageDialog.Show("กรุณากรอกวันที่ตามแผนการรับสินค้า", AppConfig.Caption);
                    return false;                       
                }
                else
                {
                    DataTable dt = Database.ReceivingEntry_SearchBy_ReceivingDate(dtReceivingDate.Value.ToString("yyyy/MM/dd"), AppConfig.UserLogin);
                    if (dt.Rows.Count <= 0)
                    {
                        MessageDialog.Show("ไม่มีรายการรับสินค้าในวันนี้", AppConfig.Caption);
                        txtBarcode.Text = string.Empty;
                        return false;
                    }

                    txtBarcode.Text = string.Empty;
                    frmZHRC020_ReceivingConfirmationList frm = new frmZHRC020_ReceivingConfirmationList();  
                    frm.ReceivingDate = dtReceivingDate.Value;
                    frm.dtReceivingData = dt;
                    frm.Show();
                    this.Hide();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtBarcode.Text = string.Empty;
                return false;
            }
        }
        #endregion
        
        #region Event Handler
        private void frmZHRC010_ReceivingEntry_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = string.Empty;
            dtReceivingDate.Value = DateTime.Now;
            txtBarcode.Focus();
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (base.OnKeyCommand(e))
                {
                    //Scan PDS QR Code
                    if (e.KeyCode == Keys.Enter)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (txtBarcode.Text.Trim() == string.Empty)
                        {                                   
                            return;
                        }

                        char[] arrSplit = new char[] { ':' };
                        string[] arrBarCode = txtBarcode.Text.Trim().Split(arrSplit);
                        //0 = QR-PDS
                        //1 = PO No.
                        //2 = PDS No.
                        //3 = Receiving No.
                        if (arrBarCode.Length != 4)
                        {
                            MessageDialog.Show("สแกนหมายเลขใบรับไม่ถูกต้อง", AppConfig.Caption);         
                            txtBarcode.Text = string.Empty;
                            return;
                        }

                        if (arrBarCode[0] != "QR-PDS")
                        {
                            MessageDialog.Show("สแกนหมายเลขใบรับไม่ถูกต้อง", AppConfig.Caption);   
                            txtBarcode.Text = string.Empty;
                            return;
                        }

                        DataSet ds = Database.ReceivingEntry_SearchBy_ReceivingNo(arrBarCode[3], 1);
                        if (ds.Tables.Count != 3 || 
                            ds.Tables[0].Rows.Count <= 0 || 
                            ds.Tables[1].Rows.Count <= 0 ||
                            ds.Tables[2].Rows.Count <= 0)
                        {
                            MessageDialog.Show("ไม่พบหมายเลขใบรับนี้ หรือ หมายเลขใบรับนี้ได้ทำการรับไปแล้ว", AppConfig.Caption);   
                            txtBarcode.Text = string.Empty;
                            return;
                        }

                        txtBarcode.Text = string.Empty;
                        frmZHRC030_ReceivingConfirmationDetail frm = new frmZHRC030_ReceivingConfirmationDetail();
                        frm.dsReceiving = ds;
                        frm.CallFromScreen = 1;
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtBarcode.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dtReceivingDate_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }
        #endregion
                       
        #region Generic Function

        #endregion
    }
}