using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using CSI.Business;
using System.Collections;
using Newtonsoft.Json;
using Rubix.Framework;
namespace CSI.Business.Master
{
    public class Location
    {
        #region Member

        #endregion

        #region Properties
        //private sp_XMSS170_Location_SearchAll_Result ResultData
        //{
        //    get
        //    {
        //        if (ta_Result == null)
        //        {
        //            ta_Result = new sp_XMSS170_Location_SearchAll_Result();
        //        }
        //        return ta_Result;
        //    }
        //    set { ta_Result = value; }
        //}

        //public Object SelectData
        //{
        //    set { ta_Result = (sp_XMSS170_Location_SearchAll_Result)value; }
        //}

        //public int LocationID
        //{
        //    get { return ResultData.LocationID; }
        //    set { ResultData.LocationID = value; }
        //}

        //public int? OwnerID
        //{
        //    get { return ResultData.OwnerID; }
        //    set { ResultData.OwnerID = value; }
        //}

        //public int? OwnerCode
        //{
        //    get { return ResultData.OwnerCode; }
        //    set { ResultData.OwnerCode = value; }
        //}

        //public int? CustomerName
        //{
        //    get { return ResultData.CustomerName; }
        //    set { ResultData.CustomerName = value; }
        //}

        //public int? WarehouseID
        //{
        //    get { return ResultData.WarehouseID; }
        //    set { ResultData.WarehouseID = value; }
        //}

        //public String WarehouseCode
        //{
        //    get { return ResultData.WarehouseCode; }
        //    set { ResultData.WarehouseCode = value; }
        //}

        //public int? ZoneID
        //{
        //    get { return ResultData.ZoneID; }
        //    set { ResultData.ZoneID = value; }
        //}

        //public String ZoneCode
        //{
        //    get { return ResultData.ZoneCode; }
        //    set { ResultData.ZoneCode = value; }
        //}

        //public int? Floor
        //{
        //    get { return ResultData.Floor; }
        //    set { ResultData.Floor = value; }
        //}

        //public String RackNo
        //{
        //    get { return ResultData.RackNo; }
        //    set { ResultData.RackNo = value; }
        //}

        //public String LocationCode
        //{
        //    get { return ResultData.LocationCode; }
        //    set { ResultData.LocationCode = value; }
        //}

        //public String LocationName
        //{
        //    get { return ResultData.LocationName; }
        //    set { ResultData.LocationName = value; }
        //}

        //public int? ProductConditionID
        //{
        //    get { return ResultData.ProductConditionID; }
        //    set { ResultData.ProductConditionID = value; }
        //}

        //public String ProductConditionCode
        //{
        //    get { return ResultData.ProductConditionCode; }
        //    set { ResultData.ProductConditionCode = value; }
        //}

        //public String Remark
        //{
        //    get { return ResultData.Remark; }
        //    set { ResultData.Remark = value; }
        //}

        //public Decimal? MaxM3
        //{
        //    get { return ResultData.MaxM3; }
        //    set { ResultData.MaxM3 = value; }
        //}

        //public Decimal? MaxM2
        //{
        //    get { return ResultData.MaxM2; }
        //    set { ResultData.MaxM2 = value; }
        //}

        //public int? PickingPriority
        //{
        //    get { return ResultData.PickingPriority; }
        //    set { ResultData.PickingPriority = value; }
        //}

        //public DateTime CreateDate
        //{
        //    get { return ResultData.CreateDate; }
        //    set { ResultData.CreateDate = value; }
        //}

        //public String CreateUser
        //{
        //    get { return ResultData.CreateUser; }
        //    set { ResultData.CreateUser = value; }
        //}

        //public DateTime? UpdateDate
        //{
        //    get { return ResultData.UpdateDate; }
        //    set { ResultData.UpdateDate = value; }
        //}

        //public String UpdateUser
        //{
        //    get { return ResultData.UpdateUser; }
        //    set { ResultData.UpdateUser = value; }

        //}

        //public String Level
        //{
        //    get { return ResultData.level; }
        //    set { ResultData.level = value; }
        //}

        //public decimal? MaxCapacity
        //{
        //    get { return ResultData.MaxCapacity; }
        //    set { ResultData.MaxCapacity = value; }
        //}

        //public int? MaxUnit
        //{
        //    get { return ResultData.MaxUnit; }
        //    set { ResultData.MaxUnit = value; }
        //}

        //public int? NoOfPallet
        //{
        //    get { return ResultData.NoOfPallet; }
        //    set { ResultData.NoOfPallet = value; }
        //}

        //public string FullCurrentCapacity
        //{
        //    get { return ResultData.FullCapacity; }
        //    set { ResultData.FullCapacity = value; }
        //}

        ////public string TemporaryLocation
        ////{
        ////    get { return ResultData.TemporaryLocation; }
        ////    set { ResultData.TemporaryLocation = value; }
        ////}

        ////public bool? TemporaryLocationFlag
        ////{
        ////    get { return ResultData.TemporaryLocationFlag; }
        ////    set { ResultData.TemporaryLocationFlag = value; }
        ////}

        //public bool? FullCapacityFlag
        //{
        //    get { return ResultData.FullCapacityFlag; }
        //    set { ResultData.FullCapacityFlag = value; }
        //}
        //public int? Stack
        //{
        //    get { return ResultData.Stack; }
        //    set { ResultData.Stack = value; }
        //}

