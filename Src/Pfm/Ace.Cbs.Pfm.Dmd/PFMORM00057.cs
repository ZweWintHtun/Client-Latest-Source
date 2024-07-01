using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{    
    [Serializable]
    public class PFMORM00057 : Supportfields<PFMORM00057>
    {
        /// <summary>
        /// NewSetup Entity
        /// </summary>
        public PFMORM00057() { }
        public virtual string Variable { get; set; }
        public virtual string Value { get; set; }
        //public virtual string Status { get; set; }
       
    }
}