using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00068 : DataRepository<LOMORM00068>, ILOMDAO00068
    {
        public IList<LOMDTO00068> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("StockGroupDAO.SelectAll");
            return query.List<LOMDTO00068>();
        }

        public IList<LOMDTO00068> CheckExist2(string groupCode,string prefix, string description)
        {
            IQuery query = this.Session.GetNamedQuery("StockGroupDAO.CheckExist2");
            query.SetString("groupCode", groupCode);
            query.SetString("prefix", prefix);
            query.SetString("description", description);
            IList<LOMDTO00068> stockgroupList = query.List<LOMDTO00068>();
            return stockgroupList;
        }

        public bool CheckExist(string groupCode, string desp, string prefix, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("StockGroupDAO.CheckExist");
            query.SetString("groupCode", groupCode);
            query.SetString("description", desp);
            query.SetString("prefix", prefix);
            IList<LOMDTO00068> stockGroupList = query.List<LOMDTO00068>();

            return stockGroupList.Count == null ? false : this.CheckDTOList(stockGroupList, groupCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00068> stockGroupList, string groupCode, bool isEdit)
        {
            foreach (LOMDTO00068 stockGroupDto in stockGroupList)
            {
                if (stockGroupDto.GroupCode != groupCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
