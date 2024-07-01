using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;

using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00063
    {
        ITCMVEW00063 View { get; set; }
        bool ValidateAdd();
        void ClearControls(bool isGird); 
        bool Save();
    }

    public interface ITCMVEW00063
    {
        ITCMCTL00063 Controller { get; set; }
        string Status { get; set; }
        string AccountNo { get; set; }
        string AccountName { get; set; }
        string DepositCode { get; set; }
        string DepositCodeDesp { get; set; }
        int SrNo { get; set; }
        string CustomerName { get; set; }
        decimal Quota { get; set; }
        decimal Quantity { get; set; }
        decimal Amount { get; set; }
        decimal AccumulateAmount { get; set; }
        decimal TotalAccumulateAmount { get; set; }
        string CurrencyCode { get; set; }
        CXDTO00001 DenoInfo { get; set; }
        TLMDTO00008 Dep_TlFEntity { get; set; }
        IList<TLMDTO00008> Dep_TLFCollection { get; set; }
        string SourceBranchCode { get; set; }
        decimal initialAmount { get; set; }
        void BindData();
        void SetCursor(string txt);
        void EnableControlsforView(string name);
        void DisableControlsforView(string name);
        void Successful(string message, string name, string VoucherNo);
        void Failure(string message);
    }
}
