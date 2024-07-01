using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00203 : EntityBase<LOMDTO00203>
    {
        public LOMDTO00203() { }

        public LOMDTO00203(string sourceBranch, string currency, string month)
        {
            SourceBr = sourceBranch;
            this.Currency = currency;
            Month = month;
        }

        public LOMDTO00203(string hpno, string acctno, string name, string termno, decimal amt, decimal cBal, DateTime dueDate)
        {
            HPNo = hpno;
            AcctNo = acctno;
            Name = name;
            TermNo = termno;
            Amount = amt;
            CBal = cBal;
            DueDate = dueDate;
        }

        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string TermNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int CreatedUserId { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual int UpdatedUserId { get; set; }

        public virtual string Month { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Currency { get; set; }
    }
}
