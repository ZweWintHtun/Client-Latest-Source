using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00207 : EntityBase<LOMDTO00207>
    {
        public LOMDTO00207() { }
        public LOMDTO00207(string sourceBranch, string currency, DateTime startDate, DateTime endDate)
        {
            SourceBr = sourceBranch;
            Cur = currency;
            StartDate = startDate;
            EndDate = endDate;
        }

        public LOMDTO00207(string acctNo, string plNo, string name, string address, string ph, DateTime nplDate,DateTime expDate,decimal samt)
        {
            ACNo = acctNo;
            PLNo = plNo;
            Name = name;
            Address = address;
            Phone = ph;
            NPLDate = nplDate;
            ExpireDate = expDate;
            SAmt = samt;
        }
        public virtual string ACNo { get; set; }
        public virtual string PLNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime NPLDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual decimal SAmt { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}
