using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00015
    {
        ITLMVEW00015 View { get; set; }
        void Save(IList<TLMDTO00042> ViewDataList);
        TLMDTO00042 BindDataToTemp();
        void FormCleaning();
        bool AddPOIssue();
        bool EditPOIssue(int editRowIndex);
        void ClearTextBoxControls();
        decimal CalculateNetAmount();
    }

    public interface ITLMVEW00015
    {
        ITLMCTL00015 Controller { get; set; }
        TLMDTO00042 TempData { get; set; }
        IList<TLMDTO00042> ViewDataList { get; set; }
        string GroupNo { get; set; }
        string PONo { get; set; }
        string Currency { get; set; }
        decimal Amount { get; set; }
        decimal Charges { get; set; }
        decimal TotalAmount { get; set; }
        string RegisterNo { get; set; }
        string _Name { get; set; }
        bool isWithIncome { get; set; }       
        IList<TLMDTO00012> DenoInfo { get; set; }
        void Successful(string message);
        void Failure(string message);
        void BindTempDataListToGridview();
        void ChangeControlName(bool isChanged);
    }
}
