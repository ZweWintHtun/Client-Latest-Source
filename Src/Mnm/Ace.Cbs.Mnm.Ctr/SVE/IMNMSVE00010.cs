using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00010:IBaseService
    {
        IList<PFMDTO00054> Check_EntryNo_Valid(string eno, string sourceBr);     
        string Save_Reversal(string eno, string groupNo, int currentUserID, string sourceBr,TLMDTO00015 CashDenoDTO);
        IList<PFMDTO00043> SelectPrnFileByAccountNo(string accountNo);  //added by ASDA
        IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourcebr);//added by HMW for reversal check of "Seperating EOD Process"
        bool CheckInfoBeforeReversal(DateTime txnSettlementDate,string sourceBr);//added by HMW for reversal check of "Seperating EOD Process"
    }
}
