//----------------------------------------------------------------------
// <copyright file="PFMDAO00056.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Khin Phyu Lin</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    //Sys001 DAO
    class PFMDAO00056 : DataRepository<PFMORM00056>, IPFMDAO00056
    {
        public PFMDTO00056 SelectSys001Info(string sourcebr, string name)   //added by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.SelectSys001Info");
            query.SetString("name", name);
            query.SetString("sourcebr", sourcebr);
            PFMDTO00056 sys001 = query.UniqueResult<PFMDTO00056>();
            return sys001;
        }

        public bool UpdateStatusByName(int updatedUserId, string name,string status,DateTime datetime)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.UpdateStatusByName");
            query.SetString("status",status);
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updatedDate", datetime);
            query.SetString("name", name);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateStatusByNameForLoanVoucher(int updatedUserId,string status, DateTime datetime,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.UpdateStatusByNameForLoanVoucher");
            query.SetString("status", status);
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updatedDate", datetime);
            query.SetString("sourcebr",sourcebr);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00056> CheckExist2(int id, string name)
        {
            IQuery query;
            if (id == 0)
            {
                query = this.Session.GetNamedQuery("Sys001DAO.CheckExist");
                query.SetString("name", name);
            }
            else
            {
                query = this.Session.GetNamedQuery("Sys001DAO.CheckExist2");
                query.SetString("name", name);
                query.SetInt32("id", id);
            }           
            IList<PFMDTO00056> Sys001 = query.List<PFMDTO00056>();
           
            //return Sys001.Count == 0 ? false : Sys001.Count == Convert.ToInt32(branchCount)? true : false;  //if sys001.count=0 ,no data exist.
            //if count > 0 , check equal with branchcount or not , if yes/ all branchs data exist.if no/ some branches exist. allow to save.

            //return Sys001.Count == 0 ? false : this.CheckBranchCount(Sys001.Count, branchCount, Sys001);  //if sys001.count=0 ,no data exist.
            return Sys001;
        }

        //public bool CheckBranchCount(int sys001Count, string branchCount, IList<PFMDTO00056> sys001List)
        //{
        //    if (sys001Count == Convert.ToInt32(branchCount))
        //        return true;
        //    else
        //    {
        //        this.ConvertToORM(sys001List);
        //        return false;
        //    }
        //}
        //public void ConvertToORM(IList<PFMDTO00056> sys001List)
        //{
        //    foreach (PFMDTO00056 sys001DTO in sys001List)
        //    {
        //        PFMORM00056 sys001ORM = new PFMORM00056();

        //        sys001ORM.Id = sys001DTO.Id;
        //        sys001ORM.Name = sys001DTO.Name;
        //        sys001ORM.SysMonYear = sys001DTO.SysMonYear;
        //        sys001ORM.Status = sys001DTO.Status;                
        //        sys001ORM.SysDate = DateTime.Now;
        //        sys001ORM.SysQty = sys001DTO.SysQty;
        //        sys001ORM.BranchCode = sys001DTO.BranchCode;
        //        sys001ORM.TS = sys001DTO.TS;
        //        sys001ORM.CreatedUserId = sys001DTO.CreatedUserId;
        //        sys001ORM.CreatedDate = DateTime.Now;
        //        sys001ORM.UpdatedUserId = sys001DTO.UpdatedUserId;
        //        sys001ORM.UpdatedDate = DateTime.Now;
        //        sys001ORM.Active = false;
        //        this.Delete(sys001ORM, true);
        //    }
        //}

        public bool CheckExist(int id, string name)
        {
            IQuery query;
            if (id == 0)
            {
                query = this.Session.GetNamedQuery("Sys001DAO.CheckExist");
                query.SetString("name", name);
            }
            else
            {
                query = this.Session.GetNamedQuery("Sys001DAO.CheckExist2");
                query.SetString("name", name);
                query.SetInt32("id", id);
            }            
            IList<PFMDTO00056> Sys001 = query.List<PFMDTO00056>();
            //return Sys001 == null ? false : (Sys001.Id == id ? false : true);
            // return Sys001.Count == 0 ? false : true;
            return Sys001.Count == 0 ? false : true;
        }

        public IList<PFMDTO00056> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectAll");
            return query.List<PFMDTO00056>();
        }

        public PFMDTO00056 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<PFMDTO00056>();
        }

        public Boolean SelectbyMonthClose(string name,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectByMonthclose");
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            PFMDTO00056 sys001 = query.UniqueResult<PFMDTO00056>();
            return sys001 == null ? false : (sys001.Status == "A" ? true : false);

        }
        public string Selectpostyear(string name, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectByMonthclose");
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            PFMDTO00056 sys001 = query.UniqueResult<PFMDTO00056>();
            return sys001.SysMonYear;
        }

   
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDatePosting(string name,string sourceBr,int updateUserID)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.UpdateDate");
            query.SetDateTime("sysdate", DateTime.Now);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updateduserid", updateUserID);
            query.SetString("branchCode", sourceBr);
            query.SetString("name", name);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDateDailyPosting(string name, DateTime date, string sourceBr, int updateUserID)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.UpdateDate");
            query.SetDateTime("sysdate", date);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updateduserid", updateUserID);
            query.SetString("branchCode", sourceBr);
            query.SetString("name", name);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public DateTime SelectSysDate(string name, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectSysDate");
            query.SetString("name", name);
            query.SetString("branchCode", sourceBr);

            //return query.UniqueResult<DateTime>();

            DateTime SysDate = query.UniqueResult<DateTime>();
            return SysDate;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateSysDateForCutOff(string branchCode, DateTime nextSettlementDate, DateTime lastSettlementDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.UpdateSysDateForCutOff");
            query.SetDateTime("lastSettlementDate", lastSettlementDate);
            query.SetDateTime("nextSettlementDate", nextSettlementDate);
            query.SetString("branchCode", branchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }
        public string Selectmonthstatus(string name,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectByMonthclose");
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            PFMDTO00056 sys001 = query.UniqueResult<PFMDTO00056>();
            return sys001.Status;
        }

        public PFMDTO00056 SelectAllByName(string name,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectAllByName");
            query.SetString("name", name);
            query.SetString("sourcebr", sourcebr);
            return query.UniqueResult<PFMDTO00056>();
        }

        public IList<PFMDTO00056> SelectSys001ForMonthBefore(string sourceBr)           //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectForMonthBefore");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00056> List = query.List<PFMDTO00056>();
            return List;
        }

        public PFMDTO00056 SelectAllByNameAndSysDateAndStatus(string name, string status)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectAllByNameAndSysDateAndStatus");
            query.SetString("name", name);
            query.SetString("status", status);
            query.SetDateTime("sysDate", DateTime.Now);
            return query.UniqueResult<PFMDTO00056>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateStatusSys001(int updatedUserId, string name, string status, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.UpdateStatusSys001");
            query.SetString("status", status);
            query.SetInt32("updateduserid", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("name", name);
            query.SetString("BranchCode", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateSysMonYear(string sysMonYear, int updatedUserId, string name, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.UpdateSysMonYear");
            query.SetString("sysMonYear", sysMonYear);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }    

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateStatusAndSysMonYear(string status, string sysMonYear, DateTime sysDate, int updatedUserId, string name, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00056.UpdateStatusAndSysMonYear");
            query.SetString("status", status);
            query.SetString("sysMonYear", sysMonYear);
            query.SetDateTime("sysDate", sysDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        //public IList<PFMDTO00056> SelectDataForCutOffandCashClosing(string nextName, string lastName,string branchCode)
        //{
        //    IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectDataForCutOffandCashClosing");
        //    query.SetString("nextName", nextName);
        //    query.SetString("lastName", lastName);
        //    query.SetString("branchCode", branchCode);
        //    return query.List<PFMDTO00056>();
        //}
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateSysDateForFixedAutoRenewaProcess(string branchCode, DateTime fixIntDate, DateTime fixVouDate, DateTime fixIntCal, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.UpdateSys001ForFixedAutoRenewalProcess");
            query.SetDateTime("fixIntDate", fixIntDate);
            query.SetDateTime("fixVouDate", fixVouDate);
            query.SetDateTime("fixIntCal", fixIntCal);
            query.SetString("branchCode", branchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        //Added by HMW (22-May-2019)
        [Transaction(TransactionPropagation.Required)]
        public IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Sys001DAO.SelectAllAutoPayStatusList");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00056> list = query.List<PFMDTO00056>();
            return list;
        }
    }
}
