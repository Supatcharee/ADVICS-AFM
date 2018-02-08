using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using Rubix.Screen.Form.Operation.K_Packing.Dialog;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using CSI.Business.BusinessFactory.Common;
using CSI.Business.DataObjects;
using Rubix.Screen.Report;
using CSI.Business.Report;
using System.Diagnostics;
using System.Runtime.InteropServices; 

namespace Rubix.Screen.Form.Operation.K_Packing
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Print, Permission.Confirm, Permission.Export)]
    public partial class frmKPK020_ConfirmPacking : FormBase
    {
        #region Member
        PackingInstruction db = null;
        PackingInstructionReport dbReport = null;
        dlgKPK011_PackingArragement m_Dialog = null;
        dlgKPK021_ConfirmPacking_ScanDetail m_ScanerDialog = null;
        dlgKPK022_PackingAppearance m_DialogAppearance = null;
        dlgKPK023_Confirmpacking_loginUser m_DialogLogin = null;
        private bool isScanMode = true;
        private LabelStickerReport m_objRptLabelSticker = null;
        private DataTable dtRMDetail;
        private int iConfirmCommand = 0;  //0 = OK Common; 1 = Restart; 2 = Shutdown;
        private string userLogon = null;
        private string machineIP = null;
        #endregion

        #region Properties
        private dlgKPK023_Confirmpacking_loginUser DialogLogin
        {
            get {
                if (m_DialogLogin == null)
                {
                    return m_DialogLogin = new dlgKPK023_Confirmpacking_loginUser();
                }
                return m_DialogLogin;
            }
            set {
                m_DialogLogin = value;
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
        private dlgKPK011_PackingArragement Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new dlgKPK011_PackingArragement();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        private dlgKPK021_ConfirmPacking_ScanDetail ScanerDialog
        {
            get
            {
                if (m_ScanerDialog == null)
                {
                    return m_ScanerDialog = new dlgKPK021_ConfirmPacking_ScanDetail();
                }
                return m_ScanerDialog;
            }
            set
            {
                m_ScanerDialog = value;
            }
        }
        private dlgKPK022_PackingAppearance AppearanceDialog
        {
            get
            {
                if (m_DialogAppearance == null)
                {
                    return m_DialogAppearance = new dlgKPK022_PackingAppearance();
                }
                return m_DialogAppearance;
            }
            set
            {
                m_DialogAppearance = value;
            }
        }
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
        public frmKPK020_ConfirmPacking()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarEdit);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(gpcSearchCriteria);

            iv = new IdleValidator("tbt_PackingHeader", "UpdateDate", "PackingNo");
            SetControl(this.Controls);
        }
        #endregion

        #region Override Method
        public override bool OnCommandConfirm()
        {
            try
            {
                ShowWaitScreen();
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (dr != null)
                {
                    if (!iv.ValidateTicket(dr["PackingNo"].ToString()))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }

                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0201"), dr["PackingNo"].ToString())) == DialogButton.Yes)
                    {
                        ConfirmData();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0402"), dr["PackingNo"].ToString()));
                        if (!this.isScanMode)
                        {
                            DataLoading();
                        }
                        else
                        {
                            ScanerDataLoading(dr["ShipmentNo"].ToString(), dr["PackingNo"].ToString(), false);
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }            
        }

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
        #endregion

        #region Even Handler
        private void frmKPK020_ConfirmPacking_Load(object sender, EventArgs e)
        {
            try
            {
                btnPrintStickLabel.Visible = base.CanPrint;
                m_toolBarPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                ControlUtil.EnableControl(false, btnPrintStickLabel);
                ScanerMode(true);
                timer1.Enabled = true;
                //OpenLogonDialog();
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
                if (ValidateSearchCiteria())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }              

        private void btnPrintStickLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }

                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                string PackingNo = Convert.ToString(dr["PackingNo"]);

                List<sp_RPT045_LabelSticker_GetData_Result> lstReport = ReportBusiness_LabelSticker.GetDataReport(PackingNo);
                if (lstReport.Count > 0)
                {
                    rptRPT045_LabelSticker rpt = new rptRPT045_LabelSticker(ReportBusiness_LabelSticker.GetReportDefaultParams("RPT045"));
                    rpt.DataSource = lstReport;
                    rpt.ShowPrintMarginsWarning = false;
                    ReportUtil.ShowPreview(rpt);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnViewApperance_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (dr != null)
                {

                    OpenAppearanceDialog(dr["PackingNo"].ToString());


                }


            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null)
                {
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dtPackingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null && dtPackingDateFrom.EditValue != null)
                {
                    shipmentControl.PackDateFrom = dtPackingDateFrom.DateTime;
                    packingControl.PackingDateFrom = dtPackingDateFrom.DateTime;
                    shipmentControl.DataLoading();
                    packingControl.DataLoading();
                }
                else
                {
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    packingControl.ShipmentNo = "-1";
                    shipmentControl.DataLoading();
                    packingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dtPackingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null && dtPackingDateTo.EditValue != null)
                {
                    shipmentControl.PackDateTo = dtPackingDateTo.DateTime;
                    packingControl.PackingDateTo = dtPackingDateTo.DateTime;
                    shipmentControl.DataLoading();
                    packingControl.DataLoading();
                }
                else
                {
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    packingControl.ShipmentNo = "-1";
                    shipmentControl.DataLoading();
                    packingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(shipmentControl.ShipmentNo))
                {
                    packingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    packingControl.DataLoading();
                }
                else
                {
                    packingControl.ShipmentNo = "-1";
                    packingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }        

        private void Function_Keydown(object sender, KeyEventArgs e)
        {
            //•	F9: Export
            //•	F12: Exit screen

            if (e.KeyCode == Keys.F3)
            {
                //•	F3: Change Mode (Screen Mode <--> Scanner Mode)
                if (isScanMode)
                {
                    isScanMode = false;
                }
                else
                {
                    isScanMode = true;
                    txtQRCode.Focus();
                }
                ScanerMode(isScanMode);
            }
            else if (e.KeyCode == Keys.F4)
            {
                //•	F4: Display
                btnSearch_Click(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.F5)
            {
                //•	F5: Clear
                ClearData();
            }
            else if (e.KeyCode == Keys.F6)
            {
                //•	F6: Print Case Mark
            }
            else if (e.KeyCode == Keys.F7)
            {
                //•	F7: Print Sticker Label
                btnPrintStickLabel_Click(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.F8)
            {
                //•	F8: Confirm Packing 
                OnCommandConfirm();
            } 
            else if (e.Shift && e.KeyCode == Keys.F1)
            {
                btnViewApperance_Click(sender, new EventArgs());
            }

        }

        private void chkBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (chkUnconfirm.Checked)
                {
                    grdSearchResult.DataSource = null;
                    ControlUtil.HiddenControl(false, m_toolBarConfirm);
                    shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingUnconfirmed();
                    shipmentControl.DataLoading();
                    packingControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingUnconfirmed();
                    packingControl.DataLoading();
                    ControlUtil.EnableControl(false, btnPrintStickLabel);
                }
                else
                {
                    grdSearchResult.DataSource = null;
                    ControlUtil.HiddenControl(true, m_toolBarConfirm);
                    shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingConfirmed();
                    shipmentControl.DataLoading();
                    packingControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingConfirmed();
                    packingControl.DataLoading();
                    ControlUtil.EnableControl(true, btnPrintStickLabel);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void txtQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                if (txtQRCode.Enabled && !string.IsNullOrEmpty(txtQRCode.Text) && e.KeyChar == (char)Keys.Enter)
                {
                    if (ValidateQRCode(txtQRCode.Text))
                    {
                        if (txtQRCode.Text.Trim().Split('-').Length == 2)
                        {
                            CommandFunction();
                            return;
                        }

                        //  [0]QR-PACK , [1]ShipmentNo, [2]PackingNo
                        string[] QRData = txtQRCode.Text.Trim().Split(':');
                        OpenScanerDialog(QRData[1], QRData[2]);
                    }
                    //else if (txtQRCode.Text == "logoff")
                    //{
                    //    OpenLogonDialog();
                    //}
                    else
                    {
                        lblErrorMsg.ForeColor = Color.Red;
                        lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0403");
                    }
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                }
            }
            catch (Exception ex)
            {
                ScanerDialog = null;
                txtQRCode.Text = string.Empty;
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtQRCode.Focus();
            timer1.Enabled = false;
        }        
        #endregion

        #region Generic Function
        private void OpenLogonDialog()
        {
            userLogon = null;
            machineIP = null;
            DialogLogin.ShowDialog();
            if (DialogLogin.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                userLogon = DialogLogin.UserLogin;
                machineIP = DialogLogin.MachineIP;
            }
        }
        
        private bool ValidateQRCode(string QRCode)
        {
            bool isValid = false;
            string[] QRData = QRCode.Split(':');
            string[] QRCommand = QRCode.Split('-');

            if (QRData.Length == 4)
            {
                if (QRData[0].Equals("QR-PACK"))
                {
                    isValid = true;
                }
            }

            if (QRCommand.Length == 2)
            {
                isValid = true;
            }

            return isValid;
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            if (gdvSearchResult.RowCount == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
            }
            else
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (dr != null)
                {
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.SelecedDataRow = dr;
                    //Dialog.BusinessClass = BusinessClass;
                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), ""));
                    }
                    Dialog = null;
                }

            }
            
        }

        private void OpenScanerDialog(string ShipmentNo, string PackingNo)
        {
            ShowWaitScreen();
            ScanerDataLoading(ShipmentNo, PackingNo,false);
            CloseWaitScreen();
            lblErrorMsg.Text = "";

            if (gdvSearchResult.RowCount > 0)
            {
                ScanerDialog.ShipmentNo = ShipmentNo;
                ScanerDialog.PackingNo = PackingNo;
                ScanerDialog.UserLogin = userLogon;
                ScanerDialog.MachineIP = machineIP;

                if (ScanerDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //dtRMDetail = ScanerDialog.dtDataResult.Copy();
                }
                
                txtQRCode.Focus();
                ScanerDialog = null;
                ScanerDataLoading(ShipmentNo, PackingNo, true);
            }
            else
            {
                ScanerDataLoading(ShipmentNo, PackingNo, true);
                if (gdvSearchResult.RowCount > 0)
                {
                    lblErrorMsg.ForeColor = Color.Red;
                    lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0404");
                    grdSearchResult.DataSource = null;
                }
                else
                {
                    lblErrorMsg.ForeColor = Color.Red;
                    lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0014");
                }
            }
        }

        private void OpenAppearanceDialog(string PackingNo)
        {
            if (gdvSearchResult.RowCount == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
            }
            else
            {
                AppearanceDialog.dtDataResult = AppearanceDataLoading(PackingNo);
                AppearanceDialog.ShowDialog(this);

                //if (Dialog.ShowDialog(this) == DialogResult.OK)
                //{
                //    DataLoading();
                //    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), ""));
                //}
                Dialog = null;
                

            }


        }
        
        private void DataLoading()
        {
                this.ShowWaitScreen();
                iv.ClearTicket();
                grdSearchResult.DataSource = null;
                DataTable dt = BusinessClass.ConfirmPackingSearchAll(ownerControl.OwnerID,
                                                                        customerControl.CustomerID,
                                                                        warehouseControl.WarehouseID,
                                                                        shipmentControl.ShipmentNo,
                                                                        packingControl.PackingNo,
                                                                        txtCustomerPONo.Text.Trim(),
                                                                        dtPackingDateFrom.DateTime, //yyyy/MM/dd
                                                                        dtPackingDateTo.DateTime, //yyyy/MM/dd
                                                                        chkConfirmed.Checked);

                grdSearchResult.DataSource = dt;
                base.GridViewOnChangeLanguage(grdSearchResult);

                //IdleValidator
                foreach (DataRow dr in dt.Rows)
                {
                    iv.PushTicket(Convert.ToDateTime(dr["DateForValiDate"]), dr["PackingNo"].ToString());
                }

                CloseWaitScreen();
           
        }

        private void ScanerDataLoading(string ShipmentNo, string PackingNo,bool Status)
        {
            iv.ClearTicket();
            grdSearchResult.DataSource = null;
            DataTable dt = BusinessClass.ConfirmPackingForScannerSearchAll(null, null, null, ShipmentNo, PackingNo, null, null, null, Status);

            grdSearchResult.DataSource = dt;
            base.GridViewOnChangeLanguage(grdSearchResult);

            //IdleValidator
            foreach (DataRow dr in dt.Rows)
            {
                iv.PushTicket(Convert.ToDateTime(dr["DateForValiDate"]), dr["PackingNo"].ToString());
            }
        }

        private DataTable AppearanceDataLoading(string PackingNo)
        {
            this.ShowWaitScreen();

            DataTable dt = BusinessClass.PackingAppearanceSearchPackingProduct(PackingNo);
            
            CloseWaitScreen();

            return dt;
        }
        
        private void ClearData()
        {

            ControlUtil.ClearControlData(chkUnconfirm
                                           , chkConfirmed                                        
                                           , shipmentControl
                                           , packingControl
                                           , txtCustomerPONo
                                           , txtQRCode);

            ownerControl.ClearData();
            customerControl.ClearData();
            warehouseControl.ClearData();
            shipmentControl.ClearData();
            packingControl.ClearData();

            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingUnconfirmed();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();
            packingControl.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingConfirmed();
            packingControl.ShipmentNo = "-1";
            packingControl.DataLoading();

            dtPackingDateFrom.EditValue = ControlUtil.GetStartDate();
            dtPackingDateTo.EditValue = ControlUtil.GetEndDate();

            chkUnconfirm.Checked = true;

            ScanerDialog = null;            
        }

        private void ScanerMode(bool isScan)
        {
            //Search Mode
            ControlUtil.EnableControl(!isScan, chkUnconfirm
                                           , chkConfirmed
                                           , ownerControl
                                           , customerControl
                                           , warehouseControl
                                           , dtPackingDateFrom
                                           , dtPackingDateTo
                                           , shipmentControl
                                           , packingControl
                                           , txtCustomerPONo
                                           , btnSearch
                                           , btnClear);
            ownerControl.EnableControl = !isScan;
            warehouseControl.EnableControl = !isScan;

            //Scan Mode
            ControlUtil.EnableControl(isScan, txtQRCode);
            ClearData();

            chkUnconfirm.Checked = true;
            ControlUtil.HiddenControl(isScan, m_toolBarConfirm);
        }

        private bool ValidateSearchCiteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //validate &= customerControl.ValidateControl();

            if (string.IsNullOrEmpty(dtPackingDateFrom.Text))
            {
                errorProvider.SetError(dtPackingDateFrom, Common.GetMessage("I0265"));
                validate = false;
            }
            if (string.IsNullOrEmpty(dtPackingDateTo.Text))
            {
                errorProvider.SetError(dtPackingDateTo, Common.GetMessage("I0266"));
                validate = false;
            }

            return validate;
        }

        private void SetControl(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (System.Windows.Forms.Control control in controls)
            {
                if (control.GetType().FullName.Contains("Rubix.Control") 
                    || control.GetType() == typeof(GroupControl)
                    || control.GetType() == typeof(PanelControl))
                {
                    SetControl(control.Controls);
                }
                else
                    control.KeyDown += new KeyEventHandler(Function_Keydown);

            }
        }

        private void ConfirmData()
        {
            DataSet ds = new DataSet("PackingDataSet");
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                if (dr != null)
                {
                    if (dtRMDetail == null)
                    {
                        dtRMDetail = new DataTable();                        
                    }
                    dtRMDetail.TableName = "PackingDataTable";
                    ds.Tables.Add(dtRMDetail);
                    //BusinessClass.ConfirmPackingConfirmData(dr["PackingNo"].ToString(), ds.GetXml(), userLogon, machineIP);
                    BusinessClass.ConfirmPackingConfirmData(dr["PackingNo"].ToString(), ds.GetXml());
                    ds.Tables.Clear();
                }
            }
            catch (Exception ex)
            {               
                throw ex;
            }
            finally
            {
                ds.Tables.Clear();
                ds.Clear();
                ds = null;
            }
        }

        private void CommandFunction()
        {
            //PCI-F08   Comfirm
            if (txtQRCode.Text.Equals("PCI-SF02"))
            {
                if (iConfirmCommand == 1)
                {
                    Process.Start("shutdown", "/r /t 0");
                    // the argument /r is to restart the computer
                }
                else if (iConfirmCommand == 2)
                {
                    Process.Start("shutdown", "/s /t 0");
                    // starts the shutdown application 
                    // the argument /s is to shut down the computer
                    // the argument /t 0 is to tell the process that 
                    // the specified operation needs to be completed 
                    // after 0 seconds
                }
            }
            else if (txtQRCode.Text.Equals("PCI-F08"))
            {
                OnCommandConfirm();
            }
            else if (txtQRCode.Text.Equals("PCI-F20"))
            {
                base.OnLogout();
            }
            else if (txtQRCode.Text.Equals("PCI-F30"))
            {
                lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0429");
                iConfirmCommand = 1; //restart               
            }
            else if (txtQRCode.Text.Equals("PCI-F40"))
            {
                lblErrorMsg.Text = Rubix.Screen.Common.GetMessage("I0429");
                iConfirmCommand = 2; //shutdown
            }

            txtQRCode.Text = string.Empty;
            txtQRCode.Focus();
        }

        #endregion        
    }
}