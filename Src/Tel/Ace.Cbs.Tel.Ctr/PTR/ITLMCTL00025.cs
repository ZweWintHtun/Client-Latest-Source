using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public interface ITLMCTL00025 :IPresenter
    {
      ITLMVEW00025 View { get; set; }
      bool Validate();
      void ClearCustomErrorMessage();
    }
  public interface ITLMVEW00025
  {
      ITLMCTL00025 Controller { get; set; }
      string CounterNo { get;}
      string AccountNo { get;}
      
  }
}
