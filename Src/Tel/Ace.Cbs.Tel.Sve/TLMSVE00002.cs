//----------------------------------------------------------------------
// <copyright file="TLMSVE00002" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
namespace Ace.Cbs.Tel.Sve
{
   /// <summary>
   /// Encash Remit Registration Service
   /// </summary>
    public class TLMSVE00002 : BaseService, ITLMSVE00002
    {
        #region DAO
        public ITLMDAO00001 REDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00010 DataGenerateInSQL { get; set; }
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        #endregion

        #region Variables
        public string encashNo = string.Empty;
        public string voucherNo = string.Empty;
        public string irPONo = string.Empty;
        #endregion

        #region Helper Methods
        public bool CheckDuplicateRegisterNo(string registerNo)
        {
            return this.REDAO.CheckExistRegisterNo(registerNo);
        }
        public TLMORM00001 GetRE(TLMDTO00001 entity)
        {
            TLMORM00001 reDTO = new TLMORM00001();
            reDTO.RegisterNo = entity.RegisterNo;
            reDTO.IssueDate = entity.IssueDate;
            reDTO.Ebank = entity.Ebank;
            reDTO.Br_Alias = CXCOM00011.Instance.GetScalarObject<string>("Branch.Client.Alias.Select", new object[] { entity.Ebank, true });
            reDTO.Type = entity.Type;
            reDTO.Name = entity.Name;
            reDTO.NRC = entity.NRC;
            reDTO.ToAccountNo = entity.ToAccountNo;
            reDTO.ToName = entity.ToName;
            reDTO.ToNRC = entity.ToNRC;
            reDTO.ToAddress = entity.ToAddress;
            reDTO.Amount = entity.Amount;
            reDTO.AccountSign = entity.AccountSign;
            reDTO.UserNo = Convert.ToString(entity.CreatedUserId);
            reDTO.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            reDTO.PhoneNo = entity.PhoneNo;
            reDTO.ToPhoneNo = entity.ToPhoneNo;
            reDTO.SourceBranchCode = entity.SourceBranchCode;
            reDTO.Currency = entity.Currency;
            reDTO.Active = true;
            reDTO.CreatedDate = DateTime.Now;
            reDTO.CreatedUserId = entity.CreatedUserId;
            return reDTO;
        }
        public  System.Nullable<DateTime> SettlementDate(string sourceBranch)
        {
            try
            {
                return CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), sourceBranch ,true });
            }

            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                return null;
            }            
    }
        public string GetEncashCode(int updateduserid,string sourceBranch)
        {
            try
            {
                encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, updateduserid, sourceBranch, new object[] { });
                return encashNo;
            }

            catch(Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
                //return string.Empty;
            }            
        }

        public TLMDTO00001 PrintPOData(string registerNo,string sourceBranch)
        {
            TLMDTO00001 printPO = this.REDAO.SelectREForPrinting(registerNo, sourceBranch);
            return printPO;
        }

        #endregion

        #region Main Methods
        [Transaction(TransactionPropagation.Required)]
        public string SaveRE(TLMDTO00001 reDTO)
        {
            try
            {
                TLMORM00001 re = this.GetRE(reDTO);
                Nullable<DateTime> sys001 = this.SettlementDate(re.SourceBranchCode);
                int updatedUserId = reDTO.CreatedUserId;
                encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, updatedUserId, reDTO.SourceBranchCode , new object[] { });
                re.EncashNo = encashNo;
                re.EncashNo = this.GetEncashCode(reDTO.CreatedUserId, re.SourceBranchCode);
                re.SettlementDate = sys001;
                re.Date_Time = DateTime.Now;
                re.PrintStatus = 0;
                if (string.IsNullOrEmpty(re.ToAccountNo))
                {
                    re.ToAccountNo = irPONo;
                }               
                REDAO.Save(re);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
                return encashNo;
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
                //return string.Empty;
            }           
        }

        [Transaction(TransactionPropagation.Required)]
        public string SaveREandPO(TLMDTO00001 reDTO)
        {
            try
            {
             //reDTO.IssueDate = DateTime.Now;
             TLMDTO00001 encashDTO = reDTO;
             decimal rate = CXCOM00010.Instance.GetExchangeRate(reDTO.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
             Nullable<DateTime> sys001 = this.SettlementDate(reDTO.SourceBranchCode);
             string day = sys001.Value.Day.ToString().PadLeft(2, '0');
             string month = sys001.Value.Month.ToString().PadLeft(2, '0');
             string year = sys001.Value.Year.ToString().Substring(2);
             int updatedUserId = reDTO.CreatedUserId;
             irPONo = this.CodeGenerator.GetGenerateCode("PONO.IBLCODE", string.Empty, updatedUserId, reDTO.SourceBranchCode, new object[] { reDTO.SourceBranchCode, sys001.Value.Day.ToString().PadLeft(2, '0'), sys001.Value.Month.ToString().PadLeft(2, '0'), sys001.Value.Year.ToString().Substring(2) });
             reDTO.IssueDate = DateTime.Now;
             string encash = this.SaveRE(reDTO);
             voucherNo = this.CodeGenerator.GetGenerateCode("NormalVoucher", string.Empty, updatedUserId,reDTO.SourceBranchCode, new object[] { day, month, year });
             encashDTO.ENO = voucherNo;            

                //irPONo = "IR" + reDTO.Ebank + "/" + this.CodeGenerator.GetGenerateCode("Encash.Entry.IRVoucherNo", string.Empty, updatedUserId, CurrentUserEntity.BranchCode, new object[] { day, month, year });
                encashDTO.PONo = irPONo;
              
                //encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, updatedUserId, new object[] { day });
                encashDTO.EncashNo = encash;

                encashDTO.UserNo = Convert.ToString(reDTO.CreatedUserId);
                encashDTO.SettlementDate = sys001;
                encashDTO.SourceBranchCode = reDTO.SourceBranchCode;
                encashDTO.CreatedUserId = reDTO.CreatedUserId;
                encashDTO.HomeExchangeRate = rate;

                
                    string remitbr = CXCOM00011.Instance.GetScalarObject<String>("GetIRPOAccount", new object[] { encashDTO.Ebank, encashDTO.Currency, reDTO.SourceBranchCode });

                    //if (string.IsNullOrEmpty(remitbr))
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    this.ServiceResult.MessageCode = CXMessage.MV00120;
                    //    return string.Empty;
                    //}
                    //else
                    //{
                        encashDTO.AccountNo = remitbr;

                        CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.EncashVou(encashDTO));
                   // }
                }

                catch(Exception)
                {
                  
                    throw new Exception(CXMessage.MV00120);
                }

                if (CXServiceWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                    throw new Exception(this.ServiceResult.MessageCode);
                    //return string.Empty;
                }

                else
                {
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI00051";//Saving Successful.
                    return irPONo;
                }
            
           
          
        }
        #endregion        
    }
}

      

        
       





        



   
