/*
 * 15 Jan 2013: 
 * 1. change control from TextEdit to SpinEdit
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using System.Data.Objects;
namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit)]
    public partial class frmXMSS140_DeadStock : FormBase
    {
        #region Member
        private DeadStock db;
#endregion

        #region Properties
        private DeadStock BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new DeadStock();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmXMSS140_DeadStock()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarRefresh, m_toolBarExport);
            ControlUtil.HiddenControl(true, m_toolBarThemeStyls, m_toolBarPaintStyls);
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS140_DeadStock_Load(object sender, EventArgs e)
        {
            ClearAll();
            if (AUTError == null)
            {                
                DataLoading();                
            }
            EnableControl(false);
        }
        // 15 Jan 2013: don't allow to input less than 0
        private void txtEmptyStockDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpReceiveCompleteDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpReceiveInCompleteDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpShippingCompleteDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpShippingInCompleteDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpHistoryDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpBillingDataDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpBillingCostDay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        private void txtExpStockTaking_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                EnableControl(true);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    SavaData();
                    EnableControl(false);
                    MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                //DataLoading();
                return false;
            }
        }
        public override bool OnCommandCancel()
        {
            EnableControl(false);
            DataLoading();
            return base.OnCommandCancel();
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                DataTable dt = BusinessClass.GetData();
                if (dt.Rows.Count > 0)
                {
                    BusinessClass.SelectData = dt.Rows[0];
                    //-- Empty Stock Criteria
                    txtEmptyStockDay.Text = BusinessClass.EmptyStockDay.ToString();
                    //-- Empire Data Deletion Criteria

                    txtExpReceiveCompleteDay.Text = BusinessClass.ExpReceiveCompleteDay.ToString();
                    txtExpReceiveInCompleteDay.Text = BusinessClass.ExpReceiveIncompleteDay.ToString();
                    txtExpShippingCompleteDay.Text = BusinessClass.ExpShippingCompleteDay.ToString();
                    txtExpShippingInCompleteDay.Text = BusinessClass.ExpShippingIncompleteDay.ToString();
                    txtExpHistoryDay.Text = BusinessClass.ExpHistoryDay.ToString();
                    txtExpBillingDataDay.Text = BusinessClass.ExpBillingDataDay.ToString();
                    txtExpBillingCostDay.Text = BusinessClass.ExpBillingCostDay.ToString();
                    txtExpStockTaking.Text = BusinessClass.ExpStockTaking.ToString();

                    //txtExpSerialDataDay.Text = BusinessClass.ExpSerialDataDay.ToString();
                    //-- 
                    memoCodeDescription.Text = BusinessClass.CodeDescription;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAll()
        {
            errorProvider.ClearErrors();
            ControlUtil.ClearControlData(Controls);
        }

        private void EnableControl(bool Condition)
        {
            ControlUtil.EnableControl(Condition, Controls);
            ControlUtil.EnableControl(Condition, m_toolBarSave, m_toolBarCancel);
        }

        private void SavaData()
        {
            try
            {
                BusinessClass.CodeName = "DeadStockSetting";
                BusinessClass.CodeDescription = memoCodeDescription.Text.Trim();
                BusinessClass.EmptyStockDay = DataUtil.Convert<int>(txtEmptyStockDay.EditValue);
                BusinessClass.ExpReceiveCompleteDay = DataUtil.Convert<int>(txtExpReceiveCompleteDay.EditValue);
                BusinessClass.ExpReceiveIncompleteDay = DataUtil.Convert<int>(txtExpReceiveInCompleteDay.EditValue);
                BusinessClass.ExpShippingCompleteDay = DataUtil.Convert<int>(txtExpShippingCompleteDay.EditValue);
                BusinessClass.ExpShippingIncompleteDay = DataUtil.Convert<int>(txtExpShippingInCompleteDay.EditValue);
                BusinessClass.ExpHistoryDay = DataUtil.Convert<int>(txtExpHistoryDay.EditValue);
                BusinessClass.ExpBillingDataDay = DataUtil.Convert<int>(txtExpBillingDataDay.EditValue);
                BusinessClass.ExpBillingCostDay = DataUtil.Convert<int>(txtExpBillingCostDay.EditValue);
                BusinessClass.ExpSerialDataDay = 0;
                BusinessClass.ExpStockTaking = DataUtil.Convert<int>(txtExpStockTaking.EditValue);
                // end 15 Jan 2013: modify because there is comma in property Text
                BusinessClass.CreateUser = AppConfig.UserLogin;
                BusinessClass.UpdateUser = AppConfig.UserLogin;
                BusinessClass.SaveDeadStockData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
    }
}