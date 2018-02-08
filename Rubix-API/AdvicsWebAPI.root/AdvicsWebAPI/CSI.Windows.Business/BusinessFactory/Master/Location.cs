using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using CSI.Business;
using System.Collections;
namespace CSI.Business.Master
{
    public class Location
    {
        #region Member
        private BusinessCommon ims = null;
        private MasterConnection _context;
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

        public DataSet SearchLocationDesigner(int WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                return Database.ExecuteDataSet("sp_XMSS170_Location_SearchLocationDesigner", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable SearchLocationLabel(int? WarehouseID, int? ZoneID, string RackNo, string LocationCode, string LocationName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ZoneID", ZoneID);
                hs.Add("RackNo", RackNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("LocationName", LocationName);
                return Database.ExecuteDataSet("sp_XMSS170_Location_SearchLocationLabel", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable LoadLocationType()
        {
            try
            {
                return Database.ExecuteDataSet("sp_common_LoadLocationType").Tables[0];
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
                return (Database.ExecuteDataSet("sp_XMSS170_Location_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveZoneData(List<LocationGraphic> lst, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                DataSet ds = new DataSet();

                foreach (LocationGraphic line in lst)
                {
                    if (line.DataState == "DELETE")
                    {
                        hs.Add("LayoutID", line.LayoutID);
                        hs.Add("UpdateUser", CreateUser);
                        Database.ExecuteNonQuery("sp_XMSS170_Location_Delete", hs);
                    }
                    else
                    {
                        ds.Tables.Clear();

                        hs.Add("ZoneID", line.ZoneID);
                        hs.Add("LocationTypeID", line.LocationTypeID);                        
                        ds.Tables.Add(line.LocationInformation);                        
                        hs.Add("LocationXML", ds.GetXml());                      
                        hs.Add("CreateUser", CreateUser);
                        hs.Add("LayoutID", line.LayoutID);
                        hs.Add("LocationLayoutCode", line.LocationCode);
                        hs.Add("LocationLayoutName", line.LocationName);
                        hs.Add("CaptionPosition", line.CaptionPosition);
                        hs.Add("Width", line.LayoutSizeWidthX);
                        hs.Add("Height", line.LayoutSizeHeightY);
                        hs.Add("PositionX", line.LayoutLocationX);
                        hs.Add("PositionY", line.LayoutLocationY);
                        hs.Add("Type", line.Type);

                        Database.ExecuteNonQuery("sp_XMSS170_Location_Save", hs);
                    }
                    hs.Clear();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int? CheckReferenceByLocation(int LocationID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("LocationID", LocationID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS170_Location_CheckReference_ByLocation", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int? CheckReferenceByLayout(string LocationList)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("LocationList", LocationList);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS170_Location_CheckReference_ByLayout", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
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
        #endregion
    }
}
