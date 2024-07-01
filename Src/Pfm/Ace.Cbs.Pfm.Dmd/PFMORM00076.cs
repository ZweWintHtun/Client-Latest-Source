using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Data Version ORM Entity
    /// </summary>
    [Serializable]    
    public class PFMORM00076  : Supportfields<PFMORM00076>
    { 
        public PFMORM00076() 
        {
        }

        public virtual string ORMName { get; set; }
        public virtual string ORMDescription { get; set; }
        public virtual string ORMProperties { get; set; }
        public virtual string DTOName { get; set; }
        public virtual string DataIdName { get; set; }
        public virtual IList<PFMORM00031> ServerDataVersions { get; set; }
    }
}