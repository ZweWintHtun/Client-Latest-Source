using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00071 : IPresenter
    {
        ILOMVEW00071 SeasonCodeView { set; get; }
        IList<LOMDTO00071> GetAll();
        void Save(LOMDTO00071 entity);
        void Delete(IList<LOMDTO00071> itemList);
        LOMDTO00071 SelectBySeasonCode(string seasonCode);
    }
    public interface ILOMVEW00071
    {
        string Code { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00071 ViewData { get; set; }
        LOMDTO00071 PreviousSeasonCodeDto { get; set; }
        IList<LOMDTO00071> SeasonCodeList { get; set; }
        ILOMCTL00071 Controller { set; get; }
        //void ControlSetting(string name, bool isEnable);
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
