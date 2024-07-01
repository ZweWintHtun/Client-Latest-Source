using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Cheque Entity
    [Serializable]
    public class PFMORM00006 : EntityBase<PFMORM00006>
    {
        public PFMORM00006() { }

        // Primary Key
        public virtual string ChequeBookNo { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string StartNo { get; set; }
        public virtual string EndNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual System.Nullable<DateTime> IssueDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string AccountSign { get; set; }

        //Source Branch Relation
        public virtual Branch Branch { get; set; }


        //Cledger AccountNo Relation
        public virtual PFMORM00028 Cledger { get; set; }

        //Currency Relation
        public virtual CurrencyDTO Currency { get; set; }
    }
}