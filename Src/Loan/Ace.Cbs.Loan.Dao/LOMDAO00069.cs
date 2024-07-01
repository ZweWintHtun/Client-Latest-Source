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
    public class LOMDAO00069 : DataRepository<LOMORM00069>, ILOMDAO00069
    {
        public IList<LOMDTO00069> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("StockItemDAO.SelectAll");
            return query.List<LOMDTO00069>();
        }

        public IList<LOMDTO00069> CheckExist2(string groupCode, string subCode, string description)
        {
            IQuery query = this.Session.GetNamedQuery("StockItemDAO.CheckExist2");
            //query.SetString("groupCode", groupCode);
            query.SetString("subCode", subCode);
            //query.SetString("description", description);
            IList<LOMDTO00069> stockitemList = query.List<LOMDTO00069>();
            return stockitemList;
        }

        public bool CheckExist(string groupCode, string desp, string subCode, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("StockItemDAO.CheckExist");
            //query.SetString("groupCode", groupCode);
            //query.SetString("description", desp);
            query.SetString("subCode", subCode);
            IList<LOMDTO00069> stockitemList = query.List<LOMDTO00069>();

            return stockitemList.Count == null ? false : this.CheckDTOList(stockitemList, subCode, isEdit);
        }

        public bool CheckDTOList(IList<LOMDTO00069> stockItemList, string subCode, bool isEdit)
        {
            foreach (LOMDTO00069 stockItemDto in stockItemList)
            {
                if (stockItemDto.SubCode != subCode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
    }
}
