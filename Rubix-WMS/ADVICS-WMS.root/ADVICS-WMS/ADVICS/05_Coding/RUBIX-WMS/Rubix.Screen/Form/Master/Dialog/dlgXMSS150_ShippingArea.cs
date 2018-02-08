using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using CSI.Business;
using Rubix.Framework;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS150_ShippingArea : DialogBase, Rubix.Framework.IClearable
    {
        #region Member        
        String strShippingAreaID = String.Empty;
        String strShippingAreaCode = String.Empty;
        private ShippingArea db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public String hippingAreaID
        {
            get { return strShippingAreaID; }
            set { strShippingAreaID = value; }
        }
        public String ShippingAreaCode
        {
            get { return strShippingAreaCode; }
            set { strShippingAreaCode = value; }
        }
        public ShippingArea BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingArea();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ShippingArea();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS150_ShippingArea()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS150_ShippingArea_Load(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }
            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                warehouseControl.DataLoading();
                clearControl();
                if (BusinessClass.ShippingAreaCode != null)
                {
                    BusinessClass = new ShippingArea();
                }
            }

            else
            {
                DataBinding();
                ControlUtil.EnableControl(false, warehouseControl);
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtShippingAreaName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistShippingAreaCode(txtShippingAreaCode.Text.Trim(), warehouseControl.WarehouseID.Value) && txtShippingAreaCode.Text.Trim() != BusinessClass.ShippingAreaCode)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0066"));
                            return false;
                        }
                        
                        SavaData();
                        DialogResult = DialogResult.OK;
                        return true;


                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandClear()
        {
            ControlUtil.ClearControlData(this);
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Shipping Area Code
            if (txtShippingAreaCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtShippingAreaCode, Rubix.Screen.Common.GetMessage("I0064"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtShippingAreaCode, String.Empty);
            }

            ////Shipping Area Name
            if (txtShippingAreaName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtShippingAreaName, Rubix.Screen.Common.GetMessage("I0065"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtShippingAreaName, String.Empty);
            }

            ////Warehouse Code
            warehouseControl.RequireField = true;
            warehouseControl.ErrorText = Rubix.Screen.Common.GetMessage("I0045");
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }
           
            return errFlag;
        }

        private void DataBinding()
        {
            //warehouseControl.SetwarehouseCode = 4;
            warehouseControl.WarehouseCode = BusinessClass.WarehouseCode;
            txtShippingAreaCode.Text = BusinessClass.ShippingAreaCode;
            txtShippingAreaName.Text = BusinessClass.ShippingAreaName;
            memoRemark.Text = BusinessClass.Remark;
            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private void SavaData()
        {
            BusinessClass.WarehouseID = warehouseControl.WarehouseID.Value;
            BusinessClass.WarehouseCode = warehouseControl.WarehouseCode;
            BusinessClass.ShippingAreaCode = txtShippingAreaCode.Text.Trim();
            BusinessClass.ShippingAreaName = txtShippingAreaName.Text.Trim();
            BusinessClass.Remark = memoRemark.Text;
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveShippingAreaData();

        }

        private void clearControl()
        {
            ControlUtil.ClearControlData(txtShippingAreaCode
                                       , txtShippingAreaName
                                       , memoRemark);
            warehouseControl.DataLoading();
        }
        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                clearControl();
            }
            else
            {
                DataBinding();
            }
        }
        #endregion
    }
}