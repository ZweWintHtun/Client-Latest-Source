//----------------------------------------------------------------------
// <copyright file="ITLMCTL00021.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd; 

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    /// <summary>
    /// Clearing Voucher Controller Interface
    /// </summary>
   public interface ITLMCTL00021 :IPresenter
    {
       ITLMVEW00021 View { get; set; }
       void ClearControls();
       void SaveClearingVoucher();
       IList<PFMDTO00054> InsertClearingVoucher();
   }

    /// <summary>
    /// Clearing Voucher View Interface
    /// </summary>
   public interface ITLMVEW00021
   {
       ITLMCTL00021 Controller { get; set; }
       string VoucherNo { get; set; }
       string AccountNo { get; set; }
       string Description { get; set; }
       string VoucherType { get; set; }
       string TransactionCode { get; set; }
       decimal Amount { get; set; }
       string CurrencyCode { get; set; }
       string Narration { get; set; }
      
       void Successful(string message,string voucherNo);
       void Failure(string message);
       void gvClearing_DataSourceNull();
       void gv_ClearingVoucherDataBind(IList<PFMDTO00054> tlfDTOList);
   }
}
