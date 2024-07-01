//----------------------------------------------------------------------
// <copyright file="TLMDAO00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;


namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// EncashRemittanceDAO
    /// </summary>
   public class TLMDAO00020:DataRepository<TLMORM00020>,ITLMDAO00020
    {
        public bool CheckExist(string dEPCODE, string dESP, string sourceBr, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.CheckExist");
            query.SetString("dEPCODE", dEPCODE);
            //query.SetString("dESP", dESP);
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00020> DEPOSITCODEList = query.List<TLMDTO00020>();
            return DEPOSITCODEList == null ? false : this.CheckDTOList(DEPOSITCODEList, dEPCODE, isEdit);
        }


        public IList<TLMDTO00020> CheckExist2(string dEPCODE, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.CheckExist2");
            query.SetString("dEPCODE", dEPCODE);
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00020> DEPOSITCODEList = query.List<TLMDTO00020>();
            return DEPOSITCODEList;
        }

        public IList<TLMDTO00020> SelectAll(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.SelectAll");
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00020>();
        }

        public TLMDTO00020 SelectByDEPCODE(string dEPCODE)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.SelectByDEPCODE");
            query.SetString("dEPCODE", dEPCODE);
            return query.UniqueResult<TLMDTO00020>();
        }

        public TLMDTO00020 SelectToTS(string dEPCODE, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.SelectToTS");
            query.SetString("dEPCODE", dEPCODE);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00020>();
        }

        public TLMDTO00020 SelectToDeleteTS(string dEPCODE, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.SelectToTS");
            query.SetString("dEPCODE", dEPCODE);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00020>();
        }

        private bool CheckDTOList(IList<TLMDTO00020> dEPOSITCODEList, string dEPCODE, bool isEdit)
        {
            foreach (TLMDTO00020 info in dEPOSITCODEList)
            {
                if (info.DepositCode != dEPCODE && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        public bool DeleteCode(TLMDTO00020 entity)
        {
            IQuery query = this.Session.GetNamedQuery("DEPOSITCODEDAO.Delete");
            query.SetString("dEPCODE", entity.DepositCode);
            query.SetString("sourceBr", entity.SourceBranchCode);
            query.SetDateTime("updateddate", (System.DateTime)entity.UpdatedDate);
            query.SetInt32("updateduserid", (System.Int32)entity.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }
    }
}
