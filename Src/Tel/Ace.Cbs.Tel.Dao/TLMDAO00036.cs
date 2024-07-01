//----------------------------------------------------------------------
// <copyright file="TLMDAO00036.cs" company="ACE Data Systems">
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
    public class TLMDAO00036 : DataRepository<TLMORM00036>, ITLMDAO00036
    {
        public bool CheckExist(int id, decimal value,string code)
        {
            IQuery query = this.Session.GetNamedQuery("AmountKeyDAO.CheckExist");
            query.SetDecimal("value", value);
            query.SetString("code", code);
            IList<TLMDTO00036> amountKeyResults = query.List<TLMDTO00036>();
            return amountKeyResults.Count == 0 ? false : this.CheckList(amountKeyResults, id, code, value);
        }

        public bool CheckList(IList<TLMDTO00036> amountKeyResults, int id, string code, decimal value)
        {
            foreach (TLMDTO00036 amountKey in amountKeyResults)
            {
                if (amountKey.Id == id)
                {

                    for (int i = 0; i < amountKeyResults.Count; i++)
                    {
                        if ((amountKey.Id != amountKeyResults[i].Id) && (amountKeyResults[i].Code == code || amountKeyResults[i].Value == value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public IList<TLMDTO00036> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("AmountKeyDAO.SelectAll");
            IList<TLMDTO00036> list = query.List<TLMDTO00036>();
            return list;
        }

        public TLMDTO00036 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("AmountKeyDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00036>();
        }

    }
}