using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00008 : Supportfields<LOMORM00008>
    {
        public virtual string Kind { get; set; }
        public virtual string Description { get; set; }
    }
}
