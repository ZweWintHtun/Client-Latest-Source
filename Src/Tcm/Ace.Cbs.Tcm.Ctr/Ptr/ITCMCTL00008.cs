using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00008 : IPresenter
    {
        ITCMVEW00008 View { get; set; }
        void ClearControls();
        void Save();
       
       
    }
    
    public interface ITCMVEW00008
    {
        ITCMCTL00008 Controller { get; set; }
        bool IsMainMenu { get; set; }
        string ChequeBookNo { get;set; }
        string AccountNo { get; set; }
        string IssueDate { get; set; }
        string StartNo { get; set; }
        string EndNo { get; set; }
        string SourceBranch { get; set; }
        void Successful(string message);
        void Failure(string message);
        void InitialEnableControls();
  
    }
}
