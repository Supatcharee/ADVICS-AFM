using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class TrackingBusiness
    {
        struct StructTrackingSearch
        {
            public string ILabel;
        }

        public DataSet Tracking_Search(string ILabel)
        {
            try
            {
                //Hashtable hs = new Hashtable();
                //hs.Add("ReceivingNo", ReceivingNo);
                //hs.Add("Installment", Installment);
                //string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/ReceivingEntry_SearchBy_ReceivingNo", hs);
                //return JsonConvert.DeserializeObject<DataSet>(strResult);



                StructTrackingSearch stc = new StructTrackingSearch();
                stc.ILabel = ILabel;

                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/Tracking_Search", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
