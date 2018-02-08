using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using CSI.Business.BusinessFactory.Master;

namespace RubixWebAPI.Controllers.Master
{
    public class PalletController : ApiController
    {
        //
        // GET: /Pallet/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        Pallet obj = new Pallet();

        struct stcPalletDetail
        {
            public int? PalletID;
            public string PalletCode;
            public string PalletName;
            public decimal Length;
            public decimal Width;
            public decimal Height;
            public decimal? M3;
            public decimal? WeightLimit;
            public string Remark;
            public string CurrentUser;

        }

        

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(string PalletCode, string PalletName)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(PalletCode, PalletName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistPalletCode(String PalletCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistPalletCode(PalletCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                stcPalletDetail stc = JsonConvert.DeserializeObject<stcPalletDetail>(strParameterData);
                obj.PalletID = stc.PalletID;
                obj.PalletCode = stc.PalletCode;
                obj.PalletName = stc.PalletName;
                obj.Length = stc.Length;
                obj.Width = stc.Width;
                obj.Height = stc.Height;
                obj.M3 = stc.M3;
                obj.WeightLimit = stc.WeightLimit;
                obj.Remark = stc.Remark;
                obj.CurrentUser = stc.CurrentUser;

                obj.SaveData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                int stc = JsonConvert.DeserializeObject<int>(strParameterData);
                obj.PalletID = stc;

                obj.DeleteData();

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int PalletID)
        {
            obj.PalletID = PalletID;
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
