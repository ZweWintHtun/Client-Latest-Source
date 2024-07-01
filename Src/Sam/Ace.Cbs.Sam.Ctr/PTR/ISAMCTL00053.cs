using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00053 : IPresenter
    {
        ISAMVEW00053 NationalityCodeView { set; get; }
        IList<SAMDTO00053> GetAll();
        void Save(SAMDTO00053 entity);
        void Delete(IList<SAMDTO00053> itemList);
        SAMDTO00053 SelectByNationalityCode(string occupationCode);
    }
    public interface ISAMVEW00053
    {
        string NationalityCode { get; set; }
        string Desp { get; set; }
        string Status { get; set; }

        SAMDTO00053 ViewData { get; set; }
        SAMDTO00053 PreviousNationalityDto { get; set; }
        IList<SAMDTO00053> NationalityCodes { get; set; }
        ISAMCTL00053 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}
