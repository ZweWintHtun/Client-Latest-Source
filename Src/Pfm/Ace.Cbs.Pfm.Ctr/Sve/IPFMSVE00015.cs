using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Pfm.Ctr.Sve
{
    /// <summary>
    /// PrintCheque Service Interface
    /// </summary>
    public interface IPFMSVE00015 
    {
        IPFMDAO00014 PrintChequeDAO { get; set; }
        IPFMDAO00006 ChequeDAO { get; set; }
        void Save(IList<PFMDTO00014> printedChequeList);
        PFMDTO00006 SelectStartNoAndEndNoByChequeBookNo(string accountNo, string chequeBookNo);
        IList<PFMDTO00020> SelectUchequeByAccountNoChequeNo(string accountNo, string chequeBookNo, string sourceBr);
      
    }
}