using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00076 : EntityBase<MNMVIW00076>
    {
        public virtual int Id { get; set; }
        public virtual string PONO { get; set; }
        public virtual string ACCTNO { get; set; }
        public virtual DateTime ADATE { get; set; }
        public virtual DateTime IDATE { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string CUR { get; set; }
        public virtual string SourceBr { get; set; }
    }
}
