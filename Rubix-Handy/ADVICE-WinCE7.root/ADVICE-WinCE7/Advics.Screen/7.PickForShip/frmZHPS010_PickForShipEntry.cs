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
using System.Globalization;

namespace Advics.Screen.PickForShip
{
    public partial class frmZHPS010_PickForShipEntry : formBase
    {
       
        #region Member
        PickForShipBusiness _db;
        int Flag = 1;
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
        #endregion

        #region Constructor
       
        public frmZHPS010_PickForShipEntry()
        {
            InitializeComponent();
            base.HideOKConfirmButton();
            txtQRCode.Focus();
        }

        

        #endregion

        #region Override Method

        #endregion

        #region Event Handler
       
        private void frmZHPS010_PickForShipEntry_Load(object sender, EventArgs e)
        {
            txtQRCode.Text = string.Empty;
        }

        private void txtQRCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (txtQRCode.Text.Trim() == "")
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        string[] QRSplit = txtQRCode.Text.Split(':');

                        if (QRSplit.Length != 4)
                        {
                            MessageDialog.Show("สแกนหมายเลข QRCode ไม่ถูกต้อง", AppConfig.Caption);
                            txtQRCode.Text = string.Empty;
                            txtQRCode.Focus();
                            return;
                        }
                        else
                        {
                            if (DateTime.ParseExact(QRSplit[3], "yyyy/mm/dd", CultureInfo.InvariantCulture) == null)
                            {
                                MessageDialog.Show("ไม่สามารถอ่านค่า Packing Date ได้", AppConfig.Caption);
                                txtQRCode.Text = string.Empty;
                                txtQRCode.Focus();
                                return;
                            }
                            DateTime PackingDate = DateTime.ParseExact(QRSplit[3], "yyyy/mm/dd", CultureInfo.InvariantCulture);
                            DataSet ds = Database.PickingPalletEntry_SearchBy_ContainerNo(QRSplit[1], QRSplit[2], QRSplit[3]);
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    frmZHPS020_PickForShipEntryScanPallet frm = new frmZHPS020_PickForShipEntryScanPallet();
                                    frm.DetailDS = ds;
                                    txtQRCode.Text = string.Empty;
                                    txtQRCode.Focus();
                                    frm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageDialog.Show("ไม่มี Pallet ที่ทำการ Pick มาก่อน", AppConfig.Caption);
                                    txtQRCode.Text = string.Empty;
                                    txtQRCode.Focus();
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show(ex.Message, AppConfig.Caption);
                        txtQRCode.Text = string.Empty;
                        txtQRCode.Focus();
                        Cursor.Current = Cursors.Default;
                    }
                    finally 
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }

        }

       
        #endregion

        #region Generic Function
        

        #endregion

      

      
    }
}