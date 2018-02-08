using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;
using CSI.Business.Report;
using Rubix.Screen.Report;

namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    public partial class dlgKPK021_ConfirmPacking_ScanDetail : SubDialogBase
    {
        #region Member
        private DataTable _dataTable = null;
        private PackingInstruction db = null;
        private Product _dbProduct = null;
        private LabelStickerReport m_objRptLabelSticker = null;
        private string _userLogin;
        private string _machineIP;

        public static string _LMethod_ { get; set; }
        public static string _LStart_ { get; set; }
        public static string _LStartCurrentDateDate_ { get; set; }
        public static string _LParameter_ { get; set; }
        public static string _LEnd_ { get; set; }
        public static string _LEndCurrentDate_ { get; set; }

        #endregion

        #region Properties
        public string UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; }
        }

        public string MachineIP
        {
            get { return _machineIP; }
            set { _machineIP = value; }
        }

        public DataTable dtDataResult
        {
            get
            {
                if (_dataTable == null)
                {
                    _dataTable = new DataTable();
                }
                return _dataTable;
            }
            set
            {
                _dataTable = value;
            }
        }        
        PackingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PackingInstruction();
                }
                return db;
            }
        }
        public Product ProductBusinessClass
        {
            get
            {
                if (_dbProduct == null)
                    _dbProduct = new Product();
                return _dbProduct;
            }
            set
            {
                _dbProduct = value;
            }
        }
        public string ShipmentNo { get; set; }
        public string PackingNo { get; set; }
        private LabelStickerReport ReportBusiness_LabelSticker
        {
            get
            {
                if (m_objRptLabelSticker == null)
                {
                    m_objRptLabelSticker = new LabelStickerReport();
                }
                return m_objRptLabelSticker;
            }
        }
        #endregion

        #region Constructor
        public dlgKPK021_ConfirmPacking_ScanDetail()
        {
            InitializeComponent();

            dtDataResult.Columns.Add("PDSNo", typeof(String));
            dtDataResult.Columns.Add("RunningNo", typeof(String));
            dtDataResult.Columns.Add("RunningForOutTag", typeof(String));
            dtDataResult.Columns.Add("PackingNo", typeof(String));
            dtDataResult.Columns.Add("LineNo", typeof(int));
            dtDataResult.Columns.Add("ShipmentNo", typeof(String));
            dtDataResult.Columns.Add("PickingNo", typeof(String));
            dtDataResult.Columns.Add("PackQty", typeof(decimal));
            dtDataResult.Columns.Add("UnitOfPackQty", typeof(int));
            dtDataResult.Columns.Add("UnitCode", typeof(String));
            dtDataResult.Columns.Add("Installment", typeof(int));
            dtDataResult.Columns.Add("ProductID", typeof(int));
            dtDataResult.Columns.Add("PartName", typeof(String));
            dtDataResult.Columns.Add("PartCode", typeof(String));
            dtDataResult.Columns.Add("PlanPackQty", typeof(decimal));
            dtDataResult.Columns.Add("RMTagQty", typeof(decimal));
            dtDataResult.Columns.Add("SumRMQty", typeof(decimal));
            dtDataResult.Columns.Add("PackedQty", typeof(decimal));

            ControlUtil.HiddenControl(true, m_toolBarCancel);
        }
        #endregion

        #region Overried Method
        public override bool OnCommandOK()
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
            
        }
        #endregion

        #region Event Handler
        private void dlgKPK021_ConfirmPacking_ScanDetail_Load(object sender, EventArgs e)
        {
            try
            {
                lblShipmentNo.Text = ShipmentNo;
                lblPackingNo.Text = PackingNo;
                //grdResult.DataSource = dtDataResult;
                //base.GridViewOnChangeLanguage(grdResult);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void txtQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ControlUtil.LStart = "START";
            //ControlUtil.LEnd = "END";
            try
            {
                //-------------------------------------------------------------------------
                _LMethod_ = "dlgKPK021_ConfirmPacking_ScanDetail/txtQRCode_KeyPress(object sender, KeyPressEventArgs e)";
                _LStart_ = "START ROUND 1";
                _LStartCurrentDateDate_ = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                /*************************** Write Log ******************************/
                ControlUtil.LogFileStart(_LMethod_, _LStart_, _LStartCurrentDateDate_, _LParameter_);
                /***************************End Write Log ******************************/
                //----------------------------------------------------------------------------

                lblErrorMsg.ForeColor = Color.Red;
                lblErrorMsg.Text = "";
                if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtQRCode.Text))
                {
                    ShowWaitScreen();
                    String QRCode = txtQRCode.Text;

                    //-------------------------------
                    _LParameter_ = "QRCode = " + QRCode;
                    _LStart_ = "START ROUND 2";
                    //-------------------------------
                    /*************************** Write Log ******************************/
                    ControlUtil.LogFileStart(_LMethod_, _LStart_, _LStartCurrentDateDate_, _LParameter_);
                    /***************************End Write Log ******************************/
                    
                    if (!ValidateQRCode(QRCode))
                    {
                        lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0403");
                        txtQRCode.Text = string.Empty;
                        return;
                    }

                    if (QRCode.Split('-').Length == 2)
                    {
                        //PCI-SF02  OK
                        //PCI-F08   Comfirm
                        //PCI-F12   Exist
                        if (QRCode.Equals("PCI-SF02"))
                        {
                            OnCommandOK();
                        }
                        else if (QRCode.Equals("PCI-F12"))
                        {
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        }
                        return;
                    }

                    //0 = PO No.
                    //1 = PDS No.
                    //2 = Running No. --> 00001
                    //3 = Supplier Code
                    //4 = Item No.
                    //5 = Item Short Code
                    //6 = Qty level 3
                    //7 = Collect Date

                    String[] QRData = QRCode.Split(':');
                    String[] RunningNo = QRData[2].Split('-');

                    DataTable dtResult = BusinessClass.ConfirmPackingSearchRMTagDetail(QRData[1], RunningNo[0], QRData[4], this.ShipmentNo, this.PackingNo);
                    if (dtResult.Rows.Count <= 0)
                    {
                        //-------------------------------------------------------------------------
                        ControlUtil.LStart = "START CHECK RETURN DATATABLE RESULT";
                        ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                        //----------------------------------------------------------------------------

                        lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0014");
                        txtQRCode.Text = string.Empty;
                        pictureBox.Image = null;
                        //-------------------------------------------------------------------------
                        ControlUtil.LParameter = "GetMessage(I0014) is [Data not found] because dataTable return 0 record";
                        /*************************** Write Log ******************************/
                        ControlUtil.LogFileStart(_LMethod_, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                        /***************************End Write Log ******************************/
                        ControlUtil.LEnd = "END CHECK RETURN DATATABLE RESULT";
                        ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                        ControlUtil.LogFileEnd(_LMethod_, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                        ClearLog();
                        //-------------------------------------------------------------------------
                        return;
                    }
                    else if (Convert.ToInt32(dtResult.Rows[0]["PlanQty"]) == Convert.ToInt32(dtResult.Rows[0]["PackedQty"]))
                    {
                        //-------------------------------------------------------------------------
                        ControlUtil.LStart = "START CHECK RETURN DATATABLE RESULT";
                        ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                        //----------------------------------------------------------------------------
                        lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0109");
                        txtQRCode.Text = string.Empty;
                        pictureBox.Image = null;
                        //-------------------------------------------------------------------------
                        ControlUtil.LParameter = "GetMessage(I0109) is 'Total [Actual Qty] cannot more than [Plan Qty], please try again.' because dataTable return [PlanQty] = [PackedQty]";
                        /*************************** Write Log ******************************/
                        ControlUtil.LogFileStart(_LMethod_, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                        /***************************End Write Log ******************************/
                        ControlUtil.LEnd = "END CHECK RETURN DATATABLE RESULT";
                        ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                        ControlUtil.LogFileEnd(_LMethod_, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                        //-------------------------------------------------------------------------
                        return;
                    }

                    byte[] imageByte = ProductBusinessClass.LoadImage(Convert.ToInt32(dtResult.Rows[0]["ProductID"]));
                    pictureBox.Image = ControlUtil.ConvertByteToImage(imageByte);

                    int runningStart;
                    int runningEnd;

                    if (RunningNo.Length == 2)
                    {
                        runningStart = Convert.ToInt32(RunningNo[0]);
                        runningEnd = Convert.ToInt32(RunningNo[1]);
                    }
                    else
                    {
                        runningStart = Convert.ToInt32(dtResult.Rows[0]["CurrentRunning"]) + 1;
                        runningEnd = Convert.ToInt32(dtResult.Rows[0]["CurrentRunning"]) + 1;
                    }

                    if (runningStart != runningEnd)
                    {
                        for (int i = runningStart; i <= runningEnd; i++)
                        {
                            AddNewDataRow(dtResult, i.ToString().PadLeft(5, '0'), i.ToString().PadLeft(5, '0'));
                        }
                    }
                    else
                    {
                        AddNewDataRow(dtResult, RunningNo[0].ToString().PadLeft(5, '0'), runningStart.ToString().PadLeft(5, '0'));
                    }

                    UpdateSummaryRMTagQty();
                    txtQRCode.Text = string.Empty;

                    ConfirmData();
                    PrintStickLabel(runningStart.ToString().PadLeft(5, '0'), runningEnd.ToString().PadLeft(5, '0'), Convert.ToInt32(dtResult.Rows[0]["ProductID"]));
                    dtDataResult.Rows.Clear();

                    //---------------------------------------------------------
                    _LEnd_ = "END ROUND 2";
                    _LEndCurrentDate_ = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                    ControlUtil.LogFileEnd(_LMethod_, _LEnd_, _LEndCurrentDate_);
                }
                //---------------------------------------------------------
                _LEnd_ = "END ROUND 1";
                _LEndCurrentDate_ = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(_LMethod_, _LEnd_, _LEndCurrentDate_);
                ClearLog();
                //--------------------------------------------------------
            }
            catch (Exception ex)
            {
                //-------------------------------------------------------------------------------------------------------
                _LMethod_ = "Exception --> dlgKPK021_ConfirmPacking_ScanDetail/txtQRCode_KeyPress(object sender, KeyPressEventArgs e)";
                _LStart_ = "Start Exception";
                _LStartCurrentDateDate_ = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                _LParameter_ = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                ControlUtil.LogFileStart(_LMethod_, _LStart_, _LStartCurrentDateDate_, _LParameter_);
                _LEnd_ = "End Exception";
                _LEndCurrentDate_ = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(_LMethod_, _LEnd_, _LEndCurrentDate_);
                //-----------------------------------------------------------------------------------------------------
                txtQRCode.Text = string.Empty;
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
            finally
            {
                //base.GridViewOnChangeLanguage(grdResult);
                CloseWaitScreen();
            }
        }
        #endregion

        #region Generic Function
        private bool ValidateQRCode(string QRCode)
        {
            bool isValid = false;
            string[] QRData = QRCode.Split(':');
            string[] QRCommand = QRCode.Split('-');
            if (QRData.Length == 8 || QRCommand.Length == 2)
            {
                isValid = true;
            }
            return isValid;
        }

        private void AddNewDataRow(DataTable dtRMData, string RunningNo, string RunningForOutTag)
        {
            if (dtDataResult.Rows.Count > 0 && Convert.ToInt32(dtDataResult.Rows[0]["SumRMQty"]) + Convert.ToInt32(dtDataResult.Rows[0]["PackedQty"]) == Convert.ToInt32(dtDataResult.Rows[0]["PlanPackQty"]))
            {
                lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0014");
                return;
            }
            
            DataRow dr = dtDataResult.NewRow();
            dr["PDSNo"] = dtRMData.Rows[0]["PDSNo"];
            dr["PackingNo"] = dtRMData.Rows[0]["PackingNo"];
            dr["LineNo"] = dtRMData.Rows[0]["LineNo"];
            dr["ShipmentNo"] = dtRMData.Rows[0]["ShipmentNo"];
            dr["PickingNo"] = dtRMData.Rows[0]["PickingNo"];
            dr["Installment"] = dtRMData.Rows[0]["Installment"];
            dr["RunningNo"] = RunningNo;
            dr["RunningForOutTag"] = string.Format("OUT-{0}", RunningForOutTag);
            dr["PackQty"] = dtRMData.Rows[0]["PackQty"];
            dr["UnitOfPackQty"] = dtRMData.Rows[0]["UnitOfPackQty"];
            dr["ProductID"] = dtRMData.Rows[0]["ProductID"];
            dr["PartCode"] = dtRMData.Rows[0]["PartCode"];
            dr["PartName"] = dtRMData.Rows[0]["PartName"];
            dr["PlanPackQty"] = dtRMData.Rows[0]["PlanPackQty"];
            dr["RMTagQty"] = dtRMData.Rows[0]["RMTagQty"];
            dr["SumRMQty"] = dtRMData.Rows[0]["SumRMQty"];
            dr["PackedQty"] = dtRMData.Rows[0]["PackedQty"];

            if (dtDataResult.Rows.Count > 0)
            {
                DataRow[] duppData = dtDataResult.Select(string.Format("PDSNo = '{0}' AND RunningNo = '{1}'", dtRMData.Rows[0]["PDSNo"].ToString(), RunningNo));

                if (duppData.Length <= 0)
                {
                    dtDataResult.Rows.Add(dr);
                }
            }
            else
            {
                dtDataResult.Rows.Add(dr);
            }
        }

        private void UpdateSummaryRMTagQty()
        {
            //-------------------------------------------------------------------------
            ControlUtil.LMethod = "UpdateSummaryRMTagQty()";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            //----------------------------------------------------------------------------

            int RMTagSum = Convert.ToInt32(dtDataResult.Compute("SUM(RMTagQty)", ""));

            //-------------------------------
            ControlUtil.LParameter = "RMTagSum = " + RMTagSum;
            /*************************** Write Log ******************************/
            ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
            /***************************End Write Log ******************************/
            //-------------------------------

            foreach (DataRow dr in dtDataResult.Rows)
            {
                dr["SumRMQty"] = RMTagSum;
            }

            //---------------------------------------------------------
            ControlUtil.LEnd = "END";
            ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
            //--------------------------------------------------------
        }

        private void PrintStickLabel(string RMTagStart, string RMTagEnd, int ProductID)
        {
            //-------------------------------------------------------------------------
            String _Method = "PrintStickLabel(string RMTagStart, string RMTagEnd, int ProductID)";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            ControlUtil.LParameter = String.Format("RMTagStart = {0}; RMTagEnd = {1}; ProductID = {2}", RMTagStart, RMTagEnd, ProductID);
            ControlUtil.LogFileStart(_LMethod_, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
            //----------------------------------------------------------------------------

            List<sp_RPT045_LabelSticker_GetData_Result> lstreport = ReportBusiness_LabelSticker.GetDataByRMTagReport(PackingNo, RMTagStart, RMTagEnd, ProductID);
            if (lstreport.Count > 0)
            {
                rptRPT045_LabelSticker rpt = new rptRPT045_LabelSticker(ReportBusiness_LabelSticker.GetReportDefaultParams("RPT045"));
                rpt.DataSource = lstreport;
                rpt.ShowPrintMarginsWarning = false;
                //-------------------------------------------------------------------------
                ControlUtil.LMethod = "rpt.Print()";
                ControlUtil.LStart = "START";
                ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LParameter = "lstreport = " + lstreport.Count;
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate,ControlUtil.LParameter);
                //------------------------------------------------------------------------------

                rpt.Print();

                //------------------------------------------------------------------------------
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //------------------------------------------------------------------------------
            }

            //----------------------------------------------------------------------------------
            ControlUtil.LEnd = "END";
            ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            ControlUtil.LogFileEnd(_Method, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
            //---------------------------------------------------------
        }

        private void ConfirmData()
        {
            //-------------------------------------------------------------------------
            String _Method = "ConfirmData()";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            //----------------------------------------------------------------------------

            DataSet ds = new DataSet("PackingDataSet");
            ControlUtil.LParameter = "";
            ControlUtil.LogFileStart(_Method, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
            try
            {
                DataRow[] dr = dtDataResult.Select("", "", DataViewRowState.Added);
                if (dr != null && dr.Length != 0)
                {                    
                    DataTable dtRMDetail = new DataTable();    
                    dtRMDetail = dr.CopyToDataTable();
                    dtRMDetail.TableName = "PackingDataTable";
                    ds.Tables.Add(dtRMDetail);
                    BusinessClass.ConfirmPackingConfirmData(PackingNo, ds.GetXml());
                    ds.Tables.Clear();
                    dtDataResult.AcceptChanges();
                }

                //---------------------------------------------------------
                ControlUtil.LParameter = "PackingDataSet = " + ds.GetXml();
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(_LMethod_, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //---------------------------------------------------------
            }

            catch (Exception ex)
            {
                //-------------------------------------------------------------------------------------------------------
                ControlUtil.LMethod = "Exception --> ConfirmData()";
                ControlUtil.LStart = "Start Exception";
                ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LParameter = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                ControlUtil.LEnd = "End Exception";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //-----------------------------------------------------------------------------------------------------

                throw ex;
            }
            finally
            {
                ds.Tables.Clear();
                ds.Clear();
                ds = null;
            }
        }

        public static void ClearLog()
        {
            _LMethod_ = "";
            _LStart_ = "";
            _LStartCurrentDateDate_ = "";
            _LParameter_ = "";
            _LEnd_ = "";
            _LEndCurrentDate_ = "";
            ControlUtil.LogFile(_LMethod_, _LStart_, _LStartCurrentDateDate_, _LParameter_, _LEnd_, _LEndCurrentDate_);
        
        }
        #endregion
    }
}