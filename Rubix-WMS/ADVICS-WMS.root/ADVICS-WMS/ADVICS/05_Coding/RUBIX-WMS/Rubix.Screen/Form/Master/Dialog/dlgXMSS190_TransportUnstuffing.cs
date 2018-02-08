using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Data.Objects;
using DevExpress.XtraEditors.Repository;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS190_TransportUnstuffing : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private int? tempCustomerID = 0;
        private int? tempDCID = 0;
        private DateTime? datEffectiveDate = DateTime.Now;
        private TransportCharge db;
        private Common.eScreenMode eScrenMode;
        private const string DefaultUnstaff = "Unstuffing";
        private const string DefaultUnstaffCharge = "0.0";
        private DataTable dt_DefaultEditData;
        #endregion

        #region Properties
        public TransportCharge BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TransportCharge();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new TransportCharge();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        public int? OwnerID
        {
            get { return tempCustomerID; }
            set { tempCustomerID = value; }
        }
        public int? WarehouseID
        {
            get { return tempDCID; }
            set { tempDCID = value; }
        }
        public DateTime? EffectiveDate
        {
            get { return datEffectiveDate; }
            set { datEffectiveDate = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS190_TransportUnstuffing()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS190_TransportUnstuffing_Load(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();

            ownerControl.WarehouseID = null;
            ownerControl.DataLoading();

            if (ScreenMode == Common.eScreenMode.Add && warehouseControl.WarehouseID.HasValue && ownerControl.OwnerID.HasValue)
            {
                LoadTransportCharge();
            }            

            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";

                ControlUtil.ClearControlData(dtEffectiveDate);
                warehouseControl.ClearData();
                ownerControl.ClearData();

                if (BusinessClass.OwnerCode != null)
                {
                    BusinessClass = new TransportCharge();
                }
            }
            else
            {
                DataBinding();
            }
            
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
                ownerControl.EnableControl = false;
                warehouseControl.EnableControl = false;
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    ControlUtil.EnableControl(false, dtEffectiveDate, warehouseControl, ownerControl, customerControl, truckCompanyControl);
                }
            }
        }
        
        private void gdvChargeSetting_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string final = View.GetRowCellDisplayText(e.RowHandle, View.Columns["FinalDestination"]);
                if (final == DefaultUnstaff)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }

        }

        private void truckCompanyControl1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    if (truckCompanyControl.TruckCompanyID.HasValue && customerControl.CustomerID.HasValue && ownerControl.OwnerID.HasValue)
                        LoadTransportCharge();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();

                customerControl.OwnerID = ownerControl.OwnerID;
                customerControl.DataLoading();

                if (grdChargeSetting.DataSource != null)
                {
                    grdChargeSetting.DataSource = null;
                    gdvChargeSetting.Columns.Clear();
                }
                if (truckCompanyControl.TruckCompanyID.HasValue && customerControl.CustomerID.HasValue && ownerControl.OwnerID.HasValue)
                    LoadTransportCharge();
            }
            catch (Exception ex)
            {
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    LoadTransportCharge();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void ChargeTextEdit_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void shippingCustomerControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (truckCompanyControl.TruckCompanyID.HasValue && customerControl.CustomerID.HasValue && ownerControl.OwnerID.HasValue)
                LoadTransportCharge();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistBeforeSave(ownerControl.OwnerID, warehouseControl.WarehouseID, dtEffectiveDate.DateTime, customerControl.CustomerID, truckCompanyControl.TruckCompanyID) && ScreenMode == Common.eScreenMode.Add)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0070"));
                            return false;
                        }
                        else
                        {
                            SaveData();
                            DialogResult = DialogResult.OK;
                            return true;
                        }

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandClear()
        {
            //if (ScreenMode == Common.eScreenMode.Edit)
            //{
            //    grdChargeSetting.DataSource = dt_DefaultEditData;
            //}
            //else
            //{
            //    LoadTransportCharge();
            //}
            ClearData();

            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void LoadTransportCharge()
        {
            int? iCustID;
            int? iShippingID;
            int? iTrunkID;
            if (ScreenMode == Common.eScreenMode.Add)
            {
                if (!ownerControl.OwnerID.HasValue || !customerControl.CustomerID.HasValue || !warehouseControl.WarehouseID.HasValue || !truckCompanyControl.TruckCompanyID.HasValue)
                {
                    return;
                }
                else
                {
                    iCustID = ownerControl.OwnerID;
                    iShippingID = customerControl.CustomerID;
                    iTrunkID = truckCompanyControl.TruckCompanyID;
                }
            }
            else
            {
                iCustID = BusinessClass.OwnerID;
                iShippingID = customerControl.CustomerID;
                iTrunkID = truckCompanyControl.TruckCompanyID;
            }

            DataTable temp = BusinessClass.LoadTransportCharge(iCustID, customerControl.CustomerID.Value, truckCompanyControl.TruckCompanyID.Value);

            List<String> tempColName = new List<string>();

            foreach (DataColumn item in temp.Columns)
            {
                string col = item.ColumnName;
                tempColName.Add(col);
            }

            DataRow dr = temp.NewRow();

            foreach (string item in tempColName)
            {
                if (item.Equals("FinalDestination") || item.Equals("FinalDestinationID") || item.Equals("FinalDestinationCode"))
                {
                    if (item.Equals("FinalDestination"))
                        dr[item] = DefaultUnstaff;
                    else if (item.Equals("FinalDestinationID"))
                        dr[item] = 0;
                    else
                        dr[item] = "";
                }
                else
                {
                    dr[item] = DefaultUnstaffCharge;
                }
            }

            temp.Rows.InsertAt(dr, 0);

            if (grdChargeSetting.DataSource != null)
            {
                grdChargeSetting.DataSource = null;
                gdvChargeSetting.Columns.Clear();
            }

            if (temp.Rows.Count > 0 && temp.Columns.Count > 3)
            {
                grdChargeSetting.DataSource = temp;
                SetFormatChargeColumn();

                gdvChargeSetting.Columns[0].OptionsColumn.AllowEdit = false;
                gdvChargeSetting.Columns[0].OptionsColumn.AllowFocus = false;
                gdvChargeSetting.Columns[0].Visible = false;
                gdvChargeSetting.Columns[0].OptionsColumn.ShowInCustomizationForm = false;
                gdvChargeSetting.Columns[0].OptionsColumn.ShowInExpressionEditor = false;
                gdvChargeSetting.Columns[1].OptionsColumn.AllowEdit = false;
                gdvChargeSetting.Columns[1].OptionsColumn.AllowFocus = false;
                gdvChargeSetting.Columns[2].OptionsColumn.AllowEdit = false;
                gdvChargeSetting.Columns[2].OptionsColumn.AllowFocus = false;

                gdvChargeSetting.Columns[1].Name = "gdcFinalDestinationCode";
                gdvChargeSetting.Columns[2].Name = "gdcFinalDestinationName";
                
                ControlUtil.SetBestWidth(gdvChargeSetting);

                base.GridViewOnChangeLanguage(grdChargeSetting);
            }
        }

        private void DataBinding()
        {
            try
            {
                ownerControl.OwnerCode = BusinessClass.OwnerCode;
                warehouseControl.WarehouseCode = BusinessClass.WarehouseCode;
                customerControl.CustomerID = BusinessClass.CustomerID;
                truckCompanyControl.TruckCompanyID = BusinessClass.TruckCompanyID;
                txtFuelPrice.Text = Convert.ToString(BusinessClass.FuelPrice);
                dtEffectiveDate.DateTime = BusinessClass.EffectiveDate;

                LoadTransportCharge();

                // For Grid
                DataTable dt_tempData = (DataTable)grdChargeSetting.DataSource;

                List<sp_XMSS190_TransportCharge_SearchByCondition_Result> tempList = BusinessClass.LoadDialog(BusinessClass.OwnerID, BusinessClass.WarehouseID, BusinessClass.EffectiveDate, BusinessClass.TruckCompanyID, BusinessClass.CustomerID);


                for (int i = 0; i < tempList.Count; i++)
                {

                    DataRow[] dr = dt_tempData.Select(String.Format("FinalDestinationID = {0}", tempList[i].FinalDestinationID));

                    if (dr.Length == 0)
                    {
                        continue;
                    }
                    string TransportTypeName = tempList[i].TransportTypeName;
                    if (dt_tempData.Columns.IndexOf(TransportTypeName) != -1)
                    {
                        if (tempList[i].TransportTypeName != null && tempList[i].TransportationCharge != null)
                        {
                            dr[0][TransportTypeName] = tempList[i].TransportationCharge;
                        }
                    }
                }

                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    dt_DefaultEditData = dt_tempData;
                }

                grdChargeSetting.DataSource = null;
                grdChargeSetting.DataSource = dt_tempData;
                SetFormatChargeColumn();

                if (ScreenMode == Common.eScreenMode.View)
                {
                    gdvChargeSetting.OptionsBehavior.Editable = false;

                }

                //Binding Statusbar
                m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
                if (BusinessClass.UpdateDate != null)
                {
                    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
                }
                else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
                {
                    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveData()
        {
            DataTable dt_save = ForTransporCharge();

            DataSet ds = new DataSet("TransportChargeSet");

            dt_save.TableName = "TransportChargeTable";

            ds.Tables.Add(dt_save);

            BusinessClass.OwnerID = Convert.ToInt32(dt_save.Rows[0]["OwnerID"].ToString());
            BusinessClass.WarehouseID = Convert.ToInt32(dt_save.Rows[0]["WarehouseID"].ToString());
            BusinessClass.EffectiveDate = Convert.ToDateTime(dt_save.Rows[0]["EffectiveDate"].ToString());
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.UpdateUser = AppConfig.UserLogin;
            BusinessClass.CustomerID = customerControl.CustomerID;
            BusinessClass.TruckCompanyID = truckCompanyControl.TruckCompanyID;
            if(txtFuelPrice.Text  == string.Empty)
            {
                BusinessClass.FuelPrice = null;
            }
            else
            {
                BusinessClass.FuelPrice = Convert.ToDecimal(txtFuelPrice.Text);
            }
         
            string resultXML = ds.GetXml();

            BusinessClass.SaveTransportChargeData(resultXML);
        }

        private DataTable ForTransporCharge()
        {
            //post editor before save
            gdvChargeSetting.PostEditor();

            BusinessClass.TruckCompanyID = truckCompanyControl.TruckCompanyID;
            BusinessClass.OwnerID = ownerControl.OwnerID.Value;
            BusinessClass.CustomerID = customerControl.CustomerID;

            DataTable dt_tempData = (DataTable)grdChargeSetting.DataSource;

            // Get TransportTypeID
            DataTable dt_tempTransportTypeName = GetDataTableTransportTypeID();

            // Get FinalDestination ID
            //DataTable dt_tempFinalDestinationName = GetDataTableFinalDestionationID();

            // -- For Save Data -- \\
            DataTable dt_SaveData = new DataTable();

            dt_SaveData.Columns.Add("OwnerID");
            dt_SaveData.Columns.Add("WarehouseID");
            dt_SaveData.Columns.Add("EffectiveDate");
            dt_SaveData.Columns.Add("FinalDestionationID");
            dt_SaveData.Columns.Add("TransportTypeID");
            dt_SaveData.Columns.Add("Charge");

            for (int i = 0; i < dt_tempData.Rows.Count; i++)
            {
                for (int j = 3; j < dt_tempData.Columns.Count; j++)
                {
                    DataRow dr = dt_SaveData.NewRow();
                    dr["OwnerID"] = ownerControl.OwnerID;
                    dr["WarehouseID"] = warehouseControl.WarehouseID;
                    dr["EffectiveDate"] = dtEffectiveDate.DateTime.Date.ToString("yyyy/MM/dd");
                    // Get Final Destination ID
                    //string strFinalDestinationName = dt_tempData.Rows[i][0].ToString();
                    //int tempFinalDestinationID = GetFinalDestionationID(dt_tempFinalDestinationName, strFinalDestinationName);
                    //dr["FinalDestionationID"] = tempFinalDestinationID;
                    dr["FinalDestionationID"] = dt_tempData.Rows[i][0/*FinalDestID*/].ToString(); ;
                    // Get Trasport Type ID
                    string strTransportTypeName = dt_tempData.Columns[j].ColumnName;
                    int tempTransportTypeID = GetTransportTypeID(dt_tempTransportTypeName, strTransportTypeName);
                    dr["TransportTypeID"] = tempTransportTypeID;
                    dr["Charge"] = dt_tempData.Rows[i][j];
                    dt_SaveData.Rows.Add(dr);
                }
            }

            return dt_SaveData;
        }

        private DataTable GetDataTableTransportTypeID()
        {
            DataTable dt = BusinessClass.GetTransportTypeID(string.Empty);

            return dt;

            //List<sp_XMSS190_TransportCharge_GetTransportTypeID_Result> temp = BusinessClass.GetTransportTypeID(string.Empty);

            //DataTable dt_tempTransportTypeName = new DataTable();

            //dt_tempTransportTypeName.Columns.Add("TransportTypeID");
            //dt_tempTransportTypeName.Columns.Add("TransportTypeName");

            //foreach (sp_XMSS190_TransportCharge_GetTransportTypeID_Result item in temp)
            //{
            //    DataRow dr = dt_tempTransportTypeName.NewRow();

            //    dr["TransportTypeID"] = item.TransportTypeID;
            //    dr["TransportTypeName"] = item.TransportTypeName;

            //    dt_tempTransportTypeName.Rows.Add(dr);
            //}

            //return dt_tempTransportTypeName;
            
            
        }
        
        private int GetTransportTypeID(DataTable dt, string strTransportTypeName)
        {
            int result = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TransportTypeName"].ToString().Equals(strTransportTypeName))
                {
                    result = Convert.ToInt32(dt.Rows[i]["TransportTypeID"].ToString());
                    break;
                }
            }
            return result;
        }
        
        private Boolean ValidateData()
        {
            Boolean errFlag = true;

            if (gdvChargeSetting.Columns.Count <= 3)
            {
                errFlag = false;
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0282"), Common.GetMessage("I0282"));
            }

            if (ScreenMode != Common.eScreenMode.Edit)
            {
                warehouseControl.RequireField = true;
                warehouseControl.ErrorText = Rubix.Screen.Common.GetMessage("I0045");
                if (!warehouseControl.ValidateControl())
                {
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(warehouseControl, String.Empty);
                }
            }

            if (ScreenMode != Common.eScreenMode.Edit)
            {
                customerControl.RequireField = true;
                customerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0249");
                if (!customerControl.ValidateControl())
                {
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(customerControl, String.Empty);
                }
            }

            if (ScreenMode != Common.eScreenMode.Edit)
            {
                truckCompanyControl.RequireField = true;
                truckCompanyControl.ErrorText = Rubix.Screen.Common.GetMessage("I0021");
                if (!truckCompanyControl.ValidateControl())
                {
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(truckCompanyControl, String.Empty);
                }
            }

            if (ScreenMode != Common.eScreenMode.Edit)
            {
                ownerControl.RequireField = true;
                ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
                if (!ownerControl.ValidateControl())
                {
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(ownerControl, String.Empty);
                }
            }
            if (dtEffectiveDate.EditValue == null)
            {
                errorProvider.SetError(dtEffectiveDate, Rubix.Screen.Common.GetMessage("I0071"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtEffectiveDate, String.Empty);
            }
            return errFlag;
        }
        
        public void ClearData()
        {
            errorProvider.ClearErrors();
            ControlUtil.ClearControlData(this.Controls);
            if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.ClearControlData(dtEffectiveDate);
                ownerControl.ClearData();
                warehouseControl.ClearData();
            }
            else
            {
                DataBinding();
            }
        }

        private void SetFormatChargeColumn()
        {
            for (int i = 3; i < gdvChargeSetting.Columns.Count; i++)
            {
                gdvChargeSetting.Columns[i].ColumnEdit = ChargeTextEdit;
            }
        }
        #endregion

    }
}