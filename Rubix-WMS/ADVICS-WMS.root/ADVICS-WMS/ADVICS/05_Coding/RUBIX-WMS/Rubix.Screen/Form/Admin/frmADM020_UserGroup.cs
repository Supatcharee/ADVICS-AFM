using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using CSI.Business.Admin;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Rubix.Framework;
namespace Rubix.Screen.Form.Admin
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmADM020_UserGroup : FormBase
    {
        #region Member
        private UserGroup db;
        private Dialog.dlgADM020_UserGroup m_Dialog = null;
        private Dictionary<int, List<sp_ADM020_LoadUserByGroup_Result>> dicChild = new Dictionary<int, List<sp_ADM020_LoadUserByGroup_Result>>();
        #endregion

        #region Properties
        private UserGroup BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserGroup();
                }
                return db;
            }
        }
        private Dialog.dlgADM020_UserGroup Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgADM020_UserGroup();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = null;
            }
        }
        #endregion

        #region Constructure
        public frmADM020_UserGroup()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        } 
        #endregion

        #region Event Handler Function
        private void frmMAS020_UserGroup_Load(object sender, EventArgs e)
        {
            try
            {
                gdvSearchResult.OptionsDetail.ShowDetailTabs = false;
                DataLoading();
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }        

        private void gdvSearchResult_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            if (dicChild.ContainsKey(e.RowHandle))
            {
                e.ChildList = dicChild[e.RowHandle];                
            }
        }

        private void gdvSearchResult_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            try
            {
                ShowWaitScreen();
                gdvSearchResult.BeginUpdate();
                if (!dicChild.ContainsKey(e.RowHandle))
                    dicChild.Add(e.RowHandle, null);

                List<sp_ADM020_LoadUserByGroup_Result> list = new List<sp_ADM020_LoadUserByGroup_Result>();
                foreach (sp_ADM020_LoadUserByGroup_Result data in BusinessClass.LoadUserByGroup(this.GetGroupIDByRowHandle(e.RowHandle)))
                {
                    list.Add(data);
                }
                dicChild[e.RowHandle] = list;
                e.IsEmpty = (list.Count == 0);
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
            }
            finally
            {
                CloseWaitScreen();
                gdvSearchResult.EndUpdate();
            }
        }

        private void gdvSearchResult_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void gdvSearchResult_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "User List";
           if (e.RowHandle >= 0)
           {
               base.GridViewChildOnChangeLanguage(grdSearchResult, e.RowHandle);               
           }
        }

        private void grdSearchResult_FocusedViewChanged(object sender, ViewFocusEventArgs e)
        {
            try
            {
                if (e.View != null && e.View.IsDetailView)
                    (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        public override bool OnCommandDelete()
        {
            if (gdvSearchResult.RowCount <= 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                return false;
            }
            try
            {
                string groupName = GetSelectedGroupName();
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), groupName)) == DialogButton.Yes)
                {
                    BusinessClass.DeleteGroup(GetSelectedGroupID());
                    DataLoading();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                if (ScreenMode != Common.eScreenMode.Add)
                {
                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return;
                    }
                    Dialog.GroupID = GetSelectedGroupID();
                }

                Dialog.ScreenMode = ScreenMode;
                Dialog.BusinessClass = this.BusinessClass;

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                }
                Dialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DataLoading()
        {
            ShowWaitScreen();
            grdSearchResult.DataSource = BusinessClass.LoadGroup();

            for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
            {
                if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                {
                    gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                    gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                }
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gdvSearchResult.Columns)
            {
                if (gc.FieldName.Equals("GroupID", StringComparison.OrdinalIgnoreCase))
                {
                    gc.Visible = false;
                }
            }
            CloseWaitScreen();
        }

        private int GetSelectedGroupID()
        {
            if (gdvSearchResult.GetFocusedRow() is sp_ADM020_LoadGroup_Result)
            {
                sp_ADM020_LoadGroup_Result selected = (sp_ADM020_LoadGroup_Result)gdvSearchResult.GetFocusedRow();
                return (int)selected.GroupID;
            }
            else
                return -1;
        }

        private string GetSelectedGroupName()
        {
            if (gdvSearchResult.GetFocusedRow() is sp_ADM020_LoadGroup_Result)
            {
                sp_ADM020_LoadGroup_Result selected = (sp_ADM020_LoadGroup_Result)gdvSearchResult.GetFocusedRow();
                return selected.GroupName;
            }
            else
                return string.Empty;
        }

        private int GetGroupIDByRowHandle(int rowHandle)
        {
            if (gdvSearchResult.GetRow(rowHandle) is sp_ADM020_LoadGroup_Result)
            {
                sp_ADM020_LoadGroup_Result selected = (sp_ADM020_LoadGroup_Result)gdvSearchResult.GetRow(rowHandle);
                return (int)selected.GroupID;
            }
            else
                return -1;
        }
        #endregion
    }
}