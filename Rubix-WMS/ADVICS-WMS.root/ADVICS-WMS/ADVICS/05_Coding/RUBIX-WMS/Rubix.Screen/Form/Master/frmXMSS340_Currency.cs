using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Master;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS340_Currency : FormBase
    {
        #region Member
        private Currency db = null;
        private DataTable dtResult = null;
        private int iCount = 0;
        private bool isValidData = true;
        #endregion
        
        #region Contrustor
        public frmXMSS340_Currency()
        {
            InitializeComponent();

            base.GridExportExcel = gdvSearchResult;
            //base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarCancel, m_toolBarSave, m_toolBarRefresh);
        } 
        #endregion

        #region Properties
        public Currency BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Currency();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Currency();
                }
                db = value;
            }
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
                            DataSet ds = new DataSet("CurrencyDataSet");
                            dtAdd.TableName = "CurrencyDataTable";
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
            gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            DataLoading();
            return true;
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    DataRow dtr = gdvSearchResult.GetFocusedDataRow();
                    if (dtr == null)
                    {
                        return false; 
                    }
                    
                    BusinessClass.CurrencyID = Convert.ToInt32(dtr["CurrencyID"]);
                    
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.CurrencyName)) == DialogButton.Yes)
                    {
                        if (BusinessClass.CheckReference(BusinessClass.CurrencyID) == 0) // Check Reference before Delete 
                        {
                            ShowWaitScreen();
                            BusinessClass.CurrencyID = Convert.ToInt32(dtr["CurrencyID"]);
                            BusinessClass.DeleteData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.CurrencyName));
                            return true;
                        }
                        else
                        {
                            CloseWaitScreen();
                            MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Currency"));
                            return false;
                        }
                        CloseWaitScreen();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler
        private void frmXMSS340_Currency_Load(object sender, EventArgs e)
        {
            try
            {
                //ทำตอน constructor ไม่ได้เพราะปุ่ม add จะไม่หายไป มี permission add แต่ไม่ show ปุ่ม add
                ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
                ControlUtil.HiddenControl(true, q_toolBarView, q_toolBarAdd);
                ControlUtil.HiddenControl(false, m_toolBarImport);
                SetEditTableColor(false);
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
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
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.ClearControlData(txtCurrencyCode, txtCurrencyName);
                grdSearchResult.DataSource = null;
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

        private void gdvSearchResult_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                bool isValid = true;
                ColumnView view = sender as ColumnView;
                view.ClearColumnErrors();

                e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");

                if (view.GetRowCellValue(e.RowHandle, gdcCurrencyCode).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyCode, Rubix.Screen.Common.GetMessage("I0356"));
                }

                if (view.GetRowCellValue(e.RowHandle, gdcCurrencyName).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyName, Rubix.Screen.Common.GetMessage("I0356"));
                }
                
                if (isValid)
                {
                    DataRow[] dr;
                    int? iCurrencyID = DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcCurrencyID));
                    string strCurrencyCode = view.GetRowCellValue(e.RowHandle, gdcCurrencyCode).ToString().Trim();
                    int iRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcROWID));

                    if (iCurrencyID == null)
                    {
                        dr = dtResult.Select(string.Format("CurrencyCode = '{0}' AND ROWID <> {1} ", strCurrencyCode, iRowID));
                    }
                    else
                    {
                        dr = dtResult.Select(string.Format("CurrencyCode = '{0}' AND CurrencyID <> {1} ", strCurrencyCode, iCurrencyID));
                    }

                    if (dr.Length > 0)
                    {
                        isValid = false;
                        view.SetColumnError(gdcCurrencyCode, Rubix.Screen.Common.GetMessage("I0070"));
                    }
                    else
                    {
                        if (BusinessClass.CheckExistCurrencyCode(iCurrencyID, strCurrencyCode))
                        {
                            isValid = false;
                            view.SetColumnError(gdcCurrencyCode, Rubix.Screen.Common.GetMessage("I0070"));
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
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                dtResult = BusinessClass.DataLoading(txtCurrencyCode.Text.Trim(), txtCurrencyName.Text.Trim());
                if (dtResult.Rows.Count <= 0)
                {
                    dtResult.Columns.Add("ROWID", typeof(int));
                    dtResult.Columns.Add("CurrencyID", typeof(int));
                    dtResult.Columns.Add("CurrencyCode", typeof(string));
                    dtResult.Columns.Add("CurrencyName", typeof(string));
                    dtResult.Columns.Add("Remark", typeof(string));
                    dtResult.Columns.Add("CreateDate", typeof(DateTime));
                    dtResult.Columns.Add("CreateUser", typeof(string));
                    dtResult.Columns.Add("UpdateDate", typeof(DateTime));
                    dtResult.Columns.Add("UpdateUser", typeof(string));
                }
                dtResult.AcceptChanges();
                grdSearchResult.DataSource = dtResult;
                iCount = dtResult.Rows.Count;
                //base.GridViewOnChangeLanguage(grdSearchResult);
                this.CloseWaitScreen();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                throw ex;
            }
        }
                
        private void SetEditTableColor(bool IsEdit)
        {
            if (IsEdit)
            {
                //สีเหลืองเสมอ
                gdcCurrencyCode.AppearanceCell.BackColor = Color.Yellow;
                gdcCurrencyName.AppearanceCell.BackColor = Color.Yellow;
                gdcRemark.AppearanceCell.BackColor = Color.Yellow;
            }
            else
            {
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    gdvSearchResult.Columns[i].AppearanceCell.BackColor = Color.White;
                }
            }

            gdcCurrencyCode.OptionsColumn.AllowEdit = IsEdit;
            gdcCurrencyName.OptionsColumn.AllowEdit = IsEdit;
            gdcRemark.OptionsColumn.AllowEdit = IsEdit;
        }
        #endregion
    }
}
