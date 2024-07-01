using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00035 : Supportfields<LOMDTO00035>
    {
        public LOMDTO00035() { }

        public LOMDTO00035(DateTime startDate, DateTime endDate, string sourceBranch, string currency)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SourceBr = sourceBranch;
            this.Cur = currency;
        }
        
        public LOMDTO00035(int id,string lno,string acctNo, string name, DateTime expireDate, decimal sAmt, decimal cBal)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.Name = name;
            this.ExpireDate = expireDate;
            this.SAmt = sAmt;
            this.CBal = cBal;
        }

        public LOMDTO00035(int id, string lno, string acctNo, DateTime sDate, DateTime closeDate, decimal sAmt)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SDate = sDate;
            this.CloseDate = closeDate;
            this.SAmt = sAmt;
        }

        public LOMDTO00035(int id, string lno, string acctNo, decimal sAmt, string cur, 
            decimal firstSAmt, DateTime expireDate, bool legalCase, bool nplCase, 
            string name, string aType, decimal force_sale_value)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = sAmt;
            this.Cur = cur;
            this.FirstSAmt = firstSAmt;
            this.ExpireDate = expireDate;
            this.LegalCase = legalCase;
            this.NplCase = nplCase;
            this.Name = name;
            this.AType = aType;
            this.Force_Sale_Value = force_sale_value;
        }

        public LOMDTO00035(int id, string lno, string acctNo, string aType, decimal sAmt, DateTime sDate, DateTime expireDate)
        {
            this.Id = id;
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.SAmt = sAmt;
            this.SDate = sDate;
            this.ExpireDate = expireDate;
            this.AType = aType;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual string Cur { get; set; }
        public virtual DateTime SDate { get; set; }
        public virtual decimal FirstSAmt { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual bool NplCase { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual string AType { get; set; }
        public virtual string Loans_Type { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual decimal Force_Sale_Value { get; set; }
        //public virtual bool Active { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        public virtual DateTime CloseDate { get; set; }
        public virtual string QuaterNo { get; set; }

        public virtual string RequiredYear { get; set; }
        public virtual string RequiredMonth { get; set; }
    }
}
