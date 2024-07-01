//----------------------------------------------------------------------
// <copyright file="TLMCTL00076.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2014-07-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
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
    public class TLMCTL00076 : AbstractPresenter, ITLMCTL00076
    {
        #region "Wire To"
        private ITLMVEW00076 view;
        public ITLMVEW00076 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00076 view)
        {
            if (this.view == null)
            {
                this.view = view;
               this.Initialize(this.view, this.GetDrawingCashDepositDenomination());
            }
        }
        private CXDTO00001 _DenoData { get; set; }
        public IList<TLMDTO00017> AcType { get; set; }
        #endregion

        #region "Private Methods"
        private TLMDTO00017 GetDrawingCashDepositDenomination()
        {
            TLMDTO00017 drawingCashDepoDeno = new TLMDTO00017();
            drawingCashDepoDeno.RegisterNo = this.View.RegisterNo;
            drawingCashDepoDeno.Currency = this.View.Currency;
            return drawingCashDepoDeno;
        }
        public IList<TLMDTO00017> GetDrawingCashDepoDenoList(string registerNo)
        {
            IList<TLMDTO00017> drawingCashDepoDenoDTOList = new List<TLMDTO00017>();
           drawingCashDepoDenoDTOList = CXClientWrapper.Instance.Invoke<ITLMSVE00076, TLMDTO00017>(x => x.GetDrawingCashDepositDenoLists(registerNo, CurrentUserEntity.BranchCode));
           this.AcType = drawingCashDepoDenoDTOList;
            return drawingCashDepoDenoDTOList;
        }
        private CXDTO00001 GetDenoList()
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.view.Currency, CXDMD00008.Received, "frmTLMVEW00016" }) == DialogResult.OK)
            {
                 this._DenoData= CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00016");
                return this._DenoData;
            }
            else
            {
                ////Error Occur becoz user don't enter deno entry but close the deno form.
                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                return null;
            }
        }
        private IList<string> GetRegisterNoList()
        {
            IList<string> rnoList = new List<string>();
            IList<TLMDTO00017> RDList = new List<TLMDTO00017>();         
            RDList = this.view.DrawingCashDepositDenominationDataSource;
            for (int i = 0; i < RDList.Count; i++)
            {
                rnoList.Add(RDList[i].RegisterNo);
            }
            return rnoList;
        }     
        #endregion

        #region "Public Methods"
        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
        public void Save()
        {
            if (this.ValidateForm(this.GetDrawingCashDepositDenomination()))
            {
                CXDTO00001 denoString = this.GetDenoList();
                IList<string> registerNoList=this.GetRegisterNoList();
               // string drawerbank = this.GetDrawerBank();
                if (denoString == null)
                    return;
                else
                {
                    TLMDTO00015 updatecashDenoDTO = new TLMDTO00015();
                    updatecashDenoDTO.RegisterNo = this.view.RegisterNo;                  
                    updatecashDenoDTO.DenoDetail = denoString.DenoString;
                    updatecashDenoDTO.DenoRate = denoString.DenoRateString;
                    updatecashDenoDTO.DenoRefundDetail = denoString.RefundString;
                    updatecashDenoDTO.DenoRefundRate = denoString.RefundRateString;
                   // updatecashDenoDTO.Rate = this.Rate;
                    updatecashDenoDTO.AdjustAmount = denoString.AdjustAmount;
                    updatecashDenoDTO.UserNo = CurrentUserEntity.CurrentUserName;
                    updatecashDenoDTO.CounterNo = denoString.CounterNo;
                    updatecashDenoDTO.AllDenoRate = string.Empty;
                    updatecashDenoDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    updatecashDenoDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                   // updatecashDenoDTO.BranchCode = drawerbank;
                    updatecashDenoDTO.VirtualStatus = (this.view.RegisterNo.Substring(0,1)=="G")?"DCMultiple":"DCSingle";
                   // this.CashDenoDAO.UpdateCashDenoByGroupNo(updatecashDenoDTO);
                    CXClientWrapper.Instance.Invoke<ITLMSVE00076>(x => x.Save(updatecashDenoDTO, registerNoList));               
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {

                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = this.View.RegisterNo;//Tlf_Eno
                        logItemForDeno[1] = this.AcType[0].AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = this.View.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = this._DenoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = this._DenoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = CurrentUserEntity.BranchCode;//sourcebr
                        logItemForDeno[10] = this.View.Currency;//cur
                        logItemForDeno[11] = this._DenoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Online Cash To Cash Transfer Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);



                        //Saving Error.
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);



                    }
                    else
                    {

                        string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = this.View.RegisterNo;//Tlf_Eno
                        logItemForDeno[1] =  this.AcType[0].AccountNo ;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = this.View.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] =  this._DenoData.DenoString;//Deno_Detail
                        logItemForDeno[6] = this._DenoData.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = CurrentUserEntity.BranchCode;//sourcebr
                        logItemForDeno[10] = this.View.Currency;//cur
                        logItemForDeno[11] = this._DenoData.DenoRateString;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Online Cash To Cash Transfer Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                         //Saving Successful
                        this.View.Successful(CXMessage.MI90001);





                    }
                    this.View.InitializeControls();
                }
            }
            else
            {
                this.view.RegisterNoSetFocus();
            }
        }
        #endregion

        #region "Validation Methods"
        public void txtGroupNo_CustomValidating(object sender, ValidationEventArgs e)
         {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                IList<TLMDTO00017> RDList = new List<TLMDTO00017>();
                RDList = this.GetDrawingCashDepoDenoList(this.View.RegisterNo);
               
                if (RDList.Count == 0 || CXClientWrapper.Instance.ServiceResult.ErrorOccurred==true)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtGroupNo"),CXClientWrapper.Instance.ServiceResult.MessageCode); //MV00168 Invalid Drawing Registerno.
                    this.view.ClearControls();
                    return;
                }
                if (RDList[0].Deno_Status != null)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00230); // MV00230 This drawing register no is already made denomination entry. 
                    return;
                }
                else
                {
                    this.view.Currency = RDList[0].Currency;
                    this.view.Amount = RDList[0].Amount.Value;
                    this.view.DrawingCashDepositDenominationDataSource = RDList;
                    this.view.BindGridView();
                }              
            }
        }      
        #endregion
    }
}
