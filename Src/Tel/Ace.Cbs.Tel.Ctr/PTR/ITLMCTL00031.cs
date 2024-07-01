//----------------------------------------------------------------------
// <copyright file="ITLMCTL00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public interface ITLMCTL00031:IPresenter
    {
      ITLMVEW00031 BankstatementListingByDateView { get; set; }
      bool CheckDate();
      void CLedgerMainPrint();
      void FAOFMainPrint();
      IList<PFMDTO00021> FledgerInfoLists { get; set; }
    }

  public interface ITLMVEW00031
  {
      ITLMCTL00031 BankstatementListingByDateController { get; set; }
      string AccountNo { get; set; }
      DateTime StartDate { get; set; }
      DateTime EndDate { get; set; }
      //void ForFAOFAccount(bool invisible);
      bool IsAllCustmers { get; set;}
      bool isFixedAcc { get; set; }
      bool WithReversal { get; set; }
  }
}
