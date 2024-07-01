//----------------------------------------------------------------------
// <copyright file="TLMSVE00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nay Lin Ko Ko, Khin Phyu Lin</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using AutoMapper;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Sve
{
    public class TLMSVE00017:BaseService,ITLMSVE00017
    {
        public ITLMDAO00017 RDDAO { get; set; }
        public ITLMDAO00001 REDAO { get; set; }
        public IPFMDAO00054 TLFDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        private ICXDAO00006 codeCheckerDAO;
        private string RERegisterNo { get; set; }
        public ICXDAO00006 CodeCheckerDAO
        {
            get { return this.codeCheckerDAO; }
            set { this.codeCheckerDAO = value; }
        }
        public string IRPONo { get; set; }
        public string VoucherNo { get; set; }
        public string EBranchAlias { get; set; }
        private DateTime SettlementDate { get; set; }
        private int Id { get; set; }

        public IList<TLMDTO00017> SelectRegisterNoBySendDate(string order,string sourceBr, DateTime datetime)
        {
            return this.RDDAO.SelectRegisterNoBySendDate(order,sourceBr,datetime);
        }

        public TLMDTO00017 SelectDrawingInfoByRegisterNo(string registerNo)
        {
            return this.RDDAO.SelectDrawingInfoByRegisterNo(registerNo);
        }

         public IList<TLMDTO00001> SelectRemittanceEncashData(string sourceBranch)
        //public IList<TLMDTO00001> SelectRemittanceEncashData()
        {
            return this.REDAO.SelectPassingEncashRemittanceData(sourceBranch);
        }
        public void UpdateRDByRegisterNo(string registerNo)
        {
            //this.RDDAO.UpdateRDByRegisterNo(registerNo, DateTime.Now);
        }

        public bool CheckAccountNoinCLedger(string acctno)
        {
            return this.CodeCheckerDAO.CheckAccountNo(acctno);
        }

        public bool CheckRegisterNo(string registerNo)
        {
            return this.REDAO.CheckExistRegisterNo(registerNo);
        }
        
        public void UpdateREByRegisterNo(string registerNo,int updatedUserId)
        {
            this.REDAO.UpdateREByRegisterNo(registerNo, DateTime.Now, updatedUserId);
        }

        public decimal SelectTestKeyByRegisterNo(string registerNo)
        {
            return this.RDDAO.SelectTestKeyByRegisterNo(registerNo);
        }

        private void SelectBranchAlias(string branchcode)
        {
            BranchDTO bdto = CXCOM00011.Instance.GetScalarObject<BranchDTO>("Branch.Server.Alias.Select", new object[] { branchcode,1 });
            if (bdto == null)
                throw new Exception(CXMessage.ME00021);
            else
                this.EBranchAlias = bdto.BranchAlias;
        }

        private string GenerateRERegisterNo(string dbank, string ebank , string reg)
        {
            return reg.Replace(dbank, ebank);
        }

        private TLMORM00001 TransferRDtoRE(TLMDTO00017 rddto,string branchcode)
        {
            TLMORM00001 redto = new TLMORM00001();
            redto.RegisterNo = this.RERegisterNo;
            redto.EncashNo = "E0000";
            redto.Ebank = rddto.SourceBranchCode;
            redto.Br_Alias = this.EBranchAlias;
            redto.Type = rddto.Type;
            redto.Name = rddto.Name;
            redto.NRC = rddto.NRC;
            redto.ToAccountNo = rddto.ToAccountNo;
            redto.ToName = rddto.ToName;
            redto.ToNRC = rddto.ToNRC;
            redto.ToAddress = rddto.ToAddress;
            redto.TestKey = rddto.TestKey;
            redto.Amount = rddto.Amount;
            redto.Date_Time = rddto.DateTime;
            redto.IssueDate = null;
            redto.AccountSign = rddto.AccountSign;
            redto.UserNo = rddto.UserNo;
            redto.Budget = rddto.Budget;
            redto.PhoneNo = rddto.PhoneNo;
            redto.ToPhoneNo = rddto.ToPhoneNo;
            redto.SourceBranchCode = rddto.Dbank;// <---- need to change Current Source Branch
            redto.Currency = rddto.Currency;
            redto.SettlementDate = rddto.SettlementDate;
            redto.PrintStatus = 0;
            redto.Active = true;
            redto.CreatedDate = DateTime.Now;
            redto.CreatedUserId = rddto.CreatedUserId;

            return redto;
        }

        [Transaction(TransactionPropagation.Required)]
        public void PassingRDDataList(IList<TLMDTO00017> rdlist, string sourcebranch)
        {
            this.SelectBranchAlias(rdlist[0].SourceBranchCode);
            try
            {
                foreach (TLMDTO00017 item in rdlist)
                {
                    this.RERegisterNo = this.GenerateRERegisterNo(item.Dbank, item.SourceBranchCode, item.RegisterNo);
                    //if (this.CheckRegisterNo(this.RERegisterNo) || (!String.IsNullOrEmpty(item.ToAccountNo) && !this.CheckAccountNoinCLedger(item.ToAccountNo)))
                    //{
                    //    this.ServiceResult.ErrorOccurred = true;
                    //    break;
                    //}
                    //else
                    //{
                        this.RDDAO.UpdateRDByRegisterNo(item.RegisterNo, DateTime.Now, item.CreatedUserId, DateTime.Now);
                        this.REDAO.Save(this.TransferRDtoRE(item, sourcebranch));
                        this.ServiceResult.ErrorOccurred = false;
                   // }
                }
                //if (!this.ServiceResult.ErrorOccurred)
                //{
                //    foreach (TLMDTO00017 item in rdlist)
                //    {
                //        this.RDDAO.UpdateRDByRegisterNo(item.RegisterNo, DateTime.Now, item.CreatedUserId, DateTime.Now);
                //        this.REDAO.Save(this.TransferRDtoRE(item,sourcebranch));
                //    }
                //    this.ServiceResult.ErrorOccurred = false;
                //}
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                throw new Exception();
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string PassingRDData(TLMDTO00017 rd)
        {
            this.SelectBranchAlias(rd.SourceBranchCode);
            try
            {
                this.RERegisterNo = this.GenerateRERegisterNo(rd.Dbank, rd.SourceBranchCode, rd.RegisterNo);
                if (this.CheckRegisterNo(rd.RegisterNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    return " RegisterNo duplicated.";
                }
                if (!String.IsNullOrEmpty(rd.ToAccountNo)  && !this.CheckAccountNoinCLedger(rd.ToAccountNo))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    return " AccountNo Not Found.";
                }
                this.RDDAO.UpdateRDByRegisterNo(rd.RegisterNo, DateTime.Now, rd.CreatedUserId, DateTime.Now);
                this.REDAO.Save(this.TransferRDtoRE(rd, rd.SourceBranchCode)); 
                //this.REDAO.Save(this.TransferRDtoRE(rd,CurrentUserEntity.BranchCode)); //<---- Need to modify
                this.ServiceResult.ErrorOccurred = false;
                return " successed.";
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                //return " failed.";
                throw new Exception(" failed.");
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public string PassingREData(TLMDTO00001 redto)
        {
            this.SettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), redto.SourceBranchCode ,true});

            if (redto.POStatus)
                this.IRPONo = this.CodeGenerator.GetGenerateCode("PONO.IBLCODE", string.Empty, redto.CreatedUserId, redto.SourceBranchCode, new object[] { redto.SourceBranchCode, this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
                //this.IRPONo = this.CodeGenerator.GetGenerateCode("PONO.IBLCODE", string.Empty, redto.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { redto.SourceBranchCode, this.SettlementDate.Day.ToString().PadLeft(2, '0'), this.SettlementDate.Month.ToString().PadLeft(2, '0'), this.SettlementDate.Year.ToString().Substring(2) });
            else
                this.IRPONo = string.Empty;

            this.VoucherNo = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, redto.CreatedUserId, redto.SourceBranchCode, new object[] { redto.SourceBranchCode });
            //this.VoucherNo = this.CodeGenerator.GetGenerateCode("IBLVoucher", string.Empty, redto.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { redto.SourceBranchCode });
            this.Id = this.TLFDAO.SelectMaxId()+1;
            decimal rate = CXCOM00010.Instance.GetExchangeRate(redto.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
            string channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            string encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, redto.CreatedUserId, redto.SourceBranchCode, new object[] { });
            //string encashNo = this.CodeGenerator.GetGenerateCode("encashCode", string.Empty, redto.CreatedUserId, CurrentUserEntity.BranchCode, new object[] { });
            //string userno = CurrentUserEntity.CurrentUserID.ToString();
            string userno = redto.UserNo;
            CXServiceWrapper.Instance.Invoke<ICXSVE00010, bool>(x => x.EncashIBLPassing(this.Id,this.VoucherNo,redto.ToAccountNo,redto.Amount,redto.RegisterNo,this.IRPONo,redto.POStatus,encashNo,redto.UserNo,false,redto.Budget,"",redto.Ebank,redto.Currency,rate,redto.SourceBranchCode,this.SettlementDate,channel,redto.CreatedUserId));
            if (CXServiceWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXServiceWrapper.Instance.ServiceResult.MessageCode;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            else
            {
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI00139";
                return this.IRPONo;
            }
        }
    }
}
