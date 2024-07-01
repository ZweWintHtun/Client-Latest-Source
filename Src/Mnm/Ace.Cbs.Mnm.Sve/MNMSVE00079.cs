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
    public class MNMSVE00079 : BaseService, IMNMSVE00079
    {
        #region Properties

        ICXDAO00009 ViewDAO { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion



        #region Main Method

        public IList<PFMDTO00042> GetReportDataPOWithdrawlEncash(DateTime startDate, DateTime endDate, string formName, string sourceBranchCode)
        {
            return PrintDataList = ViewDAO.SelectPOWithdrawalEncashListing(startDate, endDate, formName, sourceBranchCode);
        }

        #endregion
    }
}
