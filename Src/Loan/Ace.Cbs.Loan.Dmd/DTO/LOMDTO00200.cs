using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00200 : EntityBase<LOMDTO00200>
    {
        public LOMDTO00200() { }
        public LOMDTO00200(string hpcustAcctNo, string hpdoAcctno,string retmsg)
        {
            hpCustAcctNo = hpcustAcctNo;
            hpDOAcctno = hpdoAcctno;
            retMsg = retmsg;
        }
        public string hpCustAcctNo { get; set; }
        public string hpDOAcctno { get; set; }
        public string retMsg { get; set; }
    }
}
