/*
 * 17 Jan 2013:
 * 1. add method for check whether can show qty level1
 * 28 Jan 2013:
 * 1. modify DeleteTransport and DeleteOther function to validate receiving no before delete
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using CSI.Business;
using System.Data;
using System.Collections;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Transactions;
using Rubix.Framework;

namespace CSI.Business.Operation
{
    public class WarehouseUtilization
    {
        #region Members
        protected BusinessCommon ims = null;
        #endregion

        #region Properties
        protected BusinessCommon Database
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

        //public List<sp_ESTS070_InquiryWarehouseUtilization_Get_Result> GetSummary(int WarehouseID)
        //{
        //    try
        //    {
        //        return Database.StockEntity.sp_ESTS070_InquiryWarehouseUtilization_Get(WarehouseID: WarehouseID).ToList();
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //public List<sp_ESTS070_InquiryWarehouseUtilization_Detail_Get_Result> GetDetail(int WarehouseID, int? ZoneID)
        //{
        //    try
        //    {
        //        return Database.StockEntity.sp_ESTS070_InquiryWarehouseUtilization_Detail_Get(WarehouseID: WarehouseID, ZoneID: ZoneID).ToList();

        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //public List<sp_ESTS070_InquiryWarehouseUtilization_PageInfo_Get_Result> GetPageInfo(string LayoutWarehouse)
        //{
        //    try
        //    {
        //        return Database.StockEntity.sp_ESTS070_InquiryWarehouseUtilization_PageInfo_Get(LayoutWarehouse: LayoutWarehouse).ToList();
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}
        
        //public List<sp_ESTS070_InquiryWarehouseUtilization_Zone_Detail_Get_Result> GetZoneDetail(int WarehouseID, int ZoneID, string LocationPrefix)
        //{
        //    try
        //    {
        //        return Database.StockEntity.sp_ESTS070_InquiryWarehouseUtilization_Zone_Detail_Get(WarehouseID: WarehouseID, ZoneID: ZoneID, LocationPrefix: LocationPrefix).ToList();

        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        //public ObjectResult<sp_ESTS070_InquiryWarehouseUtilization_GetLayout_Result> GetWarehouseLayout(string LayoutWarehouse, int Page)
        //{
        //    try
        //    {
        //        return Database.StockEntity.sp_ESTS070_InquiryWarehouseUtilization_GetLayout(LayoutWarehouse: LayoutWarehouse, Page: Page);
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        public DataSet SpaceUtilization_Load(int WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                return Database.ExecuteDataSet("sp_ESTS060_SpaceUtilization_Load", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
