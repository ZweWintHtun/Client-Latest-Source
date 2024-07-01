using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00001
    {
        IGLMVEW00001 View { get; set; }
        IList<CXDMD00013> GetAllCurrency();
        void UpdateCurrencyRateByCur(IList<CXDMD00013> currencyList);
        void DeleteCurrencyRateByCur(IList<CXDMD00013> currencyList);
        void DeleteAllCurrencyRate();
    }
    public interface IGLMVEW00001
    {
        IGLMCTL00001 Controller { get; set; }
        void GridDataBind(IList<CXDMD00013> currencyList);
        void tsbCRUD_InitialState();
        void GridViewColumnReadOnly(bool status);
        IList<CXDMD00013> CurrencyList { get; set; }
        IList<CXDMD00013> DeleteList { get; set; }
    }
}
