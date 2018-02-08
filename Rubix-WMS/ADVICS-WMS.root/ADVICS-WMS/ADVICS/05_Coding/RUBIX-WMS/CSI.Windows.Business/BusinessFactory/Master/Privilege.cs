using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class Privilege
    {
        #region Properties
        
        //public int? PrivilegeID { get; set; }
        //public string PrivilegeCode { get; set; }
        //public string PrivilegeName { get; set; }
        //public string Remark { get; set; }
        //public string CurrentUser { get; set; }

        #endregion

        public DataTable DataLoading(String PrivilegeCode , String PrivilegeName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PrivilegeCode", PrivilegeCode);
            hs.Add("PrivilegeName", PrivilegeName);

            try
            {
                return RubixWebAPI.ExecuteDataTable("Privilege/DataLoading", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Boolean CheckExist(int? PrivilegeID, String PrivilegeCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PrivilegeID", PrivilegeID);
            hs.Add("PrivilegeCode", PrivilegeCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Privilege/CheckExist", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(String PrivilegeXML ,String CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CurrentUser", CurrentUser);

                RubixWebAPI.ExecuteObjectResult("Privilege/SaveData", hs, PrivilegeXML);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int PrivilegeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PrivilegeID", PrivilegeID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Privilege/DeleteData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int PrivilegeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PrivilegeID", PrivilegeID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Privilege/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
