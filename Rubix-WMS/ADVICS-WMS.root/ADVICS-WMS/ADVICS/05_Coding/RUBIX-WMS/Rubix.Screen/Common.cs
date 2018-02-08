using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Rubix.Screen.Form.Master.Dialog;
using System.Data;

namespace Rubix.Screen
{
    public class Common
    {
        public enum eScreenMode
        {
            View,
            Add,
            Edit
        }

        public static String DecimalFormat
        {
            get { return "#,##0"; }
        }

        public static String QtyEditMaskFormat
        {
            get { return "###,###,###,###,##0.000"; }
        }

        public static String QtyFormat
        {
            get { return "###,###,###,###,##0.000"; }
        }
        public static String QtyReportFormat
        {
            get { return "###,###,###,###,##0.00"; }
        }
        public static String VolumeFormat
        {
            get { return "###,###,###,###,##0.00000"; }
        }

        public static String AmountFormat
        {
            get { return "###,###,###,###,##0.00"; }
        }

        public static String PercentFormat
        {
            get { return "###,###,###,###,##0.00"; }
        }

        public static String TimeFormat
        {
            get { return "HH:mm"; }
        }

        public static String FullDateFormat
        {
            get { return "dd/MM/yyyy"; }
        }

        public static String FullDatetimeFormat
        {
            get { return "dd/MM/yyyy HH:mm"; }
        }

        public static String FullDateTimeFormatForExportFile
        {
            get { return "ddMMyyyy_hhmmss"; }
        }

        public static String ExceptionPrefixFile
        {
            get { return "Error"; }
        }

        public static string GetMessage(string messageId, params string[] args)
        {
            if (args.Length > 0)
            {

                return Rubix.Framework.Util.GetGlobalText(messageId, "", args);
                //return string.Format(CSI.Business.Database.GetMessage(Rubix.Framework.AppConfig.Locale, messageId), args);
            }
            else
            {
                return Rubix.Framework.Util.GetGlobalText(messageId);
                //return CSI.Business.Database.GetMessage(Rubix.Framework.AppConfig.Locale, messageId);
            }
        }

        public static string GetMessageWithDefault(string messageId, string DefaultMsg)
        {
            return Rubix.Framework.Util.GetGlobalText(messageId, DefaultMsg);
        }

        public static Color EditableCellColor()
        {
            return Color.LightSalmon;
        }

        public static Color CompleteColor()
        {
            return Color.LightSalmon;
        }
        public static Color CannotCancelColor()
        {
            return Color.LightGray;
        }
        public static Color OrderCancelColor()
        {
            return Color.IndianRed;
        }
        public static Color StockOutColor()
        {
            return Color.LightSalmon;
        }

        public static Color ReadOnlyCellColor()
        {
            return Color.White;
        }

        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public static DataTable InitialDataTableUserControl()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("UserControlName", typeof(string));
            dt.Columns.Add("ScreenName", typeof(string));

            dr = dt.NewRow();
            dr["UserControlName"] = "ownerControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS010_Owner";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "customerControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS270_Customer";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "supplierControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS030_Supplier";
            dt.Rows.Add(dr);

            /////////////////////////////////////////////////////////////
            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseControlLocationDesigner";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseControlLocationLabel";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseFromControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseToControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "warehouseControl2";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS040_Warehouse";
            dt.Rows.Add(dr);
            ////////////////////////////////////////////////////////////
            dr = dt.NewRow();
            dr["UserControlName"] = "zoneControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS120_Zone";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "zoneControlLocationDesigner";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS120_Zone";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "zoneControlLocationLabel";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS120_Zone";
            dt.Rows.Add(dr);
            ////////////////////////////////////////////////////////////
            dr = dt.NewRow();
            dr["UserControlName"] = "shippingAreaControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS150_ShippingArea";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "portControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS090_PortInfo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "portOfDischarge";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS090_PortInfo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "portOfLoading";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS090_PortInfo";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "finalDestinationControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS070_FinalDestination";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "itemGroupControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS250_ItemGroup";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "itemControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS050_Item";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "itemConditionControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS110_ItemCondition";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "itemClassificationControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS240_ItemClassification";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "transportTypeControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS130_TransportType";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserControlName"] = "truckCompanyControl";
            dr["ScreenName"] = "Rubix.Screen.Form.Master.frmXMSS020_TruckCompany";
            dt.Rows.Add(dr);

