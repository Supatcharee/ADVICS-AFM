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
    public partial class dlgXMSS230_WorkMethod : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private WorkMethod db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public WorkMethod BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new WorkMethod();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new WorkMethod();
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
        public dlgXMSS230_WorkMethod()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS230_WorkMethod_Load(object sender, EventArgs e)
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
                if (BusinessClass.WorkMethodCode != null)
                {
                    BusinessClass = new WorkMethod();
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
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtWorkMethodName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistWorkMethodCode(txtWorkMethodCode.Text.Trim()) && BusinessClass.WorkMethodCode != txtWorkMethodCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0076"));
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
            txtWorkMethodCode.Text = BusinessClass.WorkMethodCode;
            txtWorkMethodName.Text = BusinessClass.WorkMethodName;
            memoDesc.Text = BusinessClass.Description;

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
            BusinessClass.WorkMethodCode = txtWorkMethodCode.Text.Trim();
            BusinessClass.WorkMethodName = txtWorkMethodName.Text.Trim();
            BusinessClass.Description = memoDesc.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveWorkMethodData();
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtWorkMethodCode,txtWorkMethodName,memoDesc);
            
        }
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Work Method Code
            if (txtWorkMethodCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtWorkMethodCode, Rubix.Screen.Common.GetMessage("I0074"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtWorkMethodCode, String.Empty);
            }

            ////Work Method Name
            if (txtWorkMethodName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtWorkMethodName, Rubix.Screen.Common.GetMessage("I0075"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtWorkMethodName, String.Empty);
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