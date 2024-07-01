using System;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Pfm.Dmd;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00006 : IBaseService
    {
        PFMDTO00028 SelectByCreditAccountNumber(string accountNo, string branchCode);
        PFMDTO00021 SeletByDebitAccountNumber(string accountNo, string branchCode);
        string Withdrawl(PFMDTO00032 freceiptEntity);
        string Transfer(PFMDTO00032 freceiptEntity, PFMDTO00028 saofEntity);
    }
}
