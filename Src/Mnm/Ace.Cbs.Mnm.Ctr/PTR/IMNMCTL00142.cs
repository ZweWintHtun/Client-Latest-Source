using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface  IMNMCTL00142 : IPresenter
    {
        IMNMVEW00142 ViewData { get; set; }
        void ProcessInterest(string formName);
        void Show_Message(string msgCode);
  
    }

     public interface IMNMVEW00142
    {
        IMNMCTL00142 Controller { get; set; }
        Nullable<DateTime> date { get; }
        int Progress { get; set; }
        Timer TimerProgress { get; }
        bool IsSuccessful { get; set; }
        ProgressBarStyle ProgressBarStyle { set; }
     }
}
