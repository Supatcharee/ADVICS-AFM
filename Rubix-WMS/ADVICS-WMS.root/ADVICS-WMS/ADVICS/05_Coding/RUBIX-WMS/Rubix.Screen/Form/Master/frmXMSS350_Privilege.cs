using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS350_Privilege : FormBase
    {
        #region Member
        private Privilege db = null;
        private DataTable dtResult = null;
        private int iCount = 0;
        private bool isValidData = true;
        #endregion

        #region Properties
        public Privilege BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Privilege();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Privilege();
                }
                db = value;
            }
        }
        #endregion

        #region Constructor
        public frmXMSS350_Privilege()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
        } 
        #endregion

        #region Overried Method
        public override bool OnCommandEdit()
        {
            try
            {
                DataLoading();
                ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(true, m_toolBarEdit, m_toolBarDelete);
                ControlUtil.HiddenControl(true, q_toolBarEdit, q_toolBarDelete);
                SetEditTableColor(true);
                if (base.CanAdd)
                {
                    gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                }
                gdvSearchResult.OptionsBehavior.Editable = true;
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
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();
                if (gdvSearchResult.RowCount <= 0)
                {
                    return false;
                }

                if (isValidData)
                {

                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                    {
                        base.ShowWaitScreen();
                        DataTable dtAdd = null;
                        DataTable dttUpdate = null;

                        DataRow[] drAdd = dtResult.Select("", "", DataViewRowState.Added);
                        DataRow[] drUpdate = dtResult.Select("", "", DataViewRowState.ModifiedCurrent);

                        if (drAdd.Length > 0)
                        {
                            dtAdd = drAdd.CopyToDataTable();
                        }
                        if (drUpdate.Length > 0)
                        {
                            dttUpdate = drUpdate.CopyToDataTable();
                        }

                        if (dttUpdate != null)
                        {
                            if (dtAdd == null)
                            {
                                dtAdd = dttUpdate;
                            }
                            else
                            {
                                dtAdd.Merge(dttUpdate);
                            }
                        }

                        if (dtAdd != null)
                        {
                            DataSet ds = new DataSet("PrivilegeDataSet");
                            dtAdd.TableName = "PrivilegeDataTable";
                            ds.Tables.Add(dtAdd);

                            BusinessClass.SaveData(ds.GetXml(), AppConfig.UserLogin);

                            MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                            ds.Tables.Clear();
                            DataLoading();

                        }

                        base.CloseWaitScreen();
                        ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                        ControlUtil.HiddenControl(false, m_toolBarEdit, m_toolBarDelete);
                        ControlUtil.HiddenControl(false, q_toolBarEdit, q_toolBarDelete);
                        SetEditTableColor(false);
                        gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandCancel()
        {
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
            ControlUtil.HiddenControl(false, m_toolBarEdit, m_toolBarDelete);
            ControlUtil.HiddenControl(false, q_toolBarEdit, q_toolBarDelete);
            SetEditTableColor(false);
            gdvSearchResult.CloseEditor();
            gdvSearchResult.CancelUpdateCurrentRow();
            gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            DataLoading();
            gdvSearchResult.OptionsBehavior.Editable = false;
            return true;
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    return false;
                }
                else
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();
                    if (dr == null)
                    {
                        return false;
                    }
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0016")) == DialogButton.Yes)
                    {
                        base.ShowWaitScreen();

                        if (BusinessClass.CheckReference(Convert.ToInt32(dr["PVID"])) == 0) // Check Reference before Delete 
                        {
                            BusinessClass.DeleteData(Convert.ToInt32(dr["PVID"]));
                            String dataDeleted  = dr["PVCode"].ToString();
                            gdvSearchResult.DeleteSelectedRows();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), dataDeleted));
                        }
                        else
                        {
                            CloseWaitScreen();
                            MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Privilege"));
                            return false;
                        }
                        CloseWaitScreen();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion
        
        #region Event Handler
        private void frmXMSS350_Privilege_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
                ControlUtil.HiddenControl(true, q_toolBarView, q_toolBarAdd);
                ControlUtil.HiddenControl(false, m_toolBarImport);

                gdvSearchResult.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                base.GridViewOnChangeLanguage(grdSearchResult);
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }              
            }
            catch (Exception ex)
            {
                this.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.ClearControlData(txtPrivilegeCode, txtPrivilegeName);
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void gdvSearchResult_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                bool isValid = true;
                ColumnView view = sender as ColumnView;
                view.ClearColumnErrors();

                e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");

                if (view.GetRowCellValue(e.RowHandle, gdcPrivilegeCode).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcPrivilegeCode, Rubix.Screen.Common.GetMessage("I0363"));
                }
                if (view.GetRowCellValue(e.RowHandle, gdcPrivilegeName).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcPrivilegeName, Rubix.Screen.Common.GetMessage("I0364"));
                }

                if (isValid)
                {
                    DataRow[] dr;
                    int? iPrivilegeID = DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcPrivilegeID));
                    String strPrivilegeCode = view.GetRowCellValue(e.RowHandle, gdcPrivilegeCode).ToString();
                    int iRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcROWID));


                    if (iPrivilegeID == null)
                    {
                        dr = dtResult.Select(string.Format("PVCode = '{0}' AND ROWID <> {1} ", strPrivilegeCode, iRowID));

                    }
                    else
                    {
                        dr = dtResult.Select(string.Format("PVCode = '{0}' AND PVID <> {1}", strPrivilegeCode, iPrivilegeID));
                    }

                    if (dr.Length > 0)
                    {
                        isValid = false;
                        view.SetColumnError(gdcPrivilegeCode, Rubix.Screen.Common.GetMessage("I0205"));
                    }
                    else
                    {
                        if (BusinessClass.CheckExist(iPrivilegeID, strPrivilegeCode))
                        {
                            isValid = false;
                            view.SetColumnError(gdcPrivilegeCode, Rubix.Screen.Common.GetMessage("I0205"));
                        }
                    }
                }
                this.isValidData = isValid;
                e.Valid = isValid;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                iCount++;
                view.SetRowCellValue(e.RowHandle, gdcROWID, iCount);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        #endregion

        #region Generic Function
        private void DataLoading()
        {
            this.ShowWaitScreen();
            dtResult = BusinessClass.DataLoading(txtPrivilegeCode.Text.Trim(), txtPrivilegeName.Text.Trim());
            if (dtResult.Rows.Count <= 0)
            {
                dtResult.Columns.Add("ROWID", typeof(int));
                dtResult.Columns.Add("PVID", typeof(int));
                dtResult.Columns.Add("PVCode", typeof(string));
                dtResult.Columns.Add("PVName", typeof(string));
                dtResult.Columns.Add("Remark", typeof(string));
                dtResult.Columns.Add("CreateDate", typeof(DateTime));
                dtResult.Columns.Add("CreateUser", typeof(string));
                dtResult.Columns.Add("UpdateDate", typeof(DateTime));
                dtResult.Columns.Add("UpdateUser", typeof(string));
            }
            dtResult.AcceptChanges();
            grdSearchResult.DataSource = dtResult;
            iCount = dtResult.Rows.Count;
           // base.GridViewOnChangeLanguage(grdSearchResult);
            this.CloseWaitScreen();
        }

        private void SetEditTableColor(bool IsEdit)
        {
            if (IsEdit)
            {
                //สีเหลืองเสมอ
                gdcPrivilegeCode.AppearanceCell.BackColor = Color.Yellow;
                gdcPrivilegeName.AppearanceCell.BackColor = Color.Yellow;
                gcRemark.AppearanceCell.BackColor = Color.Yellow;
            }
            else
            {
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    gdvSearchResult.Columns[i].AppearanceCell.BackColor = Color.White;
                }
            }

            gdcPrivilegeCode.OptionsColumn.AllowEdit = IsEdit;
            gdcPrivilegeName.OptionsColumn.AllowEdit = IsEdit;
            gcRemark.OptionsColumn.AllowEdit = IsEdit;
        } 
        #endregion
    }
}