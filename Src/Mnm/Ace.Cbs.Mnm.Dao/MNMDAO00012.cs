//----------------------------------------------------------------------
// <copyright file="MNMDAO00012.cs" company="ACE Data Systems">
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
    public class MNMDAO00012 : DataRepository<MNMORM00012>, IMNMDAO00012
    {

        public bool CheckExist(string lNO, string aCCTNO, decimal aMOUNT, DateTime dATE_TIME, string cRACCTNO, string uSERNO, string uID, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("LEGALINTDAO.CheckExist");
            query.SetString("lNO", lNO);
            query.SetString("aCCTNO", aCCTNO);
            query.SetDecimal("aMOUNT", aMOUNT);
            query.SetDateTime("dATE_TIME", dATE_TIME);
            query.SetString("cRACCTNO", cRACCTNO);
            query.SetString("uSERNO", uSERNO);
            query.SetString("uID", uID);
            IList<MNMDTO00012> LEGALINTList = query.List<MNMDTO00012>();
            return LEGALINTList == null ? false : this.CheckDTOList(LEGALINTList, lNO, isEdit);
        }

        public IList<MNMDTO00012> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("LEGALINTDAO.SelectAll");
            return query.List<MNMDTO00012>();
        }

        public MNMDTO00012 SelectByLNO(string lNO)
        {
            IQuery query = this.Session.GetNamedQuery("LEGALINTDAO.SelectByLNO");
            query.SetString("lNO", lNO);
            return query.UniqueResult<MNMDTO00012>();
        }

        private bool CheckDTOList(IList<MNMDTO00012> lEGALINTList, string lNO, bool isEdit)
        {
            foreach (MNMDTO00012 info in lEGALINTList)
            {
                if (info.LNo != lNO && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        public IList<MNMDTO00012> SelectLegalIntList(string[] typelist, string loanNo, string branchCode)
        {

            IQuery query = this.Session.GetNamedQuery("MNMDAO00012.SelectLegalIntByloanNo");
            query.SetString("loanNo", loanNo);
            query.SetParameterList("typelist", typelist);
            query.SetString("sourceBr", branchCode);

            return query.List<MNMDTO00012>();
        }

        public IList<MNMDTO00012> SelectByLoanNo(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00012.SelectByLoanNo");
            query.SetString("loanNo", loanNo);
            return query.List<MNMDTO00012>();
        }
    }
}