using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
     [Serializable]
    public class PFMORM00011 : Supportfields<PFMORM00011>
    {
        //Stop Cheque 

        public PFMORM00011() 
        { }

        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string ChequeBookNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual PFMORM00028 CLedger { get; set; } // For Account No 
        public virtual PFMORM00006 Cheque { get; set; } // For CheckBook
        public virtual Branch Branch { get; set; } // For SourceBranchCode
        public virtual  string StartNo { get; set; }
        public virtual string EndNo { get; set; }
        public virtual string Remark { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string USERNO { get; set; }

    }
}