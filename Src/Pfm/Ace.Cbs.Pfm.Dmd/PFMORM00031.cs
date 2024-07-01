using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Server Version ORM Entity
    /// </summary>
    [Serializable]    
    public class PFMORM00031  : EntityBase<PFMORM00031>
    { 
        public PFMORM00031() 
        {
            CCCDataVersions = new List<PFMORM00030>();
        }

        public virtual decimal Version { get; set; }
        public virtual string DataVersionId { get; set; }
        public virtual string DataIdValue { get; set; }
        public virtual int Status { get; set; }

       public virtual IList<PFMORM00030> CCCDataVersions { get; set; }
    }
}