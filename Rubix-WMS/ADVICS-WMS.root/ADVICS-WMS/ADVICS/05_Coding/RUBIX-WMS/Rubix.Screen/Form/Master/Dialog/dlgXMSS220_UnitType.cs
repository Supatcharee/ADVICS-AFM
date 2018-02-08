using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS220_UnitType : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private TypeOfUnit db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public TypeOfUnit BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TypeOfUnit();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new TypeOfUnit();
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
        public dlgXMSS220_UnitType()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS220_UnitType_Load(object sender, EventArgs e)
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
                clearControl();
                if (BusinessClass.UnitCode != null)
                {
                    BusinessClass = new TypeOfUnit();
                }
            }
            else
            {
                DataBinding();
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtUnitName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistUnitCode(txtUnitCode.Text.Trim()) && BusinessClass.UnitCode != txtUnitCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0070"));
                            return false;
                        }
                        
                        SaveData();
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
            ////Unit Code
            if (txtUnitCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtUnitCode, Rubix.Screen.Common.GetMessage("I0072"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtUnitCode, String.Empty);
            }

            ////Unit Name
            if (txtUnitName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtUnitName, Rubix.Screen.Common.GetMessage("I0073"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtUnitName, String.Empty);
            }
            return errFlag;
        }
        private void DataBinding()
        {
            txtUnitCode.Text = BusinessClass.UnitCode;
            txtUnitName.Text = BusinessClass.UnitName;
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
        private void SaveData()
        {
            BusinessClass.UnitCode = txtUnitCode.Text.Trim();
            BusinessClass.UnitName = txtUnitName.Text.Trim();
            BusinessClass.Remark = memoRemark.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveUnitData();
        }
        private void clearControl() 
        {
            ControlUtil.ClearControlData(txtUnitCode, txtUnitName, memoRemark);
        }
        public void ClearData()
        {
            errorProvider.ClearErrors();
            ControlUtil.ClearControlData(this.Controls);
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