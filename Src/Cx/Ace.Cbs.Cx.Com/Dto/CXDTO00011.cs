using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Cx.Com.Dto
{
    [Serializable]
    public class CXDTO00011
    {
        public CXDTO00011(PFMDTO00001 customerdot, IList<TCMDTO00045> saofcaoffaofInformation, IList<TCMDTO00045> accountCount, IList<TLMDTO00018> loanGuarantee)
        {
            this.CustomerDto = customerdot;
            this.SaofCaofFaofInformation = saofcaoffaofInformation;
            this.AccountCount = accountCount;
            this.LoanGuarantee = loanGuarantee;
        }
        public virtual PFMDTO00001 CustomerDto { get; set; }
        public virtual IList<TCMDTO00045> SaofCaofFaofInformation { get; set; }
        public virtual IList<TCMDTO00045> AccountCount { get; set; }
        public virtual IList<TLMDTO00018> LoanGuarantee { get; set; }
    }
}
