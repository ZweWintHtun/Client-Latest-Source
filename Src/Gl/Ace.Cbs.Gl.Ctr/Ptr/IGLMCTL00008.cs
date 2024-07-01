using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00008 : IPresenter
    {
        IGLMVEW00008 View { get; set; }
        void DisplayData();
        //bool Validate_Form();
    }
    public interface IGLMVEW00008
    {
        IGLMCTL00008 Controller { get; set; }
        string AccountNo { get; set; }
        string Currency { get; set; }
        string AccountName { get; set; }
       // Nullable<decimal> Balance { get; set; }
        string Balance { get; set; }
        void Failure(string message);
 
    }
}
