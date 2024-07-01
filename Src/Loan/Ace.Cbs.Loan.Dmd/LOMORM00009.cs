using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{

    /// <summary>
    /// Stock Code ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00009 : EntityBase<LOMORM00009>
    {
         public LOMORM00009() { }

        public virtual string StockNo { get; set; }
        public virtual string Name { get; set; }
    }
}
