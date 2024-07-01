using System.Collections.Generic;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00008:IDataRepository<TLMORM00001>
    {
        TLMDTO00001 GetREByRegisterNo(string registerNo);
        TLMDTO00017 GetRDByRegisterNo(string registerNo);
     //   IList<string> SelectToAcctNoByPONO(List<string> polist);




        
    }
}
