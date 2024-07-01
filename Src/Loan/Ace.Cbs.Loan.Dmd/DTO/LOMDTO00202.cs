using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00202 : EntityBase<LOMDTO00202>
    {
        public LOMDTO00202() { }

        public LOMDTO00202(string sourceBranch, string currency)
        {
            SourceBr = sourceBranch;
            this.Currency = currency;
        }

        public LOMDTO00202(string hpno,string acctno,string name,string dealerName,int absentTerm,decimal odamt,string address,string ph)
        {
            HPNo = hpno;
            AcctNo = acctno;
            Name = name;
            Dname = dealerName;
            AbsentTerm = absentTerm;
            TotalODAmt = odamt;
            ADDRESS = address;
            PHONE = ph;
        }

        public virtual string HPNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Dname { get; set; }
        public virtual int AbsentTerm { get; set; }
        public virtual decimal TotalODAmt { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string PHONE { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Currency { get; set; }
        public virtual string LateTerm { get; set; } 

        public virtual decimal Principal_TOD { get; set; }
        public virtual decimal Interest_TOD { get; set; }
    }
}
