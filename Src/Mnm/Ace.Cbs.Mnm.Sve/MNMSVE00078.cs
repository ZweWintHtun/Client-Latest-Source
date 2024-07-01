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
    public class MNMSVE00078 : BaseService, IMNMSVE00078
    {
        #region Properties
        IList<PFMDTO00042> PrintDataList { get; set; }

        ICXDAO00009 ViewDAO { get; set; }
        #endregion

        #region Main Method

        public IList<PFMDTO00042> GetReportDataListForPORegisterEncash(DateTime startDate, DateTime endDate, string sourceBr)
        {
            return PrintDataList = ViewDAO.SelectPORegisterEncashListing(startDate, endDate, sourceBr);
           //return PrintDataList;
        }

        #endregion



    }

}
