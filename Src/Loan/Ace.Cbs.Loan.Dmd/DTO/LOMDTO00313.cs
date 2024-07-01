using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00313 : Supportfields<LOMDTO00313>
    {
        public LOMDTO00313() { }

        public LOMDTO00313(string plno, string companyName, string name, string nrc, string phone, Nullable<DateTime> closeDate,
            string uid, string sourceBr, string cur)
        {
            this.PLNo = plno;
            this.COMPANYNAME = companyName;
            this.NAME = name;
            this.NRC = nrc;
            this.PHONE = phone;
            this.CLOSEDATE = closeDate;
            this.UId = uid;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        public virtual string PLNo { get; set; }
        public virtual string COMPANYNAME { get; set; }
        public virtual string NAME { get; set; }
        public virtual string NRC { get; set; }
        public virtual string PHONE { get; set; }
        public virtual Nullable<DateTime> CLOSEDATE { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
