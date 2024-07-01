//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00060 : AbstractPresenter, IMNMCTL00060
    {
        #region Properties

        IList<MNMDTO00035> FixedRateList { get; set; }
        private IMNMVEW00060 view;
        public IMNMVEW00060 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods

        private void WireTo(IMNMVEW00060 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        private PFMDTO00007 GetVlaidateData()
        {
            PFMDTO00007 ValidateDto = new PFMDTO00007();
            //ValidateDto.Duration = this.view.RequiredDuration;
            return ValidateDto;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public IList<PFMDTO00007> SelectDuration()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00060, IList<PFMDTO00007>>(x => x.SelectRequiredDuration());
        }


        public void Print(string duration)
        {
            decimal _duration = Convert.ToDecimal(duration);
            FixedRateList = CXClientWrapper.Instance.Invoke<IMNMSVE00060, IList<MNMDTO00035>>(x => x.SelectDurationForFixedDeposit(_duration, CurrentUserEntity.BranchCode));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                CXUIScreenTransit.Transit("frmMNMVEW00131FixedDepoDurationReport", true, new object[] { FixedRateList,this.view.RequiredDuration});
            }
            
        }

        #endregion
    }
}