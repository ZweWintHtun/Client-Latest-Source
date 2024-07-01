using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00019:AbstractPresenter, ITCMCTL00019
    {
        private ITCMVEW00019 _view;
        public ITCMVEW00019 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }   

        private void WireTo(ITCMVEW00019 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view,new object());
            }
        }

        public void ClearCustomErrorMessage()
        {
            throw new NotImplementedException();
        }

        public void ClearingForm()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            List<TLMDTO00015> ListCashDenoDto = new List<TLMDTO00015>();
            CXDTO00002 rateinfo= CXCLE00011.Instance.GetDenoExchangeRateString(this.View.DepositDeno[0].Currency, CurrentUserEntity.BranchCode, "CS");
            #region For Deposit
            TLMDTO00015 DepositCashDeno = new TLMDTO00015();
            var depositdenolist = from x in this.View.DepositDeno where x.RefundCount > 0 || x.DenoCount > 0 select x;

            CXDTO00001 DepositDenoDetail = CXCLE00009.Instance.GetDenoString(depositdenolist.ToList<TLMDTO00012>(), true, CurrentUserEntity.BranchCode);

            string CounterType = string.Empty;
            CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType);
          
            DepositCashDeno.Amount = this.View.TotalAmount;
            DepositCashDeno.AdjustAmount = DepositDenoDetail.AdjustAmount;
            DepositCashDeno.DenoDetail = DepositDenoDetail.DenoString;
            DepositCashDeno.DenoRate = DepositDenoDetail.DenoRateString;
            DepositCashDeno.Reverse = false;
            DepositCashDeno.Currency = this.View.DepositDeno[0].Currency;
            DepositCashDeno.CounterNo = this.View.CounterNo;
            DepositCashDeno.Status = CounterType;
            DepositCashDeno.FromType = CXCOM00007.Instance.GetValueByKeyName("Note Exchange Deposit");
            DepositCashDeno.Rate =Convert.ToDecimal(rateinfo.ExchangeRateString);
            DepositCashDeno.SourceBranchCode=CurrentUserEntity.BranchCode;
            DepositCashDeno.UserNo =Convert.ToString(CurrentUserEntity.CurrentUserID);
            DepositCashDeno.CreatedUserId = CurrentUserEntity.CurrentUserID;

            

            ListCashDenoDto.Add(DepositCashDeno);
            #endregion For Deposit

            #region For Withdraw
            TLMDTO00015 WithdrawCashDeno = new TLMDTO00015();
            var Withdrawdenolist = from x in this.View.DenoData where x.RefundCount > 0 || x.DenoCount > 0 select x;

            CXDTO00001 WithdrawDenoDetail = CXCLE00009.Instance.GetDenoString(Withdrawdenolist.ToList<TLMDTO00012>(), true, CurrentUserEntity.BranchCode);

            CounterType = string.Empty;
            CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCounterType);
            
            WithdrawCashDeno.Amount = this.View.TotalAmount;
            WithdrawCashDeno.AdjustAmount = WithdrawDenoDetail.AdjustAmount;
            WithdrawCashDeno.DenoDetail = WithdrawDenoDetail.DenoString;
            WithdrawCashDeno.DenoRate = WithdrawDenoDetail.DenoRateString;
            WithdrawCashDeno.Reverse = false;
            WithdrawCashDeno.Currency = this.View.DenoData[0].Currency;
            WithdrawCashDeno.CounterNo = this.View.CounterNo;
            WithdrawCashDeno.Status = CounterType;
            WithdrawCashDeno.FromType = CXCOM00007.Instance.GetValueByKeyName("Note Exchange Withdraw");
            WithdrawCashDeno.Rate = Convert.ToDecimal(rateinfo.ExchangeRateString);
            WithdrawCashDeno.SourceBranchCode = CurrentUserEntity.BranchCode;
            WithdrawCashDeno.CreatedUserId = CurrentUserEntity.CurrentUserID;
            WithdrawCashDeno.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);

            ListCashDenoDto.Add(WithdrawCashDeno);
            #endregion For Withdraw

            List<TLMDTO00015> ReturnListCashDeno= CXClientWrapper.Instance.Invoke<ITCMSVE00019, List<TLMDTO00015>>(x => x.Save(ListCashDenoDto, CurrentUserEntity.BranchCode));
            this.View.DepositEntryNo = CounterType == ReturnListCashDeno[0].Status ? ReturnListCashDeno[1].TlfEntryNo : ReturnListCashDeno[0].TlfEntryNo;
            this.View.WithdrawalEntryNo = CounterType == ReturnListCashDeno[1].Status ? ReturnListCashDeno[1].TlfEntryNo : ReturnListCashDeno[0].TlfEntryNo;

            for (int i = 0; i < ListCashDenoDto.Count; i++)
            {
                string[] logItemForDeno = new string[14];
                //ClientLog For Deno
                logItemForDeno[0] = ReturnListCashDeno[i].TlfEntryNo;//Tlf_Eno
                logItemForDeno[1] = ListCashDenoDto[i].AccountType;//AcType
                logItemForDeno[2] = string.Empty;//FromType
                logItemForDeno[3] = this.View.TotalAmount.ToString();//Amount
                logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                logItemForDeno[5] = ListCashDenoDto[i].DenoDetail;//Deno_Detail
                logItemForDeno[6] = ListCashDenoDto[i].DenoRefundDetail;//DenoRefund_Detail
                logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                logItemForDeno[8] = "0";//REVERSE
                logItemForDeno[9] = CurrentUserEntity.BranchCode;//sourcebr
                logItemForDeno[10] = ListCashDenoDto[i].Currency;//cur
                logItemForDeno[11] = ListCashDenoDto[i].DenoRate;//DenoRate
                logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.DepositDeno[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Online Income Commit Deno", CurrentUserEntity.BranchCode,
                logItemForDeno);

            }


            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90001");
        }

        public bool ValidateAmount()
        {
            if (this.View.Amount != this.View.TotalAmount)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00037");
                return false;
            }
            return true;
        }
    }
}
