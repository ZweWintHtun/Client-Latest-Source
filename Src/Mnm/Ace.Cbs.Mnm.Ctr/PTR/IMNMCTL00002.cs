using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00002 : IPresenter
    {
        IMNMVEW00002 MonthAfterViewData { get; set; }
        void CheckClosing();
        void MonthAfter();
        DateTime GetSystemDate(string sourceBr);
    }
    public interface IMNMVEW00002
    {
        
        IMNMCTL00002 Controller { get; set; }
        bool butProcess_Enable { get; set; }
        void Successful(string message);
        void Failure(string message);
        DateTime Date_time { get; set; }
        int ProgressBar { get; set; }
        bool Progressstatus { get; set; }
        ProgressBarStyle ProgressBarStyle { set; }
    }
}
