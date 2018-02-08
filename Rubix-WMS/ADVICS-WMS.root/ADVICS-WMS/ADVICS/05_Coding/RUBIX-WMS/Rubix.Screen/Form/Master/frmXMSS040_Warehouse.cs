/*
 20121224:
 * 1. Modify add paramter for UpdateUser on Delete mode
 */
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
using DevExpress.Utils;
namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS040_Warehouse : FormBase
    {
        #region Member
        private Warehouse db;
        private Dialog.dlgXMSS040_Warehouse m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
            OwnerID,
            WarehouseID,
            WarehouseCode,
            WarehouseName,
            PhoneNo,
            Extension,
            Mobile,
            FaxNo,
            Address1,
            Address2,
            Division,
            ContactName1,
            ContactName2,
            ContactName3,
            MaxM3,
			MaxM2,
			MaxPallet,
			MaxCapacity,
			NoOfForklift,
			ManPower,
            InChargeEmail,
			Remark,
            CreateDate,
            CreateUser,
            UpdateDate,
            UpdateUser
            
					
        }
        #endregion

        #region Properties
        private Warehouse BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Warehouse();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS040_Warehouse Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS040_Warehouse();
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
        public frmXMSS040_Warehouse()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS040_Warehouse_Load(object sender, EventArgs e)
        {

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

                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(txtWarehouseCode, txtWarehouseName);
            ownerControl.ClearData();
            grdSearchResult.DataSource = null;
            //gdvSearchResult.Columns.Clear();
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
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
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
        public override bool OnCommandDelete()
        {
            try
            {
                BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.WarehouseName)) == DialogButton.Yes)
                {
                    // 20121224: Modify add paramter for UpdateUser
                    //BusinessClass.DeleteDistributionCenterData();
                    if (BusinessClass.CheckReference(BusinessClass.WarehouseID) == 1)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0258"));
                        return false;
                    }

                    BusinessClass.DeleteWarehouseData(AppConfig.UserLogin);
                    //end 20121224
                    DataLoading();
                    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"),BusinessClass.WarehouseName));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Function
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
                    if (ScreenMode != Common.eScreenMode.Add)
                    {
                        BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    }
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.BusinessClass = BusinessClass;
                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.WarehouseName));
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

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                List<sp_XMSS040_Warehouse_SearchAll_Result> result = BusinessClass.DataLoading(ownerControl.OwnerID, txtWarehouseCode.Text.Trim(), txtWarehouseName.Text.Trim());
                
                if (result == null)
                {
                    ClearAll();
                    MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0014"));
                }
                else
                {
                    grdSearchResult.DataSource = result;
                    //for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                    //{
                    //    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    //    {
                    //        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                    //        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    //    }
                    //}
                    //ControlUtil.SetBestWidth(gdvSearchResult);
                    ////gdvSearchResult.Columns[(int)eColDetail.OwnerID].Visible = false;
                    //gdvSearchResult.Columns[((int)eColDetail.MaxM3)-1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.MaxM3)-1].DisplayFormat.FormatString = "#,###.#####";
                    //gdvSearchResult.Columns[((int)eColDetail.MaxM2) - 1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.MaxM2) - 1].DisplayFormat.FormatString = "#,###.##";
                    //gdvSearchResult.Columns[((int)eColDetail.MaxPallet) - 1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.MaxPallet) - 1].DisplayFormat.FormatString = "#,###.##";
                    //gdvSearchResult.Columns[((int)eColDetail.MaxCapacity) - 1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.MaxCapacity) - 1].DisplayFormat.FormatString = "#,###.##";
                    //gdvSearchResult.Columns[((int)eColDetail.ManPower) - 1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.ManPower) - 1].DisplayFormat.FormatString = "#,###";
                    //gdvSearchResult.Columns[((int)eColDetail.NoOfForklift) - 1].DisplayFormat.FormatType = FormatType.Numeric;
                    //gdvSearchResult.Columns[((int)eColDetail.NoOfForklift) - 1].DisplayFormat.FormatString = "#,###";
                    //ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColDetail.OwnerID);
                }

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

        private void ClearAll()
        {
            try
            {
                grdSearchResult.DataSource = null;
                txtWarehouseCode.Text = "";
                txtWarehouseName.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ex.ToString());
            }
        }
        #endregion

       
    }
}