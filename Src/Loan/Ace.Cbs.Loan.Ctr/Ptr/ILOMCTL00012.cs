using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr 
{
    public interface ILOMCTL00012 : IPresenter 
    {
        ILOMVEW00012 View { get; set; }   //OverdraftLimitChangeView
        void Save();
        void ClearCustomErrorMessage();
    }
    public interface ILOMVEW00012 
    {
        ILOMCTL00012 Controller { set; get; }        
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        decimal OverdraftAmount { get; set; } 
        decimal PresentODLimit { get; set; }
        decimal NewODLimit { get; set; }
        decimal TotalODLimit { get; set; }
        decimal NewTotalODLimit { get; set; }
        string Name { set; get; }
        string Status { get; set; }
    }
}
