//----------------------------------------------------------------------
// <copyright file="LOMSVE00015" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>14.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00015 : BaseService, ILOMSVE00015
    {
        public ITCMDAO00003 NplIntDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ITLMDAO00018 LoansDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
       

        [Transaction(TransactionPropagation.Required)]
        public IList<TCMDTO00003> GetNPLIntList(string loanNo, string aType, string sourceBr)
        {
            IList<string> aTypeList = aType.Split(',').ToList();
            IList<TCMDTO00003> NPLIntList = NplIntDAO.GetNPLIntList(loanNo, aTypeList, sourceBr);
            return NPLIntList;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool ReleaseNPLCase(IList<TCMDTO00003> nplList , bool isVoucher,string currency,string loanAType,string channel,string sourceBr,int workstationId, string nplReleaseUser, int updatedUserID)
        {
            try
            {
                if (isVoucher)
                {
                    this.SaveProcessInTlfTable(nplList,currency,loanAType,channel,sourceBr,workstationId, nplReleaseUser, updatedUserID);
                }
                //TLFDAO.UpdateTlfForNPLRelease(nplList[0].LNo, eno, sourceBr, updatedUserID);
                LoansDAO.UpdateLoansForNPLCase(nplList[0].LNo, nplReleaseUser, sourceBr, updatedUserID, true);
                NplIntDAO.UpdateNPLIntForNPLRelease(nplList[0].LNo, sourceBr, updatedUserID);
                return true;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                return false;
                throw new Exception(ex.Message);
            }

        }

        public void SaveProcessInTlfTable(IList<TCMDTO00003> nplList,string currency,string loanAType,string channel, string sourceBr,int workstationId, string nplReleaseUser, int updatedUserID)
        {
            DateTime settlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBr);
            string voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserID, sourceBr, new object[] { settlementDate.Day.ToString().PadLeft(2, '0'), settlementDate.Month.ToString().PadLeft(2, '0'), settlementDate.Year.ToString().Substring(2) });
           
            /**Calculate Service Charges**/
            IList<string> atypeList = new List<string>();
            atypeList.Clear();
            atypeList.Add("S");
            //IList<TCMDTO00003> ServiceChargesInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, "'S'", sourceBr);           
            IList<TCMDTO00003> ServiceChargesInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
            if (ServiceChargesInfo.Count > 0)
            {
                if (ServiceChargesInfo[0].Amount > 0)
                {
                    //control = ServiceChargesInfo[0].Type;   //Acode (eg. IF0010)                    
                    this.CheckParameterAndSaveTlf(voucherNo, settlementDate, ServiceChargesInfo[0].Type, ServiceChargesInfo[0].LNo, ServiceChargesInfo[0].Amount, currency, ServiceChargesInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                }
            }

            #region to confirm
            /**'Loan Interest Charges**/
            //if (nplList[0].AType == "LOANS")
            if (loanAType == "LOANS")
            {
                atypeList.Clear();
                atypeList.Add("L");
                IList<TCMDTO00003> LoanInterestInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
                if (LoanInterestInfo.Count > 0)
                {
                    if (LoanInterestInfo[0].Amount > 0)
                    {
                        this.CheckParameterAndSaveTlf(voucherNo, settlementDate, LoanInterestInfo[0].Type, LoanInterestInfo[0].LNo, LoanInterestInfo[0].Amount, currency, LoanInterestInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                    }
                }
            }

            //if (nplList[0].AType == "OVERDRAFT")
            if (loanAType == "OVERDRAFT")
            {
                /**OD Interest Charges**/
                atypeList.Clear();
                atypeList.Add("O");
                IList<TCMDTO00003> ODInterestInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
                if (ODInterestInfo.Count > 0)
                {
                    if (ODInterestInfo[0].Amount > 0)
                    {
                        this.CheckParameterAndSaveTlf(voucherNo, settlementDate, ODInterestInfo[0].Type, ODInterestInfo[0].LNo, ODInterestInfo[0].Amount, currency, ODInterestInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                    }
                }
                /**Commiment Charges**/    //LateFees,PanelFees               
                atypeList.Clear();
                atypeList.Add("C");
                IList<TCMDTO00003> ODCommimentChargesInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
                if (ODCommimentChargesInfo.Count > 0)
                {
                    if (ODCommimentChargesInfo[0].Amount > 0)
                    {
                        this.CheckParameterAndSaveTlf(voucherNo, settlementDate, ODCommimentChargesInfo[0].Type, ODCommimentChargesInfo[0].LNo, ODCommimentChargesInfo[0].Amount, currency, ODCommimentChargesInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                    }
                }
            }
            //if (nplList[0].AType == "TOD")
            if (loanAType == "TOD")
            {
                /**TOD Interest Charges**/
                atypeList.Clear();
                atypeList.Add("T");
                IList<TCMDTO00003> TODInterestInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
                if (TODInterestInfo.Count > 0)
                {
                    if (TODInterestInfo[0].Amount > 0)
                    {
                        this.CheckParameterAndSaveTlf(voucherNo, settlementDate, TODInterestInfo[0].Type, TODInterestInfo[0].LNo, TODInterestInfo[0].Amount, currency, TODInterestInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                    }
                }
                /**Commiment Charges**/
                //LateFees,PanelFees
                atypeList.Clear();
                atypeList.Add("C");
                IList<TCMDTO00003> TODCommimentChargesInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);
                if (TODCommimentChargesInfo.Count > 0)
                {
                    if (TODCommimentChargesInfo[0].Amount > 0)
                    {
                        this.CheckParameterAndSaveTlf(voucherNo, settlementDate, TODCommimentChargesInfo[0].Type, TODCommimentChargesInfo[0].LNo, TODInterestInfo[0].Amount, currency, TODCommimentChargesInfo[0].Narration, "TRCREDIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);
                    }
                }
            }
            #endregion

            /**LumpSum**/     //DebitVoucher            
            atypeList.Clear();
            atypeList = "L,O,C,S,T".Split(',').ToList();           
            string narration = "Expired Loan/OD Interest";   //TRDEBIT
            IList<TCMDTO00003> NplDebitInfo = NplIntDAO.GetNPLIntList(nplList[0].LNo, atypeList, sourceBr);            
            if (NplDebitInfo[0].Amount > 0)
            {
                this.CheckParameterAndSaveTlf(voucherNo, settlementDate, nplList[0].ACode, nplList[0].LNo, NplDebitInfo[0].Amount, currency, narration, "TRDEBIT", "baJournal", channel, sourceBr, workstationId, nplReleaseUser, updatedUserID);               
            }   
        }

        [Transaction(TransactionPropagation.Required)]
        public void CheckParameterAndSaveTlf(string voucherNo, DateTime settlementDate,string aCode,string lno,decimal amount, string currency, string narration, string transaction, string ledgerType, string channel, string sourceBr, int workstationId, string nplReleaseUser, int updatedUserID)
        {
            //**Ledger_Type Parameter Checking
            //'Select Status,PBReference From TranType Where TranCode = ''TRDEBIT''
            TLMDTO00005 TranTypeDto = this.GetTranType(transaction);   //TRCREDIT || TRDEBIT
            decimal exchangeRate = CXCOM00010.Instance.GetExchangeRate(currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType));                        

            PFMDTO00054 tlfdto = new PFMDTO00054();
            tlfdto.Eno = voucherNo;
            tlfdto.AccountNo = aCode;
            tlfdto.SettlementDate = settlementDate;
            tlfdto.Acode = aCode;
            tlfdto.Amount = amount;
            tlfdto.HomeAmount = amount*exchangeRate;
            tlfdto.HomeAmt = amount * exchangeRate;
            tlfdto.LocalAmount = amount;
            tlfdto.LocalAmt = amount;            
            tlfdto.Lno = lno;
            tlfdto.Description = this.GetCOAAccountName(aCode, sourceBr, currency);
            tlfdto.Narration = narration;
            tlfdto.Status = TranTypeDto.Status;   //TCV || TDV
            tlfdto.TransactionCode = TranTypeDto.TransactionCode;   //TRCREDIT || TRDEBIT                              
            tlfdto.SourceCurrency = currency;
            tlfdto.Rate = exchangeRate;
            tlfdto.SourceBranchCode = sourceBr;
            tlfdto.Channel = channel;  //CBS
            PFMORM00054 tlfORM = this.ConvertToTLFORM(tlfdto);
            this.TLFDAO.Save(tlfORM);
        }

        //public bool Check_Update()
        //{
        //    return true;
        //}

        public PFMORM00054 ConvertToTLFORM(PFMDTO00054 tlfdto)
        {
            PFMORM00054 tlf = new PFMORM00054();
            tlf.Id = this.TLFDAO.SelectMaxId() + 1;
            tlf.Eno = tlfdto.Eno;
            tlf.AccountNo = tlfdto.AccountNo;
            tlf.SettlementDate = tlfdto.SettlementDate;
            tlf.Acode = tlfdto.Acode;
            tlf.Amount = tlfdto.Amount;
            tlf.HomeAmount = tlfdto.Amount;
            tlf.HomeAmt = tlfdto.Amount;
            tlf.HomeOAmt = tlfdto.HomeOAmt;
            tlf.LocalAmount = tlfdto.LocalAmount;
            tlf.LocalAmt = tlfdto.LocalAmt;
            tlf.LocalOAmt = tlfdto.LocalOAmt;
            tlf.Lno = tlfdto.Lno;
            tlf.Description = tlfdto.Description;
            tlf.Narration = tlfdto.Narration;
            tlf.Cheque = tlfdto.Cheque;
            tlf.DateTime = DateTime.Now;
            tlf.Status = tlfdto.Status;
            tlf.TransactionCode = tlfdto.TransactionCode;
            tlf.AccountSign = tlfdto.AccountSign;
            tlf.UserNo = tlfdto.UserNo;
            tlf.SourceCurrency = tlf.SourceCurrency;
            tlf.Rate = tlfdto.Rate;
            tlf.SourceBranchCode = tlfdto.SourceBranchCode;
            tlf.Channel = tlfdto.Channel;
            tlf.ReferenceType = tlfdto.ReferenceType;
            tlf.CreatedDate = DateTime.Now;
            tlf.CreatedUserId = tlfdto.CreatedUserId;
            return tlf;
        }

        public string GetCOAAccountName(string aCode, string sourceBranch, string currency)
        {
            ChargeOfAccountDTO dto = CXCOM00011.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Server.SelectAccountName", new object[] { aCode, sourceBranch, true });
            if (dto == null)
                return null;
            else
                return dto.AccountName;
        }

        public TLMDTO00005 GetTranType(string tranCode)
        {
            TLMDTO00005 trantypeDTO = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode });// WITHDRAW(status)

            if (trantypeDTO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.ME00021; // Client Data Not Found.
                return null;
            }
            else
            {
                return trantypeDTO;
            }
        }
    }
}
