using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Fledger entity
    [Serializable]
    public class PFMORM00023 : Supportfields<PFMORM00023>
    {
        public PFMORM00023() { }

        public PFMORM00023(string accountSing, string currencyCode)
        {
            this.AccountSignature = accountSing;

            this.CurrencyCode = currencyCode;
        }

        // Primary Key
        public virtual string AccountNo { get; set; }
        public virtual decimal FixedBalance { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual decimal LinkLimit { get; set; }
        public virtual string DebitAccountNo { get; set; }
        public virtual int PrintLineNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo { get; set; }

        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }

    }
}