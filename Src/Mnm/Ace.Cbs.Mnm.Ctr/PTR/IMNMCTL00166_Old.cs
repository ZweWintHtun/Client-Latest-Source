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
