using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00221 : EntityBase<LOMDTO00221>
    {
        public LOMDTO00221() { }

        public LOMDTO00221(string plNo, string acctNo, string name, int termNo, decimal principal, decimal interest, decimal installment, decimal ledgerBal, string companyName,
                            DateTime LastSettlementDate, DateTime NextSettlementDate, int absentTerm)
        {
            PLNO = plNo;
            Acctno = acctNo;
            NAME = name;
            TermNo = termNo;
            Principal = principal;
            Interest = interest;
            Installment = installment;
            LedgerBalance = ledgerBal;
            CompanyName = companyName;
            this.LastSettlementDate = LastSettlementDate;
            this.NextSettlementDate = NextSettlementDate;
            this.AbsentTime = absentTerm;
        }

        public virtual string PLNO { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string NAME { get; set; }
        public virtual int TermNo { get; set; }
        public virtual decimal Principal { get; set; }
        public virtual decimal Interest { get; set; }
        public virtual decimal Installment { get; set; }
        public virtual decimal LedgerBalance { get; set; }
        public virtual string CompanyName { get; set; }

        public DateTime LastSettlementDate { get; set; }
        public DateTime NextSettlementDate { get; set; }

        public virtual int AbsentTime { get; set; }
    }
}
