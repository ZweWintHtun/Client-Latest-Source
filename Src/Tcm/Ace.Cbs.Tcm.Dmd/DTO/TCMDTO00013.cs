using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
     [Serializable]
    public class TCMDTO00013 : EntityBase<TCMDTO00013>
    {
        public TCMDTO00013() { }

        public TCMDTO00013(string workstation)
        {
            this.WORKSTATION = workstation;
        }

        public TCMDTO00013(string acctNo, decimal cbal, decimal overdrawn_amount, decimal ovdlimit, string name, string workstation, string sourcecur, string acsign)
        {
            this.ACCTNO = acctNo;
            this.CBAL = cbal;
            this.OVERDRAWN_AMOUNT = overdrawn_amount;
            this.OVDLIMIT = ovdlimit;
            this.NAME = name;
            this.WORKSTATION = workstation;
            this.SOURCECUR = sourcecur;
            this.ACSign = acsign;
        }


        public virtual string ACCTNO { get; set; }
        public virtual decimal CBAL { get; set; }
        public virtual decimal OVERDRAWN_AMOUNT { get; set; }
        public virtual decimal OVDLIMIT { get; set; }
        public virtual string NAME { get; set; }
        public virtual string WORKSTATION { get; set; }
        public virtual string currency { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string ACSign { get; set; }
        public virtual string AcctNo { get; set; }//HMW
        public virtual decimal OVDLimit { get; set; }//HMW
    }
}
