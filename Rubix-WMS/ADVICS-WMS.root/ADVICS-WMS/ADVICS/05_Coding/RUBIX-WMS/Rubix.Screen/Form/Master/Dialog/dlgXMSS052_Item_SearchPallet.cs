using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using CSI.Business.Master;
using CSI.Business.BusinessFactory.Master;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS052_Item_SearchPallet : SubDialogBase
    {
        Pallet _db = null;
        public String PalletCode    { get; set; }
        public String PalletName    { get; set; }
        public decimal Length       { get; set; }
        public decimal Width        { get; set; }
        public decimal Height       { get; set; }
        public decimal M3           { get; set; }

        public Pallet BusinessClass
        {
            get
            {
                if (_db == null)
                    _db = new Pallet();
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public dlgXMSS052_Item_SearchPallet()
        {
            InitializeComponent();
        }

        public override bool OnCommandOK()
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                PalletCode = dr["PalletCode"].ToString();
                PalletName = dr["PalletName"].ToString();
                Length = Convert.ToDecimal(dr["Length"]);
                Width = Convert.ToDecimal(dr["Width"]);
                Height = Convert.ToDecimal(dr["Height"]);
                M3 = Convert.ToDecimal(dr["M3"]);
                DialogResult = DialogResult.OK;
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
            
        }

        private void dlgXMSS052_Item_SearchPallet_Load(object sender, EventArgs e)
        {
            grdSearchResult.DataSource = BusinessClass.DataLoading(null, null);
        }

        private void gdvSearchResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                PalletCode = dr["PalletCode"].ToString();
                PalletName = dr["PalletName"].ToString();
                Length = Convert.ToDecimal(dr["Length"]);
                Width = Convert.ToDecimal(dr["Width"]);
                Height = Convert.ToDecimal(dr["Height"]);
                M3 = Convert.ToDecimal(dr["M3"]);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}