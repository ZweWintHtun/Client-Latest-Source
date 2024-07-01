//----------------------------------------------------------------------
// <copyright file="TLMCTL00073.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-10-15</CreatedDate>
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
   public class TLMCTL00073:AbstractPresenter,ITLMCTL00073
   {
       #region "Wire To"
       private ITLMVEW00073 bankStatementListingByDateForFixedDepositACView;
        public ITLMVEW00073 BankStatementListingByDateForFixedDepositACView
        {
            get { return this.bankStatementListingByDateForFixedDepositACView; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00073 view)
        {
            if (this.bankStatementListingByDateForFixedDepositACView == null)
            {
                this.bankStatementListingByDateForFixedDepositACView = view;
                this.Initialize(this.bankStatementListingByDateForFixedDepositACView, new PFMDTO00042());
            }
        }
       #endregion

        #region "Method"
        public IList<PFMDTO00042> GetBankStatementReportList(DateTime startDate,DateTime endDate,string accountNo,bool isAllCustomers,bool withReversal)
        {
            PFMDTO00042 ReportTLF = new PFMDTO00042();         
            IList<PFMDTO00042> BankStatementListingList = new List<PFMDTO00042>();
            string budgetmonthcalculate = "M" + Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, startDate));
            string budgetyear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);

            string workStationId = Convert.ToString(CurrentUserEntity.WorkStationId);
            BankStatementListingList = CXClientWrapper.Instance.Invoke<ITLMSVE00051, PFMDTO00042>(x => x.GetGenerateDataForBankStatementDTOReportList(startDate,endDate,accountNo,isAllCustomers,"F", budgetmonthcalculate, budgetyear,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode,withReversal,workStationId));

            return BankStatementListingList;
        }
        #endregion
   }
}
