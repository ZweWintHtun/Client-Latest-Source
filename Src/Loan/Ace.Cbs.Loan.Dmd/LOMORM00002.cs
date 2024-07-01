using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
     /// <summary>
    /// Advance ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00002 : EntityBase<LOMORM00002>
    {
        public LOMORM00002() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
