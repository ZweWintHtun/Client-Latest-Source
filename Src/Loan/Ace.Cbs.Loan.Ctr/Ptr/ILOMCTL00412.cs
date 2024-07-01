using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00412 :IPresenter
    {
        ILOMVEW00412 View { get; set; }
        void Print();
        IList<TLMDTO00018> GetBusinessLNo(string sourceBr);
        bool CheckBusinessLoansAccountNo(string acctNo);//Added by HWKO (22-Nov-2017)
    }
    public interface ILOMVEW00412
    {
        ILOMCTL00412 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        //string BLNo { get; set; }//Commented by HWKO (22-Nov-2017)
        string BudgetYear { get; set; }
        string AcctNo { get; set; }//Added by HWKO (22-Nov-2017)
    }
}
