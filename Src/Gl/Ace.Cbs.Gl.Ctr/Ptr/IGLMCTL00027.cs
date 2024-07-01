using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using System.Data;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00027 : IPresenter
    {
        IGLMVEW00027 View { get; set; }
        //DataSet Print();
        IList<GLMDTO00023> Print1();
        IList<GLMDTO00023> Print2();
    }
    public interface IGLMVEW00027
    {
        IGLMCTL00027 Controller { get; set; }
        DateTime RequiredDate { get; set; }
        string isIncome { get; set; }
        string BranchCode { get; set; }
        bool IsAllBranch { get; set; }
        string SourceBranch { get; set; } 
    }
}
