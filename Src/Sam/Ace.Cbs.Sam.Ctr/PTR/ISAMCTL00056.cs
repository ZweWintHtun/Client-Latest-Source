using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00056 : IPresenter
    {
        ISAMVEW00056 NRCCodeView { set; get; }
        IList<SAMDTO00054> GetAll();
        void Save(SAMDTO00054 entity);
        void Delete(IList<SAMDTO00054> itemList);
        IList<SAMDTO00054> SelectByStateCode(string StateCode);
    }
    public interface ISAMVEW00056
    {
        string StateCode { get; set; }
        string TownshipCode { get; set; }
        string TownshipDesp { get; set; }
        string Status { get; set; }

        SAMDTO00054 ViewData { get; set; }
        SAMDTO00054 PreviousNRCCodeDto { get; set; }
        IList<SAMDTO00054> NRCCodeList { get; set; }
        ISAMCTL00056 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}
