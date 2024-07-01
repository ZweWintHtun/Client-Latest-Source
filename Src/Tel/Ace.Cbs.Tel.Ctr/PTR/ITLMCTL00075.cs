//----------------------------------------------------------------------
// <copyright file="ITLMCTL00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-14</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Pfm.Dmd;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public  interface ITLMCTL00075 : IPresenter
   {
      ITLMVEW00075 View { get; set; }
      void Save();
      void ClearCustomErrorMessage();
  }
  public interface ITLMVEW00075      
  {
      ITLMCTL00075 Controller { get; set; }
      string Eno { get; set; }
      string AccountNo { get; set; }
      string Description { get; set; }
      string status { get; set; }
      string PoNo { get; set; }
      string Currency { get; set; }
      decimal Amount { get; set; }      
      void Successful(string message);
      void Failure(string message);
     

      //PFMDTO00054 CashDeno { get; set; }
      //string Status { get; set; }      
      //void InitailizeControls();
      //void EntryNoSetFocus();
     // bool IsFormLoad { get; set; }
  }
}
