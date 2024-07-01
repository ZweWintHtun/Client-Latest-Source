using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00009:IPresenter
    {
        ITCMVEW00009 View { get; set; }
        void Save();
         //void ClearFormControls();
        void ClearCustomErrorMessage();
    }

    public interface ITCMVEW00009
    {
        ITCMCTL00009 Controller { get; set; }

        string AccountNo { get; set; }
        string LoansNo { get; set; }
        decimal OverdraftLimit { get; set; }
        string LastCalculateDate { get; set; }
        decimal Rate { get; set; }
        decimal InterestOfLastDate { get; set; }
        decimal InterestMonth1 { get; set; }
        decimal InterestMonth2 { get; set; }
        decimal InterestMonth3 { get; set; }
        decimal InterestTotal { get; set; }
        string Month1 { get; set; }
        string LabelTotalInterest { get; set; }
        string Month2 { get; set; }
        string Month3 { get; set; }
        string ParentFormId { get; set; }
        string FormName { get; set; }
        bool isValidate { get; set; }
        void ClearFormControls();
        void EnableControls();
        void DisableControls();
        void SetFocus();
        void ClearControls();
        void Successful(string message);
        void Failure(string message);
    }
}
