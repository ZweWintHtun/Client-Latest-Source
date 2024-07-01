using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //LinkAccount (LinkAC) Entity
    [Serializable]
    public class PFMORM00029 : EntityBase<PFMORM00029>
    {
        public PFMORM00029() { }       

        public virtual string CurrentAccountNo { get; set; }
        public virtual string SavingAccountNo { get; set; }
        public virtual string CALACCTNO { get; set; }
        public virtual decimal MinimumCurrentAccountBalance { get; set; }        
        public virtual decimal MinimumSavingAccountBalance { get; set; }
        public virtual decimal MinimumLinkAccountBalance { get; set; }
        public virtual string FirstPriority { get; set; }
        public virtual string SecondPriority { get; set; }
        public virtual string ThirdPriority { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual System.Nullable<DateTime> AccessDate { get; set; }
        public virtual System.Nullable<DateTime> CALDATE { get; set; }

        //Source Branch Relation
        public virtual Branch Branch { get; set; }
        //Currency Relation
        public virtual CurrencyDTO Currency { get; set; }
    
    }
}