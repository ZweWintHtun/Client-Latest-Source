using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00007 : IPresenter
    {
        ITCMVEW00007 View { get; set; }
        void Save();        
    }

    public interface ITCMVEW00007
    {
        ITCMCTL00007 Controller { get; set; }            
        string EntryNo { get; set; }
        string AccountNo { get; set; }
        string Description { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }  

        void Failure(string message);
        void Successful(string message);
        void FillData(PFMDTO00054 tlfInfo);        
    }
}
