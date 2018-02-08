using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Common;
using CSI.Business;
using CSI.Business.DataObjects;
using Rubix.Framework;
using System.Data.Objects;

namespace Rubix.Control
{
    public partial class UserInfoControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member
        private User db;
        //add by pichaya s. 20120411
        private List<sp_common_LoadUser_Result> _list = null;
        #endregion

        #region Properties
        private User BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new User();
                }
                return db;
            }
        }

        private List<sp_common_LoadUser_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading().ToList<sp_common_LoadUser_Result>();
                return _list;
            }
        }
        public String GetUserID
        {
            get
            {
                try
                {
                    if (cboUser.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadUser_Result)(GridSearch.GetFocusedRow())).UserID;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }       
        public String GetName
        {
            get
            {
                try
                {
                    if (cboUser.Text.Trim() == String.Empty)
                        return null;
                    return ((sp_common_LoadUser_Result)(GridSearch.GetFocusedRow())).Name;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        //add by pichaya s. 20120411
        public String SetUserID
        {
            set
            {
                sp_common_LoadUser_Result data = this.Datasource.SingleOrDefault(c => c.UserID.Equals(value, StringComparison.OrdinalIgnoreCase));
                if (data != null)
                {
                    cboUser.EditValue = value;
                    txtName.Text = data.Name;
                }
            }
        }

        public void Reset()
        {
            cboUser.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboUser); }
        }
        #endregion
        
        #region Constructor
        public UserInfoControl()
        {
            InitializeComponent();
            DataLoading();
        }
        #endregion

        #region Event Handler Function
        private void UserInfoControl_Load(object sender, EventArgs e)
        {
            ControlUtil.EnableControl(false, txtName);
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            txtName.Text = (cboUser.Text.Trim() == String.Empty ? String.Empty : GetName);
        }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    cboUser.Properties.DisplayMember = "UserID";
                    cboUser.Properties.ValueMember = "Name";
                    gdcUserID.FieldName = "UserID";
                    gdcName.FieldName = "Name";
                    //modify by pichaya s. 20120411
                    _list = BusinessClass.DataLoading().ToList<sp_common_LoadUser_Result>();
                    cboUser.Properties.DataSource = Datasource;
                    txtName.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion      
    }
}
