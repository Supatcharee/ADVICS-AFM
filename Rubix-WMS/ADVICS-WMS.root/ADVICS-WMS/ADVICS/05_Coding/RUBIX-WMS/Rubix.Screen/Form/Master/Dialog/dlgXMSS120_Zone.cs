using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Data.Objects;
using DevExpress.XtraGrid.Views.Grid;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS120_Zone : DialogBase, Rubix.Framework.IClearable
    {
        #region Member

        private int strZoneID;
        private bool delFlag;
        private Zone db;
        private String DefaultFloor = "1";
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Enum
        public enum eColCustomer
        {
            ZoneID,
            OwnerID,
            CustomerCode,
            CustomerName,
            CreateUser,
            CreateDate,
            UpdateUser,
            UpdateDate,
            locationFlag
        }
        #endregion

        #region Properties
        public int ZoneIDC
        {
            get { return strZoneID; }
            set { strZoneID = value; }
        }

        public Zone BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Zone();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Zone();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS120_Zone()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdCustomer };
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS120_Zone_Load(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
            //add by pichaya s. 20120411
            warehouseControl.WarehouseCode = BusinessClass.WarehouseCode;
            ownerControl.WarehouseID = Common.GetDefaultWarehouseID();
            ownerControl.DataLoading();
            grdCustomer.DataSource = null;
            gdvCustomer.Columns.Clear();
            cboZoneType.Text = "Normal";

            delFlag = false;

            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);

                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    ControlUtil.EnableControl(false, txtZoneCode, txtFloor, warehouseControl);
                }
            }

            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";

                ControlUtil.ClearControlData(txtZoneCode, txtZoneName);
                warehouseControl.ClearData();

                if (BusinessClass.ZoneCode != null)
                {
                    BusinessClass = new Zone();
                }

                txtFloor.Text = DefaultFloor;
            }
            else
            {
                DataBinding();
                ZoneIDC = BusinessClass.ZoneID;
                
            }
            //DataBindingCustomer();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            #region Old
            //DataTable temp = new DataTable();

            //if (gdvCustomer.RowCount == 0)
            //{
            //    temp.Columns.Add(eColCustomer.ZoneID.ToString());
            //    temp.Columns.Add(eColCustomer.OwnerID.ToString());
            //    temp.Columns.Add(eColCustomer.CustomerCode.ToString());
            //    temp.Columns.Add(eColCustomer.CustomerName.ToString());
            //    temp.Columns.Add(eColCustomer.CreateUser.ToString());
            //    temp.Columns.Add(eColCustomer.CreateDate.ToString());
            //    temp.Columns.Add(eColCustomer.UpdateUser.ToString());
            //    temp.Columns.Add(eColCustomer.UpdateDate.ToString());

            //    DataRow dr = temp.NewRow();
            //    dr[eColCustomer.ZoneID.ToString()] = "1";
            //    dr[eColCustomer.OwnerID.ToString()] = ownerControl.OwnerID;
            //    dr[eColCustomer.CustomerCode.ToString()] = ownerControl.GetCustomerCode;
            //    dr[eColCustomer.CustomerName.ToString()] = ownerControl.GetCustomerName;
            //    dr[eColCustomer.CreateUser.ToString()] = AppConfig.UserLogin;
            //    dr[eColCustomer.CreateDate.ToString()] = DateTime.Now.Date;
            //    dr[eColCustomer.UpdateUser.ToString()] = AppConfig.UserLogin; ;
            //    dr[eColCustomer.UpdateDate.ToString()] = DateTime.Now.Date; ;

            //    temp.Rows.Add(dr);

            //    grdCustomer.DataSource = temp;
            //}
            //else if (gdvCustomer.RowCount > 0)
            //{
            //    //if (checkGrid())
            //    //{
            //        temp = (DataTable)grdCustomer.DataSource;


            //        grdCustomer.DataSource = null;

            //        int? ZId = Convert.ToInt32(temp.Rows[temp.Rows.Count - 1][(int)eColCustomer.ZoneID].ToString());

            //        DataRow dr = temp.NewRow();
            //        if (ScreenMode == Common.eScreenMode.Add)
            //        {
            //            dr[eColCustomer.ZoneID.ToString()] = ZId + 1;
            //        }
            //        else
            //        {
            //            dr[eColCustomer.ZoneID.ToString()] = ZId;
            //        }
            //        dr[eColCustomer.OwnerID.ToString()] = ownerControl.OwnerID;
            //        dr[eColCustomer.CustomerCode.ToString()] = ownerControl.GetCustomerCode;
            //        dr[eColCustomer.CustomerName.ToString()] = ownerControl.GetCustomerName;
            //        dr[eColCustomer.CreateUser.ToString()] = AppConfig.UserLogin;
            //        dr[eColCustomer.CreateDate.ToString()] = DateTime.Now.Date;
            //        dr[eColCustomer.UpdateUser.ToString()] = AppConfig.UserLogin; ;
            //        dr[eColCustomer.UpdateDate.ToString()] = DateTime.Now.Date; ;

            //        temp.Rows.Add(dr);

            //        grdCustomer.DataSource = temp;
            //    //}
            //}
            //gdvCustomer.Columns[(int)eColCustomer.ZoneID].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.OwnerID].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.CreateDate].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.CreateUser].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.UpdateDate].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.UpdateUser].Visible = false;
            #endregion

            if (checkGrid())
            {
                gdvCustomer.AddNewRow();
                gdvCustomer.UpdateCurrentRow();
            }

        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (gdvCustomer.RowCount > 0)
            {
                delFlag = true;
                int row = gdvCustomer.GetFocusedDataSourceRowIndex();
                gdvCustomer.DeleteRow(row);
            }

        }

        private void gdvCustomer_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.ZoneID], ZoneIDC);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.OwnerID], ownerControl.OwnerID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.CustomerCode], ownerControl.OwnerCode);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.CustomerName], ownerControl.OwnerName);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.CreateUser], AppConfig.UserLogin);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.CreateDate], DateTime.Now);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.UpdateUser], AppConfig.UserLogin);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.UpdateDate], DateTime.Now);
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            ownerControl.WarehouseID = warehouseControl.WarehouseID;
            ownerControl.DataLoading();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtZoneName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistZoneCode(txtZoneCode.Text.Trim(), warehouseControl.WarehouseID, 0 /*Convert.ToInt32(txtFloor.Text)*/) && ScreenMode == Common.eScreenMode.Add)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0046"));
                            return false;
                        }
                        else
                        {
                            SavaData();
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
            ClearData();

            return base.OnCommandClear();
        }

        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            if (txtZoneCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtZoneCode, Rubix.Screen.Common.GetMessage("I0042"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtZoneCode, String.Empty);
            }
            if (txtZoneName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtZoneName, Rubix.Screen.Common.GetMessage("I0043"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtZoneName, String.Empty);
            }
            if (colorEdit1.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(colorEdit1, Rubix.Screen.Common.GetMessage("I0242"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(colorEdit1, String.Empty);
            }
            //if (txtFloor.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(txtFloor, Rubix.Screen.Common.GetMessage("I0044"));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtFloor, String.Empty);
            //}
           
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
            return errFlag;
        }

        private void DataBinding()
        {
            txtZoneCode.Text = BusinessClass.ZoneCode;
            txtZoneName.Text = BusinessClass.ZoneName;
            txtFloor.Text = Convert.ToString(BusinessClass.Floor);
            warehouseControl.WarehouseCode = BusinessClass.WarehouseCode;
            //Bind to Customer Control
            ownerControl.WarehouseID = warehouseControl.WarehouseID;
            ownerControl.DataLoading();
            colorEdit1.Text = BusinessClass.ZoneColor;
            cboZoneType.Text = BusinessClass.ZoneType == 1 ? "Normal Area" : BusinessClass.ZoneType == 2 ? "Loading Area" : BusinessClass.ZoneType == 3 ? "Port Area" : "";
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

        private void DataBindingCustomer()
        {
            #region Old
            //ObjectResult<sp_XMSS120_Zone_LoadZoneCustomer_Result> tempResult = BusinessClass.DataCustomerLoading(ZoneIDC);
            //DataTable temp = new DataTable();
            //temp.Columns.Add(eColCustomer.ZoneID.ToString());
            //temp.Columns.Add(eColCustomer.OwnerID.ToString());
            //temp.Columns.Add(eColCustomer.CustomerCode.ToString());
            //temp.Columns.Add(eColCustomer.CustomerName.ToString());
            //temp.Columns.Add(eColCustomer.CreateUser.ToString());
            //temp.Columns.Add(eColCustomer.CreateDate.ToString());
            //temp.Columns.Add(eColCustomer.UpdateUser.ToString());
            //temp.Columns.Add(eColCustomer.UpdateDate.ToString());

            //foreach (sp_XMSS120_Zone_LoadZoneCustomer_Result item in tempResult)
            //{

            //    DataRow row = temp.NewRow();

            //    row[eColCustomer.ZoneID.ToString()] = item.ZoneID;
            //    row[eColCustomer.CustomerCode.ToString()] = item.CustomerCode;
            //    row[eColCustomer.CustomerName.ToString()] = item.CustomerName;
            //    row[eColCustomer.OwnerID.ToString()] = item.OwnerID;
            //    row[eColCustomer.CreateUser.ToString()] = item.CreateUser;
            //    row[eColCustomer.CreateDate.ToString()] = item.CreateDate;
            //    row[eColCustomer.UpdateUser.ToString()] = item.UpdateUser;
            //    row[eColCustomer.UpdateDate.ToString()] = item.UpdateDate;

            //    temp.Rows.Add(row);

            //}
            #endregion

            grdCustomer.DataSource = BusinessClass.DataCustomerLoading(ZoneIDC);
            gdvCustomer.Columns[(int)eColCustomer.ZoneID].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.OwnerID].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.CreateDate].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.CreateUser].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.UpdateDate].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.UpdateUser].Visible = false;
            gdvCustomer.Columns[(int)eColCustomer.locationFlag].Visible = false;
            //gdvCustomer.Columns[(int)eColCustomer.CustomerCode].Caption = "Owner Code";
            //gdvCustomer.Columns[(int)eColCustomer.CustomerName].Caption = "Owner Name";
            

        }

        private void SavaData()
        {
            BusinessClass.ZoneCode = txtZoneCode.Text.Trim();
            BusinessClass.ZoneName = txtZoneName.Text.Trim();
            BusinessClass.Floor = 0;// Convert.ToInt32(txtFloor.Text.Trim());
            int? WarehouseID;
            BusinessClass.ZoneType = cboZoneType.Text == "Normal Area" ? 1 : cboZoneType.Text == "Loading Area" ? 2 : cboZoneType.Text == "Port Area" ? 3 : DataUtil.Convert<int>(null); //Port Area
            WarehouseID = warehouseControl.WarehouseID;
            BusinessClass.ZoneColor = Rubix.Framework.DataUtil.ToHtmlColorCode(colorEdit1.Color);//System.Drawing.ColorTranslator.ToHtml(colorEdit1.Color).Substring(1, 6);
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.UpdateUser = AppConfig.UserLogin;
            BusinessClass.SaveZoneData(WarehouseID);
            //SaveCustomerData(DistributionID);
        }
        
        private bool checkGrid()
        {
            if (ownerControl.OwnerID == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                return false;
            }
            else if (gdvCustomer.RowCount > 0)
            {
                DataRow[] dr = ((DataTable)grdCustomer.DataSource).Select(String.Format("OwnerID = {0}", ownerControl.OwnerID));

                if (dr.Length > 0)
                {
                    return false;
                }
            }
            return true;

        }    

        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.ClearControlData(txtZoneCode, txtZoneName, txtFloor);
                warehouseControl.ClearData();
                ownerControl.ClearData();
                grdCustomer.DataSource = null;
                gdvCustomer.Columns.Clear();
                colorEdit1.EditValue = null;
            }
            else
            {
                DataBinding();
                //DataBindingCustomer();
            }
        }
        #endregion      
    }
}