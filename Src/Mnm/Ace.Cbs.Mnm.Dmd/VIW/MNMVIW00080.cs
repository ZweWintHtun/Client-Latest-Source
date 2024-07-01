using System;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// VW_TRANSFERSCROLL_WITHOUT_REVERSAL_Home
    /// </summary>
    [Serializable]
    public class MNMVIW00080 : Supportfields<MNMVIW00080>
    {
        public virtual int Id { get; set; }
        public virtual string ENO { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string STATUS { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string CRPARTICULAR { get; set; }
        public virtual System.Nullable<decimal> CR_CURRENT { get; set; }
        public virtual System.Nullable<decimal> CR_SAVING { get; set; }
        public virtual System.Nullable<decimal> CR_CALL { get; set; }
        public virtual System.Nullable<decimal> CR_FIXED { get; set; }
        public virtual System.Nullable<decimal> CR_DOMESTIC { get; set; }
        public virtual string DRPARTICULAR { get; set; }
        public virtual System.Nullable<decimal> DR_CURRENT { get; set; }
        public virtual System.Nullable<decimal> DR_SAVING { get; set; }
        public virtual System.Nullable<decimal> DR_CALL { get; set; }
        public virtual System.Nullable<decimal> DR_FIXED { get; set; }
        public virtual System.Nullable<decimal> DR_DOMESTIC { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual DateTime SETTLEMENTDATE { get; set; }
    }
}
