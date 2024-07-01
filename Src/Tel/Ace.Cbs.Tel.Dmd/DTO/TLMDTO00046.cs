using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACE.Windows.Core.DataModel;

namespace ACE.CBS.TLM.DMD
{
    [Serializable]
    class TLMDTO00046 : EntityBase<TLMDTO00046>
    {
        public TLMDTO00046() { }

        public virtual string Income { get; set; }
        public virtual string CommunicationCharges { get; set; }
    }
}
