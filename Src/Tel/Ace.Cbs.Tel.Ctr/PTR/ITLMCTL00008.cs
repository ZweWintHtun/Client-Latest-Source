using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Admin.DataModel;
using System.Collections.Generic;

using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00008 : IPresenter
    {
        ITLMVEW00008 View { get; set; }
        void CalculateCharges(decimal amount, string branchCode, string currency, bool takeIncomeSeperately);
        IList<BranchDTO> GetAllBranchList();
        void Clearing();
    }
    public interface ITLMVEW00008
    {
        ITLMCTL00008 Controller { get; set; }
        decimal Amount { get; set; }
        string BranchCode { get; set; }
        string Currency { get; set; }
        bool TakeIncomeSeperately { get; set; }
        decimal RemittanceAmount { get; set; }
        decimal Income { get; set; }
        decimal CommunicationCharges { get; set; }
    }
}
