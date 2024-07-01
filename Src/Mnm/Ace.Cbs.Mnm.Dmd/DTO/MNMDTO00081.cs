using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00081 : EntityBase<MNMDTO00081>
    {
        public MNMDTO00081() { }

        public MNMDTO00081(string accountno, string name, string receiptno, decimal accrued, decimal budgetendaccount)
        {
            this.AccountNo = accountno;
            this.ReceiptNo = receiptno;
            this.BudgetEndAccount = budgetendaccount;
            this.Accrued = accrued;
            this.Name = name; 
        }

        public virtual string ReceiptNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal BudgetEndAccount { get; set; }
        public virtual decimal Accrued { get; set; }
        public virtual string Name { get; set; }

    }
}
