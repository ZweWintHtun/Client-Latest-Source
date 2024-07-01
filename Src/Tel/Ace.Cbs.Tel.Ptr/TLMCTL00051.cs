//----------------------------------------------------------------------
// <copyright file="TLMCTL00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
   public class TLMCTL00051:AbstractPresenter,ITLMCTL00051
   {
       #region "Wire To"
       private ITLMVEW00051 bankStatementListingReportview;
       public ITLMVEW00051 BankStatementListingReportView
        {
            get { return this.bankStatementListingReportview; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00051 view)
        {
            if (this.bankStatementListingReportview == null)
            {
                this.bankStatementListingReportview = view;
                this.Initialize(this.bankStatementListingReportview, new PFMDTO00042());
            }
        }
       #endregion

        #region "Method"
        public IList<PFMDTO00042> GetBankStatementReportList()
        {
            PFMDTO00042 ReportTLF = new PFMDTO00042();           
            IList<PFMDTO00042> BankStatementListingList = new List<PFMDTO00042>();

            //Modified By ZMS For Budget End Flexible 2018/09/21
            //string budgetmonthcalculate = "M" + Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, this.bankStatementListingReportview.StartDate));
            //string budgetyear = CXCOM00010.Instance.GetBudgetYear_For_PreviousBudget(CXCOM00009.BudgetYearCode, this.bankStatementListingReportview.StartDate);
            string budgetmonthcalculate = String.Empty; // will calculate in TLMSVE00051
            string budgetyear = String.Empty; // will calculate in TLMSVE00051
            
            string workStationId = Convert.ToString(CurrentUserEntity.WorkStationId);
            BankStatementListingList = CXClientWrapper.Instance.Invoke<ITLMSVE00051, PFMDTO00042>(x => x.GetGenerateDataForBankStatementDTOReportList(this.bankStatementListingReportview.StartDate,this.bankStatementListingReportview.EndDate,this.bankStatementListingReportview.AccountNo,false,"CS",budgetmonthcalculate,budgetyear,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode,this.bankStatementListingReportview.WithReversal,workStationId));
            return BankStatementListingList;
        }
        #endregion
   }
}
