//----------------------------------------------------------------------
// <copyright file="ITLMCTL00071.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>2013-06-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;
using System.Data;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public  interface ITLMCTL00071:IPresenter
    {
      ITLMVEW00071 View { get; set; }
      void Receipt(bool isreversal);
      DataTable ReceiptRefund(bool isreversal);
      DataTable ReceiptWithdrawByCounter(bool isreversal);
      DataTable Payment(bool isreversal);
      DataTable NotesChange(bool isreversal);
      void MultiTransactions(bool isreversal);
      IList<CounterInfoDTO> GetCounterInfo();
      void ClearAllCustomErrorMessage();
      DataTable Receipt_New(bool isreversal);
      string GetReportTitle();
    }

  public interface ITLMVEW00071 
  {
      ITLMCTL00071 Controller { get; set; }
      DateTime RequireDate { get; }
      string CurrencyCode { get; set; }
      bool isReversal { get; }
      string CounterNo { get; }
      bool isNoteChange { get; }
      bool isMultiTransaction { get; }
      bool isReceipt { get; }
      bool isPayment { get; }
      bool isReceiptRefund { get; }
      bool isReceiptWithdraw { get; }
  }
}
