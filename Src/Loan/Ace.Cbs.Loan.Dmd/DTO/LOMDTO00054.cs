using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00054 : Supportfields<LOMDTO00054>
    {
        public LOMDTO00054() { }

        public LOMDTO00054(string acctNo,string lno,decimal m1,decimal m2,
            decimal m3,decimal m4,decimal m5,decimal m6,decimal m7,decimal m8,
                decimal m9,decimal m10,decimal m11,decimal m12) 
        {
            this.AcctNo = acctNo;
            this.LNo = lno;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
        }

        public virtual string AcctNo { get; set; }
        public virtual string LNo { get; set; }
        public virtual System.Nullable<decimal> M1 {get;set;}
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }

        public virtual string MonthNo { get; set; }
        public virtual string Budget { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
