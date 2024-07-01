//----------------------------------------------------------------------
// <copyright file="TLMDAO00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NL</CreatedUser>
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
    public class TLMDAO00035 : DataRepository<TLMORM00035>, ITLMDAO00035
    {
        public bool CheckExist(int id, decimal value,string code)
        {
            IQuery query = this.Session.GetNamedQuery("MonthKeyDAO.CheckExist");
            query.SetDecimal("value", value);
            query.SetString("code", code);
            IList<TLMDTO00035> monthKeyResults = query.List<TLMDTO00035>();
            return monthKeyResults.Count == 0 ? false : this.CheckList(monthKeyResults, id, code, value);
        }

        public bool CheckList(IList<TLMDTO00035> monthKeyResults, int id, string code, decimal value)
        {
            foreach (TLMDTO00035 monthKey in monthKeyResults)
            {
                if (monthKey.Id == id)
                {

                    for (int i = 0; i < monthKeyResults.Count; i++)
                    {
                        if ((monthKey.Id != monthKeyResults[i].Id) && (monthKeyResults[i].Code == code || monthKeyResults[i].Value == value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public IList<TLMDTO00035> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("MonthKeyDAO.SelectAll");
            return query.List<TLMDTO00035>();
        }

        public TLMDTO00035 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("MonthKeyDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00035>();
        }

    }
}