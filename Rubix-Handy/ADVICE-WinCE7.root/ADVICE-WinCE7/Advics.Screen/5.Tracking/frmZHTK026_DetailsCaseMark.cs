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
    public partial class frmZHTK026_DetailsCaseMark : formBase
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

        public string PalletNo, VanningDate, Status, Location;
        public DataTable dtCaseMark;
        #endregion

        #region Constructor  
        public frmZHTK026_DetailsCaseMark()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
            ControlUtil.HiddenControl(true, m_toolbarOK);
        }

        #endregion

        #region Event handler
        private void frmZHTK026_DetailsCaseMark_Load(object sender, EventArgs e)
        {
            InitialData();
        }
        private void frmZHTK026_DetailsCaseMark_KeyUp(object sender, KeyEventArgs e)
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
            lbVanningDate.Text = VanningDate;
            lblStatus.Text = Status;
            lblLocation.Text = Location;

            dtCaseMark.TableName = "DataTableData";
            grdResult.DataSource = dtCaseMark;
            if (dtCaseMark.Rows.Count == 0)
            {
                grdResult.Visible = false;
            }
        }

        #endregion

       

       

       
       
    }
}