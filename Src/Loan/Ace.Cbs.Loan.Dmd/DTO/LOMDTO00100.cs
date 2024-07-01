using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00100 : EntityBase<LOMDTO00100>
    {
        public LOMDTO00100() { }

        public LOMDTO00100(string sourceBranch, string currency, string month,string year)
        {
            SourceBr = sourceBranch;
            Cur = currency;
            Month = month;
            Year = year;
        }

        public LOMDTO00100(string hpNo, string cacctno, string name, decimal principle, decimal installment, string term, string paymentType, DateTime dueDate)
        {
            HPNo = hpNo;
            AccountNo = cacctno;
            Name = name;
            Principle = principle;
            Installment = installment;
            PaymentTerm = term;
            PaymentType = paymentType;
            DueDate = dueDate;
        }
        //HPNo,AccountNo,Name,Principle,Installment,PaymentTerm,PaymentType,DueDate
        public string HPNo { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public decimal Principle { get; set; }
        public decimal Installment { get; set; }
        public string PaymentTerm { get; set; }
        public string PaymentType { get; set; }
        public DateTime DueDate { get; set; }

        public virtual string Year { get; set; }
        public virtual string Month { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }

    }
}
