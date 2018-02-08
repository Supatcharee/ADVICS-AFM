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
using System.IO;

namespace Rubix.Screen.Form.Operation.D_Storing.Dialog
{
    public partial class dlgDSRS013_COADownloadDialog : DialogBase
    {
        #region Member
        private ConfirmProductStoring db;
        #endregion

        #region Properties
        public ConfirmProductStoring BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmProductStoring();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        public string ReceivingNo { get; set; }    
        #endregion

        #region Constructor
        public dlgDSRS013_COADownloadDialog()
        {
            InitializeComponent();
            this.m_statusBar.Visible = false;
            ControlUtil.HiddenControl(true, m_toolBarPrint, m_toolBarClear, m_toolBarSave, m_toolBarSaveACopy);
        } 
        #endregion

        #region Event Handler Function
        private void dlgDSRS013_COADownloadDialog_Load(object sender, EventArgs e)
        {
            try
            {
                txtReceivingNo.Text = ReceivingNo;
                grdSearchResult.DataSource = BusinessClass.LoadAllFileName(ReceivingNo);
            }
            catch (Exception ex)
            {                
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repView_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                sfdDownload.Title = "Download destination";
                sfdDownload.FileName = dr["COA_FileName"].ToString();
                if (sfdDownload.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //BusinessClass.LoadCOAFile(txtReceivingNo.Text, sfdDownload.FileName, dr["FileName"].ToString());
                    ShowWaitScreen();
                    File.WriteAllBytes(sfdDownload.FileName, BusinessClass.LoadCOAImage(Convert.ToInt32(dr["COA_ID"])));
                    System.Diagnostics.Process.Start(sfdDownload.FileName);
                    CloseWaitScreen();
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        } 
        #endregion

        #region Generic Function

        #endregion
    }
}