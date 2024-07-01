using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Printing Dao Interface
    /// </summary>
    public interface ICXDAO00003 : IDataRepository<PFMORM00014>
    {
        IList<PFMDTO00014> PrintCheque_SelectAll();
        PFMDTO00014 PrintCheque_SelectByPrintChequeId(int id);
        PFMORM00043 PRNFile_Save(PFMORM00043 entity);
        void PRNFile_Update(PFMORM00043 entity);
        void PRNFile_Delete(PFMORM00043 entity);
        IList<PFMDTO00043> PRNFile_SelectAll();
        PFMDTO00043 PRNFile_SelectByPRNFileId(int id);
        void FPRNFile_Delete(PFMORM00058 entity);
        IList<PFMDTO00043> PRNFile_SelectByAccountNo(string accountNo);
        IList<PFMDTO00058> FPRNFile_SelectByAccountNo(string accountNo);
        bool DeletePrnFileByAccountNo(string accountNo);
        bool DeleteFPrnFileByAccountNo(string accountNo);
        decimal GetPrintLineforAccountNo(string accountNo);
        decimal GetPrintLineforFixedAccountNo(string accountNo);
        bool UpdatePrintLineForCS(string accountNo, decimal lineNo,int updatedUserId);
        bool UpdatePrintLineForFixed(string accountNo, decimal lineNo,int updatedUserId);
    }
}
