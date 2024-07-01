using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
    [Serializable]
    public class TLMDTO00058
    {
        public TLMDTO00058() { }

        public TLMDTO00058(decimal debitCash, decimal debitTransfer, decimal debitClearing, decimal debitTotal, string accountNo, decimal creditCash, decimal creditClearing, decimal creditTransfer, decimal creditTotal, DateTime dateTime, DateTime sortDatetime, string workStation, decimal rate, DateTime settlementDate, string sourceCur, string sourceBr)
        {
            this.Debit_Cash = debitCash;
            this.Debit_Transfer = debitTransfer;
            this.Debit_Clearing = debitClearing;
            this.Debit_Total = debitTotal;
            this.Account_No = accountNo;
            this.Credit_Cash = creditCash;
            this.Credit_Clearing = creditClearing;
            this.Credit_Transfer = creditTransfer;
            this.Credit_Total = creditTotal;
            this.Date_Time = dateTime;
            this.Sort_Date_Time = sortDatetime;
            this.WorkStation = workStation;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourceCur;
            this.SourceBr = sourceBr;
        }

        //Added by HWKO (23-Nov-2017)
        public TLMDTO00058(decimal debitCash, decimal debitTransfer, decimal debitClearing, decimal debitTotal, string accountNo, decimal creditCash, decimal creditClearing,
            decimal creditTransfer, decimal creditTotal, DateTime dateTime, DateTime sortDatetime, string workStation, decimal rate, DateTime settlementDate,
            string sourceCur, string sourceBr, string acnoDesp)
        {
            this.Debit_Cash = debitCash;
            this.Debit_Transfer = debitTransfer;
            this.Debit_Clearing = debitClearing;
            this.Debit_Total = debitTotal;
            this.Account_No = accountNo;
            this.Credit_Cash = creditCash;
            this.Credit_Clearing = creditClearing;
            this.Credit_Transfer = creditTransfer;
            this.Credit_Total = creditTotal;
            this.Date_Time = dateTime;
            this.Sort_Date_Time = sortDatetime;
            this.WorkStation = workStation;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourceCur;
            this.SourceBr = sourceBr;
            this.ACNoDesp = acnoDesp;
        }

        //Added by HMW (13-May-2019) for "Seperating EOD Process: Day Book" to order by eno for the same date time back date TXNs
        public TLMDTO00058(string eno, decimal debitCash, decimal debitTransfer, decimal debitClearing, decimal debitTotal, string accountNo, decimal creditCash, decimal creditClearing, decimal creditTransfer, decimal creditTotal, DateTime dateTime, DateTime sortDatetime, string workStation, decimal rate, DateTime settlementDate, string sourceCur, string sourceBr)
        {
            this.Eno = eno;
            this.Debit_Cash = debitCash;
            this.Debit_Transfer = debitTransfer;
            this.Debit_Clearing = debitClearing;
            this.Debit_Total = debitTotal;
            this.Account_No = accountNo;
            this.Credit_Cash = creditCash;
            this.Credit_Clearing = creditClearing;
            this.Credit_Transfer = creditTransfer;
            this.Credit_Total = creditTotal;
            this.Date_Time = dateTime;
            this.Sort_Date_Time = sortDatetime;
            this.WorkStation = workStation;
            this.Rate = rate;
            this.SettlementDate = settlementDate;
            this.SourceCur = sourceCur;
            this.SourceBr = sourceBr;
        }

        public virtual int Id { get; set; }

        //Added by HMW for "Seperating EOD Process: Day Book" to order by eno for the same date time back date TXNs
        public virtual String Eno { get; set; }

        public virtual System.Nullable<decimal> Debit_Cash { get; set; }
        public virtual System.Nullable<decimal> Debit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Debit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Debit_Total { get; set; }
        public virtual string Account_No { get; set; }

        public virtual System.Nullable<decimal> Credit_Cash { get; set; }
        public virtual System.Nullable<decimal> Credit_Clearing { get; set; }
        public virtual System.Nullable<decimal> Credit_Transfer { get; set; }
        public virtual System.Nullable<decimal> Credit_Total { get; set; }

        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<DateTime> Sort_Date_Time { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string ReportTitle { get; set; }

        public virtual string ReportTitle1 { get; set; }
        public virtual string ReportTitle2 { get; set; }

        public virtual string BranchCode { get; set; }

        public virtual string ACNoDesp { get; set; }//Added by HWKO (23-Nov-2017)

        //Added by ZMS (27-JUN-2018)
        public virtual int recordcount { get; set; }
        public virtual string HeadACNo { get; set; }
        public virtual string HeadACNoDesp { get; set; }
        //
    }
}

