using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Collections;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Rubix.AutoUpdate
{
    public class RubixWebAPI 
    {
        #region Member
        private static WebClient _client = null;
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
        public static WebClient RubixWebClient
        {
            get
            {
                _strResult = string.Empty;
                _client = null;
                _client = new WebClient();

                _client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                _client.Encoding = Encoding.UTF8;
                _client.Encoding = UTF8Encoding.UTF8;

                IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                _client.Proxy = defaultWebProxy;
                _client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Security.ValidateCertificate);
                
                return _client;
            }
        }
                        
        public static string MainRubixAutoUpdateURL
        {
            get
            {
                return AppConfig.RubixAutoUpdateURL + "api/";
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
                                strReturn = string.Format("{0}={1}", item, HttpUtility.UrlEncode(Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt")));
                            }
                            else
                            {
                                strReturn = string.Format("{0}={1}", item, HttpUtility.UrlEncode(hs[item].ToString()));
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
                                strReturn = string.Format("{0}&{1}={2}", strReturn, item, HttpUtility.UrlEncode(Convert.ToDateTime(hs[item]).ToString("yyyy/MM/dd hh:mm:ss tt")));
                            }
                            else
                            {
                                strReturn = string.Format("{0}&{1}={2}", strReturn, item, HttpUtility.UrlEncode(hs[item].ToString()));
                            }
                        }
                    }
                }
                strReturn = "?" + strReturn;
            }
            return strReturn;
        }
                
        public static string ExecuteAutoUpdateObjectResult(string Module, Hashtable hs = null)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixAutoUpdateURL + Module + GenerateParameter(hs), "POST", "");

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

        public static string ExecuteAutoUpdateObjectResult(string Module, string DataParameter)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixAutoUpdateURL + Module, "POST", DataParameter);

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

    public class Security
    {
        public static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
