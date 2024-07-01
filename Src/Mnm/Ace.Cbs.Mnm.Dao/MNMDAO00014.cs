//----------------------------------------------------------------------
// <copyright file="MNMDAO00014.cs" company="ACE Data Systems">
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
    public class MNMDAO00014 : DataRepository<MNMORM00014>, IMNMDAO00014
    {

        public bool CheckExist(string aCCTNO, string uID, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("CIDAO.CheckExist");
            query.SetString("aCCTNO", aCCTNO);
            query.SetString("uID", uID);
            IList<MNMDTO00014> CIList = query.List<MNMDTO00014>();
            return CIList == null ? false : this.CheckDTOList(CIList, aCCTNO, isEdit);
        }

        public IList<MNMDTO00014> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("CIDAO.SelectAll");
            return query.List<MNMDTO00014>();
        }

        public MNMDTO00014 SelectByACCTNO(string aCCTNO)
        {
            IQuery query = this.Session.GetNamedQuery("CIDAO.SelectByACCTNO");
            query.SetString("aCCTNO", aCCTNO);
            return query.UniqueResult<MNMDTO00014>();
        }

        private bool CheckDTOList(IList<MNMDTO00014> cIList, string aCCTNO, bool isEdit)
        {
            foreach (MNMDTO00014 info in cIList)
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