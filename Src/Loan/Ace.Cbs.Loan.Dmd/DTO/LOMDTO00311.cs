using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00311 : Supportfields<LOMDTO00311>
    {
        public LOMDTO00311() { }

        public LOMDTO00311(string acctNo)
        {
            this.ACNo = acctNo;
        }

        public LOMDTO00311(decimal interestAmount, decimal installmentAmt, string eno,  Nullable<DateTime> dueDate, string retMsg)
        {
            this.InterestAmount = interestAmount;
            this.InstallmentAmount = installmentAmt;
            this.Eno = eno;
            this.DueDate = dueDate;
            this.RetMsg = retMsg;
        }

        public LOMDTO00311(string plno, string acctNo, string bType,  Nullable<DateTime> sdate, decimal samt,Nullable<DateTime> expireDate,
            int term, int repDuration, int repOption, decimal intRate, decimal firstSAmt, Nullable<DateTime> lasIntDate, bool vouchered,
            string acsign, string userNo, string assessor, string lawer, decimal monthlyIncom, string monthlyRepayDate, string productType,
            string companyName, decimal docFee, bool legalCase, Nullable<DateTime> legalDate, string legalLawer,Nullable<DateTime> closeDate,
            bool nplcase, Nullable<DateTime> npldate, string lastuserno, Nullable<DateTime> lastdate, bool partial, Nullable<DateTime> voucherdate,
            int partialno, decimal scharges, string todserial,  Nullable<DateTime> todCloseDate, string chargesstatus, string marknpluser,
            string nplreleaseuser, string marklegaluser, string legalreleaseuser, bool isscharge, bool islatefee, string balstatus,
            string uid, string sourcebr, string cur, bool active, DateTime createdDate, int createdUserId)
        {
            this.PLNo = plno;
            this.ACNo = acctNo;
            this.BType = bType;
            this.SDate = sdate;
            this.SAmt = samt;
            this.ExpireDate = expireDate;
            this.Term = term;
            this.RepDuration = repDuration;
            this.RepOption = repOption;
            this.IntRate = intRate;
            this.FirstSAmt = firstSAmt;
            this.LasIntDate = lasIntDate;
            this.Vouchered = vouchered;
            this.ACSign = acsign;
            this.UserNo = userNo;
            this.Assessor = assessor;
            this.Lawer = lawer;
            this.MonthlyIncome = monthlyIncom;
            this.MonthlyRepayDate = monthlyRepayDate;
            this.ProductType = productType;
            this.CompanyName = companyName;
            this.DocFee = docFee;
            this.LegalCase = legalCase;
            this.LegalDate = legalDate;
            this.LegaLawer = legalLawer;
            this.CloseDate = closeDate;
            this.NPLCase = nplcase;
            this.NPLDate = npldate;
            this.LastUserNo = lastuserno;
            this.LastDate = lastdate;
            this.Partial = partial;
            this.VoucherDate = voucherdate;
            this.PartialNo = partialno;
            this.SCharges = scharges;
            this.TodSerial = todserial;
            this.TodCloseDate = todCloseDate;
            this.Charges_Status = chargesstatus;
            this.MarkNPLUser = marknpluser;
            this.NPLReleaseUser = nplreleaseuser;
            this.MarkLegalUser = marklegaluser;
            this.LegalReleaseUser = legalreleaseuser;
            this.isSCharge = isscharge;
            this.isLateFee = islatefee;
            this.BalStatus = balstatus;
            this.UId = uid;
            this.SourceBr = sourcebr.Trim();
            this.Cur = cur;
            this.Active = active;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }

        //Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing
        public LOMDTO00311(string plno, string acno, string custname, Nullable<decimal> samt)
        {
            this.PLNo = plno;
            this.ACNo = acno;
            this.CustName = custname;
            this.SAmt = samt;
        }

        //Added by HWKO (09-Nov-2017) //For Personal Loans Late Fees Outstanding Listing
        public LOMDTO00311(string plno, string acno, string custName, int termno, decimal odamount, int latedays,
            decimal totalLateFeesAmt)
        {
            this.PLNo = plno;
            this.ACNo = acno;
            this.CustName = custName;
            this.TermNo = termno;
            this.ODAmount = odamount;
            this.LateDays = latedays;
            this.TotalLateFeesAmt = totalLateFeesAmt;
        }

        public virtual string PLNo { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string BType { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<Int32> Term { get; set; }
        public virtual Nullable<Int32> RepDuration { get; set; }
        public virtual Nullable<Int32> RepOption { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<decimal> NYIntRate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<DateTime> LasIntDate { get; set; }
        public virtual Nullable<bool> Vouchered { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string Assessor { get; set; }
        public virtual string Lawer { get; set; }
        public virtual Nullable<decimal> MonthlyIncome { get; set; }
        public virtual string MonthlyRepayDate { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual Nullable<decimal> DocFee { get; set; }
        public virtual Nullable<bool> LegalCase { get; set; }
        public virtual Nullable<DateTime> LegalDate { get; set; }
        public virtual string LegaLawer { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual Nullable<bool> NPLCase { get; set; }
        public virtual Nullable<DateTime> NPLDate { get; set; }
        public virtual string LastUserNo { get; set; }
        public virtual Nullable<DateTime> LastDate { get; set; }
        public virtual Nullable<bool> Partial { get; set; }
        public virtual Nullable<DateTime> VoucherDate { get; set; }
        public virtual Nullable<Int32> PartialNo { get; set; }
        public virtual Nullable<decimal> SCharges { get; set; }
        public virtual string TodSerial { get; set; }
        public virtual Nullable<DateTime> TodCloseDate { get; set; }
        public virtual string Charges_Status { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }
        public virtual string MarkLegalUser { get; set; }
        public virtual string LegalReleaseUser { get; set; }
        public virtual Nullable<bool> isSCharge { get; set; }
        public virtual Nullable<bool> isLateFee { get; set; }
        public virtual string BalStatus { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        //Not related to table
        public virtual string GuarantorCompanyName { get; set; }
        public virtual string status { get; set; }
        public virtual string CustName { get; set; }//Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing

        //Added by HWKO (09-Nov-2017) //For Personal Loans Latefees Outstanding Listing
        public virtual int TermNo { get; set; }
        public virtual decimal ODAmount { get; set; }
        public virtual int LateDays { get; set; }
        public virtual decimal TotalLateFeesAmt { get; set; }
        //End Region

        //For Details
        public virtual Nullable<Int32> RepaymentDuration { get; set; }
        public virtual Nullable<Int32> RepaymentPeriod { get; set; }
        public virtual string RepaymentOption { get; set; }
        public virtual Nullable<Int32> Duration { get; set; }
        public virtual int GPeriod { get; set; }

        public Nullable<decimal> InterestAmount { get; set; }
        public Nullable<decimal> InstallmentAmount { get; set; }
        public string Eno { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string RetMsg { get; set; }

        public virtual decimal Principal_TOD { get; set; }
        public virtual decimal Interest_TOD { get; set; }
        public virtual decimal Total_LateFee_PTOD_OnIntRate { get; set; }
        public virtual decimal Total_LateFee_PTOD_OnLateFeeRate { get; set; }
        public virtual decimal Total_LateFee_ITOD_OnLateFeeRate { get; set; }
        public virtual String Phone { get; set; }

        public virtual LOMDTO00313 PL_GuanDto { get; set; }


    }
}
