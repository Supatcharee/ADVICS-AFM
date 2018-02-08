using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace CSI.Business.Master
{
    public class CalendarShipping
    {
        #region Member
        private BusinessCommon db = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (db == null)
                {
                    db = new BusinessCommon();
                }
                return db;
            }
        }
        #endregion

        public DataSet LoadShippingCalendar(int OwnerID, int CustomerID, DateTime SelectedMonth)
        {
            try 
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("SelectedMonth", SelectedMonth);
                return Database.ExecuteDataSet("sp_XMSS360_ShippingCalendar_SearchAll", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerateShippingCalendar(int OwnerID, int CustomerID, int NoOfMonth, string DateDefault, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("NoOfMonth", NoOfMonth);
                hs.Add("DateDefault", DateDefault);
                 hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS360_ShippingCalendar_Generate", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string XMLCalendarData, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CalendarXML", XMLCalendarData);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS360_ShippingCalendar_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
