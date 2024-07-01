//----------------------------------------------------------------------
// <copyright file="TLMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.Contracts.Dao;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// PO Receipt Service
    /// </summary>
  public class TLMSVE00007:BaseService,ITLMSVE00007
  {
      #region "Properties"
      private ITLMDAO00016 poDAO;
      public ITLMDAO00016 PODAO {get;set;}

      private IPFMDAO00054 tlfDAO;
      public IPFMDAO00054 TLFDAO{get; set;}      

      private IChargeOfAccountDAO coaDAO;
      public IChargeOfAccountDAO COADAO{get; set;}
    
      private ITLMDAO00016 poReceiptDAO;
      public ITLMDAO00016 POReceiptDAO
      {
         set { this.poReceiptDAO = value; }
         get { return this.poReceiptDAO; }
      }

      TLMDTO00016 POEntity { get; set; }
      public ICXSVE00002 CodeGenerator { get; set; }     
      public ICXSVE00006 POBudgetYear { get; set; }

      private ICXDAO00014 bLFDAO;
      public ICXDAO00014 BLFDAO
      {
          get { return this.bLFDAO; }
          set { this.bLFDAO = value; }
      }

      #endregion

      #region "Main Methods"
        [Transaction(TransactionPropagation.Required)]
        public string Save(TLMDTO00045 POReceiptDTO)     
        {
            string PaySlipNo = string.Empty;

            //PaySlipNo = this.CodeGenerator.GetGenerateCode("PO.Receipt.Code", string.Empty, POReceiptDTO.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { POReceiptDTO.SettlementDate.Value.Day.ToString().PadLeft(2, '0'), POReceiptDTO.SettlementDate.Value.Month.ToString().PadLeft(2, '0'), POReceiptDTO.SettlementDate.Value.Year.ToString().Substring(2) });
            PaySlipNo = this.CodeGenerator.GetGenerateCode("PO.Receipt.Code", string.Empty, POReceiptDTO.CreatedUserId, POReceiptDTO.SourceBranch, new object[] { POReceiptDTO.SettlementDate.Value.Day.ToString().PadLeft(2, '0'), POReceiptDTO.SettlementDate.Value.Month.ToString().PadLeft(2, '0'), POReceiptDTO.SettlementDate.Value.Year.ToString().Substring(2) });
           
            PFMORM00054 TLFORM = this.GetTLF(POReceiptDTO,PaySlipNo);
            this.TLFDAO.Save(TLFORM);
            
            //Update PO => IssueDate,Status,Budget and UpdatedUserId
            POReceiptDTO.UpdatedUserId = POReceiptDTO.CreatedUserId;
            if ( this.PODAO.UpdatePOByPONo(DateTime.Now, "D", POReceiptDTO.Budget, POReceiptDTO.UpdatedUserId.Value,POReceiptDTO.PaymentOrderNo,TLFORM.UserNo)==false)
            {
                throw new Exception(CXMessage.ME90001);
            }

            return PaySlipNo;
        }
        #endregion

      #region "Helper Methods"

        //Added by ZMS For Budget end Flexible 2018/09/21
        public string GetBudYear(int service, DateTime reqDate, string sourceBr)
        {
            string Return = string.Empty;
            string budYear = BLFDAO.GetBudget_Month_Year_Quarter(service, reqDate, sourceBr, Return);  // For 2018/09/17 => active budget from BLF as 2018/2019
            return budYear;
        }

        private PFMORM00054 GetTLF(TLMDTO00045 PoReceipt,string payslipNo)
        {
            PFMORM00054 TLF = new PFMORM00054();
            TLF.Id = this.TLFDAO.SelectMaxId()+1;
            TLF.Eno = payslipNo;
            TLF.AccountNo = PoReceipt.Acode;
            TLF.Amount = PoReceipt.Amount;
            TLF.Acode = PoReceipt.Acode;
            TLF.HomeAmount = PoReceipt.HomeAmount;
            TLF.HomeAmt = PoReceipt.HomeAmt;
            TLF.HomeOAmt = 0;
            TLF.LocalAmount = PoReceipt.LocalAmount;
            TLF.LocalAmt = PoReceipt.LocalAmt;
            TLF.LocalOAmt = 0;
            TLF.PaymentOrderNo = PoReceipt.PaymentOrderNo;
            TLF.Description = PoReceipt.Description;
            TLF.Narration = PoReceipt.Narration;
            TLF.DateTime = DateTime.Now;
            TLF.Status = PoReceipt.Status;
            TLF.TransactionCode = PoReceipt.TransactionCode;
            TLF.UserNo = Convert.ToString(PoReceipt.CreatedUserId);
            TLF.OtherBank = PoReceipt.OtherBank;
            TLF.OtherBankAcctNo = PoReceipt.OtherBankAcctNo;
            TLF.CLRPostStatus = PoReceipt.CLRPostStatus;
            TLF.SourceCurrency = PoReceipt.SourceCurrency;
            TLF.CurrencyCode = PoReceipt.SourceCurrency;
            TLF.SourceBranchCode = PoReceipt.SourceBranch;
            TLF.Rate = PoReceipt.Rate;
            TLF.SettlementDate = PoReceipt.SettlementDate;
            TLF.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            TLF.ReferenceType = PoReceipt.TransactionCode;
            TLF.ReferenceVoucherNo = PoReceipt.ReferenceVoucherNo;
            TLF.CreatedUserId = PoReceipt.CreatedUserId;
            TLF.CreatedDate = DateTime.Now;
            TLF.Active = true;

            return TLF;
        }   

        #endregion
  }
}
