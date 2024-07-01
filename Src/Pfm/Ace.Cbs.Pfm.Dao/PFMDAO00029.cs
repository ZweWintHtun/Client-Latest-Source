using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Pfm.Dao
{
    //LinkAccount (LinkAC)
    public class PFMDAO00029 : DataRepository<PFMORM00029>, IPFMDAO00029
    {
        public bool HasAlreadyLinkAccount(string currentAccountNo, string savingAccountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00029.LinkAC_HasAlreadyLinkAccount");
            query.SetString("currentAccountNo", currentAccountNo);
            query.SetString("savingAccountNo", savingAccountNo);
            string sql = this.GetSQLString(query.QueryString);
            IList<PFMDTO00029> linkAccountList = query.List<PFMDTO00029>();
            return linkAccountList.Count > 0  ? true : false;
            
        }

        public PFMDTO00029 SelectLinkAmount(string currentAccountNo, string savingAccountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00029.LinkAC_SelectLinkAmount");
            query.SetString("currentAccountNo", currentAccountNo);
            query.SetString("savingAccountNo", savingAccountNo);
            string sql = this.GetSQLString(query.QueryString);
            return query.UniqueResult<PFMDTO00029>();
        }

        
    }
}