        //public int? LocationTypeID
        //{
        //    get { return ResultData.LocationTypeID; }
        //    set { ResultData.LocationTypeID = value; }
        //}

        //public string LocationTypeName
        //{
        //    get { return ResultData.LocationTypeName; }
        //    set { ResultData.LocationTypeName = value; }
        //}
        #endregion

        public List<LocationGraphic> SearchLocationDesigner(int WarehouseID, byte[] DeletePicture)
        { 
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            string strResult = RubixWebAPI.ExecuteObjectResult("Location/SearchLocationDesigner", hs);
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(strResult);

            List<LocationGraphic> ListLocation = new List<LocationGraphic>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LocationGraphic lg = new LocationGraphic();
                lg.LayoutID = Convert.ToInt32(dr["LayoutID"]);
                lg.LocationCode = dr["LocationLayoutCode"].ToString();
                lg.LocationName = dr["LocationLayoutName"].ToString();
                lg.ZoneID = Convert.ToInt32(dr["ZoneID"]);
                lg.ZoneColor = dr["ZoneColor"].ToString();
                lg.LocationTypeID = Convert.ToInt32(dr["LocationTypeID"]);
                lg.Type = dr["Type"].ToString(); 
              
                lg.CaptionPosition = dr["CaptionPosition"].ToString();
                lg.CaptionOffset = GetCaptionOffSet(lg.CaptionPosition);
                lg.LayoutSizeWidthX = Convert.ToInt32(dr["Width"]);
                lg.LayoutSizeHeightY = Convert.ToInt32(dr["Height"]);
                lg.LayoutLocationX = Convert.ToInt32(dr["PositionX"]);
                lg.LayoutLocationY = Convert.ToInt32(dr["PositionY"]);

                lg.DataState = "UNCHANGE";

                DataRow[] drr = ds.Tables[1].Select(string.Format(" LayoutID='{0}' ", dr["LayoutID"]));
                if (drr.Length > 0)
                {
                    DataTable dt = drr.CopyToDataTable();
                    dt.Columns.Add("Delete",typeof(byte[]));
                    foreach(DataRow d in dt.Rows)
                    {
                        d["Delete"] = DeletePicture;
                    }
                    dt.AcceptChanges();
                    lg.LocationInformation = dt;
                }

                ListLocation.Add(lg);
            }

            return ListLocation;
        }

        public DataTable SearchLocationLabel(int? WarehouseID, int? ZoneID, string RackNo, string LocationCode, string LocationName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ZoneID", ZoneID);
            hs.Add("RackNo", RackNo);
            hs.Add("LocationCode", LocationCode);
            hs.Add("LocationName", LocationName);
            string strResult = RubixWebAPI.ExecuteObjectResult("Location/SearchLocationLabel", hs);
            return JsonConvert.DeserializeObject<DataTable>(strResult);
        }
        
        public DataTable LoadLocationType()
        {
            try
            {
                return RubixWebAPI.ExecuteDataTable("Location/LoadLocationType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Boolean CheckExistLocation(string LocationCode, int? WarehouseID, int? ZoneID)
        {           

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("LocationCode", LocationCode);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ZoneID", ZoneID);

                string strResult = RubixWebAPI.ExecuteObjectResult("Location/CheckExistLocation", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReferenceByLocation(int? LocationID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("LocationID", LocationID);
                string strResult = RubixWebAPI.ExecuteObjectResult("Location/CheckReferenceByLocation", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReferenceByLayout(DataTable dtLocationList)
        {
            DataSet ds = new DataSet("DataSetLocation");
            try
            {
                dtLocationList.TableName = "DataTableLocation";
                ds.Tables.Add(dtLocationList);
                string strResult = RubixWebAPI.ExecuteObjectResult("Location/CheckReferenceByLayout", JsonConvert.SerializeObject(ds.GetXml()));
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Tables.Clear();
                ds = null;
            }
        }

        public void SaveZoneData(List<LocationGraphic> ListLocation, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CreateUser", CreateUser);
                RubixWebAPI.ExecuteObjectResult("Location/SaveZoneData", hs, JsonConvert.SerializeObject(ListLocation));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Location Graphic
        public int GetCaptionOffSet(string PositionKey)
        {
            switch (PositionKey)
            {
                case "T": return 1;
                case "B": return 1;
                case "L": return 3;
                case "R": return 3;
                default: return 0;
            }
        }

        public string GetFullPositionBinding(string PositionKey)
        {
            switch (PositionKey)
            {
                case "T": return "Top";
                case "B": return "Buttom";
                case "L": return "Left";
                case "R": return "Right";
                default: return null;
            }
        }
        #endregion
    }

    public class LocationGraphic 
    {
        #region Properties
        public int? LayoutID { get; set; }

        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public int ZoneID { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string ZoneColor { get; set; }
        public int LocationTypeID { get; set; }
        public string Type { get; set; }

        public int? FullUnit { get; set; }
        public int? UsageUnit { get; set; }
        public int? AvailableUnit { get; set; }

        public string CaptionPosition { get; set; }
        public int CaptionOffset { get; set; }
        public int LayoutSizeWidthX { get; set; }
        public int LayoutSizeHeightY { get; set; }
        public int LayoutLocationX { get; set; }
        public int LayoutLocationY { get; set; }

        public string DataState { get; set; }

        public DataTable LocationInformation { get; set; }
        public DevExpress.XtraEditors.LabelControl LabelDetail { get; set; }

        public int ButtonID { get; set; }
        #endregion
    }
}
