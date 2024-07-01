using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00023 :IPresenter
    {
        IGLMVEW00023 ViewData { get; set; }
        void MonthlyPosting();
        void Save(object sender, EventArgs args);
        void Update(object sender, EventArgs args, List<GLMDTO00023> TitleOrderList, List<GLMDTO00023> SubTitleOrderList);
        void Delete(object sender, EventArgs args);
        GLMDTO00023 SelectAllByAccountCode(string ACode);
        GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode);//Added by HMW (13-12-2022)
        IList<GLMDTO00023> SelectAllAccountType();
        IList<GLMDTO00023> SelectAllBranchCode();
        IList<GLMDTO00023> SelectAllTITLE();
        IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type);
        IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE);
        IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode);
       
    }

    public interface IGLMVEW00023
    {
        IGLMCTL00023 Controller { get; set; }
        GLMDTO00023 ViewData { get; set; }
        void Successful(string message);
        void Failure(string message);
        //Nullable<DateTime> Date_time { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int ProgressBar { get; set; }
        bool Progressstatus { get; set; }
        string BranchCode { get; set; }
        bool IsAllBranch { get; set; }
    }
}
