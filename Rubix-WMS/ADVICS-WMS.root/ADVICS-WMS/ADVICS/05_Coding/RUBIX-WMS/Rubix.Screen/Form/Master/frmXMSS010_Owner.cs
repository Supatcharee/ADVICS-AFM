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
    public partial class frmXMSS010_Owner : FormBase
    {
        #region Member
        private Owner db;
        private Dialog.dlgXMSS010_Owner m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
             OwnerID
			,CustomerCode
			,CustomerName
			,BusinessType
			,CustomerAddress
			,City
			,StateOrProvince
			,PostalCode
			,Country
			,PhoneNo
			,Extension
			,MobileNo
			,FaxNo
			,EmailAddress
			,ContactName1
			,ContactName2
			,ContactName3
            ,DefaultReceivingDateType
			,CreateDate
			,CreateUser
			,UpdateDate
			,UpdateUser
        }
        #endregion

        #region Properties
        private Owner BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Owner();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS010_Owner Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS010_Owner();
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
        public frmXMSS010_Owner()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[]{grdSearchResult};
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        } 
        #endregion

        #region Event Handler Function
        private void frmXMSS010_Owner_Load(object sender, EventArgs e)
        {
            grdSearchResult.DataSource = null;
            base.GridViewOnChangeLanguage(grdSearchResult);
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
            ControlUtil.ClearControlData(txtOwnerCode, txtOwnerName );
            grdSearchResult.DataSource = null;
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
        public override bool  OnCommandDelete()
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
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"),BusinessClass.OwnerName)) == DialogButton.Yes)
                    {
                        if (BusinessClass.CheckReference(BusinessClass.OwnerID) == 0) // Check Reference before Delete
                        {
                            BusinessClass.DeleteOwnerData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.OwnerName));
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Owner"));
                            return false;
                        }
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
                       MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.OwnerName));
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(txtOwnerCode.Text.Trim(), txtOwnerName.Text.Trim());
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