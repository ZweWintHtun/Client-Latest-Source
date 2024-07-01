using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00045
    {
        CXDTO00011 SelectCustomerAccountInformation(string custid);
    }
}
