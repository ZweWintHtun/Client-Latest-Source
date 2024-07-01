using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{

    /// <summary>
    /// GoodWill ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00006 : EntityBase<LOMORM00006>
    {
        public LOMORM00006() { }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
