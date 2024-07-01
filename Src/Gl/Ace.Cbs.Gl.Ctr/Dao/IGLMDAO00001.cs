using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Dao
{
    public interface IGLMDAO00001 : IDataRepository<Currency>
    {
        IList<CXDMD00013> SelectAllCurrency();
        bool UpdateCurrencyRateByCur(CXDMD00013 currency, int updatedUserId);
        bool DeleteCurrencyRateByCur(CXDMD00013 currency, int updatedUserId);
        bool DeleteAllCurrencyRate(int updatedUserId);
    }
}
