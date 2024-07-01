//----------------------------------------------------------------------
// <copyright file="ITCMCTL00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
  public  interface ITCMCTL00014 :IPresenter
    {
      ITCMVEW00014 View { get; set; }
      TCMDTO00001  BindInitialData();
      bool StartUp();
      bool isMainMenuEnabled { get; set; }
    }

  public interface ITCMVEW00014
  {
      ITCMCTL00014 Controller { get; set; }
      //string NeedToStartUp { get; set; }
      string BankHead { get; set; }
      string SystemDate { get; set; }
      string Status { get; set; }
      void Successful(string message);
      void Failure(string message);     
      void FormClose();
      void DisableSystemInfo();
      //void ToShowNeedToStartUpLabel();
      //void DisableExitButton(bool enable);
  }
}
