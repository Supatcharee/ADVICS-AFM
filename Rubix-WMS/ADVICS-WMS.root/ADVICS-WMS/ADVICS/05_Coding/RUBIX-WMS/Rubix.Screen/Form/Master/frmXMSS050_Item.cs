using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS050_Item : FormBase
    {
        #region Member
        private Product db;
        private Dialog.dlgXMSS050_Item m_Dialog = null;
        #endregion

        #region Enumeration

        #endregion

        #region Properties
        private Product BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Product();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS050_Item Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS050_Item();
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
        public frmXMSS050_Item()
        {
            InitializeComponent();
            ownerControl.RequireField = true;
            //ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("");
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            ControlUtil.SetBestWidth(gdvSearchResult);
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS050_Item_Load(object sender, EventArgs e)
        {
            ownerControl.Focus();
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
            ClearAll();
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                }
                else
                {
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex); ;
            }
        }

        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.Column == gdcOwnerCode || e.Column == gdcOwnerName 
                    || e.Column == gdcSupplierCode || e.Column == gdcSupplierName 
                    || e.Column == gdcProductCode
                    || e.Column == gdcProductLongName || e.Column == gdcProductShortCode
                    || e.Column == gdcClassificationCode || e.Column == gdcTypeOfGoodsCode
                    || e.Column == gdcRemark || e.Column == gdcTypePallet
                    || e.Column == gdcTypeExpired || e.Column == gdcShelfLife
                    || e.Column == gdcSafetyStock || e.Column == gdcCreateDate
                    || e.Column == gdcCreateUser || e.Column == gdcUpdateDate
                    || e.Column == gdcUpdateUser || e.Column == gdcPackingTime
                    || e.Column == gdcPrepareTime || e.Column == gdcPalletizeTime
                    )
                {
                    DataRowView firstRow = (DataRowView)gdvSearchResult.GetRow(e.RowHandle1);
                    DataRowView secondRow = (DataRowView)gdvSearchResult.GetRow(e.RowHandle2);

                    if (firstRow["OwnerCode"].Equals(secondRow["OwnerCode"])
                        && firstRow["ProductCode"].Equals(secondRow["ProductCode"])
                        && firstRow["ProductShortCode"].Equals(secondRow["ProductShortCode"])
                        && firstRow["ProductLongName"].Equals(secondRow["ProductLongName"]))
                    {
                        e.Merge = true;

                    }
                    //else if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && firstRow.Status.Equals(secondRow.Status) && firstRow.Installment.Equals(secondRow.Installment) && (e.Column == gdcInstallment || e.Column == gdcArrivalDate))
                    //{
                    //    e.Merge = true;
                    //}
                    else
                        e.Merge = false;
                }
                else
                    e.Merge = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
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
        public override bool OnCommandDelete()
        {
            
            try
            {

                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                DataRow data = gdvSearchResult.GetFocusedDataRow();
                
                int ProductID = Convert.ToInt32(data["ProductID"]);

                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), data["ProductCode"])) == DialogButton.Yes)
                {
                    if (BusinessClass.CheckReference(ProductID))
                    {
                        BusinessClass.DeleteData(ProductID, AppConfig.UserLogin);
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), data["ProductCode"]));

                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0082"), "Item"));
                        return false;
                    }
                }
                return base.OnCommandDelete();
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
            //Cursor = Cursors.WaitCursor;
            try
            {

                if (ScreenMode != Common.eScreenMode.Add)
                {
                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return;
                    }

                    //sp_XMSS050_Product_SearchAll_Result data = (sp_XMSS050_Product_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                    //BusinessClass.ProductID = data.ProductID;
                    //BusinessClass.ProductCode = data.ProductCode;
                    BusinessClass.SelectedRow = gdvSearchResult.GetFocusedDataRow();
                }
                else
                {
                    BusinessClass.ProductID = null;
                }


                Dialog.ScreenMode = ScreenMode;
                Dialog.BusinessClass = BusinessClass;

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), BusinessClass.ProductCode));
                }
                Dialog = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, txtProductCode.Text.Trim(), txtProductName.Text.Trim(),supplierControl.SupplierID);
                
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
            ownerControl.ClearData();
            supplierControl.ClearData();
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            grdSearchResult.DataSource = null;
        }

        #endregion

        
    }
}
