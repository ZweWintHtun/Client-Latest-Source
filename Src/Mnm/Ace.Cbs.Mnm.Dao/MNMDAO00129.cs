using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00129 : DataRepository<PFMORM00029> , IMNMDAO00129
    {
        public IList<PFMDTO00029> SelectForLinkAutoPriority(string SourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectForLinkAutoPriority");
            query.SetString("SourceBr", SourceBr);
            IList<PFMDTO00029> LinkAutolist = query.List<PFMDTO00029>();
            return LinkAutolist;
        }
        

    }
}
