using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00086 : EntityBase<LOMORM00086>
    {
        public LOMORM00086() { }

        public virtual int Id { get; set; }
        public virtual string Eno { get; set; }
        public virtual string LoanType { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string FinancialYear { get; set; }
        public virtual string BusinessCode { get; set; }
        public virtual DateTime SuspendDate { get; set; }
        public virtual decimal SuspendAmu { get; set; }
        public virtual DateTime DeliverDate { get; set; }
        public virtual string TotalGroup { get; set; }
        public virtual string Population { get; set; }
        public virtual string Acre { get; set; }
        public virtual decimal SanctionAmu { get; set; }
        public virtual DateTime RefundDate { get; set; }
        public virtual decimal RefundAmu { get; set; }
        public virtual string RefundVrNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string BusinessTypeUM { get; set; }

    }
}
