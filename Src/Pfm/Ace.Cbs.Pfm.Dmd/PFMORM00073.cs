using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{    
    [Serializable]
    public class PFMORM00073 : EntityBase<PFMORM00073>
    {
        /// <summary>
        /// Freeze ORM Entity
        /// </summary>
        public PFMORM00073() { }

        public virtual string AccountNo { get; set; }
        public virtual string Reason { get; set; }
        public virtual DateTime FreezeDate { get; set; }
        public virtual string FreezeType { get; set; }
        public virtual string BranchCode { get; set; }
    }
}