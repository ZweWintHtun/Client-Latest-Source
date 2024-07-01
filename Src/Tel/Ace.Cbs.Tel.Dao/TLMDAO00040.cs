//----------------------------------------------------------------------
// <copyright file="TLMDAO00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
    public class TLMDAO00040 : DataRepository<TLMORM00040>, ITLMDAO00040
    {
        public bool CheckExist(string bCode, string bDesp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("BCodeDAO.CheckExist");
            query.SetString("bCode", bCode);
            query.SetString("bDesp", bDesp);
            IList<TLMDTO00040> BCodeList = query.List<TLMDTO00040>();
            return BCodeList == null ? false : this.CheckDTOList(BCodeList, bCode, isEdit);
        }

  public IList<TLMDTO00040> CheckExist2(string bCode, string bDesp)
        {
            IQuery query = this.Session.GetNamedQuery("BCodeDAO.CheckExist2");
            query.SetString("bCode", bCode);
            query.SetString("bDesp", bDesp);
            IList<TLMDTO00040> BCodeList = query.List<TLMDTO00040>();
            return BCodeList;
        }
        public IList<TLMDTO00040> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("BCodeDAO.SelectAll");
            return query.List<TLMDTO00040>();
        }

        public TLMDTO00040 SelectByBCode(string bCode)
        {
            IQuery query = this.Session.GetNamedQuery("BCodeDAO.SelectByBCode");
            query.SetString("bCode", bCode);
            return query.UniqueResult<TLMDTO00040>();
        }

        private bool CheckDTOList(IList<TLMDTO00040> bCodeList, string bCode, bool isEdit)
        {
            foreach (TLMDTO00040 info in bCodeList)
            {
                if (info.BCode != bCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}