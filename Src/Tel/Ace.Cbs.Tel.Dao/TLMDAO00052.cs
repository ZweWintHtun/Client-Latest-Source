//----------------------------------------------------------------------
// <copyright file="TLMDAO00052.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-11 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using System.Linq;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00052 : DataRepository<TLMVIW00052>, ITLMDAO00052
    {
        #region "For TransactionDate"
        public IList<PFMDTO00042> SelectTransactionDateWithReversalByHome(PFMDTO00042 bankCashDTO)
        {
            DateTime startDate = bankCashDTO.StartDate.Date.AddDays(-1);
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("workstation", bankCashDTO.WorkStation);       
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectTransactionDateWithReversalByCurrencyCode(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalByCurCodeTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;

        }
        #endregion

        #region "For SettlementDate
        public IList<PFMDTO00042> SelectWithReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalSettlementDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        public IList<PFMDTO00042> SelectWithReversalByCurrencyCodeSettlementDate(PFMDTO00042 bankCashDTO)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00052.SelectAllByBankCashWithReversalByCurCodeTransactionDate");
            query.SetString("datetime", bankCashDTO.StartDate.ToString("yyyy/MM/dd"));
            query.SetString("sourcebr", bankCashDTO.SourceBranch);
            query.SetString("currency", bankCashDTO.CurCode);
            query.SetString("workstation", bankCashDTO.WorkStation);
            string sqlquerystring = this.GetSQLString(query.QueryString);
            IList<PFMDTO00042> list = query.List<PFMDTO00042>();
            return list;
        }

        #endregion

    }
}
