using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Operation;
using CSI.Business.Report;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.DataObjects;
using Rubix.Screen.Report;

namespace Rubix.Screen.Form.Operation.I_Shipping.Dialog
{
    public partial class dlgISHS011_ExportDocument : DialogBase
    {
        #region Member

        private ExportDocument m_objExportDocument = null;

        private ExportInvoiceReport m_objExportInvoice = null;
        private DomesticInvoiceReport m_objDomesticInvoice = null;
        private ShippingInstructionReport m_objShippingInstruction = null;
        private AdviceOfShipmentReport m_objAdviceOfShipment = null;
        private PackingListReport m_objPackingList = null;

        private PrivilegeFormatReport m_objPrivilegeFormat = null;
        #endregion

        #region Constructor

        public dlgISHS011_ExportDocument(string shipmentNo, int installment, string containerNo)
        {
            InitializeComponent();

            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave, m_toolBarSaveACopy);
            ControlUtil.HiddenControl(false, m_toolBarPrint);

            this.ShipmentNo = shipmentNo;
            this.ContainerNo = containerNo;
            this.Installment = installment;
        }

        #endregion

        #region Properties

        public string ShipmentNo { get; private set; }
        public string ContainerNo { get; private set; }
        public int Installment { get; private set; }
        
        private ExportDocument BusinessClass
        {
            get
            {
                if (m_objExportDocument == null)
                {
                    m_objExportDocument = new ExportDocument();
                }
                return m_objExportDocument;
            }
        }

        private ExportInvoiceReport ReportClass_ExportInovice
        {
            get
            {
                if (m_objExportInvoice == null)
                {
                    m_objExportInvoice = new ExportInvoiceReport();
                }
                return m_objExportInvoice;
            }
        }

        private DomesticInvoiceReport ReportClass_DomesticInovice
        {
            get
            {
                if (m_objDomesticInvoice == null)
                {
                    m_objDomesticInvoice = new DomesticInvoiceReport();
                }
                return m_objDomesticInvoice;
            }
        }

        private ShippingInstructionReport ReportClass_ShippingInstruction
        {
            get
            {
                if (m_objShippingInstruction == null)
                {
                    m_objShippingInstruction = new ShippingInstructionReport();
                }
                return m_objShippingInstruction;
            }
        }

        private PrivilegeFormatReport ReportClass_PrivilegeFormat
        {
            get
            {
                if (m_objPrivilegeFormat == null)
                {
                    m_objPrivilegeFormat = new PrivilegeFormatReport();
                }
                return m_objPrivilegeFormat;
            }
        }

        private AdviceOfShipmentReport ReportClass_AdviceOfShipment
        {
            get
            {
                if (m_objAdviceOfShipment == null)
                {
                    m_objAdviceOfShipment = new AdviceOfShipmentReport();
                }
                return m_objAdviceOfShipment;
            }
        }

        private PackingListReport ReportClass_PackingList
        {
            get
            {
                if (m_objPackingList == null)
                {
                    m_objPackingList = new PackingListReport();
                }
                return m_objPackingList;
            }
        }
        #endregion

