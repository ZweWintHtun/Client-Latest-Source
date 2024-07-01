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
    public class LOMORM00404 : EntityBase<LOMORM00404>
    {
        public LOMORM00404() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string RelatedGLACode { get; set; }
    }
}
