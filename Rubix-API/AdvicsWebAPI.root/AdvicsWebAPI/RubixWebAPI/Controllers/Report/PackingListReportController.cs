﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report
{
    public class PackingListReportController : ApiController
    {
        PackingListReport obj = new PackingListReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            List<sp_RPT044_PackingList_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(ShipmentNo, Installment, ContainerNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }       

    }
}