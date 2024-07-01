using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00001 : DataRepository<LOMORM00001>, ILOMDAO00001
    {
        public bool CheckExist(string businessCode, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("BusinessDAO.CheckExist");
            query.SetString("code", businessCode);
            query.SetString("description", description);
            IList<LOMDTO00001> BusinessCodeList = query.List<LOMDTO00001>();
            return BusinessCodeList == null ? false : this.CheckDTOList(BusinessCodeList, businessCode, isEdit);
        }

        public IList<LOMDTO00001> CheckExist2(string businessCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("BusinessDAO.CheckExist2");
            query.SetString("code", businessCode);
            query.SetString("description", description);
            IList<LOMDTO00001> BusinessCodeList = query.List<LOMDTO00001>();
            return BusinessCodeList;
        }

        public IList<LOMDTO00001> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("BusinessDAO.SelectAll");
            return query.List<LOMDTO00001>();
        }

        public LOMDTO00001 SelectByBusinessCode(string businessCode)
        {
            IQuery query = this.Session.GetNamedQuery("BusinessDAO.SelectByCode");
            query.SetString("code", businessCode);
            return query.UniqueResult<LOMDTO00001>();
        }

        private bool CheckDTOList(IList<LOMDTO00001> businessCodeList, string businessCode, bool isEdit)
        {
            foreach (LOMDTO00001 info in businessCodeList)
            {
                if (info.Code != businessCode && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
