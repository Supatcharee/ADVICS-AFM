using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business;
using System.Net.Http;
using System.Net;
using Rubix.Framework;
using System.Data;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace RubixAuthentication.Controllers
{
    public class AutoUpdateController : ApiController
    {
        AutoUpdate obj = new AutoUpdate();
        Authentication au = new Authentication();

        [HttpGet]
        public HttpResponseMessage GetCurrentPath()
        {
            return Request.CreateResponse(HttpStatusCode.OK, HttpContext.Current.Request.PhysicalApplicationPath);
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage CheckProgramUpdate(string Serial, string CurrentVersion)
        {
            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.CheckProgramUpdate(Serial, CurrentVersion);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, APIAuthorize]
        public HttpResponseMessage CheckMobileUpdate(string CurrentVersion)
        {
            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.CheckMobileUpdate(CurrentVersion);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, APIAuthorize]
        public HttpResponseMessage LoadUpdateData(string Serial, string CurrentVersion)
        {
            DataSet ResultReturn;
            long dSumFileSize = 0;
            string UpdateFolder = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath,"AutoUpdate");

            try
            {
                ResultReturn = obj.LoadUpdateData(Serial, CurrentVersion);

                DataTable dtFileList = new DataTable();
                dtFileList.Columns.Add("Folder", typeof(string));
                dtFileList.Columns.Add("FileName", typeof(string));
                dtFileList.Columns.Add("FileSize", typeof(long));

                DataTable dtTotalSize = new DataTable();
                dtTotalSize.Columns.Add("AllFileSize", typeof(long));
                
                if (ResultReturn.Tables[1].Rows.Count > 0)
                {
                    string[] AllFiles = Directory.GetFiles(UpdateFolder);
                    foreach (string file in AllFiles)
                    {
                        DataRow drr = dtFileList.NewRow();
                        drr["Folder"] = string.Empty;
                        drr["FileName"] = Path.GetFileName(file);
                        FileInfo fi = new FileInfo(file);
                        dSumFileSize = dSumFileSize + fi.Length;
                        drr["FileSize"] = fi.Length;
                        dtFileList.Rows.Add(drr);
                    }
                }
                
                foreach (DataRow dr in ResultReturn.Tables[1].Rows)
                {
                    if (dr["Folder"] != null && dr["Folder"].ToString().Trim() != string.Empty)
                    {
                        if (Directory.Exists(string.Format("{0}\\{1}", UpdateFolder, dr["Folder"])))
                        {
                            string[] AllFiles = Directory.GetFiles(string.Format("{0}\\{1}", UpdateFolder, dr["Folder"]));
                            foreach (string file in AllFiles)
                            {
                                DataRow drr = dtFileList.NewRow();
                                drr["Folder"] = dr["Folder"].ToString();
                                drr["FileName"] = Path.GetFileName(file);
                                FileInfo fi = new FileInfo(file);
                                dSumFileSize = dSumFileSize + fi.Length;
                                drr["FileSize"] = fi.Length;
                                dtFileList.Rows.Add(drr);
                            }
                        }
                    }
                }

                DataRow drrr = dtTotalSize.NewRow();
                drrr["AllFileSize"] = dSumFileSize;
                dtTotalSize.Rows.Add(drrr);
                
                ResultReturn.Tables.Add(dtTotalSize);
                ResultReturn.Tables.Add(dtFileList);

                ResultReturn.AcceptChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage LoadMobileUpdateData()
        {
            DataSet ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string CurrentVersion = JsonConvert.DeserializeObject<string>(strParameterData);

            string UpdateFolder = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath, "MobileUpdate");


            try
            {
                ResultReturn = obj.LoadMobileUpdateData(CurrentVersion);

                DataTable dtFileList = new DataTable();
                dtFileList.Columns.Add("FileName", typeof(string));

                if (ResultReturn.Tables[0].Rows.Count > 0)
                {
                    string[] AllFiles = Directory.GetFiles(UpdateFolder);
                    foreach (string file in AllFiles)
                    {
                        DataRow drr = dtFileList.NewRow();
                        drr["FileName"] = Path.GetFileName(file);
                        dtFileList.Rows.Add(drr);
                    }
                }

                ResultReturn.Tables.Add(dtFileList);

                ResultReturn.AcceptChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage LoadFileMobileData()
        {
            byte[] ResultReturn = null;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string fileName = JsonConvert.DeserializeObject<string>(strParameterData);

            string UpdateFolderPath = string.Format("{0}{1}", HttpContext.Current.Request.PhysicalApplicationPath, "MobileUpdate");

            try
            {
                if (File.Exists(string.Format("{0}\\{1}",UpdateFolderPath,fileName)))
                {
                    ResultReturn = File.ReadAllBytes(string.Format("{0}\\{1}", UpdateFolderPath, fileName));

                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(ResultReturn));
        }


        [HttpPost, APIAuthorize]
        public HttpResponseMessage LoadForceAutoUpdate()
        {
            int ResultReturn;
            // Parameters
            string Serial = Request.Content.ReadAsStringAsync().Result;
            try
            {
                ResultReturn = Convert.ToInt32(au.LoadDatabaseConfigByCompanyCode(null, Serial).Rows[0]["ForceUpdate"]);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
