using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00075 : IPresenter
    {
        ILOMVEW00075 AGLoanProductTypeItemSetupView { set; get; }
        IList<LOMDTO00075> GetAll();
        void Save(LOMDTO00075 entity);
        void Delete(IList<LOMDTO00075> itemList);
        LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode);
    }
    public interface ILOMVEW00075
    {
        //int Id { get; set; }
        string ProductCode { get; set; }
        string SeasonCode { get; set; }
        string UMCode { get; set; }
        string SDay { get; set; }
        string SMonth { get; set; }
        string EDay { get; set; }
        string EMonth { get; set; }
        string DeadLineDay { get; set; }
        string DeadLineMonth { get; set; }
        //string USERNO { get; set; }
        //DateTime DATE_TIME { get; set; }

        string Status { get; set; }

        LOMDTO00075 ViewData { get; set; }
        LOMDTO00075 PreviousAGLoanProductTypeItemSetupDto { get; set; }
        IList<LOMDTO00075> AGLoanProductTypeItemSetupList { get; set; }
        ILOMCTL00075 Controller { set; get; }
        //void ControlSetting(string name, bool isEnable);
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
