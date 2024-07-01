using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Gl.Dmd
{
    [Serializable]
    public class GLMDTO00013
    {
        public GLMDTO00013() { }

        public GLMDTO00013(string year, string month)
        {
            this.Year = year;
            this.Month = month;
        }

        public GLMDTO00013(string aCode, string acName, string acType)
        {
            this.ACODE = aCode;
            this.ACNAME = acName;
            this.ACTYPE = acType;
        }

        public GLMDTO00013(string aCode, string acName, string acType, decimal amount, decimal cAmount)
        {
            this.ACODE = aCode;
            this.ACNAME = acName;
            this.ACTYPE = acType;
            this.AMOUNT = amount;
            this.CAMOUNT = cAmount;
        }

        public virtual string ACODE { get; set; }
        public virtual string DCODE { get; set; }
        public virtual string ACNAME { get; set; }
        public virtual string ACTYPE { get; set; }
        public virtual string CBMACODE { get; set; }
        public virtual DateTime PDATE { get; set; }
        public virtual decimal AMOUNT { get; set; }
        public virtual string Year { get; set; }
        public virtual string Month { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual decimal CAMOUNT { get; set; }
        
    }
}
