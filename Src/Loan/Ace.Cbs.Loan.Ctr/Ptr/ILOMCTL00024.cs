using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00024 : IPresenter
    {
        ILOMVEW00024 LoanVoucherView { set; get; }
        void Save(TLMDTO00018 loanDto, IList<PFMDTO00072> acctnoInfoList, string sourceBr);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ILOMVEW00024
    {
        ILOMCTL00024 Controller { set; get; }
        string LoanNo { get; set; }
        string Currency{get;set;}
        string EntryNo{get;set;}
        decimal SanctionAmount { get; set; }
        decimal PartialAmount{get;set;}
        IList<PFMDTO00072> acctInfoList { get; set; }
        void BindAccountInfo(IList<PFMDTO00072> accountInfoList);
        void Successful(string message, string voucherNo);
        void ClearControls();
        bool isSCharge { get; set; }
    }
}
