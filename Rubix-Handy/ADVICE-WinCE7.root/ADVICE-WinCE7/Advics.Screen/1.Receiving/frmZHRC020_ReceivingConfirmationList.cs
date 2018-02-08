using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;
using BusinessLayer;

namespace Advics.Screen.Receiving
{
    public partial class frmZHRC020_ReceivingConfirmationList : formBase
    {
        #region Member
        ReceivingBusiness _db;
        #endregion

        #region Properties
        public DateTime ReceivingDate { get; set; }
        public DataTable dtReceivingData { get; set; }
        private ReceivingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new ReceivingBusiness();
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
        public frmZHRC020_ReceivingConfirmationList()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler
        private void frmZHRC020_ReceivingConfirmationList_Load(object sender, EventArgs e)
        {
            try
            {
                base.HideOKConfirmButton();
                lblReceivingDate.Text = ReceivingDate.ToString("dd/MM/yyyy");
                dtReceivingData.TableName = "DataTableData";
                grdResult.DataSource = dtReceivingData;
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        } 

        private void grdResult_DoubleClick(object sender, EventArgs e)
        {
            SelectReceivingNo();
        }

        private void grdResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectReceivingNo();
                }
            }
        }
        #endregion
                
        #region Generic Function
        private void SelectReceivingNo()
        {
            try
            {
                DataSet ds = Database.ReceivingEntry_SearchBy_ReceivingNo(grdResult[grdResult.CurrentRowIndex, 0].ToString(), 1);
                if (ds.Tables.Count != 3 ||
                            ds.Tables[0].Rows.Count <= 0 ||
                            ds.Tables[1].Rows.Count <= 0 ||
                            ds.Tables[2].Rows.Count <= 0)
                {
                    MessageDialog.Show("ไม่พบหมายเลขใบรับนี้ หรือ หมายเลขใบรับนี้ได้ทำการรับไปแล้ว", AppConfig.Caption);
                    return;
                }

                frmZHRC030_ReceivingConfirmationDetail frm = new frmZHRC030_ReceivingConfirmationDetail();
                frm.dsReceiving = ds;
                frm.CallFromScreen = 2;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }
        #endregion
    }
}