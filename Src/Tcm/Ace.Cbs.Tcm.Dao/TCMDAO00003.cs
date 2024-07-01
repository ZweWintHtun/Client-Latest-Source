using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Tcm.Dao
{
    class TCMDAO00003 : DataRepository<TCMORM00003>, ITCMDAO00003
    {
        //public IList<TCMDTO00003> GetNPLIntList(string loanNo, string aType, string sourceBr)
        public IList<TCMDTO00003> GetNPLIntList(string loanNo, IList<string> aType, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00003.GetNPLIntList");
            query.SetString("loanNo", loanNo);
            //query.SetString("aType", aType);
            query.SetParameterList("aType", aType);
            query.SetString("sourceBr", sourceBr);

            return query.List<TCMDTO00003>();
        }

        public bool UpdateNPLIntForNPLRelease(string loanNo, string sourceBr, int updatedUserID)
        {
            IQuery query = this.Session.GetNamedQuery("TCMORM00003.UpdateNPLIntForNPLRelease");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserID);
            return query.ExecuteUpdate() > 0;       
        }
    }
}
