using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// DTO for VW_PLRepaymentScheduleListing
    /// Created By HWKO (13-Jul-2017)
    /// </summary>
    ///
    [Serializable]
    public class LOMDTO00316
    {
        public LOMDTO00316() { }

                
        //Used For "PLRepaymentScheduleListingDAO.SelectPLOverdrawnListing"
        //Used For "PLRepaymentScheduleListingDAO.SelectPLOverdrawnListingByCompanyName"
        public LOMDTO00316(int id, string plno, string acno, string name,
            decimal monthlyIncome, string address, decimal firstSAmt, decimal intRate,
            int termNo, decimal installmentAmt, decimal interestAmt, DateTime duedate,
            DateTime paidDate, string sourceBr, decimal remainingCapital,string phone,
            DateTime interestDate,decimal totalLateFees,decimal odAmount,string cur,string status,string companyname
            )
        {
            this.Id = id;
            this.PLNO = plno;
            this.ACNo = acno;
            this.NAME = name;
            this.MonthlyIncome = monthlyIncome;
            this.ADDRESS = address;
            this.FirstSAmt = firstSAmt;
            this.IntRate = intRate;
            this.TermNo = termNo;
            this.InstallmentAmount = installmentAmt;
            this.InterestAmount = interestAmt;
            this.DueDate = duedate;
            this.PaidDate = paidDate;
            this.SourceBr = sourceBr;
            this.RemainingCapital = remainingCapital;
            this.PHONE = phone;
            this.InterestDate = interestDate;
            this.TotalLateFees = totalLateFees;
            this.ODAmount = odAmount;
            this.Cur = cur;
            this.Status = status;
            this.CompanyName = companyname;
        }

        //Added by HWKO (27-Oct-2017)
        //Used For "PLRepaymentScheduleListingDAO.SelectByPLNO"
        public LOMDTO00316(int id, string plno, string acno, string name,
            decimal monthlyIncome, string address, decimal firstSAmt, decimal intRate,
            int termNo, decimal installmentAmt, decimal interestAmt, DateTime dueDate, DateTime autoPayDate,//DateTime duedate replace with AutoPayDate
            DateTime paidDate, string sourceBr, decimal remainingCapital, string phone,
            DateTime interestDate, decimal totalLateFees, decimal odAmount, string cur, string status, string companyname
            , string nrc,string monthlyRepayDate,string productType, decimal actualInstallmentAmount)
        {
            this.Id = id;
            this.PLNO = plno;
            this.ACNo = acno;
            this.NAME = name;
            this.MonthlyIncome = monthlyIncome;
            this.MonthlyRepayDate = monthlyRepayDate;//Added by HMW (02.02.2023)
            this.ProductType = productType;//Added by HMW (02.02.2023)
            this.ActualInstallmentAmount = actualInstallmentAmount; //Added by KCM (05.07.2023)
            this.ADDRESS = address;
            this.FirstSAmt = firstSAmt;
            this.IntRate = intRate;
            this.TermNo = termNo;
            this.InstallmentAmount = installmentAmt;
            this.InterestAmount = interestAmt;

            this.DueDate = DueDate;//Added by HMW (02-02-2023)
            this.AutoPayDate = autoPayDate;
            this.PaidDate = paidDate;
            this.SourceBr = sourceBr;
            this.RemainingCapital = remainingCapital;
            this.PHONE = phone;
            this.InterestDate = interestDate;
            this.TotalLateFees = totalLateFees;
            this.ODAmount = odAmount;
            this.Cur = cur;
            this.Status = status;
            this.CompanyName = companyname;
            this.NRC = nrc;
            
            
        }

        //Added by HWKO (15-Aug-2017)
        //Used For "PLRepaymentScheduleListingDAO.SelectByDueDateForPLIntDuePreListing"
        public LOMDTO00316(int id, string plno, string acno, string name,
            decimal monthlyIncome, string address, decimal firstSAmt, decimal intRate,
            int termNo, decimal installmentAmt, decimal interestAmt, DateTime duedate,
            DateTime paidDate, string sourceBr, decimal remainingCapital, string phone,
            DateTime interestDate, decimal totalLateFees, decimal odAmount, string cur, string status, string companyname,decimal ledgerbalance
            , DateTime actualRepaidDate)
        {
            this.Id = id;
            this.PLNO = plno;
            this.ACNo = acno;
            this.NAME = name;
            this.MonthlyIncome = monthlyIncome;
            this.ADDRESS = address;
            this.FirstSAmt = firstSAmt;
            this.IntRate = intRate;
            this.TermNo = termNo;
            this.InstallmentAmount = installmentAmt;
            this.InterestAmount = interestAmt;
            this.DueDate = duedate;
            this.PaidDate = paidDate;
            this.SourceBr = sourceBr;
            this.RemainingCapital = remainingCapital;
            this.PHONE = phone;
            this.InterestDate = interestDate;
            this.TotalLateFees = totalLateFees;
            this.ODAmount = odAmount;
            this.Cur = cur;
            this.Status = status;
            this.CompanyName = companyname;
            this.LedgerBalance = ledgerbalance;//Added by HWKO (15-Aug-2017)
            this.ActualRepaidDate = actualRepaidDate; // Added By AAM (12_Apr_2018)
            this.TotalAmount = installmentAmt + interestAmt + totalLateFees + odAmount;// Added By ZMS (27-Jun-2018)
        }

        public LOMDTO00316(string plno, string sourceBr)
        {
            this.PLNO = plno;
            this.SourceBr = sourceBr;
        }

        public LOMDTO00316(DateTime startDate, DateTime endDate, string sourcebr, string currency)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBr = sourcebr;
            this.Cur = currency;
        }

        public LOMDTO00316(string companyname)
        {
            this.CompanyName = companyname;
        }

        public LOMDTO00316(string plno, string acno, string name, string companyname, string address, string phone,
            string absentTerm, decimal totalOdAmt)
        {
            this.PLNO = plno;
            this.ACNo = acno;
            this.NAME = name;
            this.CompanyName = companyname;
            this.ADDRESS = address;
            this.PHONE = phone;
            this.AbsentTerm = absentTerm;
            this.TotalODAmt = totalOdAmt;
        }

        public LOMDTO00316(string plno, string acno, string name, string paidTerm, DateTime paiddate, decimal totalRepayAmt)
        {
            this.PLNO = plno;
            this.ACNo = acno;
            this.NAME = name;
            this.PaidTerm = paidTerm;
            this.PaidDate = paiddate;
            this.TotalRepayAmt = totalRepayAmt;
        }

        public virtual int Id { get; set; }
        public virtual string PLNO { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual decimal MonthlyIncome { get; set; }        
        public virtual string ADDRESS { get; set; }
        public virtual decimal FirstSAmt { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal InstallmentAmount { get; set; }
        public virtual decimal InterestAmount { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime AutoPayDate { get; set; }
        public virtual DateTime PaidDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual decimal RemainingCapital { get; set; }
        public virtual string PHONE { get; set; }
        public virtual DateTime InterestDate { get; set; }
        public virtual decimal TotalLateFees { get; set; }
        public virtual decimal ODAmount { get; set; }
        public virtual string Cur { get; set; }
        public virtual string Status { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string AbsentTerm { get; set; }
        public virtual decimal TotalODAmt { get; set; }
        public virtual string PaidTerm { get; set; }
        public virtual decimal TotalRepayAmt { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual string NRC { get; set; }
        public virtual Nullable<DateTime> ActualRepaidDate { get; set; } 
        public virtual Nullable<decimal> TotalAmount { get; set; }

        public virtual decimal TotalLateFee_PTOD_OnIntRate { get; set; }
        public virtual decimal TotalLateFee_PTOD_OnLateFeeRate { get; set; }
        public virtual decimal TotalLateFee_ITOD_OnLateFeeRate { get; set; }
        public virtual decimal Principal_TOD { get; set; }
        public virtual decimal Interest_TOD { get; set; }

        public virtual string MonthlyRepayDate { get; set; }//Added by HMW (02.02.2023)
        public virtual string ProductType { get; set; }//Added by HMW (02.02.2023)

        public virtual decimal ActualInstallmentAmount { get; set; }//Added by KCM (05.07.2023)
    }

}
