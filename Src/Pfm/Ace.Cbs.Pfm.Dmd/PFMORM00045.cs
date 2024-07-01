using System;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    // PrintRecord ORM - Passbook -> Transaction Printing 
    public class PFMORM00045 : EntityBase<PFMORM00045>
    {
        public PFMORM00045() { }

        public virtual string AcctNo { get; set; }
        public virtual System.Nullable<DateTime> DateTime { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal DAmt { get; set; }
        public virtual decimal CAmt { get; set; }
        public virtual string SourceBr { get; set; }

    }
}