using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Counter Version ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00030 : EntityBase<PFMORM00030>
    {
        public PFMORM00030() { }

        public virtual string CounterId { get; set; }
        public virtual int ServerVersionId { get; set; }
        public virtual PFMORM00031 ServerDataVersion { get; set; }
    }
}