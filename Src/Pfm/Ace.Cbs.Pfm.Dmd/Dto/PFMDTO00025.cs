using System;
using Ace.Windows.Core.DataModel;
using System.Collections.Generic;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00025 : Supportfields<PFMDTO00025>
    {
        /// <summary>
        /// COASetup Entity
        /// </summary>

        public PFMDTO00025(string accountNo)
        {
            this.AccountNo = accountNo;
        }

        public PFMDTO00025()
        {
            this.COAAccountName = new List<PFMORM00024>();
        }

        public virtual string AccountNo { get; set; }
        public virtual string AccountName { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string Channel { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }

        //Source Branch Relation
        public virtual BranchDTO Branch { get; set; }
        //Currency Relation
        public virtual PFMDTO00027 Currency { get; set; }
        public virtual IList<PFMORM00024> COAAccountName { get; set; } 
    }
}