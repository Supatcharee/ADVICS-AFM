using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using CSI.Business;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Admin
{
    public class ScreenControl
    {

        public bool LockScreen(string screenID, string userID, string ipAddress)
        {
            try
            {
                tb_ScreensControl tb = new tb_ScreensControl();
                tb.ScreenID = screenID;
                tb.UserID = userID;
                tb.IPaddress = ipAddress;
                //tb.LastResponse = lastResponse;

                string strResult = RubixWebAPI.ExecuteObjectResult("ScreenControl/LockScreen", JsonConvert.SerializeObject(tb));
                return JsonConvert.DeserializeObject<bool>(strResult);
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
                tb_ScreensControl tb = new tb_ScreensControl();
                tb.ScreenID = screenID;
                tb.UserID = userID;
                tb.IPaddress = ipAddress;
                RubixWebAPI.ExecuteObjectResult("ScreenControl/ClearScreen", JsonConvert.SerializeObject(tb));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
