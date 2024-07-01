using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00076 : DataRepository<MNMVIW00076>, IMNMDAO00076
    {
        public IList<MNMDTO00076> SelectPoNo(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMVIW00076.SelectPoNo");
            query.SetString("SourceBr", SourceBr);
            return query.List<MNMDTO00076>();
        }
    }
}
