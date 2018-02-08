using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Rubix.Framework;
using System.Data;
using Newtonsoft.Json;
using System.Collections;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web.Services.Protocols;
using System.Threading;
using System.IO;

namespace CSI.Business
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
        public class CustomWebClient : WebClient
        {
            //time in milliseconds
            private int timeout;
            public int Timeout
            {
                get
                {
                    return timeout;
                }
                set
                {
                    timeout = value;
                }
            }

            public CustomWebClient()
            {
                this.timeout = 1800000;
            }

            public CustomWebClient(int timeout)
            {
                this.timeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var result = base.GetWebRequest(address);
                result.Timeout = this.timeout;
                return result;
            }
        }

        public static WebClient RubixWebClient
        {
            get
            {
                _strResult = string.Empty;
                _client = null;
                _client = new CustomWebClient();

                _client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                _client.Encoding = Encoding.UTF8;
                _client.Encoding = UTF8Encoding.UTF8;

                IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                _client.Proxy = defaultWebProxy;
                _client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(Security.ValidateCertificate);

                if (!CheckWebAPIConnection())
                {
                    throw new Exception(CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0424", "Unable to connect to the server."));
                }

                return _client;
            }
        }

        public static string MainRubixURL
        {
            get 
            {
                return AppConfig.RubixWebApiUrl + "api/";
            }
        }

        public static string MainRubixAuthenURL
        {
            get
            {
                return AppConfig.RubixWebAuthenticate + "api/";
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

        public static DataSet ExecuteDataSet(string Module, Hashtable hs = null)
        {
            try                                                                                     
            {
                _strResult = RubixWebClient.UploadString(MainRubixURL + Module + GenerateParameter(hs), "POST", "");

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return JsonConvert.DeserializeObject<DataSet>(_strResult);
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

        public static DataTable ExecuteDataTable(string Module, Hashtable hs = null)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixURL + Module + GenerateParameter(hs), "POST", "");

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
                }
                else
                {
                    return JsonConvert.DeserializeObject<DataTable>(_strResult);
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

        public static void ExecuteNonQuery(string Module, Hashtable hs = null)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixURL + Module + GenerateParameter(hs), "POST", "");

                if (_strResult.Contains("ErrorException"))
                {
                    DataTable dt = JsonConvert.DeserializeObject<DataTable>(_strResult);
                    throw new Exception(dt.Rows[0]["Message"].ToString(), new Exception(dt.Rows[0]["ToString"].ToString()));
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
        
        public static string ExecuteObjectResult(string Module, Hashtable hs = null)
        {
            try
            {
                //test connection to WebAPI
                //var stream = RubixWebClient.OpenRead(AppConfig.RubixWebApiUrl);
                //RubixWebClient.Dispose();

                _strResult = RubixWebClient.UploadString(MainRubixURL + Module + GenerateParameter(hs), "POST", "");

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
                _strResult = RubixWebClient.UploadString(MainRubixURL + Module + GenerateParameter(hs), "POST", DataParameter);

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
                _strResult = RubixWebClient.UploadString(MainRubixURL + Module , "POST", DataParameter);

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

        public static void UploadFile(string Module, Hashtable hs, byte[] data)
        {
            try
            {
                RubixWebClient.UploadData(MainRubixURL + Module + GenerateParameter(hs), data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DownloadFile(string URLAddress, string SaveFilePathName)
        {
            try
            {
                RubixWebClient.DownloadFile(URLAddress, SaveFilePathName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static string ExecuteAuthenObjectResult(string Module, Hashtable hs = null)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixAuthenURL + Module + GenerateParameter(hs), "POST", "");

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

        public static string ExecuteAuthenObjectResult(string Module, string DataParameter)
        {
            try
            {
                _strResult = RubixWebClient.UploadString(MainRubixAuthenURL + Module, "POST", DataParameter);

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

        private static bool CheckWebAPIConnection()
        {
            try
            {
                int timeout = 120; //millisecond
                System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();

                for (int i = 1; i < 5; i++ )
                {
                    System.Net.NetworkInformation.PingReply reply = pingSender.Send(AppConfig.RubixWebApiAddress, timeout);
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        return true;
                    }
                    Thread.Sleep(500);
                }
                return false;
            }
            catch (Exception ex)
            {
                 return false;
            }
        }
    }

    public class Security
    {
        //public static void initSSL(ref SoapHttpClientProtocol service)
        //{
        //    string cerPart = "C:\\Rubix.cer";
        //    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateCertificate);
        //   X509Certificate cer = X509Certificate.CreateFromCertFile(cerPart);
        //    service.ClientCertificates.Add(cer);
        //}

        public static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
