using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;

namespace Advics.Screen.Packing
{
    public partial class frmZHPA040_PackagingMaterialConfirmation : formBase
    { 
        #region Member

        #endregion

        #region Properties
        public string ReceivingNo {get; set;}
        public string SupplierName{get; set;}
        #endregion
        
        #region Constructor
        public frmZHPA040_PackagingMaterialConfirmation()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarOK);
            ControlUtil.HiddenControl(false, m_toolbarConfirm);
        }
        #endregion

        #region Override Method
        public override bool OnCommandConfirm()
        {
            try
            {
                MessageBox.Show("ทำรายการเรียบร้อย");
                AppConfig.MainMenu.Show();
                AppConfig.FormList.Clear();
                this.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmZHPA040_PackagingMaterialConfirmation_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RMTagNo", typeof(string));
                dt.Columns.Add("ProductCode", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("MaterialType", typeof(string));
                dt.Columns.Add("QTY", typeof(decimal));

                DataRow dr;
                dr = dt.NewRow();
                dr["RMTagNo"] = "";
                dr["ProductCode"] = "COVER-73";
                dr["ProductName"] = "Cover-73";
                dr["MaterialType"] = "Cover";
                dr["QTY"] = 0;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["RMTagNo"] = "";
                dr["ProductCode"] = "SVE-73";
                dr["ProductName"] = "Sleeve-73";
                dr["MaterialType"] = "Sleeve";
                dr["QTY"] = 0;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["RMTagNo"] = "";
                dr["ProductCode"] = "PALLET-73";
                dr["ProductName"] = "Pallet-73";
                dr["MaterialType"] = "Pallet";
                dr["QTY"] = 0;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["RMTagNo"] = "";
                dr["ProductCode"] = "YA039-00102-00";
                dr["ProductName"] = "PE Bag";
                dr["MaterialType"] = "Caton Box";
                dr["QTY"] = 0;
                dt.Rows.Add(dr);

                grdResult.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Generic Function

        #endregion
    }
}