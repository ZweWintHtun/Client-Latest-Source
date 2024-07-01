//----------------------------------------------------------------------
// <copyright file="LOMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> TAK </CreatedUser>
// <CreatedDate>12-01-2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00023 : AbstractPresenter, ILOMCTL00023
    {
        #region "Properties"
        ILOMVEW00023 view;
        public ILOMVEW00023 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(ILOMVEW00023 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        #region "Validation Methods"
        public LOMDTO00021 GetEntity()
        {
            LOMDTO00021 entity = new LOMDTO00021();
            return entity;
        }
        #endregion

        //public IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth)
        //{
        //    IList<LOMDTO00021> liList = CXClientWrapper.Instance.Invoke<IMNMSVE00002, IList<LOMDTO00021>>(x => x.CheckIntCalculateDate(year,Smonth,Emonth));
        //    return liList;
        //}

        //public bool UpdateLoanInterest(IList<LOMDTO00021> liList)
        //{
        //    return CXClientWrapper.Instance.Invoke<IMNMSVE00002, bool>(x => x.UpdateLoanInterest(liList));
        //}

        public string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode)
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00002, string>(x => x.CalculateLoansInterestForQuarter(sDate, eDate, period, branchCode));
        }
        public string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode,int userId)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetInterestDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LOAN_INT_CAL", branchCode, true });
            PreviousSys001Dto.BLInterestDate = GetInterestDate;
            PreviousSys001Dto.BranchCode = branchCode;

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            Sys001Entity.BLInterestDate =DateTime.Now;
            Sys001Entity.BranchCode = branchCode;

            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);
            return CXClientWrapper.Instance.Invoke<IMNMSVE00002, string>(x => x.CalculateLoansInterestForMonthly(sDate, eDate, period, branchCode, dvcvList,userId));
        }
    }
}
