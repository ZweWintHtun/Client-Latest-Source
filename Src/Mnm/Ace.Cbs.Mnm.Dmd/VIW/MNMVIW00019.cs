using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_BANKSTATEMENT_ALL
    /// </summary>
    /// 
    [Serializable]
    public class MNMVIW00019 : Supportfields<MNMVIW00019>
    {
        public MNMVIW00019() { }
        public virtual int Id { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal WithdrawAmount { get; set; }
        public virtual decimal DepositAmount { get; set; }
        public virtual string S { get; set; }
        public virtual string Workstation { get; set; }
        public virtual DateTime chktime { get; set; }        
        public virtual string SourceBr { get; set; }
        
    }
}
