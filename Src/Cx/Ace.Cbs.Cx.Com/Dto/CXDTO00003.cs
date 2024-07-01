using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
     [Serializable]
    public class CXDTO00003
    {
        public CXDTO00003() { }

        public CXDTO00003(string receiverName, decimal amount, string currency, bool remittanceRegisterCheck)
        {
            this.ReceiverName = receiverName;
            this.Amount = amount;
            this.Currency = currency;
            this.RemittanceRegisterNoCheck = remittanceRegisterCheck;
        }

        public string ReceiverName { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public bool RemittanceRegisterNoCheck { get; set; }
    }
}
