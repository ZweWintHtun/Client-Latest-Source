//----------------------------------------------------------------------
// <copyright file="MNMCTL00156.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-12</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00161 : AbstractPresenter, IMNMCTL00161
    {
        #region "For Initializer"
        private IMNMVEW00161 interestWithdrawListingView;
        public IMNMVEW00161 FixedDepositInterestWithdrawListingView
        {
            get { return this.interestWithdrawListingView; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00161 view)
        {
            if (this.interestWithdrawListingView == null)
            {
                this.interestWithdrawListingView = view;
                this.Initialize(this.interestWithdrawListingView, this.Print());
            }
        }
        #endregion
          private TLMDTO00019 Print()
        {
            try
            {
                TLMDTO00019 fixintDTO = new TLMDTO00019();               
                return fixintDTO;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        public void MainPrint(string datetype)
        {
            IList<TLMDTO00019> FixedIntWithDTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00161, IList<TLMDTO00019>>(x => x.MainPrint(this.FixedDepositInterestWithdrawListingView.StartDate, this.FixedDepositInterestWithdrawListingView.EndDate, datetype, CurrentUserEntity.BranchCode));
            if (FixedIntWithDTOList.Count > 0)
            {
                CXUIScreenTransit.Transit("frmMNMVEW00162", true, new object[] { FixedIntWithDTOList,datetype,this.FixedDepositInterestWithdrawListingView.StartDate,this.FixedDepositInterestWithdrawListingView.EndDate});
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
        }
      
    }
}
