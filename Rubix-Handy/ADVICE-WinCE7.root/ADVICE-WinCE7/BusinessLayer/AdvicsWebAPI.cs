using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using Advics.Framework;
using System.Data;
using Newtonsoft.Json;

namespace BusinessLayer
{
    class AdvicsWebAPI
    {
        #region Member
        private static string _strResult = string.Empty;

        private static string AUTErrorMessage = "Your login session has expired.";
        private static string AUTToString = Environment.NewLine +
                                            "- The login session will get expired if user is idle for 24 hrs continuously." +
                                            Environment.NewLine +
                                            "- This Username already be logged on to another computer." +
                                            Environment.NewLine +
                                            Environment.NewLine +
                                            Environment.NewLine;
        #endregion
          
        #region Properties
        public static string MainAdviceURL
        {
            get
            {
                return AppConfig.AdvicsWebApiUrl + "api/";
            }
        }
        #endregion

        private static string GenerateParameter(Hashtable hs)
        {
            string strReturn = string.Empty;
            if (hs != null)
            {
                foreach (String item in hs.Keys)
                {
                    if (strReturn == string.Empty)
                    {
                        if (hs[item] == null)
                        {
                            strReturn = string.Format("{0}={1}", item, hs[item]);
                        }
                        else
                        {
                            if (hs[item] is DateTime)
                            {
                                strReturn = string.Format("{0}={1}", item, Uri.EscapeUriString(Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt")));
                                //strReturn = string.Format("{0}={1}", item, Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt"));
                            }
                            else
                            {
                                strReturn = string.Format("{0}={1}", item, Uri.EscapeUriString(hs[item].ToString()));
                                //strReturn = string.Format("{0}={1}", item, hs[item].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (hs[item] == null)
                        {
                            strReturn = string.Format("{0}&{1}={2}", strReturn, item, hs[item]);
                        }
                        else
                        {
                            if (hs[item] is DateTime)
                            {
                                strReturn = string.Format("{0}&{1}={2}", strReturn, item, Uri.EscapeUriString(Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt")));
                                //strReturn = string.Format("{0}&{1}={2}", strReturn, item, Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt"));
                            }
                            else
                            {
                                strReturn = string.Format("{0}&{1}={2}", strReturn, item, Uri.EscapeUriString(hs[item].ToString()));
                                //strReturn = string.Format("{0}&{1}={2}", strReturn, item, hs[item].ToString());
                            }
                        }
                    }
                }
                strReturn = "?" + strReturn;
            }
            return strReturn;
        }

        public static string RubixWebClient(string Module, Hashtable hs, string DataParameter)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MainAdviceURL + Module + GenerateParameter(hs));
            request.Credentials = CredentialCache.DefaultCredentials;

            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "post";
            
            byte[] postBytes;
            if (!string.IsNullOrEmpty(DataParameter))
            {
                postBytes = Encoding.UTF8.GetBytes(DataParameter);
                request.ContentLength = postBytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();
            }

            WebResponse response = request.GetResponse();           
            Stream dataStream = response.GetResponseStream();           
            StreamReader reader = new StreamReader(dataStream);
            string responseStirng = reader.ReadToEnd();            
            reader.Close();
            response.Close();

            return responseStirng;

        }

        public static string ExecuteObjectResult(string Module)
        {
            try
            {
                _strResult = RubixWebClient(Module, null, null);

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return _strResult;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNAUTHORIZED"))
                {
                    throw new Exception(AUTErrorMessage, new Exception(AUTToString));
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static string ExecuteObjectResult(string Module, Hashtable hs)
        {
            try
            {
                _strResult = RubixWebClient(Module, hs, null);

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return _strResult;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNAUTHORIZED"))
                {
                    throw new Exception(AUTErrorMessage, new Exception(AUTToString));
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static string ExecuteObjectResult(string Module, Hashtable hs, string DataParameter)
        {
            try
            {
                _strResult = RubixWebClient(Module, hs, DataParameter);

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return _strResult;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNAUTHORIZED"))
                {
                    throw new Exception(AUTErrorMessage, new Exception(AUTToString));
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static string ExecuteObjectResult(string Module, string DataParameter)
        {
            try
            {
                _strResult = RubixWebClient(Module, null, DataParameter);

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return _strResult;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UNAUTHORIZED"))
                {
                    throw new Exception(AUTErrorMessage, new Exception(AUTToString));
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
