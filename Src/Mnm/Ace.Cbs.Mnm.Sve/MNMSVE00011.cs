//----------------------------------------------------------------------
// <copyright file="MNMSVE00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Cx.Ser.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Sve
{
    /// <summary>
    /// Deliver and Receipt Reverse
    /// Service
    /// </summary>
    public class MNMSVE00011 : BaseService, IMNMSVE00011
    {
        #region "Properties"

        public IPFMDAO00054 TlfDAO { get; set; }
        public ITLMDAO00040 bcodeDAO { get; set; }
        public ICXDAO00006 CxDAO { get; set; }
        public IPFMDAO00028 CledgerDAO { get; set; }
        public IPFMDAO00023 FLedgerDAO { get; set; }
        public ICXSVE00002 CodeGenerator { get; set; }
        public ICXSVE00006 ReversalTlf { get; set; }
        public IPFMDAO00024 CoaDAO { get; set; }
        public IList<PFMDTO00001> cxdto = new List<PFMDTO00001>();
        public PFMDTO00028 cledgerAccount = new PFMDTO00028();
        public PFMDTO00023 fledgerAccount = new PFMDTO00023();
        private ChargeOfAccountDTO coaDTO;

        public string acsign = string.Empty;
        private string sourceBr = string.Empty;

        #endregion

        #region "Main Methods"

        [Transaction(TransactionPropagation.Required)]
        public string[] Save_DeliverandReceipt(PFMDTO00054 entity)
        {
            string[] ReturnValue = new string[2];
            string deliverVouno = string.Empty;
            string receiptVouno = string.Empty;

            DateTime sys001 = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), entity.SourceBranchCode ,true});

            string day = sys001.Day.ToString().PadLeft(2, '0');
            string month = sys001.Month.ToString().PadLeft(2, '0');
            string year = sys001.Year.ToString().Substring(2);
            int updatedUserId = entity.CreatedUserId;

            TLMDTO00005 reversaltrancodedto = this.CxDAO.SelectByTranCode(this.CxDAO.SelectByTranCode(entity.TransactionCode).RVReference);
            ReturnValue[0] = reversaltrancodedto.Status;
            if (entity.TransactionStatus == "Receipt Reverse")
            {
                // for receipt reversal "start with D"
                receiptVouno = this.CodeGenerator.GetGenerateCode("DeliverPayInSlip", string.Empty, updatedUserId, entity.SourceBranchCode, new object[] { day, month, year });

                //Receipt Reversal
                this.ReversalTlf.ReversalProcessForReceipt(entity.Eno, receiptVouno, null, entity.SourceBranchCode,entity.Cheque , DateTime.Now, entity.SourceBranchCode, updatedUserId, new TLMDTO00015(), entity.TransactionCode ,true);
                ReturnValue[1] = receiptVouno;
                return ReturnValue;
            }
            else
            {   // for deliver reversal "start with R"
                deliverVouno = this.CodeGenerator.GetGenerateCode("PO.Receipt.Code", string.Empty, updatedUserId, entity.SourceBranchCode, new object[] { day, month, year });

                if (entity.DeliverReturn == true)
                {
                    //Deliver Reversal ( Update Cledger if checkbox on )
                    //this.ReversalTlf.ReversalProcess(entity.Eno, deliverVouno, null, entity.SourceBranchCode, DateTime.Now, CurrentUserEntity.BranchCode, updatedUserId, new TLMDTO00015(), string.Empty, false);
                    this.ReversalTlf.ReversalProcess(entity.Eno, deliverVouno, null, entity.SourceBranchCode, DateTime.Now, entity.SourceBranchCode, updatedUserId, new TLMDTO00015(), string.Empty, false);
                }
                else
                {
                    //Deliver Reversal ( Update Cledger if checkbox off)
                    //this.ReversalTlf.ReversalProcess(entity.Eno, deliverVouno, null, entity.SourceBranchCode, DateTime.Now, CurrentUserEntity.BranchCode, updatedUserId, new TLMDTO00015(), string.Empty , true);
                    this.ReversalTlf.ReversalProcess(entity.Eno, deliverVouno, null, entity.SourceBranchCode, DateTime.Now, entity.SourceBranchCode, updatedUserId, new TLMDTO00015(), string.Empty, true);
                }
                ReturnValue[1] = deliverVouno;
                return ReturnValue;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(PFMDTO00054 entity)
        {
            try
            {
                entity.UpdatedDate = DateTime.Now;
                this.TlfDAO.UpdateTlf(entity.Eno, entity.Amount, entity.HomeAmount.Value, entity.OtherBank, entity.OtherBankChq,
                    "Clearing Deliver " + entity.OtherBankChq,
                    Convert.ToInt32(entity.UpdatedUserId.ToString()), Convert.ToDateTime(entity.UpdatedDate));
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete_DeliverEdit(PFMDTO00054 entity)
        {
            try
            {
                PFMDTO00054 tlfentity = new PFMDTO00054();
                tlfentity = entity;
                //tlfentity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                tlfentity.UpdatedUserId = entity.UpdatedUserId;
                tlfentity.UpdatedDate = DateTime.Now;
                this.TlfDAO.Delete(entity.Eno, entity.UpdatedUserId.Value, entity.SourceBranchCode);
                //if (this.ServiceResult.ErrorOccurred == false) this.ServiceResult.MessageCode = "MI90003";//Delete Success
                if (this.ServiceResult.ErrorOccurred == false) this.ServiceResult.MessageCode = "MI30040";//Successfully Reversal Transaction   
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        #endregion

        #region "Convert DTO to ORM"

        private PFMORM00054 GetTlf(PFMDTO00054 tlfDTO, bool isEdit, bool isDelete)
        {
            PFMORM00054 TlfInfo = new PFMORM00054();

            TlfInfo.Eno = tlfDTO.Eno;
            TlfInfo.AccountNo = tlfDTO.AccountNo;
            TlfInfo.Amount = tlfDTO.Amount;
            TlfInfo.OtherBankChq = tlfDTO.OtherBankChq;
            TlfInfo.OtherBank = tlfDTO.OtherBank;
            TlfInfo.ReceiptNo = tlfDTO.ReceiptNo;
                             
            if (isEdit || isDelete)
            {
                //TlfInfo.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                TlfInfo.UpdatedUserId = tlfDTO.UpdatedUserId;
                TlfInfo.UpdatedDate = DateTime.Now;
            }
            if (isDelete)
                TlfInfo.Active = false;

            return TlfInfo;
        }

        #endregion

        #region "Helper Method"

        public PFMDTO00054 GetTlfInformation(string eno, string dtype, string ctype, string sourcebr,string status)
        {
            IList<PFMDTO00054> tlflist = new List<PFMDTO00054>();
            this.sourceBr = sourcebr;
            tlflist = this.TlfDAO.SelectTlfInfoByEnoandDate(eno, dtype, ctype, sourcebr);
            if (tlflist.Count > 0)
            {
                foreach (PFMDTO00054 tlfdto in tlflist)
                {
                    if (status == "Deliver Reverse")
                    {
                        if (!string.IsNullOrEmpty(tlfdto.OrgnEno))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME30003";     //Already Reverse
                            return null;
                        }
                    }
                    else if (status == "Deliver Edit")
                    {
                        if (tlfdto.Eno.Substring(0, 1) == "D" && tlfdto.CLRPostStatus == "Y")  //added by ASDA
                        {

                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MV90049";     //Pay in Slip No. already Posted.
                            break;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(tlfdto.OrgnEno))
                        {
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME30003";     //Already Reverse
                            return null;
                        }
                    }
                    this.GetNameByAccount(tlfdto.AccountNo);

                    if (this.coaDTO == null)
                    {
                        IList<string> customerNames = new List<string>();
                        foreach (PFMDTO00001 customer in cxdto)
                        {
                            if (!string.IsNullOrEmpty(customer.Name))
                            {
                                customerNames.Add(customer.Name);
                            }
                        }
                        tlfdto.CustomerNames = customerNames;
                    }
                    else
                    {
                        IList<string> AccountName = new List<string>();
                        AccountName.Add(this.coaDTO.COASetUpAccountName);
                        tlfdto.CustomerNames = AccountName;
                    }
                    return tlfdto;
                }

            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME30012";           //Data Not Found. 
            }

            return null;
        }

        public IList<TLMDTO00040> GetBCode()
        {
            return this.bcodeDAO.SelectAll();
        }

        public string GetNameByAccount(string acctno)
        {
            try
            {
                this.coaDTO = this.CoaDAO.SelectByCode(acctno, this.sourceBr);
                if (this.coaDTO == null)
                {
                    if (acctno != null)
                    {
                        cledgerAccount = this.CledgerDAO.SelectACSignByAccountNo(acctno);

                        if (cledgerAccount != null)
                        {
                            acsign = cledgerAccount.AccountSign;
                        }

                        else
                        {
                            fledgerAccount = this.FLedgerDAO.SelectACSignAndCurByAccountNo(acctno);
                            acsign = fledgerAccount.AccountSignature;
                        }
                    }

                    if (acsign != null)
                    {
                        if (acsign.Substring(0, 1) == "C")
                        {
                            cxdto = this.CxDAO.GetCustomerInformationBySAOForCAOF(acctno, "C");
                        }

                        else if (acsign.Substring(0, 1) == "S")
                        {
                            cxdto = this.CxDAO.GetCustomerInformationBySAOForCAOF(acctno, "S");
                        }

                        else
                        {
                            cxdto = this.CxDAO.SelectCustomerInformationByFAOF(acctno);
                        }
                    }
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = CXMessage.MV00175;  // Account no not found.
            }

            while (cxdto.Count != 0)
            {
                int i = cxdto.Count - 1;
                string name = cxdto[i].Name.ToString();

                if (!string.IsNullOrEmpty(name))
                    return name;

                else i--;
            }

            return null;
        }

   
        #endregion
    }
}