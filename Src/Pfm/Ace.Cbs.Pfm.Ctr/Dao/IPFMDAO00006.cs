using System;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00006 : IDataRepository<PFMORM00006>
    {
        bool UpdateCloseDate(string accountNo, DateTime closeDate, int updatedUserId);
        PFMDTO00006 CheckStartChequeNo(string accountNo, string startNo, string branch);
        PFMDTO00006 SelectStartNoAndEndNoByChequeBookNo(string accountNo, string chequeBookNo);
        IList<PFMDTO00006> SelectByChequeBookNoByAccountNo(string accountNo);
        PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo, string branchCode);
        bool UpdateChequeInfoByChequeBookNo(string chequeBookNo, string startNo, string endNo, string sourcebr, Nullable<int> updatedUserId, Nullable<DateTime> updatedDate);
        IList<PFMDTO00006> SelectIssuedChequeByDate(DateTime startDate, DateTime endDate,string branch);
        IList<PFMDTO00006> SelectIssuedChequeByAccount(string accountNo,string branch);
        IList<PFMDTO00006> SelectListByChequeBookNoByAccountNo(string accountNo);
    }
}