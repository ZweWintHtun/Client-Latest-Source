using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Product Type ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00101 : EntityBase<LOMORM00101>
    {
        public LOMORM00101() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
} 
