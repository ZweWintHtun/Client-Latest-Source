using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Dmd
{
 
    [Serializable]
    public class TCMVIW00006
    {
        /// <summary>
        ///  VW_CLEANCASH_BYHOMECUR
        /// </summary>
        public virtual int Id { get; set; }
        public virtual string Acode { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string WorkStation { get; set; }
    }
}
