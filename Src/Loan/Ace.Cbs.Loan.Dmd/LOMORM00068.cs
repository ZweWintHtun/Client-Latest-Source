using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Hire Purchase Stock Group ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00068 : EntityBase<LOMORM00068>
    {
        public LOMORM00068() { }

        public virtual string GroupCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string PreFix { get; set; }
    }
}
