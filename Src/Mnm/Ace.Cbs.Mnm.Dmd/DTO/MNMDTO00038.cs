using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
    public class MNMDTO00038
    {
        public decimal CR_Cash { get; set; }
        public decimal CR_Transfer { get; set; }
        public decimal CR_Clearing { get; set; }
        public decimal CR_Total { get; set; }
        public decimal DR_Cash { get; set; }
        public decimal DR_Transfer { get; set; }
        public decimal DR_Clearing { get; set; }
        public decimal DR_Total { get; set; }
        public string AccountCode { get; set; }
        public string AccountHead { get; set; }
    }
}
