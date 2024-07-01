using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00326 : EntityBase<LOMDTO00326>
    {
        public LOMDTO00326() { }
        public LOMDTO00326(string plcustAcctNo, string pldoAcctno, string retmsg)
        {
            plCustAcctNo = plcustAcctNo;
            plDOAcctno = pldoAcctno;
            retMsg = retmsg;
        }
        public string plCustAcctNo { get; set; }
        public string plDOAcctno { get; set; }
        public string retMsg { get; set; }
    }
}
