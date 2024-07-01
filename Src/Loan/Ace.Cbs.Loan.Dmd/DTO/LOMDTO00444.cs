using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00444 : Supportfields<LOMDTO00444>
    {
        public LOMDTO00444() { }


        public LOMDTO00444(string acctno, string customername, int totalterm, DateTime onemonthnotice, DateTime expireddate, DateTime extendeddate)
        {
            this.AccountNo = acctno;
            this.CustomerName = customername;
            this.TotalTerm = totalterm;
            this.OneMonthNotice = onemonthnotice;
            this.ExpiredDate = expireddate;
            this.ExtendedDate = extendeddate;
        }

        public virtual string AccountNo { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual int TotalTerm { get; set; }
        public virtual DateTime OneMonthNotice { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual DateTime ExtendedDate { get; set; }

    }
}
