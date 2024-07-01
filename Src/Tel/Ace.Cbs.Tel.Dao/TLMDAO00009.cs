//----------------------------------------------------------------------
// <copyright file="TLMDAO00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2013-08-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System;


namespace Ace.Cbs.Tel.Dao
{
    //DepoDenoDAO
    public class TLMDAO00009 : DataRepository<TLMORM00009>, ITLMDAO00009
    {
        //select GroupNo By Eno
        public TLMDTO00009 SelectGroupNoByEno(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectGroupNoByEno");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00009>();
        }
        public IList<TLMDTO00009> SelectAllDepoDeno(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00009> list = query.List<TLMDTO00009>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteDepodeno(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.DeleteDepodeno");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.ExecuteUpdate();
        }


        public IList<TLMDTO00009> SelectChargesByGroupNo(string groupno)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectChargesAmountByEntryNo");
            query.SetString("entryNo", groupno);
            return query.List<TLMDTO00009>();
        }

        public TLMDTO00009 SelectSumAmountByGroupNo(string groupno, string eno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00006.SelectDepoDenoSumAmountByGroupNo");
            query.SetString("GroupNo", groupno);
            query.SetString("ENO", eno);
            query.SetString("SourceBranchCode", sourcebr);
            return query.UniqueResult<TLMDTO00009>();
        }

        public string SelectGroupNoByAcType(string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectGroupNoByACType");
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<string>();
        }

        public decimal SelectOtherAmountByGroupNo(string groupNo, string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectOtherAmountByGroupNo");
            query.SetString("groupNo", groupNo);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            decimal amt = query.UniqueResult<decimal>();
            return amt;
        }

        public decimal SelectAmountByGroupNo(string groupNo, string acType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectAmountByGroupNo");
            query.SetString("groupNo", groupNo);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            decimal amt = query.UniqueResult<decimal>();
            return amt;
        }
        [Transaction(TransactionPropagation.Required)]
        public bool DeleteByGroupNoAndACType(string acType, string sourceBr, int updatedUserId, string groupNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.DeleteByGroupNoAndACType");
            query.SetString("groupNo", groupNo);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateByGroupNoAndACType(string acType, string sourceBr, int updatedUserId, string groupNo, decimal amount)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.UpdateByGroupNoAndACType");
            query.SetDecimal("amount", amount);
            query.SetString("groupNo", groupNo);
            query.SetString("acType", acType);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public TLMDTO00009 SelectDepoDeno(string groupNo, string poNo,string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectDepoDeno");
            query.SetString("groupNo",groupNo);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            return query.UniqueResult<TLMDTO00009>();
        }

        public decimal SumAmountByPONo(string groupNo, string poNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SumAmountByPONo");
            query.SetString("groupNo", groupNo);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            decimal amt = query.UniqueResult<decimal>();
            return amt;
        }

        //edited by ASDA 
        public bool UpdateDepoDenoByReverseStatus(string groupNo, string poNo,string sourceBranch, int updatedUserId, DateTime updatedDate, bool isUpdate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.UpdateDepoDenoByReverseStatus");
            query.SetString("groupNo", groupNo);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetBoolean("active",isUpdate);  //edited by ASDA  
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        public IList<TLMDTO00009> SelectDepoDenoForCheckSinglePO(string poNo, string Tlf_Eno, string sourceBranch) //Edited by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.CheckSinglePO");
            query.SetString("poNo", poNo);
            query.SetString("Tlf_Eno", Tlf_Eno);
            query.SetString("sourceBranch", sourceBranch);
            //return query.UniqueResult<TLMDTO00009>();
            IList<TLMDTO00009> list = query.List<TLMDTO00009>();
            return list;
        }

        //public bool UpdateDepoDenoForPORefundReversal(string groupNo, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        //{
        //    IQuery query = this.Session.GetNamedQuery("TLMDAO00009.UpdateDepoDenoForPORefundReversal");
        //    query.SetString("groupNo", groupNo);
        //    query.SetString("poNo", poNo);
        //    query.SetString("sourceBranch", sourceBranch);
        //    query.SetInt32("updatedUserId", updatedUserId);
        //    query.SetDateTime("updatedDate", updatedDate);

        //    return query.ExecuteUpdate() > 0;
        //}

        public IList<TLMDTO00009> SelectAccountNoByGroupNo(string groupno, string status, string sourcebranch)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectAccountTypeByEno");
                query.SetString("entryNo", groupno);
                query.SetString("status", status);
                query.SetString("sourcebranch", sourcebranch);
                return query.List<TLMDTO00009>();
            }
            catch (Exception e)
            {
                throw null;
            }
        }

        [Transaction(TransactionPropagation.Required)]   //TCMVEW00010 (ASDA)
        public void DeleteDataFromDepoDeno(string sourcebr, DateTime startDate, DateTime endDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.DeleteDataFromDepoDeno");
            query.SetString("sourcebranchcode", sourcebr);
            query.SetString("startDate", startDate.ToString("yyyy/mm/dd"));
            query.SetString("endDate", endDate.ToString("yyyy/mm/dd"));
            query.ExecuteUpdate();
        }

        //select AccountType By Tlf_Eno (In Cash Payment Denomination Entry)
        public IList<TLMDTO00009> SelectAccountTypesByTlf_Eno(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectAccountTypeByTlf_Eno");
            query.SetString("entryNo", eno);
            query.SetString("sourcebr", sourceBr);
            return query.List<TLMDTO00009>();
        }

        //select AccountType By GroupNo (In Cash Payment Denomination Entry)
        public IList<TLMDTO00009> SelectAccountTypesByGroupNo(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00009.SelectAccountTypeByGroupNo");
            query.SetString("entryNo", eno);
            query.SetString("sourcebr", sourceBr);
            return query.List<TLMDTO00009>();
        }
        
        //Added By AAM (19-Jan-2018)
        public string Check_GroupNo_ValidOrNot_MultipleDepReversal(string groupNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_GroupNo_ValidationInMultiDepReverse");
            query.SetString("groupNo", groupNo);
            query.SetString("sourceBr", sourceBr);
            
            return query.UniqueResult<string>();
        }

        //Added By AAM (22-Jan-2018)
        //public string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr,string groupNo)
        //{
        //    IQuery query = this.Session.GetNamedQuery("SP_Check_EntryNo_MultipleDepReverse");
        //    query.SetString("eno", eno);
        //    query.SetString("sourceBr", sourceBr);
        //    query.SetString("groupNo", groupNo);

        //    return query.UniqueResult<string>();
        //}

        //Added by HMW (10-June-2019)
        public string Check_EntryNo_ValidOrNot_MultipleDepWdwReversal(string groupNo, string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_EntryNo_Multiple_DepWdwReverse");            
            query.SetString("groupNo", groupNo);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);            
            query.SetString("ERRMESSAGE", string.Empty);

            return query.UniqueResult<string>();
        }
    }
}
