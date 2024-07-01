//----------------------------------------------------------------------
// <copyright file="TLMDAO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Cx.Com.Dto;


namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// CashDeno DAO
    /// </summary>
    public class TLMDAO00015 : DataRepository<TLMORM00015>, ITLMDAO00015
    {
        public IList<TLMDTO00015> GetCenterTableDataDTOList(string status,string receiptno,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoDatasForCenterTableDepositByDate");
           // DateTime date = DateTime.Now.Date;
            query.SetDateTime("cashdate", DateTime.Now);
            query.SetParameter("status", status);
            query.SetParameter("receiptno", receiptno);
            query.SetString("sourcebr", sourcebr);
            string sql = this.GetSQLString(query.QueryString);
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;

        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 SaveCashDenoData(TLMDTO00015 cashdenoparameter)
        {   
            IQuery query = this.Session.GetNamedQuery("StoreProcedure_INS_CASHDENO");
            query.SetString("receiptNo", cashdenoparameter.ReceiptNo);
            query.SetString("denoEno", cashdenoparameter.DenoEntryNo);
            query.SetString("tlfEno", cashdenoparameter.TlfEntryNo);
            query.SetString("acType", cashdenoparameter.AccountType);
            query.SetString("fromType", cashdenoparameter.FromType);
            query.SetString("branchcode", cashdenoparameter.BranchCode);
            query.SetDecimal("amount", cashdenoparameter.Amount);
            query.SetDecimal("adjustAmt", cashdenoparameter.AdjustAmount.Value);
            query.SetString("denoDetail", cashdenoparameter.DenoDetail);
            query.SetString("denorefundDetail", cashdenoparameter.DenoRefundDetail);
            query.SetString("userNo", cashdenoparameter.UserNo);
            query.SetString("counterNo", cashdenoparameter.CounterNo);
            query.SetString("status", cashdenoparameter.Status);
            query.SetBoolean("reverse", Convert.ToBoolean(cashdenoparameter.Reverse));
            query.SetString("registerNo", cashdenoparameter.RegisterNo);
            query.SetString("sourceBranch", cashdenoparameter.SourceBranchCode);
            query.SetString("currency", cashdenoparameter.Currency);
            query.SetString("denoRate", cashdenoparameter.DenoRate);
            query.SetString("denorefundRate", cashdenoparameter.DenoRefundRate);
            query.SetDateTime("settlementDate", Convert.ToDateTime(cashdenoparameter.SettlementDate));
            query.SetDecimal("rate", cashdenoparameter.Rate.Value);
            query.SetInt32("createduserId", cashdenoparameter.CreatedUserId);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00015)));
            //query.UniqueResult().ToString();
            TLMDTO00015 cashdenodata = query.UniqueResult<TLMDTO00015>();
            //return query.UniqueResult().ToString();
            return cashdenodata;
        }

        //[Transaction(TransactionPropagation.Required)]
        //public IList<TLMDTO00015> SelectOnlineCashDenoData_DepoDeno()
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectOnlineCashDenoEntry.DepoDeno");
        //    query.SetString("rd", "RD");
        //    query.SetString("status", "R");            
        //    return query.List<TLMDTO00015>();
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public IList<TLMDTO00015> SelectOnlineCashDenoData_IblTlf()
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectOnlineCashDenoEntry.IBLTLF");
        //    query.SetString("rd", "RD");
        //    query.SetString("status", "R");
        //    query.SetString("ibl", "IBL");
        //    IList<TLMDTO00015> cashdto = query.List<TLMDTO00015>();
        //    return cashdto;
        //}

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00015> SelectOnlineCashDenoData(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectOnlineCashDenoEntry");
            query.SetString("rd", "RD");
            query.SetString("status", "R");
            query.SetString("ibl", "IBL");
            query.SetString("sourceBr", sourceBr);
            query.SetString("groupno", "G");
            IList<TLMDTO00015> cashdto = query.List<TLMDTO00015>();
            return cashdto;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool CheckEntryNo(string entryNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.CheckEntryNo");
            query.SetString("rd", "RD");
            query.SetString("entryno", entryNo);
            IList<TLMDTO00015> dto = query.List<TLMDTO00015>();
            return (dto.Count >0) ? true : false;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDeno(string entryno,CXDTO00001 denodto, string counterno, int updatedUserId,decimal rate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDeno");
            query.SetDateTime("cashDate", DateTime.Now);
            query.SetString("denodetail", denodto.DenoString);
            query.SetString("denorate", denodto.DenoRateString);
            query.SetString("denorefunddetail", denodto.RefundString);
            query.SetString("denorefundrate", denodto.RefundRateString);
            query.SetDecimal("adjustAmount", denodto.AdjustAmount);
            query.SetString("userno", updatedUserId.ToString());
            query.SetString("counterNo", counterno);
            query.SetDecimal("rate", rate);
            query.SetString("entryNo", entryno);
            query.SetString("status", "R");
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateReceiptReversal(TLMDTO00015 cashdenoInfo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateReceiptReversal");
            query.SetString("entryNo", cashdenoInfo.DenoEntryNo);
            query.SetInt32("updatedUserId", cashdenoInfo.CreatedUserId);
            query.SetDateTime("updatedDate", cashdenoInfo.CreatedDate);
            query.SetString("accountNo", cashdenoInfo.AccountType);
            query.SetString("receiptNo", cashdenoInfo.ReceiptNo);

            return query.ExecuteUpdate() > 0;
        }
        public IList<TLMDTO00015> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteCashDeno(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteCashDeno");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.ExecuteUpdate();
        }


        public IList<TLMDTO00015> SelectHomeAmountByBranch(string branchCode, string currency, DateTime settlementDate, string accountType, string counterNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectHomeAmountByBranch");            
                
            if(string.IsNullOrEmpty(accountType))
                query = Session.CreateQuery(query.QueryString.Replace("c.AccountType", "c.CounterNo"));

            query.SetString("branchCode", branchCode);
            query.SetString("currency", currency);
            query.SetString("temp", string.IsNullOrEmpty(accountType)?counterNo:accountType);
            query.SetDateTime("settlementDate", settlementDate);

            return query.List<TLMDTO00015>();
        }


        // for TCMCTL00007 (Is EntryNo already made deno?)
        public IList<TLMDTO00015> GetCashDenoInfo(string tlfeno, string status, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoData");
            query.SetParameter("tlfEno", tlfeno);
            query.SetParameter("status", status);
            query.SetParameter("sourceBranch", sourceBr);
            //string sql = this.GetSQLString(query.QueryString);
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }


        // for TCMCTL00075 (Is EntryNo already made deno?)
        public IList<TLMDTO00015> GetCashDenoInfoByIsNotNullCashDate(string tlfeno, string status, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoDataByIsNotNullCashDate");
            query.SetParameter("tlfEno", tlfeno);
            query.SetParameter("status", status);
            query.SetParameter("sourceBranch", sourceBr);
            //string sql = this.GetSQLString(query.QueryString);
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }

        public TLMDTO00015 SelectCashDenoInfoByACType(string acType, string sourceBranchCode)
        {
            if (string.IsNullOrEmpty(acType))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(sourceBranchCode))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoInfoByACType");
            query.SetParameter("actype", acType);
            query.SetParameter("sourceBranchCode", sourceBranchCode);
            return query.UniqueResult<TLMDTO00015>();
        }
        public string SelectCounterNoByAcType(string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCounterNoByAcType");
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<string>();
        }

        public TLMDTO00015 SelectByAcTypeAndNotReverse(string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectByAcTypeAndNotReverse");
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00015>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteByACType(string acType, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteByACType");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteByTlfEno(string tlfEno, string sourceBr, int updatedUserId)
        {
           IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteByTlfEno");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByTlfEno(CXDTO00001 deno, int updatedUserId, string sourceBr, string tlfEno, decimal cashAmount)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByTlfEno");
            query.SetDecimal("amount", cashAmount);
            query.SetDecimal("adjustAmount", deno.AdjustAmount);
            query.SetString("denoDetail", deno.DenoString);
            query.SetString("denoRefundDetail", deno.RefundString);
            query.SetString("denoRate", deno.DenoRateString);
            query.SetString("denoRefundRate", deno.RefundRateString);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByACType(CXDTO00001 deno, int updatedUserId, string sourceBr, string acType, decimal cashAmount)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByACType");
            query.SetDecimal("amount", cashAmount);
            query.SetDecimal("adjustAmount", deno.AdjustAmount);
            query.SetString("denoDetail", deno.DenoString);
            query.SetString("denoRefundDetail", deno.RefundString);
            query.SetString("denoRate", deno.DenoRateString);
            query.SetString("denoRefundRate", deno.RefundRateString);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        public decimal SelectAmountByTlfEno(string tlfEno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectAmountByTlfEno");
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<decimal>();
        }
        public decimal SelectAmountByACType(string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectAmountByACType");
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<decimal>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByTlfEnoAndCashDate(string eno, int updatedUserId, string tlfEno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByTlfEnoAndCashDate");
            query.SetString("eno", eno);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("cashdate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        //IndividualDenomination Delete
        public TLMDTO00015 GetCashDenoByEntryNo(string entryNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoByEntryNo");
            query.SetString("entryNo", entryNo);
            query.SetString("sourceBranchCode", branchCode);
            //query.SetDateTime("cashdate", DateTime.Now);          
            return query.UniqueResult<TLMDTO00015>();
        }
        [Transaction(TransactionPropagation.Required)]
        public void DeleteCashDenoByEntryNo(string entryNo, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteCashDenoByEntryNo");
            query.SetString("entryNo", entryNo);
            query.SetString("sourceBranchCode", branchCode);
            query.ExecuteUpdate();
        }



    
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateReceiptNoInCenterTableApprove(string tlfEno,int updatedUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateReceiptNoInCenterTableApprove");
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("tlfeno", tlfEno);
            query.SetString("sourceBr", sourceBr);           
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00015> GetDepoDenoAndCashDeno(string groupNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoAndDepoDenoDatas");
            query.SetString("groupNo", groupNo);
            query.SetString("sourceBranch", sourceBranch);
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }

        // For PO Refund Reversal
        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 GetCashDenoForPOReversal(string groupNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.GetCashDenoForPOReversal");
            query.SetString("groupNo", groupNo);
            query.SetString("sourceBranch", sourceBranch);
            TLMDTO00015 result = query.UniqueResult<TLMDTO00015>();
            return result;
        }

        // Drawing Remittance Voucher To check Multi/Group Denomination
        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00015> GetDepoDenoAndCashDenoForDrawingVoucher(string registerNo, string sourceBranch)
        {
            if (string.IsNullOrEmpty(registerNo))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            if (string.IsNullOrEmpty(sourceBranch))
            {
                throw new Exception("ME90018");//Invalid Parameter Value.
            }
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoAndDepoDenoDatasForDrawingVoucher");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBranch", sourceBranch);
            //TLMDTO00015 cashdenoDto = query.UniqueResult<TLMDTO00015>();
            //return cashdenoDto;
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
            
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 GetSinglePO(string poNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectSinglePO");
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("status", "R");
            return query.UniqueResult<TLMDTO00015>();
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 GetMultiPO(string groupNo, string poNo, string sourceBranch,string status)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectMultiPO");
            query.SetString("groupNo", groupNo);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("status", status);
            return query.UniqueResult<TLMDTO00015>();
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 SelectByEno(string eno, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectByEno");
            query.SetString("eno", eno);
            query.SetString("sourceBranch", sourceBranch);
            return query.UniqueResult<TLMDTO00015>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByDenoEntryNo(string voucherNo, string orgnEno, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByDenoEntryNo");
            query.SetString("voucherNo", voucherNo);
            query.SetString("orgnEno", orgnEno);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("status", "R");
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByTlfEntryNo(string voucherNo, string groupNo, string sourceBranch, int updatedUserId, DateTime updatedDate,string status)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByTlfEntryNo");
            query.SetString("voucherNo", voucherNo);
            query.SetString("groupNo", groupNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("status",status);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByAccountType(string voucherNo, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByAccountType");
            query.SetString("voucherNo", voucherNo);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("status", "P");
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 SelectCashDenoByTlfEnoForDenoEdit(string tlfeno, string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("DenoEdit.SelectCashDenoDataByTLFEno");
            query.SetString("tlfeno", tlfeno);
            query.SetString("sourcebranchcode", sourcebranchcode);
            return query.UniqueResult<TLMDTO00015>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoEdit(string tlfeno, TLMDTO00015 cashdenodto)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoEdit");
            query.SetString("tlfeno", tlfeno);
            query.SetString("status", cashdenodto.Status);
            query.SetString("sourceBranch", cashdenodto.SourceBranchCode);
            query.SetDateTime("cashdate", DateTime.Now);
            //query.SetString("serialno", cashdenodto.TlfEntryNo);
            query.SetDateTime("updatedDate", cashdenodto.CreatedDate);
            query.SetInt32("updatedUserId", cashdenodto.CreatedUserId);
            query.SetString("denoENo", cashdenodto.TlfEntryNo);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //TCMVEW00010 (ASDA)
        public IList<TLMDTO00015> SelectCashDenoBySourcebrAndDatetimeAndStatus(string sourcebr, DateTime startDate, DateTime endDate, string status)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectAllBySourcebrAndDatetimeAndStatus");            
            query.SetString("sourcebranchcode", sourcebr);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("status", status);            
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]   //TCMVEW00010 (ASDA)
        public IList<TLMDTO00015> SelectCashDenoBySourcebrAndDatetime(string sourcebr, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectAllBySourcebrAndDatetime");
            query.SetString("sourcebranchcode", sourcebr);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));            
            IList<TLMDTO00015> list = query.List<TLMDTO00015>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]   //TCMVEW00010 (ASDA)
        public void DeleteCashDenoByDatetimeAndStatus(string sourcebr, DateTime startDate, DateTime endDate, string status)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteCashDenoByDatetimeAndStatus");
            query.SetString("sourcebranchcode", sourcebr);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));
            query.SetString("status", status);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]   //TCMVEW00010 (ASDA)
        public void DeleteCashDenoByDatetime(string sourcebr, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.DeleteCashDenoByDatetime");
            query.SetString("sourcebranchcode", sourcebr);
            query.SetString("startDate", startDate.ToString("yyyy/MM/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/MM/dd"));            
            query.ExecuteUpdate();
        }

        //Select Max Id
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.SelectMaxId");
            return query.UniqueResult<TLMDTO00015>().Id;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCashDenoByGroupNo(TLMDTO00015 cashdenodto)
        {
            IQuery query = null;
            if (cashdenodto.VirtualStatus == "CashDeno")
            {
                query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoWithGroupNo");
                query.SetString("groupNo", cashdenodto.TlfEntryNo);
                query.SetString("status", cashdenodto.Status);
            }
            else 
            {
                if(cashdenodto.VirtualStatus=="DCSingle")/*Drawing Cash Deposit Denomination For Single */
                {
                query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByAccountTypeAndReverse");
                query.SetString("atype", cashdenodto.RegisterNo);
                }
                else if (cashdenodto.VirtualStatus == "DCMultiple")/*Drawing Cash Deposit Denomination For Multiple*/
                {
                    query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByTLFENOAndReverse");
                    query.SetString("groupno", cashdenodto.RegisterNo);
                }
                query.SetString("denorefunddetail", cashdenodto.DenoRefundDetail);
                query.SetString("denorefundrate", cashdenodto.DenoRefundRate);
            }            
            query.SetDateTime("cashdate", DateTime.Now);
            query.SetString("denodetail", cashdenodto.DenoDetail);        
            query.SetString("denorate", cashdenodto.DenoRate);
            query.SetDecimal("rate", cashdenodto.Rate.Value);
            query.SetDateTime("settlementDate", cashdenodto.SettlementDate.Value );
            //query.SetString("denorefundrate", cashdenodto.DenoRefundRate);
            query.SetDecimal("adjustamount", cashdenodto.AdjustAmount.Value);
            query.SetString("userno", cashdenodto.UserNo);
            query.SetString("counterno", cashdenodto.CounterNo);
            query.SetString("alldenorate", cashdenodto.AllDenoRate);
            query.SetDateTime("updatedDate",DateTime.Now);
            query.SetInt32("updatedUserId", cashdenodto.UpdatedUserId.Value);           
            query.SetString("sourceBranch", cashdenodto.SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00015 SelectCashDenoByAccountTypeOrTLFEno(string accountType, string sourcebranchcode)
        {
            IQuery query = null;
            if (accountType.Substring(0, 1) != "G")
            {
                query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoDatasByAccountType");
                query.SetString("actype", accountType);
            }
            else
            {
                query = this.Session.GetNamedQuery("TLMDAO00015.SelectCashDenoDatasByTLFENo");
                query.SetString("tlfeno", accountType);
            }           
            query.SetString("sourceBranch", sourcebranchcode);
            return query.UniqueResult<TLMDTO00015>();           
        }

        [Transaction(TransactionPropagation.Required)]   //Added by ASDA  (MNMSVE00023) Delete Case
        public bool UpdateCashDenoForReversalDelete(string voucherNo, int updatedUserId, string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoForReversalDelete");
            query.SetString("ReversalVoucherNo", voucherNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);            
            return query.ExecuteUpdate() > 0;
        }


        [Transaction(TransactionPropagation.Required)]   //Added by ASDA  (MNMSVE00023) already Voucher Edit Case
        public bool UpdateCashDenoByForAmountEdit(string voucherNo, int updatedUserId, string tlfEno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoForAmountEdit");
            query.SetString("ReversalENO", voucherNo);       
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //Added by ASDA  (MNMSVE00023) already Voucher Edit Case
        public bool UpdateCashDenoByCashDateNull(int updatedUserId, string tlfEno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00015.UpdateCashDenoByCashDateNull");            
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("tlfEno", tlfEno);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }
    }
}
