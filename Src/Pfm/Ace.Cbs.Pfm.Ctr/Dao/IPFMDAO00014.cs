using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00014 : IDataRepository<PFMORM00014>
    {
        //PrintCheque Dao Interface

        IList<PFMDTO00014> SelectByChequeBookNo(string accountNo, string chequeBookNo);
        IList<PFMDTO00014> SelectPrintedChequeByDate(DateTime startDate, DateTime endDate,string branch);
        IList<PFMDTO00014> SelectPrintedChequeByAccount(string accountNo,string branch);
        PFMDTO00006 CheckStartChequeNo(string accountNo, string chequeNo, string startNo, string branch);
        PFMDTO00006 CheckEndChequeNo(string accountNo, string chequeNo, string endNo, string branch);

    }
}