using System;
using System.Collections.Generic;
using CSI.Business.Operation;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmXMSS290_ForceRunProcess : FormBase
    {
        #region Member
        private ProcessConfig db = null;
        #endregion

        #region Property
        private ProcessConfig BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProcessConfig();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmXMSS290_ForceRunProcess()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarDelete, m_toolBarExport, m_toolBarRefresh, m_toolBarView, m_toolBarSave, m_toolBarEdit, m_toolBarCancel);
            ControlUtil.HiddenControl(true, m_toolBarThemeStyls, m_toolBarPaintStyls);
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS290_ForceRunProcess_Load(object sender, EventArgs e)
        {
            ControlUtil.HiddenControl(true, m_toolBarEdit);
        }

        private void btnRunDaily_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                BusinessClass.RunDailyProcess();
                CloseWaitScreen();
                MessageDialog.ShowInformationMsg(Common.GetMessage("I0169"));
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnRunMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                BusinessClass.RunMonthlyProcess();
                CloseWaitScreen();
                MessageDialog.ShowInformationMsg(Common.GetMessage("I0169"));
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnAutoCalculateProcess_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                BusinessClass.AutoCalPlanProcess();
                CloseWaitScreen();
                MessageDialog.ShowInformationMsg(Common.GetMessage("I0169"));
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion
   }
}