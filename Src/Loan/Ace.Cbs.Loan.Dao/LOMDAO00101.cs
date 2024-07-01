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
    public class LOMDAO00101 : DataRepository<LOMORM00101>, ILOMDAO00101
    {
        public bool CheckExist(string Code, string description, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("SubProductTypeDAO.CheckExist");
            query.SetString("code", Code);
            query.SetString("description", description);
            IList<LOMDTO00101> SubProductTypeList = query.List<LOMDTO00101>();
            return SubProductTypeList == null ? false : this.CheckDTOList(SubProductTypeList, Code, isEdit);
        }

        public IList<LOMDTO00101> CheckExist2(string Code, string description)
        {
            IQuery query = this.Session.GetNamedQuery("SubProductTypeDAO.CheckExist2");
            query.SetString("code", Code);
            query.SetString("description", description);
            IList<LOMDTO00101> BusinessCodeList = query.List<LOMDTO00101>();
            return BusinessCodeList;
        }

        public IList<LOMDTO00101> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("SubProductTypeDAO.SelectAll");
            return query.List<LOMDTO00101>();
        }

        public LOMDTO00101 SelectBySubProductType(string Code)
        {
            IQuery query = this.Session.GetNamedQuery("SubProductTypeDAO.SelectByCode");
            query.SetString("code", Code);
            return query.UniqueResult<LOMDTO00101>();
        }

        private bool CheckDTOList(IList<LOMDTO00101> subProductTypeList, string Code, bool isEdit)
        {
            foreach (LOMDTO00101 info in subProductTypeList)
            {
                if (info.Code != Code && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
