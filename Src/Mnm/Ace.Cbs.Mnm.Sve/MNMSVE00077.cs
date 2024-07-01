using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00077 : BaseService , IMNMSVE00077
    {
        ICXDAO00009 ViewDAO { get; set; }        
        IList<TLMDTO00017> PrintDrawingRemittanceList { get; set; }
        IList<TLMDTO00001> PrintEncashRemittanceList { get; set; }

        #region Main Method
        public IList<TLMDTO00017> GetDrawingRemittanceListing(TLMDTO00001 dataDTO)
        {
            if (dataDTO.Status == "0")
            {
                PrintDrawingRemittanceList = ViewDAO.SelectDailyDrawingRemittanceListing_ByTransactionDate(dataDTO.RequiredDate, dataDTO.Ebank, dataDTO.SourceBranchCode);
            }
            else
            {
                PrintDrawingRemittanceList = ViewDAO.SelectDailyDrawingRemittanceListing_BySettlementDate(dataDTO.RequiredDate, dataDTO.Ebank,dataDTO.SourceBranchCode);
            }
            return PrintDrawingRemittanceList;              
        }

        public IList<TLMDTO00001> GetEncashRemittanceListing(TLMDTO00001 dataDTO)
        {
            if (dataDTO.Status == "0")
            {
                PrintEncashRemittanceList = ViewDAO.SelectDailyEncashRemittanceListing_ByTransactionDate(dataDTO.RequiredDate, dataDTO.Ebank, dataDTO.SourceBranchCode);
            }
            else
            {
                PrintEncashRemittanceList = ViewDAO.SelectDailyEncashRemittanceListing_BySettlementDate(dataDTO.RequiredDate, dataDTO.Ebank, dataDTO.SourceBranchCode);
            }
            return PrintEncashRemittanceList;
        }
        #endregion
    }
}
