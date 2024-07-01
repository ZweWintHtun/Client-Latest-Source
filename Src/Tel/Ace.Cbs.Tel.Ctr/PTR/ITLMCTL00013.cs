//----------------------------------------------------------------------
// <copyright file="ITLMCTL00013.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using System.Drawing;


namespace Ace.Cbs.Tel.Ctr.Ptr
{
    //Fixed Deposit Wihtdraw Controller Interface
    public interface ITLMCTL00013 : IPresenter
    {
        ITLMVEW00013 View { get; set; }      
        void SaveFixedDepositWithdraw();
        void ClearControls();
        void FixInterestCalculation();
        bool Validate();
    }

   //Fixed Deposit Withdraw View Interface
   public interface ITLMVEW00013
   {
       ITLMCTL00013 Controller { get; set; }     
       string AccountNo { get; set; }
       string VoucherNo { get; set; }
       string RegisterDuration { get; set; }
       string ReceiptNo { get; set; }
       decimal Amount { get; set; }
       decimal TotalAmount { get; set; }
       string RegisterDate { get; set; }
       decimal AvailableInterestAfterTax { get; set; }
       int NoOfPerson { get; set; }
       string AccountSign { get; set;  }
       string JoinType { get; set; }
       string CurrencyCode { get; set; }
       string Name { get; set; }
       decimal InterestRate { get; set; }
       decimal Duration { get; set; }
       string Receipt { get; set; }
       DateTime LastIntDate { get; set; }
       string AccuredStatus { get; set; }
       string Status { get; set; }
       decimal Accrued { get; set; }
       bool MatureStatus { get; set; }
       Image Photo { get; set; }
       Image Signature { get; set; }
       IList<PFMDTO00032> receiptNoList { get; set; }
       IList<PFMDTO00032> BindReceiptNo(IList<PFMDTO00032> receiptNoList);       
       void EnableControls();
       void gvClearing_DataSourceNull();
       void gvCustomer_DataBind(IList<PFMDTO00001> custList);
       void Successful(string message, string VoucherNo);
       void Failure(string message);
       void ReceiptBind();

   
       void Select();
   }
}
