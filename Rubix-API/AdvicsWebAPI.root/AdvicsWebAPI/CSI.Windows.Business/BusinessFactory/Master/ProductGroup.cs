using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;

namespace CSI.Business.Master
{
    public class ProductGroup
    {
        #region Member
        private sp_XMSS250_ProductGroup_SearchAll_Result ta_Result = null;
        private sp_XMSS250_ProductGroup_LoadProductCategory_Result ta_Result_SubItem = null;
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

        public ObjectResult<sp_XMSS250_ProductGroup_SearchAll_Result> DataLoading(string ProductGroupCode, string ProductGroupName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS250_ProductGroup_SearchAll(productGroupCode: ProductGroupCode == string.Empty ? null : ProductGroupCode, productGroupName: ProductGroupName == string.Empty ? null : ProductGroupName);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //public ObjectResult<sp_XMSS250_ProductGroup_LoadProductCategory_Result> DataLoadingSubItem()
        //{
        //    return Database.MasterEntity.sp_XMSS250_LoadSubItem(typeOfGoodsID: ProductGroupID);
        //}
        public DataTable DataLoadingSubItem()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupID",ProductGroupID);
                return Database.ExecuteDataSet("sp_XMSS250_ProductGroup_LoadProductCategory", hs).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Boolean CheckExistProductGroupCode(String ProductGroupCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupCode", ProductGroupCode);
                return (Database.ExecuteDataSet("sp_XMSS250_ProductGroup_CheckExist", hs).Tables[0].Rows.Count > 0);             
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveProductGroupData(string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupID", ProductGroupID);
                hs.Add("ProductGroupCode",ProductGroupCode);
                hs.Add("ProductGroupName",ProductGroupName);
                hs.Add("CreateUser",CreateUser);
                hs.Add("resultXML", resultXML);
                Database.ExecuteNonQuery("sp_XMSS250_ProductGroup_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteProductGroupData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupID", ProductGroupID);

                Database.ExecuteNonQuery("sp_XMSS250_ProductGroup_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int? CheckReference(int? iProductGroupID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductGroupID", iProductGroupID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS250_ProductGroup_CheckReference",hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReferenceCategory(int? iProductCategoryID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductCategoryID", iProductCategoryID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS250_ProductGroup_CheckReferenceCategory", hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductCategoryData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductCategoryID", ProductCategoryID);

                Database.ExecuteNonQuery("sp_XMSS250_ProductGroup_Delete_Category", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
