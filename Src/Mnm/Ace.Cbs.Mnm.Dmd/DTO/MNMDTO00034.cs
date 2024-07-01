using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00034
    {
        public MNMDTO00034() { }

        public MNMDTO00034(string acctno, string name, decimal cbal, decimal i1, decimal i2, decimal i3, decimal i4, string budget,string sourcebr)
        {
            this.Acctno = acctno;
            this.Name = name;
            this.Cbal = cbal;
            this.I1 = i1;
            this.I2 = i2;
            this.I3 = i3;
            this.I4 = i4;
            this.Budget = budget;
            this.SourceBr = sourcebr;
        }

        public virtual int Id { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual decimal I1 { get; set; }
        public virtual decimal I2 { get; set; }
        public virtual decimal I3 { get; set; }
        public virtual decimal I4 { get; set; }
        public virtual string Budget { get; set; }
        public virtual decimal I { get; set; }
        public virtual decimal Total { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
