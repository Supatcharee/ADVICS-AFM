using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;

namespace CSI.Business.BusinessFactory.Operation
{
    public class StockChecking
    {
        #region Member
        private sp_ESTS040_StockChecking_Get_Result ta_Result = null;
        #endregion

        #region Properties
        private sp_ESTS040_StockChecking_Get_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_ESTS040_StockChecking_Get_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_ESTS040_StockChecking_Get_Result)value; }
        }
        public int? OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public int? WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public String DCCode
        {
            get { return ResultData.DCCode; }
            set { ResultData.DCCode = value; }
        }
        public String WarehouseName
        {
            get { return ResultData.WarehouseName; }
            set { ResultData.WarehouseName = value; }
        }
        public DateTime CheckedDate
        {
            get { return ResultData.CheckedDate; }
            set { ResultData.CheckedDate = value; }
        }
        public String CheckedBy
        {
            get { return ResultData.CheckedBy; }
            set { ResultData.CheckedBy = value; }
        }
        public int? ProductID
        {
            get { return ResultData.ProductID; }
            set { ResultData.ProductID = value; }
        }
        public String ProductCode
        {
            get { return ResultData.ProductCode; }
            set { ResultData.ProductCode = value; }
        }
        public String ProductLongName
        {
            get { return ResultData.ProductLongName; }
            set { ResultData.ProductLongName = value; }
        }
        public int? ProductConditionID
        {
            get { return ResultData.ProductConditionID; }
            set { ResultData.ProductConditionID = value; }
        }
        public String ProductConditionCode
        {
            get { return ResultData.ProductConditionCode; }
            set { ResultData.ProductConditionCode = value; }
        }
        public String ProductConditionName
        {
            get { return ResultData.ProductConditionName; }
            set { ResultData.ProductConditionName = value; }
        }
        public int LocationID
        {
            get { return ResultData.LocationID; }
            set { ResultData.LocationID = value; }
        }
        public String LocationCode
        {
            get { return ResultData.LocationCode; }
            set { ResultData.LocationCode = value; }
        }
        public Decimal? InventoryQty
        {
            get { return ResultData.InventoryQty; }
            set { ResultData.InventoryQty = value; }
        }
        public Decimal? CheckedQty
        {
            get { return ResultData.CheckedQty; }
            set { ResultData.CheckedQty = value; }
        }
        public int? TypeOfUnitInventory
        {
            get { return ResultData.TypeOfUnitInventory; }
            set { ResultData.TypeOfUnitInventory = value; }
        }
        public String UnitCode
        {
            get { return ResultData.UnitCode; }
            set { ResultData.UnitCode = value; }
        }
        public String UnitName
        {
            get { return ResultData.UnitName; }
            set { ResultData.UnitName = value; }
        }
        public String Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public int DiffFlag
        {
            get { return ResultData.DiffFlag; }
            set { ResultData.DiffFlag = value; }
        }
        #endregion

        public List<sp_ESTS040_StockChecking_Get_Result> DataLoading(int? iCustomerID, 
                                                                    int? iWarehouseID, 
                                                                    int? iProductID, 
                                                                    DateTime? dtdateFrom, 
                                                                    DateTime? dtdateTo, 
                                                                    bool? idiffFlage)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iCustomerID", iCustomerID);
            hs.Add("iWarehouseID", iWarehouseID);
            hs.Add("iProductID", iProductID);
            hs.Add("dtdateFrom", dtdateFrom);
            hs.Add("dtdateTo", dtdateTo);
            hs.Add("idiffFlage", idiffFlage);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StockChecking/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ESTS040_StockChecking_Get_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
