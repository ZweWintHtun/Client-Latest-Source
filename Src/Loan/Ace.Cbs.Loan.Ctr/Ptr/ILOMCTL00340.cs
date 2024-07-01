using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00340
    {
        ILOMVEW00340 View { get; set; }

        void Print(IList<LOMDTO00338> DTOListSelectedCust);
        void Print();
        bool CheckBLAccountNo(string acctNo);
        IList<LOMDTO00338> BindCustomerList(string sourceBr);
    }

    public interface ILOMVEW00340
    {
        ILOMCTL00340 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
        DateTime DateFromView { get; set; }
        string BudgetYear { get; set; }

        string Reference_VW { get; set; }
        string Description_VW { get; set; }
        string Place_VW { get; set; }
        decimal Amount_VW { get; set; }
        string InsuranceDesp_VW { get; set; }
        string CustNameCustNRCConcat { get; set; }
    }
}
