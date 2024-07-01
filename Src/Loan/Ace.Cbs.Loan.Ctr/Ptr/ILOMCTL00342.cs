using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00342
    {
        ILOMVEW00342 View { get; set; }

        void Print();
        void Print(IList<LOMDTO00338> DTOListSelectedCust);
        bool CheckBLAccountNo(string acctNo);
        IList<LOMDTO00338> BindCustomerList(string sourceBr);
    }

    public interface ILOMVEW00342
    {
        ILOMCTL00342 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
        DateTime DateFromView { get; set; }

        string BudgetYear { get; set; }
        string InsuranceDesp { get; set; }
        string PartA { get; set; }
        string PartB { get; set; }
        string CustNameCustNRCConcat { get; set; }
        string CustNameCustNRCConcatWithEnter { get; set; }
        string CustNameConcat { get; set; }
        string CustNRCConcat { get; set; }
        string CustFatherNameConcat { get; set; }
        string CustAddressForOneConcat { get; set; }
        string CustNameConcatWithEnter { get; set; }
        
    }
}
