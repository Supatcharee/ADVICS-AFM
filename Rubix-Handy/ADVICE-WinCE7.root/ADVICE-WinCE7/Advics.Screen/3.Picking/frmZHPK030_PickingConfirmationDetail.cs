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

namespace Advics.Screen.Picking
{
    public partial class frmZHPK030_PickingConfirmationDetail : formBase
    {
        #region Member
        PickingBusiness _db;
        private DataTable dtRMTagReceive = new DataTable();
        #endregion

        #region Properties
        public DataSet dsPicking { get; set; }
        public int CallFromScreen { get; set; }
        public DateTime PickingDate { get; set; }
        private PickingBusiness Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new PickingBusiness();
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
        public frmZHPK030_PickingConfirmationDetail()
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
                return ConfirmPicking();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmZHPK030_PickingConfirmationDetail_Load(object sender, EventArgs e)
        {
            try
            {
                InitialData();
                txtRMTag.Focus();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
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
                            MessageDialog.Show("ERR 1 : หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                            txtRMTag.Text = string.Empty;
                            return;
                        }

                        DataRow[] dr;
                        DataRow[] dr1;
                        DataRow[] itemFilter;
                        Boolean itemMatchFlag;

                        if (arrBarCode[2].Length == 11)
                        {
                            string[] running = arrBarCode[2].Split('-');
                            //int iStatrRunning =  Convert.ToInt32(dsPicking.Tables[2].Compute(" MIN(RunningNo)", string.Empty)); // dsPicking.Tables[2].Select(.Rows[0]["RunningNo"].ToString();
                            itemFilter = dsPicking.Tables[2].Select(string.Format("TagStatus = 2 AND PDSNo = '{0}'", arrBarCode[1]));

                            itemMatchFlag = false;
                            for (int i = 0; i < itemFilter.Length; i++)
                            {
                                
                                if ( Convert.ToInt32(itemFilter[i]["RunningNo"]) == Convert.ToInt32(running[0]) )
                                {
                                    itemMatchFlag = true;
                                    break;
                                }
                            }
                            
                            //if (iStatrRunning != Convert.ToInt32(running[0]))
                            if (itemMatchFlag == false)
                            {
                                MessageDialog.Show("ERR 2 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;     
                            }

                            for (int i = Convert.ToInt32(running[0]); i <= Convert.ToInt32(running[1]); i++)
                            {

                                dr = dsPicking.Tables[2].Select(string.Format("ProductCode = '{0}' AND RunningNo = '{1}' AND TagStatus = 2 AND PDSNo = '{2}'", arrBarCode[4], i.ToString().PadLeft(5, '0'), arrBarCode[1]));

                                if (dr.Length <= 0)
                                {
                                    MessageDialog.Show("ERR 3 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                    txtRMTag.Text = string.Empty;
                                    return;     
                                }
                                
                                dr1 = dsPicking.Tables[1].Select(string.Format("ProductID = '{0}' ", dr[0]["ProductID"]));

                                if (Convert.ToInt32(dr1[0]["PickingQty"]) >= Convert.ToInt32(dr1[0]["PlanPickingQty"]))
                                {
                                    MessageDialog.Show("ERR 4 : ไม่สามารถหยิบเกินแผนได้", AppConfig.Caption);
                                    txtRMTag.Text = string.Empty;
                                    return;                                   
                                }

                                if (Convert.ToInt32(dr[0]["Qty"]) != Convert.ToInt32(Convert.ToDecimal(arrBarCode[6])))
                                {
                                    MessageDialog.Show("ERR 5 : หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                                    txtRMTag.Text = string.Empty;
                                    return;
                                }

                                dr[0]["TagStatus"] = 3;
                                
                                if (dr1.Length <= 0)
                                {
                                    MessageDialog.Show("ERR 6 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                    txtRMTag.Text = string.Empty;
                                    return;
                                }
                                else
                                {
                                    dr1[0]["PickingQty"] = Convert.ToInt32(dr1[0]["PickingQty"]) + Convert.ToInt32(dr[0]["Qty"]);
                                    dr1[0]["LocationID"] = dr[0]["LocationID"];
                                    txtRMTag.Text = string.Empty;
                                    AddRMTagData(dr[0]["PDSNo"].ToString(), dr[0]["RunningNo"].ToString(), Convert.ToInt32(dr[0]["ProductID"]));
                                }
                            }
                        }
                        else
                        {
                            dr = dsPicking.Tables[2].Select(string.Format("ProductCode = '{0}' AND RunningNo = '{1}' AND TagStatus = 2 AND PDSNo = '{2}'", arrBarCode[4], arrBarCode[2], arrBarCode[1]));
                            if (dr.Length <= 0)
                            {
                                MessageDialog.Show("ERR 7 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }

                            if (Convert.ToInt32(dr[0]["Qty"]) != Convert.ToInt32(Convert.ToDecimal(arrBarCode[6])))
                            {
                                MessageDialog.Show("ERR 8 : หมายเลข R/M ไม่ถูกต้อง", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }

                            dr1 = dsPicking.Tables[1].Select(string.Format("ProductID = '{0}' ", dr[0]["ProductID"]));
                            if (Convert.ToInt32(dr1[0]["PickingQty"]) >= Convert.ToInt32(dr1[0]["PlanPickingQty"]))
                            {
                                MessageDialog.Show("ERR 9 : ไม่สามารถหยิบเกินแผนได้", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }

                            dr[0]["TagStatus"] = 3;
                            dr1 = dsPicking.Tables[1].Select(string.Format("ProductID = '{0}' ", dr[0]["ProductID"]));
                            if (dr1.Length <= 0)
                            {
                                MessageDialog.Show("ERR 10 : หมายเลข R/M ไม่ถูกต้อง หรือ หมายเลข R/M นี้ได้รับสแกนไปแล้ว", AppConfig.Caption);
                                txtRMTag.Text = string.Empty;
                                return;
                            }
                            else
                            {
                                dr1[0]["PickingQty"] = Convert.ToInt32(dr1[0]["PickingQty"]) + Convert.ToInt32(dr[0]["Qty"]);
                                dr1[0]["LocationID"] = dr[0]["LocationID"];
                                txtRMTag.Text = string.Empty;
                                AddRMTagData(dr[0]["PDSNo"].ToString(), dr[0]["RunningNo"].ToString(), Convert.ToInt32(dr[0]["ProductID"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show("ERR 11 : " +ex.Message, AppConfig.Caption);
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
            lblPickingNo.Text = dsPicking.Tables[0].Rows[0]["PickingNo"].ToString();
            lblPickingDate.Text = dsPicking.Tables[0].Rows[0]["PickingDate"].ToString();
            lblPackingNo.Text = dsPicking.Tables[0].Rows[0]["PackingNo"].ToString();
            dsPicking.Tables[1].TableName = "DataTableData";
            dsPicking.Tables[1].AcceptChanges();
            grdResult.DataSource = dsPicking.Tables[1];

            dtRMTagReceive.Columns.Add("PDSNo", typeof(string));
            dtRMTagReceive.Columns.Add("RunningNo", typeof(string));
            dtRMTagReceive.Columns.Add("ProductID", typeof(int));
        }

        private void AddRMTagData(string PDSNo, string RunningNo, int ProductID)
        {
            DataRow dr = dtRMTagReceive.NewRow();
            dr["PDSNo"] = PDSNo;
            dr["RunningNo"] = RunningNo;
            dr["ProductID"] = ProductID;
            dtRMTagReceive.Rows.Add(dr);
        }

        private bool ConfirmPicking()
        {
            DataRow[] drUpdate = dsPicking.Tables[1].Select("", "", DataViewRowState.ModifiedCurrent);

            if (drUpdate.Length > 0)
            {
                foreach (DataRow dr in drUpdate.CopyToDataTable().Rows)
                {
                    //Save
                    Database.PickingConfirmationDetail_Save(dr["PickingNo"].ToString(),
                                                            1,
                                                            Convert.ToInt32(dr["ProductID"]),
                                                            Convert.ToDecimal(dr["PickingQty"]),
                                                            dtRMTagReceive.Select(string.Format("ProductID ={0}", dr["ProductID"])).CopyToDataTable(),
                                                            AppConfig.UserLogin);
                }

                if (CallFromScreen == 2)
                {
                    DataTable dt = Database.PickingEntry_SearchBy_PickingDate(PickingDate.ToString("yyyy/MM/dd"), AppConfig.UserLogin);
                    if (dt.Rows.Count <= 0)
                    {
                        AppConfig.FormList.Clear();
                        frmZHPK010_PickingEntry frm = new frmZHPK010_PickingEntry();
                        AppConfig.FormList.Add(AppConfig.MainMenu);
                        frm.Show();
                        this.Dispose();
                    }
                    else
                    {
                        frmZHPK020_PickingConfirmationList frm = new frmZHPK020_PickingConfirmationList();
                        frm.PickingDate = PickingDate;
                        frm.dtPicking = dt;
                        AppConfig.FormList.Add(AppConfig.MainMenu);
                        frm.Show();
                        this.Dispose();
                    }
                }
                else
                {
                    AppConfig.FormList.Clear();
                    frmZHPK010_PickingEntry frm = new frmZHPK010_PickingEntry();
                    AppConfig.FormList.Add(AppConfig.MainMenu);
                    frm.Show();
                    this.Dispose();
                }
                return true;
            }
            else
            {
                MessageDialog.Show("ไม่มีข้อมูลให้ทำการหยิบสินค้า", AppConfig.Caption);
                return false;
            }
        }
        #endregion
    }
}