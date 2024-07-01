using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
     [Serializable]
    public class CXDTO00005
    {
        public CXDTO00005() { }

        public CXDTO00005(decimal communicationCharges, decimal remittanceAmount, decimal commission)
        {
            this.CommunicationCharges = communicationCharges;
            this.RemittanceAmount = remittanceAmount;
            this.Commission = commission;
        }

        public virtual decimal CommunicationCharges { get; set; }
        public virtual decimal RemittanceAmount { get; set; }
        public virtual decimal Commission { get; set; }
    }
}
