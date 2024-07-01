//----------------------------------------------------------------------
// <copyright file="TLMSVE00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// CLEARING VOUCHER SERVICE
    /// </summary>
    public class TLMSVE00021 : BaseService, ITLMSVE00021
    {
        #region DAO
        public ICXSVE00002 CodeGeneratorDAO { get; set; }
        public ITLMDAO00005 TranTypeDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        
        #endregion

        #region MAIN METHODS
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SaveClearingVoucher(IList<PFMDTO00054> tlfListDTO)
        {
            string voucherNo = string.Empty;
            try
            {
        
                DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), tlfListDTO[0].SourceBranchCode ,true});
                decimal rate = CXCOM00010.Instance.GetExchangeRate(tlfListDTO[0].CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                string day = sys001.Day.ToString().PadLeft(2, '0');
                string month = sys001.Month.ToString().PadLeft(2, '0');
                string year = sys001.Year.ToString().Substring(2);
                int updatedUserId = tlfListDTO[0].CreatedUserId;
                //voucherNo = this.CodeGeneratorDAO.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });
                voucherNo = this.CodeGeneratorDAO.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId, tlfListDTO[0].SourceBranchCode, new object[] { day, month, year });
              
                foreach (PFMDTO00054 tlfDTO in tlfListDTO)
                {
                    PFMORM00054 tlfEntity = new PFMORM00054();
                    tlfEntity.Id = this.TLFDAO.SelectMaxId() + 1;
                    tlfEntity.Eno = voucherNo;
                    tlfEntity.AccountNo = tlfDTO.AccountNo;
                    tlfEntity.Acode = tlfDTO.AccountNo;
                    tlfEntity.Description = tlfDTO.Description;
                    tlfEntity.Amount = tlfDTO.Amount;
                    tlfEntity.HomeAmt = tlfDTO.Amount * rate;
                    tlfEntity.HomeOAmt = Convert.ToDecimal(0.00);
                    tlfEntity.HomeAmount = tlfEntity.HomeAmt + tlfEntity.HomeOAmt;
                    tlfEntity.LocalAmt = tlfDTO.Amount;
                    tlfEntity.LocalOAmt = Convert.ToDecimal(0.00);
                    tlfEntity.LocalAmount = tlfEntity.LocalAmt + tlfEntity.LocalOAmt;
                    tlfEntity.CurrencyCode = tlfDTO.CurrencyCode;
                    tlfEntity.SourceCurrency = tlfDTO.CurrencyCode;
                    tlfEntity.SourceBranchCode = tlfListDTO[0].SourceBranchCode;
                    tlfEntity.DateTime = DateTime.Now;
                    tlfEntity.UserNo = Convert.ToString(tlfListDTO[0].CreatedUserId);
                    tlfEntity.Rate = rate;
                    tlfEntity.SettlementDate = sys001;
                    tlfEntity.Channel = tlfListDTO[0].Channel;
                    tlfEntity.Narration = tlfDTO.Narration;
                    tlfEntity.TransactionCode = tlfDTO.TransactionCode;
                    TLMDTO00005 transactionType = this.TranTypeDAO.SelectTranTypeStatus(tlfEntity.TransactionCode);
                    tlfEntity.Status = transactionType.Status;
                    tlfEntity.CreatedUserId = tlfListDTO[0].CreatedUserId;
                    tlfEntity.CreatedDate = DateTime.Now;

                    this.TLFDAO.Save(tlfEntity);
                    tlfDTO.Status = tlfEntity.Status;
                    tlfDTO.Eno = voucherNo;
                  
                    
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00051";
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return tlfListDTO;
        }
        #endregion
    }
}
