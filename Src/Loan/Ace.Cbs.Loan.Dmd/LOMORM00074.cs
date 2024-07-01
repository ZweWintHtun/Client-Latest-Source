using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Product Code ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00074 : EntityBase<LOMORM00074>
    {
        public LOMORM00074() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string USERNO { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
    }
}