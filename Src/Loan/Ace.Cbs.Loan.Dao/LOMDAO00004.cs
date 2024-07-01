//----------------------------------------------------------------------
// <copyright file="LONDAO00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/18/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00004 : DataRepository<LOMORM00004>, ILOMDAO00004
    {

        public bool CheckExist(string iNSUCODE, string iNSUDESP, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("INSURANDAO.CheckExist");
            query.SetString("iNSUCODE", iNSUCODE);
            query.SetString("iNSUDESP", iNSUDESP);
            IList<LOMDTO00004> INSURANList = query.List<LOMDTO00004>();
            return INSURANList == null ? false : this.CheckDTOList(INSURANList, iNSUCODE, isEdit);
        }
        
        public IList<LOMDTO00004> CheckExist2(string iNSUCODE, string iNSUDESP)
        {
            IQuery query = this.Session.GetNamedQuery("INSURANDAO.CheckExist2");
            query.SetString("iNSUCODE", iNSUCODE);
            query.SetString("iNSUDESP", iNSUDESP);
            IList<LOMDTO00004> INSURANList = query.List<LOMDTO00004>();
            return INSURANList;
        }

        public IList<LOMDTO00004> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("INSURANDAO.SelectAll");
            return query.List<LOMDTO00004>();
        }

        public LOMDTO00004 SelectByINSUCODE(string iNSUCODE)
        {
            IQuery query = this.Session.GetNamedQuery("INSURANDAO.SelectByINSUCODE");
            query.SetString("iNSUCODE", iNSUCODE);
            return query.UniqueResult<LOMDTO00004>();
        }

        private bool CheckDTOList(IList<LOMDTO00004> iNSURANList, string iNSUCODE, bool isEdit)
        {
            foreach (LOMDTO00004 info in iNSURANList)
            {
                if (info.INSUCODE != iNSUCODE && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}