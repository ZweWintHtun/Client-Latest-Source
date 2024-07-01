using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;

using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Ser.Sve;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00047 : BaseService, ITLMSVE00047
    {
        public ICXDAO00009 ViewDAO { get; set; }


        public IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branchCode, string sourcebranc)
        {
            IList<TLMDTO00004> ibltlfDTOList = this.ViewDAO.HomeOnlineTransactionListingByAllBranch(startDate, endDate, branchCode, sourcebranc);

            if (ibltlfDTOList == null || ibltlfDTOList.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // No Data for Report
                return ibltlfDTOList;
            }
            else
                return ibltlfDTOList;
        }

        public IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate,string branchCode,string sourcebranc,string forReversalCase)
        {
            IList<TLMDTO00004> ibltlfDTOList = null;
            if (forReversalCase == null)
            {
               ibltlfDTOList = this.ViewDAO.ActiveOnlineTransactionListingByAllBranch(startDate, endDate,branchCode, sourcebranc);
            }
            if (forReversalCase != null)
            {
                ibltlfDTOList = this.ViewDAO.ActiveOnlineTransactionListingByAllBranchForReversal(startDate, endDate,branchCode, sourcebranc);
            }
            if  (ibltlfDTOList == null || ibltlfDTOList.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // No Data for Report
                return ibltlfDTOList;
            }
            else
                return ibltlfDTOList;
        }
    }
}
