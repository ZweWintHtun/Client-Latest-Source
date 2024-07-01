using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00005 : IPresenter
    {
        IMNMVEW00005 ViewData { get; set; }
        void DailyPosting();
    }
    public interface IMNMVEW00005
    {
        IMNMCTL00005 Controller { get; set; }
        void Successful(string message);
        void Failure(string message);
        Nullable<DateTime> Date_time { get; set; }
        DateTime StartDate { get; }
        int ProgressBar { get; set; }
        bool Progressstatus { get; set; }
    }
}
