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
    public partial class dlgXMSS240_ItemClassification : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private Classification db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public Classification BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Classification();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Classification();
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
        public dlgXMSS240_ItemClassification()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS240_ItemClassification_Load(object sender, EventArgs e)
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
                if (BusinessClass.ClassificationCode != null)
                {
                    BusinessClass = new Classification();
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
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtClassificationName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistClassificationCode(txtClassificationCode.Text.Trim()) && BusinessClass.ClassificationCode != txtClassificationCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0079"));
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
        private void DataBinding()
        {
            txtClassificationCode.Text = BusinessClass.ClassificationCode;
            txtClassificationName.Text = BusinessClass.ClassificationName;
            //ownerControl.OwnerCode = BusinessClass.CustomerCode;         2013-04-05  ownerControl is  not  use
            memoRemark.Text = BusinessClass.Remark;

            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.CreateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }
        private void SaveData()
        {
            BusinessClass.ClassificationCode = txtClassificationCode.Text.Trim();
            BusinessClass.ClassificationName = txtClassificationName.Text.Trim();
            BusinessClass.Remark = memoRemark.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveClassificationData();
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtClassificationCode, txtClassificationName, memoRemark);
        }
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Classification Code
            if (txtClassificationCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtClassificationCode, Rubix.Screen.Common.GetMessage("I0077"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtClassificationCode, String.Empty);
            }

            ////Classification Name
            if (txtClassificationName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtClassificationName, Rubix.Screen.Common.GetMessage("I0078"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtClassificationName, String.Empty);
            }

            return errFlag;
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