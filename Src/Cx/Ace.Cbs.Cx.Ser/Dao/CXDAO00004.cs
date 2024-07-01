using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Cx.Ser.Dao
{
    public class CXDAO00004 : DataRepository<PFMORM00054>, ICXDAO00004
    {
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectMaxId");
            PFMDTO00054 dto = query.UniqueResult<PFMDTO00054>();
            return dto.Id;
        }   
    }
}
