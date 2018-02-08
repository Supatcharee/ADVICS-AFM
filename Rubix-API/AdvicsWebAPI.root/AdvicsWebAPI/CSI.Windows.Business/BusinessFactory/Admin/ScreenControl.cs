using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using CSI.Business;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Admin
{
    public class ScreenControl
    {        
        public bool LockScreen(string screenID, string userID, string ipAddress)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScreenID", screenID);
                hs.Add("UserID", userID);
                hs.Add("IPaddress", ipAddress);
                return Convert.ToInt16(Database.ExecuteScalar("sp_ADM000_ScreenControl_LockScreeen", hs)) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearScreen(string screenID, string userID, string ipAddress)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScreenID", screenID);
                hs.Add("UserID", userID);
                hs.Add("IPaddress", ipAddress);
                Database.ExecuteNonQuery("sp_ADM000_ScreenControl_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
