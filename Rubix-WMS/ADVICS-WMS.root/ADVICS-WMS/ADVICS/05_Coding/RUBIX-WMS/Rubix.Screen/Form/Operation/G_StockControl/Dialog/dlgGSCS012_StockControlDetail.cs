/*
 * 18 Jan 2013:
 * 1. add validate qty before save
 */
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
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
namespace Rubix.Screen.Form.Operation.G_StockControl.Dialog
{
    public partial class dlgGSCS012_StockControlDetail : DialogBase
    {
        #region Member
        private StockControl db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public StockControl BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new StockControl();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Enumeration
        // Column order in grid
        private enum eColumns
        {
            StatusName
			,Lineno
			,SortedLineNo
			,Product
			,Distribution
			,PortOfLoading
			,PortOfDischarge
			,OrderQty
			,AssignQty
        }

        #endregion

        #region Constructor
        public dlgGSCS012_StockControlDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarClear);

            colInventory.DisplayFormat.FormatString = Common.QtyFormat;
            colInventory.DisplayFormat.FormatType = FormatType.Custom;
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {

                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), BusinessClass.ShipmentNo)) == DialogButton.Yes)
                {
                    // 18 Jan 2013: add validate qty must be equal to be 0 then be saved. 
                    if (ValidateData())
                    {
                        //sumColumn                    
                        SaveData();
                    }
                    // end 18 Jan 2013: add validate 
                    DialogResult = DialogResult.OK;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void dlgGSCS012_StockControlDetail_Load(object sender, EventArgs e)
        {

            initialData();
            grdSearchDetail.DataSource = BusinessClass.ViewDetail(BusinessClass.ShipmentNo, BusinessClass.PickingNo);
            ControlUtil.SetBestWidth(grvSearchDetail);
            grvSearchDetail.OptionsBehavior.Editable = true;
        }
        private void btnUpdateToZero_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < grvSearchDetail.RowCount; i++ )
            {
                grvSearchDetail.SetRowCellValue(i, colAssignQty, 0);
            }
        }
        #endregion

        #region Generic function
        private void initialData()
        {
            portOfDischarge.EnableControl = false;
            finalDestinationControl.EnableControl = false;
            //txtShipmentNo.Enabled = false;
            //txtPickingNo.Enabled = false;
            ControlUtil.EnableControl(false, txtShipmentNo, txtPickingNo);

            portOfDischarge.PortID = BusinessClass.PortOfDischargeID;
            finalDestinationControl.FinalDestinationID = BusinessClass.FinalDestinationID;
            txtShipmentNo.Text = BusinessClass.ShipmentNo;
            txtPickingNo.Text = BusinessClass.PickingNo;

        }
        private void SaveData()
        {
            grvSearchDetail.PostEditor();
            StringBuilder xml = new StringBuilder();

            xml.Append("<Tab>");
            List<sp_GSCS012_StockControlDetail_Search_Result> data = (List<sp_GSCS012_StockControlDetail_Search_Result>)grdSearchDetail.DataSource;

            foreach (sp_GSCS012_StockControlDetail_Search_Result rec in data)
            {
                string rowXml = string.Empty;
                rowXml = string.Format("<Rec><LineNo>{0}</LineNo><Qty>{1}</Qty></Rec>", rec.Lineno, rec.AssignQty);
                xml.Append(rowXml);
            }
            xml.Append("</Tab>");
            BusinessClass.SavePickingData(AppConfig.UserLogin, xml.ToString());
        }
        // 18 Jan 2013: If sum of qty on grid is equal to be 0, return true (can save)
        private bool ValidateData()
        {
            bool noError = true;

            //decimal sumQty = 0;
            //List<sp_GSCS012_StockControlDetail_Search_Result> temp = (List<sp_GSCS012_StockControlDetail_Search_Result>)grdSearchDetail.DataSource;
            //foreach (sp_GSCS012_StockControlDetail_Search_Result item in temp)
            //{
            //    sumQty += item.AssignQty.HasValue? item.AssignQty.Value:0;
            //}

            //if (sumQty != 0) 
            //{
            //    noError = false;
            //}

            return noError;
        }

        private void grvSearchDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colAssignQty)
                e.Appearance.BackColor = Common.EditableCellColor();
        }
        // end 18 Jan 2013: If sum of qty on grid is equal to be 0, return true (can save)
        #endregion

        
    }
}