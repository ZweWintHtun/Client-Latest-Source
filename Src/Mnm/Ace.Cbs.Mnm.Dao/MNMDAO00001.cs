using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00001 : DataRepository<MNMORM00001>, IMNMDAO00001
    {
        public string SelectbyYearpost(string name,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("Syspost.SelectbyPostyear");
            query.SetString("name", name);
            query.SetString("sourceBr", sourceBr);
            MNMDTO00001 syspost = query.UniqueResult<MNMDTO00001>();
            return syspost== null? string.Empty : syspost.Date_time.ToString();

        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateStatus(DateTime datetime, string postingname, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("Syspost.Updatestatus");
            query.SetDateTime("datetime", datetime);
            query.SetString("postingname", postingname);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        public IList<MNMDTO00001> SelectPostDateByPostName(string sourceBr)    //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("Syspost.SelectPostDateByPostName");
            query.SetString("sourceBr", sourceBr);
            IList<MNMDTO00001> sysPostList = query.List<MNMDTO00001>();
            return sysPostList;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateStatusByBranchCode(DateTime datetime, string postingname, string sourceBr, int updatedUserId) //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("Syspost.UpdatestatusByBranchCode");
            query.SetDateTime("datetime", datetime);
            query.SetDateTime("updatedDate", datetime);            
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("postingname", postingname);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }
    }
}
