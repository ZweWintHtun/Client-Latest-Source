using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// LSBusinessType ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00076 : EntityBase<LOMORM00076>
    {
        public LOMORM00076() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserNo { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
    }
}
