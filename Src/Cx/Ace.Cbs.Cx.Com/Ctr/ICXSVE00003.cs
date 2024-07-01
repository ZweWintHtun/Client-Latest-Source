using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Printing Service Interface
    /// </summary>
    public interface ICXSVE00003
    {
        ICXDAO00003 PrintingDAO { get; set; }

        IList<PFMDTO00014> PrintCheque_SelectAll();
       // void PrintCheque_Update(PFMORM00014 entity);
        void PrintCheque_Save(PFMDTO00014 entity);
        void PrintCheque_Delete(IList<PFMDTO00014> itemList);
        PFMDTO00014 PrintCheque_SelectByPrintChequeId(int id);        
        void PRNFile_Save(PFMDTO00043 entity);
        void PRNFile_Update(PFMDTO00043 entity);
        void PRNFile_Delete(IList<PFMDTO00043> itemList);
        PFMDTO00043 PRNFile_SelectByPRNFileId(int id);
        IList<PFMDTO00043> PRNFile_SelectAll();
       IList<PFMDTO00043> PRNFile_SelecByAccountNo(string accountNo);
       IList<PFMDTO00058> FPRNFile_SelecByAccountNo(string accountNo);
       void FPRNFile_Delete(IList<PFMDTO00058> itemList);
       bool DeletePrnFileByAccountNo(string accountNo);
       bool DeleteFPrnFileByAccountNo(string accountNo);
        
       IList<PFMDTO00043> SelectPrnFileByAccountNos(string[] accountNos);
       IList<PFMDTO00058> SelectFPrnFileByAccountNos(string[] accountNos);
       bool UpdateDataAfterPrintingForCS(string accountNo, decimal printLineNo,int updatedUserId);
       bool UpdateDataAfterPrintingForFixed(string accountNo, decimal printLineNo,int updatedUserId);
    }
}
