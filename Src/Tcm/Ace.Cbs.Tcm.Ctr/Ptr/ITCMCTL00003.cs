using System.Collections.Generic;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00003 : IPresenter
    {
        ITCMVEW00003 View { get; set; }        
       
        void FormCleaning();
         bool ValidateForm(object validationContext);
        void SavePOIssueTransfer(IList<TLMDTO00043> POIssueLists);
        bool[] CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit);
        bool AddPOIssue();
        TLMDTO00043 GetViewData();    
    }

    public interface ITCMVEW00003 //: IPresenter
    {
        ITCMCTL00003 POIssueByTransferController { get; set; }
        TLMDTO00043 TempData { get; set; }
        
        IList<TLMDTO00043> ViewDataList { get; set; }
        string AccountNo { get; set; }
        string ChequeNo { get; set; }
        string Currency { get; set; }
        decimal POAmount { get; set; }
        decimal Charges { get; set; }
        decimal TotalAmount { get; set; }       
        bool IsVIP { get; set; }
        TLMDTO00016 PODTO { get; set; }       
        bool isWithIncome { get; set; }
        void InitializeControls();
        string ACSign { get; set; }
        string Texts { get; set; }
        void Successful(string message);
        void Failure(string message);
        void BindTempDataListToGridview();
        int GetMenuIDPermission();
        void DisableChequeNo();
    }
}
