using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
//using AutoMapper;
//using NHibernate.Criterion;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Loan.Sve
{
    public class LOMSVE00027 : BaseService, ILOMSVE00027
    {
        public ILOMDAO00013 LegalDAO { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ILOMDAO00022 LrpLegalDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
       // public IList<PFMDTO00072> cusDto = new List<PFMDTO00072>();
     //   public IList<LOMDTO00013> legalDto = new List<LOMDTO00013>();
        public IList<LOMDTO00013> CheckLegalLoanNo(string loanNo, string sourceBr)
        {
            IList<LOMDTO00013> legalList = LegalDAO.SelectLegalInfoByCloseDateNull(loanNo, sourceBr);
            if (legalList == null || legalList.Count < 1)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV90055; //Invalid Loan No.
                return null;
            }
            else
            {
                if (legalList[0].CloseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90057; //Loans No. Already Closed!
                    return null;
                }
                else if (legalList[0].AcceptDate == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90077; //Loans No. Already Accepted!
                    return null;
                }
                else if (legalList[0].ReleaseDate != null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90074; //This legal case loan is already released.
                    return null;
                }
                else if (legalList[0].AcType != "LOANS")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.MV90078; //Legal Loans type only...
                    return null;
                }
                else
                {
                    IList<PFMDTO00072> CustomerInfo = new List<PFMDTO00072>();
                    IList<LOMDTO00013> legalDto = new List<LOMDTO00013>();
                    CustomerInfo = this.CodeChecker.GetCurrentAccountInfoByAccountNumber(legalList[0].AcctNo);
                    if (CustomerInfo.Count > 0)
                    {
                        legalList[0].NameList = new string[CustomerInfo.Count()]; 
                        for (int i = 0; i < CustomerInfo.Count; i++)
                        {
                            legalList[0].NameList[i] = CustomerInfo[i].CustomerName;                            
                        }
                        legalList[0].Bal = CustomerInfo[0].CurrentBalance;
                    }                    
                }
                return legalList;
            }            
        }

        public IList<PFMDTO00072> GetCustNames(string AccNo)
        {
            IList<PFMDTO00072> CustomerInfo = new List<PFMDTO00072>();
            CustomerInfo = this.CodeChecker.GetCurrentAccountInfoByAccountNumber(AccNo);
            return CustomerInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public void SaveLoanRepayment(IList<LOMDTO00013> legalList,decimal currentBalance,string currency,string channel, string sourceBr, int workStationId, string currentUserName, int currentUserId)
        {
            try
            {
                DateTime NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), sourceBr);
                decimal HomeExchangeRate = CXCOM00010.Instance.GetExchangeRate(currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
                string voucherNumber = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, currentUserId, sourceBr, new object[] { NextSettlementDate.Day.ToString().PadLeft(2, '0'), NextSettlementDate.Month.ToString().PadLeft(2, '0'), NextSettlementDate.Year.ToString().Substring(2) });
                decimal cledgerCBal = 0;

                //Insert Into LrpLegal Table
                this.ConvertToLrpLegalORM(legalList, currency, sourceBr, voucherNumber, workStationId, currentUserId);

                //Update Cledger Table
                if(legalList[1].Name == "Cr")
                    cledgerCBal = currentBalance + legalList[0].SAmt.Value; 
                 
                this.CledgerDAO.UpdateCledgerCBalByAccountNo(legalList[1].AcctNo, cledgerCBal, sourceBr, workStationId, currentUserId);

                //Insert Into Tlf Table           
                this.ConvertToTLFORM(legalList, NextSettlementDate, HomeExchangeRate, voucherNumber, currency, channel, sourceBr, workStationId, currentUserId);
                //this.TLFDAO.Save(this.ConvertToTLFORM(legaldto, NextSettlementDate, HomeExchangeRate, voucherNumber, currency, channel, sourceBr,workStationId, currentUserId));

                //Update Legal Table
                this.LegalDAO.UpateLegalForLoanRepay(cledgerCBal, voucherNumber, legalList[1].AcctNo, legalList[0].Lno, sourceBr, currentUserId);

                this.ServiceResult.ErrorOccurred = false;
                return;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;                
                throw new Exception(ex.Message);
            }
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
        
         public void ConvertToLrpLegalORM(IList<LOMDTO00013> legalList,string currency,string sourceBr,string voucherNumber,int workstationId, int currentUserId)
         {
             LOMORM00022 LrpLegalORM = new LOMORM00022();
            // LrpLegalORM.Id = LrpLegalDAO.SelectMaxId() + 1;
             //LrpLegalORM.RepayNo = legalList[0].RepayNo;
             LrpLegalORM.RepayNo = voucherNumber;
             LrpLegalORM.Lno = legalList[0].Lno;
             LrpLegalORM.AcctNo = legalList[1].AcctNo;
             LrpLegalORM.Date_Time = DateTime.Now;
             LrpLegalORM.Amount = legalList[0].SAmt.Value;
             LrpLegalORM.UserNo = workstationId.ToString();
             LrpLegalORM.DrAccountNo = legalList[0].DrAccountNo;
             LrpLegalORM.AType = legalList[0].AType;
             LrpLegalORM.SourceBr = sourceBr;
             LrpLegalORM.Cur = currency;
             LrpLegalORM.Active = true;
             LrpLegalORM.CreatedDate = DateTime.Now;
             LrpLegalORM.CreatedUserId = currentUserId;             
             LrpLegalDAO.Save(LrpLegalORM);
         }
                 
         public void ConvertToTLFORM(IList<LOMDTO00013> legalList, DateTime nextSettlementDate, decimal homeExchangeRate, string voucherNumber, string currency, string channel, string sourceBr, int workstationId, int currentUserId)
         {
             //Insert Into Tlf Table
             foreach (LOMDTO00013 legalDTO in legalList)
             {
                 PFMORM00054 tlfORM = new PFMORM00054();
                 tlfORM.Id = TLFDAO.SelectMaxId() + 1;
                 tlfORM.Eno = voucherNumber;
                 if (legalDTO.Name == "Dr")
                 {
                     string drcode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);//TRDEBIT
                     TLMDTO00005 drtransactionTypeDTO = this.GetTranType(drcode);//TDV
                     tlfORM.AccountNo = legalDTO.DrAccountNo;
                     tlfORM.Acode = legalDTO.DrAccountNo;
                     tlfORM.Status = drtransactionTypeDTO.Status;                     
                     tlfORM.ReferenceType= drtransactionTypeDTO.PBReference;
                 }
                 else
                 {
                     string crcode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);//TRCREDIT
                     TLMDTO00005 crtransactionTypeDTO = this.GetTranType(crcode);//TCV
                     tlfORM.AccountNo = legalDTO.AcctNo;
                     tlfORM.Acode = legalDTO.DrAccountNo;
                     tlfORM.Status = crtransactionTypeDTO.Status;
                     tlfORM.ReferenceType = crtransactionTypeDTO.PBReference;
                     tlfORM.AccountSign = legalDTO.AccountSign;
                 }
                 tlfORM.SettlementDate = nextSettlementDate;
                 tlfORM.Amount = legalDTO.SAmt.Value;
                 tlfORM.HomeAmount = legalDTO.SAmt * homeExchangeRate;
                 tlfORM.HomeAmt = legalDTO.SAmt * homeExchangeRate;
                 tlfORM.LocalAmount = legalDTO.SAmt;
                 tlfORM.LocalAmt = legalDTO.SAmt;
                 tlfORM.Lno = legalDTO.Lno;
                 tlfORM.Description = legalDTO.LoansDesp;
                 tlfORM.DateTime = DateTime.Now;
                 tlfORM.SourceCurrency = currency;
                 tlfORM.Rate = homeExchangeRate;
                 tlfORM.UserNo = workstationId.ToString();
                 tlfORM.SourceBranchCode = sourceBr;
                 tlfORM.Channel = channel;  //CBS                    
                 tlfORM.Active = true;
                 tlfORM.CreatedDate = DateTime.Now;
                 tlfORM.CreatedUserId = currentUserId;
                 this.TLFDAO.Save(tlfORM);
             }
         }

         //[Transaction()]
         //public PFMORM00054 ConvertToTLFORM(LOMDTO00013 legalDTO, DateTime nextSettlementDate, decimal homeExchangeRate, string voucherNumber, string currency, string channel, string sourceBr, int workstationId, int currentUserId)
         //{
         //    //Insert Into Tlf Table
            
         //        PFMORM00054 tlfORM = new PFMORM00054();
         //        //tlfORM.Id = this.TLFDAO.SelectMaxId() + 1;
         //        tlfORM.Eno = voucherNumber;
         //        if (legalDTO.Name == "Dr")
         //        {
         //            string drcode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);//TRDEBIT
         //            TLMDTO00005 drtransactionTypeDTO = this.GetTranType(drcode);//TDV

         //            tlfORM.AccountNo = legalDTO.DrAccountNo;
         //            tlfORM.Acode = legalDTO.DrAccountNo;
         //            tlfORM.Status = drtransactionTypeDTO.Status;
         //        }
         //        else
         //        {
         //            string crcode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);//TRCREDIT
         //            TLMDTO00005 crtransactionTypeDTO = this.GetTranType(crcode);//TCV
         //            tlfORM.AccountNo = legalDTO.AcctNo;
         //            tlfORM.Acode = legalDTO.DrAccountNo;
         //            tlfORM.Status = crtransactionTypeDTO.Status;
         //            tlfORM.AccountSign = legalDTO.AccountSign;
         //        }
         //        tlfORM.SettlementDate = nextSettlementDate;
         //        tlfORM.Amount = legalDTO.SAmt.Value;
         //        tlfORM.HomeAmount = legalDTO.SAmt * homeExchangeRate;
         //        tlfORM.HomeAmt = legalDTO.SAmt * homeExchangeRate;
         //        tlfORM.LocalAmount = legalDTO.SAmt;
         //        tlfORM.LocalAmt = legalDTO.SAmt;
         //        tlfORM.Lno = legalDTO.Lno;
         //        tlfORM.Description = legalDTO.LoansDesp;
         //        tlfORM.DateTime = DateTime.Now;
         //        tlfORM.SourceCurrency = currency;
         //        tlfORM.Rate = homeExchangeRate;
         //        tlfORM.UserNo = workstationId.ToString();
         //        tlfORM.SourceBranchCode = sourceBr;
         //        tlfORM.Channel = channel;  //CBS   
         //        //tlfORM.ReferenceType=;
         //        tlfORM.Active = true;
         //        tlfORM.CreatedDate = DateTime.Now;
         //        tlfORM.CreatedUserId = currentUserId;
         //        return tlfORM;             
         //}
    }
}

