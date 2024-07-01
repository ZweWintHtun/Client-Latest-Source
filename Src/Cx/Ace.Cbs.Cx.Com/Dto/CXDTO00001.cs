using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
    [Serializable]
    public class CXDTO00001
    {
        public CXDTO00001() { }

        public CXDTO00001(string denoString, string denoRateString, string refundString, string refundRateString)
        {
            this.DenoString = denoString;
            this.DenoRateString = DenoRateString;
            this.RefundString = refundString;
            this.RefundRateString = refundRateString;
        }
        public virtual string CounterNo { get; set; }
        public virtual string DenoString { get; set; }
        public virtual string DenoRateString { get; set; }
        public virtual string RefundString { get; set; }
        public virtual string RefundRateString { get; set; }
        public virtual decimal Surplus { get; set; }
        public virtual decimal Shortage { get; set; }
        public virtual decimal AdjustAmount { get; set; }
        public virtual decimal TotalAmount { get; set; }
    }
}
