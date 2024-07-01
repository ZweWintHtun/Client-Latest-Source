using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00074 : IPresenter
    {
        ILOMVEW00074 ProductCodeView { set; get; }
        IList<LOMDTO00074> GetAll();
        void Save(LOMDTO00074 entity);
        void Delete(IList<LOMDTO00074> itemList);
        LOMDTO00074 SelectByProductCode(string productCode);
    }
    public interface ILOMVEW00074
    {
        string Code { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00074 ViewData { get; set; }
        LOMDTO00074 PreviousProductCodeDto { get; set; }
        IList<LOMDTO00074> ProductCodeList { get; set; }
        ILOMCTL00074 Controller { set; get; }
        //void ControlSetting(string name, bool isEnable);
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
