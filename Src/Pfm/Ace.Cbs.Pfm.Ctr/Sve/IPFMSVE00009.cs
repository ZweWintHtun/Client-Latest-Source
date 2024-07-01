using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00009
    {
        IPFMDAO00043 PrnDAO { get; set; }
        IPFMDAO00058 FPrnDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00023 FledgerDAO { get; set; }

        void SavePrnFile( PFMDTO00043 PrnFile);
        void SaveFPrnFile( PFMDTO00058 FPrnFile);
        void UpdatePrintLineNumber(string accountNo, int lineCount, bool isFixedAccount, int updatedUserId);
        int SelectPrintLineNumberByAccountNo(string accountNo,bool isFixedAccount);
        IList<PFMDTO00043> GetPrnFileByAccountNo(string accountNo);
        IList<PFMDTO00058> GetFPrnFileByAccountNo(string accountNo);
        void DeletePrnFile(IList<PFMDTO00043> PrnFiles,List<string[]> printedList);
        void DeleteFPrnFile(IList<PFMDTO00058> FPrnFiles,List<string[]> printedList);
    }
}