//----------------------------------------------------------------------
// <copyright file="TLMSVE00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Thiyi Hay Mar Soe</CreatedUser>
// <CreatedDate>19.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dao;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Admin.DataModel;
// Added by AAM (16-Jan-2018)
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO; 

//Testing
namespace Ace.Cbs.Tel.Sve
{
   public class TLMSVE00001: BaseService,ITLMSVE00001
   {
       #region Properties
       public ICXSVE00002 CodeGenerator { get; set; }
       public ITLMDAO00005 TranTypeDAO { get; set; }
       public IPFMDAO00054 TLFDAO { get; set; }
       public ITLMDAO00015 CashDenoDAO { get; set; }
       
       // Added By AAM (16-Jan-2018)
       private ILOMDAO00096 hpRegListsDAO;
       public ILOMDAO00096 HpRegListsDAO
       {
           get { return this.hpRegListsDAO; }
           set { this.hpRegListsDAO = value; }
       }
       
       public string voucherNo = string.Empty;
       #endregion

       #region Convert DTO to ORM
       private PFMORM00054 GetTLF(TLMDTO00041 entity)
       {
           PFMORM00054 tlf = new PFMORM00054();
           tlf.Id = this.TLFDAO.SelectMaxId() + 1;
           tlf.AccountNo = entity.AccountNo;
           tlf.Amount = entity.Amount;
           tlf.Acode = entity.Acode;
           tlf.HomeOAmt = Convert.ToDecimal(0.00);
           tlf.LocalAmt = entity.Amount;
           tlf.LocalOAmt = Convert.ToDecimal(0.00);
           tlf.LocalAmount =tlf.LocalAmt+tlf.LocalOAmt ;
           tlf.SourceCurrency = entity.CurrencyCode;
           tlf.CurrencyCode = entity.CurrencyCode;
           tlf.Description = entity.Description;
           tlf.Narration = entity.Narration;
           tlf.Channel = entity.Channel;
           tlf.CheckTime = DateTime.Now;
           tlf.DateTime = DateTime.Now;
           tlf.TransactionCode = entity.TranscationCode;
           tlf.UserNo =Convert.ToString(entity.CreatedUserId);
           tlf.SourceBranchCode = entity.SourceBranchCode;
           tlf.Active = true;
           tlf.CreatedUserId =entity.CreatedUserId;
           tlf.CreatedDate = DateTime.Now;
           return tlf;
       }

       private TLMORM00015 GetCashDeno(TLMDTO00041 entity)
       {
           TLMORM00015 cashDeno = new TLMORM00015();
           cashDeno.AccountType = entity.AccountNo;
           cashDeno.Amount = entity.Amount;
           cashDeno.AdjustAmount = entity.AdjustAmount;
           cashDeno.CashDate = DateTime.Now;
           cashDeno.DenoDetail = entity.DenoDetail;
           cashDeno.DenoRate = entity.DenoRate;
           cashDeno.DenoRefundDetail = entity.DenoRefundDetail;
           cashDeno.DenoRefundRate = entity.DenoRefundRate;
           cashDeno.UserNo = Convert.ToString(entity.CreatedUserId);
           cashDeno.CounterNo = entity.CounterNo;
           cashDeno.Status = entity.CashStatus;
           cashDeno.Reverse = false;
           cashDeno.SourceBranchCode =entity.SourceBranchCode;
           cashDeno.Currency = entity.CurrencyCode;
           cashDeno.Active = true;
           cashDeno.CreatedUserId = entity.CreatedUserId;
           cashDeno.CreatedDate = DateTime.Now;
           return cashDeno;
       }
       #endregion

       #region Helper Method
       [Transaction(TransactionPropagation.Required)]
       private string Save_DomesticVoucher(PFMORM00054 tlf, TLMORM00015 cashdeno, TLMDTO00041 domesticVoucherDTO)
       {
           DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), domesticVoucherDTO.SourceBranchCode,true });
           decimal rate = CXCOM00010.Instance.GetExchangeRate(tlf.SourceCurrency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
           //CurrencyDTO currencyDTO = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });

           string day = sys001.Day.ToString().PadLeft(2, '0');
           string month = sys001.Month.ToString().PadLeft(2, '0');
           string year = sys001.Year.ToString().Substring(2);
           int updatedUserId = domesticVoucherDTO.CreatedUserId;

           voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, domesticVoucherDTO.SourceBranchCode, new object[] { day, month, year });
           TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(tlf.TransactionCode);

           if (transactionType == null)
           { throw new Exception("MV20042"); }
           else if (rate.Equals(0))
           { throw new Exception("MV20032"); }
           
           //Save TLF
           //tlf.SourceCurrency = currencyDTO.Cur;
           tlf.HomeAmt = tlf.Amount * rate;
           tlf.HomeAmount = tlf.HomeAmt+tlf.HomeOAmt;
           tlf.Rate = rate;
           tlf.SettlementDate = sys001;
           tlf.Status = transactionType.Status;
           tlf.Eno = voucherNo;
           TLFDAO.Save(tlf);

           //Save CashDeno
           if (domesticVoucherDTO.Status == "Credit Amount :")
           {
               cashdeno.Id = this.CashDenoDAO.SelectMaxId() + 1;
               cashdeno.SettlementDate = sys001;
               cashdeno.Rate = rate;
               cashdeno.TlfEntryNo = voucherNo;
               this.CashDenoDAO.Save(cashdeno);
           }

           return voucherNo;
       }
       #endregion

       #region Main Methods
       [Transaction(TransactionPropagation.Required)]
       public string SaveDomesticVoucher(TLMDTO00041 domesticVoucherDTO)
       {
           try
           {
               PFMORM00054 tlf = this.GetTLF(domesticVoucherDTO);

               if (domesticVoucherDTO.Status == "Credit Amount :")
               {
                   TLMORM00015 cashdeno = this.GetCashDeno(domesticVoucherDTO);
                   voucherNo = this.Save_DomesticVoucher(tlf, cashdeno, domesticVoucherDTO);
               }
               else
               {
                   TLMORM00015 cashdeno = new TLMORM00015();
                   voucherNo = this.Save_DomesticVoucher(tlf, cashdeno, domesticVoucherDTO);
               }

               this.ServiceResult.ErrorOccurred = false;
               this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = ex.Message;
               throw new Exception(this.ServiceResult.MessageCode);
           }
           return voucherNo;
       }
       #endregion
   }
}
