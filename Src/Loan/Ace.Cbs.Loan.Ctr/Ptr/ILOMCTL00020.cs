using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00020 : IPresenter
    {
        ILOMVEW00020 LoansInterestEditingView { get; set; }
        string GetInterestQuarter();
        void Update();
        void ClearCustomErrorMessage();
        void Focus();
    }
    public interface ILOMVEW00020
    {
        string LoansNo { get; set; }
        string AccountNo { get; set; }
        decimal SanctionAmount { get; set; }
        decimal Rate { get; set; }
        decimal QuarterInterestAmount { get; set; }
        void Successful(string message);
        void Failure(string message);
        void EnableTextBox();
        void DisableTextBox();
        void InitializedControls();
        void TextFcus();
    }
}