        #region Overriden Method
        public override bool OnCommandPrint()
        {
            try
            {
                // Validate
                if (!chkPackingList.Checked
                    && !chkSaleInvoice.Checked
                    && !chkAdviceOfShipment.Checked
                    && !chkShippingInstruction.Checked
                    && !chkPrivilegeFormat.Checked)
                {

                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                ShowWaitScreen();

                // Execute Printing selected report.
                if (chkSaleInvoice.Checked) Print_SaleInvoice();
                if (chkPackingList.Checked) Print_PackingList();
                if (chkAdviceOfShipment.Checked) Print_AdviceOfShipment();
                if (chkShippingInstruction.Checked) Print_ShippingInstruction();
                if (chkPrivilegeFormat.Checked) Print_PrivilegeFormat();

                CloseWaitScreen();

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }            
        }
        #endregion

        #region Print Operator

        private void Print_PackingList()
        {
            List<sp_RPT044_PackingList_GetData_Result> DataHeader = ReportClass_PackingList.GetDataReport(ShipmentNo, 1, ContainerNo);

            rptRPT044_PackingList rpt = new rptRPT044_PackingList(ReportClass_ExportInovice.GetReportDefaultParams("RPT044"));
            rpt.DataSource = DataHeader;
            rpt.SetParameterReport("printBy", AppConfig.Name);

            ReportUtil.ShowPreview(rpt);
        }

        private void Print_SaleInvoice()
        {
            // Flag indicate that has data to print any report.
            bool bPrintable = false;

            // Update Data
            BusinessClass.UpdatePrePrint(this.ShipmentNo, this.Installment, this.ContainerNo);

            // Export Invoice
            DataSet dsExport = ReportClass_ExportInovice.GetDataReport(ShipmentNo, 1, ContainerNo);
            DataSet dsDomestic = ReportClass_DomesticInovice.GetDataReport(ShipmentNo, 1, ContainerNo);

            //ตรวจสอบว่า report ที่ส่งกลับมาจาก API data row --> เอาออกตาม requirement 
            //if ((dsExport.Tables[0].Rows.Count == 0 || dsExport.Tables[1].Rows.Count == 0 || dsExport.Tables[2].Rows.Count == 0) &&
            //    (dsDomestic.Tables[0].Rows.Count == 0 || dsDomestic.Tables[1].Rows.Count == 0 || dsDomestic.Tables[2].Rows.Count == 0))
            //{
            //    return;
            //}
                
            if (dsExport.Tables.Count == 3 && dsExport.Tables[0].Rows.Count > 0)
            {
                //ตรวจสอบว่ามีเลข invoice gen ให้แล้วหรือยัง แล้วเตือนว่าถ้าจะปริ้นระบบก็ไม่ได้ gen ให้ --> โปรเจคนี้ gen ให้หลังจาก print report
                //if (dsExport.Tables[0].Rows[0]["InvoiceNo"].ToString() == string.Empty && MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0430")) == DialogButton.No)
                //{
                //    return;
                //}

                bPrintable = true;

                dsExport.Tables[0].TableName = "dtbHeader";
                dsExport.Tables[1].TableName = "dtbDetail";
                dsExport.Tables[2].TableName = "dtbFooter";

                DataColumn[] fkHeader = new DataColumn[] {dsExport.Tables[0].Columns["ShipmentNo"],  dsExport.Tables[0].Columns["Installment"]};
                DataColumn[] fkDetail = new DataColumn[] {dsExport.Tables[1].Columns["ShipmentNo"],  dsExport.Tables[1].Columns["Installment"]};
                DataColumn[] fkFooter = new DataColumn[] { dsExport.Tables[2].Columns["ShipmentNo"], dsExport.Tables[2].Columns["Installment"] };

                dsExport.Relations.Add("fk_HeaderDetail", fkHeader, fkDetail, false);
                dsExport.Relations.Add("fk_HeaderFooter", fkHeader, fkFooter, false);

                rptRPT038_ExportInvoiceReport rpt = new rptRPT038_ExportInvoiceReport(ReportClass_ExportInovice.GetReportDefaultParams("RPT038"));
                rpt.DataSource = dsExport;
                rpt.SetParameterReport("Remark", txtInvoiceRemark.Text);
                rpt.SetParameterReport("Atten1", chkInvCon1.Checked);
                rpt.SetParameterReport("Atten2", chkInvCon2.Checked);
                rpt.SetParameterReport("Atten3", chkInvCon3.Checked);
                rpt.SetParameterReport("From", txtParamFrom.Text);
                rpt.SetParameterReport("To", txtParamTo.Text);            

                ReportUtil.ShowPreview(rpt);
            }

            // Domestic Invoice
            if (dsDomestic.Tables.Count == 3 && dsDomestic.Tables[0].Rows.Count > 0)
            {
                //ตรวจสอบว่ามีเลข invoice gen ให้แล้วหรือยัง แล้วเตือนว่าถ้าจะปริ้นระบบก็ไม่ได้ gen ให้ --> โปรเจคนี้ gen ให้หลังจาก print report
                //if (dsDomestic.Tables[0].Rows[0]["InvoiceNo"].ToString() == string.Empty && MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0430")) == DialogButton.No)
                //{
                //    return;
                //}

                bPrintable = true;

                dsDomestic.Tables[0].TableName = "dtbHeader";
                dsDomestic.Tables[1].TableName = "dtbDetail";
                dsDomestic.Tables[2].TableName = "dtbFooter";

                DataColumn[] fkHeader = new DataColumn[] { dsDomestic.Tables[0].Columns["ShipmentNo"], dsDomestic.Tables[0].Columns["Installment"] };
                DataColumn[] fkDetail = new DataColumn[] { dsDomestic.Tables[1].Columns["ShipmentNo"], dsDomestic.Tables[1].Columns["Installment"] };
                DataColumn[] fkFooter = new DataColumn[] { dsDomestic.Tables[2].Columns["ShipmentNo"], dsDomestic.Tables[2].Columns["Installment"] };

                dsDomestic.Relations.Add("fk_HeaderDetail", fkHeader, fkDetail, false);
                dsDomestic.Relations.Add("fk_HeaderFooter", fkHeader, fkFooter, false);

                rptRPT039_DomesticInvoiceReport rpt = new rptRPT039_DomesticInvoiceReport(ReportClass_ExportInovice.GetReportDefaultParams("RPT039"));
                rpt.DataSource = dsDomestic;
                rpt.SetParameterReport("Remark", txtInvoiceRemark.Text);   

                ReportUtil.ShowPreview(rpt);
            }
          
        }

        private void Print_AdviceOfShipment()
        {
            List<sp_RPT042_AdivceOfShipment_GetData_Result> Data = ReportClass_AdviceOfShipment.GetDataReport(ShipmentNo, 1, ContainerNo);

            rptRPT042_AdviceOfShipment rpt = new rptRPT042_AdviceOfShipment(ReportClass_ExportInovice.GetReportDefaultParams("RPT042"));
            rpt.DataSource = Data;

            ReportUtil.ShowPreview(rpt);
        }

        private void Print_ShippingInstruction()
        {
            // Export Invoice
            DataSet dsCover = ReportClass_ShippingInstruction.GetCoverDataReport(ShipmentNo, 1, ContainerNo);
            DataSet dsList = ReportClass_ShippingInstruction.GetListDataReport(ShipmentNo, 1, ContainerNo);  

            //################
            //# Print Cover
            //################
            if (dsCover.Tables.Count == 1 && dsCover.Tables[0].Rows.Count > 0)
            {
                dsCover.Tables[0].TableName = "dtbHeader";

                rptRPT040_ShippingInstructionCoverReport rpt = new rptRPT040_ShippingInstructionCoverReport(ReportClass_ExportInovice.GetReportDefaultParams("RPT040"));
                rpt.DataSource = dsCover;
                rpt.SetParameterReport("printBy", AppConfig.Name);

                ReportUtil.ShowPreview(rpt);
            }


            //################
            //# Print List
            //################
            if (dsList.Tables.Count == 1 && dsList.Tables[0].Rows.Count > 0)
            {
                dsList.Tables[0].TableName = "dtbData";

                rptRPT041_ShippingInstructionListReport rpt = new rptRPT041_ShippingInstructionListReport(ReportClass_ExportInovice.GetReportDefaultParams("RPT041"));
                rpt.DataSource = dsList;
                rpt.SetParameterReport("printBy", AppConfig.Name);

                ReportUtil.ShowPreview(rpt);
            }
        }

        private void Print_PrivilegeFormat()
        {
            try
            {
                List<sp_RPT043_PrivilegeFormat_GetData_Result> dsExport = ReportClass_PrivilegeFormat.GetDataReport(ShipmentNo, ContainerNo);
                if (dsExport.Count > 0)
                {
                    rptRPT043_PrivilegeFormatReport rpt = new rptRPT043_PrivilegeFormatReport(ReportClass_PrivilegeFormat.GetReportDefaultParams("RPT043"));
                    rpt.DataSource = dsExport;
                    rpt.SetParameterReport("printBy", AppConfig.Name);

                    ReportUtil.ShowPreview(rpt);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Events Handler Function

        private void dlgSHS011_ExportDocument_Load(object sender, EventArgs e)
        {
            base.HideStatusBar();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            chkPackingList.Checked = true;
            chkSaleInvoice.Checked = true;
            chkAdviceOfShipment.Checked = true;
            chkShippingInstruction.Checked = true;
            chkPrivilegeFormat.Checked = true;
            chkInvCon1.Checked = true;
            chkInvCon2.Checked = true;
            chkInvCon3.Checked = true;
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            chkPackingList.Checked = false;
            chkSaleInvoice.Checked = false;
            chkAdviceOfShipment.Checked = false;
            chkShippingInstruction.Checked = false;
            chkPrivilegeFormat.Checked = false;
            chkInvCon1.Checked = false;
            chkInvCon2.Checked = false;
            chkInvCon3.Checked = false;
        }

        private void chkSaleInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaleInvoice.Checked)
            {
                chkInvCon1.Visible = true;
                chkInvCon2.Visible = true;
                chkInvCon3.Visible = true;
                txtInvoiceRemark.Visible = true;
                labelControl1.Visible = true;
                labelControl2.Visible = true;
                labelControl3.Visible = true;
                txtParamFrom.Visible = true;
                txtParamTo.Visible = true;
            }
            else
            {
                chkInvCon1.Visible = false;
                chkInvCon2.Visible = false;
                chkInvCon3.Visible = false;
                txtInvoiceRemark.Visible = false;
                labelControl1.Visible = false;
                labelControl2.Visible = false;
                labelControl3.Visible = false;
                txtParamFrom.Visible = false;
                txtParamTo.Visible = false;
            }
        }
        #endregion




    }
}