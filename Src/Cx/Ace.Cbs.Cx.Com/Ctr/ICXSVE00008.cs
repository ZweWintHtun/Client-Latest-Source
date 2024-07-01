using System.Collections.Generic;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Invoking;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Cx.Com.Ctr
{
   public interface ICXSVE00008
    {
       CXDTO00003 CheckRemittanceRegisterNo(string registerNo, CXDMD00006 DrawingEncashTransaction);
    }
}
