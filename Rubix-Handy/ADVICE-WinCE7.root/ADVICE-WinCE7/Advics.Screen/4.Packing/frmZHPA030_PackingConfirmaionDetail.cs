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
    public partial class frmZHPA030_PackingConfirmaionDetail : formBase
    {
        #region Member

        #endregion

        #region Properties
        public string ShippingNo { get; set; }
        public string PackingNo { get; set; }
        public DateTime ShippingDate { get; set; }
        #endregion

        #region Constructor
        public frmZHPA030_PackingConfirmaionDetail()
        {
            InitializeComponent();            
        }
        #endregion

        #region Override Method
        public override bool OnCommandOK()
        {
            try
            {
                frmZHPA040_PackagingMaterialConfirmation frm = new frmZHPA040_PackagingMaterialConfirmation();
                frm.Show();
                this.Hide();
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
        private void frmZHPA030_PackingConfirmaionDetail_Load(object sender, EventArgs e)
        {
            try
            {
                lblShippingNo.Text = ShippingNo;
                lblPackingNo.Text = PackingNo;
                lblPickingDate.Text = ShippingDate.ToString("dd/MM/yyyy");

                DataTable dt = new DataTable();
                dt.Columns.Add("RMTagNo", typeof(string));
                dt.Columns.Add("ProductCode", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("ActualQTY", typeof(decimal));
                dt.Columns.Add("RemainQTY", typeof(decimal));

                DataRow dr;
                dr = dt.NewRow();
                dr["RMTagNo"] = "ADVICS-RM140101001";
                dr["ProductCode"] = "132040-40470";
                dr["ProductName"] = "Cylinder Assy, Brake Master, L/Reservoir";
                dr["ActualQTY"] = 0;
                dr["RemainQTY"] = 10000;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["RMTagNo"] = "ADVICS-RM140101002";
                dr["ProductCode"] = "132040-40500";
                dr["ProductName"] = "Cylinder Assy, Brake Master, L/Reservoir";
                dr["ActualQTY"] = 0;
                dr["RemainQTY"] = 500;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["RMTagNo"] = "ADVICS-RM140101003";
                dr["ProductCode"] = "132040-40770";
                dr["ProductName"] = "Cylinder Assy, Brake Master, L/Reservoir";
                dr["ActualQTY"] = 0;
                dr["RemainQTY"] = 2900;
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