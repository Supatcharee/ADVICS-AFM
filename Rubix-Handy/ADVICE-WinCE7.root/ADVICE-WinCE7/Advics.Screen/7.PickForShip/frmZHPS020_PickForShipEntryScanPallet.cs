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

namespace Advics.Screen.PickForShip
{
    public partial class frmZHPS020_PickForShipEntryScanPallet : formBase
    {
        #region Member
        PickForShipBusiness _db;
        DataSet _DetailDS;
        #endregion

        #region Properties
        private PickForShipBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new PickForShipBusiness();
                }
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public DataSet DetailDS
        {
            get { return _DetailDS; }
            set { _DetailDS = value; }
        }
        #endregion 

        #region Constructor
        public frmZHPS020_PickForShipEntryScanPallet()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
        }
        #endregion

        #region Event Handler

        private void frmZHPS020_PickForShipEntryScanPallet_Load(object sender, EventArgs e)
        {
            lblShipmentNo.Text = DetailDS.Tables[0].Rows[0]["ShipmentNo"].ToString();
            lblContainerNo.Text = DetailDS.Tables[0].Rows[0]["ContainerNo"].ToString();
            DataTable dt = DetailDS.Tables[1].Copy();
            dt.TableName = "DataTableData";
            grdResult.DataSource = dt;
            txtPalletNo.Text = string.Empty;
            txtPalletNo.Focus();
        }

        private void txtPalletNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (txtPalletNo.Text.Trim() == "")
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        if (!CheckPalletNo())
                        {
                            MessageDialog.Show("สแกนหมายเลข Pallet No ไม่ถูกต้อง", AppConfig.Caption);
                            txtPalletNo.Text = string.Empty;
                            txtPalletNo.Focus();
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        else
                        {
                            SaveUpdatePickShip();
                            frmZHPS010_PickForShipEntry frm = new frmZHPS010_PickForShipEntry();
                            AppConfig.FormList.Add(AppConfig.MainMenu);
                            frm.Show();
                            this.Dispose();
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show(ex.Message, AppConfig.Caption);
                        txtPalletNo.Text = string.Empty;
                        Cursor.Current = Cursors.Default;
                    }
                }

            }

        }

        #endregion

        #region Generic Function

        private bool CheckPalletNo()
        {
            bool flag = false;
            if (txtPalletNo.Text.Trim() != "")
            {
                flag = Database.PickShip_CheckPalletOrLocation(txtPalletNo.Text.Trim(), "");
            }
            DataRow[] dr = DetailDS.Tables[1].Select("PalletNo = '" + txtPalletNo.Text + "'");
            if (dr.Length == 0)
            {
                flag = false;
            }

            return flag;
        }

        private void SaveUpdatePickShip()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Database.CaseMarkPickAndPack(txtPalletNo.Text.Trim(), AppConfig.UserLogin);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        #endregion

    }
}