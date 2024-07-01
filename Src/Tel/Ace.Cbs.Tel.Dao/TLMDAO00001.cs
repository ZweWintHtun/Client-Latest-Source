//----------------------------------------------------------------------
// <copyright file="TLMDAO00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Khin Phyu Lin</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Ace.Cbs.Cx.Com.Utt;


using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// Remittance Encash DAO
    /// </summary>
    public class TLMDAO00001 : DataRepository<TLMORM00001>,ITLMDAO00001
    {
        public TLMDTO00001 SelectREInformationByRegisterNo(string registerNo, string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("SelectREInfoByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("branchno", sourcebranchcode);
            return query.UniqueResult<TLMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00001> SelectRemittanceEncashData(string sourceBr) // Select RegisterNo From RE table
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectEncashData");
            query.SetString("toAcctno","po");
            query.SetString("istoAcctno", string.Empty);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00001> SelectRemittanceEncashDataCashType(string sourceBr) // Select RegisterNo From RE table
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectEncashDataCashType");
            query.SetString("istoAcctno", string.Empty);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateREByRegisterNo(string registerNo, System.DateTime issueDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateREByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetDateTime("issueDate", issueDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00001 SelectREByRegisterNo(string registerNo, string ebank, string toAccountNo, string toName, string toNRC, string toAddress, System.Decimal amount)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectREByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("ebank", ebank);
            query.SetString("toAccountNo", toAccountNo);
            query.SetString("toName", toName);
            query.SetString("toNRC", toNRC);
            query.SetString("toAddress", toAddress);
            query.SetDecimal("amount", amount);
            return query.UniqueResult<TLMDTO00001>();
        }

        public bool UpdateRemittanceEncashData(string registerNo, Nullable<DateTime> issueDate, string encashNo, System.Nullable<DateTime> settlementDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateRE");
            query.SetDateTime("issuedate", issueDate.Value);
            query.SetString("encashno", encashNo);
            query.SetDateTime("settlementdate", settlementDate.Value);
            query.SetInt32("updatedUserId", updatedUserId.Value);
            query.SetDateTime("updatedDate", updatedDate.Value);
            query.SetString("registerNo", registerNo);

            return query.ExecuteUpdate() > 0;

        }

        public IList<TLMDTO00001> SelectToAcctNoByPONO(IList<string> ponolist)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectToAcctNoByPONO");
            if (ponolist.Count != 0)
            {
                query.SetParameterList("polist", ponolist);
                IList<TLMDTO00001> re = query.List<TLMDTO00001>();
                return re;
            }
            else
            {
                return null;
            }
        }



        public TLMDTO00001 SelectEncashDataForIBLReconcile(DateTime datetime, string type, string ebank)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectEncashDataForIBLReconcile");
            query.SetDateTime("datetime",datetime.Date);
            query.SetString("type", type);
            query.SetString("ebank", ebank);

            return query.UniqueResult<TLMDTO00001>();

        }

        public IList<TLMDTO00001> SelectEncashDataForIBLReconcileSide(DateTime datetime, string type, string ebank,string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectEncashDataForIBLReconcile");
            query.SetDateTime("datetime", datetime.Date);
            query.SetString("type", type);
            query.SetString("ebank", ebank);
            query.SetString("sourcebrcode", sourcebranchcode);
            return query.List<TLMDTO00001>();

        }


        public bool CheckExistRegisterNo(string registerNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.CheckExist");
            query.SetString("RegisterNo", registerNo);
            TLMDTO00001 registerEncash = query.UniqueResult<TLMDTO00001>();
            return registerEncash == null ? false : true;
        }

      
        public IList<TLMDTO00001> SelectPassingEncashRemittanceData(string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.Select.EncashRemitPassingData");
            query.SetString("type", "IBL");
            query.SetString("sourceBranch", sourceBranch);
            return query.List<TLMDTO00001>();
        }

        //Added by ASDA
        //public IList<TLMDTO00001> SelectPassingEncashRemittanceData()
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMDAO00001.Select.EncashRemitPassingData");
        //    query.SetString("type", "IBL");
        //    //query.SetString("sourceBranch", sourceBranch);
        //    return query.List<TLMDTO00001>();
        //}
        //end---------
        public TLMDTO00001 SelectRegisterNoByPO(string pono)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.Select.RegisterNoByPO");
            query.SetString("acctno", pono);
            return query.UniqueResult<TLMDTO00001>();
        }

        public IList<TLMDTO00001> SelectRE(IList<string> ponoList, string SourceBranchCode)
        {
            if (ponoList.Count == 0)
            {
                ponoList.Add(string.Empty);
            }
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectRE");
            query.SetParameterList("polist", ponoList);
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00001> re = query.List<TLMDTO00001>();
            return re;
        }

        public TLMDTO00001 GetREInfoByRegtisterNo(string registerno)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.Select.REInfoByRegisterNo");
            query.SetString("registerno", registerno);
            //query.SetString("toaccountno" , toaccountno );
            //query.SetDateTime("issuedate", issuedate);
            return query.UniqueResult<TLMDTO00001>();
        }


        //For PO Printing in Transfer & Clearing Function.To bind Gird View By User required Date.
        public IList<TLMDTO00001> SelectREDTOListForPOPrinting(DateTime datetime,string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectREForClearingPosting");
            string gggg = datetime.ToString("yyyy/MM/dd");
            query.SetString("datetime", gggg);
            query.SetString("sourcebrcode",sourcebranchcode);
            return query.List<TLMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteRE(IList<string> ponoList, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.DeleteRE");
            query.SetParameterList("polist", ponoList);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.ExecuteUpdate();


        }

      
        public bool UpdateReInfo(string registerNo,string encashNo,string toAccountNo, Nullable<DateTime> issueDate, System.Nullable<DateTime> settlementDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateReInfo");
            query.SetString("registerno", registerNo);
            query.SetString("encashno", encashNo);
            query.SetString("toaccountno", toAccountNo);
            query.SetDateTime("issuedate", issueDate.Value);            
            query.SetDateTime("settlementdate", settlementDate.Value);
            query.SetInt32("updatedUserId", updatedUserId.Value);
            query.SetDateTime("updatedDate", updatedDate.Value);          

            return query.ExecuteUpdate() > 0;

        }
        public bool UpdatePrintStautsByRegisterNo(string registerNo,Nullable<short> printstatus,int updatedUserId)
        {
            int prnstatus = Convert.ToInt32(printstatus) + 1;
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdatePrintStatusByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetInt32("printstatus", prnstatus);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        //For EncashNo Editting
        [Transaction(TransactionPropagation.Required)]
        public void UpdateReEntity(string registerNo_new,string registerNo_old,System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateReEntityByRegisterNo");
            query.SetString("registerno", registerNo_new);
            query.SetString("registerno_old", registerNo_old); 
            query.SetInt32("updatedUserId", updatedUserId.Value);
            query.SetDateTime("updatedDate", updatedDate.Value);
            query.ExecuteUpdate();
        }

        public IList<TLMDTO00001> SelectReListByRegisterNo(string registerNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00001>();
        }


        public TLMDTO00001 SelectByRegisterNo(string registerNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00001>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateByRegisterNo(TLMDTO00001 entity)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateByResigerNo");
            query.SetString("name", entity.Name);
            query.SetString("nrc", entity.NRC);
            query.SetString("phone", entity.PhoneNo);
            query.SetString("toName", entity.ToName);
            query.SetString("toNRC", entity.ToNRC);
            query.SetString("toAddress", entity.ToAddress);
            query.SetString("toPhone", entity.ToPhoneNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", entity.UpdatedUserId.Value);
            query.SetString("registerNo", entity.RegisterNo);
            query.SetString("sourceBr", entity.SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteREbyRegisterNo(string registerNo, string sourceBr, string cur,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.DeleteREByResigsterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateREbyRegisterNoWithAmount(decimal amount,string registerNo, string sourceBr,string name,string address,string nrc,string phono,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateByRegisterNoWithAmount");
            query.SetDecimal("amount", amount);
            query.SetString("registerNo", registerNo);
            query.SetString("name", name);
            query.SetString("nrc", nrc);
            query.SetString("phoneno", phono);
            query.SetString("address", address);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateREbyRegisterNoWithAmountAndIssueDate(decimal amount, string registerNo, string sourceBr,string name , string address,string nrc , string phono,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateByRegisterNoWithAmountAndIssueDate");
            query.SetDecimal("amount", amount);
            query.SetString("registerNo", registerNo);
            query.SetString("name", name);
            query.SetString("nrc", nrc);
            query.SetString("phoneno", phono);
            query.SetString("address", address);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateIssueDateAndToAcctno(string registerNo, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.UpdateIssueDateAndToAcctNo");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public TLMDTO00001 SelectREForPrinting(string registerNo,string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00001.SelectREForPrinting");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBranch", sourceBranch);
            return query.UniqueResult<TLMDTO00001>();
        }
    }


}
