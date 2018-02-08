using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace CSI.Business.BusinessFactory.Master
{
    public class Privilege
    {
        #region Member
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }


        #endregion

        #region Generic function
        public DataTable DataLoading(String PrivilegeCode, String PrivilegeName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PrivilegeCode", PrivilegeCode);
                hs.Add("PrivilegeName", PrivilegeName);
                DataTable tb = Database.ExecuteDataSet("sp_XMSS350_Privilege_Search", hs).Tables[0];
                return tb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExist(int? PrivilegeID, String PrivilegeCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PrivilegeID", PrivilegeID);
                hs.Add("PrivilegeCode", PrivilegeCode);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS350_Privilege_CheckExist", hs)) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(String PrivilegeXML, String CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();

                hs.Add("PrivilegeXML", PrivilegeXML);
                hs.Add("CurrentUser", CurrentUser);

                Database.ExecuteNonQuery("sp_XMSS350_Privilege_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int PrivilegeID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PVID", PrivilegeID);
                Database.ExecuteNonQuery("sp_XMSS350_Privilege_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int PrivilegeID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PVID", PrivilegeID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS350_Privilege_CheckReference", hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion




        
    }
}
