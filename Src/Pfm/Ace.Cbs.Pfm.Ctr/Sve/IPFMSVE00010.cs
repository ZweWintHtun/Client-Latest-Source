using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00010
    {
        ICXSVE00002 CodeGenerator { get; set; }
        ICXSVE00006 CodeChecker { get; set; }
        IPFMDAO00028 CLedgerDAO { get; set; }
        IPFMDAO00033 BalanceDAO { get; set; }
        IPFMDAO00001 CustomerDAO { get; set; }
        IPFMDAO00016 SAOFDAO { get; set; }
        IPFMDAO00002 CloseBalanceDAO { get; set; }
        IPFMDAO00040 SIDAO { get; set; }
        IPFMDAO00043 PRNFileDAO { get; set; }
        IPFMDAO00054 TLFDao { get; set; }

        object GetBeforeTaxForCredit(string accountNo);
        object GetBeforeTaxForDebit(string accountNo, DateTime openDate);
        IList<PFMDTO00072> GetSavingAccountInfo(string accountNo,string sourceBranchCode);
        void SaveSavingAccountClose(PFMDTO00072 accountClose);
    }
}