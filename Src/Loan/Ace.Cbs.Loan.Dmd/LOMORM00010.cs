using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;


namespace Ace.Cbs.Loan.Dmd
{

    /// <summary>
    /// Kind Of Stock ORM Entity
    /// </summary>
    [Serializable]
   public class LOMORM00010 : EntityBase<LOMORM00010>
    {
      public LOMORM00010() { }

        public virtual string KStockNo { get; set; }
        public virtual string Desp { get; set; }
    }
}
