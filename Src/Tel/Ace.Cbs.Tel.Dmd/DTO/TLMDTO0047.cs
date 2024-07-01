using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACE.Windows.Core.DataModel;

namespace ACE.CBS.TLM.DMD.DTO
{
    public class TLMDTO0047 : Supportfields<TLMDTO0047>
    {
        public TLMDTO0047() { }

        public virtual string CurrencyCode { get; set; }
        public virtual string LinkAmount { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual bool IsVIP { get; set; }
        public virtual string NoOfPersonSign { get; set; }
        public virtual string JoinType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual string IncomeType { get; set; }
        public virtual decimal CommunicationCharges { get; set; }
        public virtual decimal Commissions { get; set; }
        public virtual string Name { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual string WithdrawType { get; set; }
        public virtual string ExchangeRate { get; set; }
        public virtual bool LinkStatus { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string SettlementDate { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string DenoString { get; set; }
        public virtual string DenoRateString { get; set; }
        public virtual string RefundString { get; set; }
        public virtual string RefundRateString { get; set; }
        public virtual string AccountSing { get; set; }
        public virtual string Channel { get; set; }
        public virtual string CounterNo { get; set; }
             





    }
}
