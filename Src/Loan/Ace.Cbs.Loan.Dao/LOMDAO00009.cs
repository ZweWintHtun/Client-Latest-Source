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
    public class LOMDAO00009 : DataRepository<LOMORM00009>, ILOMDAO00009
    {

        public bool CheckExist(string stockNo, string name, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("StockDAO.CheckExist");
            query.SetString("stockNo", stockNo);
            query.SetString("name", name);
            IList<LOMDTO00009> StockNoList = query.List<LOMDTO00009>();
            return StockNoList == null ? false : this.CheckStockNoList(StockNoList, stockNo, isEdit);
        }

        public IList<LOMDTO00009> CheckExist2(string stockNo, string stockName)
        {
            IQuery query = this.Session.GetNamedQuery("StockDAO.CheckExist2");
            query.SetString("stockNo", stockNo);
            query.SetString("stockName", stockName);
            IList<LOMDTO00009> StockNoList = query.List<LOMDTO00009>();
            return StockNoList;
        }

        public IList<LOMDTO00009> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("StockDAO.SelectAll");
            return query.List<LOMDTO00009>();
        }

        public LOMDTO00009 SelectByCode(string stockNo)
        {
            IQuery query = this.Session.GetNamedQuery("StockDAO.SelectByCode");
            query.SetString("stockNo", stockNo);
            return query.UniqueResult<LOMDTO00009>();
        }

        private bool CheckStockNoList(IList<LOMDTO00009> stockNoList, string stockNo, bool isEdit)
        {
            foreach (LOMDTO00009 info in stockNoList)
          
            {
                if (info.StockNo != stockNo && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }


    }
}
