using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.Master;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master
{   
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS070_FinalDestination : FormBase
    {
        #region Member
        private FinalDestination db;
        private Dialog.dlgXMSS070_FinalDestination m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
                 FinalDestinationID
				,OwnerID
				,CustomerCode
                ,ShippingCode
				,FinalDestinationCode
				,FinalDestinationLongName
				,FinalDestinationAddress
				,FinalDestinationDetail
				,ContactName1
				,ContactName2
				,ContactName3
				,City
				,StateOrProvince
				,Country
				,PhoneNo
				,Extension
				,FaxNo
				,PostalCode
				,KM
				,Remark
				,MobileNo
				,LeadTimeDays
				,LeadTimeHr
				,DeleteFlag
				,CreateDate
				,CreateUser
				,UpdateDate
				,UpdateUser
                ,CustomerID
                ,MapFileName
                
        }
        #endregion

        #region Properties
        private FinalDestination BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new FinalDestination();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS070_FinalDestination Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS070_FinalDestination();
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
        public frmXMSS070_FinalDestination()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        }
        #endregion

        #region Event Handler Function
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
            ControlUtil.ClearControlData(txtFinalDesCode, txtFinalDesName );
            grdSearchResult.DataSource = null;
            customerControl.ClearData();
            ownerControl.ClearData();
            //gdvSearchResult.Columns.Clear();
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            customerControl.OwnerID = ownerControl.OwnerID;
            customerControl.DataLoading();
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
                if ((grdSearchResult.DefaultView).DataRowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.FinalDestinationLongName)) == DialogButton.Yes)
                    {
                        if (BusinessClass.IsSystem == false)
                        {
                            if (BusinessClass.CheckReference(BusinessClass.FinalDestinationID) == 0) // Check Reference before Delete : Add by Chalermchai C. // 04/25/2012
                            {
                                BusinessClass.DeleteCustomerData();
                                DataLoading();
                                MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.FinalDestinationLongName));
                            }
                            else
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Final Destination"));
                                return false;
                            } 
                        }
                        else
                            MessageDialog.ShowBusinessErrorMsg(this, String.Format(Common.GetMessage("I0082"), "This"));
                       
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
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.FinalDestinationLongName));
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(FinalDestinationCode: txtFinalDesCode.Text.Trim(), FinalDestinationName: txtFinalDesName.Text.Trim(), OwnerID: ownerControl.OwnerID, shippingCustomerID: customerControl.CustomerID);
                
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
        #endregion      
    }
}