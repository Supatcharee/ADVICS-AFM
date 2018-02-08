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

namespace Advics.Screen.Receiving
{
    public partial class frmZHRC030_ReceivingConfirmationDetail : formBase
    {
        #region Member
        ReceivingBusiness _db;
        private DataTable dtRMTagReceive = new DataTable();
        #endregion

        #region Properties
        public DataSet dsReceiving {get; set;}
        public int CallFromScreen { get; set; }
        public DateTime ReceivingDate { get; set; }
        private ReceivingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new ReceivingBusiness();
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
        public frmZHRC030_ReceivingConfirmationDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolbarOK);
            ControlUtil.HiddenControl(false, m_toolbarConfirm);
        } 
        #endregion

        #region Override Method
        public override bool OnCommandConfirm()
        {
            try
            {
                return ConfirmReceiving();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtRMTag.Text = string.Empty;
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmZHRC030_ReceivingConfirmationDetail_Load(object sender, EventArgs e)
        {
            try
            {
                InitialData();
                txtRMTag.Focus();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                txtRMTag.Text = string.Empty;
            }
        } 

        private void txtRMTag_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (base.OnKeyCommand(e))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        if (txtRMTag.Text.Trim() == string.Empty)
                        {
                            return;
                        }

                        char[] arrSplit = new char[] { ':' };
                        string[] arrBarCode = txtRMTag.Text.Trim().Split(arrSplit);
                        //0 = PO No.
                        //1 = PDS No.
                        //2 = Running No. --> 00001
                        //3 = Supplier Code
                        //4 = Item No.
                        //5 = Item Short Code
                        //6 = Qty level 3
                        //7 = Collect Date
                        if (arrBarCode.Length != 8)
                        {
                            MessageDialog.Show("หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                            txtRMTag.Text = string.Empty;
                            return;
                        }

                        DataRow[] dr;
                        DataRow[] dr1;

                        if (arrBarCode[2].Length == 11)
                        {
                            //MessageDialog.Show("Case Length 11",AppConfig.Caption);
                            string[] running = arrBarCode[2].Split('-');

                            dr = dsReceiving.Tables[2].Select(string.Format("ProductCode = '{0}' AND RunningNo >= {1} AND RunningNo <= {2} AND PDSNo = '{3}'  AND TagStatus = 0", arrBarCode[4], Convert.ToInt32(running[0]), Convert.ToInt32(running[1]), arrBarCode[1]));
                            //MessageDialog.Show("Select 1", AppConfig.Caption);
                            if (dr.Length <= 0)
                            {
                                MessageDialog.Show("ER001 : หมายเลข R/M กับ PDSNo ไม่ตรงกัน", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }
                            //MessageDialog.Show("if 1", AppConfig.Caption);
                            if (Convert.ToInt32(dr[0]["Qty"]) != Convert.ToInt32(Convert.ToDecimal(arrBarCode[6])))
                            {
                                MessageDialog.Show("ER002 : หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }
                            //MessageDialog.Show("if 2", AppConfig.Caption);
                            
                            dr1 = dsReceiving.Tables[1].Select(string.Format("ProductID = '{0}' ", dr[0]["ProductID"]));
                            //MessageDialog.Show("Select 2", AppConfig.Caption);
                            for (int i = 0; i < dr.Length; i++)
                            {
                                //MessageDialog.Show("for " + i, AppConfig.Caption);
                                if (dr1.Length <= 0)
                                {
                                    MessageDialog.Show("ER003 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                    txtRMTag.Text = string.Empty;
                                    return;
                                }
                                else
                                {
                                    dr[i]["TagStatus"] = 1;
                                    dr1[0]["ActualQty"] = Convert.ToInt32(dr1[0]["ActualQty"]) + Convert.ToInt32(dr[i]["Qty"]);
                                    dr1[0]["LocationID"] = dr[i]["LocationID"];
                                    dr1[0]["RemainQty"] = Convert.ToInt32(dr1[0]["RemainQty"]) - Convert.ToInt32(dr[i]["Qty"]);
                                    AddRMTagData(dr[0]["PDSNo"].ToString(), dr[i]["RunningNo"].ToString());
                                }
                            }
                        }
                        else
                        {
                            dr = dsReceiving.Tables[2].Select(string.Format("ProductCode = '{0}' AND RunningNo = '{1}'  AND PDSNo = '{2}'  AND TagStatus = 0", arrBarCode[4], arrBarCode[2], arrBarCode[1]));
                            if (dr.Length <= 0)
                            {
                                MessageDialog.Show("ER004 : หมายเลข R/M กับ PDSNo ไม่ตรงกัน", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }

                            if (Convert.ToInt32(dr[0]["Qty"]) != Convert.ToInt32(Convert.ToDecimal(arrBarCode[6])))
                            {
                                MessageDialog.Show("ER005 : หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }

                            dr[0]["TagStatus"] = 1;
                            dr1 = dsReceiving.Tables[1].Select(string.Format("ProductID = '{0}' ", dr[0]["ProductID"]));
                            if (dr1.Length <= 0)
                            {
                                MessageDialog.Show("ER006 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }
                            else
                            {
                                dr1[0]["ActualQty"] = Convert.ToInt32(dr1[0]["ActualQty"]) + Convert.ToInt32(dr[0]["Qty"]);
                                dr1[0]["LocationID"] = dr[0]["LocationID"];
                                dr1[0]["RemainQty"] = Convert.ToInt32(dr1[0]["RemainQty"]) - Convert.ToInt32(dr[0]["Qty"]);
                                AddRMTagData(dr[0]["PDSNo"].ToString(), dr[0]["RunningNo"].ToString());
                            }
                        }
                        txtRMTag.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message,   AppConfig.Caption);
                txtRMTag.Text = string.Empty;
            }
            finally
            {
                
                Cursor.Current = Cursors.Default;
            }
        }

        private void grdResult_KeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyCommand(e);
        }
        #endregion

        #region Generic Function
        private void InitialData()
        {
            lblReceivingNo.Text = dsReceiving.Tables[0].Rows[0]["ReceivingNo"].ToString();
            lblReceivingDate.Text = dsReceiving.Tables[0].Rows[0]["ReceiveDateDisplay"].ToString();
            lblSupplier.Text = dsReceiving.Tables[0].Rows[0]["SupplierLongName"].ToString();
            dsReceiving.Tables[1].TableName = "DataTableData";
            dsReceiving.Tables[1].AcceptChanges();
            grdResult.DataSource = dsReceiving.Tables[1];
            ReceivingDate = Convert.ToDateTime(dsReceiving.Tables[0].Rows[0]["ReceiveDate"]);

            dtRMTagReceive.Columns.Add("PDSNo", typeof(string));
            dtRMTagReceive.Columns.Add("RunningNo", typeof(string));
        }

        private void AddRMTagData(string PDSNo, string RunningNo)
        {
            DataRow dr = dtRMTagReceive.NewRow();
            dr["PDSNo"] = PDSNo;
            dr["RunningNo"] = RunningNo;
            dtRMTagReceive.Rows.Add(dr);
        }

        private bool ConfirmReceiving()
        {
            DataRow[] drUpdate = dsReceiving.Tables[1].Select("", "", DataViewRowState.ModifiedCurrent);

            if (drUpdate.Length > 0)
            {
                foreach (DataRow dr in drUpdate.CopyToDataTable().Rows)
                {
                    Database.ReceivingConfirmDetail_Save(dr["ReceivingNo"].ToString()
                                                         , Convert.ToInt16(dr["Installment"])
                                                         , Convert.ToInt32(dr["ProductID"])
                                                         , Convert.ToDecimal(dr["ActualQty"])
                                                         , Convert.ToInt32(dr["LocationID"]));
                }

                Database.ReceivingConfirmDetail_RMTagSave(lblReceivingNo.Text, chkIsCompleteFlag.Checked ? 1 : 0, dtRMTagReceive);

                if (CallFromScreen == 2)
                {
                    DataTable dt = Database.ReceivingEntry_SearchBy_ReceivingDate(ReceivingDate.ToString("yyyy/MM/dd"), AppConfig.UserLogin);
                    if (dt.Rows.Count <= 0)
                    {
                        AppConfig.FormList.Clear();
                        frmZHRC010_ReceivingEntry frm = new frmZHRC010_ReceivingEntry();
                        AppConfig.FormList.Add(AppConfig.MainMenu);
                        frm.Show();
                        this.Dispose();
                    }
                    else
                    {
                        frmZHRC020_ReceivingConfirmationList frm = new frmZHRC020_ReceivingConfirmationList();
                        frm.ReceivingDate = ReceivingDate;
                        frm.dtReceivingData = dt;
                        AppConfig.FormList.Add(AppConfig.MainMenu);
                        frm.Show();
                        this.Dispose();
                    }
                }
                else
                {
                    AppConfig.FormList.Clear();
                    frmZHRC010_ReceivingEntry frm = new frmZHRC010_ReceivingEntry();
                    AppConfig.FormList.Add(AppConfig.MainMenu);
                    frm.Show();
                    this.Dispose();
                }
                return true;
            }
            else
            {
                MessageDialog.Show("ไม่มีข้อมูลให้ทำการรับสินค้า", AppConfig.Caption);
                txtRMTag.Text = string.Empty;
                return false;
            }
        }
        #endregion
    }
}