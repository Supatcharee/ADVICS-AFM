using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using CSI.Business.BusinessFactory.Master;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS280_SystemConfig : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private SystemConfig db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public  SystemConfig  BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SystemConfig();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new SystemConfig();
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
        public dlgXMSS280_SystemConfig()
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
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    ControlUtil.EnableControl(false, txtConfigItem);
                }
            }
            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                clearControl();
                if (BusinessClass.ConfigItem != null)
                {
                    BusinessClass = new SystemConfig();
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
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtConfigItem.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistConfigID(txtConfigItem.Text.Trim()) && BusinessClass.ConfigItem != txtConfigItem.Text.Trim())
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
            ////Config Item
            if (txtConfigItem.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtConfigItem, Rubix.Screen.Common.GetMessage("I0220"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtConfigItem, String.Empty);
            }

            ////Config Value
            if (txtConfigValue.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtConfigValue, Rubix.Screen.Common.GetMessage("I0221"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtConfigValue, String.Empty);
            }
            return errFlag;
        }
        private void DataBinding()
        {
            txtConfigItem.Text = BusinessClass.ConfigItem;
            txtConfigValue.Text = BusinessClass.ConfigValue;
            memoDescription.Text = BusinessClass.Description; 
        }
        private void SaveData()
        {
            BusinessClass.ConfigItem = txtConfigItem.Text.Trim();
            BusinessClass.ConfigValue = txtConfigValue.Text.Trim();
            BusinessClass.Description = memoDescription.Text.Trim();
            BusinessClass.SaveSystemConfigData();
        }
        private void clearControl() 
        {
            ControlUtil.ClearControlData(txtConfigItem, txtConfigValue, memoDescription);
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