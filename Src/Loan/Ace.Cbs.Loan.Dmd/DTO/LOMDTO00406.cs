using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00406 : Supportfields<LOMDTO00406>
    {
        //Business_Loans_Details Table
        public LOMDTO00406() { }

        //public LOMDTO00406(string lno,string acctno,decimal samt,DateTime duedate,int days,int userid,string name,string sourceBr) 
        //{
        //    this.Lno = lno;
        //    this.Acctno = acctno;
        //    this.FirstSAmt = samt;
        //    this.FirstMDueDate = duedate;
        //    this.DAYSINYEAR = days;
        //    this.CreatedUserId = userid;
        //    this.UserName = name;
        //    this.SourceBr = sourceBr;
        //}
        public LOMDTO00406(string lno, string acctno,string name,string address,string phoneNo,decimal FSamt,decimal samt,DateTime nplDate,string userName)
        {
            this.Lno = lno;
            this.Acctno = acctno;
            this.Name = Name;
            this.Address = address;
            this.Phone = phoneNo;
            this.FirstSAmt = FSamt;
            this.Capital = samt;
            this.NPLDate = nplDate;
            this.UserName = name;
        }
        public LOMDTO00406(DateTime sDate, DateTime eDate,string sourceBr,string cur)
        {
            this.StartDate = sDate;
            this.EndDate = eDate;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        //Updated By AAM (22-Nov-2017)
        public LOMDTO00406(string chkAcctNo,string LNo,string acctNo,string name,string nrc,int termNo,int lateDays,int loanPeriod,string blType,DateTime dueDate)
        {
            this.chkAcctNo = chkAcctNo;
            Lno = LNo;
            Acctno = acctNo;
            NAME = name;
            NRC = nrc;
            TermNo = termNo;
            LateDays = lateDays;
            LoansPeriod = loanPeriod;
            BLType = blType;
            EndDate = dueDate;

        }

        public LOMDTO00406(string LNo, string acctNo, string name, string nrc, int termNo, int lateDays, decimal odAmount, decimal totalLateFees,DateTime endDate,int loansPeriod)
        {
            Lno = LNo;
            Acctno = acctNo;
            NAME = name;
            NRC = nrc;
            TermNo = termNo;
            LateDays = lateDays;
            ODAmount = odAmount;
            TotalLateFees = totalLateFees;
            EndDate = endDate;
            LoansPeriod = loansPeriod;
        }

        //Added by HWKO (22-Nov-2017)
        public LOMDTO00406(string lno, string acctno, string name, string address, string phone, decimal firstSAmt, decimal capital, DateTime nplDate, string userName, DateTime endDate, string blType)
        {
            this.Lno = lno;
            this.Acctno = acctno;
            this.Name = Name;
            this.Address = address;
            this.Phone = phone;
            this.FirstSAmt = firstSAmt;
            this.Capital = capital;
            this.NPLDate = nplDate;
            this.UserName = name;
            this.EndDate = endDate;
            this.BLType = blType;
        }

        // Added One Constructor By AAM (12_Apr_2018) For Business Loans Interest Due Pre Listing Report
        //Lno,Acctno,Name,TermNo,InterestStatus,InterestPaidDate,EndDate,RepayInterestAmount,TotalLateFees
        //    ,ODAmount,Phone,Address,CBal,FirstSAmt,BLType,InterestStatusDesp,ActualRepaidDate
        public LOMDTO00406(string lno,string acctNo,string name,int termNo,bool intStatus
                        ,DateTime intPaidDate,DateTime endDate,decimal repayIntAmt,decimal totalLateFees,decimal odAmt
                        ,string ph,string address,decimal cbal,decimal firstSAmt,string blType
                        , string intStatusDesp, DateTime actualRepaidDate, decimal totalAmount)
        {
            Lno = lno;
            AcctNo = acctNo;
            Name = name;
            TermNo = termNo;
            InterestStatus = intStatus;
            InterestPaidDate = intPaidDate;
            EndDate = endDate;
            RepayInterestAmount = repayIntAmt;
            TotalLateFees = totalLateFees;
            ODAmount = odAmt;
            Phone = ph;
            Address = address;
            CBal = cbal;
            FirstSAmt = firstSAmt;
            BLType = blType;
            InterestStatusDesp = intStatusDesp;
            ActualRepaidDate = actualRepaidDate;
            TotalAmount = totalAmount;

        }



        public virtual int Id { get; set; }
        //public virtual string Lno { get; set; }
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
        public virtual string HasLimitChange { get; set; } //D or I
        public virtual Nullable<decimal> LimitChangeAmount { get; set; }
        public virtual Nullable<DateTime> LimitChangeDate { get; set; }
        public virtual Nullable<decimal> LCInterestPrevDays { get; set; } //Previous Interest of LC Month
        public virtual Nullable<decimal> ODAmount { get; set; }
        public virtual Nullable<decimal> SChargeAmt { get; set; }
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
        //public virtual Nullable<decimal> LateDays { get; set; }
        public virtual int LateDays { get; set; }// Modified By AAM (23-Nov-2017)
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

        public virtual DateTime FirstMDueDate { get; set; }
        public virtual int DAYSINYEAR { get; set; }
        public virtual int CreatedUserId { get; set; }
        public virtual string UserName { get; set; }

        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        //public virtual int Id { get; set; }
        //public virtual DateTime StartDate { get; set; }
        //public virtual DateTime EndDate { get; set; }

        public virtual decimal Duration { get; set; }
        public virtual DateTime VoucherDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }

        public virtual string Lno { get; set; }
        public virtual string NRC { get; set; }
        public virtual string chkAcctNo { get; set; }
        public virtual string BLType { get; set; }

        public virtual string LoansNo { get; set; }
        public virtual string InterestPaidStatus { get; set; }
        public virtual decimal CBal { get; set; }
        //public virtual DateTime SDate { get; set; }
        //public virtual decimal SCharges { get; set; }
        //public virtual bool isSCharge { get; set; }

        // Updated By AAM (22-Nov-2017)
        public string AcctNo { get; set; }
        public string NAME { get; set; }
        public int Min_Period { get; set; }

        public string InterestStatusDesp { get; set; }// Added By AAM (12-Dec-2017)
        public DateTime ActualRepaidDate { get; set; }// Added By AAM (12-Dec-2017)

        public virtual Nullable<decimal> TotalAmount { get; set; }// Added By ZMs (27-Jun-2018)
    }
}
