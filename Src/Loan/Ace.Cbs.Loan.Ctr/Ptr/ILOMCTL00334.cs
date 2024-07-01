using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00334
    {
        ILOMVEW00334 View { get; set; }

        void Print();
        void Print(IList<LOMDTO00334> selectedCustList);
        bool CheckHPAccountNo(string acctNo);
        IList<LOMDTO00334> BindCustomerList(string sourceBr);
    }

    public interface ILOMVEW00334
    {
        ILOMCTL00334 Controller { get; set; }

        string SourceBranch { get; set; }
        string AcctNo { get; set; }
        DateTime DateFromView { get; set; }
        string ProductName { get; set; }
        string CarNo { get; set; }
        string CarBoardNo { get; set; }
        string NoOfProduct { get; set; }
        string CustNameConcat { get; set; }
        string CustNameCustNRCConcat { get; set; }
        string CustNameCustNRCConcatWithEnter { get; set; }
        string CustNRCConcat { get; set; }
        string CustFatherNameConcat { get; set; }
        string CustAddressForOneConcat { get; set; }
    }
}
