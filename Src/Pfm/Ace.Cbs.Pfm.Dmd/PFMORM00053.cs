using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// AppSettings ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00053 : EntityBase<PFMORM00053>
    {
        public PFMORM00053() { }

        public virtual string KeyName { get; set; }
        public virtual string KeyValue { get; set; }
        public virtual byte[] BinaryValue { get; set; }
        public virtual string Description { get; set; }
        public virtual int Location { get; set; }
        public virtual int Type { get; set; }
    }
}
