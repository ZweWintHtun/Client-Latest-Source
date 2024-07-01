using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00007:IPresenter
    {
        IMNMVEW00007 View { get; set; }
        void Save(string Saving, string Fixed);
        void SelectByKeyName();
        void ClearControls();
    }

    public interface IMNMVEW00007
    {
        IMNMCTL00007 Controller { get; set; }
        bool SavingAccrued { get; set; }
        bool SavingNotAccrued { get; set; }
        bool FixedAccrued { get; set; }
        bool FixedNotAccrued { get; set; }

        void Failure(string message);
        void Successful(string message);
    }
}
