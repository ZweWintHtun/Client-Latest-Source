using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00028 : IPresenter
    {
        ILOMVEW00028 View { get; set; }
        void Save(); 
    }
    public interface ILOMVEW00028
    {
        ILOMCTL00028 Controller { get; set; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string DrAccountNo { get; set; }
        string TypeOfLoan { get; set; }
        string LegalDate { get; set; }
        decimal CurrentBalance { get; set; }
        decimal DepositAmount { get; set; }
        string Status { get; set; }
        void BindNameList(IList<LOMDTO00013> legalList);
        void BindGridView(IList<LOMDTO00013> legalList);
    }
}
