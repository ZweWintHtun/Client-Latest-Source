//----------------------------------------------------------------------
// <copyright file="ITCMCTL00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-08-01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
   public interface ITCMCTL00070: IPresenter
    {
       ITCMVEW00070 View { get; set; }
    }
   public interface ITCMVEW00070
   {
       ITCMCTL00070 Controller { get; set; }
       string AccountNo { get; set; }
       string FromName { get; set; }
       string ToName { get; set; }
       string GiftChequeNo { get; set; }
       string ChequeNo { get; set; }
       decimal Amount { get; set; }
       decimal Charges { get; set; }
       decimal TotalAmount { get; set; }
       bool IsVIP { get; set; }
       string ACSign { get; set; }
       TLMDTO00059 GiftChequeDTO { get; set; }
       bool isWithIncome { get; set; }
       string Texts { get; set; }
       void InitalizeControls();
       void DisableChequeNo();
   }
}
