using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Rubix.Framework;

namespace CSI.Business
{
    public class BusinessCommon
    { 
        public static string GetMessage(string locale, string messageId)
        {
            return Rubix.Framework.Util.GetGlobalText(messageId);
            //return Database.GetMessage(locale, messageId);
        }

        public static string GetMessage(string locale, string messageId, string DefaultMessage)
        {
            string strReturnMessage = Rubix.Framework.Util.GetGlobalText(messageId);
            if (strReturnMessage.Contains("NO MSG ID"))
            {
                return DefaultMessage;
            }
            else
            {
                return Rubix.Framework.Util.GetGlobalText(messageId);
            }
            //return Database.GetMessage(locale, messageId);
            //The username or password is incorrect. Please try again.
        }       
    }
}

