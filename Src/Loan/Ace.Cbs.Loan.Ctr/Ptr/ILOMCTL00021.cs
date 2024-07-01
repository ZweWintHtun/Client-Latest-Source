using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
  public interface ILOMCTL00021:IPresenter
    {
      ILOMVEW00021 LegalProcessEditingView { get; set; }
      void Save();
    }
  public interface ILOMVEW00021
  {
      string LoansNo { get; set; }
      string AccountNo { get; set; }
      decimal LedgerBalance { get; set; }
      string AdvanceType { get; set; }
      decimal SanctionAmount { get; set; }
      decimal InterestRate { get; set; }
      decimal Interest { get; set; }
      decimal ServiceCharges { get; set; }
      decimal ExtraCharges { get; set; }
      string LegalCaseLawyer { get; set; }
      bool LgSCase { get; set; }

      void Successful(string message);
      void Failure(string message);      
      void InitializedControls();
      void GetTitle();
      void EnableControls();
      void DiableControls();
      void EnableInfo(bool isEnable);
  }
}
