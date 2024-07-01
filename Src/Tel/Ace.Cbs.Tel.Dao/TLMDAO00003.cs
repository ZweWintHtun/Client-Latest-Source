//----------------------------------------------------------------------
// <copyright file="TLMDAO00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00003 : DataRepository<TLMORM00003>, ITLMDAO00003
    {
        public bool CheckExist(int id, decimal rate, decimal fixAmt, decimal startNo, decimal endNo, string cur)
        {
            IQuery query = this.Session.GetNamedQuery("PORateDAO.CheckExist");
            query.SetDecimal("rate", rate);
            query.SetDecimal("fixAmt", fixAmt);
            query.SetDecimal("startNo", startNo);
            query.SetDecimal("endNo", endNo);
            query.SetString("cur", cur);
            TLMDTO00003 PORate = query.UniqueResult<TLMDTO00003>();
            return PORate == null ? false : (PORate.Id == id ? false : true);
        }
        public IList<TLMDTO00003> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("PORateDAO.SelectAll");
            return query.List<TLMDTO00003>();
        }

        public TLMDTO00003 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("PORateDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00003>();
        }

        public IList<CurrencyDTO> SelectCurrency()
        {
            IQuery query = this.Session.GetNamedQuery("PORate.SelectCurrency");
            IList<CurrencyDTO> list = query.List<CurrencyDTO>();
            return list;
        }

        public IList<TLMDTO00003> SelectAllPORateByCurrency(string currency)
        {
            IQuery query = this.Session.GetNamedQuery("PORateDAO.SelectAllPORateByCurrency");
            query.SetString("currency", currency);
            IList<TLMDTO00003> PORateList = query.List<TLMDTO00003>();
            return PORateList;
        }
    }

}