using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// UCheck Dao
    /// </summary>
    public interface IPFMDAO00020 : IDataRepository<PFMORM00020>
    {
        bool UpdateUsedChequeNo(string AccountNo, string ChequeNo, string SourceBranchCode, int UpdatedUserId);
        IList<PFMDTO00020> GetUCheckData(DateTime startDate,DateTime endDate,string branch);
        IList<PFMDTO00020> SelectUchequeByAccountNoChequeNo(string accountNo, string chequeNo, string activeBranch);
        bool DeletefromUCheckbyId(int id, int UpdatedUserId);
    }
}