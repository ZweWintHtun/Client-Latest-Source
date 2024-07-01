using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00227 : EntityBase<LOMDTO00227>
    {
        public LOMDTO00227() { }

        public LOMDTO00227(string lno, string acctNo, string name, int absentTerm, decimal odAmount, string address, string ph)
        {
            Lno = acctNo;
            AcctNo = lno;
            NAME = name;
            AbsentTerm = absentTerm;
            TotalODAmt = odAmount;
            ADDRESS = address;
            PHONE = ph;
        }

        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string NAME { get; set; }
        public virtual int AbsentTerm { get; set; }
        public virtual decimal TotalODAmt { get; set; }
        public virtual string ADDRESS { get; set; }
        public virtual string PHONE { get; set; }
    }
}
