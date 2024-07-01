using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_BusinessLoansInterestDueListing DTO
    /// </summary>
    [Serializable]
    public class LOMDTO00405 
    {
        public LOMDTO00405() { }

        public LOMDTO00405(int id, string lno, string acctno,string name,string address,string phone,string state,Nullable<DateTime> intPaidDate,
                           Nullable<DateTime> firstDueDate,Nullable<decimal> firstSamt, Nullable<decimal> currentSamt,Nullable<decimal> intRate,
                           string sourcebr, Nullable<decimal> totalLateFee,Nullable<decimal> Tod, string cur, Nullable<DateTime> voucherDate,DateTime expireDate,
                           Nullable<decimal> totalInt, Nullable<decimal> lastInt, Nullable<DateTime> sDate, Nullable<decimal> sCharge,bool isServicecharge)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.PaidStatus = state;
            this.IntPaidDate = intPaidDate;
            this.FirstDueDate = firstDueDate;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.TotalLateFee = totalLateFee;
            this.TODAmt = TODAmt;
            this.Currency = cur;
            this.VoucherDate = voucherDate;
            this.ExpireDate = expireDate;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.SDate = sDate;
            this.SCharges = sCharge;
            this.isSCharge = isServicecharge;
        }

        //Added by HWKO (15-Aug-2017)
        //Used for "BLInterestDuePreListingDAO.SelectByDueDateForBLIntDuePreListing"
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone, string state, Nullable<DateTime> intPaidDate,
                           Nullable<DateTime> firstDueDate, Nullable<decimal> firstSamt, Nullable<decimal> currentSamt, Nullable<decimal> intRate,
                           string sourcebr, Nullable<decimal> totalLateFee, Nullable<decimal> Tod, string cur, Nullable<DateTime> voucherDate, DateTime expireDate,
                           Nullable<decimal> totalInt, Nullable<decimal> lastInt, Nullable<DateTime> sDate, Nullable<decimal> sCharge, bool isServicecharge,decimal ledgerbalance)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.PaidStatus = state;
            this.IntPaidDate = intPaidDate;
            this.FirstDueDate = firstDueDate;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.TotalLateFee = totalLateFee;
            this.TODAmt = TODAmt;
            this.Currency = cur;
            this.VoucherDate = voucherDate;
            this.ExpireDate = expireDate;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.SDate = sDate;
            this.SCharges = sCharge;
            this.isSCharge = isServicecharge;
            this.LedgerBalance = ledgerbalance;//Added by HWKO (15-Aug-2017)
        }

        public LOMDTO00405(DateTime startDate,DateTime endDate,string sourceBr,string cur)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
        }
        public LOMDTO00405(DateTime startDate, DateTime endDate, string sourceBr, string cur,decimal minAmt,decimal maxAmt)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBranchCode = sourceBr;
            this.Currency = cur;
            this.MinimumAmount = minAmt;
            this.MaximumAmount = maxAmt;
        }
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone, 
                           Nullable<decimal> firstSamt, Nullable<decimal> currentSamt, Nullable<decimal> intRate,
                          string sourcebr,string cur,DateTime expireDate,
                           Nullable<DateTime> sDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.ExpireDate = expireDate;
            this.SDate = sDate;
        }
        public LOMDTO00405(string sourceBr,string lno, string cur)
        {          
            this.SourceBranchCode = sourceBr;
            this.LNo = lno;
            this.Currency = cur;
        }
        //RDLC0041
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone,
                       Nullable<decimal> firstSamt, Nullable<decimal> currentSamt, Nullable<decimal> intRate,
                      string sourcebr, string cur, DateTime expireDate,
                       Nullable<DateTime> sDate, Nullable<decimal> serviceCharges, bool isSerChargeState
                        ,Nullable<DateTime> vDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.ExpireDate = expireDate;
            this.SDate = sDate;
            this.SCharges = serviceCharges;
            this.isSCharge = isSerChargeState;
            this.VoucherDate = vDate;
        }
        //RDLC0042
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone,
                       Nullable<decimal> firstSamt, Nullable<decimal> currentSamt, Nullable<decimal> intRate,
                      string sourcebr, string cur, DateTime expireDate,
                       Nullable<DateTime> sDate, Nullable<decimal> serviceCharges, bool isSerChargeState
                        , Nullable<DateTime> vDate, Nullable<DateTime> intPaidDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.ExpireDate = expireDate;
            this.SDate = sDate;
            this.SCharges = serviceCharges;
            this.isSCharge = isSerChargeState;
            this.VoucherDate = vDate;
            this.IntPaidDate = intPaidDate;
        }
        //BL Repay
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone, Nullable<decimal> firstSamt,
                          Nullable<decimal> currentSamt,string sourcebr, string cur, 
                          Nullable<DateTime> voucherDate, DateTime expireDate,string repayNo,Nullable<decimal> repayInt,
                          Nullable<decimal> repayAmt, Nullable<DateTime> rDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.VoucherDate = voucherDate;
            this.ExpireDate = expireDate;
            this.REPAYNO= repayNo;
            this.InterestForRepay = repayInt;
            this.RepayAmount = repayAmt;
            this.RepayDate = rDate;
        }
        //BL Repay
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone, Nullable<decimal> firstSamt,
                          Nullable<decimal> currentSamt, string cur, DateTime expireDate,
                          Nullable<DateTime> voucherDate, int nplCase, Nullable<DateTime> nplDate,
                          string markNplUser, string nplReleaseUser)
        {
            this.Id = id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.Currency = cur;
            this.ExpireDate = expireDate;
            this.VoucherDate = voucherDate;
            this.NPLCase = nplCase;
            this.NPLDate = nplDate;
            this.MarkNPLUser = markNplUser;
            this.NPLReleaseUser = nplReleaseUser;
        }
        public LOMDTO00405(int id, string lno, string acctno, string name, string address, string phone,
                           Nullable<decimal> firstSamt, Nullable<decimal> currentSamt, Nullable<decimal> intRate,
                          string sourcebr, string cur, DateTime expireDate,
                           Nullable<DateTime> sDate, string businessLoansTypes)
        {           
            this.LNo = lno;
            this.AccountNo = acctno;
            this.NAME = name;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.FirstSAmt = firstSamt;
            this.CurrentSanAmt = currentSamt;
            this.IntRate = intRate;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.ExpireDate = expireDate;
            this.SDate = sDate;
            this.BusinessLoansTypes = businessLoansTypes;
        }

        // Added By AAM (25_Jan_2018) For Business Loans Repay Listing Report
        public LOMDTO00405(string lno,string acctNo,string name,string address,string phone,decimal firstSAmt,DateTime voucherDate,DateTime expDate,
                            decimal currentSanAmt,DateTime datetime,decimal amount,string repayNo,decimal intForRepay,Nullable<decimal> intRate,
                            string sourceBr,string currency,string businessLoansTypes)
        {
            LNo = lno;
            AccountNo = acctNo;
            NAME = name;
            ADDRESS = address;
            PHONE = phone;
            FirstSAmt = firstSAmt;
            VoucherDate = voucherDate;
            ExpireDate = expDate;
            CurrentSanAmt = currentSanAmt;
            DATE_TIME = datetime;
            AMOUNT = amount;
            REPAYNO = repayNo;
            InterestForRepay = intForRepay;
            IntRate = intRate;
            SourceBranchCode = sourceBr;
            Currency = currency;
            BusinessLoansTypes = businessLoansTypes;
        }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string PHONE { get; set; }
        public virtual string PaidStatus { get; set; }
        public virtual Nullable<DateTime> IntPaidDate { get; set; }
        public virtual Nullable<decimal> FirstSAmt { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<DateTime> VoucherDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<DateTime> FirstDueDate { get; set; }
        public virtual Nullable<decimal> TotalLateFee { get; set; }
        public virtual Nullable<decimal> CurrentSanAmt { get; set; }
        public virtual Nullable<decimal> TODAmt { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual Nullable<decimal> TotalInt { get; set; }
        public virtual Nullable<decimal> LastInt { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<decimal> SCharges { get; set; }
        public virtual bool isSCharge { get; set; }


        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual Nullable<decimal> MinimumAmount { get; set; }
        public virtual Nullable<decimal> MaximumAmount { get; set; }

        public virtual string REPAYNO { get; set; }
        public virtual Nullable<decimal> InterestForRepay { get; set; }
        public virtual Nullable<decimal> RepayAmount { get; set; }
        public virtual Nullable<DateTime> RepayDate { get; set; }

        public virtual int NPLCase { get; set; }
        public virtual Nullable<DateTime> NPLDate { get; set; }
        public virtual string MarkNPLUser { get; set; }
        public virtual string NPLReleaseUser { get; set; }

        public virtual decimal LedgerBalance { get; set; }//Added by HWKO (15-Aug-2017)
        public virtual string BusinessLoansTypes { get; set; }

        public DateTime DATE_TIME { get; set; }// Added By AAM (25_Jan-2018)
        public decimal AMOUNT { get; set; }// Added By AAM (25_Jan-2018)
    }
}
