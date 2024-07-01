//----------------------------------------------------------------------
// <copyright file="MNMDAO00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00013 : DataRepository<MNMORM00013>, IMNMDAO00013
    {

        public bool CheckExist(DateTime fIXINTDATE, DateTime fIXVOUDATE, string uID, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("DATEFILEDAO.CheckExist");
            query.SetDateTime("fIXINTDATE", fIXINTDATE);
            query.SetDateTime("fIXVOUDATE", fIXVOUDATE);
            query.SetString("uID", uID);
            IList<MNMDTO00013> DATEFILEList = query.List<MNMDTO00013>();
            return DATEFILEList == null ? false : this.CheckDTOList(DATEFILEList, fIXINTDATE, isEdit);
        }

        public IList<MNMDTO00013> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("DATEFILEDAO.SelectAll");
            return query.List<MNMDTO00013>();
        }

        public MNMDTO00013 SelectByFIXINTDATE(DateTime fIXINTDATE)
        {
            IQuery query = this.Session.GetNamedQuery("DATEFILEDAO.SelectByFIXINTDATE");
            query.SetDateTime("fIXINTDATE", fIXINTDATE);
            return query.UniqueResult<MNMDTO00013>();
        }

        private bool CheckDTOList(IList<MNMDTO00013> dATEFILEList, DateTime fIXINTDATE, bool isEdit)
        {
            foreach (MNMDTO00013 info in dATEFILEList)
            {
                if (info.FIXINTDATE != fIXINTDATE && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}