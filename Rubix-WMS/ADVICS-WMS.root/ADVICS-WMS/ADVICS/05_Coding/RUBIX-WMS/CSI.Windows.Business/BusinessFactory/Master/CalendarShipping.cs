using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class CalendarShipping
    {
        #region Member
        struct ShippingCalendarGenerate
        {
            public int? OwnerID;
            public int? CustomerID;
            public int NoOfMonth;
            public string DateDefault;
            public string CreateUser;
        }
        #endregion

        #region Properties

        #endregion

        public DataSet LoadShippingCalendar(int? OwnerID, int? CustomerID, DateTime SelectedMonth)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("SelectedMonth", SelectedMonth);
                string strResult = RubixWebAPI.ExecuteObjectResult("CalendarShipping/LoadShippingCalendar", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerateShippingCalendar(int? OwnerID, int? CustomerID, int NoOfMonth, string DateDefault, string CreateUser)
        {
            try
            {
                ShippingCalendarGenerate stc = new ShippingCalendarGenerate();
                stc.OwnerID = OwnerID;
                stc.CustomerID = CustomerID;
                stc.NoOfMonth = NoOfMonth;
                stc.DateDefault = DateDefault;
                stc.CreateUser = CreateUser;
                RubixWebAPI.ExecuteObjectResult("CalendarShipping/GenerateShippingCalendar", JsonConvert.SerializeObject(stc));
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
                RubixWebAPI.ExecuteObjectResult("CalendarShipping/SaveData", hs, JsonConvert.SerializeObject(ds.GetXml()));
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
