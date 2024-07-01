using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Ctr.Dao;

namespace Ace.Cbs.Pfm.Dao
{
    class PFMDAO00024 : DataRepository<ChargeOfAccount>, IPFMDAO00024
    {
        public ChargeOfAccountDTO SelectByCode(string aCode, string sourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("COA_SelectByACode");
            query.SetString("aCode", aCode);
            query.SetString("sourceBranchCode", sourceBranchCode);
            return query.UniqueResult<ChargeOfAccountDTO>();
        }
    }
}
