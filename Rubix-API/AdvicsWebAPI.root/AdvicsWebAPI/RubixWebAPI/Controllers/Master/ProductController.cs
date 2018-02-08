using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Master;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using Rubix.Framework;

namespace RubixWebAPI.Controllers.Master
{
    public class ProductController : ApiController
    {
        Product obj = new Product();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, String ProductCode, String ProductName, int? SupplierID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, ProductCode, ProductName, SupplierID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingDetail(int ProductID)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.DataLoadingDetail(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadImage(int ProductID)
        {
            byte[] ResultReturn;

            try
            {
                ResultReturn = obj.LoadImage(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadQCImage(string ProductCode)
        {
            byte[] ResultReturn;

            try
            {
                ResultReturn = obj.LoadQCImage(ProductCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistProduct(int OwnerID, int? ProductID, String ProductCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistProduct(OwnerID, ProductID, ProductCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadTypeOfUnitLV1(int? UnitID)
    //    {
    //        string ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadTypeOfUnitLV1(UnitID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }
        
    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadMaker()
    //    {
    //        DataTable ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadMaker();
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }
        
    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadLocationCode(int? WarehouseID, int? ZoneID, String RackNo)
    //    {
    //        string ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadLocationCode(WarehouseID, ZoneID, RackNo);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadTypeOfCargo()
    //    {
    //        DataTable ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadTypeOfCargo();
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadPalletType()
    //    {
    //        DataTable ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadPalletType();
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadTypeOfCargo(int productID)
    //    {
    //        List<sp_XMSS050_Product_LoadTypeOfCargo_Result> ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadTypeOfCargo(productID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadSortingLocation(int productID)
    //    {
    //        List<sp_XMSS050_Product_LoadSortingLocation_Result> ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadSortingLocation(productID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }
        
    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage LoadHandingData(int productID, int packageID)
    //    {
    //        DataTable ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.LoadHandingData(productID, packageID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage CreateProduct()
    //    {
    //        tbm_Product ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.CreateProduct();
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage IsDuplicatedProductCode(int? productID, int? customerID, string productCode)
    //    {
    //        bool ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.IsDuplicatedProductCode(productID, customerID, productCode);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage GetProduct(int productID)
    //    {
    //        tbm_Product ResultReturn;
    //        ProductStruct prdstc = new ProductStruct();
            
    //        try
    //        {
    //            ResultReturn = obj.GetProduct(productID);
    //            prdstc.tbm_Product = DataUtil.CopyEntity(ResultReturn);

    //            prdstc.tbm_ProductDefaultUnit = new List<tbm_ProductDefaultUnit>();
    //            prdstc.tbm_ProductDefaultZoneTransit = new List<tbm_ProductDefaultZoneTransit>();

    //            foreach (var item in ResultReturn.tbm_ProductDefaultUnit)
    //            {
    //                tbm_ProductDefaultUnit itemNew = DataUtil.CopyEntity(item);
    //                prdstc.tbm_ProductDefaultUnit.Add(itemNew);
    //            }

    //            foreach (var item in ResultReturn.tbm_ProductDefaultZoneTransit)
    //            {
    //                tbm_ProductDefaultZoneTransit itemNew = DataUtil.CopyEntity(item);
    //                prdstc.tbm_ProductDefaultZoneTransit.Add(itemNew);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, prdstc);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage getDefultUnit(string configItem)
    //    {
    //        List<sp_XMSS050_systemconfig_Search_Result> ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.getDefultUnit(configItem);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

        //    [HttpPost, HttpGet, APIAuthorize]
        //    public HttpResponseMessage CanDelete(int productID)
        //    {
        //        bool ResultReturn;

        //        try
        //        {
        //            ResultReturn = obj.CanDelete(productID);
        //        }
        //        catch (Exception ex)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage IsUnitOfVolumn(int unitID)
    //    {
    //        bool ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.IsUnitOfVolumn(unitID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage CanConvert(int unitID, int? unitLvl1, int? unitLvl2, int? unitLvl3, int? unitLvl4)
    //    {
    //        bool ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.CanConvert(unitID, unitLvl1, unitLvl2, unitLvl3, unitLvl4);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData()
        {

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            ProductInfomation proInfo = JsonConvert.DeserializeObject<ProductInfomation>(strParameterData);

            try
            {
                obj.SaveData(proInfo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage ChangePackage(int productID, int packageID)
    //    {
    //        try
    //        {
    //            obj.ChangePackage(productID, packageID);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK);
    //    }
        
    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage DuplicateProduct(int productID, string productCode, string productName)
    //    {
    //        try
    //        {
    //            obj.DuplicateProduct(productID, productCode, productName);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK);
    //    }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int ProductID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData(int? ProductID, string CurrentUser)
        {
            //bool ResultReturn;

            //string strParameterData = Request.Content.ReadAsStringAsync().Result;
            //int? ProductID = JsonConvert.DeserializeObject<int>(strParameterData);

            try
            {
                obj.DeleteData(ProductID, CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    //    [HttpPost, HttpGet, APIAuthorize]
    //    public HttpResponseMessage CanAddMorePackage(int currentPackageCount)
    //    {
    //        bool ResultReturn;

    //        try
    //        {
    //            ResultReturn = obj.CanAddMorePackage(currentPackageCount);
    //        }
    //        catch (Exception ex)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
    //    }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadMaterial(int? ProductID)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.LoadMaterial(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadComboBoxData()
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.LoadComboBoxData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}