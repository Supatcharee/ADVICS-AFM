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

namespace Advics.Screen.Tracking
{
    public partial class frmZHTK025_DetailsTagOut : formBase
    {


        #region Member
        private TrackingBusiness _db;
        #endregion

        #region Properties
        private TrackingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new TrackingBusiness();
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public string PalletNo, PackDate;
        public DataTable dtRmtagShip;
        #endregion

        #region Constructor
        public frmZHTK025_DetailsTagOut()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
            ControlUtil.HiddenControl(true, m_toolbarOK);
        }

        #endregion

        #region Event handler
        private void frmZHTK025_DetailsTagOut_Load(object sender, EventArgs e)
        {
            InitialData();
        }

        private void frmZHTK025_DetailsTagOut_KeyUp(object sender, KeyEventArgs e)
        {
            //base.OnKeyCommand(e);
        }

        private void grdResult_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }
        #endregion

        #region Generic function
        private void InitialData()
        {

            lblPalletno.Text = PalletNo;
            lbPackDate.Text = PackDate;


            dtRmtagShip.TableName = "DataTableData";
            grdResult.DataSource = dtRmtagShip;
            if (dtRmtagShip.Rows.Count == 0)
            {
                grdResult.Visible = false;
            }
          
        }
        #endregion

       

       

       

       
    }
}