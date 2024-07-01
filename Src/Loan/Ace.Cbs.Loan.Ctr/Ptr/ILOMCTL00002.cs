using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr 
{
    public interface ILOMCTL00002 : IPresenter
    {
        ILOMVEW00002 TypeOfAdvanceView { set; get; }
        IList<LOMDTO00002> GetAll();
        void Save(LOMDTO00002 entity);
        void Delete(IList<LOMDTO00002> itemList);
        LOMDTO00002 SelectByAdvanceCode(string advanceCode);
    }
    public interface ILOMVEW00002
    {
        string Code { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00002 ViewData { get; set; }
        LOMDTO00002 PreviousAdvanceDto { get; set; }
        IList<LOMDTO00002> TypesOfAdvanceList { get; set; }
        ILOMCTL00002 Controller { set; get; }
        //void ControlSetting(string name, bool isEnable);
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
