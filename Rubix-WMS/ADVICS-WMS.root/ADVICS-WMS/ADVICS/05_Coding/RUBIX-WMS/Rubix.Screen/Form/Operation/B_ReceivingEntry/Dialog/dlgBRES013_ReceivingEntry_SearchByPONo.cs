using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;

namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    public partial class dlgBRES013_ReceivingEntry_SearchByPONo : SubDialogBase
    {
        #region Member

        private ReceivingEntry db = null; 


        #endregion

        #region Properties

        public ReceivingEntry BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingEntry();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        public int OwnerID { get; set; }
        public int WarehouseID { get; set; }
        public int SupplierID { get; set; }
        public string PONo { get; set; }
        public string PDSNo { get; set; }

        #endregion

        #region Override Method

        public override bool OnCommandOK()
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                if (dr != null)
                {
                    this.PONo = dr["PONo"].ToString();
                    this.PDSNo = dr["PDSNo"].ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                
            }
            return false;
        }

        #endregion

        #region Event Handler

        public dlgBRES013_ReceivingEntry_SearchByPONo()
        {
            InitializeComponent();
        }

        private void dlgBRES013_ReceivingEntry_SearchByPONo_Load(object sender, EventArgs e)
        {
            try
            {
                
                dtCustomerPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtCustomerPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {

                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Generic Function

        private void DataLoading()
        {

            grdSearchResult.DataSource = BusinessClass.LoadPONo(OwnerID
                                                                , WarehouseID
                                                                , SupplierID
                                                                , dtCustomerPOIssueDateFrom.EditValue == null ? null : dtCustomerPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd")
                                                                , dtCustomerPOIssueDateTo.EditValue == null ? null : dtCustomerPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"));
            base.GridViewOnChangeLanguage(grdSearchResult);
        }

        #endregion

        
    }
}