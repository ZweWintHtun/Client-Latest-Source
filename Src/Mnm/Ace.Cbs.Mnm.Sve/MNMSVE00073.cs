using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00073 : BaseService, IMNMSVE00073
    {
        #region Properties

        ICXDAO00009 ViewDAO { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Main Method      

        public IList<PFMDTO00042> GetReportDataListForPOAndIR(DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate,string sourceBranchCode)
        {
            return PrintDataList = ViewDAO.SelectPOAndIR_RegisterAndWithdrawalListing(startDate, endDate, formName, IsTransactionDate,sourceBranchCode);
        }
       
        #endregion

       
    }
}
