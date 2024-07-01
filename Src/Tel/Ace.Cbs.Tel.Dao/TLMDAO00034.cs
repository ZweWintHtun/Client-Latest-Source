//----------------------------------------------------------------------
// <copyright file="TLMDAO00034.cs" company="ACE Data Systems">
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
    public class TLMDAO00034 : DataRepository<TLMORM00034>, ITLMDAO00034
    {
        public bool CheckExist(int id,decimal value,string code)
        {
            IQuery query = this.Session.GetNamedQuery("DayKeyDAO.CheckExist");
            query.SetDecimal("value", value);
            query.SetString("code", code);
            IList<TLMDTO00034> dayKeyResults = query.List<TLMDTO00034>();
            return dayKeyResults.Count == 0 ? false : this.CheckList(dayKeyResults,id,code,value);
        }

        public bool CheckList(IList<TLMDTO00034> dayKeyResults, int id,string code,decimal value)
        {
            foreach (TLMDTO00034 dayKey in dayKeyResults)
            {
                if (dayKey.Id == id)
                {

                    for (int i = 0; i < dayKeyResults.Count; i++)
                    {
                        if ((dayKey.Id != dayKeyResults[i].Id) && (dayKeyResults[i].Code == code || dayKeyResults[i].Value == value))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return true;
        }

        public IList<TLMDTO00034> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("DayKeyDAO.SelectAll");
            return query.List<TLMDTO00034>();
        }

        public TLMDTO00034 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("DayKeyDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00034>();
        }

    }
}