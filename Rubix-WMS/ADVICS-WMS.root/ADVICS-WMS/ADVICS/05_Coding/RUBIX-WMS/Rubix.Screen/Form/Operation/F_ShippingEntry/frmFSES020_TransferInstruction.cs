using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Operation;
using CSI.Business.Operation;
using DevExpress.XtraGrid;
using CSI.Business.BusinessFactory.Common;
using CSI.Business.DataObjects;


namespace Rubix.Screen.Form.Operation.F_ShippingEntry
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmFSES020_TransferInstruction : FormBase
    {
        #region Member
        private Dialog.dlgFSES021_TransferInstructionDialog m_Dialog = null;
        private ShippingInstruction db;
        #endregion

        #region Enumeration
        private enum eColShippingHeader
        {
            StatusID
           ,
            ShipmentNo
                ,
            PickingNo
                ,
            Installment
                ,
            Remark
                ,
            OwnerID
                ,
            OwnerCode
                ,
            OwnerName
                ,
            CustomerCode
                ,
            CustomerName
                ,
            WarehouseID
                ,
            WarehouseCode
                ,
            WarehouseName
                ,
            ShippingAreaID
                ,
            ShippingAreaCode
                ,
            ShippingAreaName
                ,
            PickingDate
                ,
            VanningDate
                ,
            TransportationDate
                ,
            CutDate
                ,
            ETD
                ,
            DeliveryDate
                ,
            AgentSeal
                ,
            InspectionSeal
                ,
            InvoiceNo
                ,
            BookingNo
                ,
            VesselName1
                ,
            VesselName2
                ,
            AgentOwner
                ,
            PortOfLoadingID
                ,
            PortOfLoadingCode
                ,
            PortOfLoadingName
                ,
            PortOfDischargeID
                ,
            PortOfDischargeCode
                ,
            PortOfDischargeName
                ,
            FinalDestinationID
                ,
            FinalDestinationCode
                ,
            FinalDestinationLongName
                ,
            ShipCompleteFlag
                ,
            NumberOfPallet
                ,
            ShipCompleteDate
                ,
            CreateDate
                ,
            CreateUser
                ,
            UpdateDate
                ,
            UpdateUser
                , CustomerID
        }
        #endregion

        #region Properties
        private ShippingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                return db;
            }
        }

        private Dialog.dlgFSES021_TransferInstructionDialog Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgFSES021_TransferInstructionDialog();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }


        #endregion

        #region Constructor
        public frmFSES020_TransferInstruction()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            //add by pichaya s. 20130625
            iv = new IdleValidator("tbt_PickingHeader", "UpdateDate", "ShipmentNo", "PickingNo");
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
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.GetFocusedDataRow() != null)
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();

                    //add by pichaya s. 20130625
                    if (!iv.ValidateTicket(dr["ShipmentNo"].ToString(), dr["PickingNo"].ToString()))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    //check status--
                    if (BusinessClass.TransferInstructionCheckStatus(dr["ShipmentNo"].ToString(), dr["PickingNo"].ToString(), dr["ReceivingNo"].ToString()))
                    {
                        OpenDialog(Common.eScreenMode.Edit);
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0343", shipmentControl.ShipmentNo));
                        return false;
                    }
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {

            }
        }
        public override bool OnCommandDelete()
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                if ((grdSearchResult.DefaultView).DataRowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    if (gdvSearchResult.GetFocusedRow() == null)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return false;
                    }
                    //check status--
                    if (BusinessClass.TransferInstructionCheckStatus(dr["ShipmentNo"].ToString(), dr["PickingNo"].ToString(), dr["ReceivingNo"].ToString()))
                    {
                        BusinessClass.ShipmentNo = dr["ShipmentNo"].ToString();
                        BusinessClass.PickingNo = dr["PickingNo"].ToString();
                        BusinessClass.Installment = Convert.ToInt32(dr["Installment"]);
                        BusinessClass.UpdateUser = AppConfig.UserLogin;
                        BusinessClass.TransferInstructionDelete();
                        DataLoading();
                        base.GridViewOnChangeLanguage(grdSearchResult);
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0082", shipmentControl.ShipmentNo));
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmFSES020_TransferInstruction_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                warehouseFromControl.ClearData();
                warehouseToControl.ClearData();
                ownerControl.ClearData();
                shipmentControl.ClearData();
                pickingControl.ClearData();
                receivingControl1.ClearData();
                chkUnconfirm.Checked = true;
                grdSearchResult.DataSource = null;
                //gdvSearchResult.Columns.Clear();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSearchCriteria())
                {
                    DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkUnconfirm_CheckedChanged(object sender, EventArgs e)
        {
            chkAll.Checked = !chkUnconfirm.Checked;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            chkUnconfirm.Checked = !chkAll.Checked;
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.TransferInstructionSearchAll(ownerControl.OwnerID, shipmentControl.ShipmentNo, pickingControl.PickingNo, receivingControl1.ReceivingNo, warehouseFromControl.WarehouseID, warehouseToControl.WarehouseID, (chkUnconfirm.Checked ? 0 : 1));

                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    {
                        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    }
                }

                iv.ClearTicket();

                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    iv.PushTicket(Convert.ToDateTime(gdvSearchResult.GetRowCellValue(i, "UpdateDate"))
                                 , gdvSearchResult.GetRowCellValue(i, "ShipmentNo").ToString()
                                 , gdvSearchResult.GetRowCellValue(i, "PickingNo").ToString());
                }

                if (gdvSearchResult.RowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }

                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    Dialog.IdleValidatorControl = this.iv;
                    if (ScreenMode != Common.eScreenMode.Add)
                    {
                        DataRow dr = gdvSearchResult.GetFocusedDataRow();
                        Dialog.TransferInstrunctionHeader = dr;
                    }

                    Dialog.ScreenMode = ScreenMode;

                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ShipmentNo));
                    }
                    Dialog = null;
                }

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

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseFromControl.ErrorText = Common.GetMessage("I0045");
            warehouseFromControl.RequireField = true;

            warehouseToControl.ErrorText = Common.GetMessage("I0045");
            warehouseToControl.RequireField = true;
            
            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseFromControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseToControl.ValidateControl())
            {
                validate = false;
            }

            return validate;
        }
        #endregion

    }

}