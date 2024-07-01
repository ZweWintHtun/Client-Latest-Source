using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00010:IPresenter
    {
        IMNMVEW00010 View { get; set; }
        void Save();
        void ClearCustomErrorMessage();
        void GetInfoByEntryNo();
        DateTime GetSystemDate(string sourceBr);
    }

    public interface IMNMVEW00010
    {
        IMNMCTL00010 Controller { get; set; }

        string GroupNo { get; set; }
        string EntryNo { get; set; }
        string Narration { get; set; }
        string ParentFormId { get; set; }
        string Status { get; set; }        
        void Failure(string message);
        void Successful(string message);
        void FillData(IList<PFMDTO00054> BindData);
        void EnableDisableControls();
        
    }
}
