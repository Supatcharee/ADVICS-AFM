using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using System.IO;
using CSI.Business.Operation;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Operation.I_Shipping.Dialog
{
    public partial class frmISHS062_DownloadAttachFileDialog : DialogBase
    {
        #region Member
        private PrintPCIDriver db;
        private PrintPCIDriver BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PrintPCIDriver();
                }
                return db;
            }
        } 
        #endregion

        #region Properties
        public string ShipmentNo
        {
            get
            {
                return txtShipmentNo.Text;
            }
            set
            {
                txtShipmentNo.Text = value;
            }
        }

        public string PickingNo
        {
            get
            {
                return txtPickingNo.Text;
            }
            set
            {
                txtPickingNo.Text = value;
            }
        } 
        #endregion

        #region Constructor
        public frmISHS062_DownloadAttachFileDialog()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear, m_toolBarSaveACopy, m_toolBarPrint);
        } 
        #endregion

        #region Event Handler
        private void frmISH062_DownloadAttachFileDialog_Load(object sender, EventArgs e)
        {
            try
            {
                grdResult.DataSource = BusinessClass.GetAttachList(txtShipmentNo.Text, txtPickingNo.Text);
                ControlUtil.SetBestWidth(gdvResult);
                gdvResult.OptionsBehavior.Editable = true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvResult.GetFocusedDataRow();

                sfdDownload.Title = "Download destination";
                sfdDownload.FileName = dr["COA_FileName"].ToString();
                if (sfdDownload.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
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
    }
}
