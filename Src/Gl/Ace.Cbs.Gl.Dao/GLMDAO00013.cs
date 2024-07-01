using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00013 : DataRepository<GLMVIW00013>, IGLMDAO00013
    {
        public IList<GLMDTO00013> SelectDataOrderByACode(string sourceBr)
        {
            IQuery Query = this.Session.GetNamedQuery("GLMVIW00013.SelectDataOrderByACode");
            Query.SetString("sourceBr", sourceBr);
            return Query.List<GLMDTO00013>();
        }
    }
}