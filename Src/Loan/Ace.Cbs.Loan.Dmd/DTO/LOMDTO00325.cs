using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    //Added by HWKO (28-Jul-2017)
    [Serializable]
    public class LOMDTO00325 : Supportfields<LOMDTO00325>
    {
        public LOMDTO00325() { }

        //public string Eno { get; set; }
        public string LoanNo { get; set; }
        public string Currency { get; set; }
        public decimal SAmt { get; set; }
        public string AcctNo { get; set; }
        public string Desp { get; set; }
        public decimal DCAmt { get; set; }
        public string DCDesp { get; set; }

    }
}
