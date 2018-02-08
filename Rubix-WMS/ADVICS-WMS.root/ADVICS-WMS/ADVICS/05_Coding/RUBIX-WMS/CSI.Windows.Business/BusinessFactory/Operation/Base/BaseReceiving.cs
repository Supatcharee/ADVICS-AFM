/*
 20121225: 
 * 1. Modify return type for function GetPalletList to List<>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Operation.Base
{
    public class BaseReceiving : Business.BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_CRCS020_StoringInstruction_Pallet_Search_Result> GetPalletList(string receivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("receivingNo", receivingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("BaseReceiving/GetPalletList", hs);
                return JsonConvert.DeserializeObject<List<sp_CRCS020_StoringInstruction_Pallet_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetContext()
        {
            //do nothing
        }

        public int GetReceivingCompleteStatusID()
        {
            return 6;
        }

        public int GetReceivingIncompleteStatusID()
        {
            return 5;
        }

        public int GetReceivingEntryStatusID()
        {
            return 3;
        }

    }
}
