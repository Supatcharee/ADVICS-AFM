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
    public partial class dlgXMSS110_ItemCondition : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        String strProductConditionID = String.Empty;
        String strProductConditionCode = String.Empty;
        private Condition db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public String ProductConditionID
        {
            get { return strProductConditionID; }
            set { strProductConditionID = value; }
        }
        public String ProductConditionCode
        {
            get { return strProductConditionCode; }
            set { strProductConditionCode = value; }
        }
        public Condition BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Condition();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Condition();
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
        public dlgXMSS110_ItemCondition()
        {
            InitializeComponent();
        }
        #endregion
               
        #region Event Handler Function
        private void dlgXMSS110_ItemCondition_Load(object sender, EventArgs e)
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
                if (BusinessClass.ProductConditionCode != null)
                {
                    BusinessClass = new Condition();
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
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtCondName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistProductConditionCode(txtCondCode.Text.Trim()) && BusinessClass.ProductConditionCode.Trim() != txtCondCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0041"));
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
            ////Product Condition Code
            if (txtCondCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCondCode, Rubix.Screen.Common.GetMessage("I0039"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtCondCode, String.Empty);
            }

            ////Product Condition Name
            if (txtCondName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCondName, Rubix.Screen.Common.GetMessage("I0040"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtCondName, String.Empty);
            }
            return errFlag;
        }

        private void DataBinding()
        {
            txtCondCode.Text = BusinessClass.ProductConditionCode;
            txtCondName.Text = BusinessClass.ProductConditionName;
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
            BusinessClass.ProductConditionCode = txtCondCode.Text.Trim();
            BusinessClass.ProductConditionName = txtCondName.Text.Trim();
            BusinessClass.Remark = memoRemark.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveConditionData();
        }

        private void clearControl()
        {
            try
            {
                ControlUtil.ClearControlData(Controls);
            }
            catch (Exception ex)
            {
                
            }
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