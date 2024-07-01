using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00019 : BaseService, ITCMSVE00019
    {
        #region Properties
        public ITLMDAO00015 CashDenoDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        #endregion Properties

        #region Main Methods
        [Transaction(TransactionPropagation.Required)]
        public List<TLMDTO00015> Save(List<TLMDTO00015> ListCashDenoDTO, string SourceBr)
        {
            List<TLMDTO00015> ReturnListCashDTO = new List<TLMDTO00015>();
            if (ListCashDenoDTO.Count<=0)
            {
                throw new Exception(CXMessage.ME90018);//Invalid Parameter Value.
            }
            foreach (TLMDTO00015 CashDenoDTO in ListCashDenoDTO)
            {
                string TLFEntryNo = string.Empty;
                CashDenoDTO.CashDate = System.DateTime.Now;
                CashDenoDTO.CreatedDate = System.DateTime.Now;
                TLFEntryNo = this.CodeGenerator.GetGenerateCode("NoteChangeEntryNo", string.Empty, CashDenoDTO.CreatedUserId, SourceBr, new object[] { });
                CashDenoDTO.TlfEntryNo = TLFEntryNo;
                CashDenoDTO.SettlementDate = this.GetSettlementDate(ListCashDenoDTO[0].SourceBranchCode);
                ReturnListCashDTO.Add(CashDenoDTO);
                TLMORM00015 CashDenoORM = ConvertCashDenoDTOtoORMObject(CashDenoDTO);
                this.CashDenoDAO.Save(CashDenoORM);
                //ReversalVouno = this.CodeGenerator.GetGenerateCode("Reversal Code", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });                                 //To get Note Change Entry No 
            }
            return ReturnListCashDTO;
        }
        public DateTime GetSettlementDate(string sourceBranchCode)
        {
            return CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBranchCode);
        }
        #endregion Main Methods

        #region Helper Methods
        private TLMORM00015 ConvertCashDenoDTOtoORMObject(TLMDTO00015 CashDenoDTO)
        {
            TLMORM00015 CashDenoORM = new TLMORM00015();
            CashDenoORM.TlfEntryNo = CashDenoDTO.TlfEntryNo;
            CashDenoORM.AccountType = "VB0000";
            CashDenoORM.FromType = CashDenoDTO.FromType;
            CashDenoORM.Amount = CashDenoDTO.Amount;
            CashDenoORM.AdjustAmount = CashDenoDTO.AdjustAmount;
            CashDenoORM.CashDate = System.DateTime.Now;
            CashDenoORM.DenoDetail = CashDenoDTO.DenoDetail;
            CashDenoORM.Status = CashDenoDTO.Status;
            CashDenoORM.Reverse = CashDenoDTO.Reverse;
            CashDenoORM.Currency = CashDenoDTO.Currency;
            CashDenoORM.SourceBranchCode = CashDenoDTO.SourceBranchCode;
            CashDenoORM.DenoRate = CashDenoDTO.DenoRate;
            CashDenoORM.Rate = CashDenoDTO.Rate;
            CashDenoORM.SettlementDate = CashDenoDTO.SettlementDate;
            CashDenoORM.CreatedDate = System.DateTime.Now;
            CashDenoORM.CreatedUserId=CashDenoDTO.CreatedUserId;
            CashDenoORM.UserNo = CashDenoDTO.UserNo;
            CashDenoORM.CounterNo = CashDenoDTO.CounterNo;

            return CashDenoORM;
        }
        #endregion Helper Methods 
    }
}
