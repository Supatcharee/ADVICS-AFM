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

namespace CSI.Business.BusinessFactory.Operation.Base
{
    public class BaseReceiving : Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Members
        protected O_BC_ReceivingModelContainer _context = null;
        #endregion

        #region Properties
        protected new O_BC_ReceivingModelContainer Context
        {
            get
            {
                if (_context == null)
                {
                    _context = CSI.Business.Database.ReceivingContext;
                }
                return _context;
            }
        }
        #endregion
        
        public List<sp_CRCS020_StoringInstruction_Pallet_Search_Result> GetPalletList(string receivingNo)
        {
            return Context.sp_CRCS020_StoringInstruction_Pallet_Search(receivingNo: receivingNo).ToList();
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
