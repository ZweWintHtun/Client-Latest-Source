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
    public interface ILOMSVE00011 : IBaseService
    {
        ITLMDAO00018 LoanDAO { get; set; }
        IList<PFMDTO00072> IsValidForLoanAcctno(string acctno);

        IList<LOMDTO00001> BindLoansBType();

        TLMDTO00018 SelectLoanInformationByLoanNoAndSourceBr(string lno, string sourcebr);
        //TLMDTO00018 CheckLoansNoAlreadyExistorNot(string lno);


        string Save_LandandBuilding(LOMDTO00015 land_BuildingDto, LOMDTO00021 liDto, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);
        string Save_PersonalGuarantee(PFMDTO00039 personal_GuaranteeDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);
        string Save_Hypothecation(LOMDTO00017 hypothecationDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);
        string Save_Pledge(IList<LOMDTO00016> pledgeDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);
        string Save_GoldAndJewellery(IList<LOMDTO00018> gjTypeDto, IList<LOMDTO00018> gjKindDto, LOMDTO00021 liList, TLMDTO00018 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);

        string GetCompanyName(string acctno);
    }
}