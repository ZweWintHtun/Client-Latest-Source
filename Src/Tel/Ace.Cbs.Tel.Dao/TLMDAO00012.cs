//----------------------------------------------------------------------
// <copyright file="TLMDAO00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System.Linq;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00012 : DataRepository<TLMORM00012>, ITLMDAO00012
    {
        public bool CheckExistForSave(int id, string Cur, string symbol)
        {
            IQuery query = this.Session.GetNamedQuery("DenoDAO.CheckExistForSave");
            query.SetString("Cur", Cur);
            query.SetString("symbol", symbol);
            IList<TLMDTO00012> Deno = query.List<TLMDTO00012>();
            if (Deno.Count == 0)
                return false;
            else
                return true;
        }

        public bool CheckExistForUpdate(int id, string Cur, string symbol)
        {
            IQuery query = this.Session.GetNamedQuery("DenoDAO.CheckExistForUpdate");
            query.SetString("Cur", Cur);
            query.SetString("symbol", symbol);
            IList<TLMDTO00012> Deno = query.List<TLMDTO00012>();
            //if (Deno.Count == 0)
            //    return false;
            //else
            //    return true;
            return Deno.Count == 0 ? false : (Deno[0].Id == id ? false : true);

        }
        //public bool CheckExist( int id,string dESP)
        //{
        //    IQuery query = this.Session.GetNamedQuery("DenoDAO.CheckExist");
        //    query.SetString("dESP", dESP);
        //    TLMDTO00012 Deno = query.UniqueResult<TLMDTO00012>();
        //    return Deno == null ? false : (Deno.Id == id ? false : true);
        //}
        public IList<TLMDTO00012> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("DenoDAO.SelectAll");
            return query.List<TLMDTO00012>();
        }

        public TLMDTO00012 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("DenoDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00012>();
        }

        public IList<string> SelectDescriptionByCurrrency(string currency)
        {
            IQuery query = this.Session.GetNamedQuery("DenoDAO.SelectDescriptionByCurrrency");
            query.SetString("currency", currency);
            IList<TLMDTO00012> deno = query.List<TLMDTO00012>();

            var denos = (from value in deno
                         select value.Description).ToList();

            return denos;
        }



    }
}