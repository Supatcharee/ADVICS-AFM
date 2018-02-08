using System;
using System.Collections.Generic;
using System.Data;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Linq;
namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    public partial class dlgKPK011_PackingArragement : DialogBase
    {
        #region Member
        private ShippingInstruction db_control;
        private PackingInstruction db;
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode { get; set; }
        public DataRow SelecedDataRow { get; set; }
        public ShippingInstruction SIBusinessClass
        {
            get
            {
                if (db_control == null)
                {
                    db_control = new ShippingInstruction();
                }
                return db_control;
            }
            set
            {
                if (db_control == null)
                {
                    db_control = new ShippingInstruction();
                }
                db_control = value;
            }
        }
        public PackingInstruction BusinessClass
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
        #endregion

        #region Constructor
        public dlgKPK011_PackingArragement()
        {
            InitializeComponent();          
        } 
        #endregion

        #region Override Method
        public override bool  OnCommandSave()
        {
            try
            {
                ShowWaitScreen();
                BusinessClass.PackingArragementSaveDetail(txtPackingPlanNo.Text, txtHeaderRemark.Text, DataUtil.Convert<decimal>(txtTotalWeight.Text), DataUtil.Convert<decimal>(txtTotalGrossWeight.Text), DataUtil.Convert<decimal>(txtTotalMeasurement.Text), (grdShippingInstruction.DataSource as DataTable).Copy());
                DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        public override bool OnCommandClear()
        {
            try
            {
                ShowWaitScreen();
                DataBinding();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler Function
        private void dlgKPK011_PackingArragement_Load(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                    ControlUtil.EnableControl(false, this.Controls);
                    //ControlUtil.HiddenControl(true, btnUpdate, btnOK,btnCancel);                    
                }
                else
                {
                    ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                    ControlUtil.EnableControl(false, this.Controls);
                    ControlUtil.EnableControl(true, btnUpdate, btnOK, btnCancel, txtHeaderRemark, txtTotalGrossWeight, txtTotalMeasurement, txtTotalWeight);
                    //ControlUtil.HiddenControl(false, btnUpdate);
                }
                ownerControl.EnableControl = false;
                warehouseControl.EnableControl = false;
                ControlUtil.HiddenControl(true, btnOK, btnCancel);
                DataBinding();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void portOfLoading_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAddressPortLoading.Text = portOfLoading.GetPortAddress;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void portOfDischarge_EditValueChanged(object sender, EventArgs e)
        {            
            try
            {
                txtAddressPortDischarge.Text = portOfDischarge.GetPortAddress;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void finalDestinationControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (finalDestinationControl.GetFinalDestinationID.HasValue)
                {
                    sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result finalInfo = SIBusinessClass.LoadFinalDesInfo(finalDestinationControl.GetFinalDestinationID.Value);
                    txtFinalAddress.EditValue = finalInfo.FinalDestinationAddress;
                    txtPhone.EditValue = finalInfo.PhoneNo;
                    txtExt.EditValue = finalInfo.Extension;
                    txtMobile.EditValue = finalInfo.MobileNo;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvShippingInstruction.RowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    DataRow dr = gdvShippingInstruction.GetFocusedDataRow();
                     if (dr != null)
                     {

                         itemControl.ProductID = DataUtil.Convert<int>(dr["ProductID"]);
                         txtQty.EditValue = dr["PlanQty"];
                         cboQtyUnit.EditValue = dr["UnitOfPlanQty"];
                         itemConditionControl.ProductConditionID = DataUtil.Convert<int>(dr["ProductConditionID"]);
                         txtDetailRemark.Text = dr["DetailRemark"].ToString();

                         txtGrossWeight.EditValue = dr["GrossWeight"];
                         txtMeasure.EditValue = dr["M3"];
                         txtNetWeight.EditValue = dr["Weight"];

                         ControlUtil.EnableControl(true, txtGrossWeight, txtMeasure, txtNetWeight);

                         ControlUtil.HiddenControl(true, btnUpdate);
                         ControlUtil.HiddenControl(false, btnOK, btnCancel);

                         grdShippingInstruction.Enabled = false;
                     }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataRow dr = gdvShippingInstruction.GetFocusedDataRow();
                    if (dr != null)
                    {
                        dr["GrossWeight"] = txtGrossWeight.EditValue;
                        dr["M3"] = txtMeasure.EditValue;
                        dr["Weight"] = txtNetWeight.EditValue;
                    }
                    grdShippingInstruction.Enabled = true;
                    ControlUtil.EnableControl(false, txtGrossWeight, txtMeasure, txtNetWeight);
                    ControlUtil.ClearControlData(txtGrossWeight, txtMeasure, txtNetWeight);
                    CalculateTotal();
                    ControlUtil.HiddenControl(false, btnUpdate);
                    ControlUtil.HiddenControl(true, btnOK, btnCancel);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                grdShippingInstruction.Enabled = true;
                ControlUtil.EnableControl(false, txtGrossWeight, txtMeasure, txtNetWeight);
                ControlUtil.ClearControlData(txtGrossWeight, txtMeasure, txtNetWeight);

                CalculateTotal();
                ControlUtil.HiddenControl(false, btnUpdate);
                ControlUtil.HiddenControl(true, btnOK, btnCancel);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        #endregion

        #region Generic Function
        private void DataBinding()
        {
            if (this.ScreenMode != Common.eScreenMode.Add)
            {
                DataSet ds = BusinessClass.PackingArragementSearchDetail(SelecedDataRow["ShipmentNo"].ToString()
                                                                        , SelecedDataRow["PackingNo"].ToString());
                DataTable dtHeader = ds.Tables[0];
                DataTable dtDetail = ds.Tables[1];
                
                //HEADER
                txtStatus.Text = dtHeader.Rows[0]["StatusName"].ToString();
                ownerControl.OwnerID = DataUtil.Convert<int>(dtHeader.Rows[0]["OwnerID"]);
                customerControl.CustomerID = DataUtil.Convert<int>(dtHeader.Rows[0]["CustomerID"]);
                warehouseControl.WarehouseID = DataUtil.Convert<int>(dtHeader.Rows[0]["WarehouseID"]);
                shippingAreaControl.ShippingAreaID = DataUtil.Convert<int>(dtHeader.Rows[0]["ShippingAreaID"]);
                shipmentControl.ShipmentNo = dtHeader.Rows[0]["ShipmentNo"].ToString();
                txtPackingPlanNo.Text = dtHeader.Rows[0]["PackingNo"].ToString();
                dtPackingPlan.EditValue = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["PackingDatePlan"]);
                txtPackingTimePlan.Text = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["PackingDatePlan"]) == null ? string.Empty : Convert.ToDateTime(dtHeader.Rows[0]["PackingDatePlan"]).ToString("HH:mm");
                dtPackingActual.EditValue = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["PackingDateActual"]);
                txtPackingTimeActual.Text = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["PackingDateActual"]) == null ? string.Empty : Convert.ToDateTime(dtHeader.Rows[0]["PackingDateActual"]).ToString("HH:mm");
                txtPalletNo.Text = dtHeader.Rows[0]["PalletNo"].ToString();
                txtPickingNo.Text = dtHeader.Rows[0]["PickingNo"].ToString();
                dtTransportDate.EditValue = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["TransportationDate"]);
                txtTransportTime.Text = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["TransportationDate"]) == null ? string.Empty : Convert.ToDateTime(dtHeader.Rows[0]["TransportationDate"]).ToString("HH:mm");
                dtDeliveryDate.EditValue = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["DeliveryDate"]);
                txtDeliveryTime.Text = DataUtil.Convert<DateTime>(dtHeader.Rows[0]["DeliveryDate"]) == null ? string.Empty : Convert.ToDateTime(dtHeader.Rows[0]["DeliveryDate"]).ToString("HH:mm");
                txtTotalWeight.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["TotalWeight"].ToString());
                txtTotalGrossWeight.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["TotalGrossWeight"].ToString());
                txtTotalMeasurement.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["TotalM3"].ToString());
                portOfLoading.PortID = DataUtil.Convert<int>(dtHeader.Rows[0]["PortOfLoadingID"]);
                portOfDischarge.PortID = DataUtil.Convert<int>(dtHeader.Rows[0]["PortOfDischargeID"]);
                finalDestinationControl.FinalDestinationID = DataUtil.Convert<int>(dtHeader.Rows[0]["FinalDestinationID"]);
                txtHeaderRemark.Text = dtHeader.Rows[0]["Remark"].ToString();

                ////////////////////////////////////////////////////////////
                m_statusBarCreatedDate.Caption = Convert.ToDateTime(dtHeader.Rows[0]["CreateDate"]).ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = dtHeader.Rows[0]["CreateUser"].ToString();
                if (dtHeader.Rows[0]["UpdateDate"] != DBNull.Value)
                {
                    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(dtHeader.Rows[0]["UpdateDate"]).ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = dtHeader.Rows[0]["UpdateUser"].ToString();
                }
                else if (dtHeader.Rows[0]["UpdateDate"] != DBNull.Value && ScreenMode == Common.eScreenMode.Edit)
                {
                    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                }
                ////////////////////////////////////////////////////////////
                //DETAIL
                grdShippingInstruction.DataSource = dtDetail;
                base.GridViewOnChangeLanguage(grdShippingInstruction);
            }

        }

        private bool ValidateData()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            if (string.IsNullOrEmpty(txtGrossWeight.Text) || Convert.ToDouble(txtGrossWeight.EditValue) <= 0.0)
            {
                errorProvider.SetError(txtGrossWeight, Common.GetMessage("I0407"));
                validate = false;
            }
            if (string.IsNullOrEmpty(txtNetWeight.Text) || Convert.ToDouble(txtNetWeight.EditValue) <= 0.0)
            {
                errorProvider.SetError(txtNetWeight, Common.GetMessage("I0406"));
                validate = false;
            }
            if (string.IsNullOrEmpty(txtMeasure.Text) || Convert.ToDouble(txtMeasure.EditValue) <= 0.0)
            {
                errorProvider.SetError(txtMeasure, Common.GetMessage("I0408"));
                validate = false;
            }
            return validate;
        }

        private void CalculateTotal()
        {
            DataTable dt = grdShippingInstruction.DataSource as DataTable;
            txtTotalWeight.EditValue = dt.Compute("Sum(Weight)", "");
            txtTotalGrossWeight.EditValue = dt.Compute("Sum(GrossWeight)", "");
            txtTotalMeasurement.EditValue = dt.Compute("Sum(M3)", "");
        }
        #endregion       

        
    }
}