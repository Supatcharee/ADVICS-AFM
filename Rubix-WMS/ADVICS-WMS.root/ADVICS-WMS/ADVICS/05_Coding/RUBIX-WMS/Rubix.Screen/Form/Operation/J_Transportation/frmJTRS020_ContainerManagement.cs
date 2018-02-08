using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using Rubix.Screen.Form.Operation.J_Transportation.Dialog;


namespace Rubix.Screen.Form.Operation.J_Transportation
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.Edit,Permission.Add,Permission.Delete,Permission.Confirm)]
    public partial class frmJTRS020_ContainerManagement : FormBase
    {
        public frmJTRS020_ContainerManagement()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
        }
        #region Member

        private dlgJTRS021_ContainerManagement m_Dialog; 

        #endregion

        #region Properties

        private dlgJTRS021_ContainerManagement Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new dlgJTRS021_ContainerManagement();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        #endregion

        #region Override Method

        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        #endregion

        #region Generic Functiona
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.EnableControl(false, Dialog.Controls);
                }

                else if (ScreenMode == Common.eScreenMode.Add)
                {
                    ControlUtil.ClearControlData(Dialog.Controls);
                    ControlUtil.EnableControl(true, Dialog.Controls);
                }

                else if (ScreenMode == Common.eScreenMode.Edit)
                {
                    ControlUtil.EnableControl(true, Dialog.Controls);
                }
                Dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion

        private void frmJTRS020_ContainerManagement_Load(object sender, EventArgs e)
        {

        }
    }
}