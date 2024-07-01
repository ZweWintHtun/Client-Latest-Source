using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00166:IPresenter
    {
        IMNMVEW00166 View { get; set; }
        void Save();
        void ClearCustomErrorMessage();
        void GetEntryData();
        string Check_GroupNo_ValidOrNot_MultipleDepReversal(string groupNo, string sourceBr);//Added by AAM (19-Jan-2018)
        //string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr);//Added by AAM (22-Jan-2018)
        string Check_EntryNo_ValidOrNot_MultipleDepWdwReversal(string eno, string sourceBr);//Added by HMW (10-Jun-2019)        
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface IMNMVEW00166
    {
        IMNMCTL00166 Controller { get; set; }

        string GroupNo { get; set; }
        string EntryNo { get; set; }
        string Narration { get; set; }
        string AccountNo { get; set; }
        string Cheque { get; set; }
        decimal Amount { get; set; }
        string ParentFormId { get; set; }
        string Status { get; set; }        
        void Failure(string message);
        void Successful(string message);
        void FillData(IList<PFMDTO00054> BindData, IList<PFMDTO00001> CustData);
        void EnableDisableControls();
        void ClearTextBox();
    }
}
