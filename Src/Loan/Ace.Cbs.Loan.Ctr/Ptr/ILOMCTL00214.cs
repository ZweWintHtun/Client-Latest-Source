using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00214 : IPresenter
    {
        ILOMVEW00214 View { get; set; }
        string GetRepayAmountPerTerm(string hpno, string sourceBr);
        void Print(string rptName, string acctNo, string currency, string sourceBr);//Updated by HWKO (21-Nov-2017)
        bool CheckHPAccountNo(string acctNo);//Added by HWKO (21-Nov-2017)

    }
    public interface ILOMVEW00214
    {
        ILOMCTL00214 Controller { get; set; }
        //string HPNo { get; set; }//Commented by HWKO (21-Nov-2017)
        string AcctNo { get; set; }//Added by HWKO (21-Nov-2017)
        string SourceBr { get; set; }
        string Currency { get; set; }
    }
}
