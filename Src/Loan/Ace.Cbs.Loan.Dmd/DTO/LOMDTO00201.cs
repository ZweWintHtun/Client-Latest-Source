using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00201 : EntityBase<LOMDTO00201>
    {
        public LOMDTO00201() { }

        public LOMDTO00201(decimal amt)
        {
            Amount = amt;
        }
        public virtual  string HPNo { get; set; }
        public virtual string TermNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime PaidDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal ODAmount { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal TotalLateFees { get; set; }
        public virtual decimal LastInt { get; set; }
        public virtual DateTime LastDate { get; set; }
        public virtual DateTime LateFeePaidDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int CreatedUserId { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual int UpdatedUserId { get; set; }
    }
}
