using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_BANKSTATEMENT_SAOF
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00020 : Supportfields<MNMVIW00020> 
    {
        public MNMVIW00020() { }
        public virtual int Id { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string NRC { get; set; }
        public virtual decimal Cbal { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string SourceBr { get; set; }      
    }
}
