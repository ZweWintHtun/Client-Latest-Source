using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00020
    {
        void DeleteOldPONoByActive(IList<TLMDTO00043> polist, string branchno, int updateUserId);
        bool CheckingChequeNo(string accountNo, string chequeNo, string branch);
        string GetDescriptionByAccountNo(string accountNo);
    }
}
