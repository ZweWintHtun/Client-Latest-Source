using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00205 : EntityBase<LOMDTO00205>
    {
        public LOMDTO00205() { }
        public LOMDTO00205(string plNo, string acctNo, string name,string address,string nrc,string companyName, string phone, int term, DateTime regDate, DateTime expDate,decimal intRate,decimal sAmt,decimal interest)
        {
            PLNo = plNo;
            ACNo=acctNo;
            Name=name;
            Address = address;//Added by HWKO (22-Dec-2017)
            NRC = nrc;//Added by HWKO (22-Dec-2017)
            CompanyName=companyName;
            Phone=phone;
            Term=term;
            SDate=regDate;
            ExpireDate=regDate;
            IntRate=intRate;
            SAmt=sAmt;
            Interest = interest;
        }

        public virtual string PLNo { get; set; }
        public virtual string ACNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }//Added by HWKO (22-Dec-2017)
        public virtual string NRC { get; set; }//Added by HWKO (22-Dec-2017)
        public virtual string CompanyName { get; set; }
        public virtual string Phone { get; set; }
        public virtual int Term { get; set; }
        public virtual DateTime SDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual decimal IntRate { get; set; }
        public virtual decimal SAmt { get; set; }
        public virtual decimal Interest { get; set; }
    }
}
