using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
   public interface IMNMCTL00078 : IPresenter
    {
        IMNMVEW00078 View { get; set; }
        void Print();
        void ClearCustomErrorMessage();

    }
       public interface IMNMVEW00078
       {
            IMNMCTL00078 Controller { get; set;}
            DateTime StartDate { get; set; }
            DateTime EndDate { get; set; }
            string FormName { get; set; }
           // string CurrencyCode { get; set; }
    
       }
    
}
