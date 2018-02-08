using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;

namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    public partial class dlgASO031_SaleOrderByContainer : DialogBase
    {
        #region Member
        private SalePurchaseOrder db;
        #endregion

        #region Properties
        private SalePurchaseOrder BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                return db;
            }
        }
        public string SONo { get; set; }
        #endregion

        #region Constructor
        public dlgASO031_SaleOrderByContainer()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
        } 
        #endregion

        #region Override Method

        #endregion

        #region Event Handler
        private void dlgASO031_CheckingSaleOrder_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        } 
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdResult.DataSource = null;
                grdResult.DataSource = BusinessClass.CheckingSaleOrderByContainer(SONo);
                base.GridViewOnChangeLanguage(grdResult);
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

    }
}