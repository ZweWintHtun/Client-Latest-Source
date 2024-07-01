using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Sve;
//using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00007 : BaseService,ITCMSVE00007
    {
        #region Properties

        public ITLMDAO00015 CashDenoDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }

        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public void Save(TLMDTO00015 cashDenoEntity,PFMDTO00054 paymentData)
        {
            try
            {
                decimal HomeExRate = CXCOM00010.Instance.GetExchangeRate(paymentData.SourceCurrency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));  //1                               

                DateTime settlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), paymentData.SourceBranchCode , true});
                //DateTime settlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode });
                if (settlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.                    
                    return;
                }               

                // Save Cash Deno
                //TLMORM00015 cashDeno = new TLMORM00015();
                //cashDeno.DenoEntryNo = string.Empty;
                //cashDeno.TlfEntryNo = paymentData.Eno;
                //cashDeno.AccountType = paymentData.AccountNo;
                //cashDeno.FromType = cashDenoEntity.FromType;
                //cashDeno.BranchCode = cashDenoEntity.FromType;
                //cashDeno.ReceiptNo = cashDenoEntity.ReceiptNo;
                //cashDeno.Amount = paymentData.Amount;                
                //cashDeno.CashDate = DateTime.Now;               
                //cashDeno.DenoDetail = cashDenoEntity.DenoDetail;
                //cashDeno.DenoRate = cashDenoEntity.DenoRate;
                //cashDeno.DenoRefundDetail = cashDenoEntity.DenoRefundDetail;
                //cashDeno.DenoRefundRate = cashDenoEntity.DenoRefundRate;
                //cashDeno.SettlementDate =settlementDate;
                //cashDeno.AllDenoRate = cashDenoEntity.AllDenoRate;
                //cashDeno.Rate = HomeExRate;
                //cashDeno.AdjustAmount = cashDenoEntity.AdjustAmount;
                //cashDeno.Amount = cashDenoEntity.Amount;
                //cashDeno.CounterNo = cashDenoEntity.CounterNo;
                //cashDeno.UserNo = paymentData.CreatedUserId.ToString();   
                ////cashDeno.UserNo = CurrentUserEntity.CurrentUserID.ToString();                
                //cashDeno.Status = "P";
                //cashDeno.Reverse = false;
                //cashDeno.SourceBranchCode = paymentData.SourceBranchCode;
                ////cashDeno.SourceBranchCode = CurrentUserEntity.BranchCode;
                //cashDeno.Currency = paymentData.SourceCurrency;               
                //cashDeno.Active = true;
                //cashDeno.CreatedUserId = paymentData.CreatedUserId;
                ////cashDeno.CreatedUserId = CurrentUserEntity.CurrentUserID;
                //cashDeno.CreatedDate = DateTime.Now;
                //this.CashDenoDAO.Save(cashDeno);

                TLMDTO00015 updatecashDenoDTO = new TLMDTO00015();
                updatecashDenoDTO.TlfEntryNo = paymentData.Eno;
                updatecashDenoDTO.DenoDetail = cashDenoEntity.DenoDetail;
                updatecashDenoDTO.DenoRate = cashDenoEntity.DenoRate;
                updatecashDenoDTO.Rate = HomeExRate;
                updatecashDenoDTO.AdjustAmount = 0;
                updatecashDenoDTO.Status = "P";
                updatecashDenoDTO.UserNo = paymentData.UserNo;
                updatecashDenoDTO.CounterNo = cashDenoEntity.CounterNo;
                updatecashDenoDTO.AllDenoRate = string.Empty;
                updatecashDenoDTO.UpdatedUserId = paymentData.CreatedUserId;
                updatecashDenoDTO.SourceBranchCode = paymentData.SourceBranchCode;
                updatecashDenoDTO.VirtualStatus = "CashDeno";
                updatecashDenoDTO.SettlementDate = settlementDate;
                this.CashDenoDAO.UpdateCashDenoByGroupNo(updatecashDenoDTO);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";  //Saving Successful
            }
            catch (Exception ex)
            {
                this.ServiceResult.MessageCode = ex.Message;
            }
        }

        #endregion             

        #region Validation Method

        public PFMDTO00054 Check_EntryNo(string entryNo, string sourceBr, string tranCode)
        {
            return this.TLFDAO.GetTlfInfo( entryNo, sourceBr, tranCode);
        }
        public IList<TLMDTO00015> Check_DenoEno(string tlfeno, string status, string sourceBr)
        {
            return this.CashDenoDAO.GetCashDenoInfo( tlfeno,  status, sourceBr);
        }

        #endregion 
    }
}


