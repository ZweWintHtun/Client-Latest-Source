using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00085 : Supportfields<LOMDTO00085>
    {
        public LOMDTO00085() { }

        public LOMDTO00085(int id)
        {
            this.Id = id;
        }

        public LOMDTO00085(string lno, string acctNo, string acSign, string loanProductcode,
            Nullable<DateTime> closeDate, string budget, Nullable<decimal> principalAmt, Nullable<decimal> totalInt,
            Nullable<decimal> lastInt, Nullable<decimal> accuredInt, Nullable<decimal> m1,
            Nullable<decimal> m2, Nullable<decimal> m3, Nullable<decimal> m4, Nullable<decimal> m5,
            Nullable<decimal> m6, Nullable<decimal> m7, Nullable<decimal> m8, Nullable<decimal> m9,
            Nullable<decimal> m10, Nullable<decimal> m11, Nullable<decimal> m12, string cur, string sourceBr)
        {
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.ACSign = acSign;
            this.LoanProductCode = loanProductcode;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.PrincipalAmount = principalAmt;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.AccuredInt = accuredInt;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.Cur = cur;
            this.SourceBr = sourceBr;
        }

        public LOMDTO00085(string lno,string acctNo,string acSign,string loanProductcode,
            Nullable<DateTime> closeDate, string budget,Nullable<decimal> principalAmt,Nullable<decimal> totalInt,
            Nullable<decimal> lastInt,Nullable<decimal> accuredInt,Nullable<decimal> m1,
            Nullable<decimal> m2,Nullable<decimal> m3,Nullable<decimal> m4,Nullable<decimal> m5,
            Nullable<decimal> m6,Nullable<decimal> m7, Nullable<decimal> m8,Nullable<decimal> m9,
            Nullable<decimal> m10,Nullable<decimal> m11,Nullable<decimal> m12,string cur,string sourceBr,
            Nullable<decimal> samt,Nullable<DateTime> sDate)
        {
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.ACSign = acSign;
            this.LoanProductCode = loanProductcode;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.PrincipalAmount = principalAmt;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.AccuredInt = accuredInt;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.Cur = cur;
            this.SourceBr = sourceBr;
            this.SAmt = samt;
            this.SDate = sDate;
        }

        //Updated by HWKO (16-Mar-2017)
        public LOMDTO00085(int id,string lno, string acctNo, string acSign, string loanProductcode,
            Nullable<DateTime> closeDate, string budget, Nullable<decimal> principalAmt, Nullable<decimal> totalInt,
            Nullable<decimal> lastInt, Nullable<decimal> accuredInt, Nullable<decimal> m1,
            Nullable<decimal> m2, Nullable<decimal> m3, Nullable<decimal> m4, Nullable<decimal> m5,
            Nullable<decimal> m6, Nullable<decimal> m7, Nullable<decimal> m8, Nullable<decimal> m9,
            Nullable<decimal> m10, Nullable<decimal> m11, Nullable<decimal> m12, string cur, string sourceBr,
            DateTime date_time, bool active, byte[] tS, int createdUserId, DateTime createdDate, 
            Nullable<int> updatedUserId, Nullable<DateTime> updatedDate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.ACSign = acSign;
            this.LoanProductCode = loanProductcode;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.PrincipalAmount = principalAmt;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.AccuredInt = accuredInt;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.Cur = cur;
            this.SourceBr = sourceBr;
            this.DATE_TIME = date_time;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string LoanProductCode { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual Nullable<decimal> PrincipalAmount { get; set; }
        public virtual Nullable<decimal> TotalInt { get; set; }
        public virtual Nullable<decimal> LastInt { get; set; }
        public virtual Nullable<decimal> AccuredInt { get; set; }
        public virtual Nullable<decimal> M1 { get; set; }
        public virtual Nullable<decimal> M2 { get; set; }
        public virtual Nullable<decimal> M3 { get; set; }
        public virtual Nullable<decimal> M4 { get; set; }
        public virtual Nullable<decimal> M5 { get; set; }
        public virtual Nullable<decimal> M6 { get; set; }
        public virtual Nullable<decimal> M7 { get; set; }
        public virtual Nullable<decimal> M8 { get; set; }
        public virtual Nullable<decimal> M9 { get; set; }
        public virtual Nullable<decimal> M10 { get; set; }
        public virtual Nullable<decimal> M11 { get; set; }
        public virtual Nullable<decimal> M12 { get; set; }
        public virtual string Cur { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual DateTime DATE_TIME { get; set; }

        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<DateTime> StartPeriod { get; set; }

        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<decimal> InterestAmount { get; set; }

    }
}
