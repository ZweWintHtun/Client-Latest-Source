//----------------------------------------------------------------------
// <copyright file="ITLMCTL00073.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-10-15</CreatedDate>
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
   public interface ITLMCTL00073:IPresenter
    {
       ITLMVEW00073 BankStatementListingByDateForFixedDepositACView { get; set; }
       //IList<PFMDTO00042> GetBankStatementReportList(DateTime startDate, DateTime endDate, string accountNo, bool isAllCustomers);
       IList<PFMDTO00042> GetBankStatementReportList(DateTime startDate, DateTime endDate, string accountNo, bool isAllCustomers, bool withReversal);
    }
   public interface ITLMVEW00073
   {
       ITLMCTL00073 BankStatementListingByDateForFixedDepositACController { get; set; }
        string TransactionStatus { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string AccountNo { get; set; }
        bool IsAllCustomers { get; set; }
        IList<PFMDTO00021> FledgerInfoLists { get; set; }

   }
}
