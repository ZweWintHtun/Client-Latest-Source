using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using NHibernate;
using System;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using NHibernate.Transform;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00030 : DataRepository<PFMORM00042>, IMNMDAO00030
    {
        public IList<PFMDTO00042> SelectAll(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("ReportTLF.SelectAll");
            query.SetString("sourceBr", sourceBr);
            return query.List<PFMDTO00042>();
        }
        public IList<PFMDTO00042> SelectDistinctACodeFromReportTLF(string dcode)
        {
            IList<PFMDTO00042> result;
            IQuery query = this.Session.GetNamedQuery("SP_SelectDistinctACodeFromReportTLF");
            query.SetString("dcode", dcode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00042)));
            result = query.List<PFMDTO00042>();
            return result;
        }        
    }
}
