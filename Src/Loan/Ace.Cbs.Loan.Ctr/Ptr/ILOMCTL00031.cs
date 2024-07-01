using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00031 : IPresenter
    {
        ILOMVEW00031 RegistrationDataEnquiryView { get; set; }
        //ILOMVEW00031 View { get; set; }
        void GetTransaction();
        IList<LOMDTO00001> BindLoansBType();
    }
    public interface ILOMVEW00031       
    {
        //int Index{get;set;}   
        string LoanType { get; set; } 
    }
}
