using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Advics.Framework;

namespace Advics.Screen
{
    public partial class formBase : Form
    {
        #region Member
        public string ClipboardData = string.Empty;
        #endregion

        #region Properties
        public PictureBox m_toolbarMainMenu { get { return btnMainMenu; } }
        public PictureBox m_toolbarBack { get { return btnBack; } }
        public PictureBox m_toolbarOK { get { return btnOK; } }
        public PictureBox m_toolbarConfirm { get { return btnConfirm; } }
        //public PictureBox m_toolbarClost { get { return btnClose; } }
        #endregion

        #region Virtual Method Must Implement by inherrited form.
        public virtual bool OnCommandOK() { return true; }
        public virtual bool OnCommandConfirm() { return true; }
        #endregion

        #region Constructor
        public formBase()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler
        private void formBase_Load(object sender, EventArgs e)
        {
            statusBar.Text = string.Format("ชื่อผู้ใช้ : {0}  |  Version : {1}", AppConfig.UserLogin, AppConfig.ProgramVersion);
            AppConfig.FormList.Add(this);
        }


        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            HomeButtonClick();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClick();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                OnCommandConfirm();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }       
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                OnCommandOK();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfig.MainMenu.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        } 
        
        private void formBase_Closed(object sender, EventArgs e)
        {
            AppConfig.MainMenu.Close();
            this.Close();
        }
        #endregion
        
        #region Generic Function
        public void HideOKConfirmButton()
        {
            //btnClose.Location = btnOK.Location;
            btnOK.Visible = false;
            btnConfirm.Visible = false;
            lbl2.Visible = false;
            //lbl3.Visible = false;
        }

        private void HomeButtonClick()
        {
            try
            {
                AppConfig.MainMenu.Show();
                AppConfig.FormList.Clear();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        public void BackButtonClick()
        {
            try
            {
                AppConfig.FormList[AppConfig.FormList.Count - 2].Show();
                AppConfig.FormList.Remove(AppConfig.FormList[AppConfig.FormList.Count - 1]);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }
        
        public bool OnKeyCommand(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (AppConfig.dialogResult != DialogResult.None)
                //{
                //    AppConfig.dialogResult = DialogResult.None;
                //    return false;
                //}
                ClipboardData = ControlUtil.GetDataFromClipboard();
                if (ClipboardData.Contains(AppConfig.HomeCommand))
                {
                    HomeButtonClick();
                    return false;
                }
                else if (ClipboardData.Contains(AppConfig.BackCommand))
                {
                    BackButtonClick();
                    return false;
                }
                else if (ClipboardData.Contains(AppConfig.ConfirmCommand))
                {
                    if (btnConfirm.Visible)
                    {
                        this.OnCommandConfirm();
                        return false;
                    }
                    else  if (btnOK.Visible)
                    {
                        this.OnCommandOK();
                        return false;
                    }
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                HomeButtonClick();
                return false;
            }
            else if (e.KeyCode == Keys.F2)
            {
                BackButtonClick();
                return false;
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (btnConfirm.Visible)
                {
                    this.OnCommandConfirm();
                    return true;
                }
                else if (btnOK.Visible)
                {
                    this.OnCommandOK();
                    return true;
                }
            }
            else if (e.KeyCode == Keys.F4)
            {

            }

            return true;
        }
        #endregion      

    }
}