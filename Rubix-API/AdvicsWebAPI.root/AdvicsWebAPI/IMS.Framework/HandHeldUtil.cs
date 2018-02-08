using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenNETCF.Desktop.Communication;

namespace Rubix.Framework
{
    public class HandHeldUtil
    {
        public static string MSG_NOT_CONNECT_DEVICE = "Device not connected";

        public static bool IsDriverInstall()
        {
            try
            {
                Activator.CreateInstance("OpenNETCF.Desktop.Communication", "OpenNETCF.Desktop.Communication.RAPI");
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public static void CopyFileToDevice(string localFileName, string remoteFileName)
        {
            RAPI rapi = null;
            try
            {
                rapi = new RAPI();

                if (false == rapi.DevicePresent)
                {
                    throw new ApplicationException(MSG_NOT_CONNECT_DEVICE);
                }

                if (false == rapi.Connected)
                {
                    rapi.Connect();
                }

                rapi.CopyFileToDevice(localFileName, remoteFileName, true);
                rapi.Disconnect();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (rapi != null)
                {
                    if (rapi.Connected)
                        rapi.Disconnect();
                    rapi.Dispose();
                    rapi = null;
                }
            }
        }

        public static void CopyFileFromDevice(string localFileName, string remoteFileName)
        {
            RAPI rapi = null;
            try
            {
                rapi = new RAPI();

                if (!rapi.DevicePresent)
                {
                    throw new ApplicationException(MSG_NOT_CONNECT_DEVICE);
                }

                if (!rapi.Connected)
                {
                    rapi.Connect();
                }

                rapi.CopyFileFromDevice(localFileName, remoteFileName, true);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (rapi != null)
                {
                    if (rapi.Connected)
                        rapi.Disconnect();
                    rapi.Dispose();
                    rapi = null;
                }
            }
        }

        public static void CopyFileOnDevice(string remoteFileName, string dbFilePath)
        {
            RAPI rapi = null;
            try
            {
                rapi = new RAPI();

                if (!rapi.DevicePresent)
                {
                    throw new ApplicationException(MSG_NOT_CONNECT_DEVICE);
                }

                if (!rapi.Connected)
                {
                    rapi.Connect();
                }

                rapi.CopyFileOnDevice(remoteFileName, dbFilePath, true);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (rapi != null)
                {
                    if (rapi.Connected)
                        rapi.Disconnect();
                    rapi.Dispose();
                    rapi = null;
                }
            }
        }

        public static bool IsDevicePresent()
        {
            RAPI rapi = null;
            try
            {
                rapi = new RAPI();
                return rapi.DevicePresent;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (rapi != null)
                {
                    if (rapi.Connected)
                        rapi.Disconnect();
                    rapi.Dispose();
                    rapi = null;
                }
            }
        }

        public static bool IsDeviceConnect()
        {
            RAPI rapi = null;
            try
            {
                if (!rapi.DevicePresent)
                {
                    throw new ApplicationException(MSG_NOT_CONNECT_DEVICE);
                }

                return rapi.Connected;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (rapi != null)
                {
                    if (rapi.Connected)
                        rapi.Disconnect();
                    rapi.Dispose();
                    rapi = null;
                }
            }
        }
    }
}
