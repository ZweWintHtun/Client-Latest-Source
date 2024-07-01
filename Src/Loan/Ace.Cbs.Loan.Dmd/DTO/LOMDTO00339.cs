using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd
{
    //Created by HWKO (20-Dec-2017)
    [Serializable]
    public class LOMDTO00339
    {
        public LOMDTO00339() { }

        public virtual string CustomerName { get; set; }
        public virtual string CustomerNRC { get; set; }
        public virtual string CustomerAddress { get; set; }
        public virtual string CustNameCustNRC { get; set; }
    }
}
