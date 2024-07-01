//----------------------------------------------------------------------
// <copyright file="ILOMCTL00016" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>15.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00016 : IPresenter
    {
        ILOMVEW00016 View { set; get; }
        void Save();
        void Release();
    }
    public interface ILOMVEW00016
    {
        ILOMCTL00016 Controller { set; get; }
        string LoanNo { get; set; }
        string AccountNo { get; set; }
        string AdvanceType { get; set; }
        decimal InterestRate { get; set; }
        decimal ServicesCharges { get; set; }
        decimal LedgerBalance { get; set; }
        decimal SanctionAmount { get; set; }
        decimal Interest { get; set; }
        decimal ExtraCharges { get; set; }
        string LegalCaseLawyer { get; set; }
        string UserName { get; set; }
        string FormName { get; set; }

        string MakingDate { get; set; }
        string AcceptanceDate { get; set; }
        string LegalReleaseLawyer { get; set; }

        string Status { get; set; }
    }
}
