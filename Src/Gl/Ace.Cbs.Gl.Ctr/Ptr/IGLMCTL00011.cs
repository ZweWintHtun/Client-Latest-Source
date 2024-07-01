using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00011 : IPresenter
    {
        IList<GLMDTO00001> SelectFormatFile(string formatStatus);
        IGLMVEW00011 View { get; set; }
        void PreView(string formatType, string formatStatus);
    }
    public interface IGLMVEW00011
    {
        IGLMCTL00011 Controller { get; set; }
        string Currency { get; set; }
        int Month { get; set; }
        string Header { get; set; }
        string ReportFormat { get; }
        string MonthText { get; }
        string FormName { get; }
        bool isHomeCurrency { get; }
    }
}
