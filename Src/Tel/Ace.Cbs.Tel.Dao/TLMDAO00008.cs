//----------------------------------------------------------------------
// <copyright file="TLMDAO00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KoKoTun</CreatedUser>
// <CreatedDate>01/24/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Dao;
using Ace.Cbs.Tel.Dao;
using NHibernate;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Dao
{
	public class TLMDAO00008 : DataRepository<TLMORM00008>, ITLMDAO00008
    {
		public bool CheckExist(int id,string eNO,string dEPCODE ,string aCCTNO ,string nAME ,decimal qTY ,decimal aMOUNT ,string qUOTANO ,string uID )
        {
            IQuery query = this.Session.GetNamedQuery("DEP_TLFDAO.CheckExist");
			query.SetString("eNO", eNO);
            query.SetString("dEPCODE", dEPCODE); 
            query.SetString("aCCTNO", aCCTNO); 
            query.SetString("nAME", nAME); 
            query.SetDecimal("qTY", qTY); 
            query.SetDecimal("aMOUNT", aMOUNT); 
            query.SetString("qUOTANO", qUOTANO); 
            query.SetString("uID", uID); 
            TLMDTO00008 DEP_TLF = query.UniqueResult<TLMDTO00008>();
            return DEP_TLF == null ? false : (DEP_TLF.Id == id ? false : true);
        }
        public IList<TLMDTO00008> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("DEP_TLFDAO.SelectAll");
            return query.List<TLMDTO00008>();
        }

        public TLMDTO00008 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("DEP_TLFDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00008>();
        }
		


	}
}