            dt.AcceptChanges();

            return dt;
        }

        public static void SetEnableAddToUserControl(System.Windows.Forms.Control[] controls, bool CanAdd)
        {
            foreach (System.Windows.Forms.Control selectControl in controls)
            {
                if (selectControl is Rubix.Control.OwnerControl)
                {
                    dlgXMSS010_Owner xfrm = new dlgXMSS010_Owner();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.OwnerControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.OwnerControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.CustomerControl)
                {
                    dlgXMSS270_Customer xfrm = new dlgXMSS270_Customer();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.CustomerControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.CustomerControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.SupplierControl)
                {
                    dlgXMSS030_Supplier xfrm = new dlgXMSS030_Supplier();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.SupplierControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.SupplierControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.WarehouseControl)
                {
                    dlgXMSS040_Warehouse xfrm = new dlgXMSS040_Warehouse();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.WarehouseControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.WarehouseControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ZoneControl)
                {
                    dlgXMSS120_Zone xfrm = new dlgXMSS120_Zone();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ZoneControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ZoneControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ShippingAreaControl)
                {
                    dlgXMSS150_ShippingArea xfrm = new dlgXMSS150_ShippingArea();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ShippingAreaControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ShippingAreaControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.PortControl)
                {
                    dlgXMSS090_Port xfrm = new dlgXMSS090_Port();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.PortControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.PortControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.PortOfDischarge)
                {
                    dlgXMSS090_Port xfrm = new dlgXMSS090_Port();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.PortOfDischarge).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.PortOfDischarge).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.PortOfLoading)
                {
                    dlgXMSS090_Port xfrm = new dlgXMSS090_Port();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.PortOfLoading).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.PortOfLoading).AddNewForm = xfrm;
                }

                else if (selectControl is Rubix.Control.FinalDestinationControl)
                {
                    dlgXMSS070_FinalDestination xfrm = new dlgXMSS070_FinalDestination();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.FinalDestinationControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.FinalDestinationControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ItemGroupControl)
                {
                    dlgXMSS250_ItemGroup xfrm = new dlgXMSS250_ItemGroup();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ItemGroupControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ItemGroupControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ItemControl)
                {
                    dlgXMSS050_Item xfrm = new dlgXMSS050_Item();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ItemControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ItemControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ItemConditionControl)
                {
                    dlgXMSS110_ItemCondition xfrm = new dlgXMSS110_ItemCondition();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ItemConditionControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ItemConditionControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.ItemClassificationControl)
                {
                    dlgXMSS240_ItemClassification xfrm = new dlgXMSS240_ItemClassification();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.ItemClassificationControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.ItemClassificationControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.TransportTypeControl)
                {
                    dlgXMSS130_ContainerType xfrm = new dlgXMSS130_ContainerType();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.TransportTypeControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.TransportTypeControl).AddNewForm = xfrm;
                }
                else if (selectControl is Rubix.Control.TruckCompanyControl)
                {
                    dlgXMSS020_TruckCompany xfrm = new dlgXMSS020_TruckCompany();
                    xfrm.ScreenMode = Common.eScreenMode.Add;
                    (selectControl as Rubix.Control.TruckCompanyControl).IsShowAddNewButton = CanAdd;
                    (selectControl as Rubix.Control.TruckCompanyControl).AddNewForm = xfrm;
                }
            }
        }

        public static int? GetDefaultOwnerID()
        {
            if (Rubix.Framework.AppConfig.DefaultOwnerID == null || Rubix.Framework.AppConfig.DefaultOwnerID <= 0)
            {
                return -1;
            }
            else
            {
                return Rubix.Framework.AppConfig.DefaultOwnerID;
            }
        }

        public static int? GetDefaultWarehouseID()
        {
            if (Rubix.Framework.AppConfig.DefaultWarehouseID == null || Rubix.Framework.AppConfig.DefaultWarehouseID <= 0)
            {
                return -1;
            }
            else
            {
                return Rubix.Framework.AppConfig.DefaultWarehouseID;
            }
        }
    }
}
