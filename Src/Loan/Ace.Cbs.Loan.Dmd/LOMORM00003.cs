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
    public class LOMORM00003 : EntityBase<LOMORM00003>
    {
        public LOMORM00003() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
