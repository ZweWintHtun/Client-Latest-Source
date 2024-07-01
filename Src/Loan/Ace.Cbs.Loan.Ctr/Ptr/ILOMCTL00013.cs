//----------------------------------------------------------------------
// <copyright file="IMNMCTL00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> TAK </CreatedUser>
// <CreatedDate>12-01-2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00013 : IPresenter
    {
        ILOMVEW00013 View { get; set; }
        TLMDTO00018 loanDto { get; set; }
        IList<TLMDTO00018> LoansList { get; set; }
        void ClearAllCustomErrors();
        bool ValidateForm();
        TLMDTO00018 SelectByLoanNo(string loanNo);
        IList<PFMDTO00017> SelectCAOFData(string acctNo);
        IList<MNMDTO00012> SelectlegalIntData(string loanNo);
        IList<MNMDTO00011> SelectCommitFeeByLoanNo(string accountNo, string loanNo);
        IList<LOMDTO00021> SelectLIByLoanNo(string accountNo, string loanNo);
        IList<MNMDTO00027> SelectSChargeByLoanNo(string accountNo, string loanNo);
        void Save(TLMDTO00018 loan, IList<PFMDTO00017> caof, IList<MNMDTO00012> legal, IList<MNMDTO00011> commit, IList<LOMDTO00021> li, IList<MNMDTO00027> scharge,
        string cur, DateTime SettlementDate, ChargeOfAccountDTO CoaACName, string creditVoucher, string debitVoucher, string creditTranCode, string debitTranCode,bool isOD,decimal reqAmount);
    }

    public interface ILOMVEW00013
    {
        ILOMCTL00013 Controller { get; set; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string Type { get; set; }
        decimal Amount { get; set; }
        decimal OutstandingInt { get; set; }
        decimal OutstandingChg { get; set; }
        decimal PenlityFees { get; set; }
        decimal ServiceCharges { get; set; }
        decimal CommitmentFees { get; set; }
        decimal Total { get; set; }
        decimal Interest { get; set; }
        void BindInfo(IList<PFMDTO00017> caofList);
    }
}
