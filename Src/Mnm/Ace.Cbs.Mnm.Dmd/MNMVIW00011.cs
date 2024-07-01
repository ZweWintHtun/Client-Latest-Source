using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd 
{
    public class MNMVIW00011 : EntityBase<MNMVIW00011>
    {
        public MNMVIW00011() { }

        // public virtual int Id { get; set; }
        public virtual string ACODE { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual DateTime SETTLEMENTDATE { get; set; }
        public virtual string ACTYPE { get; set; }
        public virtual string DESP { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual decimal CREDIT { get; set; }
        public virtual decimal DEBIT { get; set; }
        public virtual decimal OCREDIT { get; set; }
        public virtual decimal ODEBIT { get; set; }
        public virtual decimal HOMECREDIT { get; set; }
        public virtual decimal HOMEDEBIT { get; set; }
        public virtual decimal HOMEOCREDIT { get; set; }
        public virtual decimal HOMEODEBIT { get; set; }
        public virtual int CASH { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string status { get; set; }
       
    }
}
