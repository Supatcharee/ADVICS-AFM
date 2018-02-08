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

namespace Advics.Screen.Picking
{
    public partial class frmZHPK040_PickingPackingMaterial : formBase
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

        #region Override Method

        #endregion

        #region Constructor
        public frmZHPK040_PickingPackingMaterial()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
        }
        #endregion

        #region Event Handler
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
                        DataSet ds = new DataSet();
                        ds.DataSetName = "DataSet";
                        DataTable dt = new DataTable();
                        dt.TableName = "DataTable";
                        dt.Columns.Add("PDSNo", typeof(string));
                        dt.Columns.Add("RunningNo", typeof(string));
                        dt.Columns.Add("Qty", typeof(string));
                        ds.Tables.Add(dt);
                        string PDSNo = arrBarCode[1];
                        string RunningNo = arrBarCode[2];
                        string Qty = arrBarCode[6];
                        dt.Rows.Add(PDSNo, RunningNo, Qty);
                        Database.PickingPackingMaterial_Save(ds.GetXml(), AppConfig.UserLogin);
                        txtRMTagNo.Text = string.Empty;
                        txtRMTagNo.Focus();
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

        private void frmZHPK040_PickingPackingMaterial_Load(object sender, EventArgs e)
        {

            //txtRMTagNo.Text = "PSM-16-06-01:1-PSM-1606-01:00001:PSM:BB-112:BB-112:1.0000:2016/06/01";
            txtRMTagNo.Text = string.Empty;
            txtRMTagNo.Focus();
        }
        #endregion

        #region Generic Function

        #endregion
    }
}