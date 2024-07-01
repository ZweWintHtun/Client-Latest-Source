using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
    // Cledger Entity
    [Serializable]
    public class PFMORM00028 : Supportfields<PFMORM00028>
    {
        public PFMORM00028() 
        {
            //CAOFs = new List<PFMDTO00017>();
            //SAOFs = new List<PFMDTO00016>();
        }

        //Primary Key
        public virtual string AccountNo { get; set; }

        public virtual decimal CurrentBal { get; set; }
        public virtual decimal OverdraftLimit { get; set; }
        public virtual decimal MinimumBalance { get; set; }
        public virtual Nullable<DateTime> OverdraftDate { get; set; }
        public virtual decimal DayOfBalance { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal LoansCount { get; set; }
        public virtual decimal SavingInterestRate { get; set; }
        public virtual decimal TransactionCount { get; set; }
        public virtual decimal MonthOpeningBalance { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual decimal PrintLineNo { get; set; }
        public virtual System.Nullable<decimal> UsedRate { get; set; }
        public virtual System.Nullable<decimal> UnUsedRate { get; set; }
        public virtual string Code { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual string LastUserNo { get; set; }
        public virtual decimal TemporaryOverdraftLimit { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string CLINACCTNO { get; set; }
       public virtual System.Nullable<int> NoOfPersonSign { get; set; }
        // CustomerId Relation
        public virtual PFMORM00001 Customer { get; set; }
        //Source Branch Relation
        public virtual Branch Branch { get; set; }
        //Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        //CAOF Relation
        public virtual IList<PFMORM00017> CAOFs { get; set; }
        ////SAOF Relation
        public virtual IList<PFMORM00016> SAOFs { get; set; }
    }
}