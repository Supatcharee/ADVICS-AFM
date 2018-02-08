using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Master
{
     [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export)]
    public partial class frmXMSS360_ShippingCalendar : FormBase
    {
        #region Member
        private CalendarShipping db;
        private Button[,] m_BtnDayInCalendarList;
        private bool IsEditCalendar = false;
        private DataTable dtCalendarEdit = new DataTable();
        #endregion

        #region Enumeration
        enum eCalendar
        {
            OwnerCode = 1,
            CustomerCode,
            CalendarDate,
            IsShippingDay
        }
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode { get; set; }
        private CalendarShipping BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new CalendarShipping();
                }
                return db;
            }
        }
        #endregion
         
        #region Construnctor
         public frmXMSS360_ShippingCalendar()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarExport, m_toolBarSave, m_toolBarRefresh);
            ControlUtil.HiddenControl(true, m_toolBarThemeStyls, m_toolBarPaintStyls);
            base.GridExportExcel = gdvSearchResult;
        } 
        #endregion

        #region Override Method
         public override bool OnCommandEdit()
         {
             try
             {
                 errorProvider.ClearErrors();
                 if (ownerControl.OwnerID == null)
                 {
                     MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                     return false;
                 }

                 if (customerControl.CustomerID == null)
                 {
                     MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0249"));
                     return false;
                 }

                 if (dtCalendarMonth.DateTime == null)
                 {
                     MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0370"));
                     return false;
                 }

                 ControlUtil.HiddenControl(true, m_toolBarEdit);
                 ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
                 ControlUtil.EnableControl(false, ownerControl, customerControl, btnGenerate, btnImport, txtNumberOfMonthToAdd, gpcShippingDay);
                 ScreenMode = Common.eScreenMode.Edit;
                 return true;
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
                 return false;
             }
         }
         public override bool OnCommandSave()
         {
             try
             {
                 if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), dtCalendarMonth.DateTime.ToString("MM/yyyy"))) == DialogButton.Yes)
                 {
                     SaveData();
                     ControlUtil.HiddenControl(false, m_toolBarEdit);
                     ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                     ControlUtil.EnableControl(true, ownerControl, customerControl, btnGenerate, btnImport, txtNumberOfMonthToAdd, gpcShippingDay);
                     ScreenMode = Common.eScreenMode.View;
                     GenerateCalendar();
                     return true;
                 }
                 return false;
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
                 return false;
             }
         }
         public override bool OnCommandCancel()
         {
             try
             {
                 ControlUtil.HiddenControl(false, m_toolBarEdit);
                 ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                 ControlUtil.EnableControl(true, ownerControl, customerControl, btnGenerate, btnImport, txtNumberOfMonthToAdd, gpcShippingDay);
                 ScreenMode = Common.eScreenMode.View;
                 GenerateCalendar();
                 return true;
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
                 return false;
             }
         }
        #endregion

        #region Event Handler
         private void frmXMSS360_ShippingCalendar_Load(object sender, EventArgs e)
        {
            try
            {
                InitialScreen();
                dtCalendarMonth.DateTime = DateTime.Now;
                ScreenMode = Common.eScreenMode.View;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
         
         private void ownerControl_EditValueChanged(object sender, EventArgs e)
         {
             try
             {
                 if (ownerControl.OwnerID != null)
                 {
                     customerControl.ClearData();
                     customerControl.OwnerID = ownerControl.OwnerID;
                     customerControl.DataLoading();
                     GenerateCalendar();
                 }
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void customerControl_EditValueChanged(object sender, EventArgs e)
         {
             try
             {
                 GenerateCalendar();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void dtCalendarMonth_EditValueChanged(object sender, EventArgs e)
         {
             try
             {
                 GenerateCalendar();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void btnCalendarBackWard_Click(object sender, EventArgs e)
         {
             try
             {
                 if (ScreenMode == Common.eScreenMode.Edit && IsEditCalendar)
                 {
                     if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), dtCalendarMonth.DateTime.ToString("MM/yyyy"))) == DialogButton.Yes)
                     {
                         SaveData();
                     }
                 }
                 dtCalendarMonth.DateTime = dtCalendarMonth.DateTime.AddMonths(-1);
                 GenerateCalendar();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void btnCalendarForward_Click(object sender, EventArgs e)
         {
             try
             {
                 if (ScreenMode == Common.eScreenMode.Edit && IsEditCalendar)
                 {
                     if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), dtCalendarMonth.DateTime.ToString("MM/yyyy"))) == DialogButton.Yes)
                     {
                         SaveData();
                     }
                 }
                 dtCalendarMonth.DateTime = dtCalendarMonth.DateTime.AddMonths(1);
                 GenerateCalendar();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void Calendar_ClickChangeDayColor(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    System.Windows.Forms.Control btnFucus = (sender as System.Windows.Forms.Control);
                    if (btnFucus.GetType() == typeof(Button))
                    {
                       
                        DataRow[] drCheck = dtCalendarEdit.Select(string.Format("OwnerID = {0} AND CustomerID = {1} AND ShippingDate = '{2}' AND IsShippingDay = {3}"
                                                                                , ownerControl.OwnerID
                                                                                , customerControl.CustomerID
                                                                                , dtCalendarMonth.DateTime.ToString("yyyy/MM") + "/" + btnFucus.Text
                                                                                , (btnFucus.BackColor == Color.Red ? 1 : 0)));

                        if (drCheck.Length > 0)
                        {
                            dtCalendarEdit.Rows.Remove(drCheck[0]);
                        }

                        DataRow drNew = dtCalendarEdit.NewRow();
                        drNew["OwnerID"] = ownerControl.OwnerID;
                        drNew["CustomerID"] = customerControl.CustomerID;
                        drNew["ShippingDate"] = dtCalendarMonth.DateTime.ToString("yyyy/MM") + "/" + btnFucus.Text;
                        drNew["IsShippingDay"] = (btnFucus.BackColor == Color.Red ? 0 : 1);
                        dtCalendarEdit.Rows.Add(drNew);

                        btnFucus.BackColor = (btnFucus.BackColor == Color.Red) ? Color.White : Color.Red;
                        IsEditCalendar = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

         private void btnGenerate_Click(object sender, EventArgs e)
         {
             try
             {
                 if (ValidateData())
                 {
                     ShowWaitScreen();
                     BusinessClass.GenerateShippingCalendar(ownerControl.OwnerID, customerControl.CustomerID, Convert.ToInt32(txtNumberOfMonthToAdd.Text), GenerateDefaultNonWorkingDay(), AppConfig.UserLogin);
                     GenerateCalendar();
                 }
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void btnImport_Click(object sender, EventArgs e)
         {
             ExcelManager excel = new ExcelManager();
             try
             {
                 DataTable dtImport = new DataTable();

                 dtImport.Columns.Add("OwnerCode", typeof(string));
                 dtImport.Columns.Add("CustomerCode", typeof(string));
                 dtImport.Columns.Add("ShippingDate", typeof(string));
                 dtImport.Columns.Add("IsShippingDay", typeof(int));
          
                 if (ofdImport.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                 {
                     this.ShowWaitScreen();

                     using (excel)
                     {
                         excel.OpenExcel(ofdImport.FileName);
                         DateTime OutDate;
                         int OutInt;
                         //read header
                         int row = 1;
                         row++;
                         while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eCalendar.OwnerCode).Trim()))
                         {
                             //Check valid date
                             if (DateTime.TryParse(excel.ReadData(row, (int)eCalendar.CalendarDate).Trim(), out OutDate) &&
                                 int.TryParse(excel.ReadData(row, (int)eCalendar.IsShippingDay).Trim(), out OutInt))
                             {

                                 DataRow drNew = dtImport.NewRow();
                                 drNew["OwnerCode"] = excel.ReadData(row, (int)eCalendar.OwnerCode).Trim();
                                 drNew["CustomerCode"] = excel.ReadData(row, (int)eCalendar.CustomerCode).Trim();
                                 drNew["ShippingDate"] = excel.ReadData(row, (int)eCalendar.CalendarDate).Trim();
                                 drNew["IsShippingDay"] = excel.ReadData(row, (int)eCalendar.IsShippingDay).Trim();
                                 dtImport.Rows.Add(drNew);
                             }
                             row++;
                         }
                            
                         DataTable distinctTable = dtImport.DefaultView.ToTable(true, "OwnerCode", "CustomerCode");
                         if (distinctTable.Rows.Count != 1)
                         {
                             MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0377"));
                             return;
                         }

                         Owner owner = new Owner();
                         List<sp_XMSS010_Owner_SearchAll_Result> listOwner = owner.DataLoading(distinctTable.Rows[0]["OwnerCode"].ToString(), null);
                         if (listOwner.Count == 0)
                         {
                             MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0229", "Owner Code"));
                             return;
                         }

                         Customer customer = new Customer();
                         List<sp_XMSS270_Customer_SearchAll_Result> listCustomer = customer.DataLoading(listOwner[0].OwnerID, distinctTable.Rows[0]["CustomerCode"].ToString(), null);
                         if (listCustomer.Count == 0)
                         {
                             MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0229", "Customer Code"));
                             return;
                         }
                         
                         int OwnerID = listOwner[0].OwnerID;
                         int CustomerID = listCustomer[0].CustomerID;

                         foreach (DataRow dr in dtImport.Rows)
                         {
                             DataRow drNew = dtCalendarEdit.NewRow();
                             drNew["OwnerID"] = OwnerID;
                             drNew["CustomerID"] = CustomerID;
                             drNew["ShippingDate"] = dr["ShippingDate"];
                             drNew["IsShippingDay"] = dr["IsShippingDay"];
                             dtCalendarEdit.Rows.Add(drNew);
                         }

                         SaveData();
                         GenerateCalendar();
                         MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0410"));
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
             finally
             {
                 excel.Dispose();
                 this.CloseWaitScreen();
             }
         }
        #endregion

        #region Generic Function
         private void InitialScreen()
         {
             try
             {
                 Button[,] myButtons =
                {
                    {btnDay1,btnDay2,btnDay3,btnDay4,btnDay5,btnDay6,btnDay7},
                    {btnDay8,btnDay9,btnDay10,btnDay11,btnDay12,btnDay13,btnDay14},
                    {btnDay15,btnDay16,btnDay17,btnDay18,btnDay19,btnDay20,btnDay21},
                    {btnDay22,btnDay23,btnDay24,btnDay25,btnDay26,btnDay27,btnDay28},
                    {btnDay29,btnDay30,btnDay31,btnDay32,btnDay33,btnDay34,btnDay35},
                    {btnDay36,btnDay37,btnDay38,btnDay39,btnDay40,btnDay41,btnDay42}
                };
                 m_BtnDayInCalendarList = myButtons;

                 foreach (Button t in m_BtnDayInCalendarList)
                 {
                     t.Click += new EventHandler(Calendar_ClickChangeDayColor);
                 }

                 dtCalendarEdit.Columns.Add("OwnerID", typeof(int));
                 dtCalendarEdit.Columns.Add("CustomerID", typeof(int));
                 dtCalendarEdit.Columns.Add("ShippingDate", typeof(string));
                 dtCalendarEdit.Columns.Add("IsShippingDay", typeof(int));
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
             }
         }

         private void GenerateCalendar()
         {
             try
             {
                 ShowWaitScreen();                
                 //check กรณียังไม่เข้า page load เข้า event owner กับ customer control ก่อน
                 if (m_BtnDayInCalendarList == null)
                 {
                     return;
                 }

                 DateTime dateTime;

                 if (dtCalendarMonth.DateTime == null)
                 {
                     dtCalendarMonth.DateTime = DateTime.Now;
                 }

                 dateTime = Util.FirstDayOfMonth(dtCalendarMonth.DateTime);

                 // เตรียม TextBox ไว้สร้างปฏิทิน
                 for (int j = 0; j < 7; j++)
                 {
                     for (int i = 0; i < 6; i++)
                     {
                         if (m_BtnDayInCalendarList[i, j] != null)
                         {
                             m_BtnDayInCalendarList[i, j].BackColor = Color.White;
                             m_BtnDayInCalendarList[i, j].Text = string.Empty;
                             m_BtnDayInCalendarList[i, j].Enabled = false;
                         }
                     }
                 }

                 // หาว่าวันแรกของเดือนเป็นวันอะไร?         
                 DayOfWeek dayOfWeekEnum = dateTime.DayOfWeek;

                 // ทำการใส่ค่าวันลงไปใน textbox + กำหนดสี
                 int week = 0;
                 string calendarString = "".PadRight(DateTime.DaysInMonth(dtCalendarMonth.DateTime.Year, dtCalendarMonth.DateTime.Month), '0');
                 for (int i = 0; i < calendarString.Length; i++, dayOfWeekEnum++)
                 {
                     // กำหนดค่าวันที่
                     m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Text = (i + 1).ToString();
                     m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Enabled = true;

                     // เลื่อนไปวันต่อไป
                     if ((int)dayOfWeekEnum + 1 >= 7)
                     {
                         dayOfWeekEnum -= 7;
                         week++;
                     }
                 }

                 DataLoading();
             }
             finally
             {
                 CloseWaitScreen();
             }
         }

         private void DataLoading()
         {
             try
             {
                 if (ownerControl.OwnerID == null || customerControl.CustomerID == null || dtCalendarMonth.DateTime == null)
                 {
                     return;
                 }
                 ShowWaitScreen();
                 DataSet ds = BusinessClass.LoadShippingCalendar(ownerControl.OwnerID, customerControl.CustomerID, dtCalendarMonth.DateTime);
                 if (ds.Tables.Count == 4)
                 {
                     if (ds.Tables[0].Rows[0]["StartMonthToAdd"] != DBNull.Value)
                     {
                         txtStartMonthToAdd.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartMonthToAdd"]).ToString("MM/yyyy");
                     }

                     if (ds.Tables[1].Rows[0]["LastGenerate"] != DBNull.Value)
                     {
                         txtLastGenerate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["LastGenerate"]).ToString("MM/yyyy");
                     }

                     if (ds.Tables[2].Rows[0]["ShippingDate"] != DBNull.Value)
                     {
                         DateTime dateTime = Util.FirstDayOfMonth(dtCalendarMonth.DateTime);
                         // หาว่าวันแรกของเดือนเป็นวันอะไร?         
                         DayOfWeek dayOfWeekEnum = dateTime.DayOfWeek;

                         // ทำการใส่ค่าวันลงไปใน textbox + กำหนดสี
                         int week = 0;
                         string calendarString = ds.Tables[2].Rows[0]["ShippingDate"].ToString();
                         for (int i = 0; i < calendarString.Length; i++, dayOfWeekEnum++)
                         {
                             // กำหนดค่าวันที่
                             m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Text = (i + 1).ToString();
                             m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].Enabled = true;
                             // กำหนดสี
                             if (calendarString[i] == '1')
                             {
                                 m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].BackColor = Color.Red;
                             }
                            else
                             {
                                 m_BtnDayInCalendarList[week, (int)dayOfWeekEnum].BackColor = Color.White;
                             }

                             // เลื่อนไปวันต่อไป
                             if ((int)dayOfWeekEnum + 1 >= 7)
                             {
                                 dayOfWeekEnum -= 7;
                                 week++;
                             }
                         }
                     }

                     grdSearchResult.DataSource = ds.Tables[3];
                 }
             }
             finally
             {
                 CloseWaitScreen();
             }
         }

         private bool ValidateData()
         {
             if (ownerControl.OwnerID == null)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                 return false;
             }

             if (customerControl.CustomerID == null)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0249"));
                 return false;
             }

             if (dtCalendarMonth.DateTime == null)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0370"));
                 return false;
             }

             if (txtNumberOfMonthToAdd.Text.Trim() == string.Empty || Convert.ToInt32(txtNumberOfMonthToAdd.EditValue) <= 0)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0371"));
                 return false;
             }

             if (GenerateDefaultNonWorkingDay() == string.Empty)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0372"));
                 return false;
             }

             return true;
         }

         private string GenerateDefaultNonWorkingDay()
         {
             string strReturn = string.Empty;

             strReturn += (chkMonday.Checked ? "Monday," : string.Empty);
             strReturn += (chkTuesday.Checked ? "Tuesday," : string.Empty);
             strReturn += (chkWednesday.Checked ? "Wednesday," : string.Empty);
             strReturn += (chkThursday.Checked ? "Thursday," : string.Empty);
             strReturn += (chkFriday.Checked ? "Friday," : string.Empty);
             strReturn += (chkSaturday.Checked ? "Saturday," : string.Empty);
             strReturn += (chkSunday.Checked ? "Sunday," : string.Empty);
             return strReturn;
         }

         private void SaveData()
         {
             try
             {
                 ShowWaitScreen();
                 BusinessClass.SaveData(dtCalendarEdit, AppConfig.UserLogin);
                 IsEditCalendar = false;
                 dtCalendarEdit.Rows.Clear();
             }
             finally
             {
                 CloseWaitScreen();
             }
         }
        #endregion
    }
}