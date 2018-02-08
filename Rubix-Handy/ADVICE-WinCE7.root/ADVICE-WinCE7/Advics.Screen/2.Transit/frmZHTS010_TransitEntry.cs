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

namespace Advics.Screen.Transit
{
    public partial class frmZHTS010_TransitEntry : formBase
    {
        #region Member
        TransitBusiness _db;
        #endregion

        #region Properties
        private TransitBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new TransitBusiness();
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
        public frmZHTS010_TransitEntry()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
        }
        #endregion

        #region Override Method

        #endregion

        #region Event Handler
        private void frmZHTS010_TransitEntry_Load(object sender, EventArgs e)
        {
            txtRMTagNo.Text = string.Empty;
            txtRMTagNo.Focus();
        }

        private void txtRMTagNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (base.OnKeyCommand(e))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (txtRMTagNo.Text.Trim() == string.Empty)
                        {
                            return;
                        }

                        char[] arrSplit = new char[] { ':' };
                        string[] arrBarCode = txtRMTagNo.Text.Trim().Split(arrSplit);
                        //0 = PO No.
                        //1 = PDS No.
                        //2 = Running No. --> 00001
                        //3 = Supplier Code
                        //4 = Item No.
                        //5 = Item Short Code
                        //6 = Qty level 3
                        //7 = Collect Date
                        if (arrBarCode.Length != 8)
                        {
                            MessageDialog.Show("สแกนหมายเลขใบรับไม่ถูกต้อง", AppConfig.Caption);
                            txtRMTagNo.Text = string.Empty;
                            return;
                        }

                        DataSet ds = Database.TransitEntry_Search(arrBarCode[1], arrBarCode[2]);
                        if (ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0)
                        {
                            MessageDialog.Show("สแกนหมายเลขใบรับไม่ถูกต้อง หรือ สแกนไปหมายเลขใบรับไปแล้ว", AppConfig.Caption);
                            txtRMTagNo.Text = string.Empty;
                            return;
                        }

                        txtRMTagNo.Text = string.Empty;
                        frmZHTS020_TransitConfirmationDetail frm = new frmZHTS020_TransitConfirmationDetail();
                        frm.dsTransitInformation = ds;
                        frm.RMTag = arrBarCode;
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtRMTagNo.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion
                
        #region Generic Function
                
        #endregion
    }
}