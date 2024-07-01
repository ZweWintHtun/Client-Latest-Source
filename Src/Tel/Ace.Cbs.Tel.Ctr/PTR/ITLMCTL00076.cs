//----------------------------------------------------------------------
// <copyright file="ITLMCTL00076.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00076:IPresenter
    {
       ITLMVEW00076 View { get; set; }
       void Save();
       IList<TLMDTO00017> GetDrawingCashDepoDenoList(string registerNo);
    }
   public interface ITLMVEW00076
   {
       ITLMCTL00076 Controller { get; set; }
       String RegisterNo { get; set; }
       String Currency { get; set; }
       Decimal Amount { get; set; }
       IList<TLMDTO00017> DrawingCashDepositDenominationDataSource { get; set; }
       void Failure(string message);
       void Successful(string message);
       void InitializeControls();
       void RegisterNoSetFocus();
       void BindGridView();
       void ClearControls();
   }
}
