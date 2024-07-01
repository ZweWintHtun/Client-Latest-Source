//----------------------------------------------------------------------
// <copyright file="TLMDAO00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Dao;
using NHibernate;
using System.Data;
using System;
using System.Data.SqlClient;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// IBL TLF DAO
    /// </summary>
    public class TLMDAO00004 : DataRepository<TLMORM00004>, ITLMDAO00004
    {
        //Select Max Id
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectMaxId");
            return query.UniqueResult<TLMDTO00004>().Id;
        }

        //Select IBLTLF Info BY Eno
        public IList<TLMDTO00004> SelectIBLTLfInfoByEno(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectIBLTlfInfoByEno");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00004> ListIBLDTO = query.List<TLMDTO00004>();

            return ListIBLDTO;
        }


        //Check RelatedBr and RelatedAc in IBltlf
        public bool CheckExistRelatedBrAndAc(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.CheckExistRelatedBrAndRelatedAC");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00004> ListIBLDTO = query.List<TLMDTO00004>();
            return ListIBLDTO.Count == 0 ? true : false;

        }

        //Check accountno in IBLTLF 
        [Transaction(TransactionPropagation.Required)]
        public bool CheckExist(string accountno)
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.CheckExist");
            query.SetString("acctno", accountno);
            IList<TLMDTO00004> iblDTO = query.List<TLMDTO00004>();
            return iblDTO.Count == 0 ? true : false;     
 
        }

        /* Select Data For IBL Transaction Reconsile */
        [Transaction(TransactionPropagation.Required)]
        public IList<TLMDTO00004> SelectDataForTransactionReconsile(string fromBr, string toBr, bool inout, string sourceBr, DateTime date)
        {
            IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectDataForTransactionReconsile");
            query.SetString("frombranch", fromBr);
            query.SetString("tobranch", toBr);
            query.SetBoolean("inout", inout);
            query.SetDateTime("datetime", date);
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00004> result = query.List<TLMDTO00004>();
            return result;
        }

         public IList<TLMDTO00004> SelectAll(string SourceBranchCode)
         {
             IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectAll");
             query.SetString("SourceBranchCode", SourceBranchCode);
             return query.List<TLMDTO00004>(); 
         }


         [Transaction(TransactionPropagation.Required)]
         public void DeleteIBLTLF(string SourceBranchCode)
         {
             IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.DeleteAll");
             query.SetString("SourceBranchCode", SourceBranchCode);
             query.ExecuteUpdate();
         }

         [Transaction(TransactionPropagation.Required)]
         public IList<TLMDTO00004> SelectChargesByEntryNo(string entryno, string sourceBr)
         {
             IQuery query = this.Session.GetNamedQuery("TLMDAO00004.SelectCharegsByGroupNo");
             query.SetString("entryno", entryno);
             query.SetString("sourceBr", sourceBr);            
             return query.List<TLMDTO00004>();
             //return query.UniqueResult<TLMDTO00004>();
         }

         [Transaction(TransactionPropagation.Required)]
         public string SelectDistinctAccountNoByEno(string entryno,string sourcebr,string trantype)
         {
             IQuery query = this.Session.GetNamedQuery("IBLTLFDAO.SelectDistinctAccountNoByEno");
             query.SetString("eno", entryno);
             query.SetDateTime("datetime", DateTime.Now);
             query.SetString("sourcebr", sourcebr);
             query.SetString("trantype",trantype);
             return query.UniqueResult<TLMDTO00004>().AccountNo;
         }


    }
}
