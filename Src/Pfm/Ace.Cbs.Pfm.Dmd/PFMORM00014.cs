using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print Cheque ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00014  : EntityBase<PFMORM00014>
    {
        public PFMORM00014() {  }
                
        public virtual string AccountNo { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string UserNo { get; set; }       
        public virtual string ChequeBookNo { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        
    }
}