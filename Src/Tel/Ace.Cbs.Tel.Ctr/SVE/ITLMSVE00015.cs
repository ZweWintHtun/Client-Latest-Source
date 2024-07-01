using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00015 : IBaseService
    {
       IPFMDAO00054 TLFDao { get; set; }
       //IPFMDAO00054 TLFChargesDao { get; set; }
       ITLMDAO00016 PODao { get; set; }
       //ITLMDAO00009 DepoDenoDao { get; set; }
       ITLMDAO00015 CashDenoDao { get; set; }
       ITLMDAO00005 TranTypeDao { get; set; }
       IList<TLMDTO00043> POIssueList { get; set; }
       ICXSVE00002 CodeGenerator { get; set; }

       IList<PFMDTO00054> SavePOIssueEntry(IList<TLMDTO00042> POIssueList, bool isWithIncome, bool isMultiple, CXDTO00001 denoString);
        
    }
}
