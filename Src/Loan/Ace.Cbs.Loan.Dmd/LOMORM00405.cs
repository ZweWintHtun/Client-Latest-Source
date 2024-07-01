//----------------------------------------------------------------------
// <copyright file="LOMORM00405.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ZMS</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Business_Loans_Details ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00405 : Supportfields<LOMORM00405>
    {
        public LOMORM00405() { }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string Acctno { get; set; }
        public virtual int LoansPeriod { get; set; }
        public virtual int TermNo { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<decimal> Capital { get; set; }
        public virtual Nullable<decimal> RemainingCapital { get; set; }
        public virtual Nullable<decimal> RepayCapital { get; set; }
        public virtual Nullable<decimal> ActualRepayCapital { get; set; }
        public virtual Nullable<decimal> InterestRate { get; set; }
        public virtual Nullable<decimal> RepayInterestAmount { get; set; }
        public virtual Nullable<decimal> ActualRepayInterestAmount { get; set; }
        public virtual Nullable<decimal> InterestAmountPerDay { get; set; }
        public virtual Nullable<decimal> TotalInterestAmount { get; set; }
        public virtual Nullable<DateTime> StartDate { get; set; }
        public virtual Nullable<DateTime> EndDate { get; set; }
        public virtual Nullable<DateTime> CapitalDueDate { get; set; }
        public virtual Nullable<DateTime> CapitalPaidDate { get; set; }
        public virtual Nullable<DateTime> InterestDate { get; set; }
        public virtual Nullable<DateTime> InterestPaidDate { get; set; }
        public virtual Nullable<DateTime> GracePeriodDueDate { get; set; }
        public virtual string HasLimitChange { get; set; }
        public virtual Nullable<decimal> LimitChangeAmount { get; set; }
        public virtual Nullable<DateTime> LimitChangeDate { get; set; }
        public virtual Nullable<decimal> LCInterestPrevDays { get; set; }
        public virtual Nullable<decimal> SChargeAmt { get; set; }
        public virtual Nullable<decimal> ODAmount { get; set; }
        public virtual Nullable<decimal> ODAmountHistory { get; set; }
        public virtual Nullable<DateTime> ODStartDate { get; set; }
        public virtual Nullable<DateTime> ODPaidDate { get; set; }
        public virtual Nullable<decimal> LateFees { get; set; }
        public virtual Nullable<decimal> LateFeesAmtPerDay { get; set; }
        public virtual Nullable<decimal> TotalLateFees { get; set; }
        public virtual Nullable<DateTime> LatefeesStartDate { get; set; }
        public virtual Nullable<DateTime> LatefeesPaidDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual bool ReverseStatus { get; set; }
        public virtual Nullable<DateTime> RegDueDate { get; set; }
        public virtual bool Manual_Status { get; set; }
        public virtual Nullable<DateTime> AutoPayRunDate { get; set; }
        public virtual bool InterestStatus { get; set; }
        public virtual bool CapitalStatus { get; set; }
        public virtual bool LateFeeStatus { get; set; }
        public virtual bool ODPaidStatus { get; set; }
        public virtual Nullable<decimal> LateDays { get; set; }
        public virtual Nullable<decimal> LateMonth { get; set; }
        public virtual string HasDeposit { get; set; }
        public virtual Nullable<DateTime> DepositDate { get; set; }

        public virtual int LegalCase { get; set; }
        public virtual System.Nullable<DateTime> LegalDate { get; set; }
        public virtual string LegaLawer { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual int NPLCase { get; set; }
        public virtual System.Nullable<DateTime> NPLDate { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }
        public virtual string MarkLegalUser { get; set; }
        public virtual string LegalReleaseUser { get; set; }

        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
