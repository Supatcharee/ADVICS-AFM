using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advics.Framework;
using BusinessLayer;

namespace Advics.Screen.Tracking
{
    public partial class frmZHTK010_TrackingEntry : formBase
    {
       
        #region Member
        TrackingBusiness _db;
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
        #endregion

        #region Constructor
        public frmZHTK010_TrackingEntry()
        {
            InitializeComponent();
            //ControlUtil.HiddenControl(true, m_toolbarConfirm);
            //base.HideOKConfirmButton();
            txtQRCode.Focus();
        }
        #endregion

        #region Override Method

        public override bool OnCommandOK()
        {
            try
            {
                openDetails();
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
        private void frmZHTK010_TrackingEntry_Load(object sender, EventArgs e)
        {
            txtQRCode.Text = string.Empty;

        }

        private void txtQRCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (base.OnKeyCommand(e))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (txtQRCode.Text.Trim() == "")
                    {
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    openDetails();
                }
            }

        }

        #endregion
                       
        #region Generic Function
        private void openDetails()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtQRCode.Text.Trim() == string.Empty)
                {

                    MessageDialog.Show("สแกนหมายเลข QRCode ไม่ถูกต้อง", AppConfig.Caption);
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;

                 
                }

                char[] arrSplit = new char[] { ':' };
                string[] arrBarCode = txtQRCode.Text.Trim().Split(arrSplit);
                if (arrBarCode.Length == 8 || arrBarCode.Length == 6 || arrBarCode.Length == 1)
                {

                }
                else {

                    MessageDialog.Show("สแกนหมายเลข QRCode ไม่ถูกต้อง", AppConfig.Caption);
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }



