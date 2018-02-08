using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.Business.DataObjects
{
    public class ConfirmDetail
    {
        public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> Data { get; set; }
        public string ReceivingNo { get; set; }
        public DateTime? ReceivingDate { get; set; }
        public int? NoOfPallet { get; set; }
        public bool IsConfirmCompletely { get; set; }
        public int Installment { get; set; }

        public ConfirmDetail()
        {
            this.Data = new List<sp_CRCS051_ConfirmReceivingDetail_Get_Result>();
            this.NoOfPallet = null;
            this.ReceivingNo = null;
            this.ReceivingDate = null;
            this.IsConfirmCompletely = false;
        }
    }
}
