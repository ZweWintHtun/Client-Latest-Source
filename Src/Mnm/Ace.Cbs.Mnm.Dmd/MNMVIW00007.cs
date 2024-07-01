using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00007 : EntityBase<MNMVIW00007>
    {
        public MNMVIW00007()
        {
        }
        public virtual string ENO { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string STATUS { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string CRPARTICULAR { get; set; }
        public virtual decimal CR_CURRENT { get; set; }
        public virtual decimal CR_SAVING { get; set; }
        public virtual decimal CR_CALL { get; set; }
        public virtual decimal CR_FIXED { get; set; }
        public virtual decimal CR_DOMESTIC { get; set; }
        public virtual string DRPARTICULAR { get; set; }
        public virtual decimal DR_CURRENT { get; set; }
        public virtual decimal DR_SAVING { get; set; }
        public virtual decimal DR_CALL { get; set; }
        public virtual decimal DR_FIXED { get; set; }
        public virtual decimal DR_DOMESTIC { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual DateTime SETTLEMENTDATE { get; set; }

    }
}
