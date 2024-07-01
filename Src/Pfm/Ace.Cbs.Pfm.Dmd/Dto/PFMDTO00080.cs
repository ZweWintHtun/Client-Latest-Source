using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
   
    [Serializable]
    public class PFMDTO00080 
    {
        public PFMDTO00080()
        {          
        }
        public PFMDTO00080(string resCode, string resDep)
        {
            this.ResCode = resCode;
            this.ResDesp = resDep;
        }
        public virtual string ResCode { get; set; }
        public virtual string ResDesp { get; set; }
    }
}