using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class CalendarCompany
    {
        #region Member
        struct CompanyCalendarGenerate
        {
            public int? OwnerID;
            public int NoOfMonth;
            public string DateDefault;
            public string CreateUser;
        }
        #endregion

        #region Properties

        #endregion

        public DataSet LoadCompanyCalendar(int? OwnerID, DateTime SelectedMonth)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("SelectedMonth", SelectedMonth);
                string strResult = RubixWebAPI.ExecuteObjectResult("CalendarCompany/LoadCompanyCalendar", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerateCompanyCalendar(int? OwnerID, int NoOfMonth, string DateDefault, string CreateUser)
        {
            try
            {
                CompanyCalendarGenerate stc = new CompanyCalendarGenerate();
                stc.OwnerID = OwnerID;
                stc.NoOfMonth = NoOfMonth;
                stc.DateDefault = DateDefault;
                stc.CreateUser = CreateUser;
                RubixWebAPI.ExecuteObjectResult("CalendarCompany/GenerateCompanyCalendar", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(DataTable dtCalendar, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CreateUser", CreateUser);

                DataSet ds = new DataSet();
                ds.DataSetName = "CalendarDataSet";
                dtCalendar.TableName = "CalendarDataTable";
                ds.Tables.Add(dtCalendar);
                RubixWebAPI.ExecuteObjectResult("CalendarCompany/SaveData", hs, JsonConvert.SerializeObject(ds.GetXml()));
                ds.Tables.Clear();
                ds = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
