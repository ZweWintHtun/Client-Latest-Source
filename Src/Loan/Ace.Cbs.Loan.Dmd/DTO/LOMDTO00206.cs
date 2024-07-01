using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00206 : EntityBase<LOMDTO00206>
    {
        public LOMDTO00206() { }
        public LOMDTO00206(string sourceBranch, string currency, string month, string year)
        {
            SourceBr = sourceBranch;
            Cur = currency;
            Month = month;
            Year = year;
        }

        public LOMDTO00206(string acctNo,string lno,string name,string ph,string address,decimal interest) 
        {
            AcctNo = acctNo;
            Lno = lno;
            Name = name;
            Phone = ph;
            Address = address;
            Interest = interest;
        }
        public virtual string AcctNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual decimal Interest { get; set; }

        public virtual string Year { get; set; }
        public virtual string Month { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
