//----------------------------------------------------------------------
// <copyright file="TLMCTL00042.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-02</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00042:AbstractPresenter , ITLMCTL00042
    {
        private ITLMVEW00042 view;
        public ITLMVEW00042 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00042 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        private PFMDTO00067 GetViewData()
        {
            PFMDTO00067 dto = new PFMDTO00067();
            dto.AccountNo = this.view.AccountNo;
            return dto;
        }

        public void txtEnquiryAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;
            if (!CXCLE00012.Instance.CheckAccountNoType(this.View.AccountNo, CXDMD00011.AccountNoType2))
            {
                this.SetCustomErrorMessage(this.GetControl("txtEnquiryAccountNo"), CXMessage.MV00046);
            }

        }

        public PFMDTO00067 GetAccountInformation()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ITLMSVE00042, PFMDTO00067>(service => service.GetAccountInformation(this.View.AccountNo));
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
