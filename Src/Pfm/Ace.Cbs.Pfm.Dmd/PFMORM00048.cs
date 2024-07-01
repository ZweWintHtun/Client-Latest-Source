using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Message ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00048 : Supportfields<PFMORM00048>
    {
        public PFMORM00048() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}