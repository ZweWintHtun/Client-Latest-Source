using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00220 : EntityBase<LOMDTO00220>
    {
        public LOMDTO00220() { }

        public LOMDTO00220(string hpNo, string acctNo, string name, int termNo, decimal principal, decimal interest, decimal installment, decimal ledgerBal,string stockGroup,
                            DateTime LastSettlementDate, DateTime NextSettlementDate, int absentTerm)
        {
            HPNo = hpNo;
            AcctNo = acctNo;
            NAME = name;
            TermNo = termNo;
            Principal = principal;
            Interest = interest;
            Installment = installment;
            LedgerBalance = ledgerBal;
            StockGroup = stockGroup;
            this.LastSettlementDate = LastSettlementDate;
            this.NextSettlementDate = NextSettlementDate;
            this.AbsentTime = absentTerm;
        }

        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }       
        public virtual int TermNo { get; set; }
        public virtual decimal Principal { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Installment { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual string StockGroup { get; set; }

        public DateTime LastSettlementDate { get; set; }
        public DateTime NextSettlementDate { get; set; }

        public virtual int AbsentTime { get; set; }
    }
}
