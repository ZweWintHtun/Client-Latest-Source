//----------------------------------------------------------------------
// <copyright file="TLMDAO00037.cs" company="ACE Data Systems">
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
    public class TLMDAO00037 : DataRepository<TLMORM00037>, ITLMDAO00037
    {
        public bool CheckExist(int id, decimal value, string code)
        {
            IQuery query = this.Session.GetNamedQuery("BranchKeyDAO.CheckExist");
            query.SetDecimal("value", value);
            query.SetString("code", code);
            IList<TLMDTO00037> branchKeyResults = query.List<TLMDTO00037>();
            return branchKeyResults.Count == 0 ? false : this.CheckList(branchKeyResults, id, code, value);
        }

        public bool CheckList(IList<TLMDTO00037> branchKeyResults, int id, string code, decimal value)
        {
            foreach (TLMDTO00037 branchKey in branchKeyResults)
            {
                if (branchKey.Id == id)
                {

                    for (int i = 0; i < branchKeyResults.Count; i++)
                    {
                        if ((branchKey.Id != branchKeyResults[i].Id) && (branchKeyResults[i].Code == code || branchKeyResults[i].Value == value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public IList<TLMDTO00037> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("BranchKeyDAO.SelectAll");
            return query.List<TLMDTO00037>();
        }

        public TLMDTO00037 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("BranchKeyDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00037>();
        }

    }
}