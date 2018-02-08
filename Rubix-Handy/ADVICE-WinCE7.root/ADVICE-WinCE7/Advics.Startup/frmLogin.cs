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
using Advics.Screen.Picking;

namespace Advics.Startup
{
    public partial class frmLogin : Form
    {
        #region Member
        private LoginBusiness _db = null;
        #endregion

        #region Properties
        private LoginBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new LoginBusiness();
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        #endregion

        #region Construnctor
        public frmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler
        private void frmLogin_Load(object sender, EventArgs e)
        {
            PerformLogin();
            lblProgramVersion.Text = string.Format("Program Version : {0}", AppConfig.ProgramVersion);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                VerifyUser();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtUsername.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtUsername.Text.Trim() != string.Empty)
                {
                    if (txtUsername.Text.Contains(AppConfig.ClearCommand))
                    {
                        txtUsername.Text = string.Empty;
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        VerifyUser();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtUsername.Text = string.Empty;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                frmSystemConfig frm = new frmSystemConfig();
                frm.FormLogin = this;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }
        #endregion

        #region Generic Function
        public void PerformLogin()
        {
            AppConfig.UserLogin = string.Empty;
            txtUsername.Text = string.Empty;
        }

        private void VerifyUser()
        {
            DataTable dt = Database.VerifyUser(txtUsername.Text.Trim().Replace("USERNAME-",""));
            if (dt.Rows.Count > 0)
            {
                AppConfig.UserLogin = txtUsername.Text.Trim().Replace("USERNAME-", "");
                frmMainMenu frm = new frmMainMenu();
                frm.FormLogin = this;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageDialog.Show("ชื่อผู้ใช้ไม่ถูกต้อง", AppConfig.Caption);
                txtUsername.Text = string.Empty;
            }
        }
        #endregion
    }
}