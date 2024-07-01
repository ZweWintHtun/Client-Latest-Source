using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00301 : IPresenter
	{
        ILOMVEW00301 View { get; set; }

        void ClearCustomErrorMessage();
        void Update();
        void Focus();
	}

    public interface ILOMVEW00301
    {
        //ILOMCTL00301 Controller { get; set; }

        string LoansNo { get; set; }
        string AccountNo { get; set; }
        decimal SanctionAmount { get; set; }
        decimal Rate { get; set; }
        decimal InterestAmount { get; set; }

        void Successful(string message);
        void Failure(string message);
        void EnableTextBox();
        void DisableTextBox();
        void InitializedControls();
        void TextFcus();
    }
}
