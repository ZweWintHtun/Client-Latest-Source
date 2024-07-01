using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// LAND ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00005 : EntityBase<LOMORM00005>
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
