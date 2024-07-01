// <CreatedUser>KSW</CreatedUser>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00030 : DataRepository<TLMORM00030>, ITLMDAO00030
    {
        public IList<TLMDTO00030> SelectById(int RemitbrIblID)
        {
            IQuery query = this.Session.GetNamedQuery("IblDwtRateDAO.SelectById");
            query.SetInt32("RemitbrIblID", RemitbrIblID); 
            return query.List<TLMDTO00030>();
        }

        public bool DeleteById(int RemitbrIblID, int userId)
        {
            IQuery query = this.Session.GetNamedQuery("IblDwtRateDAO.DeleteById");
            query.SetDateTime("updatedDate", System.DateTime.Now);
            query.SetInt32("updatedUserId", userId);
            query.SetInt32("RemitbrIblID", RemitbrIblID);
            return query.ExecuteUpdate() > 0 ? true : false;
        }

        public TLMDTO00030 SelectByIdForSaveAppServer(int IblDwtRateId)
        {
            IQuery query = this.Session.GetNamedQuery("IblDwtRateDAO.SelectByIdForSaveAppServer");
            query.SetInt32("IblDwtRateId", IblDwtRateId);
            return query.UniqueResult<TLMDTO00030>();
        }
    }
}
