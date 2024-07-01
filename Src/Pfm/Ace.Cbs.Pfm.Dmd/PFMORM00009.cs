using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Rate File entity
    [Serializable]
    public class PFMORM00009 : Supportfields<PFMORM00009>
    {
        public PFMORM00009() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }      
        public virtual DateTime DATE_TIME { get; set;  }
        public virtual bool LASTMODIFY { get; set; }
        public virtual string USERNO { get; set;  }
        
        public virtual decimal Rate { get; set; }
        public virtual decimal Duration { get; set; }
    }
}