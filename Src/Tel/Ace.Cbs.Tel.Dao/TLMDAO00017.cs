//----------------------------------------------------------------------
// <copyright file="TLMDAO00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nay Lin Ko Ko, Khin Phyu Lin</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Dto;
using NHibernate.Transform;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// RD DAO
    /// </summary>
    public class TLMDAO00017 : DataRepository<TLMORM00017>, ITLMDAO00017
    {
        public string SelectRegisterNo(string RegisterNo)
        {
            return null;
        }

        public IList<TLMDTO00017> SelectRegisterNoBySendDate(string order, string sourceBr, DateTime datetime)
        {
            if (order == "IBL Drawing Remittance Passing (By Branch)")
            {

                IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectRegisterNoBySendDateOdrByBranchNo");
                query.SetString("sourceBr", sourceBr);
                query.SetDateTime("dateTime", datetime);              
                return query.List<TLMDTO00017>();
            }
            else if (order == "IBL Drawing Remittance Passing (By Date)")
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectRegisterNoBySendDateOdrByDateTime");
                query.SetString("sourceBr", sourceBr);
                query.SetDateTime("datetime", datetime);
                return query.List<TLMDTO00017>();
            }
            else if (order == "IBL Drawing Remittance Passing (By Register No)")
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectRegisterNoBySendDateOdrByRegisterNo");
                query.SetString("sourceBr", sourceBr);
                query.SetDateTime("datetime", datetime);
                return query.List<TLMDTO00017>();
            }
            else
                return null;

        }

        public TLMDTO00017 SelectDrawingInfoByRegisterNo(string registerNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectDrawingInfoByRegisterNo");
            query.SetString("registerNo", registerNo);
            return query.UniqueResult<TLMDTO00017>();
        }

        public decimal SelectTestKeyByRegisterNo(string registerNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectTestKeyByRegisterNo");
            query.SetString("registerNo", registerNo);
            return Convert.ToDecimal(query.UniqueResult<TLMDTO00017>().TestKey);
        }

        public bool UpdateRDByRegisterNo(string registerNo, System.DateTime sendDate, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateRDByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetDateTime("sendDate", sendDate);
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updateddate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        public IList<TLMDTO00017> SelectAllRegisterNo(string sourceBranchCode, string type)
        {
           
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectRegisterNo");
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("type", type);
            query.SetString("todaydate", (DateTime.Now.ToString("yyyy/MM/dd")));
            IList<TLMDTO00017> registerNo =  query.List<TLMDTO00017>();
            return registerNo;
        }

        public IList<TLMDTO00017> SelectAllRegisterNoForFX(string sourceBranchCode, string type)
        {

            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectRegisterNoForFX");
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("type", type);
            IList<TLMDTO00017> registerNo = query.List<TLMDTO00017>();
            return registerNo;
        }

        public IList<TLMDTO00017> SelectDrawingDataForIBLReconcile(DateTime date_time,string type,string branchcode,string sourcebranchcode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectDrawingDataForIBLReconcile");
            query.SetDateTime("datetime", date_time.Date);
            query.SetString("type", type);
            query.SetString("dbank", branchcode);
            query.SetString("sourcebr", sourcebranchcode);
            string sqlQuery = this.GetSQLString(query.QueryString);
            IList<TLMDTO00017> RDDTOLists = query.List<TLMDTO00017>();
            return RDDTOLists;
        }


        public TLMDTO00017 SelectDrawingDataForIBLReconcileSide(DateTime date_time, string type, string branchcode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.TLMDAO00017.SelectDrawingDataForIBLReconcileSide");
            query.SetDateTime("datetime", date_time.Date);
            query.SetString("type", type);
            query.SetString("dbank", branchcode);
           
            string sqlQuery = this.GetSQLString(query.QueryString);

            TLMDTO00017 RDDTO = query.UniqueResult<TLMDTO00017>();
            return RDDTO;
        }

        //<!--//SelectAll RD For Quarter//-->
        public IList<TLMDTO00017> SelectAllRDQTR(string qSDATE, string qEDATE, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectAllRDQTR");
            query.SetString("qSDATE", qSDATE);
            query.SetString("qEDATE", qEDATE);
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00017> res=query.List<TLMDTO00017>();
            return res;
        }

         //<!--//Delete RD For Quarter-->
        [Transaction(TransactionPropagation.Required)]
        public void DeleteRDQTR(string qSDATE, string qEDATE, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.DeleteRDQTR");
            query.SetString("qSDATE", qSDATE);
            query.SetString("qEDATE", qEDATE);
            query.SetString("SourceBranchCode", SourceBranchCode); 
            query.ExecuteUpdate();
        }

         //<!--//SelectAll RD //-->
        public IList<TLMDTO00017> SelectAllRD( string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectAllRD");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00017> res = query.List<TLMDTO00017>();
            return res;
        }

        //<!--//DeleteAll RD-->
        [Transaction(TransactionPropagation.Required)]
        public void DeleteRD(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.DeleteRD");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.ExecuteUpdate();
        }

        //Select RD Data By Register No For Check RD Register No
        public TLMDTO00017 SelectDrawingDataByRegisterNo(string registerNo, string sourceBr)  //comment reopen by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);

            return query.UniqueResult<TLMDTO00017>();
        }

        //Update RD By RegisterNo and SourceBr
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateRDByRegisterNoAndSourceBr(DateTime sendDate, int UpdateUserId, DateTime updateDate, string registerNo1,string registerNo2, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateRDByRegisterNoAndSourceBr");
            query.SetDateTime("sendDate", sendDate);
            query.SetInt32("updateduserid", UpdateUserId);
            query.SetDateTime("updateddate", updateDate);
            query.SetString("registerNo1", registerNo1);
            query.SetString("registerNo2", registerNo2);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateRDRegisterNoToAddC(string registerNo, string newRegNo, string sourcebr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateRegisterNoC");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourcebr);
            query.SetString("modifyRegisterNo", newRegNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public TLMDTO00017 SelectByRegisterNo(string registerNo, string sourceBr)  
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.SelectByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00017>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateRDPersonalInformation(string name, string nrc, string address, string phoneNo, string narration, string toAccountNo, string toName, string toNRC, string toAddress, string toPhoneNo, int updatedUserId, string registerNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("UpdateRDPersonalInfo");
            query.SetString("name", name);
            query.SetString("nrc", nrc);
            query.SetString("address", address);
            query.SetString("phoneNo", phoneNo);
            query.SetString("narration", narration);
            query.SetString("toAccountNo", toAccountNo);
            query.SetString("toName", toName);
            query.SetString("toNRC", toNRC);
            query.SetString("toAddress", toAddress);
            query.SetString("toPhoneNo", toPhoneNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   
        public bool DeleteByRegisterNo(string registerNo, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.DeleteByRegisterNo");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateRDImportantDataByRegisterNo(decimal testKey,decimal amount, decimal commission, decimal tlxCharges, string incomeType, string accountNo, string name, string nrc, string address, string checkNo, string phoneNo, string narration, string acSign, string rdType, string deno_status, int updatedUserId, string registerNo, string sourceBr)
        {//edited by ASDA
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateRDImportantDataByRegisterNo");           
            query.SetDecimal("testKey", testKey);
            query.SetDecimal("amount", amount);
            query.SetDecimal("commission", commission);
            query.SetDecimal("tlxCharges", tlxCharges);
            query.SetString("incomeType", incomeType);
            query.SetString("accountNo", accountNo);
            query.SetString("name", name);
            query.SetString("nrc", nrc);
            query.SetString("address", address);
            query.SetString("checkNo", checkNo);
            query.SetString("phoneNo", phoneNo);
            query.SetString("narration", narration);
            query.SetString("acSign", acSign);
            query.SetString("rdType", rdType);
            query.SetString("deno_status", deno_status);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateRDVoucher(DateTime receiptDate, DateTime incomeDate, DateTime settlementDate, string registerNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateRDVoucher");
            query.SetDateTime("receiptDate", receiptDate);
            query.SetDateTime("incomeDate", incomeDate);
            query.SetDateTime("settlementDate", settlementDate);
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        #region "Drawing Cash Deposit Denomination Entry(HWH)"
        public IList<TLMDTO00017> SelectRDDataListByGroupNo(string groupNo, string sourceBranch, bool isRD)
        {
            IQuery query = null;
            if (isRD == true)
            {
                query = this.Session.GetNamedQuery("TLMDAO00017.SelectRDDatasInDrawingCashDenominationEntry");
            }
            else
            {
                query = this.Session.GetNamedQuery("TLMDAO00017.SelectRDListandDenoListsInDrawingCashDeno");
            }
            query.SetString("groupno", groupNo);
            query.SetString("sourcebr", sourceBranch);
            IList<TLMDTO00017> res = query.List<TLMDTO00017>();
            return res;
        }       

        //TLMDAO00017.UpdateDenoStatusByRegisterNo
         [Transaction(TransactionPropagation.Required)]
        public bool UpdateDenoStatusByRegisterNo(string groupNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00017.UpdateDenoStatusByRegisterNo");
            query.SetString("registerNo", groupNo);
            query.SetString("denostatus", "Y");
            query.SetString("sourcebr", sourceBranch);
            query.SetInt32("updatedUserId", CurrentUserEntity.CurrentUserID);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 1;
        }
#endregion
    }
}
