using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00005 : IPresenter
    {
        ILOMVEW00005 LandView { set; get; }
        IList<LOMDTO00001> SelectAll();
        void Save(LOMDTO00001 entity);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByLandCode(string code);
    }

    public interface ILOMVEW00005
    {
        string lCode { get; set; }
        string lDesp { get; set; }
        string Status { get; set; }

        LOMDTO00001 ViewData { get; set; }
        LOMDTO00001 PreviousLandDto { get; set; }
        IList<LOMDTO00001> Lands { get; set; }
        ILOMCTL00005 Controller { set; get; }

        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}
