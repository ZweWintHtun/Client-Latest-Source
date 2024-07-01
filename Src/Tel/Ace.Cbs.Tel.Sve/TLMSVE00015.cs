//----------------------------------------------------------------------
// <copyright file="TLMSVE00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>15/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00015 : BaseService , ITLMSVE00015
        
    {
        #region Properties
        
        public IList<TLMDTO00043> POIssueList { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public TLMDTO00043 POIssueData { get; set; }
        public IPFMDAO00054 TLFDao { get; set; }
        public ITLMDAO00016 PODao { get; set; }
        public ITLMDAO00009 DepoDenoDao { get; set; }
        public ITLMDAO00015 CashDenoDao { get; set; }

        private ITLMDAO00005 tranTypeDao;
        public ITLMDAO00005 TranTypeDao
        {
            get { return this.tranTypeDao; }
            set { this.tranTypeDao = value; }
        }

        #endregion
        
        #region DTO Properties
        private DateTime SettlementDate { get; set; }
        private decimal Rate { get; set; }
        private string Channel { get; set; }
        private string TransactionCode { get; set; }
        private string TransactionTypeStatus { get; set; }
        public string PONo { get; set; }
        public string VoucherNo { get; set; }
        public string GroupNo { get; set; }
        public string CoaSetupAccountNo { get; set; }
        public string CoaSetupIncomeAccountNo { get; set; }
        public string Description { get; set; }
        public string IncomeDescription { get; set; }
        public string Income { get; set; }
        #endregion

        #region Method

        public string GetVoucherNo(DateTime settlementDate , int CreatedUserID ,string branch)
        {
            return this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, CreatedUserID, branch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
        }

        public string GetGroupNo(DateTime settlementDate , int CreatedUserID,string branch)
        {
            return this.CodeGenerator.GetGenerateCode("GroupVoucher", string.Empty, CreatedUserID, branch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
        }

        public string GetPONo(DateTime settlementDate, int CreatedUserID,string branch)
        {
            return this.CodeGenerator.GetGenerateCode("PONO.Code", string.Empty, CreatedUserID, branch, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
        }

        public string GetCOAAccountName(string aCode , string sourceBranch , string currency)
        {
            ChargeOfAccountDTO dto = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { aCode, sourceBranch,true });
            if (dto == null)
                return null;
            else
                return dto.AccountName;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00054> SavePOIssueEntry(IList<TLMDTO00042> PoIssueList, bool isWithIncome, bool isMultiple, CXDTO00001 denostring)
        {
            try
            {
                this.Income = (isWithIncome) ? "Y" : null;
                this.CoaSetupAccountNo = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "PO", PoIssueList[0].Currency, PoIssueList[0].SourceBranch, true });
                this.CoaSetupIncomeAccountNo = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Income", PoIssueList[0].Currency, PoIssueList[0].SourceBranch, true });
                this.Description = this.GetCOAAccountName(this.CoaSetupAccountNo, PoIssueList[0].SourceBranch, PoIssueList[0].Currency);
                this.IncomeDescription = this.GetCOAAccountName(this.CoaSetupIncomeAccountNo, PoIssueList[0].SourceBranch, PoIssueList[0].Currency);
                this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PoIssueList[0].SourceBranch ,true});
                this.Rate = CXCOM00010.Instance.GetExchangeRate(PoIssueList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));
                this.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                this.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POIssueCash); //POICS
                TLMDTO00005 tranTypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { this.TransactionCode });
                if (this.Description == null || this.IncomeDescription == null || this.SettlementDate == null || this.Rate == 0 || tranTypeDTO == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00021; //Client Data Not Found.
                    return null;
                }
                this.TransactionTypeStatus = tranTypeDTO.Status; //CCV
                IList<PFMDTO00054> TLF_LIST = new List<PFMDTO00054>();
                string[] PONoArray = new string[PoIssueList.Count + 1];
                decimal NetAmount = 0;
                for (int i = 0; i < PoIssueList.Count; i++)
                {
                    NetAmount += PoIssueList[i].Amount + PoIssueList[i].Charges;
                    try
                    {
                        PONo = this.GetPONo(this.SettlementDate, PoIssueList[i].CreatedUserId, PoIssueList[0].SourceBranch);
                        VoucherNo = this.GetVoucherNo(this.SettlementDate, PoIssueList[i].CreatedUserId, PoIssueList[0].SourceBranch);
                        GroupNo = (isMultiple) ? ((i == 0) ? this.GetGroupNo(this.SettlementDate, PoIssueList[i].CreatedUserId, PoIssueList[0].SourceBranch) : GroupNo) : string.Empty;
                    }
                    catch
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90022";
                        throw new Exception(this.ServiceResult.MessageCode);
                        //return null;
                    }

                    PFMORM00054 tlfData = this.BindTLFData(PoIssueList[i], isMultiple);
                    this.TLFDao.Save(tlfData);
                    TLF_LIST.Add(new PFMDTO00054(tlfData.Eno, tlfData.CurrencyCode, tlfData.AccountNo, tlfData.Amount, tlfData.Status, tlfData.SettlementDate.Value, tlfData.Acode, tlfData.Rate.Value.ToString(), tlfData.PaymentOrderNo, tlfData.SourceBranchCode));
                    this.ServiceResult.ErrorOccurred = false;
                    if (isWithIncome)
                    {
                        tlfData = this.BindTLFData(PoIssueList[i],isMultiple);
                        tlfData.Eno = this.VoucherNo;
                        tlfData.Acode = this.CoaSetupIncomeAccountNo;
                        tlfData.AccountNo = this.CoaSetupIncomeAccountNo;
                        tlfData.Amount = PoIssueList[i].Charges;
                        tlfData.HomeAmount = PoIssueList[i].Charges;
                        tlfData.HomeAmt = PoIssueList[i].Charges;
                        tlfData.LocalAmount = PoIssueList[i].Charges;
                        tlfData.LocalAmt = PoIssueList[i].Charges;
                        tlfData.Description = this.IncomeDescription;
                        tlfData.Narration = tlfData.Narration.Replace("PO Issue For", "PO Charges For");

                        this.TLFDao.Save(tlfData);
                        TLF_LIST.Add(new PFMDTO00054(tlfData.Eno, tlfData.CurrencyCode, tlfData.AccountNo, tlfData.Amount, tlfData.Status, tlfData.SettlementDate.Value, tlfData.Acode, tlfData.Rate.Value.ToString(), tlfData.PaymentOrderNo, tlfData.SourceBranchCode));

                    }
                    TLMORM00016 poData = this.BindPOData(PoIssueList[i]);
                    this.PODao.Save(poData);
                    //TLF_LIST[i].PaymentOrderNo = poData.PONo;
                    if (isMultiple)
                    {
                        TLMORM00009 depoDenoData = this.BindDenoDepo(PoIssueList[i]);
                        this.DepoDenoDao.Save(depoDenoData);
                    }

                }
                TLMORM00015 cashDenoData = this.BindCashDeno(PoIssueList[0], denostring,isMultiple);
                if (isMultiple)
                {
                    TLF_LIST[0].ReferenceVoucherNo = cashDenoData.TlfEntryNo = this.GroupNo;
                }
                else
                {
                    cashDenoData.TlfEntryNo = this.VoucherNo;
                }
                cashDenoData.Amount = NetAmount;                  
                this.CashDenoDao.Save(cashDenoData);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00051";
                return TLF_LIST;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw new Exception(this.ServiceResult.MessageCode);
                //return null;
            }
        }
        #endregion

        #region TransferDTOtoORM

        private PFMORM00054 BindTLFData(TLMDTO00042 getTLF,bool isMulti)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDao.SelectMaxId() + 1;
            //tlf.Eno = (isMulti)?GroupNo:VoucherNo;
            tlf.Eno = this.VoucherNo;
            tlf.AccountNo = this.CoaSetupAccountNo;
            tlf.Amount = getTLF.Amount;
            tlf.Acode = this.CoaSetupAccountNo;
            tlf.HomeAmt = (tlf.Amount * this.Rate);
            tlf.HomeOAmt = 0;
            tlf.LocalAmt = tlf.Amount;
            tlf.LocalOAmt = 0;
            tlf.HomeAmount = tlf.HomeAmt + ((tlf.HomeOAmt == null) ? 0 : tlf.HomeOAmt.Value);
            tlf.LocalAmount = tlf.LocalAmt + ((tlf.LocalOAmt == null) ? 0 : tlf.LocalOAmt.Value);
            tlf.SourceCurrency = getTLF.Currency;
            tlf.CurrencyCode = getTLF.Currency;
            tlf.Description = this.Description;
            tlf.Narration = "PO Issue For " + "PO" + getTLF.SourceBranch + "/" + PONo;
            tlf.Description = this.Description;
            tlf.DateTime = DateTime.Now;
            tlf.Status = this.TransactionTypeStatus;
            tlf.TransactionCode = this.TransactionCode;
            tlf.UserNo = getTLF.CreatedUserId.ToString();
            tlf.SourceBranchCode = getTLF.SourceBranch;
            tlf.PaymentOrderNo = "PO" + getTLF.SourceBranch + "/" + PONo;
            tlf.Channel = this.Channel;
            tlf.ReferenceVoucherNo = tlf.PaymentOrderNo;
            tlf.ReferenceType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentOrderAccountNoName); //PO
            tlf.Rate = this.Rate;
            tlf.CreatedUserId = getTLF.CreatedUserId;
            tlf.CreatedDate = DateTime.Now;
            tlf.Active = true;
            tlf.SettlementDate = this.SettlementDate;

            return tlf;
        }

        private TLMORM00016 BindPOData(TLMDTO00042 getPO)
        {
            TLMORM00016 po = new TLMORM00016();

            po.PONo = "PO" + getPO.SourceBranch + "/" + this.PONo;
            po.Amount = getPO.Amount;
            po.AccountNo = null;//null;
            po.ADate = DateTime.Now;
            po.IDate = null;
            po.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashPaymentStatus);
            po.ToAccountNo = null;
            po.CheckNo = null;
            po.Income = this.Income;
            po.UserNo = getPO.UserNo;
            po.Charges = getPO.Charges;
            po.ACode = this.CoaSetupAccountNo;
            po.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            po.SourceBranchCode = getPO.SourceBranch;
            po.Currency = getPO.Currency;
            po.Rate = this.Rate;
            po.SettlementDate = this.SettlementDate;
            po.CreatedUserId = getPO.CreatedUserId;
            po.CreatedDate = DateTime.Now;
            po.AccountSign = null;
            po.Active = true;
            po.UserNo = Convert.ToString(getPO.CreatedUserId);

            return po;
        }


        private TLMORM00015 BindCashDeno(TLMDTO00042 getCashDeno, CXDTO00001 denostring,bool isMulti)
        {
            TLMORM00015 cashdeno = new TLMORM00015();

            //cashdeno.TlfEntryNo = VoucherNo;
            cashdeno.DenoEntryNo = null;
            if (isMulti)
                cashdeno.AccountType = null;
            else
                cashdeno.AccountType = "PO" + getCashDeno.SourceBranch + "/" + this.PONo;
            cashdeno.FromType = null;
            cashdeno.BranchCode = null;
            cashdeno.ReceiptNo = null;
            //cashdeno.Id = this.CashDenoDao.SelectMaxId() + 1;
            cashdeno.AdjustAmount = denostring.AdjustAmount;
            cashdeno.CashDate = DateTime.Now;
            cashdeno.DenoDetail = denostring.DenoString;
            cashdeno.DenoRefundDetail = denostring.RefundString;
            cashdeno.UserNo = getCashDeno.UserNo;
            cashdeno.CounterNo = denostring.CounterNo; //Receive Counter
            cashdeno.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus); //R
            cashdeno.Reverse = false;
            cashdeno.SourceBranchCode = getCashDeno.SourceBranch;
            cashdeno.Currency = getCashDeno.Currency;
            cashdeno.DenoRate = denostring.DenoRateString;
            cashdeno.DenoRefundRate = denostring.RefundRateString;
            cashdeno.SettlementDate = this.SettlementDate;
            cashdeno.AllDenoRate = null;
            cashdeno.Rate = this.Rate;
            cashdeno.UserNo = getCashDeno.CreatedUserId.ToString();
            cashdeno.CreatedUserId = getCashDeno.CreatedUserId;
            cashdeno.CreatedDate = DateTime.Now;
            cashdeno.Active = true;

            return cashdeno;
        }

        private TLMORM00009 BindDenoDepo(TLMDTO00042 getDenoDepo)
        {
            TLMORM00009 depodeno = new TLMORM00009();
            decimal zeroAmount = 0;
            //getDenoDepo.GroupNo = this.GroupNo;
            depodeno.GroupNo = this.GroupNo;
            depodeno.Tlf_Eno = this.VoucherNo;
            depodeno.AccountType = "PO" + getDenoDepo.SourceBranch + "/" + this.PONo;
            depodeno.Amount = getDenoDepo.Amount + getDenoDepo.Charges;
            depodeno.Reverse_Status = false;
            depodeno.Income = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            depodeno.Communicationcharge = Convert.ToDecimal(string.Format("{0:0.00}", zeroAmount));
            depodeno.SourceBranchCode = getDenoDepo.SourceBranch;
            depodeno.Currency = getDenoDepo.Currency;
            depodeno.CreatedDate = DateTime.Now;
            depodeno.CreatedUserId = getDenoDepo.CreatedUserId;
            depodeno.Active = true;

            return depodeno;
        }

        #endregion
    }
}