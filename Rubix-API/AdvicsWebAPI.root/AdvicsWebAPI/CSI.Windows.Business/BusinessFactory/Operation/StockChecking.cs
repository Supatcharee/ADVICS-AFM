using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.BusinessFactory.Operation
{
    public class StockChecking
    {
        #region Member
        private ObjectResult<sp_ESTS040_StockChecking_Get_Result> lt_Result = null;
        private sp_ESTS040_StockChecking_Get_Result ta_Result = null;
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
        private ObjectResult<sp_ESTS040_StockChecking_Get_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_ESTS040_StockChecking_Get_Result)value; }
        }
        public int? CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public int? DistributionCenterID
        {
            get { return ResultData.DCID; }
            set { ResultData.DCID = value; }
        }
        public String DCCode
        {
            get { return ResultData.DCCode; }
            set { ResultData.DCCode = value; }
        }
        public String DCLongName
        {
            get { return ResultData.DCLongName; }
            set { ResultData.DCLongName = value; }
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

        public List<sp_ESTS040_StockChecking_Get_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ProductID, DateTime? dtdateFrom, DateTime? dtdateTo, bool? idiffFlage)
        {
            try
            {
                return Database.StockEntity.sp_ESTS040_StockChecking_Get( ownerID: OwnerID
                                                                         ,warehouseID: WarehouseID
                                                                         ,productID: ProductID
                                                                         ,dateFrom: dtdateFrom
                                                                         ,dateTo: dtdateTo
                                                                         ,diffFlag: idiffFlage).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
    }
}
