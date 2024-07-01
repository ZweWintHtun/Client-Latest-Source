using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00012 : IPresenter
    {
        IGLMVEW00012 View { get; set; }
        IList<ChargeOfAccountDTO> SelectCOAData();
        IList<ChargeOfAccountDTO> SelectCOADataByAcode(string acode);
        void clickonOK();
    }

    public interface IGLMVEW00012
    {
        IGLMCTL00012 Controller { get; set; }
        string PLAccount { get; set; }
        string PITAccount { get; set; }
    }
}
