using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00166 : IBaseService
    {
        IList<PFMDTO00054> Check_EntryNo_Valid(string groupNo, string eno, string sourceBr);
        string Save_Reversal(string eno, string groupNo, int currentUserID, string sourceBr, TLMDTO00015 CashDenoDTO);
        IList<PFMDTO00043> SelectPrnFileByAccountNo(string accountNo);

        decimal SelectGroupAmountForMultipleReversal(string groupNo, string sourceBr);
        string Check_GroupNo_ValidOrNot_MultipleDepReversal(string groupNo, string sourceBr);//Added By AAM (19-Jan-2018)
        //string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr);//Added By AAM (22-Jan-2018)
        //string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr, string groupNo);//Updated By ZMS (15.11.18)
        IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourcebr);//added by HMW (29-May-2019) for reversal check of "Seperating EOD Process"
        bool CheckInfoBeforeReversal(DateTime txnSettlementDate, string sourceBr);//added by HMW (29-May-2019) for reversal check of "Seperating EOD Process"
        string Check_EntryNo_ValidOrNot_MultipleDepWdwReversal(string groupNo, string eno, string sourceBr);//added by HMW (29-May-2019) for reversal check of "Seperating EOD Process"
    }
}