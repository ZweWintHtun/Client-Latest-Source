using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMORM00415 :EntityBase<LOMORM00415>
    {
        public LOMORM00415() { }

        public virtual string ProductCode { get; set; }
        public virtual string Description { get; set; }
        public virtual string RelatedGLACode { get; set; }

    }
}

