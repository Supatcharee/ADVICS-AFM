﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using DevExpress.XtraGrid.Columns;

namespace Rubix.Screen.Form.Operation.N_PackingMaterial.Dialog
{
    public partial class dlgNPM011_PackingMaterialAdjustment : DialogBase
    {
        #region Member
        private DataTable _SONO;
        private SalePurchaseOrder db;
        private int? _OwnerID;
        private DataSet dsEditData;
        private DataSet _dsSummaryResult;
        private bool closeAfterSave = false;
        private object ValueBeforeChange;
        private Dictionary<string, int> SeqIndex = new Dictionary<string, int>();
        private Dictionary<string, int> countAdd = new Dictionary<string, int>();
        #endregion

        #region Properties
        public DataTable SONO
        {
            get { return _SONO; }
            set { _SONO = value; }
        }

        public int? OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }

        public DataSet dsSummaryResult
        {
            get { return _dsSummaryResult; }
            set { _dsSummaryResult = value; }
        }

        private SalePurchaseOrder BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                return db;
            }
        }
        
        #endregion

        #region Override
        public override bool OnCommandSave()
        {
            try
            {
                
                GridView Mastergrv = (GridView)grdEditPO.Views[0];
                if (Mastergrv != null)
                {
                    Mastergrv.CloseEditor();
                    Mastergrv.UpdateCurrentRow();
                    if (validateSave())
                    {
                        if (MessageDialog.ShowConfirmationMsg(this, "Do you want to confirm this plan?") == DialogButton.Yes)
                        {
                            ShowWaitScreen();
                            SaveData();
                            MessageDialog.ShowInformationMsg("Save Complete");
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        #endregion

        #region Constructor
        public dlgNPM011_PackingMaterialAdjustment()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarImport, m_toolBarSaveACopy, m_toolBarPrint);
            m_statusBar.Visible = false;
        }
        #endregion

        #region Event Handler

        private void dlgNPM011_PackingMaterialAdjustment_Load(object sender, EventArgs e)
        {
            try
            {
                m_toolBarSave.Caption = "Confirm";
                dataLoading();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void gdvEditPO_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;
                DataRow FirstRow = gdvEditPO.GetDataRow(e.RowHandle1);
                DataRow SecondRow = gdvEditPO.GetDataRow(e.RowHandle2);
                if (e.Column == gdcPONo)
                {
                    if (FirstRow["PONo"].Equals(SecondRow["PONo"]))
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                else if (e.Column == gdcPartName || e.Column == gdcProductCode)
                {
                    if (FirstRow["ProductID"].Equals(SecondRow["ProductID"]))
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                else if (e.Column == gdcSupplierCode)
                {
                    if (FirstRow["SupplierCode"].Equals(SecondRow["SupplierCode"]))
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                else if (e.Column == gdcRemaining || e.Column == gdcSumQty || e.Column == gdcMinOrder)
                {
                    if (FirstRow["ProductID"].Equals(SecondRow["ProductID"]) && FirstRow["PONo"].Equals(SecondRow["PONo"]) && FirstRow["SUMQty"].Equals(SecondRow["SUMQty"])
                        && FirstRow["RemainQty"].Equals(SecondRow["RemainQty"]) && FirstRow["ProductCode"].Equals(SecondRow["ProductCode"]))
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                else 
                {
                    e.Merge = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void repQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            try
            {
                DataRow focusRow = gdvEditPO.GetFocusedDataRow();
                DataTable dt = (DataTable)grdEditPO.DataSource;
                DataRow[] focusRowGroup = dt.Select(string.Format("PONo = '{0}' and ProductID = {1}", focusRow["PONo"], focusRow["ProductID"]));
                double? OldSum = DataUtil.Convert<double>(focusRow["SUMQty"]);
                double? NewSum = 0;
                double NV = (e.NewValue == null || e.NewValue == string.Empty) ? 0 : Convert.ToDouble(e.NewValue);
                double OV = (gdvEditPO.GetFocusedValue() == DBNull.Value) ? 0 : Convert.ToDouble(gdvEditPO.GetFocusedValue());

                foreach (DataRow drFocus in focusRowGroup)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn dc in gdvEditPO.Columns)
                    {
                        if (dc.FieldName != "SONo" && dc.FieldName != "SupplierCode" && dc.FieldName != "rowStatus" && dc.FieldName != "MinOrder" && dc.FieldName != "RemainQty" && dc.FieldName != "PONo" && dc.FieldName != "ProductID" && dc.FieldName != "ProductCode" && dc.FieldName != "ProductLongName" && dc.FieldName != "SUMQty" && !string.IsNullOrEmpty(drFocus[dc.FieldName].ToString()))
                        {
                            NewSum += DataUtil.Convert<double>(drFocus[dc.FieldName]);
                        }
                    }
                }
                NewSum += NV - OV;
                if (NewSum > OldSum)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, String.Format("Value can't over than {0} your Summary is {1}", OldSum, NewSum));
                    e.Cancel = true;
                }
                else
                {
                    foreach (DataRow drFocus in focusRowGroup)
                    {
                        drFocus["RemainQty"] = OldSum - NewSum;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GridColumn dc = gdvEditPO.FocusedColumn;
                DataTable dt = (DataTable)grdEditPO.DataSource;

                if (dc.FieldName != "SONo" && dc.FieldName != "SupplierCode" && dc.FieldName != "rowStatus" && dc.FieldName != "MinOrder" && dc.FieldName != "RemainQty" && dc.FieldName != "PONo" && dc.FieldName != "ProductID" && dc.FieldName != "ProductCode" && dc.FieldName != "ProductLongName" && dc.FieldName != "SUMQty")
                {
                    string[] fName = dc.FieldName.Split(':');
                    DateTime? curdate = DataUtil.Convert<DateTime>(fName[0]);
                    if (!countAdd.ContainsKey(curdate.ToString()))
                    {
                        countAdd.Add(curdate.ToString(), 1);
                    }
                    string ColumnDay = curdate.Value.ToShortDateString() + " : " + countAdd[curdate.ToString()].ToString() + "";


                    dt.Columns.Add(ColumnDay, typeof(double));
                    gdvEditPO.Columns.AddField(ColumnDay);
                    gdvEditPO.Columns[ColumnDay].ColumnEdit = repQty;
                    gdvEditPO.Columns[ColumnDay].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    gdvEditPO.Columns[ColumnDay].Visible = true;
                    gdvEditPO.Columns[ColumnDay].VisibleIndex = gdvEditPO.Columns[curdate.Value.ToShortDateString()].VisibleIndex + countAdd[curdate.ToString()];
                    SeqIndex.Add(ColumnDay, countAdd[curdate.ToString()]);
                    countAdd[curdate.ToString()]++;
                }

                //DataRow drFocus = gdvEditPO.GetFocusedDataRow();
                //DataTable dt = (DataTable)grdEditPO.DataSource;
                //DataRow drNew = dt.NewRow();
                //int[] index = gdvEditPO.GetSelectedRows();

                //drNew["PONo"] = drFocus["PONo"];
                //drNew["ProductID"] = drFocus["ProductID"];
                //drNew["ProductCode"] = drFocus["ProductCode"];
                //drNew["ProductLongName"] = drFocus["ProductLongName"];
                //drNew["MinOrder"] = drFocus["MinOrder"];
                //drNew["RemainQty"] = drFocus["RemainQty"];
                //drNew["SUMQty"] = drFocus["SUMQty"];
                //drNew["rowStatus"] = "New";
                //dt.Rows.InsertAt(drNew, index[0] + 1);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dlgNPM011_PackingMaterialAdjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!closeAfterSave)
                {
                    DataSet RollbackDS = new DataSet("PackingMaterialDataSet");
                    DataTable RollbackDT = SONO.Copy();
                    RollbackDT.TableName = "PackingMaterialDataTable";
                    RollbackDS.Tables.Add(RollbackDT);

                    BusinessClass.PurchaseOrder_PackingMaterial_Cancel(RollbackDS.GetXml());
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion

        #region Generic Function
        private void SaveData()
        {
            try
            {
                DataTable dtRaw = dsEditData.Tables[1].Copy();
                if (!dtRaw.Columns.Contains("RowStatus"))
                {
                    dtRaw.Columns.Add("RowStatus");
                }
                if (!dtRaw.Columns.Contains("Seq"))
                {
                    dtRaw.Columns.Add("Seq");
                }
                dtRaw.Columns.Remove("SupplierCode");
                foreach (DataRow item in dtRaw.Rows)
                {
                    item["RowStatus"] = 0;
                    item["Seq"] = 0;
                }
                DataTable dtChange = (DataTable)grdEditPO.DataSource;
                foreach (DataRow dr in dtChange.Rows)
                {
                    foreach (DataColumn dc in dtChange.Columns)
                    {
                        if (dc.ColumnName != "SONo" && dc.ColumnName != "SupplierCode" && dc.ColumnName != "rowStatus" && dc.ColumnName != "RemainQty" && dc.ColumnName != "MinOrder" && dc.ColumnName != "PONo" && dc.ColumnName != "ProductID" && dc.ColumnName != "ProductCode" && dc.ColumnName != "ProductLongName" && dc.ColumnName != "SUMQty" && !string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))  
                        {
                            string[] fName = dc.ColumnName.Split(':');
                            int seq = (SeqIndex.ContainsKey(dc.ColumnName)) ? SeqIndex[dc.ColumnName] : 0;
                            DataRow[] drRaw = dtRaw.Select(String.Format("PONo = '{2}' and ProductID = {0} and ArrivalDate = '{1}' and seq = {3}", dr["ProductID"], dc.ColumnName, dr["PONo"], seq));
                            DataRow[] PDSRow = dtRaw.Select(String.Format("PONo = '{1}' and ArrivalDate = '{0}' and seq = {2}", dc.ColumnName, dr["PONo"], seq));

                            int Rstatus = (SeqIndex.ContainsKey(dc.ColumnName)) ? 1 : 0;

                            string PDSNo = "";
                            if (PDSRow.Length > 0 && !SeqIndex.ContainsKey(dc.ColumnName))
                            {
                                PDSNo = (string.IsNullOrEmpty(PDSRow[0]["PDSNo"].ToString())) ? "" : PDSRow[0]["PDSNo"].ToString();
                            }
                            if (drRaw.Length > 0 && !SeqIndex.ContainsKey(dc.ColumnName))
                            {
                                foreach (DataRow item in drRaw)
                                {
                                    item["OrderQty"] = dr[dc.ColumnName];
                                }
                            }
                            else
                            {
                                dtRaw.Rows.Add(dr["PONo"], PDSNo, dr["ProductID"], dr["ProductCode"], dr["ProductLongName"], dc.ColumnName, dr[dc.ColumnName], Rstatus, seq);
                            }
                        }
                    }
                }
                DataSet dsSave = new DataSet("NewDataset");
                dtRaw.Columns["ArrivalDate"].DateTimeMode = DataSetDateTime.Unspecified;
                DataTable dtSave = dtRaw.Copy();
                dtSave.TableName = "Table1";
                dtSave.Columns.Remove("ProductLongName");
                dsSave.Tables.Add(dtSave);
                BusinessClass.PurchaseOrderPackingMaterialPreConfirmSave(dsSave.GetXml());
                closeAfterSave = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void dataLoading()
        {
            try
            {
                ShowWaitScreen();
                DataSet ds = dsSummaryResult;
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    dt.Columns.Add("rowStatus",typeof(string));
                    dt.Columns.Add("RemainQty",typeof(double));
                    DateTime? Firstday = DataUtil.Convert<DateTime>(ds.Tables[2].Rows[0]["MinDate"].ToString());
                    if (Firstday.HasValue)
                    {
                        int dayleft = DateTime.DaysInMonth(Firstday.Value.Year, Firstday.Value.Month) - Firstday.Value.Day;
                        CSI.Business.Master.CalendarCompany CalendarBusiness = new CSI.Business.Master.CalendarCompany();
                        DataSet calendar = CalendarBusiness.LoadCompanyCalendar(OwnerID, Firstday.Value);
                        grdEditPO.DataSource = dt;
                        for (int i = 0; i <= dayleft; i++)
                        {
                            DateTime dayNum = Firstday.Value.AddDays(i);
                            string calendarexp = string.Format("CalendarDate = '{0}' and IsNonWorkingDay = 1", dayNum.ToShortDateString());
                            string ColumnDay = dayNum.ToShortDateString();
                            dt.Columns.Add(ColumnDay, typeof(double));
                            gdvEditPO.Columns.AddField(ColumnDay);
                            gdvEditPO.Columns[ColumnDay].ColumnEdit = repQty;
                            gdvEditPO.Columns[ColumnDay].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                            gdvEditPO.Columns[ColumnDay].Visible = true;
                            gdvEditPO.Columns[ColumnDay].VisibleIndex = gdvEditPO.Columns.Count - 1;
                            if (dayNum <= DateTime.Now)
                            {
                                gdvEditPO.Columns[ColumnDay].ColumnEdit = repQtyLock;
                                gdvEditPO.Columns[ColumnDay].OptionsColumn.AllowEdit = false;
                                gdvEditPO.Columns[ColumnDay].AppearanceCell.BackColor = Color.LightGray;
                                gdvEditPO.Columns[ColumnDay].AppearanceCell.BackColor2 = Color.LightGray;
                            }
                            else if (calendar.Tables[3].Select(calendarexp).Length > 0)
                            {
                                gdvEditPO.Columns[ColumnDay].ColumnEdit = repQtyLock;
                                gdvEditPO.Columns[ColumnDay].OptionsColumn.AllowEdit = false;
                                gdvEditPO.Columns[ColumnDay].AppearanceCell.BackColor = Color.LightBlue;
                                gdvEditPO.Columns[ColumnDay].AppearanceCell.BackColor2 = Color.LightBlue;
                            }
                        }

                        DataTable dtdt = ds.Tables[1];

                        foreach (DataRow Mrow in dt.Rows)
                        {
                            Mrow["rowStatus"] = "Old";
                            int? OrderQty = 0;
                            DataRow[] dttemp = dtdt.Select(String.Format("PONo = '{1}' AND ProductID = {0}", Mrow["ProductID"], Mrow["PONo"]));
                            foreach (DataRow Drow in dttemp)
                            {
                                DateTime? arrdate = DataUtil.Convert<DateTime>(Drow["ArrivalDate"].ToString());
                                if (arrdate.HasValue)
                                {
                                    Mrow[arrdate.Value.ToShortDateString()] = Drow["OrderQty"];
                                    OrderQty += DataUtil.Convert<int>(Drow["OrderQty"]);
                                }
                            }
                            Mrow["RemainQty"] = DataUtil.Convert<int>(Mrow["SUMQty"]) - OrderQty;
                        }
                    }
                    
                }
                dsEditData = ds;
                gdvEditPO.BestFitColumns();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private bool validateSave()
        {
            try
            {
                DataTable dt = (DataTable)grdEditPO.DataSource;
                DataRow[] MainRow = dt.Select("rowStatus = 'Old'");
                foreach (DataRow focusRow in MainRow)
                {
                    DataRow[] focusRowGroup = dt.Select(string.Format("PONo = '{0}' and ProductID = {1}", focusRow["PONo"], focusRow["ProductID"]));
                    double? OldSum = DataUtil.Convert<double>(focusRow["SUMQty"]);
                    double? NewSum = 0;

                    foreach (DataRow drFocus in focusRowGroup)
                    {
                        foreach (DevExpress.XtraGrid.Columns.GridColumn dc in gdvEditPO.Columns)
                        {
                            if (dc.FieldName != "SONo" && dc.FieldName != "SupplierCode" && dc.FieldName != "rowStatus" && dc.FieldName != "MinOrder" && dc.FieldName != "RemainQty" && dc.FieldName != "PONo" && dc.FieldName != "ProductID" && dc.FieldName != "ProductCode" && dc.FieldName != "ProductLongName" && dc.FieldName != "SUMQty" && !string.IsNullOrEmpty(drFocus[dc.FieldName].ToString()))
                            {
                                NewSum += DataUtil.Convert<double>(drFocus[dc.FieldName]);
                            }
                        }
                    }
                    if (NewSum != OldSum)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "Sum Qty not equal total plan Qty at PO No. " + focusRow["PONo"]);
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion

        private void gdvEditPO_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                DataRow dr = gdvEditPO.GetDataRow(e.RowHandle);
                double? Value = DataUtil.Convert<double>(e.Value);
                double? MinOrder = DataUtil.Convert<double>(dr["MinOrder"]);
                if (Value % MinOrder != 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Item(s) are not order by MOQ. Please re-check.");
                    dr[e.Column.FieldName] = ValueBeforeChange.ToString();
                    repQty_EditValueChanging(sender, new DevExpress.XtraEditors.Controls.ChangingEventArgs(Value, ValueBeforeChange));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void repQty_Enter(object sender, EventArgs e)
        {
            ValueBeforeChange = (gdvEditPO.GetFocusedValue() == DBNull.Value) ? 0 : gdvEditPO.GetFocusedValue();
        }


    }
}