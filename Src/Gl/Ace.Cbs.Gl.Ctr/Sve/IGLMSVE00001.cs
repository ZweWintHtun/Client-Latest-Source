using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00001:IBaseService
    {
        IList<CXDMD00013> SelectAllCurrency();
        IList<CXDMD00013> UpdateCurrencyRate(IList<CXDMD00013> currencyList, int updatedUserId);
        IList<CXDMD00013> DeleteCurrencyRateByCur(IList<CXDMD00013> currencyList, int updatedUserId);
        IList<CXDMD00013> DeleteAllCurrencyRate(int updatedUserId);
    }
}
