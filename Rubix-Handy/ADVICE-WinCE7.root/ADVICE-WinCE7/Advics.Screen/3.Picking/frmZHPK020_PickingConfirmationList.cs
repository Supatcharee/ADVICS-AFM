using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using Advics.Framework;

namespace Advics.Screen.Picking
{
    public partial class frmZHPK020_PickingConfirmationList : formBase
    {
        #region Member
        PickingBusiness _db;
        #endregion

        #region Properties
        public DateTime PickingDate { get; set; }
        public DataTable dtPicking { get; set; }
        private PickingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new PickingBusiness();
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        #endregion

        #region Constructor
        public frmZHPK020_PickingConfirmationList()
        {
            InitializeComponent();
        }
        #endregion

        #region Override Method

        #endregion

        #region Event Handler
        private void frmZHPK020_PickingConfirmationList_Load(object sender, EventArgs e)
        {
            try
            {
                base.HideOKConfirmButton();
                lblPickingDate.Text = PickingDate.ToString("dd/MM/yyyy");
                dtPicking.TableName = "DataTableData";
                grdResult.DataSource = dtPicking;
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void grdResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Database.PickingEntry_SearchBy_PickingNo(grdResult[grdResult.CurrentRowIndex, 0].ToString(), 1);
                if (ds.Tables.Count != 2)
                {
                    MessageDialog.Show("ไม่พบหมายเลขใบหยิบนี้", AppConfig.Caption);
                    return;
                }

                frmZHPK030_PickingConfirmationDetail frm = new frmZHPK030_PickingConfirmationDetail();
                frm.dsPicking = ds;
                frm.CallFromScreen = 2;
                frm.PickingDate = PickingDate;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void grdResult_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }
        #endregion
        
        #region Generic Function

        #endregion
    }
}