                DataSet ds = Database.Tracking_Search(txtQRCode.Text.Trim());
                if (ds.Tables.Count <=0 )
                {
                    MessageDialog.Show("สแกนหมายเลข QRCode ไม่ถูกต้อง", AppConfig.Caption);
                    txtQRCode.Text = string.Empty;
                    txtQRCode.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else {

                    string TagType = ds.Tables[0].Rows[0]["TagType"].ToString().Trim().ToUpper();

                    if (TagType == "RMTAGRECEIVE")
                    {
                       
                        string Status = ds.Tables[2].Rows[0]["Status"].ToString().Trim().ToUpper();
                        string PDSNo = ds.Tables[1].Rows[0]["PDSNo"].ToString();
                        string RunningNo = ds.Tables[1].Rows[0]["RunningNo"].ToString();

                        if (Status == "NOT RECEIVED")
                        {
                            OpenTagStatus0(PDSNo,RunningNo,Status);
                            txtQRCode.Text = string.Empty;
                        }
                        else if (Status == "RECEIVED")
                        {
                            string RevNo = ds.Tables[3].Rows[0]["InformationKey"].ToString();
                            string RevDate ;
                            if (ds.Tables[3].Rows[0]["InformationDate"] != DBNull.Value)
                            {
                                RevDate = ds.Tables[3].Rows[0]["InformationDate"].ToString();
                            }
                            else
                            {
                                RevDate = "-";
                            }
                            string RevBy = ds.Tables[3].Rows[0]["InformationUser"].ToString();
                            OpenTagStatus1(PDSNo, RunningNo, Status, RevNo,RevDate, RevBy);
                            txtQRCode.Text = string.Empty;
                        }
                        else if (Status == "TRANSIT")
                        {
                            string Location = ds.Tables[3].Rows[0]["InformationKey"].ToString();
                            string TransitDate;
                            if (ds.Tables[3].Rows[0]["InformationDate"] != DBNull.Value)
                            {
                                TransitDate = ds.Tables[3].Rows[0]["InformationDate"].ToString();
                            }
                            else
                            {
                                TransitDate = "-";
                            }
                            string TransitBy = ds.Tables[3].Rows[0]["InformationUser"].ToString();
                            OpenTagStatus2(PDSNo, RunningNo, Status, Location, TransitDate, TransitBy);
                            txtQRCode.Text = string.Empty;
                        }
                        else if (Status == "PICKED")
                        {
                            string PalletNo = ds.Tables[3].Rows[0]["InformationKey"].ToString();
                            string PickDate;
                            if (ds.Tables[3].Rows[0]["InformationDate"] != DBNull.Value)
                            {
                                PickDate = ds.Tables[3].Rows[0]["InformationDate"].ToString();
                            }
                            else
                            {
                                PickDate = "-";
                            }
                            string PickBy = ds.Tables[3].Rows[0]["InformationUser"].ToString();
                            OpenTagStatus3(PDSNo, RunningNo, Status, PalletNo, PickDate, PickBy);
                            txtQRCode.Text = string.Empty;
                        }
                        else if (Status == "PACKED")
                        {
                            string PalletNo = ds.Tables[3].Rows[0]["InformationKey"].ToString();
                            string PackDate;
                            if (ds.Tables[3].Rows[0]["InformationDate"] != DBNull.Value)
                            {
                                PackDate = ds.Tables[3].Rows[0]["InformationDate"].ToString();
                            }
                            else
                            {
                                PackDate = "-";
                            }
                            string PackBy = ds.Tables[3].Rows[0]["InformationUser"].ToString();
                            OpenTagStatus4(PDSNo, RunningNo, Status, PalletNo, PackDate, PackBy);
                            txtQRCode.Text = string.Empty;
                        }
                    }
                    else if(TagType == "RMTAGSHIP")
                    {
                        string PalletNo = ds.Tables[1].Rows[0]["PalletNo"].ToString();
                        string PackDate;
                        if (ds.Tables[1].Rows[0]["InfoDate"] != DBNull.Value)
                        {
                            PackDate = ds.Tables[1].Rows[0]["InfoDate"].ToString();
                        }
                        else
                        {
                            PackDate = "-";
                        }
                        DataTable dtRmtagShip = ds.Tables[2];
                        OpenTagOut(PalletNo, PackDate,dtRmtagShip);
                        txtQRCode.Text = string.Empty;
                    }
                    else if (TagType == "CASE MARK")
                    {
                        string PalletNo = ds.Tables[1].Rows[0]["PalletNo"].ToString();
                        string VanningDate;
                        if (ds.Tables[1].Rows[0]["InfoDate"] != DBNull.Value)
                        {
                            VanningDate = ds.Tables[1].Rows[0]["InfoDate"].ToString();
                        }
                        else
                        {
                            VanningDate = "-";
                        }
                        string InfoStatus = ds.Tables[1].Rows[0]["InfoStatus"].ToString();
                        string InfoLocation = ds.Tables[1].Rows[0]["InfoLocation"].ToString();
                        DataTable dtCaseMark = ds.Tables[2];
                        OpenCaseMark(PalletNo, VanningDate, dtCaseMark, InfoStatus,InfoLocation);
                        txtQRCode.Text = string.Empty;
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

        private void OpenCaseMark(string PalletNo, string VanningDate, DataTable dtCaseMark, string Status, string Location)
        {
            try
            {
                frmZHTK026_DetailsCaseMark frm = new frmZHTK026_DetailsCaseMark();

                frm.PalletNo = PalletNo;
                frm.VanningDate = VanningDate;
                frm.dtCaseMark = dtCaseMark;
                frm.Status = Status;
                frm.Location = Location;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagOut(string PalletNo, string PackDate, DataTable dtRmtagShip)
        {
            try
            {
                frmZHTK025_DetailsTagOut frm = new frmZHTK025_DetailsTagOut();

                frm.PalletNo = PalletNo;
                frm.PackDate = PackDate;
                frm.dtRmtagShip = dtRmtagShip;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagStatus4(string PDSNo, string RunningNo, string Status, string PalletNo, string PackDate, string PackBy)
        {
            try
            {
                frmZHTK024_DetailsTagStatus4 frm = new frmZHTK024_DetailsTagStatus4();

                frm.PDSNo = PDSNo;
                frm.RunningNo = RunningNo;
                frm.Status = Status;
                frm.PalletNo = PalletNo;
                frm.PackDate = PackDate;
                frm.PackBy = PackBy;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagStatus3(string PDSNo, string RunningNo, string Status, string PalletNo, string PickDate, string PickBy)
        {
            try
            {
                frmZHTK023_DetailsTagStatus3 frm = new frmZHTK023_DetailsTagStatus3();

                frm.PDSNo = PDSNo;
                frm.RunningNo = RunningNo;
                frm.Status = Status;
                frm.PalletNo = PalletNo;
                frm.PickDate = PickDate;
                frm.PickBy = PickBy;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagStatus2(string PDSNo, string RunningNo, string Status, string Location, string TransitDate, string TransitBy)
        {
            try
            {
                frmZHTK022_DetailsTagStatus2 frm = new frmZHTK022_DetailsTagStatus2();

                frm.PDSNo = PDSNo;
                frm.RunningNo = RunningNo;
                frm.Status = Status;
                frm.Location = Location;
                frm.TransitDate = TransitDate;
                frm.TransitBy = TransitBy;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagStatus1(string PDSNo, string RunningNo, string Status, string RevNo,string RevDate, string RevBy)
        {
            try
            {
                frmZHTK021_DetailsTagStatus1 frm = new frmZHTK021_DetailsTagStatus1();

                frm.PDSNo = PDSNo;
                frm.RunningNo = RunningNo;
                frm.Status = Status;
                frm.RevNo = RevNo;
                frm.RevDate = RevDate;
                frm.RevBy = RevBy;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenTagStatus0(string PDSNo, string RunningNo, string Status)
        {
            try
            {
                frmZHTK020_DetailsTagStatus0 frm = new frmZHTK020_DetailsTagStatus0();

                frm.PDSNo = PDSNo;
                frm.RunningNo = RunningNo;
                frm.Status = Status;
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

      
    }
}