﻿using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Mnm.Dmd
{
    public class MNMORM00007 : Supportfields<MNMORM00007>
    {
        public MNMORM00007() { }

        public virtual int Id { get; set; }

        // Considering
        public virtual string AccountNo { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual string Status { get; set; }
        public virtual string Budget { get; set; }
        public virtual decimal LastInt { get; set; }
        public virtual Nullable<decimal> AccruedInt { get; set; }
        public virtual decimal Month1 { get; set; }
        public virtual decimal Month2 { get; set; }
        public virtual decimal Month3 { get; set; }
        public virtual decimal Month4 { get; set; }
        public virtual decimal Month5 { get; set; }
        public virtual decimal Month6 { get; set; }
        public virtual decimal Month7 { get; set; }
        public virtual decimal Month8 { get; set; }
        public virtual decimal Month9 { get; set; }
        public virtual decimal Month10 { get; set; }
        public virtual decimal Month11 { get; set; }
        public virtual decimal Month12 { get; set; }

        public virtual string SourceBranchCode { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CurrencyCode { get; set; }

        // Currency relation
        public virtual CurrencyDTO Currency { get; set; }

        // Source Branch relation
        public virtual Branch Branch { get; set; }
    }
}
