using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class PickForShipBusiness
    {
        public void PickShip_Update(string PalletNo, string LocationCode, int Flag, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("Flag", Flag);
                hs.Add("UserName", UserName);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickShip_Update", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PickShip_CheckPalletOrLocation(string PalletNo, string LocationCode)
        {
            try
            {
                bool retflag = false;
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickShip_CheckPalletOrLocation", hs);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(strResult);
                if (dt.Rows.Count > 0)
                {
                    retflag = true;
                }
                else
                {
                    retflag = false;
                }
                return retflag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CaseMarkPickAndPack(string PalletNo, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("UserName", UserName);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/CaseMarkPickAndPack", hs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet PickingPalletEntry_SearchBy_ContainerNo(string ShipmentNo, string ContainerNo, string PackingDate)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("ContainerNo", ContainerNo);
                hs.Add("PackingDate", PackingDate);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickingPalletEntry_SearchBy_ContainerNo", hs);
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(strResult);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
