using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00096 : EntityBase<LOMDTO00096>
    {
        public LOMDTO00096() { }

        public LOMDTO00096(string sourceBranch, string currency, DateTime startDate, DateTime endDate)
        {
            this.SourceBr = sourceBranch;
            this.Cur = currency;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public LOMDTO00096(string hpNo,string cacctno,string name,string dealerName,string stockType,
                           decimal principle,int term,decimal rentalChg,decimal commi,decimal docFees,DateTime regDate,DateTime expDate,string stockGroup)
        {
            HPNo = hpNo;
            Caccount = cacctno;
            NAME = name;
            Dname = dealerName;
            Description = stockType;
            LoanAmount = principle;
            Term = term;
            RentalCharges = rentalChg;
            Commission = commi;
            DocFees = docFees;
            CreatedDate = regDate;
            ExpiredDate = expDate;
            StockGroup = stockGroup;
        }
        //a.HPNo,a.Caccount,cu.Name,a.Dname,a.StockItems,a.LoanAmount,a.Installment,a.Term,a.Name,a.CreatedDate
        public string HPNo { get; set; }
        public string Caccount { get; set; }
        public string NAME { get; set; }
        public string Dname { get; set; }
        public string Description { get; set; }
        public decimal LoanAmount { get; set; }
        public int Term { get; set; }
        public decimal RentalCharges { get; set; }
        public decimal Commission { get; set; }
        public decimal DocFees { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string StockGroup { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

    }
}
