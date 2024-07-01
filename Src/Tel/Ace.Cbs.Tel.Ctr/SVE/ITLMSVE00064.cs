using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00064 :IBaseService
    {
       IList<PFMDTO00042> SelectDepositListingByAccountNo(string accountNo, DateTime startDate, DateTime endDate, string workstation,int createdUserId,string sourceBr);
    }
}
