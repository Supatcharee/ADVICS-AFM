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

namespace Advics.Screen.Transit
{
    public partial class frmZHTS020_TransitConfirmationDetail : formBase
    {
        #region Member
        TransitBusiness _db;
        #endregion

        #region Enumeration
        enum TransitHeader
        {
            ReceivingNo,
            ItemCode,
            ItemName,			
            ItemCondition,
            ExpiredDate,
            RunningNo,
            LocationCode,
            RemainQty
        }

        enum TransitDetail
        {
            LocationCode,
            LocationID,
            ReceiveQtyLevel2,
            TransitQtyLevel2,
            UnitLevel2
        }
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
        public DataSet dsTransitInformation { get; set; }
        public string[] RMTag  { get; set; }
        #endregion
        
        #region Constructor
        public frmZHTS020_TransitConfirmationDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(false, m_toolbarConfirm);
            ControlUtil.HiddenControl(true, m_toolbarOK);
        }
        #endregion

        #region Override Method

        #endregion

        #region Event Handler
        private void frmZHTS020_TransitConfirmationDetail_Load(object sender, EventArgs e)
        {
            base.HideOKConfirmButton();
            txtLocationCode.Focus();
            txtLocationCode.Text = string.Empty;
            InitialData();
        }
        
        private void txtLocationCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (base.OnKeyCommand(e))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (txtLocationCode.Text.Trim() == string.Empty)
                        {
                            return;
                        }
                        if (!string.IsNullOrEmpty(lblLocation.Text) && txtLocationCode.Text.Trim() != lblLocation.Text)
                        {
                            MessageDialog.Show("Location ไม่ถูกต้อง", AppConfig.Caption);
                            txtLocationCode.Text = string.Empty;
                            return;
                        }
                        //DataRow[] dr = dsTransitInformation.Tables[1].Select(string.Format(" LocationCode = '{0}' ", txtLocationCode.Text.Trim()));

                        //if (dr.Length == 0)
                        //{
                        //    MessageDialog.Show("พื้นที่จัดเก็บสินค้าไม่ถูกต้อง", AppConfig.Caption);
                        //    txtLocationCode.Text = string.Empty;
                        //    return;
                        //}
                        //RM Tag
                        //0 = PO No.
                        //1 = PDS No.
                        //2 = Running No. --> 00001
                        //3 = Supplier Code
                        //4 = Item No.
                        //5 = Item Short Code
                        //6 = Qty level 3
                        //7 = Collect Date

                        //Database.TransitConfirmationDetail_Save(RMTag[1], RMTag[2], Convert.ToInt32(dr[0]["LocationID"]), AppConfig.UserLogin);
                        Database.TransitConfirmationDetail_Save(RMTag[1], RMTag[2], txtLocationCode.Text.Trim(), AppConfig.UserLogin);

                        AppConfig.FormList.Clear();
                        txtLocationCode.Text = string.Empty;
                        frmZHTS010_TransitEntry frm = new frmZHTS010_TransitEntry();
                        AppConfig.FormList.Add(AppConfig.MainMenu);
                        frm.Show();
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtLocationCode.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       
        #endregion
       
        #region Generic Function
        private void InitialData()
        {
            lblReceivingNo.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.ReceivingNo.ToString()].ToString();
            lblItemCode.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.ItemCode.ToString()].ToString();
            lblItemName.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.ItemName.ToString()].ToString();
            lblRMTagNo.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.RunningNo.ToString()].ToString();
            lblLocation.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.LocationCode.ToString()].ToString();
            lblRemainQty.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.RemainQty.ToString()].ToString();
            if (dsTransitInformation.Tables[0].Rows[0][TransitHeader.ExpiredDate.ToString()] != DBNull.Value)
            {
                lblExpiryDate.Text = Convert.ToDateTime(dsTransitInformation.Tables[0].Rows[0][TransitHeader.ExpiredDate.ToString()]).ToString("dd/MM/yyyy");
            }
            else
            {
                lblExpiryDate.Text = "-";
            }
            lblItemCondition.Text = dsTransitInformation.Tables[0].Rows[0][TransitHeader.ItemCondition.ToString()].ToString();

          
        }
        #endregion

    }
}