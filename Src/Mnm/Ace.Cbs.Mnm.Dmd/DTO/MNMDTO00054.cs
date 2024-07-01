using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
      [Serializable]
    public class MNMDTO00054
    {
        public MNMDTO00054() { }

        public MNMDTO00054(string actype,decimal homecredit,decimal homedebit)
        {
            this.ACTYPE = actype;
            this.CREDIT = homecredit;
            this.DEBIT = homedebit;
        }
      
        public MNMDTO00054(string acode, decimal hcredit,decimal hdebit,decimal hocredit,decimal hodebit)
        {
            this.ACODE = acode;
            this.CREDIT = hcredit;
            this.DEBIT = hdebit;
            this.OCREDIT = HOMEOCREDIT;
            this.ODEBIT = HOMEODEBIT;
        }
       
        public MNMDTO00054(string acode, DateTime datetime, DateTime sdate, string actype, string desp, decimal hcredit, decimal hdebit, decimal hocredit, decimal hodebit,string narration)
        {
            this.ACODE = acode;
            this.DATE_TIME = datetime;
            this.SETTLEMENTDATE = sdate;
            this.ACTYPE = actype;
            this.DESP = desp;
            this.HOMECREDIT = hcredit;
            this.HOMEDEBIT = hdebit;
            this.HOMEOCREDIT = hocredit;
            this.HOMEODEBIT = hodebit;
            this.NARRATION = narration;
        }
        

        //public MNMDTO00054(string acode, DateTime datetime, string aType, string desp, decimal credit, decimal debit)
        //{
        //    this.ACODE = acode;
        //    this.DATE_TIME = datetime;
        //    this.ACTYPE = aType;
        //    this.DESP = desp;
        //    this.CREDIT = credit;
        //    this.DEBIT = debit;
        //}

        //public MNMDTO00054(string acode, DateTime datetime, string desp, string aType, decimal homeCredit, decimal homeDebit, decimal oDebit)
        //{
        //    this.ACODE = acode;
        //    this.DATE_TIME = datetime;
        //    this.DESP = desp;
        //    this.ACTYPE = aType;            
        //    this.HOMECREDIT = homeCredit;
        //    this.HOMEDEBIT = homeDebit;
        //    this.ODEBIT = oDebit;            
        //}

        //public MNMDTO00054(string acode, decimal hcredit, decimal hdebit, decimal hocredit, decimal hodebit)
        //{
        //    this.ACODE = acode;
        //    this.CREDIT = hcredit;
        //    this.DEBIT = hdebit;
        //    this.OCREDIT = HOMEOCREDIT;
        //    this.ODEBIT = HOMEODEBIT;
        //}

        //public MNMDTO00054(string acode, DateTime datetime, DateTime sdate, string actype, string desp, decimal credit, decimal debit, decimal ocredit, decimal odebit)
        //{
        //    this.ACODE = acode;
        //    this.DATE_TIME = datetime;
        //    this.SETTLEMENTDATE = sdate;
        //    this.ACTYPE = actype;
        //    this.DESP = desp;
        //    this.CREDIT = credit;
        //    this.DEBIT = debit;
        //    this.OCREDIT = ocredit;
        //    this.ODEBIT = odebit;
        //}
        //public MNMDTO00054(string date1, string date2, string workstation ,string sourcebr)
        //{
        //    this.StartDate = date1;
        //    this.EndDate = date2;           
        //    this.SOURCEBR = sourcebr;
        //    this.WORKSTATION = workstation;
        //}

        //public MNMDTO00054(string date1, string date2, string date3, string cur, string workstation, string sourcebr)
        //{
        //    this.StartDate = date1;
        //    this.EndDate = date2;
        //    this.Date = date3;
        //    this.SOURCECUR = cur;
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}

        //public MNMDTO00054(string acode, string date1, string date2, string date3, string cur, string workstation, string sourcebr)
        //{
        //    this.ACODE = acode;
        //    this.StartDate = date1;
        //    this.EndDate = date2;
        //    this.Date = date3;
        //    this.SOURCECUR = cur;
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}
        //public MNMDTO00054(DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        //{
        //    this.StartDate = startDate.ToString("dd/MM/YYYY");
        //    this.EndDate = endDate.ToString("dd/MM/YYYY");
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}

        //public MNMDTO00054(DateTime startDate, DateTime endDate, string cur, string workstation, string sourcebr)
        //{
        //    this.StartDate = startDate.ToString("dd/MM/YYYY");
        //    this.EndDate = endDate.ToString("dd/MM/YYYY");
        //    this.SOURCECUR = cur;
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}
        //public MNMDTO00054(string aCode, DateTime startDate, DateTime endDate, string workstation, string sourcebr)
        //{
        //    this.ACODE = aCode;
        //    this.StartDate = startDate.ToString("dd/MM/YYYY");
        //    this.EndDate = endDate.ToString("dd/MM/YYYY");
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}

        //public MNMDTO00054(string aCode, DateTime startDate, DateTime endDate, string cur, string workstation, string sourcebr)
        //{
        //    this.ACODE = aCode;
        //    this.StartDate = startDate.ToString("dd/MM/YYYY");
        //    this.EndDate = endDate.ToString("dd/MM/YYYY");
        //    this.SOURCECUR = cur;
        //    this.WORKSTATION = workstation;
        //    this.SOURCEBR = sourcebr;
        //}

        // Added Constructor By AAM (28-Feb-2018)            
        public MNMDTO00054(int id,string aCODE,DateTime date_time,DateTime settlementDate,string acType,string desp
                            ,string sourceCur,string workstation,string sourceBr,bool active,decimal credit,decimal debit
                            ,decimal oCredit,decimal oDebit,decimal homeCredit,decimal homeDebit,decimal homeOCredit,decimal homeODebit)

        {
            Id = id;
            ACODE = aCODE;
            DATE_TIME = date_time;
            SETTLEMENTDATE = settlementDate;
            ACTYPE = acType;
            DESP = desp;
            SOURCECUR = sourceCur;
            WORKSTATION = workstation;
            SOURCEBR = sourceBr;
            Active = active;
            CREDIT = credit;
            DEBIT = debit;
            OCREDIT = OCREDIT;
            ODEBIT = oDebit;
            HOMECREDIT = homeCredit;
            HOMEDEBIT = homeDebit;
            HOMEOCREDIT = homeOCredit;
            HOMEODEBIT = homeODebit;
        }

        public virtual string ACNAME { get; set; }
        public virtual string ACODE { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual DateTime SETTLEMENTDATE { get; set; }
        public virtual string ACTYPE { get; set; }
        public virtual string DESP { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual decimal CREDIT { get; set; }
        public virtual decimal DEBIT { get; set; }
        public virtual decimal OCREDIT { get; set; }
        public virtual decimal ODEBIT { get; set; }
        public virtual decimal HOMECREDIT { get; set; }
        public virtual decimal HOMEDEBIT { get; set; }
        public virtual decimal HOMEOCREDIT { get; set; }
        public virtual decimal HOMEODEBIT { get; set; }
        public virtual int CASH { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual int SrNo { get; set; }       
        public virtual decimal Balance {get; set;}
        public virtual string StartDate { get; set; }
        public virtual string EndDate { get; set; }
        public virtual string Date { get; set; }
        public virtual decimal closingBalance { get; set; }

        public virtual string NARRATION { get; set; }
        
        // Added By AAM (28-Feb-2018)
        public Int64 Id { get; set; } 
        public bool Active { get; set; } 
    }
}
