using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00243
    {
        public LOMDTO00243() { }

        public LOMDTO00243(string plNo, string acctNo, string assessorName,string lawerName,string busiDesp
                           ,decimal monthlyIncome,string companyName,decimal docFees,string cur,string custName
                           ,string custNRC,string guaCompanyName,string guaName,string guaNRC,string guaPhone
                           ,decimal sanctionAmt,bool sCharge,decimal intRate, int repDuration, string installName
                            , DateTime expDate, int gracePeriod, string productType, string monthlyRepayDate)
        {
            PLNo = plNo;
            ACNo = acctNo;
            Assessor = assessorName;
            Lawer = lawerName;
            BUSIDESP = busiDesp;
            MonthlyIncome = monthlyIncome;
            CompanyName = companyName;
            DocFee = docFees;
            Cur = cur;
            CustName = custName;
            CustNRC = custNRC;
            GuaCompanyName = guaCompanyName;
            GuaName = guaName;
            GuaNRC = guaNRC;
            GuaPhone = guaPhone;
            SAmt = sanctionAmt;
            isSCharge = sCharge;
            IntRate = intRate;
            RepDuration = repDuration;
            InstallName = installName;
            ExpireDate = expDate;
            GracePeriod = gracePeriod; 
            ProductType = productType;
            MonthlyRepayDate = monthlyRepayDate;            
            
        }

        public string PLNo { get; set; }
        public string ACNo { get; set; }
        public string Assessor { get; set; }
        public string Lawer { get; set; }
        public string BUSIDESP { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string MonthlyRepayDate { get; set; }
        public string ProductType { get; set; }
        public string CompanyName { get; set; }
        public decimal DocFee { get; set; }
        public string Cur { get; set; }
        public string CustName { get; set; }
        public string CustNRC { get; set; }
        public string GuaCompanyName { get; set; }
        public string GuaName { get; set; }
        public string GuaNRC { get; set; }
        public string GuaPhone { get; set; }
        public decimal SAmt { get; set; }
        public bool isSCharge { get; set; }
        public decimal IntRate { get; set; }
        public int RepDuration { get; set; }
        public string InstallName { get; set; }
        public DateTime ExpireDate { get; set; }
        public int GracePeriod { get; set; }

    }
}
