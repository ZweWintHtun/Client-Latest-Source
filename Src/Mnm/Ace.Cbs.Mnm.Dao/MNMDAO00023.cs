//----------------------------------------------------------------------
// <copyright file="MNMDAO00023.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00023 : DataRepository<MNMORM00023>, IMNMDAO00023
    {
        #region Unused
        public IList<MNMDTO00023> SelectAll(DateTime startdate, DateTime enddate, string workStation,string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("VW_SelectAll");
            query.SetDateTime("startdate", startdate);
            query.SetDateTime("enddate", enddate);
            query.SetString("workStation", workStation);
            query.SetString("sourceBr", branchCode);
            return query.List<MNMDTO00023>();
        }
        #endregion

        public bool DeleteAdjRemitScharge(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DeleteAdjRemitScharge");
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }
    }
}
