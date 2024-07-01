using System;
using System.Drawing;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.CBM.Ctr.Ptr
{
    /// <summary>
    /// Individual Controller
    /// </summary>
    public interface ICBMCTL00001 : IPresenter
    {
        ICBMVEW00001 View { get; set; }
        void Print(string fname);
        
    }

    /// <summary>
    /// Individual View
    /// </summary>
    public interface ICBMVEW00001
    {
        ICBMCTL00001 Controller { get; set; }
        DateTime Date { get; set; }
        string Currency { get; set; }
    }
}