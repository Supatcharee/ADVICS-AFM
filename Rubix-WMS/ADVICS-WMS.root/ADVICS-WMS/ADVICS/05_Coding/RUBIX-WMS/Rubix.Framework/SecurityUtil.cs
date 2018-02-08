using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubix.Framework
{
    public class Permission
    {
        public const string OpenScreen = "Open Screen";
        public const string Add = "Add";
        public const string Edit = "Edit";
        public const string Delete = "Delete";
        public const string Print = "Print";
        public const string Export = "Export";
        public const string Import = "Import";
        public const string OpenReport = "Open Report";
        public const string Confirm = "Confirm";
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ScreenPermissionAttribute : Attribute
    {
        private string[] m_permissions = null;
        public ScreenPermissionAttribute(params string[] perms)
        {
            m_permissions = perms;
        }
        /// <summary>
        /// ใช้ Constructor นี้สำหรับ VB เพราะว่า VB ไม่สามารถ pass Parameter ของ Attribute ที่เป็น Param Array ได้
        /// </summary>
        /// <param name="strPerm"></param>
        public ScreenPermissionAttribute(string strPerm)
        {
            m_permissions = new string[] { strPerm };
        }
        public string[] PermissionItems
        {
            get
            {
                return m_permissions;
            }
        }
    }
    //public class SecurityUtil
    //{
    //    Database m_db = null;
    //    public SecurityUtil(Database db)
    //    {
    //        m_db = db;
    //    }

    //    public bool CheckPermission(Type formType, string strUser, string strPermName)
    //    {
    //        //			string strClassName = formType.Namespace + "." + formType.Name;
    //        //			DataRequest req = new DataRequest("select count(*) from tb_DPSecurityMatch where 
    //        return true;
    //    }

    //    public string[] LoadPermission(Type formType)
    //    {
    //        object[] att = formType.GetCustomAttributes(typeof(ScreenPermissionAttribute), true);
    //        ArrayList arItems = new ArrayList();
    //        foreach (object o in att)
    //        {
    //            if (o is ScreenPermissionAttribute)
    //            {
    //                string[] perms = ((ScreenPermissionAttribute)o).PermissionItems;
    //                foreach (string p in perms)
    //                {
    //                    if (!arItems.Contains(p))
    //                    {
    //                        arItems.Add(p);
    //                    }
    //                }
    //            }
    //        }
    //        string[] result = new string[arItems.Count];
    //        arItems.CopyTo(result);
    //        return result;
    //    }
    //}
}
