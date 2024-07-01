using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;// Added by AAM (20_Sep_2018)

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00006:IPresenter
    {
        IMNMVEW00006 YearpostViewData { get; set; }
        void Posting();
        void Clear();
        IList<PFMDTO00079> Get_BLFInfo_ByActiveBudget(string sourceBr);

    }
    public interface IMNMVEW00006
    {
        //PFMDTO00056 ViewData { set; get; }
        IMNMCTL00006 Controller { get; set; }
        void Successful(string message);
        void Failure(string message);
        Nullable<DateTime> Date_time { get; set; }
        string LabelStatus { get; set; }
        int ProgressBar { get; set; }
        bool Progressstatus { get; set; }
      
    }
}
