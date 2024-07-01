using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;


namespace Ace.Cbs.Loan.Ctr.Ptr
{

    public interface ILOMCTL00030 : IPresenter
    {
        ILOMVEW00030 View { get; set; }
        string Currency { get; set; }
        bool Save();
        bool GetLoanInformationForRepaymentEdit();
        //void CheckRepayment();
    }

    public interface ILOMVEW00030
    {
        ILOMCTL00030 Controller { set; get; }
        
        string LoanNo { set; get; }
        string AccountNo{ set; get; }        
        string LastRepaymentNo{ set; get; }
        decimal LastRepaymentAmount{ set; get; }
        decimal BeforeLastRepaymentSanctionAmount{ set; get; }
        decimal AfterLastRepaymentSanctionAmount{ set; get; }
        decimal AfterNewRepaymentSanctionAmount{ set; get; }
        string CustomerName{ set; get; }
        decimal Interest{ set; get; }
        decimal FirstSanctionAmount { get; set; }
        decimal PrevTotalSanctionAmount { get; set; }
        bool FullSettlement { get; set; }
        decimal NewRepaymentAmount { get; set; }
        string InterestAccountDesp { set; get; }
        string CreditAccountDesp { set; get; }
        string CreditAccountCode { set; get; }
        string InterestAccountCode { set; get; }
        void RepaymentCheck();
    }

}
