using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// [VW_MOB831]  // select from VW_RD
    /// </summary
    [Serializable]
    public class MNMVIW00031 : Supportfields<MNMVIW00031>
    {
        public MNMVIW00031() { }

        public virtual int Id { get; set; }
        public virtual string DrawingNo { get; set; }
        public virtual string RegisterNo { get; set; }
        public virtual string Br_Alias { get; set; }
        public virtual string Type { get; set; }
        public virtual string NRC { get; set; }
        public virtual string ToName { get; set; }
        public virtual string ToNRC { get; set; }
        public virtual Nullable<decimal> TLXCharges { get; set; }
        public virtual Nullable<decimal> Comission { get; set; }
        public virtual string DBank { get; set; }
        public virtual Nullable<DateTime> ReceiptDate { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual Nullable<decimal> Amount { get; set; }
        public virtual Nullable<DateTime> DateTime { get; set; }
        public virtual string Currency { get; set; }
        public virtual Nullable<DateTime> SettlementDate { get; set; }
        public virtual bool OtherBank { get; set; }
        public virtual string BankAlias { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
