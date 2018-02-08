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
    public partial class frmZHTK022_DetailsTagStatus2 : formBase
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

        public string PDSNo,  RunningNo,  Status,  Location,  TransitDate,  TransitBy;
        #endregion


        #region Constructor
        public frmZHTK022_DetailsTagStatus2()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarConfirm);
            ControlUtil.HiddenControl(true, m_toolbarOK);
        }
        #endregion

        #region Event handler
        private void frmZHTK022_DetailsTagStatus2_Load(object sender, EventArgs e)
        {
            InitialData();
        }

        private void frmZHTK022_DetailsTagStatus2_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }

        #endregion

        #region Generic function
        private void InitialData()
        {
            lblPDSno.Text = PDSNo;
            lblRunningno.Text = RunningNo;
            lblStatus.Text = Status;
            lblLocation.Text = Location;
            lblTransitdate.Text = TransitDate;
            lblTransitby.Text = TransitBy;
        }
        #endregion

       

    }
}