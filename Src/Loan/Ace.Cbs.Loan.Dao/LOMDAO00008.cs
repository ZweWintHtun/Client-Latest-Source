using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00008 : DataRepository<LOMORM00008>, ILOMDAO00008
    {
        public bool CheckExist(string kind, string desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("GJKDAO.CheckExist");
            query.SetString("kind", kind);
            query.SetString("description", desp);
            IList<LOMDTO00008> GJKCodeList = query.List<LOMDTO00008>();
            return GJKCodeList == null ? false : this.CheckDTOList(GJKCodeList, kind, isEdit);
        }

        private bool CheckDTOList(IList<LOMDTO00008> gjkCodeList, string kind, bool isEdit)
        {
            foreach (LOMDTO00008 info in gjkCodeList)
            {
                if (info.Kind != kind && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        public IList<LOMDTO00008> CheckExist2(string kind, string desp)
        {
            IQuery query = this.Session.GetNamedQuery("GJKDAO.CheckExist2");
            query.SetString("kind", kind);
            query.SetString("description", desp);
            IList<LOMDTO00008> GJKCodeList = query.List<LOMDTO00008>();
            return GJKCodeList;
        }


        public IList<LOMDTO00008> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("GJKDAO.SelectAll");
            return query.List<LOMDTO00008>();
        }

        public LOMDTO00008 SelectByGjKind(string kind)
        {
            IQuery query = this.Session.GetNamedQuery("GJKDAO.SelectByCode");
            query.SetString("kind", kind);
            return query.UniqueResult<LOMDTO00008>();
        }

        public void ManualUpdate(LOMORM00008 entity)
        {
            IQuery query = this.Session.GetNamedQuery("GJKDAO.Update");
            query.SetString("desp", entity.Description);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", entity.UpdatedUserId.Value);
            query.SetString("kind", entity.Kind);
            query.ExecuteUpdate();
        }
    }
}
