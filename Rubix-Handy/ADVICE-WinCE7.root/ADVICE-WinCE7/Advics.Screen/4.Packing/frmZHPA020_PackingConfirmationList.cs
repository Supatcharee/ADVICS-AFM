using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Advics.Screen.Packing
{
    public partial class frmZHPA020_PackingConfirmationList : formBase
    {
        #region Member

        #endregion

        #region Properties
        public DateTime PackingDate { get; set; }
        #endregion

        #region Constructor
        public frmZHPA020_PackingConfirmationList()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Override Method

        #endregion

        #region Event Handler
        private void frmZHPA020_PackingConfirmationList_Load(object sender, EventArgs e)
        {
            try
            {
                base.HideOKConfirmButton();
                lblDeliveryDate.Text = PackingDate.ToString("dd/MM/yyyy");

                DataTable dt = new DataTable();
                dt.Columns.Add("ShippingNo", typeof(string));
                dt.Columns.Add("PackingNo", typeof(string));
                dt.Columns.Add("Customer", typeof(string));
                dt.Columns.Add("Address", typeof(string));

                DataRow dr;
                dr = dt.NewRow();
                dr["ShippingNo"] = "ADVICS-SH140101001";
                dr["PackingNo"] = "ADVICS-PK140101001";
                dr["Customer"] = "Customer001";
                dr["Address"] = "Address001";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ShippingNo"] = "ADVICS-SH140101002";
                dr["PackingNo"] = "ADVICS-PK140101002";
                dr["Customer"] = "Customer002";
                dr["Address"] = "Address002";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ShippingNo"] = "ADVICS-SH140101003";
                dr["PackingNo"] = "ADVICS-PK140101003";
                dr["Customer"] = "Customer003";
                dr["Address"] = "Address003";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ShippingNo"] = "ADVICS-SH140101004";
                dr["PackingNo"] = "ADVICS-PK140101004";
                dr["Customer"] = "Customer004";
                dr["Address"] = "Address004";
                dt.Rows.Add(dr);

                grdResult.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmZHPA030_PackingConfirmaionDetail frm = new frmZHPA030_PackingConfirmaionDetail();
                frm.ShippingNo = grdResult[grdResult.CurrentRowIndex, 0].ToString();
                frm.PackingNo = grdResult[grdResult.CurrentRowIndex, 1].ToString();
                frm.ShippingDate = this.PackingDate;
                frm.Show();
                this.Hide();
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