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
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00059 : AbstractPresenter, IMNMCTL00059
    {
        #region "Constructor"

        public MNMCTL00059()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #endregion 

        #region Properties

        private string BranchCode { get; set; }
        IList<MNMDTO00035> freceiptList { get; set; }
        IList<PFMDTO00001> BindData { get; set; }
     
        private IMNMVEW00059 view;
        public IMNMVEW00059 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods

        private void WireTo(IMNMVEW00059 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        private MNMDTO00035 GetVlaidateData()
        {
            MNMDTO00035 ValidateDto = new MNMDTO00035();
            ValidateDto.AcctNo = this.view.AccountNo;
            ValidateDto.Cur = this.view.currencyNo;
            return ValidateDto;
        }

        #region Events calling Methods

        public void mtxtAccountNo_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (!e.HasXmlBaseError)
            {
                if (string.IsNullOrEmpty(view.AccountNo))
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00046");
            }

            Nullable<CXDMD00011> accountType;
            string accountNo = this.View.AccountNo.Replace("-", "");

             try
             {
                 if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                 {
                    BindData = CXClientWrapper.Instance.Invoke<IMNMSVE00059, IList<PFMDTO00001>>(x => x.CheckingAccount(accountNo, CurrentUserEntity.BranchCode));
                   
                    

                     if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                     {
                         if (BindData != null && !string.IsNullOrEmpty(BindData[0].Message))
                         {
                             this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { BindData[0].Message });
                         }
                         else
                         {
                             this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                             CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                         }
                     }

                     if (BindData[0].SourceBranch != CurrentUserEntity.BranchCode && string.IsNullOrEmpty(BindData[0].Message))
                     {
                         // Invalid Branch Code
                         this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });
                         return;
                     }

                 }
             }

             catch (Exception ex)
             {
                 // Set Error Message to Control.
                 if (ex.Message == "MV00114")
                     this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                 else
                     this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                     
             }
            
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetVlaidateData());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void Print(string acctno,string cur)
        {
            freceiptList = CXClientWrapper.Instance.Invoke<IMNMSVE00059, IList<MNMDTO00035>>(x => x.SelectFReceiptInfo(acctno,cur,this.BranchCode));
           
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                CXUIScreenTransit.Transit("frmMNMVEW00108FixedDepoReceiptReport", true, new object[] { freceiptList });
            }
        }

        #endregion

        #endregion
    }
}