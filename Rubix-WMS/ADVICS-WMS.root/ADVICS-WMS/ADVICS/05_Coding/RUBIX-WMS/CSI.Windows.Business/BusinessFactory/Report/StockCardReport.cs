using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class StockCardReport : Base.BaseReport
    {
        public List<sp_RPT030_StockCard_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? productID,int? typeOfGoods, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("typeOfGoods", typeOfGoods);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StockCardReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT030_StockCard_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetTypeOfGoodName(Int32? productID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("productID", productID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StockCardReport/GetTypeOfGoodName", hs);
                return JsonConvert.DeserializeObject<String>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
