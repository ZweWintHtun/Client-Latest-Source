//----------------------------------------------------------------------
// <copyright file="ITLMSVE00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00018
    {
        ICXSVE00006 CodeChecker { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        ICXSVE00010 SavingAccountCheck { get; set; }
        ITLMDAO00017 RDDAO { get; set; }
        ITLMDAO00015 CashDenoDAO { get; set; }
        ITLMDAO00009 DepoDenoDAO { get; set; }
        ITLMDAO00029 RemitBrIBLDAO { get; set; }
        IPFMDAO00002 CloseBalanceDAO { get; set; }
        IPFMDAO00020 UCheckDAO { get; set; }

        PFMDTO00001 GetCustomerByAccountNumber(string accountNo,DateTime todaydate);
        bool IsValidTotalAmount(string accountNo, decimal totalAmount, string accountSign);
        bool HasSavingAccountTransaction(string accountNo, int userid);
        bool IsValidChequeNo(string accountNo, string chequeNo, string branchCode);
        PFMDTO00002 CloseAccountValue(string accountNo, bool isIncome);
        IList<TLMDTO00054> Save(TLMDTO00054 remit, IList<TLMDTO00054> drawing);
        CXDTO00009 AmountInformationChecking(string accountno, decimal amount, bool isVIP);
        void Save_DrawingPrinting(IList<TLMDTO00021> drawingPrintingDto);
        TLMDTO00018 SelectByLoanNo(string loanNo, string sourceBr);
        IList<PFMDTO00017> SelectCAOFData(string acctNo);
        IList<MNMDTO00012> SelectlegalIntData(string loanNo);

        IList<MNMDTO00011> SelectCommitFeeByLoanNo(string accountNo,string loanNo);
        IList<LOMDTO00021> SelectLIByLoanNo(string accountNo, string loanNo);
        IList<MNMDTO00027> SelectSChargeByLoanNo(string accountNo, string loanNo);
        void SaveCloseAC(TLMDTO00018 loan, IList<PFMDTO00017> caof, IList<MNMDTO00012> legal, IList<MNMDTO00011> commit, IList<LOMDTO00021> li, IList<MNMDTO00027> scharge,
        string cur, DateTime SettlementDate, ChargeOfAccountDTO CoaACName, string creditVoucher, string debitVoucher, string creditTranCode, string debitTranCode,bool isOD,decimal amount);
    }
}
