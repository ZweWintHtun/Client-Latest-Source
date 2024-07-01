//----------------------------------------------------------------------
// <copyright file="TLMDAO00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Data.NHibernate.Support;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00031 : DataRepository<TLMORM00031>, ITLMDAO00031
    {
        public bool CheckExist(int id, string zONETYPE, string brCode, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("ZoneDAO.CheckExist");
            //query.SetString("zONETYPE", zONETYPE);
            query.SetString("brCode", brCode);
            query.SetString("SourceBranchCode", SourceBranchCode);
            TLMDTO00031 Zone = query.UniqueResult<TLMDTO00031>();
            return Zone == null ? false : (Zone.Id == id ? false : true);
        }
        public IList<TLMDTO00031> SelectAll(string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("ZoneDAO.SelectAll");
            query.SetString("sourcebr", sourcebr);
            return query.List<TLMDTO00031>();
        }

        public TLMDTO00031 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("ZoneDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00031>();
        }

        public IList<TLMDTO00031> SelectAllByDistinct()
        {
            IQuery query = this.Session.GetNamedQuery("ZoneDAO.SelectAllByDistinct");
            return query.List<TLMDTO00031>();
        }

        public bool CheckAccountCode(string aCode)
        {
            IQuery query = this.Session.GetNamedQuery("ZoneDAO.CheckAccountCode");
            query.SetString("aCode", aCode);
            IList<ChargeOfAccountDTO> result = query.List<ChargeOfAccountDTO>();
            return result.Count == 0 ? false : true;
        }

    }
}