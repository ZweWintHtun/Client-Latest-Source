//----------------------------------------------------------------------
// <copyright file="TLMDAO00059.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> NYO ME SAN </CreatedUser>
// <CreatedDate> 2013.8.21 </CreatedDate>
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
    public class TLMDAO00057 : DataRepository<TLMVIW00015>, ITLMDAO00057
    {
        public IList<TLMDTO00017> SelectDrawingRegisterOutstanding(string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00057.SelectDrawingRemittanceRegisterOutstanding");
                query.SetString("sourceBr", sourceBr);
                IList<TLMDTO00017> list = query.List<TLMDTO00017>();
                return list;
            }

            catch
            {
                IList<TLMDTO00017> list = new List<TLMDTO00017>();
                return list; 
            }

        }

        public IList<TLMDTO00017> SelectDrawingRegisterOutstandingByIncomeOutstand(string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00057.SelectDrawingRemittanceRegisterOutstandingByIncomeOutstanding");
                query.SetString("sourceBr", sourceBr);
                IList<TLMDTO00017> list = query.List<TLMDTO00017>();
                return list;
            }
            catch
            {
                IList<TLMDTO00017> list = new List<TLMDTO00017>();
                return list;
            }

        }

        public IList<TLMDTO00017> SelectDrawingRegisterOutstandingByDrawingAmountOutstand(string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("TLMDAO00057.SelectDrawingRemittanceRegisterOutstandingByDrawingAmountOutstanding");
                query.SetString("sourceBr", sourceBr);                
                IList<TLMDTO00017> list = query.List<TLMDTO00017>();
                return list;
            }
            catch
            {
                IList<TLMDTO00017> list = new List<TLMDTO00017>();
                return list;
            }


        }
    }
}
