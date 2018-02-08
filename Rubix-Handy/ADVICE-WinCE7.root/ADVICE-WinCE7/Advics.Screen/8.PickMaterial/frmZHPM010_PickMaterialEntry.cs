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

namespace Advics.Screen.PickMaterial
{
    public partial class frmZHPM010_PickMaterialEntry : formBase
    {

         #region Member
        PickMaterialBusiness _db;
        int Flag = 1;
        #endregion

        #region Properties
        private PickMaterialBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new PickMaterialBusiness();
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
         public frmZHPM010_PickMaterialEntry()
        {
            InitializeComponent();
            txtQRCode.Focus();
        }

        #endregion

        #region Override Method

        public override bool OnCommandOK()
        {
            try
            {
                SavePickMat();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtQRCode.Text = string.Empty;
                return false;
            }
        }
        #endregion

        #region Event Handler
       
        private void frmZHPM010_PickMaterialEntry_Load(object sender, EventArgs e)
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
                        else {

                            SavePickMat();
                        }

                      
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show(ex.Message, AppConfig.Caption);
                        txtQRCode.Text = string.Empty;
                        txtQRCode.Focus();
                       
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
        private void SavePickMat()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtQRCode.Text.Trim() == string.Empty)
                {

                    MessageDialog.Show("สแกนหมายเลข RM tag ไม่ถูกต้อง", AppConfig.Caption);
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                    return;


                }

                char[] arrSplit = new char[] { ':' };
                string[] arrBarCode = txtQRCode.Text.Trim().Split(arrSplit);
                string PDSNo = arrBarCode[1].ToString();
                string RunningNo = arrBarCode[2].ToString();
                if (!CheckQRCode(PDSNo, RunningNo))
                {
                    MessageDialog.Show("Cannot Pick, this RM tag has not been transited or already picked", AppConfig.Caption);
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {

                    Database.PickMat_Save(PDSNo, RunningNo,AppConfig.UserLogin);

                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();

                }
                      
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtQRCode.Text = string.Empty;
                txtQRCode.Focus();
                
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }


        private bool CheckQRCode(string PDSNo, string RunningNo)
        {
            bool flag = false;

            flag = Database.CheckPickMat_QRCode(PDSNo, RunningNo);


            return flag;
        }
        #endregion

       
      


       

       
    }
}