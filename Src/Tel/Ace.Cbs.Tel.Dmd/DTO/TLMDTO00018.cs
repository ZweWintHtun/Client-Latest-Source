//----------------------------------------------------------------------
// <copyright file="TLMDTO00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
//using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// Loans DTO Entity
    /// </summary>
    [Serializable]
    public class TLMDTO00018 : Supportfields<TLMDTO00018>
    {
        public TLMDTO00018() { }

        public TLMDTO00018(string account)
        {
            this.AccountNo = account;
        }
        public TLMDTO00018(decimal sAmount,DateTime expireDate)
        {
            this.SAmount = sAmount;
            this.ExpireDate = expireDate;
        }
        public TLMDTO00018(decimal sAmount)
        {
            this.SAmount = sAmount;
        }
        public TLMDTO00018(bool legalCase, string lno, string aType, bool nplCase)
        {
            this.LegalCase = legalCase;
            this.Lno = lno;
            this.AType = aType;
            this.NPLCase = nplCase;
        }
        public TLMDTO00018(string accountNo, string lno, bool legalCase, DateTime lastIntDate, bool nplCase, string cur)
        {
            this.AccountNo = accountNo;
            this.Lno = lno;
            this.LegalCase = legalCase;
            this.LasIntDate = lastIntDate;
            this.NPLCase = nplCase;
            this.Currency = cur;
        }
        public TLMDTO00018(string lno, string acctNo, string aType, string bType, System.Nullable<DateTime> sDate,
            System.Nullable<decimal> sAmt, string time, string loans_Type,string relatedGLACode, System.Nullable<DateTime> expireDate,
            System.Nullable<decimal> intRate, System.Nullable<decimal> unUsedRate, System.Nullable<decimal> firstSAmt, System.Nullable<decimal> docFee, 
            System.Nullable<DateTime> lasIntDate, string lasRepayNo, System.Nullable<decimal> min_Period, bool vouchered,
            string aCSign, string userNo, string assessor, string lawer, bool legalCase, System.Nullable<DateTime> legalDate, 
            string legaLawer, System.Nullable<DateTime> closeDate, bool nPLCase, System.Nullable<DateTime> nPLDate, string lastUserNo,
            System.Nullable<DateTime> lastDate, System.Nullable<bool> partial, System.Nullable<DateTime> voucherDate, 
            System.Nullable<int> partialNo, decimal sCharges, string todSerial, System.Nullable<DateTime> todCloseDate, 
            string charges_Status, string markNPLUser, string nPLReleaseUser, string markLegalUser, string legalReleaseUser, 
            string uId, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId,
            System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, string _balStatus, System.Nullable<decimal> usedOhalfRate,bool _islatefee,
            int gracePeriod,string PrincipleRepayOptions,string InterestRepayOptions)
        {
            this.Lno = lno;
            this.AccountNo = acctNo;
            this.AType = aType;
            this.BType = bType;
            this.SDate = sDate;
            this.SAmount = sAmt;
            this.Time = time;
            this.Loans_Type = loans_Type;
            this.RelatedGLACode = relatedGLACode;
            this.ExpireDate = expireDate;
            this.IntRate = intRate;
            this.UnUsedRate = unUsedRate;
            this.FirstSAmount = firstSAmt;
            this.DocFee = docFee;
            this.LasIntDate = lasIntDate;
            this.LasRepayNo = lasRepayNo;
            this.Min_Period = min_Period;
            this.Vouchered = vouchered;
            this.ACSign = aCSign;
            this.UserNo = userNo;
            this.Assessor = assessor;
            this.Lawer = lawer;
            this.LegalCase = legalCase;
            this.LegalDate = legalDate;
            this.LegaLawer = legaLawer;
            this.CloseDate = closeDate;
            this.NPLCase = nPLCase;
            this.NPLDate = nPLDate;
            this.LastUserNo = lastUserNo;
            this.LastDate = lastDate;
            this.Partial = partial;
            this.VoucherDate = voucherDate;
            this.PartialNo = partialNo;
            this.Scharges = sCharges;
            this.TodSerial = todSerial;
            this.TodCloseDate = todCloseDate;
            this.Charges_Status = charges_Status;
            this.MarkNPLUser = markNPLUser;
            this.NPLReleaseUser = nPLReleaseUser;
            this.MarkLegalUser = markLegalUser;
            this.LegalReleaseUser = legalReleaseUser;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.BalStatus = _balStatus;
            this.UsedOverRate = usedOhalfRate;          
            this.isLateFee = _islatefee;
            this.GracePeriod = gracePeriod;
            this.PrincipleRepayOptions = PrincipleRepayOptions;
            this.InterestRepayOptions = InterestRepayOptions;
        }
        public TLMDTO00018(string lno, string acctNo, string aType, string bType, System.Nullable<DateTime> sDate,
        System.Nullable<decimal> sAmt, string time, string loans_Type,string relatedGLACode, System.Nullable<DateTime> expireDate,
        System.Nullable<decimal> intRate, System.Nullable<decimal> unUsedRate, System.Nullable<decimal> firstSAmt, System.Nullable<decimal> docFee, 
        System.Nullable<DateTime> lasIntDate, string lasRepayNo, System.Nullable<decimal> min_Period, bool vouchered,
        string aCSign, string userNo, string assessor, string lawer, bool legalCase, System.Nullable<DateTime> legalDate,
        string legaLawer, System.Nullable<DateTime> closeDate, bool nPLCase, System.Nullable<DateTime> nPLDate, string lastUserNo,
        System.Nullable<DateTime> lastDate, System.Nullable<bool> partial, System.Nullable<DateTime> voucherDate,
        System.Nullable<int> partialNo, decimal sCharges, string todSerial, System.Nullable<DateTime> todCloseDate,
        string charges_Status, string markNPLUser, string nPLReleaseUser, string markLegalUser, string legalReleaseUser,
        string uId, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId,
        System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, string _balStatus, System.Nullable<decimal> usedOhalfRate, bool _isSCharge,bool _islatefee,
         int gracePeriod,string PrincipleRepayOptions,string InterestRepayOptions)
        {
            this.Lno = lno;
            this.AccountNo = acctNo;
            this.AType = aType;
            this.BType = bType;
            this.SDate = sDate;
            this.SAmount = sAmt;
            this.Time = time;
            this.Loans_Type = loans_Type;
            this.RelatedGLACode = relatedGLACode;
            this.ExpireDate = expireDate;
            this.IntRate = intRate;
            this.UnUsedRate = unUsedRate;
            this.FirstSAmount = firstSAmt;
            this.DocFee = docFee;
            this.LasIntDate = lasIntDate;
            this.LasRepayNo = lasRepayNo;
            this.Min_Period = min_Period;
            this.Vouchered = vouchered;
            this.ACSign = aCSign;
            this.UserNo = userNo;
            this.Assessor = assessor;
            this.Lawer = lawer;
            this.LegalCase = legalCase;
            this.LegalDate = legalDate;
            this.LegaLawer = legaLawer;
            this.CloseDate = closeDate;
            this.NPLCase = nPLCase;
            this.NPLDate = nPLDate;
            this.LastUserNo = lastUserNo;
            this.LastDate = lastDate;
            this.Partial = partial;
            this.VoucherDate = voucherDate;
            this.PartialNo = partialNo;
            this.Scharges = sCharges;
            this.TodSerial = todSerial;
            this.TodCloseDate = todCloseDate;
            this.Charges_Status = charges_Status;
            this.MarkNPLUser = markNPLUser;
            this.NPLReleaseUser = nPLReleaseUser;
            this.MarkLegalUser = markLegalUser;
            this.LegalReleaseUser = legalReleaseUser;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.BalStatus = _balStatus;
            this.UsedOverRate = usedOhalfRate;
            this.isScharge = _isSCharge;
            this.isLateFee = _islatefee;
            this.GracePeriod = gracePeriod;
            this.PrincipleRepayOptions = PrincipleRepayOptions;
            this.InterestRepayOptions = InterestRepayOptions;

        }

        public TLMDTO00018(string lno, string acctNo, string aType, string bType, System.Nullable<DateTime> sDate, System.Nullable<decimal> sAmt, string time, 
            string loans_Type, string relatedGLACode, System.Nullable<DateTime> expireDate, System.Nullable<decimal> intRate, System.Nullable<decimal> unUsedRate,
            System.Nullable<decimal> firstSAmt, System.Nullable<decimal> docFee, System.Nullable<DateTime> lasIntDate, string lasRepayNo, System.Nullable<decimal> min_Period, bool vouchered, 
            string aCSign, string userNo, string assessor, string lawer, bool legalCase, System.Nullable<DateTime> legalDate, string legaLawer, 
            System.Nullable<DateTime> closeDate, bool nPLCase, System.Nullable<DateTime> nPLDate, string lastUserNo, System.Nullable<DateTime> lastDate,
            System.Nullable<bool> partial, System.Nullable<DateTime> voucherDate, System.Nullable<int> partialNo, decimal sCharges, string todSerial, 
            System.Nullable<DateTime> todCloseDate, string charges_Status, string markNPLUser, string nPLReleaseUser, string markLegalUser, string legalReleaseUser,
            string uId, string sourceBr, string cur, int gracePeriod, string PrincipleRepayOptions, string InterestRepayOptions, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, 
            System.Nullable<int> updatedUserId)
        {
            this.Lno = lno;
            this.AccountNo = acctNo;
            this.AType = aType;
            this.BType = bType;
            this.SDate = sDate;
            this.SAmount = sAmt;
            this.Time = time;
            this.Loans_Type = loans_Type;
            this.RelatedGLACode = relatedGLACode;
            this.ExpireDate = expireDate;
            this.IntRate = intRate;
            this.UnUsedRate = unUsedRate;
            this.FirstSAmount = firstSAmt;
            this.DocFee = docFee;
            this.LasIntDate = lasIntDate;
            this.LasRepayNo = lasRepayNo;
            this.Min_Period = min_Period;
            this.Vouchered = vouchered;
            this.ACSign = aCSign;
            this.UserNo = userNo;
            this.Assessor = assessor;
            this.Lawer = lawer;
            this.LegalCase = legalCase;
            this.LegalDate = legalDate;
            this.LegaLawer = legaLawer;
            this.CloseDate = closeDate;
            this.NPLCase = nPLCase;
            this.NPLDate = nPLDate;
            this.LastUserNo = lastUserNo;
            this.LastDate = lastDate;
            this.Partial = partial;
            this.VoucherDate = voucherDate;
            this.PartialNo = partialNo;
            this.Scharges = sCharges;
            this.TodSerial = todSerial;
            this.TodCloseDate = todCloseDate;
            this.Charges_Status = charges_Status;
            this.MarkNPLUser = markNPLUser;
            this.NPLReleaseUser = nPLReleaseUser;
            this.MarkLegalUser = markLegalUser;
            this.LegalReleaseUser = legalReleaseUser;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.GracePeriod = gracePeriod;
            this.PrincipleRepayOptions = PrincipleRepayOptions;
            this.InterestRepayOptions = InterestRepayOptions;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        //For Business Loan Registration (Added by HMW at 10-Oct-2019)       
        public TLMDTO00018(string lno, string acctNo, string aType, string bType, System.Nullable<DateTime> sDate,
        System.Nullable<decimal> sAmt, string time, string loans_Type, string relatedGLACode, System.Nullable<DateTime> expireDate,
        System.Nullable<decimal> intRate, System.Nullable<decimal> unUsedRate, System.Nullable<decimal> firstSAmt, System.Nullable<decimal> docFee,
        System.Nullable<DateTime> lasIntDate, string lasRepayNo, System.Nullable<decimal> min_Period, bool vouchered,
        string aCSign, string userNo, string assessor, string lawer, bool legalCase, System.Nullable<DateTime> legalDate,
        string legaLawer, System.Nullable<DateTime> closeDate, bool nPLCase, System.Nullable<DateTime> nPLDate, string lastUserNo,
        System.Nullable<DateTime> lastDate, System.Nullable<bool> partial, System.Nullable<DateTime> voucherDate,
        System.Nullable<int> partialNo, decimal sCharges, string todSerial, System.Nullable<DateTime> todCloseDate,
        string charges_Status, string markNPLUser, string nPLReleaseUser, string markLegalUser, string legalReleaseUser,
        string uId, string sourceBr, string cur, bool active, byte[] tS, DateTime createdDate, int createdUserId,
        System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId, string _balStatus, System.Nullable<decimal> usedOhalfRate, bool _isSCharge, bool _islatefee,
         int gracePeriod, string PrincipleRepayOptions, string InterestRepayOptions,int reversalStatus)
        {
            this.Lno = lno;
            this.AccountNo = acctNo;
            this.AType = aType;
            this.BType = bType;
            this.SDate = sDate;
            this.SAmount = sAmt;
            this.Time = time;
            this.Loans_Type = loans_Type;
            this.RelatedGLACode = relatedGLACode;
            this.ExpireDate = expireDate;
            this.IntRate = intRate;
            this.UnUsedRate = unUsedRate;
            this.FirstSAmount = firstSAmt;
            this.DocFee = docFee;
            this.LasIntDate = lasIntDate;
            this.LasRepayNo = lasRepayNo;
            this.Min_Period = min_Period;
            this.Vouchered = vouchered;
            this.ACSign = aCSign;
            this.UserNo = userNo;
            this.Assessor = assessor;
            this.Lawer = lawer;
            this.LegalCase = legalCase;
            this.LegalDate = legalDate;
            this.LegaLawer = legaLawer;
            this.CloseDate = closeDate;
            this.NPLCase = nPLCase;
            this.NPLDate = nPLDate;
            this.LastUserNo = lastUserNo;
            this.LastDate = lastDate;
            this.Partial = partial;
            this.VoucherDate = voucherDate;
            this.PartialNo = partialNo;
            this.Scharges = sCharges;
            this.TodSerial = todSerial;
            this.TodCloseDate = todCloseDate;
            this.Charges_Status = charges_Status;
            this.MarkNPLUser = markNPLUser;
            this.NPLReleaseUser = nPLReleaseUser;
            this.MarkLegalUser = markLegalUser;
            this.LegalReleaseUser = legalReleaseUser;
            this.UniqueId = uId;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
            this.BalStatus = _balStatus;
            this.UsedOverRate = usedOhalfRate;
            this.isScharge = _isSCharge;
            this.isLateFee = _islatefee;
            this.GracePeriod = gracePeriod;
            this.PrincipleRepayOptions = PrincipleRepayOptions;
            this.InterestRepayOptions = InterestRepayOptions;
            this.ReversalStatus = reversalStatus;

        }
        
        public TLMDTO00018(string acctno, string lno, string guaranteeacctno)
        {
            this.AccountNo = acctno;
            this.Lno = lno;
            this.GuaranteeAccountNo = guaranteeacctno;
        }

        public TLMDTO00018(string acctno, string lno, Nullable<decimal> samt)
        {
            this.AccountNo = acctno;
            this.Lno = lno;
            this.SAmount = samt;
        }

        public TLMDTO00018(string lno, string accountno, string loanstype, System.Nullable<DateTime> expiredate)
        {
            this.Lno = lno;
            this.AccountNo = accountno;
            this.Loans_Type = loanstype;
            this.ExpireDate = expiredate;
        }
        public TLMDTO00018(string lno, string accountno, System.Nullable<decimal>  samt,string loanType,string cur)
        {
            this.AccountNo = accountno;
            this.Lno = lno;
            this.SAmount = samt;
            this.Loans_Type = loanType;
            this.Currency = cur;

        }
        public TLMDTO00018(string lno, string accountno, string loanstype, System.Nullable<DateTime> expiredate, System.Nullable<decimal> SAmount)
        {
            this.Lno = lno;
            this.AccountNo = accountno;
            this.Loans_Type = loanstype;
            this.ExpireDate = expiredate;
            this.SAmount = SAmount;
        }

        public TLMDTO00018(string accountno, string lno, bool legalCase, System.Nullable<DateTime> lastintDate,bool nplCase,string cur)
        {            
            this.AccountNo = accountno;
            this.Lno = lno;
            this.LegalCase = legalCase;
            this.LasIntDate = lastintDate;
            this.NPLCase = nplCase;
            this.Currency = cur;
        }
        public TLMDTO00018(string result, string lno, string accountno, decimal samt,decimal Fsamt,string LType, string cur,string name,string blType)
        {
            this.ResultCode = result;
            this.Lno = lno;
            this.AccountNo = accountno;
            this.SAmount = samt;
            this.FirstSAmount = Fsamt;
            this.Loans_Type = LType;
            this.Currency = cur;
            this.Name = name;
            this.BusinessLoansType = blType;
        }
        //Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        public TLMDTO00018(string lno, string acctno, string custName, Nullable<decimal> firstSamt)
        {
            this.Lno = lno;
            this.AccountNo = acctno;
            this.CustName = custName;
            this.FirstSAmount = firstSamt;
        }

        //Added by SHO (22-Nov-2021) //For Business Loans Limit change entry
     /*   public TLMDTO00018(string loanNo, string sourceBr)
        {
            this.Lno = loanNo;
            this.SourceBranchCode = sourceBr;
        }*/

        public virtual string Lno{get;set;}
        public virtual string AccountNo{get;set;}
        public virtual string AType{get;set;}
        public virtual string BType{get;set;}
        public virtual  System.Nullable<DateTime> SDate{get;set;}
        public virtual System.Nullable<decimal> SAmount { get; set; }
        public virtual string Time{get;set;}
        public virtual string Loans_Type{get;set;}

        public virtual string RelatedGLACode{ get; set; }

        public virtual  System.Nullable<DateTime> ExpireDate{get;set;}
        public virtual System.Nullable<decimal> IntRate { get; set; }
        public virtual System.Nullable<decimal> UnUsedRate { get; set; }
        public virtual System.Nullable<decimal> UsedOverRate { get; set; }
        public virtual System.Nullable<decimal> FirstSAmount { get; set; }
        public virtual  System.Nullable<DateTime> LasIntDate{get;set;}
        public virtual string LasRepayNo{get;set;}
        public virtual System.Nullable<decimal> Min_Period { get; set; }
        public virtual bool Vouchered{get;set;}
        public virtual string ACSign{get;set;}
        public virtual string UserNo{get;set;}
        public virtual string Assessor{get;set;}
        public virtual string Lawer{get;set;}
        public virtual bool LegalCase{get;set;}
        public virtual  System.Nullable<DateTime> LegalDate{get;set;}
      
        public virtual string LegaLawer{get;set;}
        public virtual  System.Nullable<DateTime> CloseDate{get;set;}
        public virtual bool NPLCase{get;set;}
        public virtual  System.Nullable<DateTime> NPLDate{get;set;}
        public virtual string LastUserNo{get;set;}
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual System.Nullable<bool> Partial{get;set;}
        public virtual  System.Nullable<DateTime> VoucherDate{get;set;}
        public virtual System.Nullable<int> PartialNo { get; set; }
        public virtual decimal Scharges { get; set; }
        public virtual string TodSerial{get;set;}
        public virtual  System.Nullable<DateTime> TodCloseDate{get;set;}
        public virtual string Charges_Status{get;set;}
        public virtual string MarkNPLUser{get;set;}
        public virtual string NPLReleaseUser{get;set;}
        public virtual string MarkLegalUser{get;set;}
        public virtual string LegalReleaseUser{get;set;}
        public virtual string UniqueId{get;set;}
        public virtual string SourceBranchCode{get;set;}
        public virtual string Currency{get;set;}
        public virtual string GuaranteeAccountNo { get; set; }
        public virtual int Duration { get; set; }
        public virtual bool isScharge { get; set; }
        public virtual bool isOD { get; set; }
        public virtual bool isPFcharge { get; set; }
        //LOMCTL00012  (OD Limit Change Entry)
        public virtual decimal OverdraftAmount { get; set; }
        public virtual decimal PresentODLimit { get; set; }
        public virtual decimal TotalODLimit { get; set; }
        public virtual decimal NewODLimit { get; set; }
        public virtual decimal NewTotalODLimit { get; set; }
        public virtual string Name { get; set; }
        public virtual string BusinessLoansType { get; set; }

        #region LoanRepayment
        public virtual string CreditAccountDesp { get; set; }
        public virtual string InterestAccountDesp { get; set; }
        public virtual decimal WithdrawableBalance { get; set; }
        public virtual string CreditAccountCode { get; set; }
        public virtual string InterestAccountCode { get; set; }
        public virtual decimal Interest { get; set; }

        public virtual string ResultCode { get; set; }
        public virtual string LastRepaymentNo { get; set; }
        public virtual decimal LastRepaymentAmount { get; set; }
        public virtual decimal BeforeLastRepaymentSanctionAmount { get; set; }
        public virtual decimal AfterLastRepaymentSanctionAmount { get; set; }
        public virtual decimal FistSanctionAmount { get; set; }
        public virtual decimal PrevTotalSanctionAmount { get; set; }
        
        #endregion

        public virtual string BalStatus { get; set; }
        public virtual bool isLateFee { get; set; }


        public virtual LOMDTO00015 Land_buildingDto { get; set; }
        public virtual PFMDTO00039 Per_guaranteeDto { get; set; }
        public virtual IList<LOMDTO00016> PledgeDto { get; set; }
        public virtual LOMDTO00017 HypothecationDto { get; set; }
        public virtual IList<LOMDTO00018> GjTypeDtoList { get; set; }
        public virtual IList<LOMDTO00018> GjKindDtoList { get; set; }

        public virtual IList<LOMDTO00021> LiList { get; set; }
        public virtual IList<LOMDTO00012> PenalFeeList { get; set; }
        public virtual IList<PFMDTO00072> LoanAcctnoInfoList { get; set; }
        public virtual IList<PFMDTO00017> CaofList { get; set; }

        public virtual string status { get; set; }
        public virtual string EntryNo { get; set; }
        public virtual System.Nullable<decimal> serviceChargesRate { get; set; }
        public virtual LOMDTO00021 LiDTO { get; set; }
        public virtual decimal OutstandingInt { get; set; }
        public virtual decimal OutstandingChg { get; set; }
        public virtual decimal PenlityFees { get; set; }
        public virtual decimal ServiceCharges { get; set; }
        public virtual decimal CommitmentFees { get; set; }
        public virtual System.Nullable<decimal> DocFee { get; set; }
        public virtual decimal TODServiceCharges { get; set; }

        public virtual int GracePeriod { get; set; }
        public virtual string PrincipleRepayOptions { get; set; }
        public virtual string InterestRepayOptions { get; set; }
        
        public virtual string CustName { get; set; }//Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        public virtual string voucherNo { get; set; }
        public virtual int ReversalStatus { get; set; }//Added by HMW at 10-Oct-2019
        public virtual int RCount { get; set; }

        public virtual decimal OldIntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)
        public virtual decimal NewIntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)
    }
}
