using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00209 : EntityBase<LOMDTO00209>
    {
        public LOMDTO00209() { }
        public LOMDTO00209(string sourceBranch, string currency, DateTime startDate, DateTime endDate)
        {
            SourceBr = sourceBranch;
            Cur = currency;
            StartDate = startDate;
            EndDate = endDate;
        }

        public LOMDTO00209(string hpNo, string name,string address,string phoneno, string acctNo
                           ,decimal loanAmount, int term, DateTime regDate, DateTime expDate, string dealerName
                           ,string stockGroup,string nrc,decimal rentalPercent,decimal rentalChg,decimal downpayPercent)//,string phone
        {
            HPNo = hpNo;
            NAME = name;
            Address = address;//Added by HWKO (22-Dec-2017)
            PhoneNo = phoneno;//Added by HWKO (22-Dec-2017)
            Caccount = acctNo;
            LoanAmount = loanAmount;
            Term = term;
            CreatedDate = regDate;
            ExpiredDate = expDate;
            //PHONE = phone;
            Dname = dealerName;
            StockGroup = stockGroup;
            NRC = nrc;
            RCharges_Percent = rentalPercent;
            RentalCharges = rentalChg;
            DownPayPercent = downpayPercent;
         
        }

        public virtual string HPNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual string Address { get; set; }//Added by HWKO (22-Dec-2017)
        public virtual string PhoneNo { get; set; }//Added by HWKO (22-Dec-2017)
        public virtual string Caccount { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual int Term { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        //public virtual string PHONE { get; set; }
        public virtual string Dname { get; set; }
        public virtual string StockGroup { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

        public string NRC { get; set; }// Added By AAM (22-Dec-2017)

        public decimal RCharges_Percent { get; set; }// Added By AAM (22-Mar-2018)
        public decimal RentalCharges { get; set; }// Added By AAM (22-Mar-2018)
        public decimal DownPayPercent { get; set; }// Added By AAM (22-Mar-2018)
        
    }
}
