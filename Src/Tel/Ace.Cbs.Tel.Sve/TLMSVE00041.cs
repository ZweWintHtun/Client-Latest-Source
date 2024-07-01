//----------------------------------------------------------------------
// <copyright file="TLMSVE00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-05</CreatedDate>
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
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Sve
{
    /// <summary>
    /// Center Table Deposit Approve Service
    /// </summary>
    public class TLMSVE00041 : BaseService, ITLMSVE00041
    {
        private ITLMDAO00015 cashDenoDAO;
        public ITLMDAO00015 CashDenoDAO
        {
            get;
            set;
        }
        public ICXSVE00002 CodeGenerator { get; set; }
        public TLMDTO00015 CashDenoDTO { get; set; }
        public TLMDTO00015 CashDTOs { get; set; }

        public int count;
        IList<TLMDTO00015> List { get; set; }
        public IList<TLMDTO00015> GetCenterTableDepositDTOList(string status, string receiptno, string sourcebr)
        {
            return CashDenoDAO.GetCenterTableDataDTOList(status, receiptno, sourcebr);
        }
        public List<TLMDTO00015> SaveDTO(IList<TLMDTO00015> cashdenolist, int userno)
        {
            List<TLMDTO00015> RegisterNoList = new List<TLMDTO00015>();
            bool IsPass = false;
            // int fromTypeIndex = cashDenoList.ToList().FindIndex(x => x.Status.Equals(paymentCashStatus));           
            this.List = cashdenolist;
            for (int i = 0; i < cashdenolist.Count; i++)
            {
                this.count += 1;
                TLMDTO00015 CashDTO = new TLMDTO00015();
                if (IsPass == false)
                {
                    CashDTO.ReceiptNo = null;
                    CashDTO.DenoEntryNo = null;
                    CashDTO.AccountType = cashdenolist[i].AccountType;
                    CashDTO.BranchCode = null;
                    CashDTO.Amount = cashdenolist[i].Amount;
                    CashDTO.SettlementDate = cashdenolist[i].SettlementDate;
                    CashDTO.SourceBranchCode = cashdenolist[i].SourceBranchCode;
                    CashDTO.Reverse = false;
                    CashDTO.FromType = "Receive Counter " + "(" + cashdenolist[i].CounterNo + ")";
                    CashDTO.AdjustAmount = 0;
                    CashDTO.DenoDetail = cashdenolist[i].DenoDetail;
                    CashDTO.DenoRefundDetail = string.Empty;
                    CashDTO.CounterNo = string.Empty;
                    CashDTO.UserNo = userno.ToString();
                    CashDTO.RegisterNo = cashdenolist[i].TlfEntryNo;
                    CashDTO.Currency = cashdenolist[i].Currency;
                    CashDTO.DenoRate = cashdenolist[i].DenoRate;
                    CashDTO.DenoRefundRate = string.Empty;
                    CashDTO.SettlementDate = cashdenolist[i].SettlementDate;
                    CashDTO.Rate = cashdenolist[i].Rate;
                    CashDTO.Status = cashdenolist[i].Status;
                    CashDTO.UniqueId = null;
                    CashDTO.CreatedUserId = cashdenolist[i].CreatedUserId;
                    CashDTO.CreatedDate = DateTime.Now;
                    CashDTO.Active = true;
                }
                if (IsPass == false)
                {
                    IsPass = this.SaveCashDeno(CashDTO).Reverse.Value;
                    CashDenoDAO.UpdateReceiptNoInCenterTableApprove(cashdenolist[i].TlfEntryNo, cashdenolist[i].CreatedUserId, CashDTO.SourceBranchCode);
                    if (IsPass == true)
                    {
                        i = cashdenolist.Count - 1;
                        RegisterNoList.Add(new TLMDTO00015(CashDTO.RegisterNo, IsPass));
                    }
                    else
                    {
                        RegisterNoList.Add(new TLMDTO00015(CashDTO.TlfEntryNo, IsPass));
                    }
                }
            }
            return RegisterNoList;
        }
        [Transaction(TransactionPropagation.Required)]
        private TLMDTO00015 SaveCashDeno(TLMDTO00015 CashDTO)
        {
            TLMDTO00015 spReturnDTO = new TLMDTO00015();
            try
            {
                //CashDTO.TlfEntryNo = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, CashDTO.CreatedUserId,CurrentUserEntity.BranchCode);
                CashDTO.TlfEntryNo = this.CodeGenerator.GetGenerateCode("VaultVoucher", string.Empty, CashDTO.CreatedUserId, CashDTO.SourceBranchCode);
                spReturnDTO.TlfEntryNo = CashDTO.TlfEntryNo;
                spReturnDTO = CashDenoDAO.SaveCashDenoData(CashDTO);
                if (spReturnDTO.ReturnValue == "0" && spReturnDTO.ErrorMessage == "THIS VOUCHER IS ALREADY APPROVE BY OTHER.")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI00132";
                    spReturnDTO.Reverse = true;
                    return spReturnDTO;
                }
                else if (spReturnDTO.ReturnValue == "0" && spReturnDTO.ErrorMessage == "ERROR OCCUR WHILE SAVING APPROVE AMOUNT.")
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = CXMessage.ME00059;
                    spReturnDTO.Reverse = true;
                    return spReturnDTO;
                }

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            spReturnDTO.Reverse = false;
            return spReturnDTO;

        }
    }
}