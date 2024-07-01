using System;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00152 : BaseService, IMNMSVE00152
    {   
        #region Properties
        ICXDAO00009 ViewDAO { get; set; }
        IList<MNMDTO00077> PrintDataList { get; set; }
        #endregion
        #region Main Method

        public IList<MNMDTO00077> GetReportFixedAutoRenewalOnlyPrinciple(DateTime startDate, DateTime endDate,string cur, string status,string sourceBr, string formName)
        {
            if (formName.Contains("Fixed Auto Renewal All Listing"))
            {
                return PrintDataList = ViewDAO.SelectByFixedAutoRenewalAll(startDate, endDate, cur, sourceBr);
            }
            else
            {
                return PrintDataList = ViewDAO.SelectByFixedAutoRenewalListing(startDate, endDate, cur, status, sourceBr, formName);

            }
        }

        #endregion

    }
}
