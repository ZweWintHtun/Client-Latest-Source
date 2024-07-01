using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00081 : DataRepository<PFMORM00032>, IMNMDAO00081
    {
        public IList<MNMDTO00081> SelectFreceipt(string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMORM00032.InterestOutstanding");
            query.SetString("sourceBranch", branchCode);

            return query.List<MNMDTO00081>();
        }
    }
}
