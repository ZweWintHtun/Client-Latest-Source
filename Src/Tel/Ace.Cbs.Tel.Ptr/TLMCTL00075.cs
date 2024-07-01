//----------------------------------------------------------------------
// <copyright file="TLMCTL00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2014-07-14</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using System.Windows.Forms;

namespace Ace.Cbs.Tel.Ptr
{
  public class TLMCTL00075 : AbstractPresenter , ITLMCTL00075
    {
      #region "Wire To"
        private ITLMVEW00075 view;
        public ITLMVEW00075 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00075 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        #endregion

        #region "Validation Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        //public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    // if xml base error does not exist.
        //    if (e.HasXmlBaseError == false)
        //    {
        //        try
        //        {
        //            PFMDTO00054 tlDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00075, PFMDTO00054>(x => x.isValidEntryNo(this.View.Eno, CurrentUserEntity.BranchCode));
        //            if (tlDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
        //                return;
        //            }
        //            else if (tlDTO.Amount == 0)
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI30016");
        //                return;
        //            }
        //            else
        //            {
        //                this.view.AccountNo = tlDTO.AccountNo;
        //                this.view.Description = tlDTO.ReceiptNo;
        //                this.view.PoNo = tlDTO.OtherBankChq;
        //                this.view.Currency = tlDTO.OtherBank;
        //                this.view.Amount = tlDTO.Amount;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI30016"); //Invalid Entry No.
        //        }

        //        // this.SetFocus("txtEntryNo");
        //    }
        //    else
        //    { return; }
        //}
   
       #endregion

      #region "Private Methods"
      private PFMDTO00054 GetCashPaymentDenomination()
      {
          PFMDTO00054 cashdenoEntity = new PFMDTO00054();
          try
          {           
              cashdenoEntity.Eno = this.view.Eno;
              cashdenoEntity.AccountNo = this.view.AccountNo;
              cashdenoEntity.Description = this.view.Description;
              cashdenoEntity.PaymentOrderNo = this.view.PoNo;
              cashdenoEntity.CurrencyCode = this.view.Currency;
              cashdenoEntity.Amount = this.view.Amount;
              cashdenoEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
              cashdenoEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
              //cashdenoEntity.UserNo = CurrentUserEntity.CurrentUserName;
              cashdenoEntity.UserNo = CurrentUserEntity.CurrentUserID.ToString();
          }
          catch
          {
              throw new Exception(CXMessage.ME00021);
          }
         return cashdenoEntity;
      }

      private PFMDTO00054 GetEntity()
      {
          PFMDTO00054 cashdenoEntity = new PFMDTO00054();
          cashdenoEntity.Eno = this.view.Eno;              
          return cashdenoEntity;
      }
     
      private CXDTO00001 GetDenoList()
      {
          //if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.view.Currency, CXDMD00008.Payment, "frmTLMVEW00016" }) == DialogResult.OK)
          //{
          //    return CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00016");

          //}
          if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.view.Currency, CXDMD00008.Payment, "TLMVEW00075" }) == DialogResult.OK)
          {
             return CXUIScreenTransit.GetData<CXDTO00001>("TLMVEW00075");              
          }
          else
          {
              ////Error Occur becoz user don't enter deno entry but close the deno form.
              this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
              return null;
          }
      }


      #endregion

      #region "Public Methods"    
      public void Save()
      {
          PFMDTO00054 cashdenoDTO = this.GetCashPaymentDenomination();
          cashdenoDTO.VoucherStatus =this.view.status;
          if (this.ValidateForm(GetEntity()))
          {
              CXDTO00001 denoString = this.GetDenoList();
              if (denoString == null)
                  return;
              else
              {
                 // PFMDTO00054 cashdenoDTO = this.GetCashPaymentDenomination();
                  CXClientWrapper.Instance.Invoke<ITLMSVE00075>(x => x.SaveorUpdate(cashdenoDTO, denoString));
                  if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                  {
                      //Saving Error.
                      this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                  }
                  else
                  {
                      //Saving Successful.
                      this.View.Successful(CXMessage.MI90001);
                  }
                  //this.View.InitailizeControls();
              }
          }
          //else
          //{
          //    this.view.EntryNoSetFocus();
          //}          
      }      
      #endregion
    }
}
