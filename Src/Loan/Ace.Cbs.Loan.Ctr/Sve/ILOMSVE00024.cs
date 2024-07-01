//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00024 : IBaseService
    {
        IList<PFMDTO00072> SelectLoanInfoByloanNoandSourcebr(string lno, string sourcebr);
        TLMDTO00018 SelectLoanByloanNoandSourcebr(string lno, string sourcebr); 
        string LoanVoucher(TLMDTO00018 loanDto, IList<PFMDTO00072> acctnoInfoList,string sourcebr,string AccountNo,string description,bool isSCharge);
    }
}