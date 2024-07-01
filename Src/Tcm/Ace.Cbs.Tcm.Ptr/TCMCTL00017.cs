//----------------------------------------------------------------------
// <copyright file="TLMCTL00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>20/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dto;
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using System.Linq;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00017: AbstractPresenter, ITCMCTL00017
    {

        private ITCMVEW00017 _view;
        public ITCMVEW00017 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00017 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetCashDenoData());
            }
        }

        private string _CounterNo { get; set; }
        private CXDTO00001 _DenoData { get; set; }
        public IList<TLMDTO00015> AcType { get; set; }

        #region HelperMethods

        private TLMDTO00015 GetCashDenoData()
        {
            TLMDTO00015 cashdenodto = new TLMDTO00015();
            cashdenodto.TlfEntryNo = this.View.TlfEntryNo;
            return cashdenodto;
        }

        public void GetCashDeno()
        {
            this.View.CashDenoList = CXClientWrapper.Instance.Invoke<ITCMSVE00017, IList<TLMDTO00015>>(x => x.GetOnlineDenominationData(CurrentUserEntity.BranchCode));
        }

        private bool GetDenoList()
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.Totalamount, this.View.Currency, CXDMD00008.Received, "frmTCMVEW00017" }) == DialogResult.OK)
            {
                this._DenoData = CXUIScreenTransit.GetData<CXDTO00001>("frmTCMVEW00017");
                return true;
            }
            else
                return false;
        }

        public IList<TLMDTO00015> GetGridData()
        {
            IList<TLMDTO00015> cashdeno = CXClientWrapper.Instance.Invoke<ITCMSVE00017, IList<TLMDTO00015>>(x => x.GetChargesAmount(this.View.TlfEntryNo,CurrentUserEntity.BranchCode));
            if (cashdeno.Count > 0)
            {
                this.View.Totalamount = cashdeno.Sum(x => x.IncomeCharges + x.CommunicationCharges);
                this.AcType = cashdeno;
                return cashdeno;
            }
            else
            {
                this.View.Failure("MV00213");
                return null;
            }
        }

        public void ClearingForm()
        {
            this._view.Currency = string.Empty;
            this._view.Totalamount = 0;
            this.ClearAllCustomErrorMessage();
        }
        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        #endregion

        #region MainMethod

        public void Save()
        {
            if (this.GetDenoList())
            {
               CXClientWrapper.Instance.Invoke<ITCMSVE00017>(x => x.Update(this.View.TlfEntryNo,this.View.Currency,this._DenoData,CurrentUserEntity.CurrentUserID));

               #region Fail 
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] logItemForDeno = new string[14];
                    //ClientLog For Deno
                    logItemForDeno[0] = this.View.TlfEntryNo;//Tlf_Eno
                    logItemForDeno[1] = this.AcType[0].AccountType;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = this.View.Totalamount.ToString();//Amount
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Note Change Fail Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);


                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                   
                }
               #endregion

              #region Successful Transcation


                else
                 {
                    string[] logItemForDeno = new string[14];
                        //ClientLog For Deno
                        logItemForDeno[0] = this.View.TlfEntryNo;//Tlf_Eno
                        logItemForDeno[1] = this.AcType[0].AccountType;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = this.View.Totalamount.ToString();//Amount
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Note Change Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);

                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                       
                    }
               #endregion
            }
        }
        #endregion
    }
}
