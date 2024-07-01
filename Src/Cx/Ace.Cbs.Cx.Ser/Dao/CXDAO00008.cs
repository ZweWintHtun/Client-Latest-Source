using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;
namespace Ace.Cbs.Cx.Ser.Dao
{
    [Repository]
    public class CXDAO00008 : DataRepository<TLMORM00001>, ICXDAO00008
    {
        public TLMDTO00001 GetREByRegisterNo(string registerNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00008.SelectByRERegisterNo");
            query.SetString("registerNo", registerNo);
            TLMDTO00001 re = query.UniqueResult<TLMDTO00001>();
            return re;
        }

        public TLMDTO00017 GetRDByRegisterNo(string registerNo)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00008.SelectByRDRegisterNo");
            query.SetString("registerNo", registerNo);
            TLMDTO00017 rd = query.UniqueResult<TLMDTO00017>();
            return rd;
        }

    
    }
}
