using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00033 : EntityBase<MNMDTO00033>
    {
        
        public MNMDTO00033()
        {
        }
        public MNMDTO00033(string ENO,string CRPARTICULAR, decimal CR_CURRENT, decimal CR_SAVING, decimal CR_CALL, decimal CR_FIXED, decimal CR_DOMESTIC, string DRPARTICULAR, decimal DR_CURRENT, decimal DR_SAVING, decimal DR_CALL, decimal DR_FIXED, decimal DR_DOMESTIC)
        {
            this.ENO = ENO;
            this.CRPARTICULAR = CRPARTICULAR;
            this.CR_CURRENT = CR_CURRENT;
            this.CR_SAVING = CR_SAVING;
            this.CR_CALL = CR_CALL;
            this.CR_FIXED = CR_FIXED;
            this.CR_DOMESTIC = CR_DOMESTIC;
            this.DRPARTICULAR = DRPARTICULAR;
            this.DR_CURRENT = DR_CURRENT;
            this.DR_SAVING = DR_SAVING;
            this.DR_FIXED = DR_FIXED;
            this.DR_CALL = DR_CALL;
            this.DR_DOMESTIC = DR_DOMESTIC;


        }

        
         //For Transfer Scroll Listing 
        // (t.ENO,t.ACSIGN,t.STATUS,t.DATE_TIME,t.CRPARTICULAR,t.CR_CURRENT,t.CR_SAVING,t.CR_CALL,t.CR_FIXED,
         //t.CR_DOMESTIC,t.DRPARTICULAR,t.DR_CURRENT,t.DR_SAVING,t.DR_CALL,t.DR_FIXED,t.DR_DOMESTIC,t.WORKSTATION,t.SOURCECUR,
         //t.SOURCEBR,t.SETTLEMENTDATE)
        public MNMDTO00033(string ENO,string ACSIGN, string STATUS, DateTime DATE_TIME, string CRPARTICULAR,
            System.Nullable<decimal>CR_CURRENT, System.Nullable<decimal> CR_SAVING, System.Nullable<decimal> CR_CALL,
            System.Nullable<decimal>CR_FIXED,System.Nullable<decimal>CR_DOMESTIC, string DRPARTICULAR,System.Nullable<decimal>DR_CURRENT,
            System.Nullable<decimal>DR_SAVING, System.Nullable<decimal> DR_CALL,System.Nullable<decimal>DR_FIXED,
            System.Nullable<decimal> DR_DOMESTIC, string workstation,string sourcecur,string sourcebr,DateTime settlementdate)
        {
            this.ENO = ENO;
            this.ACSIGN = ACSIGN;
            this.STATUS = STATUS;
            this.DATE_TIME = DATE_TIME;
            this.CRPARTICULAR = CRPARTICULAR;
            this.CR_CURRENT = Convert.ToDecimal(CR_CURRENT);
            this.CR_SAVING = Convert.ToDecimal(CR_SAVING);
            this.CR_CALL = Convert.ToDecimal(CR_CALL);
            this.CR_FIXED = Convert.ToDecimal(CR_FIXED);
            this.CR_DOMESTIC = Convert.ToDecimal(CR_DOMESTIC);
            this.DRPARTICULAR = DRPARTICULAR;
            this.DR_CURRENT = Convert.ToDecimal(DR_CURRENT);
            this.DR_SAVING = Convert.ToDecimal(DR_SAVING);
            this.DR_FIXED = Convert.ToDecimal(DR_FIXED);
            this.DR_CALL = Convert.ToDecimal(DR_CALL);
            this.DR_DOMESTIC = Convert.ToDecimal(DR_DOMESTIC);
            this.SOURCEBR = sourcebr;
            this.SOURCECUR = sourcecur;
            this.WORKSTATION = workstation;
            this.SETTLEMENTDATE = settlementdate;

        }
        public MNMDTO00033(string ENO, string ACSIGN, string STATUS, DateTime DATE_TIME, string CRPARTICULAR,
          System.Nullable<decimal> CR_CURRENT, System.Nullable<decimal> CR_SAVING, System.Nullable<decimal> CR_CALL,
          System.Nullable<decimal> CR_FIXED, System.Nullable<decimal> CR_DOMESTIC, string DRPARTICULAR, System.Nullable<decimal>DR_CURRENT,
          System.Nullable<decimal> DR_SAVING, System.Nullable<decimal> DR_CALL, System.Nullable<decimal>DR_FIXED,
          System.Nullable<decimal> DR_DOMESTIC)
        {
            this.ENO = ENO;
            this.ACSIGN = ACSIGN;
            this.STATUS = STATUS;
            this.DATE_TIME = DATE_TIME;
            this.CRPARTICULAR = CRPARTICULAR;
            this.CR_CURRENT = Convert.ToDecimal(CR_CURRENT);
            this.CR_SAVING = Convert.ToDecimal(CR_SAVING);
            this.CR_CALL = Convert.ToDecimal(CR_CALL);
            this.CR_FIXED = Convert.ToDecimal(CR_FIXED);
            this.CR_DOMESTIC = Convert.ToDecimal(CR_DOMESTIC);
            this.DRPARTICULAR = DRPARTICULAR;
            this.DR_CURRENT = Convert.ToDecimal(DR_CURRENT);
            this.DR_SAVING = Convert.ToDecimal(DR_SAVING);
            this.DR_FIXED = Convert.ToDecimal(DR_FIXED);
            this.DR_CALL = Convert.ToDecimal(DR_CALL);
            this.DR_DOMESTIC = Convert.ToDecimal(DR_DOMESTIC);
        }

         public virtual string ENO { get; set; }
        public virtual string ACSIGN { get; set; }
        public virtual string STATUS { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual string CRPARTICULAR { get; set; }
        public virtual decimal CR_CURRENT { get; set; }
        public virtual decimal CR_SAVING { get; set; }
        public virtual decimal CR_CALL { get; set; }
        public virtual decimal CR_FIXED { get; set; }
        public virtual decimal CR_DOMESTIC { get; set; }
        public virtual string DRPARTICULAR { get; set; }
        public virtual decimal DR_CURRENT { get; set; }
        public virtual decimal DR_SAVING { get; set; }
        public virtual decimal DR_CALL { get; set; }
        public virtual decimal DR_FIXED { get; set; }
        public virtual decimal DR_DOMESTIC { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual DateTime SETTLEMENTDATE { get; set; }
        public virtual string StatusReversal { get; set; }

    }
}
