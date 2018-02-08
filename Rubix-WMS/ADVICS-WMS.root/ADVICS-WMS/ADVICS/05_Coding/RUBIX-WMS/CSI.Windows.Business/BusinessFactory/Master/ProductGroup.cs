using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class ProductGroup
    {
        #region Member
        private sp_XMSS250_ProductGroup_SearchAll_Result ta_Result = null;
        private sp_XMSS250_ProductGroup_LoadProductCategory_Result ta_Result_SubItem = null;
        struct ProductGroupStruct
        {
            public sp_XMSS250_ProductGroup_SearchAll_Result ResultData;
            public string resultXML;
        }
        #endregion

        #region Properties
        public sp_XMSS250_ProductGroup_LoadProductCategory_Result ResultSubItem
        {
            get
            {
                if (ta_Result_SubItem == null)
                {
                    ta_Result_SubItem = new sp_XMSS250_ProductGroup_LoadProductCategory_Result();
                }
                return ta_Result_SubItem;
            }
            set { ta_Result_SubItem = value; }
        }
        public sp_XMSS250_ProductGroup_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS250_ProductGroup_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS250_ProductGroup_SearchAll_Result)value; }
        }
        public int ProductGroupID
        {
            get { return ResultData.ProductGroupID; }
            set { ResultData.ProductGroupID = value; }
        }
        public string ProductGroupCode
        {
            get { return ResultData.ProductGroupCode; }
            set { ResultData.ProductGroupCode = value; }
        }
        public string ProductGroupName
        {
            get { return ResultData.ProductGroupName; }
            set { ResultData.ProductGroupName = value; }
        } 
        public String CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }
        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }
        public String UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }
        public DateTime? UpdateDate
        {
            get { return ResultData.UpdateDate; }
            set { ResultData.UpdateDate = value; }
        }
        public int ProductCategoryID
        {
            get { return ResultSubItem.ProductCategoryID; }
            set { ResultSubItem.ProductCategoryID = value; }
        }
        public string ProductCategoryCode
        {
            get { return ResultSubItem.ProductCategoryCode; }
            set { ResultSubItem.ProductCategoryCode = value; }

        }
        public string ProductCategoryName
        {
            get { return ResultSubItem.ProductCategoryName; }
            set { ResultSubItem.ProductCategoryName = value; }
        }
        #endregion

        public List<sp_XMSS250_ProductGroup_SearchAll_Result> DataLoading(string ProductGroupCode, string ProductGroupName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductGroupCode", ProductGroupCode);
            hs.Add("ProductGroupName", ProductGroupName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductGroup/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS250_ProductGroup_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DataLoadingSubItem()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupID",ProductGroupID);
                return RubixWebAPI.ExecuteDataTable("ProductGroup/DataLoadingSubItem", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Boolean CheckExistProductGroupCode(String ProductGroupCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductGroupCode", ProductGroupCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductGroup/CheckExistProductGroupCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveProductGroupData(string resultXML)
        {
            ProductGroupStruct stc;
            stc.ResultData = ResultData;
            stc.resultXML = resultXML;

            try
            {
                RubixWebAPI.ExecuteObjectResult("ProductGroup/SaveProductGroupData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductGroupData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductGroupID", ProductGroupID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ProductGroup/DeleteProductGroupData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iProductGroupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iProductGroupID", iProductGroupID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductGroup/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReferenceCategory(int? ProductCategoryID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCategoryID", ProductCategoryID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductGroup/CheckReferenceCategory", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductCategoryData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCategoryID", ProductCategoryID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ProductGroup/DeleteProductCategoryData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
