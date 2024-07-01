using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{   
    // [ PrintRecord DTO]
    [System.Serializable]
    public class PFMDTO00045 : EntityBase<PFMDTO00045>
    {
        public PFMDTO00045() { }       

        public virtual string AcctNo { get; set; }
        public virtual System.Nullable<DateTime> DateTime { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal DAmt { get; set; }
        public virtual decimal CAmt { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Reference { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual bool WithdrawlStatus { get; set; }
    }


}