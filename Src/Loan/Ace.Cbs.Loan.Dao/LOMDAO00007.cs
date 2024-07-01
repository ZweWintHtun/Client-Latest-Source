//----------------------------------------------------------------------
// <copyright file="LOMDAO00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/25/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using System;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00007 : DataRepository<LOMORM00007>, ILOMDAO00007
    {

        #region Implementation

        public bool CheckExist(string code, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("GJTDAO.CheckExist");
            query.SetString("code", code);
            query.SetString("description", desp);
            IList<LOMDTO00007> GJTCodeList = query.List<LOMDTO00007>();
            return GJTCodeList == null ? false : this.CheckDTOList(GJTCodeList, code, isEdit);
        }
        public IList<LOMDTO00007> CheckExist2(string code, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("GJTDAO.CheckExist2");
            query.SetString("code", code);
            query.SetString("description", desp);
            IList<LOMDTO00007> GJTCodeList = query.List<LOMDTO00007>();
            return GJTCodeList;
        }

        public IList<LOMDTO00007> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("GJTDAO.SelectAll");
            return query.List<LOMDTO00007>();
        }

        public LOMDTO00007 SelectByGjtype(string code)
        {
            IQuery query = this.Session.GetNamedQuery("GJTDAO.SelectByCode");
            query.SetString("code", code);
            return query.UniqueResult<LOMDTO00007>();
        }

        public void ManualUpdate(LOMORM00007 entity)
        {
            IQuery query = this.Session.GetNamedQuery("GJTDAO.Update");
            query.SetString("code", entity.Code);
            query.SetString("desp", entity.Description);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", entity.UpdatedUserId.Value);
            query.ExecuteUpdate();
        }

        #endregion

        #region Helper Methods

        private bool CheckDTOList(IList<LOMDTO00007> gJTCodeList, string gjtype, bool isEdit)
        {
            foreach (LOMDTO00007 info in gJTCodeList)
            {
                if (info.Code != gjtype && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        #endregion
    }
}