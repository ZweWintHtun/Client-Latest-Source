using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00336
    {
        public LOMDTO00336() { }

        public LOMDTO00336(decimal loanamount, string acctNo, string custName, string custNrc, string custAddress,
            string custFatherName, string guaname, string guanrc, string guacompanyname, decimal rchgRate, string termno,
            DateTime duedate, decimal installAmtPerTerm, decimal rchgAmtPerTerm, DateTime ftduedate, DateTime ltduedate,
            decimal totalinstallmentAmt)
        {
            this.LoanAmount = loanamount;
            this.AcctNo = acctNo;
            this.CustName = custName;
            this.CustNRC = custNrc;
            this.CustAddress = custAddress;
            this.CustFatherName = custFatherName;
            this.GuaName = guaname;
            this.GuaNRC = guanrc;
            this.GuaCompanyName = guacompanyname;
            this.RChgRate = rchgRate;
            this.TermNo = termno;
            this.DueDate = duedate;
            this.InstallAmtPerTerm = installAmtPerTerm;
            this.RChgAmtPerTerm = rchgAmtPerTerm;
            this.FTDueDate = ftduedate;
            this.LTDueDate = ltduedate;
            this.TotalInstallmentAmt = totalinstallmentAmt; 
        }

        public LOMDTO00336(string custName,string custnrc,string custfathername,string custaddress)
        {
            this.CustName = custName;
            this.CustNRC = custnrc;
            this.CustFatherName = custfathername;
            this.CustAddress = custaddress;
        }

        public virtual string PLNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime DateFromView { get; set; }
        public virtual string Reason { get; set; }
        //Added By AAM (06_Aug_2018)
        public virtual string startYear { get { return GetMyanmarString(FTDueDate.Year.ToString()); } }
        public virtual string startMonth { get { return monthArr[FTDueDate.Month-1]; } } 
        public virtual string startDay { get { return GetMyanmarString(FTDueDate.Day.ToString()); } }
        public virtual string endYear { get { return GetMyanmarString(LTDueDate.Year.ToString()); } }
        public virtual string endMonth { get { return monthArr[LTDueDate.Month - 1]; } }
        public virtual string endDay { get { return GetMyanmarString(LTDueDate.Day.ToString()); } }
        
        public virtual decimal LoanAmount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string CustName { get; set; }
        public virtual string CustNRC { get; set; }
        public virtual string CustAddress { get; set; }
        public virtual string CustFatherName { get; set; }
        public virtual string GuaName { get; set; }
        public virtual string GuaNRC { get; set; }
        public virtual string GuaCompanyName { get; set; }
        public virtual decimal RChgRate { get; set; }
        public virtual string TermNo { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal InstallAmtPerTerm { get; set; }
        public virtual decimal RChgAmtPerTerm { get; set; }
        public virtual DateTime FTDueDate { get; set; }//First Term Due Date
        public virtual DateTime LTDueDate { get; set; }//Last Term Due Date
        //public virtual decimal TotalInstallmentAmt { get; set; }//Total Installment Amt without Down Payment for all terms
        public virtual decimal TotalInstallmentAmt
        {
            get { return InstallAmtPerTerm + RChgAmtPerTerm; }
            set{}
        }

        string[] monthArr = { "ဇန္န၀ါရီ", "ေဖေဖာ္၀ါရီ", "မတ္", "ဧၿပီ", "ေမ", "ဇြန္", "ဇူလိုင္",
                                "ၾသဂုတ္", "စက္တင္ဘာ", "ေအာက္တိုဘာ", "ႏို၀င္ဘာ", "ဒီဇင္ဘာ" };
        string[] numArr = { "၀", "၁", "၂", "၃", "၄", "၅","၆","၇","၈","၉"};

        private string GetMyanmarString(string str)
        {
            string strMya = str;
            for (int i = 0; i < 10; i++)
            {
                strMya = strMya.Replace(i.ToString(), numArr[i]);
            }
            return strMya;
        }

    }
}
