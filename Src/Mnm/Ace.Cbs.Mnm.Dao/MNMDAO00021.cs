//----------------------------------------------------------------------
// <copyright file="MNMDAO00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dao;
using Ace.Cbs.Mnm.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00021 : DataRepository<MNMORM00021>, IMNMDAO00021
    {

        public bool CheckExist(string eNO, string aCCTNO, decimal aMOUNT, decimal hOMEAMOUNT, decimal hOMEAMT, decimal hOMEOAMT, decimal lOCALAMOUNT, decimal lOCALAMT, decimal lOCALOAMT, string sTATUS, string uID, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("INTLFDAO.CheckExist");
            query.SetString("eNO", eNO);
            query.SetString("aCCTNO", aCCTNO);
            query.SetDecimal("aMOUNT", aMOUNT);
            query.SetDecimal("hOMEAMOUNT", hOMEAMOUNT);
            query.SetDecimal("hOMEAMT", hOMEAMT);
            query.SetDecimal("hOMEOAMT", hOMEOAMT);
            query.SetDecimal("lOCALAMOUNT", lOCALAMOUNT);
            query.SetDecimal("lOCALAMT", lOCALAMT);
            query.SetDecimal("lOCALOAMT", lOCALOAMT);
            query.SetString("sTATUS", sTATUS);
            query.SetString("uID", uID);
            IList<MNMDTO00021> INTLFList = query.List<MNMDTO00021>();
            return INTLFList == null ? false : this.CheckDTOList(INTLFList, eNO, isEdit);
        }

        public IList<MNMDTO00021> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("INTLFDAO.SelectAll");
            return query.List<MNMDTO00021>();
        }

        public MNMDTO00021 SelectByENO(string eNO)
        {
            IQuery query = this.Session.GetNamedQuery("INTLFDAO.SelectByENO");
            query.SetString("eNO", eNO);
            return query.UniqueResult<MNMDTO00021>();
        }

        private bool CheckDTOList(IList<MNMDTO00021> iNTLFList, string eNO, bool isEdit)
        {
            foreach (MNMDTO00021 info in iNTLFList)
            {
                if (info.ENO != eNO && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}