using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00026 : BaseService, IMNMSVE00026
    {
        ITLMDAO00001 REDAO { get; set; }
        ITLMDAO00016 PODAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00054 TLFDAO { get; set; }
        ICXSVE00006 ReverSalDAO { get; set; }
        ICXDAO00006 CodeCheckerDAO { get; set; }
        IPFMDAO00056 Sys001DAO { get; set; }

        decimal charges = 0;

         #region DTO Properties
        public string PONo { get; set; }
        public string PaymentOrderNo { get; set; }
        public string VoucherNo { get; set; }
        private ChargeOfAccountDTO CoaDTO { get; set; }
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private string TransactionCodeDebit { get; set; }
        private string TransactionCodeCredit { get; set; }
        private string TransactionTypeDebitStatus { get; set; }
        private string TransactionTypeCreditStatus { get; set; }
        private decimal TotalAmount { get; set; }
        public string CoaSetupAccountNo { get; set; }
        public string CoaSetupAccount { get; set; }
        public string CoaSetupIncomeAccountNo { get; set; }
        public string Description { get; set; }
        public string IncomeDescription { get; set; }
        public string Income { get; set; }
        public string COAACName { get; set; }
        #endregion

        #region Main Method
        public TLMDTO00001 GetReInfo(string registerNo, string sourceBr)
        {
            TLMDTO00001 reInfo = this.REDAO.SelectByRegisterNo(registerNo, sourceBr);
            if (reInfo != null && (reInfo.ToAccountNo != null && reInfo.ToAccountNo.ToString() != string.Empty && reInfo.ToAccountNo.Substring(0, 2) == "IR"))
            {
                string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
                TLMDTO00016 PODTO = this.PODAO.SelectPOByPONoAndSourceBrAndCurAndBudgetYear(reInfo.ToAccountNo, sourceBr, reInfo.Currency, CurBudYear);
                if (PODTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00219"; //PO No. Not Found.
                    return null;
                }
                else
                {
                    if (PODTO.IDate == null || PODTO.IDate == default(DateTime))
                    {
                        reInfo.IsNullPOIDate = true;
                    }
                    else
                    {
                        reInfo.IsNullPOIDate = false;
                    }
 charges = PODTO.Charges==null ? 0 : PODTO.Charges.Value ;
                }
            }
            return reInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> Save(TLMDTO00001 entity)
        {
            try
            {
                IList<PFMDTO00054> TLFList = new List<PFMDTO00054>();
 //string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
                //entity.Budget = CurBudYear;
                TLMDTO00001 oldData = this.REDAO.SelectByRegisterNo(entity.RegisterNo, entity.SourceBranchCode);
                if (oldData.IssueDate != null && oldData.IssueDate != default(DateTime))
                {
                    this.ReversalProcess(entity);
                }

                if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty && entity.ToAccountNo.Substring(0, 2) == "IR")
                {
					//Update PO
                    this.PODAO.UpdatePOByAmount(entity.ToAccountNo, entity.Budget, entity.SourceBranchCode, entity.Amount, charges,entity.UpdatedUserId.Value,DateTime.Now);                    

                    //Update RE
                    this.REDAO.UpdateREbyRegisterNoWithAmount(entity.Amount, entity.RegisterNo, entity.SourceBranchCode,entity.ToName,entity.ToAddress,entity.ToNRC,entity.ToPhoneNo, entity.UpdatedUserId.Value);

                    //Insert New 2 lines in Tlf
                  TLFList = this.SaveIR(entity);
                }
                else
                {
                    if(entity.ToAccountNo!=null && entity.ToAccountNo.ToString()!=string.Empty)
                        this.UpdateForInterestStatusChange(entity);

                    //Update RE
                    this.REDAO.UpdateREbyRegisterNoWithAmountAndIssueDate(entity.Amount, entity.RegisterNo, entity.SourceBranchCode, entity.ToName,entity.ToAddress,entity.ToNRC,entity.ToPhoneNo,entity.UpdatedUserId.Value);

                    //Insert New 2 lines in Tlf
                    //this.SaveCustomerAcc(entity);
                }
                return TLFList;
               
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete(TLMDTO00001 entity)
        {
            try
            {
                TLMDTO00001 oldData = this.REDAO.SelectByRegisterNo(entity.RegisterNo, entity.SourceBranchCode);
                if (oldData.IssueDate != null && oldData.IssueDate != default(DateTime))
                {
                    this.ReversalProcess(entity);
                }
                if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty && entity.ToAccountNo.Substring(0, 2) == "IR")
                {
                    this.PODAO.DeletePOByActive(entity.ToAccountNo, entity.SourceBranchCode, entity.UpdatedUserId.Value);
                }
                else
                {
                    if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty)
                        this.UpdateForInterestStatusChange(entity);
                }

                //Delete RE
                this.REDAO.DeleteREbyRegisterNo(entity.RegisterNo, entity.SourceBranchCode, entity.Currency, entity.UpdatedUserId.Value);
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
        #endregion

        #region Helper Methods
        private string GetGeneratedEnoLocal(string MaxItem,int UpdateUserID,string BranchCode)
        {
            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), BranchCode,true});

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);


            string Eno = this.CodeGenerator.GetGenerateCode(MaxItem, string.Empty, UpdateUserID, BranchCode, new object[] { day, month, year });

            return Eno;
        }

        [Transaction]
        private void ReversalProcess(TLMDTO00001 entity)
        {
            string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
            //TLMDTO00001 oldData = this.REDAO.SelectByRegisterNo(entity.RegisterNo, entity.SourceBranchCode);
            IList<PFMDTO00054> TlfList = this.TLFDAO.SelectByERegisterNo(entity.RegisterNo, entity.SourceBranchCode, DateTime.Now);
            if (TlfList != null || TlfList.Count > 0)
            {
                var isOrgnEnoNull = from x in TlfList
                                    where x.OrgnEno == null
                                    && x.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString()
                                    select x;
                int i = isOrgnEnoNull.ToList<PFMDTO00054>() == null ? 0 : isOrgnEnoNull.ToList<PFMDTO00054>().Count;

                if (i == 0)
                {
                    throw new Exception("ME30003"); //Entry No Already Issued
                }
                else
                {
                    if (entity.ToAccountNo != null && entity.ToAccountNo.ToString() != string.Empty && entity.ToAccountNo.Substring(0, 2) == "IR")
                    {
TLMDTO00016 PODTO = this.PODAO.SelectPOByPONoAndSourceBrAndCurAndBudgetYear(entity.ToAccountNo, entity.SourceBranchCode, entity.Currency, CurBudYear);
                        if (PODTO == null)
                        {
                            throw new Exception("MV00219"); //PO No. Not Found.
                        }
                        if (PODTO.IDate != null && PODTO.IDate != default(DateTime))
                        {
                            throw new Exception("MV00149"); //This P.O No. {0} is already refund.
                        }
                    }

                    string GeneratedEno = GetGeneratedEnoLocal("Reversal Code", entity.UpdatedUserId.Value, entity.SourceBranchCode);
                    ReverSalDAO.ReversalProcess(TlfList[0].Eno, GeneratedEno, "", entity.SourceBranchCode, DateTime.Now, entity.SourceBranchCode, entity.UpdatedUserId.Value, null, string.Empty, true);
                }
            }
            else
            {
                throw new Exception("MV30010"); //This Register No is not Today Transaction
            }
        }

        [Transaction]
        private void UpdateForInterestStatusChange(TLMDTO00001 entity)
        {
            PFMDTO00028 Account = this.CodeCheckerDAO.GetAccountInfoOfCledgerByAccountNoAndSourceBranch(entity.ToAccountNo, entity.ToAccountNo.ToString().Substring(0, 3));
            if (Account != null)
            {
                if (Account.CloseDate != null && Account.CloseDate != default(DateTime))
                {
                    throw new Exception("MV00044"); //Account has been Closed
                }
                else 
                {
                    //this.CodeCheckerDAO.UpdateCurrentBalance(Account.AccountNo, Account.CurrentBal + entity.Amount, ++Account.TransactionCount, entity.UpdatedUserId.Value, entity.UpdatedUserId.Value.ToString());
                }
            }
            else
            {
                throw new Exception("MV00175"); //Account No. Not Found
            }

            if (Account.OverdraftLimit > 0 || Account.TemporaryOverdraftLimit > 0)
            {
                this.Sys001DAO.UpdateStatusSys001(entity.UpdatedUserId.Value, "OVD_INT_CAL", "N", entity.SourceBranchCode);
            }
            else
            {
                if (Account.LoansCount > 0)
                {
                    this.Sys001DAO.UpdateStatusSys001(entity.UpdatedUserId.Value, "SERVICE_CHG_CAL", "N", entity.SourceBranchCode);
                }
            }
        }
        #endregion

        #region IR
        public IList<PFMDTO00054> SaveIR(TLMDTO00001 entity)
        {
            try
            {
                IList<PFMDTO00054> TLFList = new List<PFMDTO00054>();
                //For TLF Description require to save ACode Description
                this.CoaSetupAccountNo = entity.DebitACode;
                this.COAACName = entity.DebitACodeName;
                if (this.COAACName == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode, true });
                if (this.SettlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }
                this.Rate = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                if (this.Rate == 0)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }
                this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);

                this.TransactionCodeDebit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentDebit); //EREMITDRTR
                TLMDTO00005 tranTypeDebitDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeDebit });
                if (tranTypeDebitDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
                this.TransactionCodeCredit = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueForEncashmentCredit); //POICRTR
                TLMDTO00005 tranTypeCreditDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCodeCredit });
                if (tranTypeCreditDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
                this.TransactionTypeDebitStatus = tranTypeDebitDTO.Status; //TDV
                this.TransactionTypeCreditStatus = tranTypeCreditDTO.Status; //TCV
                this.CoaSetupAccount = entity.CreditACode;

                VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, entity.CreatedUserId, entity.SourceBranchCode, new object[] { this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });

                PFMORM00054 tlfEntity = this.GetTLF(entity);
                tlfEntity.ReferenceVoucherNo = entity.RegisterNo;
                tlfEntity.Eno = VoucherNo;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;

                tlfEntity.Eno = VoucherNo;
                this.TLFDAO.Save(tlfEntity);
                TLFList.Add(new PFMDTO00054(tlfEntity.Eno, tlfEntity.AccountNo, tlfEntity.Amount, tlfEntity.Status, tlfEntity.TransactionCode, tlfEntity.Narration, tlfEntity.DateTime, tlfEntity.Acode, tlfEntity.Cheque, tlfEntity.CurrencyCode, tlfEntity.Rate.Value, tlfEntity.SettlementDate.Value, tlfEntity.TS, tlfEntity.AccountSign, tlfEntity.HomeAmount.Value, tlfEntity.HomeAmt.Value, tlfEntity.HomeOAmt.Value, tlfEntity.LocalAmount.Value, tlfEntity.LocalAmt.Value, tlfEntity.LocalOAmt.Value, tlfEntity.Description, tlfEntity.PaymentOrderNo));

                #region NextTlf
                tlfEntity = this.GetTLF(entity);
                tlfEntity.Eno = this.VoucherNo;
                tlfEntity.AccountNo = this.CoaSetupAccount;
                tlfEntity.Acode = this.CoaSetupAccount;
                tlfEntity.TransactionCode = TransactionCodeCredit;
                tlfEntity.Status = TransactionTypeCreditStatus;
                tlfEntity.Id = TLFDAO.SelectMaxId() + 1;
                tlfEntity.ReferenceVoucherNo = entity.RegisterNo;
                //For TLF Description require to save ACode Description
                this.COAACName = entity.CreditACodeName;
                if (this.COAACName == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                    return null;
                }

                tlfEntity.Description = this.COAACName;
                this.TLFDAO.Save(tlfEntity);
                TLFList.Add(new PFMDTO00054(tlfEntity.Eno, tlfEntity.AccountNo, tlfEntity.Amount, tlfEntity.Status, tlfEntity.TransactionCode, tlfEntity.Narration, tlfEntity.DateTime, tlfEntity.Acode, tlfEntity.Cheque, tlfEntity.CurrencyCode, tlfEntity.Rate.Value, tlfEntity.SettlementDate.Value, tlfEntity.TS, tlfEntity.AccountSign, tlfEntity.HomeAmount.Value, tlfEntity.HomeAmt.Value, tlfEntity.HomeOAmt.Value, tlfEntity.LocalAmount.Value, tlfEntity.LocalAmt.Value, tlfEntity.LocalOAmt.Value, tlfEntity.Description, tlfEntity.PaymentOrderNo));
              
                return TLFList;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000"; //Saving Error.
                throw new Exception(this.ServiceResult.MessageCode);
                //return null;
            }
        }
             #endregion
        private PFMORM00054 GetTLF(TLMDTO00001 entity)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.AccountNo = CoaSetupAccountNo;
            tlf.PaymentOrderNo = entity.ToAccountNo;
            tlf.Amount = entity.Amount;
            tlf.Acode = CoaSetupAccountNo;
            tlf.SettlementDate = this.SettlementDate;
            tlf.Channel = this.Channel;
            tlf.TransactionCode = this.TransactionCodeDebit;
            tlf.Status = this.TransactionTypeDebitStatus;
            tlf.Description = this.COAACName;
            tlf.Narration = "RE" + entity.RegisterNo + " " + entity.ToAccountNo;
            tlf.SourceBranchCode = entity.SourceBranchCode;
            tlf.Rate = this.Rate;
            tlf.CurrencyCode = entity.Currency;
            CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
            tlf.SourceCurrency = curdto.Cur;
            tlf.UserNo = entity.UpdatedUserId.Value.ToString();
            tlf.HomeAmt = entity.Amount * this.Rate;
            tlf.HomeOAmt = 0;
            tlf.LocalAmt = entity.Amount;
            tlf.LocalOAmt = 0;
            tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null) ? 0 : tlf.HomeOAmt.Value);
            tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceCode);//RE
            tlf.DeliverReturn = false;
            tlf.DateTime = entity.CreatedDate;
            tlf.Active = true;
            tlf.ERegisterNo = entity.RegisterNo;
            tlf.CreatedUserId = entity.UpdatedUserId.Value;
            tlf.CreatedDate = entity.CreatedDate;
            return tlf;
        }
        #endregion

        #region CustomerAcc

        public void SaveCustomerAcc(TLMDTO00001 Entity)
        {
            if (Entity != null)
            {
                this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), Entity.SourceBranchCode, true });

                if (this.SettlementDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    throw new Exception(CXMessage.ME00021); // Client Data Not Found.
                }
                this.Rate = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { Entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType), true,Entity.Currency, true }).Rate;
                Entity.SettlementDate = this.SettlementDate;
                this.VoucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, Entity.CreatedUserId, Entity.SourceBranchCode, new object[] { Entity.SettlementDate.Value.Day.ToString().PadLeft(2, '0'), Entity.SettlementDate.Value.Month.ToString().PadLeft(2, '0'), Entity.SettlementDate.Value.Year.ToString().Substring(2) });

                PFMORM00054 tlfData = new PFMORM00054();
                tlfData = this.BindTLFData(Entity);
                tlfData.Description = Entity.CreditACodeName;
                tlfData.Narration = "Remit Transfer " + Entity.BankName + " "+ Entity.ToName;
                if (tlfData != null)
                {
                    try
                    {
                        this.TLFDAO.Save(tlfData);
                        this.ServiceResult.ErrorOccurred = false;
                    }
                    catch
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90000";
                        throw new Exception(this.ServiceResult.MessageCode);
                    }

                    tlfData = this.BindTLFData(Entity);
                    tlfData.Acode = Entity.DebitACode;
                    tlfData.AccountNo = Entity.DebitACode;
                    tlfData.Description = Entity.DebitACodeName;
                    tlfData.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceDebitTransfer);//"EREMITDRTR"
                    tlfData.Narration = "E Remitt:";
                    tlfData.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucher);

                    tlfData.AccountSign = string.Empty;
                    tlfData.TransactionCode =  CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceDebitTransfer);

                    try
                    {
                        this.TLFDAO.Save(tlfData);
                        this.ServiceResult.ErrorOccurred = false;
                    }
                    catch
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90000";
                        throw new Exception(this.ServiceResult.MessageCode);
                    }
                }
            }
        }
        private PFMORM00054 BindTLFData(TLMDTO00001 getTLF)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = this.VoucherNo;
            tlf.AccountNo = getTLF.ToAccountNo;
            tlf.Acode = getTLF.CreditACode;
            tlf.Amount = getTLF.Amount;
            tlf.HomeAmt = getTLF.Amount * this.Rate;
            tlf.LocalAmt = getTLF.Amount;
            tlf.HomeOAmt = 0;
            tlf.LocalOAmt = 0;
            tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null) ? 0 : tlf.HomeOAmt.Value);
            tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);

            tlf.CurrencyCode = getTLF.Currency;
            tlf.SourceCurrency = getTLF.Currency;
            tlf.Description = getTLF.Description;
            tlf.DateTime = getTLF.CreatedDate;
            tlf.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucher);
            tlf.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.EncashmentRemittanceCreditTransfer); //"EREMITCRTR"
            tlf.AccountSign = getTLF.AccountSign;
            tlf.SourceBranchCode = getTLF.SourceBranchCode;
            CurrencyDTO curdto = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
            tlf.SourceCurrency = curdto.Cur;
            tlf.Rate = this.Rate;
            tlf.SettlementDate = getTLF.SettlementDate;
            tlf.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            tlf.ReferenceVoucherNo = getTLF.RegisterNo;
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.RemittanceCode);
            tlf.ERegisterNo = getTLF.RegisterNo;
            tlf.UserNo = getTLF.UpdatedUserId.Value.ToString();
            tlf.CreatedUserId = getTLF.UpdatedUserId.Value;
            tlf.CreatedDate = getTLF.CreatedDate;

            return tlf;
        }

        #endregion

    }
}
