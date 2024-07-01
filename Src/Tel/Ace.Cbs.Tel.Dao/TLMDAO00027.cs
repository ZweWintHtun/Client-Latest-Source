//----------------------------------------------------------------------
// <copyright file="TLMDAO00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
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
    public class TLMDAO00027 : DataRepository<TLMORM00027>, ITLMDAO00027
    {
        public bool CheckExist(int id, string bRANCHNO, string ipaddress)
        {
            IQuery query = this.Session.GetNamedQuery("SERVERLOGDAO.CheckExist");
            query.SetString("bRANCHNO", bRANCHNO);
            query.SetString("ipaddress", ipaddress);
            TLMDTO00027 SERVERLOG = query.UniqueResult<TLMDTO00027>();
            return SERVERLOG == null ? false : (SERVERLOG.Id == id ? false : true);
        }
        public IList<TLMDTO00027> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("SERVERLOGDAO.SelectAll");
            return query.List<TLMDTO00027>();
        }

        public TLMDTO00027 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("SERVERLOGDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00027>();
        }



    }
}
