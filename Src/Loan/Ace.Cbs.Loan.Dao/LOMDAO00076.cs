using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00076 : DataRepository<LOMORM00076>, ILOMDAO00076
    {
        public bool CheckExist(string lsBusinessCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("LSBusinessDAO.CheckExist");
            query.SetString("code", lsBusinessCode);
            query.SetString("description", description);
            IList<LOMDTO00076> LSBusinessCodeList = query.List<LOMDTO00076>();
            return LSBusinessCodeList == null ? false : this.CheckDTOList(LSBusinessCodeList, lsBusinessCode, isEdit);
        }

        public IList<LOMDTO00076> CheckExist2(string lsBusinessCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("LSBusinessDAO.CheckExist2");
            query.SetString("code", lsBusinessCode);
            query.SetString("description", description);
            IList<LOMDTO00076> LSBusinessCodeList = query.List<LOMDTO00076>();
            return LSBusinessCodeList;
        }

        public IList<LOMDTO00076> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("LSBusinessDAO.SelectAll");
            return query.List<LOMDTO00076>();
        }

        public LOMDTO00076 SelectByLsBusinessCode(string lsBusinessCode)
        {
            IQuery query = this.Session.GetNamedQuery("LSBusinessDAO.SelectByCode");
            query.SetString("code", lsBusinessCode);
            return query.UniqueResult<LOMDTO00076>();
        }

        private bool CheckDTOList(IList<LOMDTO00076> lsBusinessCodeList, string lsBusinessCode, bool isEdit)
        {
            foreach (LOMDTO00076 info in lsBusinessCodeList)
            {
                if (info.Code != lsBusinessCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

    }
}
