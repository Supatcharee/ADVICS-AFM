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
using CSI.Business.Master;


namespace RubixWebAPI.Controllers.Master
{
    public class CalendarShippingController : ApiController
    {
        CalendarShipping obj = new CalendarShipping();

        struct ShippingCalendarGenerate
        {
            public int OwnerID;
            public int CustomerID;
            public int NoOfMonth;
            public string DateDefault;
            public string CreateUser;
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadShippingCalendar(int OwnerID, int CustomerID, DateTime SelectedMonth)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.LoadShippingCalendar(OwnerID, CustomerID, SelectedMonth);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GenerateShippingCalendar()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                ShippingCalendarGenerate stc = JsonConvert.DeserializeObject<ShippingCalendarGenerate>(strParameterData);

                obj.GenerateShippingCalendar(stc.OwnerID, stc.CustomerID, stc.NoOfMonth, stc.DateDefault, stc.CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData(string CreateUser)
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                obj.SaveData(strParameterData, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
