//----------------------------------------------------------------------
// <copyright file="TCMCTL00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Aye Nyein Su</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
/// <summary>
/// Cheque Book Editing Controller
/// </summary>
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
    public class TCMCTL00008:AbstractPresenter,ITCMCTL00008
    {
        private bool isSave = false;

        private ITCMVEW00008 view;
        public ITCMVEW00008 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00008 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetChequeBookEditingEntity());
            }
        }


        #region Helper Methods
        private PFMDTO00006 GetChequeBookEditingEntity()
         {
            PFMDTO00006 chequeBookEditingEntity = new PFMDTO00006();
            chequeBookEditingEntity.ChequeBookNo = this.view.ChequeBookNo;
            chequeBookEditingEntity.StartNo = this.view.StartNo;
            chequeBookEditingEntity.EndNo = this.view.EndNo;
            chequeBookEditingEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
            chequeBookEditingEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            chequeBookEditingEntity.CreatedDate = DateTime.Now;

            chequeBookEditingEntity.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);


            return chequeBookEditingEntity;
        }
        #endregion

        #region Validation
          
        public void txtChequeBookNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (String.IsNullOrEmpty(this.View.ChequeBookNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), "MV00067");
                    return;
                }

                if (!string.IsNullOrEmpty(this.view.ChequeBookNo))
                {
                    this.view.ChequeBookNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeBookNo), CXCOM00009.ChequeBookNoDisplayFormat);
                    PFMDTO00006 chequeDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00008, PFMDTO00006>(x => x.GetChequeInfoByChequeBookNo(this.View.ChequeBookNo,CurrentUserEntity.BranchCode));
                    
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        //this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetCustomErrorMessage(this.GetControl("txtChequeBookNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }

                    else
                    {
                        if (isSave == false)
                        {
                            this.View.AccountNo = chequeDTO.AccountNo;
                            this.View.IssueDate = CXCOM00006.Instance.GetDateFormat(chequeDTO.IssueDate.Value).ToString();
                            this.View.StartNo = chequeDTO.StartNo;
                            this.View.EndNo = chequeDTO.EndNo;
                            this.View.SourceBranch = CurrentUserEntity.BranchCode;
                            this.View.InitialEnableControls();
                        }                        
                    }          
                   
                }

            }
        }

        public void txtStartNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false && View.IsMainMenu == true)
            {
                if (!string.IsNullOrEmpty(this.View.StartNo))
                {
                    this.View.StartNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.View.StartNo), CXCOM00009.ChequeNoDisplayFormat);

                    string endNo = CXCLE00007.GetChequeEndNo(this.View.StartNo);

                    if (endNo.Equals("-1"))
                    {
                        // Invalid Start Cheque No.
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), CXMessage.MV00065);
                        this.View.EndNo = string.Empty;
                    }
                    else if (endNo.Equals("-2"))
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), CXMessage.MV00084);
                        this.View.EndNo = string.Empty;
                    }
                    else
                    {
                        this.View.EndNo = endNo;
                        this.SetCustomErrorMessage(this.GetControl("txtStartNo"), string.Empty);
                    }
                }
            }
        }

        #endregion

        #region UI

        public void ClearControls()
        {
            
            this.View.ChequeBookNo = string.Empty;
            this.View.AccountNo = string.Empty;
            this.View.IssueDate = string.Empty;
            this.View.StartNo= string.Empty;
            this.View.EndNo = string.Empty;
            this.View.SourceBranch = string.Empty;

            this.ClearAllCustomErrorMessage();
        }


        public void Save()
        {
            PFMDTO00006 cheque = this.GetChequeBookEditingEntity();
            isSave = true;
            if (this.ValidateForm(cheque))
            {
                cheque = this.GetChequeBookEditingEntity();

                CXClientWrapper.Instance.Invoke<ITCMSVE00008, string>(x => x.SaveCheque(cheque));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {

                    this.View.Successful(CXMessage.MI90001);
                }
            }
            this.isSave = false;

        }

        #endregion

    }
}
