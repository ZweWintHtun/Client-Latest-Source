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
    public class LOMDAO00010 : DataRepository<LOMORM00010>, ILOMDAO00010
    {
        public bool CheckExist(string kstockNo,string  desp, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("KStockDAO.CheckExist");
            query.SetString("kstockno", kstockNo);
            query.SetString("desp", desp);
            IList<LOMDTO00010> KStockNoList = query.List<LOMDTO00010>();
            return KStockNoList == null ? false : this.CheckKStockNoList(KStockNoList,kstockNo, isEdit);
        }

        public IList<LOMDTO00010> CheckExist2(string kstockNo, string kstockName)
        {
            IQuery query = this.Session.GetNamedQuery("KStockDAO.CheckExist2");
            query.SetString("kstockNo", kstockNo);
            query.SetString("kstockName", kstockName);
            IList<LOMDTO00010> KStockNoList = query.List<LOMDTO00010>();
            return KStockNoList;
        }

        public IList<LOMDTO00010> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("KStockDAO.SelectAll");
            return query.List<LOMDTO00010>();
        }

        public LOMDTO00010 SelectByCode(string kstockNo)
        {
            IQuery query = this.Session.GetNamedQuery("KStockDAO.SelectByCode");
            query.SetString("kstockno", kstockNo);
            return query.UniqueResult<LOMDTO00010>();
        }

        private bool CheckKStockNoList(IList<LOMDTO00010> kstockNoList, string kstockNo, bool isEdit)
        {
            foreach (LOMDTO00010 info in kstockNoList)
            {
                if (info.KStockNo != kstockNo && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }




    }
}
