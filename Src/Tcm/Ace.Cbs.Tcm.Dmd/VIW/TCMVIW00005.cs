using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Dmd
{

    [Serializable]
    public class TCMVIW00005
    {

        /// <summary>
        /// VW_CLEANCASH
        /// </summary>
        public virtual int Id { get; set; }
        public virtual string Acode { get; set; }
        public virtual string Status { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string SourceCur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string WorkStation { get; set; }
    }
}
