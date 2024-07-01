using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// VW_LOANS_LEGAL_LIST
    /// </summary>
    ///  
    [Serializable]
    public class LOMVIW00001 
    {
        public LOMVIW00001() { }
        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string Cur { get; set; }
        public virtual string Name { get; set; }
        public virtual string AType { get; set; }
        public virtual string LoansDesp { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<DateTime> LegalDate { get; set; }
        public virtual Nullable<DateTime> NplDate { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual bool NplCase { get; set; }
    }
}
