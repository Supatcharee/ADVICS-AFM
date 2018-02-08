using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.BusinessFactory.Report
{
    public class StockCardReport : Base.BaseReport
    {
        public List<sp_RPT030_StockCard_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? productID, int? productGroupID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT030_StockCard_GetData(ownerID: OwnerID, warehouseID: WarehouseID, productID: productID, productGroupID: productGroupID, dateForm: dateFrom, dateTo: dateTo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTypeOfGoodName(Int32? productID)
        {
            try
            {
                ObjectResult<string> dt = Context.sp_RPT_GET_TypeOfGood_By_Product(productID: productID);
                List<string> result = dt.ToList();
                return result[0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
