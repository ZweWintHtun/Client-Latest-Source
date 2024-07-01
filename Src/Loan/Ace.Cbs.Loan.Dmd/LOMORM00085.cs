using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00085 : Supportfields<LOMORM00085>
    {
        public LOMORM00085() { }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string LoanProductCode { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual Nullable<decimal> PrincipalAmount { get; set; }
        public virtual Nullable<decimal> TotalInt { get; set; }
        public virtual Nullable<decimal> LastInt { get; set; }
        public virtual Nullable<decimal> AccuredInt { get; set; }
        public virtual Nullable<decimal> M1 { get; set; }
        public virtual Nullable<decimal> M2 { get; set; }
        public virtual Nullable<decimal> M3 { get; set; }
        public virtual Nullable<decimal> M4 { get; set; }
        public virtual Nullable<decimal> M5 { get; set; }
        public virtual Nullable<decimal> M6 { get; set; }
        public virtual Nullable<decimal> M7 { get; set; }
        public virtual Nullable<decimal> M8 { get; set; }
        public virtual Nullable<decimal> M9 { get; set; }
        public virtual Nullable<decimal> M10 { get; set; }
        public virtual Nullable<decimal> M11 { get; set; }
        public virtual Nullable<decimal> M12 { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual Nullable<DateTime> DATE_TIME { get; set; }

    }
}
