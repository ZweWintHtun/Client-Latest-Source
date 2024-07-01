using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using System.Collections.Generic;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00035 : IBaseService
    {
        IList<MNMDTO00033> GetReturnTransferData(PFMDTO00042 TransferScrollDTO);
        PFMDTO00042 GetTotalBalCashClear(PFMDTO00042 TransferScrollDTO);
    }
}
