//----------------------------------------------------------------------
// <copyright file="TCMCTL00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2014/08/01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    /*Gift Cheque Issued By Transfer ( Income ) Controller*/
    /*Gift Cheque Issued By Transfer ( No Income ) Controller*/
   public class TCMCTL00070: AbstractPresenter,ITCMCTL00070
   {
       #region Wire To
       private ITCMVEW00070 view;
        public ITCMVEW00070 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITCMVEW00070 giftChequeIssuebytransferview)
        {
            if (this.view == null)
            {
                this.view = giftChequeIssuebytransferview;
                this.Initialize(this.view, this.GetViewData());
            }
        }
       #endregion

        #region Custom Validation Methods
        public void mtxtAccountNo_CustomValiding(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType2 || accountType == CXDMD00011.DomesticAccountType))
                {
                    if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        string workstation = CurrentUserEntity.WorkStationId.ToString();
                        this.view.GiftChequeDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00070, TLMDTO00059>(x => x.CheckAccountNo(this.view.AccountNo, this.view.IsVIP, this.view.isWithIncome, workstation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                        if (this.view.GiftChequeDTO == null)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.view.FromName = this.view.GiftChequeDTO.NAME;
                          //  this.view.ACSign = this.view.PODTO.AcSign;
                            if (this.view.ACSign == "S")
                            {
                                this.view.DisableChequeNo();
                            }
                        }

                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { this.view.AccountNo, CurrentUserEntity.BranchCode });

                    }
                }
                else
                {
                    this.View.InitalizeControls();
                }
            }

        }
        #endregion

        #region Methods
        private TLMDTO00059 GetViewData()
        {
            TLMDTO00059 GiftChequeDTO = new TLMDTO00059();
            GiftChequeDTO.IsCheck = this.view.IsVIP;
            GiftChequeDTO.ACCTNO = this.view.AccountNo;
            GiftChequeDTO.NAME = this.view.FromName;
            GiftChequeDTO.TONAME = this.view.ToName;
            GiftChequeDTO.AMOUNT = this.view.Amount;
            GiftChequeDTO.CHARGES = this.view.Charges;
            GiftChequeDTO.GCNO = this.view.GiftChequeNo;
            GiftChequeDTO.TotalAMOUNT = this.view.TotalAmount;
            GiftChequeDTO.CHECKNO = this.view.ChequeNo;                
                return GiftChequeDTO;
        }
       #endregion
   }
}
