using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00069 : EntityBase<LOMORM00069>
    {
        public LOMORM00069() { }

        public virtual string SubCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string GroupCode { get; set; }
        public virtual LOMORM00068 GroupCodeId { get; set; }
    }
}
