using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dmd
{
    [Serializable()]
    public class CXDMD00013
    {
        public CXDMD00013() { }
        public CXDMD00013(string cur, string desp, string symbol, decimal m1, decimal m2, decimal m3, decimal m4, decimal m5, decimal m6, decimal m7, decimal m8, decimal m9, decimal m10, decimal m11, decimal m12)
        {
            this.Cur = cur;
            this.Description = desp;
            this.Symbol = symbol;
            this.Month1Ammount = m1;
            this.Month2Ammount = m2;
            this.Month3Ammount = m3;
            this.Month4Ammount = m4;
            this.Month5Ammount = m5;
            this.Month6Ammount = m6;
            this.Month7Ammount = m7;
            this.Month8Ammount = m8;
            this.Month9Ammount = m9;
            this.Month10Ammount = m10;
            this.Month11Ammount = m11;
            this.Month12Ammount = m12;
        }

        //public CXDMD00013(string dCode)
        //{
        //    this.DCODE = dCode;
        //} comment by ASDA coz no need to use

        public virtual string Cur { get; set; }
        public virtual string Description { get; set; }
        public virtual string Symbol { get; set; }
        public virtual decimal Month10Ammount { get; set; }
        public virtual decimal Month11Ammount { get; set; }
        public virtual decimal Month12Ammount { get; set; }
        public virtual decimal Month13Ammount { get; set; }
        public virtual decimal Month1Ammount { get; set; }
        public virtual decimal Month2Ammount { get; set; }
        public virtual decimal Month3Ammount { get; set; }
        public virtual decimal Month4Ammount { get; set; }
        public virtual decimal Month5Ammount { get; set; }
        public virtual decimal Month6Ammount { get; set; }
        public virtual decimal Month7Ammount { get; set; }
        public virtual decimal Month8Ammount { get; set; }
        public virtual decimal Month9Ammount { get; set; }
                
        
        public virtual string ACode { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string Active { get; set; }
        

        
    }
}
