using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// Business ORM Entity
    /// </summary>
    [Serializable]
    public class LOMORM00001 : EntityBase<LOMORM00001>
    {
        public LOMORM00001() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
} 
