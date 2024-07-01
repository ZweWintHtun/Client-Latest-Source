using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Balance entity
    [Serializable]
    public class PFMORM00033 : Supportfields<PFMORM00033>
    {
        public PFMORM00033(){}

        public virtual int Id { get; set; }

        // Not Relation because Saving,Current,Fixed.
        public virtual string AccountNo { get; set; }

        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal Month1 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth1 { get; set; }
        public virtual decimal Month2 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth2 { get; set; }
        public virtual decimal Month3 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth3 { get; set; }
        public virtual decimal Month4 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth4 { get; set; }
        public virtual decimal Month5 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth5 { get; set; }
        public virtual decimal Month6 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth6 { get; set; }
        public virtual decimal Month7 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth7 { get; set; }
        public virtual decimal Month8 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth8 { get; set; }
        public virtual decimal Month9 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth9 { get; set; }
        public virtual decimal Month10 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth10 { get; set; }
        public virtual decimal Month11 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth11 { get; set; }
        public virtual decimal Month12 { get; set; }
        public virtual System.Nullable<decimal> TransactionCountOfMonth12 { get; set; }

        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }

        //Branch Relation
        public virtual PFMORM00033 Branch { get; set; }

        //currency Relation
        public virtual CurrencyDTO Currency { get; set; }

    }
}