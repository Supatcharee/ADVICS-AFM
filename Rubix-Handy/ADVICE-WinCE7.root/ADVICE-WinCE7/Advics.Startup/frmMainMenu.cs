using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;
using Advics.Screen.Receiving;
using Advics.Screen.Transit;
using Advics.Screen.Picking;
using Advics.Screen.Packing;
using BusinessLayer;
using Advics.Screen.Tracking;
using Advics.Screen.TransitAfterPack;
using Advics.Screen.PickForShip;
using Advics.Screen.PickMaterial;

namespace Advics.Startup
{
    public partial class frmMainMenu : Form
    {
        #region Member
        string strCommandKey = string.Empty;
        private LoginBusiness _db = null;
        #endregion

        #region Properties
        public frmLogin FormLogin { get; set; }
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

        #region Constructor
        public frmMainMenu()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserLogin.Text = string.Format("ชื่อผู้ใช้ : {0}", AppConfig.UserLogin);
                lblProgramVersion.Text = string.Format("Program Version : {0}", AppConfig.ProgramVersion);
                CheckMainMenuPermission();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }           
        }

        private void pnlReceiving_Click(object sender, EventArgs e)
        {
            OpenReceivingModule();
        }

        private void pnlTransit_Click(object sender, EventArgs e)
        {
            OpenTransitModule();
        }

        private void pnlPicking_Click(object sender, EventArgs e)
        {
            OpenPickingModule();
        }

        private void pnlTracking_Click(object sender, EventArgs e)
        {
            OpenTrackingModule();
        }

        private void pnlPickFS_Click(object sender, EventArgs e)
        {
            OpenPickForShipModule();
        }

        private void pnlTransitATP_Click(object sender, EventArgs e)
        {
            OpenTransitAfterPackModule();
        }

        private void pnlLogout_Click(object sender, EventArgs e)
        {
            OpenLogoutModule();
        }

        private void frmMainMenu_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {                
                if (e.KeyCode == Keys.Enter)
                {
                    if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    {
                        strCommandKey = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                    }
                    
                    if (strCommandKey.Contains(AppConfig.ReceivingCommand))
                    {
                        if (AppConfig.IsOpenReceivingModule)
                        {
                            OpenReceivingModule();
                        }
                        strCommandKey = string.Empty;
                    }
                    else if (strCommandKey.Contains(AppConfig.TransitCommand))
                    {
                        if (AppConfig.IsOpenTransitModule)
                        {
                            OpenTransitModule();
                        }
                        strCommandKey = string.Empty;
                    }
                    else if (strCommandKey.Contains(AppConfig.PickingCommand))
                    {
                        if (AppConfig.IsOpenPickingModule)
                        {
                            OpenPickingModule();
                        }
                        strCommandKey = string.Empty;
                    }
                    else if (strCommandKey.Contains(AppConfig.LogoutCommand))
                    {
                        OpenLogoutModule();
                        strCommandKey = string.Empty;
                    }
                }
                else if (e.KeyCode == Keys.NumPad1)
                {
                    if (AppConfig.IsOpenReceivingModule)
                    {
                        OpenReceivingModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad2)
                {
                    if (AppConfig.IsOpenTransitModule)
                    {
                        OpenTransitModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad3)
                {
                    if (AppConfig.IsOpenPickingModule)
                    {
                        OpenPickingModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad4)
                {
                    if (AppConfig.IsOpenTrackingModule)
                    {
                        OpenTrackingModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad5)
                {
                    if (AppConfig.IsOpenTransitAfterPackModule)
                    {
                        OpenTransitAfterPackModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad6)
                {
                    if (AppConfig.IsOpenPickForShipModule)
                    {
                        OpenPickForShipModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad7)
                {
                    if (AppConfig.IsOpenPickPackingMaterialModule)
                    {
                        OpenPickPackingMaterialModule();
                    }
                }
                else if (e.KeyCode == Keys.NumPad0)
                {
                   
                   OpenLogoutModule();
                   
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       

        private void frmMainMenu_Closed(object sender, EventArgs e)
        {
            this.Close();
            FormLogin.Close();
        }
        #endregion

        #region Generic Function
        private void AddThisScreenToList()
        {
            if (AppConfig.FormList.Exists(c => c.Text == this.Text))
            {
                AppConfig.FormList.Remove(this);
            }
            AppConfig.FormList.Add(this);
        }

        private void OpenReceivingModule()
        {
            try
            {
                frmZHRC010_ReceivingEntry frm = new frmZHRC010_ReceivingEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenTransitModule()
        {
            try
            {
                frmZHTS010_TransitEntry frm = new frmZHTS010_TransitEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenPickingModule()
        {
            try
            {
                frmZHPK010_PickingEntry frm = new frmZHPK010_PickingEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }


        private void OpenTrackingModule()
        {
            try
            {
                frmZHTK010_TrackingEntry frm = new frmZHTK010_TrackingEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenTransitAfterPackModule()
        {
            try
            {
                frmZHTP010_TransitAfterPackEntry frm = new frmZHTP010_TransitAfterPackEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenPickForShipModule()
        {
            try
            {
                frmZHPS010_PickForShipEntry frm = new frmZHPS010_PickForShipEntry();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenPickPackingMaterialModule()
        {
            try
            {
                frmZHPK040_PickingPackingMaterial frm = new frmZHPK040_PickingPackingMaterial();
                AppConfig.MainMenu = this;
                AddThisScreenToList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void OpenLogoutModule()
        {
            try
            {
                this.Hide();
                FormLogin.PerformLogin();
                FormLogin.Show();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }




        private void CheckMainMenuPermission()
        {
            DataTable dt = Database.LoadMainMenu(AppConfig.UserLogin, "Open Screen");
            if (dt.Rows.Count > 0)
            {
                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD010_Receiving' ").Length <= 0)
                {
                    pnlReceiving.Enabled = false;
                    pnlReceiving.BackColor = Color.Silver;
                    AppConfig.IsOpenReceivingModule = false;
                    lblReceiving.Text = "Receiving Confirm (N/A)";
                }
                else
                {
                    pnlReceiving.Enabled = true;
                    pnlReceiving.BackColor = Color.PaleVioletRed;
                    AppConfig.IsOpenReceivingModule = true;
                    lblReceiving.Text = "Receiving Confirm (1)";
                }

                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD020_Transit' ").Length <= 0)
                {
                    pnlTransit.Enabled = false;
                    pnlTransit.BackColor = Color.Silver;
                    AppConfig.IsOpenTransitModule = false;
                    lblTransit.Text = "Transit Confirm (N/A)";
                }
                else
                {
                    pnlTransit.Enabled = true;
                    pnlTransit.BackColor = Color.DarkCyan;
                    AppConfig.IsOpenTransitModule = true;
                    lblTransit.Text = "Transit Confirm (2)";
                }

                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD030_Picking' ").Length <= 0)
                {
                    pnlPicking.Enabled = false;
                    pnlPicking.BackColor = Color.Silver;
                    AppConfig.IsOpenPickingModule = false;
                    lblPicking.Text = "Picking Confirm (N/A)";
                }
                else
                {
                    pnlPicking.Enabled = true;
                    pnlPicking.BackColor = Color.ForestGreen;
                    AppConfig.IsOpenPickingModule = true;
                    lblPicking.Text = "Picking Confirm (3)";
                }


                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD040_Tracking' ").Length <= 0)
                {
                    pnlTracking.Enabled = false;
                    pnlTracking.BackColor = Color.Silver;
                    AppConfig.IsOpenTrackingModule = false;
                    lbTracking.Text = "QR Tracking (N/A)";
                }
                else
                {
                    pnlTracking.Enabled = true;
                    pnlTracking.BackColor = Color.Orange;
                    AppConfig.IsOpenTrackingModule = true;
                    lbTracking.Text = "QR Tracking (4)";
                }

                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD050_TransitAfterPack' ").Length <= 0)
                {
                    pnlTransitATP.Enabled = false;
                    pnlTransitATP.BackColor = Color.Silver;
                    AppConfig.IsOpenTransitAfterPackModule = false;
                    lbTransitATP.Text = "Pallet Transit (N/A)";
                }
                else
                {
                    pnlTransitATP.Enabled = true;
                    pnlTransitATP.BackColor = Color.LimeGreen;
                    AppConfig.IsOpenTransitAfterPackModule = true;
                    lbTransitATP.Text = "Pallet Transit (5)";
                }

                if (dt.Select(" ClassName = 'Rubix.Screen.Form.Handheld.frmHHD060_PickForShip' ").Length <= 0)
                {
                    
                    pnlPickFS.Enabled = false;
                    pnlPickFS.BackColor = Color.Silver;
                    AppConfig.IsOpenPickForShipModule = false;
                    lbPickFS.Text = "Pick Van (N/A)";
                }
                else
                {
                    pnlPickFS.Enabled = true;
                    pnlPickFS.BackColor = Color.SteelBlue;
                    AppConfig.IsOpenPickForShipModule = true;
                    lbPickFS.Text = "Pick Van (6)";
                }

            }
            else
            {
                pnlReceiving.Enabled = false;
                pnlReceiving.BackColor = Color.Silver;
                AppConfig.IsOpenReceivingModule = false;
                lblReceiving.Text = "Receiving Confirm (N/A)";

                pnlTransit.Enabled = false;
                pnlTransit.BackColor = Color.Silver;
                AppConfig.IsOpenTransitModule = false;
                lblTransit.Text = "Transit Confirm (N/A)";

                pnlPicking.Enabled = false;
                pnlPicking.BackColor = Color.Silver;
                AppConfig.IsOpenPickingModule = false;
                lblPicking.Text = "Picking Confirm (N/A)";


                pnlTracking.Enabled = false;
                pnlTracking.BackColor = Color.Silver;
                AppConfig.IsOpenTrackingModule = false;
                lbTracking.Text = "QR Tracking (N/A)";

                pnlTransitATP.Enabled = false;
                pnlTransitATP.BackColor = Color.Silver;
                AppConfig.IsOpenTransitAfterPackModule = false;
                lbTransitATP.Text = "Transit After Pack (N/A)";


                pnlPickFS.Enabled = false;
                pnlPickFS.BackColor = Color.Silver;
                AppConfig.IsOpenPickForShipModule = false;
                lbPickFS.Text = "Pick For Ship (N/A)";
            }
        }
        #endregion



       

        

      
       
    }
}