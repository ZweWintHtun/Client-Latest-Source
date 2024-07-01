using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00222 : EntityBase<LOMDTO00222>
    {
        public LOMDTO00222() { }

        public LOMDTO00222(string lno, string acctNo, string name, int termNo, decimal interest, decimal installment, decimal ledgerBal, string businessType,
                            DateTime LastSettlementDate, DateTime NextSettlementDate, int absentTerm)
        {
            Lno = lno;
            Acctno = acctNo;
            NAME = name;
            TermNo = termNo;
            Interest = interest;
            Installment = installment;
            LedgerBalance = ledgerBal;
            BusinessType = businessType;
            this.LastSettlementDate = LastSettlementDate;
            this.NextSettlementDate = NextSettlementDate;
            this.AbsentTime = absentTerm;
        }

        public virtual string Lno { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Installment { get; set; }
        public virtual string BusinessType { get; set; }

        public DateTime LastSettlementDate { get; set; }
        public DateTime NextSettlementDate { get; set; }

        public virtual int AbsentTime { get; set; }
    }
}
