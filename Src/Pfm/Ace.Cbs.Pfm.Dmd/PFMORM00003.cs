using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Initial Entity
    [Serializable]
    public class PFMORM00003: Supportfields<PFMORM00003>
    {
        public PFMORM00003() { }

        // Primary key
        public virtual string Initial { get; set; }
        public virtual string Description { get; set; }
        public virtual User CreatedUser { get; set; }

    }
}