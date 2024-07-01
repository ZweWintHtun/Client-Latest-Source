//----------------------------------------------------------------------
// <copyright file="MNMDAO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dao;
using Ace.Cbs.Mnm.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00015 : DataRepository<MNMORM00015>, IMNMDAO00015
    {

        public bool CheckExist(string aCCTNO, string uID, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("PREV_CIDAO.CheckExist");
            query.SetString("aCCTNO", aCCTNO);
            query.SetString("uID", uID);
            IList<MNMDTO00015> PREV_CIList = query.List<MNMDTO00015>();
            return PREV_CIList == null ? false : this.CheckDTOList(PREV_CIList, aCCTNO, isEdit);
        }

        public IList<MNMDTO00015> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("PREV_CIDAO.SelectAll");
            return query.List<MNMDTO00015>();
        }

        public MNMDTO00015 SelectByACCTNO(string aCCTNO)
        {
            IQuery query = this.Session.GetNamedQuery("PREV_CIDAO.SelectByACCTNO");
            query.SetString("aCCTNO", aCCTNO);
            return query.UniqueResult<MNMDTO00015>();
        }

        private bool CheckDTOList(IList<MNMDTO00015> pREV_CIList, string aCCTNO, bool isEdit)
        {
            foreach (MNMDTO00015 info in pREV_CIList)
            {
                if (info.ACCTNO != aCCTNO && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}