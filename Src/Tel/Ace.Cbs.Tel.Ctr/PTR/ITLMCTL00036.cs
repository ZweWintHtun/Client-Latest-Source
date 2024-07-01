using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using System;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// DayBook Controller Interface    
    /// </summary>
  public  interface ITLMCTL00036 : IPresenter
    {
      ITLMVEW00036 View { get; set; }
      bool Validate();
      void ClearCustomErrorMessage();
      void CurrentDayBook();
      void SavingDayBook();
      void FixedDayBook();
      void DomesticDayBook();
      void GetCurrentBranch();
      bool CheckDate();
    }

    /// <summary>
    /// DayBook View Interface
    /// </summary>
  public interface ITLMVEW00036
  {
      ITLMCTL00036 Controller { get; set; }
      string CurrencyCode { get; set; }
      string BranchCode { get; set; }
      DateTime RequireDate { get; }
      //bool IsAllBranch { get; }
      bool IsTransactionDate { get; }
      bool IsReversal { get; }
      bool IsSaving { get; }
      bool IsSourceCurrency { get; }
      bool SortByTime { get; set; }
      string AccountSign { get; set; }
      bool IsSettlementDate { get; }
      bool IsByAccountNo { get; }
       
  }
}

